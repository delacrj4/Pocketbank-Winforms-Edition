Imports System.IO
Imports System.Text.Json
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Imports Pocketbank_vWF.Domain
Imports Pocketbank_vWF.Infrastructure
Imports Pocketbank_vWF.Services

Module Program
    Private passed As Integer

    <STAThread>
    Sub Main(args As String())
        Try
            If args.Length > 0 AndAlso args(0) = "ui-test" Then
                UiVerification.Run(If(args.Length > 1, args(1), ""))
                Return
            End If
            Dim settings = LocalSettings.Load()
            Dim repo As New BankRepository(settings)
            Select Case If(args.Length = 0, "", args(0))
                Case "initialize"
                    repo.InitializeSchema()
                    Console.WriteLine("Oracle schema created.")
                Case "import"
                    If args.Length <> 2 Then Throw New ArgumentException("Usage: import <local users JSON>")
                    Dim users = JsonSerializer.Deserialize(Of List(Of ImportedUser))(File.ReadAllText(args(1)))
                    repo.ImportUsers(users)
                    Console.WriteLine($"Imported {users.Count} sign-ins with fresh checking accounts.")
                Case "check"
                    repo.CheckConnection()
                    Console.WriteLine("Oracle connection and schema are ready.")
                Case "test"
                    TestBank(repo, settings)
                Case "ui"
                    PreviewUI(repo, settings)
                Case Else
                    Throw New ArgumentException("Commands: initialize | import <path> | check | test | ui | ui-test [render-folder]")
            End Select
        Catch ex As Exception
            Console.Error.WriteLine(ex.GetType().Name & ": " & ex.Message)
            Environment.ExitCode = 1
        End Try
    End Sub

    Private Sub PreviewUI(repo As BankRepository, settings As LocalSettings)
        Dim address = "wf-preview-" & Guid.NewGuid().ToString("N") & "@example.invalid"
        Dim secret = Convert.ToHexString(RandomNumberGenerator.GetBytes(16))
        Dim service As New BankService(repo)
        Dim user = service.Register("Alex Morgan", address, secret)
        Try
            System.Windows.Forms.Application.SetHighDpiMode(System.Windows.Forms.HighDpiMode.PerMonitorV2)
            System.Windows.Forms.Application.EnableVisualStyles()
            Using form As New Pocketbank_vWF.Form1(service, service.Dashboard())
                form.Text = "Pocket Bank — UI verification"
                System.Windows.Forms.Application.Run(form)
            End Using
        Finally
            CleanupFixtures(settings, {user})
        End Try
    End Sub

    Private Sub Check(condition As Boolean, description As String)
        If Not condition Then Throw New Exception("FAIL: " & description)
        passed += 1
        Console.WriteLine("PASS: " & description)
    End Sub

    Private Sub Rejected(action As Action, description As String)
        Try
            action()
        Catch ex As BankingException
            Check(True, description)
            Return
        End Try
        Throw New Exception("FAIL: " & description)
    End Sub

    Private Sub TestBank(repo As BankRepository, settings As LocalSettings)
        Dim hash = Passwords.Hash("practice-password")
        Check(Passwords.Verify("practice-password", hash), "PBKDF2 password verification")
        Check(Not Passwords.Verify("wrong", hash), "Wrong password rejected")
        ' Fixed Node.js crypto.scrypt-compatible fixture; contains no user credentials.
        Dim salt = "0123456789abcdef0123456789abcdef"
        Dim legacy = "d9c28c30e8175c5701a675a9f04cb4435e9270e08a7c25929e782aadfab49b0db0ba7a56945155df0164897936205767ee3e67712ffb0a209fb0ee70713c48a7"
        Check(Passwords.Verify("compatibility-test", salt & ":" & legacy), "Legacy scrypt matches independent Node.js fixture")
        Dim prefix = "wf-test-" & Guid.NewGuid().ToString("N")
        Dim first As BankUser = Nothing, second As BankUser = Nothing
        Try
            first = repo.Register("Test Sender", prefix & "@example.invalid", hash)
            second = repo.Register("Test Receiver", prefix & "-2@example.invalid", hash)
            Dim a = repo.LoadDashboard(first.Id).Accounts.Single()
            Dim b = repo.LoadDashboard(second.Id).Accounts.Single()
            Check(a.BalanceCents = 100000 AndAlso repo.LoadDashboard(first.Id).Transactions.Count = 0, "Fresh checking balance and empty history")
            Check(repo.SignIn(first.Email, "practice-password").Id = first.Id, "Oracle sign-in")
            Rejected(Sub() repo.SignIn(first.Email, "wrong-password"), "Invalid Oracle sign-in")
            Rejected(Sub() repo.Register("Duplicate", first.Email, hash), "Duplicate registration rejected atomically")
            repo.OpenSavings(first.Id)
            Dim savings = repo.LoadDashboard(first.Id).Accounts.Single(Function(x) x.Kind = "Savings")
            Check(savings.BalanceCents = 0, "Savings opens at zero")
            Rejected(Sub() repo.OpenSavings(first.Id), "Only one savings account")
            Dim draft As New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 2500}
            Check(repo.Review(first.Id, draft).Recipient = "Test Receiver", "Recipient preview")
            Dim reference = repo.Transfer(first.Id, draft)
            Check(repo.Transfer(first.Id, draft) = reference, "Retry returns same reference")
            Check(repo.LoadDashboard(first.Id).Accounts.Single(Function(x) x.Kind = "Checking").BalanceCents = 97500, "Debit applied once")
            Check(repo.LoadDashboard(second.Id).Accounts.Single().BalanceCents = 102500, "Credit applied once")
            Check(repo.LoadDashboard(first.Id).Transactions.Single().Direction = "Sent" AndAlso repo.LoadDashboard(second.Id).Transactions.Single().Direction = "Received", "Both histories reflect the transfer")
            Rejected(Sub() repo.Transfer(first.Id, New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 1, .RequestId = draft.RequestId}), "Changed retry payload rejected")
            Rejected(Sub() repo.Transfer(second.Id, New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 1}), "Ownership enforced")
            Rejected(Sub() repo.Transfer(first.Id, New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 999999}), "Overdraft rejected")
            Rejected(Sub() repo.Transfer(first.Id, New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 0}), "Zero amount rejected")
            Rejected(Sub() repo.Transfer(first.Id, New TransferDraft With {.Source = a.Number, .Destination = a.Number, .AmountCents = 1}), "Self transfer rejected")
            Rejected(Sub() repo.Transfer(second.Id, New TransferDraft With {.Source = b.Number, .Destination = savings.Number, .AmountCents = 1}), "Other user's savings cannot receive payments")
            repo.Transfer(first.Id, New TransferDraft With {.Source = a.Number, .Destination = savings.Number, .AmountCents = 10000})
            Check(repo.LoadDashboard(first.Id).Accounts.Sum(Function(x) x.BalanceCents) = 97500, "Internal transfer preserves total")
            Check(repo.LoadDashboard(first.Id).Transactions.First().Direction = "Internal", "Internal transfer history")
            ' Opposing payments exercise lock ordering and conservation under concurrent use.
            Dim jobs = Enumerable.Range(0, 10).Select(Function(i) Task.Run(Sub()
                                                                             If i Mod 2 = 0 Then
                                                                                 repo.Transfer(first.Id, New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 100})
                                                                             Else
                                                                                 repo.Transfer(second.Id, New TransferDraft With {.Source = b.Number, .Destination = a.Number, .AmountCents = 100})
                                                                             End If
                                                                         End Sub)).ToArray()
            Task.WaitAll(jobs)
            Check(repo.LoadDashboard(first.Id).Accounts.Sum(Function(x) x.BalanceCents) + repo.LoadDashboard(second.Id).Accounts.Sum(Function(x) x.BalanceCents) = 200000, "Concurrent opposing transfers conserve money")
            Check(repo.LoadDashboard(first.Id).Transactions.Count = 12, "Concurrent transfers recorded exactly once")
            Dim retry As New TransferDraft With {.Source = a.Number, .Destination = b.Number, .AmountCents = 100}
            Dim retries = Enumerable.Range(0, 5).Select(Function(i) Task.Run(Function() repo.Transfer(first.Id, retry))).ToArray()
            Task.WaitAll(retries)
            Check(retries.Select(Function(t) t.Result).Distinct().Count() = 1, "Concurrent identical retries commit once")
            Dim service As New BankService(repo)
            Rejected(Sub() service.Dashboard(), "Signed-out session cannot read accounts")
            service.SignIn(first.Email, "practice-password")
            service.SignOut()
            Rejected(Sub() service.OpenSavings(), "Sign-out invalidates session")
            Console.WriteLine($"{passed} checks passed against Oracle.")
        Finally
            ' Delete only the fixtures created by this run; no original account data is touched.
            CleanupFixtures(settings, {first, second})
        End Try
    End Sub

    Private Sub CleanupFixtures(settings As LocalSettings, users As IEnumerable(Of BankUser))
            Using c As New OracleConnection(settings.ConnectionString())
                c.Open()
                Using schemaCommand = c.CreateCommand()
                    schemaCommand.CommandText = "ALTER SESSION SET CURRENT_SCHEMA=" & settings.Schema
                    schemaCommand.ExecuteNonQuery()
                End Using
                Using tx = c.BeginTransaction()
                    For Each u In users
                        If u Is Nothing Then Continue For
                        For Each sql In {"DELETE FROM pb_transactions WHERE source_number IN (SELECT account_number FROM pb_accounts WHERE user_id=:id) OR destination_number IN (SELECT account_number FROM pb_accounts WHERE user_id=:id)", "DELETE FROM pb_accounts WHERE user_id=:id", "DELETE FROM pb_users WHERE id=:id"}
                            Using cmd = c.CreateCommand()
                                cmd.BindByName = True
                                cmd.CommandText = sql
                                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = u.Id
                                cmd.ExecuteNonQuery()
                            End Using
                        Next
                    Next
                    tx.Commit()
                End Using
            End Using
    End Sub
End Module
