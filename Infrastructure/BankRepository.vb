Imports System.Data
Imports System.Security.Cryptography
Imports Oracle.ManagedDataAccess.Client
Imports Pocketbank_vWF.Domain

Namespace Infrastructure
    ' Each operation owns its connection; callers run these bounded operations off the UI thread.
    ' Transfers lock both accounts in deterministic order and commit the ledger and balances together.
    Public Class BankRepository
        Private ReadOnly connectionString As String
        Private ReadOnly schema As String
        Public Sub New(settings As LocalSettings)
            connectionString = settings.ConnectionString()
            schema = settings.Schema
            If Not System.Text.RegularExpressions.Regex.IsMatch(schema, "^[A-Z][A-Z0-9_]{0,29}$") Then Throw New ArgumentException("Invalid Oracle schema name.")
        End Sub

        Private Function Connect() As OracleConnection
            Dim c As New OracleConnection(connectionString)
            Try
                c.Open()
                Using cmd = c.CreateCommand()
                    cmd.CommandText = "ALTER SESSION SET CURRENT_SCHEMA=" & schema
                    cmd.ExecuteNonQuery()
                End Using
                Return c
            Catch
                c.Dispose()
                Throw
            End Try
        End Function

        Private Shared Function Command(c As OracleConnection, sql As String, ParamArray values() As Object) As OracleCommand
            Dim cmd = c.CreateCommand()
            cmd.BindByName = True
            cmd.CommandText = sql
            cmd.CommandTimeout = 15
            For i = 0 To values.Length - 1
                Dim p = cmd.Parameters.Add("p" & i, If(TypeOf values(i) Is Long OrElse TypeOf values(i) Is Integer, OracleDbType.Int64, OracleDbType.Varchar2))
                p.Value = If(values(i), DBNull.Value)
            Next
            Return cmd
        End Function

        Private Shared Function Execute(c As OracleConnection, sql As String, ParamArray values() As Object) As Integer
            Using cmd = Command(c, sql, values)
                Return cmd.ExecuteNonQuery()
            End Using
        End Function

        Public Sub CheckConnection()
            Using c = Connect(), cmd = Command(c, "SELECT COUNT(*) FROM pb_users")
                cmd.ExecuteScalar()
            End Using
        End Sub

        Public Function SignIn(email As String, password As String) As BankUser
            Using c = Connect()
                Dim result As BankUser = Nothing
                Dim hash As String = ""
                Using cmd = Command(c, "SELECT id,display_name,email,password_hash FROM pb_users WHERE email=:p0", email), r = cmd.ExecuteReader()
                    If r.Read() Then
                        result = New BankUser With {.Id = r.GetString(0), .DisplayName = r.GetString(1), .Email = r.GetString(2)}
                        hash = r.GetString(3)
                    End If
                End Using
                If result Is Nothing OrElse Not Services.Passwords.Verify(password, hash) Then Throw New BankingException("Email or password is incorrect.")
                If Not hash.StartsWith("pbkdf2:", StringComparison.Ordinal) Then
                    Execute(c, "UPDATE pb_users SET password_hash=:p0 WHERE id=:p1", Services.Passwords.Hash(password), result.Id)
                End If
                Return result
            End Using
        End Function

        Public Function Register(name As String, email As String, hash As String) As BankUser
            Using c = Connect(), tx = c.BeginTransaction()
                Try
                    Dim u As New BankUser With {.Id = Guid.NewGuid().ToString(), .DisplayName = name, .Email = email}
                    Execute(c, "INSERT INTO pb_users VALUES (:p0,:p1,:p2,:p3)", u.Id, name, email, hash)
                    InsertAccount(c, u.Id, "Checking", 100000)
                    tx.Commit()
                    Return u
                Catch ex As OracleException When ex.Number = 1
                    Throw New BankingException("An account with this email already exists.")
                End Try
            End Using
        End Function

        Private Shared Function InsertAccount(c As OracleConnection, userId As String, kind As String, cents As Long) As String
            Dim number = Convert.ToHexString(RandomNumberGenerator.GetBytes(8))
            Execute(c, "INSERT INTO pb_accounts VALUES (:p0,:p1,:p2,:p3)", number, userId, kind, cents)
            Return number
        End Function

        Public Sub OpenSavings(userId As String)
            Using c = Connect(), tx = c.BeginTransaction()
                Try
                    InsertAccount(c, userId, "Savings", 0)
                    tx.Commit()
                Catch ex As OracleException When ex.Number = 1
                    Throw New BankingException("Your savings account is already open. Refresh to see it.")
                End Try
            End Using
        End Sub

        Public Function LoadDashboard(userId As String) As Dashboard
            Dim result As New Dashboard()
            Using c = Connect(), tx = c.BeginTransaction(IsolationLevel.Serializable)
                Using cmd = Command(c, "SELECT account_number,kind,balance_cents FROM pb_accounts WHERE user_id=:p0 ORDER BY kind", userId), r = cmd.ExecuteReader()
                    While r.Read()
                        result.Accounts.Add(New BankAccount With {.Number = r.GetString(0), .Kind = r.GetString(1), .BalanceCents = r.GetInt64(2)})
                    End While
                End Using
                Using cmd = Command(c, "SELECT t.reference,t.created_at,t.amount_cents,t.source_number,t.destination_number,s.user_id,d.user_id,su.display_name,du.display_name FROM pb_transactions t LEFT JOIN pb_accounts s ON s.account_number=t.source_number JOIN pb_accounts d ON d.account_number=t.destination_number LEFT JOIN pb_users su ON su.id=s.user_id JOIN pb_users du ON du.id=d.user_id WHERE s.user_id=:p0 OR d.user_id=:p0 ORDER BY t.created_at DESC,t.reference", userId), r = cmd.ExecuteReader()
                    While r.Read()
                        Dim ownSource = Not r.IsDBNull(5) AndAlso r.GetString(5) = userId
                        Dim ownDestination = r.GetString(6) = userId
                        Dim direction = If(ownSource AndAlso ownDestination, "Internal", If(ownSource, "Sent", "Received"))
                        result.Transactions.Add(New Activity With {.Reference = r.GetString(0), .CreatedAt = DateTime.SpecifyKind(r.GetDateTime(1), DateTimeKind.Utc), .AmountCents = r.GetInt64(2), .Source = If(r.IsDBNull(3), "", r.GetString(3)), .Destination = r.GetString(4), .Direction = direction, .Description = If(ownSource AndAlso ownDestination, "Between your accounts", If(ownSource, "Payment to " & r.GetString(8), "Payment from " & If(r.IsDBNull(7), "Pocket Bank", r.GetString(7))))})
                    End While
                End Using
                tx.Commit()
            End Using
            Return result
        End Function

        Private Shared Function ValidateTransfer(c As OracleConnection, userId As String, draft As TransferDraft, lockRows As Boolean) As TransferDraft
            If draft.AmountCents <= 0 OrElse draft.AmountCents > 9007199254740991L Then Throw New BankingException("Enter a positive amount with up to two decimal places.")
            If draft.Source = draft.Destination Then Throw New BankingException("Choose a different destination account.")
            Dim sourceOwner = "", destinationOwner = "", kind = "", name = ""
            Dim sourceBalance As Long, destinationBalance As Long
            ' Sort lock acquisition to avoid opposing transfers deadlocking.
            For Each number In New String() {draft.Source, draft.Destination}.OrderBy(Function(n) n, StringComparer.Ordinal)
                Using cmd = Command(c, "SELECT user_id,kind,balance_cents FROM pb_accounts WHERE account_number=:p0" & If(lockRows, " FOR UPDATE WAIT 5", ""), number), r = cmd.ExecuteReader()
                    If Not r.Read() Then Throw New BankingException("Account not found. Check the recipient's checking account number.")
                    If number = draft.Source Then
                        sourceOwner = r.GetString(0)
                        sourceBalance = r.GetInt64(2)
                    Else
                        destinationOwner = r.GetString(0)
                        kind = r.GetString(1)
                        destinationBalance = r.GetInt64(2)
                    End If
                End Using
            Next
            If sourceOwner <> userId Then Throw New BankingException("You can only send money from your own accounts.")
            If destinationOwner <> userId AndAlso kind <> "Checking" Then Throw New BankingException("Payments to another user must go to their checking account.")
            If sourceBalance < draft.AmountCents Then Throw New BankingException("Insufficient funds. Choose a smaller amount or another account.")
            If destinationBalance > 9007199254740991L - draft.AmountCents Then Throw New BankingException("The recipient cannot receive this amount.")
            Using cmd = Command(c, "SELECT display_name FROM pb_users WHERE id=:p0", destinationOwner)
                name = CStr(cmd.ExecuteScalar())
            End Using
            Return New TransferDraft With {.Source = draft.Source, .Destination = draft.Destination, .AmountCents = draft.AmountCents, .Recipient = name, .DestinationKind = kind, .RequestId = draft.RequestId}
        End Function

        Public Function Review(userId As String, draft As TransferDraft) As TransferDraft
            Using c = Connect()
                Return ValidateTransfer(c, userId, draft, False)
            End Using
        End Function

        Public Function Transfer(userId As String, draft As TransferDraft) As String
            Dim request As Guid
            If Not Guid.TryParseExact(draft.RequestId, "D", request) Then Throw New BankingException("Invalid transfer request. Start a new transfer.")
            Using c = Connect(), tx = c.BeginTransaction()
                ' Serialize retries on the initiating user before reading the idempotency key.
                Using cmd = Command(c, "SELECT id FROM pb_users WHERE id=:p0 FOR UPDATE WAIT 5", userId), r = cmd.ExecuteReader()
                    If Not r.Read() Then Throw New BankingException("Please sign in again.")
                End Using
                Using cmd = Command(c, "SELECT reference,source_number,destination_number,amount_cents FROM pb_transactions WHERE request_id=:p0", userId & ":" & draft.RequestId), r = cmd.ExecuteReader()
                    If r.Read() Then
                        If r.GetString(1) <> draft.Source OrElse r.GetString(2) <> draft.Destination OrElse r.GetInt64(3) <> draft.AmountCents Then Throw New BankingException("This transfer request was already used. Start a new transfer.")
                        Return r.GetString(0)
                    End If
                End Using
                ValidateTransfer(c, userId, draft, True)
                Execute(c, "UPDATE pb_accounts SET balance_cents=balance_cents-:p0 WHERE account_number=:p1", draft.AmountCents, draft.Source)
                Execute(c, "UPDATE pb_accounts SET balance_cents=balance_cents+:p0 WHERE account_number=:p1", draft.AmountCents, draft.Destination)
                Dim reference = Guid.NewGuid().ToString()
                Execute(c, "INSERT INTO pb_transactions(reference,source_number,destination_number,amount_cents,request_id) VALUES (:p0,:p1,:p2,:p3,:p4)", reference, draft.Source, draft.Destination, draft.AmountCents, userId & ":" & draft.RequestId)
                tx.Commit()
                Return reference
            End Using
        End Function

        Public Sub InitializeSchema()
            Using c = Connect(), stream = GetType(BankRepository).Assembly.GetManifestResourceStream("Pocketbank_vWF.Database.schema.sql"), reader As New IO.StreamReader(stream)
                For Each statement In reader.ReadToEnd().Split(";"c)
                    If Not String.IsNullOrWhiteSpace(statement) Then Execute(c, statement.Trim())
                Next
            End Using
        End Sub

        Public Sub ImportUsers(users As IEnumerable(Of ImportedUser))
            Using c = Connect(), tx = c.BeginTransaction()
                Using cmd = Command(c, "SELECT COUNT(*) FROM pb_users")
                    If Convert.ToInt32(cmd.ExecuteScalar()) <> 0 Then Throw New BankingException("Import requires an empty Pocket Bank schema; existing data has not been changed.")
                End Using
                For Each u In users
                    Execute(c, "INSERT INTO pb_users VALUES (:p0,:p1,:p2,:p3)", u.id, u.display_name, u.email, u.password_hash)
                    InsertAccount(c, u.id, "Checking", 100000)
                Next
                tx.Commit()
            End Using
        End Sub
    End Class

    Public Class ImportedUser
        Public Property id As String = ""
        Public Property display_name As String = ""
        Public Property email As String = ""
        Public Property password_hash As String = ""
    End Class
End Namespace
