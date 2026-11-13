# Pocketbank Winforms Edition

Pocketbank is a Windows desktop banking simulator built with VB.NET, .NET 10 WinForms, and Oracle XE. Create an account, manage fictional checking and savings balances, transfer funds, and view transaction history.

## Quick start

1. Install the .NET 10 SDK, PowerShell 7, and Oracle Database XE with a local `XEPDB1` pluggable database. Use a Windows account with local Oracle SYSDBA access.
2. For a fresh installation, open PowerShell 7 in the project folder and run `.\scripts\Setup-Oracle.ps1` to initialize the database. Start the Oracle listener first if your account cannot start Windows services.
3. Run `dotnet run --project Pocketbank_vWF.vbproj`, or open `Pocketbank_vWF.slnx` in Visual Studio and press F5. Choose **Register** on the sign-in screen to create an account.

If setup creates the database but cannot connect, make sure the Oracle listener is running and check the connection with:

```powershell
dotnet run --project tools\PocketBank.Tools.vbproj -- check
```
