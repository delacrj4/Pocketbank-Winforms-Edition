Namespace UI.Views
    Public Class RegistrationView
        Public Event RegistrationRequested(displayName As String, email As String, password As String)
        Public Event SignInRequested()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
            RaiseEvent RegistrationRequested(NameTextBox.Text, EmailTextBox.Text, PasswordTextBox.Text)
        End Sub

        Private Sub SwitchButton_Click(sender As Object, e As EventArgs) Handles SwitchButton.Click
            RaiseEvent SignInRequested()
        End Sub

        Private Sub ShowPasswordCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox.CheckedChanged
            PasswordTextBox.UseSystemPasswordChar = Not ShowPasswordCheckBox.Checked
        End Sub

        Public Sub ClearPassword()
            PasswordTextBox.Clear()
        End Sub
    End Class
End Namespace
