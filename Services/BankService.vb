Imports System.Text.RegularExpressions
Imports Pocketbank_vWF.Domain
Imports Pocketbank_vWF.Infrastructure

Namespace Services
    Public Class BankService
        Private ReadOnly repository As BankRepository
        Private signedIn As BankUser
        Private expires As DateTime

        Public Sub New(repo As BankRepository)
            repository = repo
        End Sub

        Public ReadOnly Property CurrentUser As BankUser
            Get
                If signedIn Is Nothing OrElse DateTime.UtcNow >= expires Then
                    signedIn = Nothing
                    Throw New BankingException("Your session has ended. Please sign in again.")
                End If
                Return signedIn
            End Get
        End Property

        Private Shared Function Email(value As String) As String
            value = value.Trim().ToLowerInvariant()
            If value.Length > 254 OrElse Not Regex.IsMatch(value, "^[^\s@]+@[^\s@]+\.[^\s@]+$") Then Throw New BankingException("Enter a valid email address.")
            Return value
        End Function

        Private Shared Sub ValidatePassword(value As String)
            If value.Length < 6 OrElse value.Length > 128 Then Throw New BankingException("Use a password between 6 and 128 characters.")
        End Sub

        Public Function SignIn(address As String, password As String) As BankUser
            ValidatePassword(password)
            signedIn = repository.SignIn(Email(address), password)
            expires = DateTime.UtcNow.AddHours(8)
            Return signedIn
        End Function

        Public Function Register(name As String, address As String, password As String) As BankUser
            name = name.Trim()
            If name.Length = 0 OrElse name.Length > 80 Then Throw New BankingException("Enter a display name between 1 and 80 characters.")
            ValidatePassword(password)
            Dim normalized = Email(address)
            signedIn = repository.Register(name, normalized, Passwords.Hash(password))
            expires = DateTime.UtcNow.AddHours(8)
            Return signedIn
        End Function

        Public Sub SignOut()
            signedIn = Nothing
        End Sub

        Public Function Dashboard() As Dashboard
            Return repository.LoadDashboard(CurrentUser.Id)
        End Function

        Public Sub OpenSavings()
            repository.OpenSavings(CurrentUser.Id)
        End Sub

        Public Function Review(draft As TransferDraft) As TransferDraft
            Return repository.Review(CurrentUser.Id, draft)
        End Function

        Public Function Transfer(draft As TransferDraft) As String
            Return repository.Transfer(CurrentUser.Id, draft)
        End Function
    End Class
End Namespace
