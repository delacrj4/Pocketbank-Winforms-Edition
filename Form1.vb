Imports System.IO
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Imports Pocketbank_vWF.Domain
Imports Pocketbank_vWF.Infrastructure
Imports Pocketbank_vWF.Services
Imports Pocketbank_vWF.UI
Imports Pocketbank_vWF.UI.Views

Public Class Form1
    Private bank As BankService
    Private snapshot As New Dashboard()
    Private busy As Boolean

    ' Keep construction free of database access so the Visual Studio Designer can load it.
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(service As BankService, initial As Dashboard)
        Me.New()
        bank = service
        snapshot = initial
    End Sub

    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If bank IsNot Nothing Then
            Navigate("Accounts")
            SessionTimer.Start()
        Else
            AcceptButton = SignInPage.SubmitButton
            SignInPage.EmailTextBox.Select()
            Await RunAsync(AddressOf EnsureConnectedAsync, True)
        End If
    End Sub

    Private Async Function EnsureConnectedAsync() As Task
        If bank IsNot Nothing Then Return
        Dim repo As New BankRepository(LocalSettings.Load())
        Await Task.Run(Sub() repo.CheckConnection())
        bank = New BankService(repo)
    End Function

    Private Sub DisplayPage(view As UserControl)
        AcceptButton = Nothing
        For Each previous In PageHost.Controls.Cast(Of Control)().ToArray()
            PageHost.Controls.Remove(previous)
            previous.Dispose()
        Next
        Notice("")
        view.Dock = DockStyle.Fill
        PageHost.Controls.Add(view)
    End Sub

    Private Sub ShowSignIn()
        SessionTimer.Stop()
        SidebarPanel.Visible = False
        SignInPage = New SignInView()
        DisplayPage(SignInPage)
        AcceptButton = SignInPage.SubmitButton
        SignInPage.EmailTextBox.Select()
    End Sub

    Private Sub ShowRegistration() Handles SignInPage.CreateAccountRequested
        Dim view As New RegistrationView()
        AddHandler view.SignInRequested, AddressOf ShowSignIn
        AddHandler view.RegistrationRequested, Async Sub(name, email, password)
                                                         Await RunAsync(Async Function()
                                                                            Await EnsureConnectedAsync()
                                                                            Await Task.Run(Function() bank.Register(name, email, password))
                                                                            view.ClearPassword()
                                                                            Await CompleteSignInAsync()
                                                                        End Function)
                                                     End Sub
        DisplayPage(view)
        AcceptButton = view.SubmitButton
        view.NameTextBox.Select()
    End Sub

    Private Async Sub SignInRequested(email As String, password As String) Handles SignInPage.SignInRequested
        Await RunAsync(Async Function()
                           Await EnsureConnectedAsync()
                           Await Task.Run(Function() bank.SignIn(email, password))
                           SignInPage.ClearPassword()
                           Await CompleteSignInAsync()
                       End Function)
    End Sub

    Private Async Function CompleteSignInAsync() As Task
        snapshot = Await Task.Run(Function() bank.Dashboard())
        SessionTimer.Start()
        Navigate("Accounts")
    End Function

    Private Sub Navigate(page As String)
        Try
            Dim user = bank.CurrentUser
            UserNameLabel.Text = user.DisplayName
            SidebarPanel.Visible = True
            Select Case page
                Case "Accounts"
                    Dim view As New AccountsView()
                    view.BindDashboard(snapshot)
                    AddHandler view.TransferRequested, Sub() Navigate("Transfer")
                    AddHandler view.RefreshRequested, Async Sub() Await RefreshAsync("Accounts")
                    AddHandler view.OpenSavingsRequested, Async Sub()
                                                              Await RunAsync(Async Function()
                                                                                 Await Task.Run(Sub() bank.OpenSavings())
                                                                                 snapshot = Await Task.Run(Function() bank.Dashboard())
                                                                                 Navigate("Accounts")
                                                                                 Notice("Savings account opened.")
                                                                             End Function)
                                                          End Sub
                    DisplayPage(view)
                Case "Activity"
                    Dim view As New ActivityView()
                    view.BindDashboard(snapshot)
                    AddHandler view.RefreshRequested, Async Sub() Await RefreshAsync("Activity")
                    DisplayPage(view)
                Case "Transfer"
                    Dim view As New TransferView()
                    view.BindAccounts(snapshot.Accounts)
                    AddHandler view.ReviewRequested, Async Sub()
                                                         Await RunAsync(Async Function()
                                                                            Dim draft = view.ReadDraft()
                                                                            Dim reviewed = Await Task.Run(Function() bank.Review(draft))
                                                                            view.ShowReview(reviewed)
                                                                        End Function)
                                                     End Sub
                    AddHandler view.ConfirmationRequested, Async Sub()
                                                               Await RunAsync(Async Function()
                                                                                  Dim draft = view.ReviewedDraft
                                                                                  Dim reference = Await Task.Run(Function() bank.Transfer(draft))
                                                                                  ' Once committed, remove the confirmation controls before refreshing.
                                                                                  Navigate("Activity")
                                                                                  Try
                                                                                      snapshot = Await Task.Run(Function() bank.Dashboard())
                                                                                      Navigate("Activity")
                                                                                      Notice("Transfer complete. Reference " & reference)
                                                                                  Catch ex As OracleException
                                                                                      Notice("Transfer complete. Reference " & reference & ". Refresh to update balances.")
                                                                                  End Try
                                                                              End Function)
                                                           End Sub
                    DisplayPage(view)
            End Select
            MarkActive(AccountsButton, page = "Accounts")
            MarkActive(TransferButton, page = "Transfer")
            MarkActive(ActivityButton, page = "Activity")
        Catch ex As BankingException
            ShowSignIn()
            Notice(ex.Message, True)
        End Try
    End Sub

    Private Shared Sub MarkActive(button As Button, active As Boolean)
        button.BackColor = If(active, Theme.Accent, Theme.Surface)
        button.ForeColor = If(active, Theme.Background, Theme.Ink)
    End Sub

    Private Async Function RefreshAsync(page As String) As Task
        Await RunAsync(Async Function()
                           snapshot = Await Task.Run(Function() bank.Dashboard())
                           Navigate(page)
                           Notice("Balances and activity updated.")
                       End Function)
    End Function

    Private Sub AccountsButton_Click(sender As Object, e As EventArgs) Handles AccountsButton.Click
        Navigate("Accounts")
    End Sub

    Private Sub TransferButton_Click(sender As Object, e As EventArgs) Handles TransferButton.Click
        Navigate("Transfer")
    End Sub

    Private Sub ActivityButton_Click(sender As Object, e As EventArgs) Handles ActivityButton.Click
        Navigate("Activity")
    End Sub

    Private Sub SignOutButton_Click(sender As Object, e As EventArgs) Handles SignOutButton.Click
        bank.SignOut()
        snapshot = New Dashboard()
        ShowSignIn()
    End Sub

    Private Sub SessionTimer_Tick(sender As Object, e As EventArgs) Handles SessionTimer.Tick
        If busy OrElse bank Is Nothing Then Return
        Try
            Dim user = bank.CurrentUser
        Catch ex As BankingException
            snapshot = New Dashboard()
            ShowSignIn()
            Notice(ex.Message, True)
        End Try
    End Sub

    Private Sub Notice(message As String, Optional failed As Boolean = False)
        If IsDisposed Then Return
        StatusLabel.Text = message
        StatusLabel.ForeColor = If(failed, Theme.Bad, Theme.Good)
    End Sub

    Private Async Function RunAsync(work As Func(Of Task), Optional connection As Boolean = False) As Task
        If busy Then Return
        busy = True
        ContentPanel.Enabled = False
        SidebarPanel.Enabled = False
        UseWaitCursor = True
        Try
            Await work()
        Catch ex As BankingException
            Notice(ex.Message, True)
        Catch ex As OracleException
            Diagnostics.Trace.WriteLine($"Pocket Bank Oracle error: ORA-{ex.Number:D5}")
            If connection Then
                Notice("Your bank is temporarily unavailable. Check that Oracle is running, then try signing in again.", True)
            Else
                Notice(If(ex.Number = 30006 OrElse ex.Number = 60 OrElse ex.Number = 8177, "The accounts are busy. Please retry in a moment.", "The request could not be completed. Please try again. Transfer requests are safe to retry."), True)
            End If
        Catch ex As Exception When TypeOf ex Is IOException OrElse TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is System.Text.Json.JsonException OrElse TypeOf ex Is System.Security.Cryptography.CryptographicException
            Notice("Your local database settings could not be read. Check the local configuration before trying again.", True)
        Catch ex As Exception
            Notice("The action could not be completed. Please try again.", True)
            Diagnostics.Debug.WriteLine(ex.GetType().Name & ": " & ex.Message)
        Finally
            If Not IsDisposed Then
                ContentPanel.Enabled = True
                SidebarPanel.Enabled = True
                UseWaitCursor = False
            End If
            busy = False
        End Try
    End Function
End Class
