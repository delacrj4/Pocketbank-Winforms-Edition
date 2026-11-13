Namespace UI.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class RegistrationView
        Inherits Global.System.Windows.Forms.UserControl

        Private components As Global.System.ComponentModel.IContainer

        <Global.System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then components.Dispose()
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <Global.System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New Global.System.ComponentModel.Container()
            Me.CenterLayout = New Global.System.Windows.Forms.TableLayoutPanel()
            Me.HeaderPanel = New Global.System.Windows.Forms.Panel()
            Me.TitleLabel = New Global.System.Windows.Forms.Label()
            Me.PageLabel = New Global.System.Windows.Forms.Label()
            Me.CredentialsPanel = New Global.System.Windows.Forms.Panel()
            Me.NameLabel = New Global.System.Windows.Forms.Label()
            Me.NameTextBox = New Global.System.Windows.Forms.TextBox()
            Me.EmailLabel = New Global.System.Windows.Forms.Label()
            Me.EmailTextBox = New Global.System.Windows.Forms.TextBox()
            Me.PasswordLabel = New Global.System.Windows.Forms.Label()
            Me.PasswordTextBox = New Global.System.Windows.Forms.TextBox()
            Me.PasswordHintLabel = New Global.System.Windows.Forms.Label()
            Me.ShowPasswordCheckBox = New Global.System.Windows.Forms.CheckBox()
            Me.SubmitButton = New Global.System.Windows.Forms.Button()
            Me.SwitchButton = New Global.System.Windows.Forms.Button()
            Me.CenterLayout.SuspendLayout()
            Me.HeaderPanel.SuspendLayout()
            Me.CredentialsPanel.SuspendLayout()
            Me.SuspendLayout()
            ' CenterLayout
            Me.CenterLayout.Location = New Global.System.Drawing.Point(0, 0)
            Me.CenterLayout.Size = New Global.System.Drawing.Size(200, 32)
            Me.CenterLayout.Name = "CenterLayout"
            Me.CenterLayout.TabIndex = 0
            Me.CenterLayout.Dock = Global.System.Windows.Forms.DockStyle.Fill
            Me.CenterLayout.ColumnCount = 3
            Me.CenterLayout.RowCount = 4
            Me.CenterLayout.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            ' HeaderPanel
            Me.HeaderPanel.Location = New Global.System.Drawing.Point(0, 0)
            Me.HeaderPanel.Size = New Global.System.Drawing.Size(480, 100)
            Me.HeaderPanel.Name = "HeaderPanel"
            Me.HeaderPanel.TabIndex = 1
            Me.HeaderPanel.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.HeaderPanel.Margin = New Global.System.Windows.Forms.Padding(0)
            ' TitleLabel
            Me.TitleLabel.Location = New Global.System.Drawing.Point(0, 0)
            Me.TitleLabel.Size = New Global.System.Drawing.Size(480, 52)
            Me.TitleLabel.Name = "TitleLabel"
            Me.TitleLabel.TabIndex = 2
            Me.TitleLabel.Text = "Pocket Bank"
            Me.TitleLabel.Font = New Global.System.Drawing.Font("Segoe UI", 28F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TitleLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' PageLabel
            Me.PageLabel.Location = New Global.System.Drawing.Point(0, 60)
            Me.PageLabel.Size = New Global.System.Drawing.Size(440, 28)
            Me.PageLabel.Name = "PageLabel"
            Me.PageLabel.TabIndex = 3
            Me.PageLabel.Text = "Create account"
            Me.PageLabel.Font = New Global.System.Drawing.Font("Segoe UI", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.PageLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' CredentialsPanel
            Me.CredentialsPanel.Location = New Global.System.Drawing.Point(0, 0)
            Me.CredentialsPanel.Size = New Global.System.Drawing.Size(480, 480)
            Me.CredentialsPanel.Name = "CredentialsPanel"
            Me.CredentialsPanel.TabIndex = 4
            Me.CredentialsPanel.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.CredentialsPanel.Margin = New Global.System.Windows.Forms.Padding(0)
            ' NameLabel
            Me.NameLabel.Location = New Global.System.Drawing.Point(24, 24)
            Me.NameLabel.Size = New Global.System.Drawing.Size(400, 32)
            Me.NameLabel.Name = "NameLabel"
            Me.NameLabel.TabIndex = 5
            Me.NameLabel.Text = "Display name"
            Me.NameLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.NameLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' NameTextBox
            Me.NameTextBox.Location = New Global.System.Drawing.Point(24, 54)
            Me.NameTextBox.Size = New Global.System.Drawing.Size(400, 30)
            Me.NameTextBox.Name = "NameTextBox"
            Me.NameTextBox.TabIndex = 6
            Me.NameTextBox.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.NameTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.NameTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.NameTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
            Me.NameTextBox.MaxLength = 80
            Me.NameTextBox.AccessibleName = "Display name"
            ' EmailLabel
            Me.EmailLabel.Location = New Global.System.Drawing.Point(24, 106)
            Me.EmailLabel.Size = New Global.System.Drawing.Size(400, 32)
            Me.EmailLabel.Name = "EmailLabel"
            Me.EmailLabel.TabIndex = 7
            Me.EmailLabel.Text = "Email address"
            Me.EmailLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.EmailLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' EmailTextBox
            Me.EmailTextBox.Location = New Global.System.Drawing.Point(24, 136)
            Me.EmailTextBox.Size = New Global.System.Drawing.Size(400, 30)
            Me.EmailTextBox.Name = "EmailTextBox"
            Me.EmailTextBox.TabIndex = 8
            Me.EmailTextBox.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.EmailTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.EmailTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.EmailTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
            Me.EmailTextBox.MaxLength = 254
            Me.EmailTextBox.AccessibleName = "Email address"
            ' PasswordLabel
            Me.PasswordLabel.Location = New Global.System.Drawing.Point(24, 188)
            Me.PasswordLabel.Size = New Global.System.Drawing.Size(400, 32)
            Me.PasswordLabel.Name = "PasswordLabel"
            Me.PasswordLabel.TabIndex = 9
            Me.PasswordLabel.Text = "Password"
            Me.PasswordLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.PasswordLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' PasswordTextBox
            Me.PasswordTextBox.Location = New Global.System.Drawing.Point(24, 218)
            Me.PasswordTextBox.Size = New Global.System.Drawing.Size(400, 30)
            Me.PasswordTextBox.Name = "PasswordTextBox"
            Me.PasswordTextBox.TabIndex = 10
            Me.PasswordTextBox.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.PasswordTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.PasswordTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.PasswordTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
            Me.PasswordTextBox.MaxLength = 128
            Me.PasswordTextBox.UseSystemPasswordChar = True
            Me.PasswordTextBox.AccessibleName = "Password"
            ' PasswordHintLabel
            Me.PasswordHintLabel.Location = New Global.System.Drawing.Point(24, 262)
            Me.PasswordHintLabel.Size = New Global.System.Drawing.Size(400, 24)
            Me.PasswordHintLabel.Name = "PasswordHintLabel"
            Me.PasswordHintLabel.TabIndex = 11
            Me.PasswordHintLabel.Text = "6–128 characters"
            Me.PasswordHintLabel.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.PasswordHintLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' ShowPasswordCheckBox
            Me.ShowPasswordCheckBox.Location = New Global.System.Drawing.Point(24, 290)
            Me.ShowPasswordCheckBox.Size = New Global.System.Drawing.Size(260, 28)
            Me.ShowPasswordCheckBox.Name = "ShowPasswordCheckBox"
            Me.ShowPasswordCheckBox.TabIndex = 12
            Me.ShowPasswordCheckBox.Text = "Show password"
            Me.ShowPasswordCheckBox.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            Me.ShowPasswordCheckBox.AutoSize = True
            ' SubmitButton
            Me.SubmitButton.Location = New Global.System.Drawing.Point(24, 338)
            Me.SubmitButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.SubmitButton.Name = "SubmitButton"
            Me.SubmitButton.TabIndex = 13
            Me.SubmitButton.Text = "Create account"
            Me.SubmitButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.SubmitButton.ForeColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.SubmitButton.BackColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.SubmitButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.SubmitButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.SubmitButton.UseVisualStyleBackColor = False
            Me.SubmitButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' SwitchButton
            Me.SwitchButton.Location = New Global.System.Drawing.Point(24, 394)
            Me.SwitchButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.SwitchButton.Name = "SwitchButton"
            Me.SwitchButton.TabIndex = 14
            Me.SwitchButton.Text = "Back to sign in"
            Me.SwitchButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.SwitchButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.SwitchButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.SwitchButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.SwitchButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.SwitchButton.UseVisualStyleBackColor = False
            Me.SwitchButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            Me.CenterLayout.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 50.0F))
            Me.CenterLayout.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 480.0F))
            Me.CenterLayout.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Percent, 50.0F))
            Me.CenterLayout.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 48.0F))
            Me.CenterLayout.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 100.0F))
            Me.CenterLayout.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Absolute, 490.0F))
            Me.CenterLayout.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 100.0F))
            Me.CenterLayout.Controls.Add(Me.HeaderPanel, 1, 1)
            Me.CenterLayout.Controls.Add(Me.CredentialsPanel, 1, 2)
            Me.Controls.Add(Me.CenterLayout)
            Me.HeaderPanel.Controls.Add(Me.TitleLabel)
            Me.HeaderPanel.Controls.Add(Me.PageLabel)
            Me.CredentialsPanel.Controls.Add(Me.NameLabel)
            Me.CredentialsPanel.Controls.Add(Me.NameTextBox)
            Me.CredentialsPanel.Controls.Add(Me.EmailLabel)
            Me.CredentialsPanel.Controls.Add(Me.EmailTextBox)
            Me.CredentialsPanel.Controls.Add(Me.PasswordLabel)
            Me.CredentialsPanel.Controls.Add(Me.PasswordTextBox)
            Me.CredentialsPanel.Controls.Add(Me.PasswordHintLabel)
            Me.CredentialsPanel.Controls.Add(Me.ShowPasswordCheckBox)
            Me.CredentialsPanel.Controls.Add(Me.SubmitButton)
            Me.CredentialsPanel.Controls.Add(Me.SwitchButton)
            Me.AutoScaleDimensions = New Global.System.Drawing.SizeF(7.0F, 15.0F)
            Me.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.Name = "RegistrationView"
            Me.Size = New Global.System.Drawing.Size(1024, 760)
            Me.AutoScroll = True
            Me.CredentialsPanel.ResumeLayout(False)
            Me.CredentialsPanel.PerformLayout()
            Me.HeaderPanel.ResumeLayout(False)
            Me.HeaderPanel.PerformLayout()
            Me.CenterLayout.ResumeLayout(False)
            Me.CenterLayout.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents CenterLayout As Global.System.Windows.Forms.TableLayoutPanel
        Friend WithEvents HeaderPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents TitleLabel As Global.System.Windows.Forms.Label
        Friend WithEvents PageLabel As Global.System.Windows.Forms.Label
        Friend WithEvents CredentialsPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents NameLabel As Global.System.Windows.Forms.Label
        Friend WithEvents NameTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents EmailLabel As Global.System.Windows.Forms.Label
        Friend WithEvents EmailTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents PasswordLabel As Global.System.Windows.Forms.Label
        Friend WithEvents PasswordTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents PasswordHintLabel As Global.System.Windows.Forms.Label
        Friend WithEvents ShowPasswordCheckBox As Global.System.Windows.Forms.CheckBox
        Friend WithEvents SubmitButton As Global.System.Windows.Forms.Button
        Friend WithEvents SwitchButton As Global.System.Windows.Forms.Button
    End Class
End Namespace
