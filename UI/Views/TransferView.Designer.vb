Namespace UI.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class TransferView
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
            Me.TitleLabel = New Global.System.Windows.Forms.Label()
            Me.EntryPanel = New Global.System.Windows.Forms.Panel()
            Me.SourceLabel = New Global.System.Windows.Forms.Label()
            Me.SourceComboBox = New Global.System.Windows.Forms.ComboBox()
            Me.AvailableLabel = New Global.System.Windows.Forms.Label()
            Me.DestinationLabel = New Global.System.Windows.Forms.Label()
            Me.DestinationTextBox = New Global.System.Windows.Forms.TextBox()
            Me.UseCheckingButton = New Global.System.Windows.Forms.Button()
            Me.UseSavingsButton = New Global.System.Windows.Forms.Button()
            Me.RecipientHintLabel = New Global.System.Windows.Forms.Label()
            Me.AmountLabel = New Global.System.Windows.Forms.Label()
            Me.AmountTextBox = New Global.System.Windows.Forms.TextBox()
            Me.ReviewButton = New Global.System.Windows.Forms.Button()
            Me.ReviewPanel = New Global.System.Windows.Forms.Panel()
            Me.ReviewTitleLabel = New Global.System.Windows.Forms.Label()
            Me.ReviewAmountLabel = New Global.System.Windows.Forms.Label()
            Me.RecipientLabel = New Global.System.Windows.Forms.Label()
            Me.ReviewDestinationLabel = New Global.System.Windows.Forms.Label()
            Me.ReviewSourceLabel = New Global.System.Windows.Forms.Label()
            Me.FeeLabel = New Global.System.Windows.Forms.Label()
            Me.ConfirmButton = New Global.System.Windows.Forms.Button()
            Me.EditButton = New Global.System.Windows.Forms.Button()
            Me.EntryPanel.SuspendLayout()
            Me.ReviewPanel.SuspendLayout()
            Me.SuspendLayout()
            ' TitleLabel
            Me.TitleLabel.Location = New Global.System.Drawing.Point(32, 24)
            Me.TitleLabel.Size = New Global.System.Drawing.Size(850, 48)
            Me.TitleLabel.Name = "TitleLabel"
            Me.TitleLabel.TabIndex = 0
            Me.TitleLabel.Text = "Transfer"
            Me.TitleLabel.Font = New Global.System.Drawing.Font("Segoe UI", 27F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TitleLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' EntryPanel
            Me.EntryPanel.Location = New Global.System.Drawing.Point(32, 92)
            Me.EntryPanel.Size = New Global.System.Drawing.Size(620, 438)
            Me.EntryPanel.Name = "EntryPanel"
            Me.EntryPanel.TabIndex = 1
            Me.EntryPanel.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            ' SourceLabel
            Me.SourceLabel.Location = New Global.System.Drawing.Point(24, 18)
            Me.SourceLabel.Size = New Global.System.Drawing.Size(550, 28)
            Me.SourceLabel.Name = "SourceLabel"
            Me.SourceLabel.TabIndex = 2
            Me.SourceLabel.Text = "From account"
            Me.SourceLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.SourceLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' SourceComboBox
            Me.SourceComboBox.Location = New Global.System.Drawing.Point(24, 50)
            Me.SourceComboBox.Size = New Global.System.Drawing.Size(550, 32)
            Me.SourceComboBox.Name = "SourceComboBox"
            Me.SourceComboBox.TabIndex = 3
            Me.SourceComboBox.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SourceComboBox.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.SourceComboBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.SourceComboBox.Font = New Global.System.Drawing.Font("Segoe UI", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.SourceComboBox.AccessibleName = "From account"
            ' AvailableLabel
            Me.AvailableLabel.Location = New Global.System.Drawing.Point(24, 88)
            Me.AvailableLabel.Size = New Global.System.Drawing.Size(550, 28)
            Me.AvailableLabel.Name = "AvailableLabel"
            Me.AvailableLabel.TabIndex = 4
            Me.AvailableLabel.Text = "Available balance"
            Me.AvailableLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.AvailableLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' DestinationLabel
            Me.DestinationLabel.Location = New Global.System.Drawing.Point(24, 128)
            Me.DestinationLabel.Size = New Global.System.Drawing.Size(550, 28)
            Me.DestinationLabel.Name = "DestinationLabel"
            Me.DestinationLabel.TabIndex = 5
            Me.DestinationLabel.Text = "Recipient account number"
            Me.DestinationLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.DestinationLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' DestinationTextBox
            Me.DestinationTextBox.Location = New Global.System.Drawing.Point(24, 160)
            Me.DestinationTextBox.Size = New Global.System.Drawing.Size(550, 30)
            Me.DestinationTextBox.Name = "DestinationTextBox"
            Me.DestinationTextBox.TabIndex = 6
            Me.DestinationTextBox.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.DestinationTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.DestinationTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.DestinationTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
            Me.DestinationTextBox.MaxLength = 16
            Me.DestinationTextBox.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Upper
            Me.DestinationTextBox.AccessibleName = "Recipient account number"
            ' UseCheckingButton
            Me.UseCheckingButton.Location = New Global.System.Drawing.Point(24, 202)
            Me.UseCheckingButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.UseCheckingButton.Name = "UseCheckingButton"
            Me.UseCheckingButton.TabIndex = 7
            Me.UseCheckingButton.Text = "Use my checking"
            Me.UseCheckingButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.UseCheckingButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.UseCheckingButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.UseCheckingButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.UseCheckingButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.UseCheckingButton.UseVisualStyleBackColor = False
            Me.UseCheckingButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' UseSavingsButton
            Me.UseSavingsButton.Location = New Global.System.Drawing.Point(220, 202)
            Me.UseSavingsButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.UseSavingsButton.Name = "UseSavingsButton"
            Me.UseSavingsButton.TabIndex = 8
            Me.UseSavingsButton.Text = "Use my savings"
            Me.UseSavingsButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.UseSavingsButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.UseSavingsButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.UseSavingsButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.UseSavingsButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.UseSavingsButton.UseVisualStyleBackColor = False
            Me.UseSavingsButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' RecipientHintLabel
            Me.RecipientHintLabel.Location = New Global.System.Drawing.Point(24, 256)
            Me.RecipientHintLabel.Size = New Global.System.Drawing.Size(550, 28)
            Me.RecipientHintLabel.Name = "RecipientHintLabel"
            Me.RecipientHintLabel.TabIndex = 9
            Me.RecipientHintLabel.Text = "Other members receive payments in their checking account."
            Me.RecipientHintLabel.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.RecipientHintLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' AmountLabel
            Me.AmountLabel.Location = New Global.System.Drawing.Point(24, 294)
            Me.AmountLabel.Size = New Global.System.Drawing.Size(550, 28)
            Me.AmountLabel.Name = "AmountLabel"
            Me.AmountLabel.TabIndex = 10
            Me.AmountLabel.Text = "Amount (USD)"
            Me.AmountLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.AmountLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' AmountTextBox
            Me.AmountTextBox.Location = New Global.System.Drawing.Point(24, 326)
            Me.AmountTextBox.Size = New Global.System.Drawing.Size(230, 30)
            Me.AmountTextBox.Name = "AmountTextBox"
            Me.AmountTextBox.TabIndex = 11
            Me.AmountTextBox.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.AmountTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.AmountTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.AmountTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
            Me.AmountTextBox.MaxLength = 20
            Me.AmountTextBox.PlaceholderText = "0.00"
            Me.AmountTextBox.AccessibleName = "Amount in USD"
            ' ReviewButton
            Me.ReviewButton.Location = New Global.System.Drawing.Point(24, 378)
            Me.ReviewButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.ReviewButton.Name = "ReviewButton"
            Me.ReviewButton.TabIndex = 12
            Me.ReviewButton.Text = "Review transfer"
            Me.ReviewButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.ReviewButton.ForeColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.ReviewButton.BackColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.ReviewButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.ReviewButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.ReviewButton.UseVisualStyleBackColor = False
            Me.ReviewButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' ReviewPanel
            Me.ReviewPanel.Location = New Global.System.Drawing.Point(32, 548)
            Me.ReviewPanel.Size = New Global.System.Drawing.Size(620, 330)
            Me.ReviewPanel.Name = "ReviewPanel"
            Me.ReviewPanel.TabIndex = 13
            Me.ReviewPanel.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            ' ReviewTitleLabel
            Me.ReviewTitleLabel.Location = New Global.System.Drawing.Point(24, 16)
            Me.ReviewTitleLabel.Size = New Global.System.Drawing.Size(550, 32)
            Me.ReviewTitleLabel.Name = "ReviewTitleLabel"
            Me.ReviewTitleLabel.TabIndex = 14
            Me.ReviewTitleLabel.Text = "Review transfer"
            Me.ReviewTitleLabel.Font = New Global.System.Drawing.Font("Segoe UI", 16F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.ReviewTitleLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' ReviewAmountLabel
            Me.ReviewAmountLabel.Location = New Global.System.Drawing.Point(24, 58)
            Me.ReviewAmountLabel.Size = New Global.System.Drawing.Size(550, 54)
            Me.ReviewAmountLabel.Name = "ReviewAmountLabel"
            Me.ReviewAmountLabel.TabIndex = 15
            Me.ReviewAmountLabel.Text = "$0.00"
            Me.ReviewAmountLabel.Font = New Global.System.Drawing.Font("Segoe UI", 28F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.ReviewAmountLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' RecipientLabel
            Me.RecipientLabel.Location = New Global.System.Drawing.Point(24, 120)
            Me.RecipientLabel.Size = New Global.System.Drawing.Size(550, 32)
            Me.RecipientLabel.Name = "RecipientLabel"
            Me.RecipientLabel.TabIndex = 16
            Me.RecipientLabel.Text = "Recipient"
            Me.RecipientLabel.Font = New Global.System.Drawing.Font("Segoe UI", 13F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.RecipientLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' ReviewDestinationLabel
            Me.ReviewDestinationLabel.Location = New Global.System.Drawing.Point(24, 158)
            Me.ReviewDestinationLabel.Size = New Global.System.Drawing.Size(550, 28)
            Me.ReviewDestinationLabel.Name = "ReviewDestinationLabel"
            Me.ReviewDestinationLabel.TabIndex = 17
            Me.ReviewDestinationLabel.Text = "Recipient account number"
            Me.ReviewDestinationLabel.Font = New Global.System.Drawing.Font("Segoe UI", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.ReviewDestinationLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' ReviewSourceLabel
            Me.ReviewSourceLabel.Location = New Global.System.Drawing.Point(24, 192)
            Me.ReviewSourceLabel.Size = New Global.System.Drawing.Size(550, 30)
            Me.ReviewSourceLabel.Name = "ReviewSourceLabel"
            Me.ReviewSourceLabel.TabIndex = 18
            Me.ReviewSourceLabel.Text = "Source account"
            Me.ReviewSourceLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.ReviewSourceLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' FeeLabel
            Me.FeeLabel.Location = New Global.System.Drawing.Point(24, 228)
            Me.FeeLabel.Size = New Global.System.Drawing.Size(550, 26)
            Me.FeeLabel.Name = "FeeLabel"
            Me.FeeLabel.TabIndex = 19
            Me.FeeLabel.Text = "Transfer fee: $0.00"
            Me.FeeLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.FeeLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' ConfirmButton
            Me.ConfirmButton.Location = New Global.System.Drawing.Point(24, 270)
            Me.ConfirmButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.ConfirmButton.Name = "ConfirmButton"
            Me.ConfirmButton.TabIndex = 20
            Me.ConfirmButton.Text = "Confirm & send"
            Me.ConfirmButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.ConfirmButton.ForeColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.ConfirmButton.BackColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.ConfirmButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.ConfirmButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.ConfirmButton.UseVisualStyleBackColor = False
            Me.ConfirmButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' EditButton
            Me.EditButton.Location = New Global.System.Drawing.Point(220, 270)
            Me.EditButton.Size = New Global.System.Drawing.Size(160, 42)
            Me.EditButton.Name = "EditButton"
            Me.EditButton.TabIndex = 21
            Me.EditButton.Text = "Edit details"
            Me.EditButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.EditButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.EditButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.EditButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.EditButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.EditButton.UseVisualStyleBackColor = False
            Me.EditButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            Me.Controls.Add(Me.TitleLabel)
            Me.Controls.Add(Me.EntryPanel)
            Me.EntryPanel.Controls.Add(Me.SourceLabel)
            Me.EntryPanel.Controls.Add(Me.SourceComboBox)
            Me.EntryPanel.Controls.Add(Me.AvailableLabel)
            Me.EntryPanel.Controls.Add(Me.DestinationLabel)
            Me.EntryPanel.Controls.Add(Me.DestinationTextBox)
            Me.EntryPanel.Controls.Add(Me.UseCheckingButton)
            Me.EntryPanel.Controls.Add(Me.UseSavingsButton)
            Me.EntryPanel.Controls.Add(Me.RecipientHintLabel)
            Me.EntryPanel.Controls.Add(Me.AmountLabel)
            Me.EntryPanel.Controls.Add(Me.AmountTextBox)
            Me.EntryPanel.Controls.Add(Me.ReviewButton)
            Me.Controls.Add(Me.ReviewPanel)
            Me.ReviewPanel.Controls.Add(Me.ReviewTitleLabel)
            Me.ReviewPanel.Controls.Add(Me.ReviewAmountLabel)
            Me.ReviewPanel.Controls.Add(Me.RecipientLabel)
            Me.ReviewPanel.Controls.Add(Me.ReviewDestinationLabel)
            Me.ReviewPanel.Controls.Add(Me.ReviewSourceLabel)
            Me.ReviewPanel.Controls.Add(Me.FeeLabel)
            Me.ReviewPanel.Controls.Add(Me.ConfirmButton)
            Me.ReviewPanel.Controls.Add(Me.EditButton)
            Me.AutoScaleDimensions = New Global.System.Drawing.SizeF(7.0F, 15.0F)
            Me.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.Name = "TransferView"
            Me.Size = New Global.System.Drawing.Size(1024, 760)
            Me.AutoScroll = True
            Me.AutoScrollMinSize = New Global.System.Drawing.Size(900, 740)
            Me.ReviewPanel.ResumeLayout(False)
            Me.ReviewPanel.PerformLayout()
            Me.EntryPanel.ResumeLayout(False)
            Me.EntryPanel.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents TitleLabel As Global.System.Windows.Forms.Label
        Friend WithEvents EntryPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents SourceLabel As Global.System.Windows.Forms.Label
        Friend WithEvents SourceComboBox As Global.System.Windows.Forms.ComboBox
        Friend WithEvents AvailableLabel As Global.System.Windows.Forms.Label
        Friend WithEvents DestinationLabel As Global.System.Windows.Forms.Label
        Friend WithEvents DestinationTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents UseCheckingButton As Global.System.Windows.Forms.Button
        Friend WithEvents UseSavingsButton As Global.System.Windows.Forms.Button
        Friend WithEvents RecipientHintLabel As Global.System.Windows.Forms.Label
        Friend WithEvents AmountLabel As Global.System.Windows.Forms.Label
        Friend WithEvents AmountTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents ReviewButton As Global.System.Windows.Forms.Button
        Friend WithEvents ReviewPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents ReviewTitleLabel As Global.System.Windows.Forms.Label
        Friend WithEvents ReviewAmountLabel As Global.System.Windows.Forms.Label
        Friend WithEvents RecipientLabel As Global.System.Windows.Forms.Label
        Friend WithEvents ReviewDestinationLabel As Global.System.Windows.Forms.Label
        Friend WithEvents ReviewSourceLabel As Global.System.Windows.Forms.Label
        Friend WithEvents FeeLabel As Global.System.Windows.Forms.Label
        Friend WithEvents ConfirmButton As Global.System.Windows.Forms.Button
        Friend WithEvents EditButton As Global.System.Windows.Forms.Button
    End Class
End Namespace
