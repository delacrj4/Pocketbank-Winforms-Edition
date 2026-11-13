[CmdletBinding()]
param(
    [string]$OracleHome = '',
    [string]$DataSource = 'localhost:1521/XEPDB1',
    [string]$AngularPath = ''
)
$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path -Parent $PSScriptRoot
$settingsPath = Join-Path ([Environment]::GetFolderPath('LocalApplicationData')) 'PocketBank\connection.json'
if (Test-Path -LiteralPath $settingsPath) {
    throw 'Pocket Bank connection settings already exist. Setup never overwrites credentials or resets a database. Run the check command in README to verify the existing setup.'
}
if (-not $OracleHome) {
    $oracleKey = Get-ChildItem 'HKLM:\SOFTWARE\ORACLE' | Where-Object PSChildName -Like 'KEY_*' | Select-Object -First 1
    if ($oracleKey) { $OracleHome = (Get-ItemProperty $oracleKey.PSPath).ORACLE_HOME }
}
$sqlplus = Join-Path $OracleHome 'bin\sqlplus.exe'
if (-not (Test-Path -LiteralPath $sqlplus)) { throw 'Oracle SQL*Plus was not found. Supply -OracleHome.' }
$env:ORACLE_HOME = $OracleHome
$env:ORACLE_SID = 'XE'

Write-Host 'Starting the installed Oracle listener if needed...'
$listener = Get-Service '*TNSListener' | Select-Object -First 1
if ($listener.Status -ne 'Running') {
    Start-Service -InputObject $listener
}

function Invoke-LocalSql([string]$Sql) {
    $lines = @"
whenever oserror exit failure
whenever sqlerror exit failure rollback
set echo off heading off feedback off verify off
$Sql
exit
"@ | & $sqlplus -L -s '/ as sysdba' 2>&1
    if ($LASTEXITCODE -ne 0) {
        # Do not echo SQL: it can contain newly generated credentials.
        $code = [regex]::Match(($lines -join "`n"), 'ORA-\d+').Value
        throw "Oracle setup failed ($code). Check local SYSDBA access and XEPDB1 availability. No existing schema is reset."
    }
    return ($lines -join "`n")
}

$pdbState = Invoke-LocalSql "select open_mode from v`$pdbs where name='XEPDB1';"
if ($pdbState -notmatch 'READ WRITE') { $null = Invoke-LocalSql 'alter pluggable database XEPDB1 open;' }
$exists = Invoke-LocalSql "alter session set container=XEPDB1;`nselect count(*) from dba_users where username in ('POCKETBANK_OWNER','POCKETBANK_APP');"
if ($exists.Trim() -ne '0') { throw 'A Pocket Bank database user already exists. Setup stopped without changing it.' }

# Owner performs installation; runtime user receives only the CRUD grants the app needs.
$ownerPassword = 'Pb' + [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(12))
$appPassword = 'Pb' + [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(12))
$schema = Get-Content -LiteralPath (Join-Path $projectRoot 'Database\schema.sql') -Raw
$null = Invoke-LocalSql @"
alter session set container=XEPDB1;
create user POCKETBANK_OWNER identified by "$ownerPassword" default tablespace USERS quota 20M on USERS;
grant create session, create table to POCKETBANK_OWNER;
alter session set current_schema=POCKETBANK_OWNER;
$schema
create user POCKETBANK_APP identified by "$appPassword";
grant create session to POCKETBANK_APP;
grant select,insert,update,delete on POCKETBANK_OWNER.pb_users to POCKETBANK_APP;
grant select,insert,update,delete on POCKETBANK_OWNER.pb_accounts to POCKETBANK_APP;
grant select,insert,update,delete on POCKETBANK_OWNER.pb_transactions to POCKETBANK_APP;
alter user POCKETBANK_OWNER account lock;
alter system register;
"@

Add-Type -AssemblyName System.Security.Cryptography.ProtectedData
$protected = [Convert]::ToBase64String([Security.Cryptography.ProtectedData]::Protect([Text.Encoding]::UTF8.GetBytes($appPassword), $null, [Security.Cryptography.DataProtectionScope]::CurrentUser))
$null = New-Item -ItemType Directory -Path (Split-Path -Parent $settingsPath) -Force
@{ DataSource = $DataSource; UserId = 'POCKETBANK_APP'; Schema = 'POCKETBANK_OWNER'; ProtectedPassword = $protected } | ConvertTo-Json | Set-Content -LiteralPath $settingsPath
$ownerPassword = $null
$appPassword = $null

dotnet build (Join-Path $projectRoot 'tools\PocketBank.Tools.vbproj') --configuration Release --verbosity quiet
if ($LASTEXITCODE -ne 0) { throw 'Build failed. Schema and encrypted settings are created; see README recovery instructions.' }
$utility = Join-Path $projectRoot 'tools\bin\Release\net10.0-windows\PocketBank.Tools.dll'
# Oracle may take a moment to advertise the newly opened PDB to the listener.
dotnet $utility check
if ($LASTEXITCODE -ne 0) { throw 'Schema created. Listener registration may still be pending; rerun the check command from README shortly.' }
if ($AngularPath) {
    $local = Join-Path $projectRoot '.local'
    $null = New-Item -ItemType Directory -Path $local -Force
    $export = Join-Path $local ('users-' + [Guid]::NewGuid().ToString('N') + '.json')
    try {
        node (Join-Path $PSScriptRoot 'export-users.cjs') (Join-Path $AngularPath 'server\data\pocketbank.sqlite') $export
        if ($LASTEXITCODE -ne 0) { throw 'Read-only Angular account export failed.' }
        dotnet $utility import $export
        if ($LASTEXITCODE -ne 0) { throw 'Account import failed. The JSON remains local until the cleanup below.' }
    }
    finally {
        # Delete only the specific temporary file this invocation created.
        if (Test-Path -LiteralPath $export) { Remove-Item -LiteralPath $export }
    }
}
Write-Host 'Pocket Bank is ready. Open the solution and run, or use dotnet run.'
