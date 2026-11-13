Namespace UI.Views
    Public Class SignInView
        Public Event SignInRequested(email As String, password As String)
        Public Event CreateAccountRequested()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
            RaiseEvent SignInRequested(EmailTextBox.Text, PasswordTextBox.Text)
        End Sub

        Private Sub SwitchButton_Click(sender As Object, e As EventArgs) Handles SwitchButton.Click
            RaiseEvent CreateAccountRequested()
        End Sub

        Private Sub ShowPasswordCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox.CheckedChanged
            PasswordTextBox.UseSystemPasswordChar = Not ShowPasswordCheckBox.Checked
        End Sub

        Public Sub ClearPassword()
            PasswordTextBox.Clear()
        End Sub
    End Class
End Namespace
