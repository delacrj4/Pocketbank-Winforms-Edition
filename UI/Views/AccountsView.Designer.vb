Namespace UI.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class AccountsView
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
            Dim bodyStyle As New Global.System.Windows.Forms.DataGridViewCellStyle()
            Dim headerStyle As New Global.System.Windows.Forms.DataGridViewCellStyle()
            Dim amountStyle As New Global.System.Windows.Forms.DataGridViewCellStyle()
            Me.TitleLabel = New Global.System.Windows.Forms.Label()
            Me.TotalPanel = New Global.System.Windows.Forms.Panel()
            Me.TotalCaptionLabel = New Global.System.Windows.Forms.Label()
            Me.TotalBalanceLabel = New Global.System.Windows.Forms.Label()
            Me.CurrencyLabel = New Global.System.Windows.Forms.Label()
            Me.CheckingPanel = New Global.System.Windows.Forms.Panel()
            Me.CheckingCaptionLabel = New Global.System.Windows.Forms.Label()
            Me.CheckingBalanceLabel = New Global.System.Windows.Forms.Label()
            Me.CheckingAvailableLabel = New Global.System.Windows.Forms.Label()
            Me.CheckingNumberTextBox = New Global.System.Windows.Forms.TextBox()
            Me.SavingsPanel = New Global.System.Windows.Forms.Panel()
            Me.SavingsCaptionLabel = New Global.System.Windows.Forms.Label()
            Me.SavingsBalanceLabel = New Global.System.Windows.Forms.Label()
            Me.SavingsAvailableLabel = New Global.System.Windows.Forms.Label()
            Me.SavingsNumberTextBox = New Global.System.Windows.Forms.TextBox()
            Me.SavingsPromptLabel = New Global.System.Windows.Forms.Label()
            Me.OpenSavingsButton = New Global.System.Windows.Forms.Button()
            Me.TransferButton = New Global.System.Windows.Forms.Button()
            Me.RefreshButton = New Global.System.Windows.Forms.Button()
            Me.RecentLabel = New Global.System.Windows.Forms.Label()
            Me.EmptyLabel = New Global.System.Windows.Forms.Label()
            Me.RecentGrid = New Global.System.Windows.Forms.DataGridView()
            Me.RecentGridDate = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RecentGridDescription = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RecentGridDirection = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RecentGridAmount = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalPanel.SuspendLayout()
            Me.CheckingPanel.SuspendLayout()
            Me.SavingsPanel.SuspendLayout()
            CType(Me.RecentGrid, Global.System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            bodyStyle.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            bodyStyle.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            bodyStyle.SelectionBackColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            bodyStyle.SelectionForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            bodyStyle.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            bodyStyle.Padding = New Global.System.Windows.Forms.Padding(10, 4, 10, 4)
            headerStyle.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            headerStyle.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            headerStyle.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            headerStyle.Padding = New Global.System.Windows.Forms.Padding(10, 4, 10, 4)
            amountStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            ' TitleLabel
            Me.TitleLabel.Location = New Global.System.Drawing.Point(32, 24)
            Me.TitleLabel.Size = New Global.System.Drawing.Size(850, 48)
            Me.TitleLabel.Name = "TitleLabel"
            Me.TitleLabel.TabIndex = 0
            Me.TitleLabel.Text = "Accounts"
            Me.TitleLabel.Font = New Global.System.Drawing.Font("Segoe UI", 27F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TitleLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' TotalPanel
            Me.TotalPanel.Location = New Global.System.Drawing.Point(32, 92)
            Me.TotalPanel.Size = New Global.System.Drawing.Size(850, 140)
            Me.TotalPanel.Name = "TotalPanel"
            Me.TotalPanel.TabIndex = 1
            Me.TotalPanel.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            ' TotalCaptionLabel
            Me.TotalCaptionLabel.Location = New Global.System.Drawing.Point(24, 16)
            Me.TotalCaptionLabel.Size = New Global.System.Drawing.Size(790, 32)
            Me.TotalCaptionLabel.Name = "TotalCaptionLabel"
            Me.TotalCaptionLabel.TabIndex = 2
            Me.TotalCaptionLabel.Text = "TOTAL AVAILABLE BALANCE"
            Me.TotalCaptionLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TotalCaptionLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' TotalBalanceLabel
            Me.TotalBalanceLabel.Location = New Global.System.Drawing.Point(24, 46)
            Me.TotalBalanceLabel.Size = New Global.System.Drawing.Size(790, 64)
            Me.TotalBalanceLabel.Name = "TotalBalanceLabel"
            Me.TotalBalanceLabel.TabIndex = 3
            Me.TotalBalanceLabel.Text = "$0.00"
            Me.TotalBalanceLabel.Font = New Global.System.Drawing.Font("Segoe UI", 34F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TotalBalanceLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' CurrencyLabel
            Me.CurrencyLabel.Location = New Global.System.Drawing.Point(24, 112)
            Me.CurrencyLabel.Size = New Global.System.Drawing.Size(790, 24)
            Me.CurrencyLabel.Name = "CurrencyLabel"
            Me.CurrencyLabel.TabIndex = 4
            Me.CurrencyLabel.Text = "USD"
            Me.CurrencyLabel.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.CurrencyLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' CheckingPanel
            Me.CheckingPanel.Location = New Global.System.Drawing.Point(32, 250)
            Me.CheckingPanel.Size = New Global.System.Drawing.Size(416, 204)
            Me.CheckingPanel.Name = "CheckingPanel"
            Me.CheckingPanel.TabIndex = 5
            Me.CheckingPanel.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            ' CheckingCaptionLabel
            Me.CheckingCaptionLabel.Location = New Global.System.Drawing.Point(24, 16)
            Me.CheckingCaptionLabel.Size = New Global.System.Drawing.Size(360, 30)
            Me.CheckingCaptionLabel.Name = "CheckingCaptionLabel"
            Me.CheckingCaptionLabel.TabIndex = 6
            Me.CheckingCaptionLabel.Text = "Checking"
            Me.CheckingCaptionLabel.Font = New Global.System.Drawing.Font("Segoe UI", 13F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.CheckingCaptionLabel.ForeColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            ' CheckingBalanceLabel
            Me.CheckingBalanceLabel.Location = New Global.System.Drawing.Point(24, 52)
            Me.CheckingBalanceLabel.Size = New Global.System.Drawing.Size(360, 50)
            Me.CheckingBalanceLabel.Name = "CheckingBalanceLabel"
            Me.CheckingBalanceLabel.TabIndex = 7
            Me.CheckingBalanceLabel.Text = "$0.00"
            Me.CheckingBalanceLabel.Font = New Global.System.Drawing.Font("Segoe UI", 26F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.CheckingBalanceLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' CheckingAvailableLabel
            Me.CheckingAvailableLabel.Location = New Global.System.Drawing.Point(24, 106)
            Me.CheckingAvailableLabel.Size = New Global.System.Drawing.Size(360, 24)
            Me.CheckingAvailableLabel.Name = "CheckingAvailableLabel"
            Me.CheckingAvailableLabel.TabIndex = 8
            Me.CheckingAvailableLabel.Text = "Available balance"
            Me.CheckingAvailableLabel.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.CheckingAvailableLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' CheckingNumberTextBox
            Me.CheckingNumberTextBox.Location = New Global.System.Drawing.Point(24, 142)
            Me.CheckingNumberTextBox.Size = New Global.System.Drawing.Size(360, 30)
            Me.CheckingNumberTextBox.Name = "CheckingNumberTextBox"
            Me.CheckingNumberTextBox.TabIndex = 9
            Me.CheckingNumberTextBox.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.CheckingNumberTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.CheckingNumberTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.CheckingNumberTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
            Me.CheckingNumberTextBox.ReadOnly = True
            Me.CheckingNumberTextBox.Text = "Account number"
            Me.CheckingNumberTextBox.AccessibleName = "Checking account number"
            ' SavingsPanel
            Me.SavingsPanel.Location = New Global.System.Drawing.Point(466, 250)
            Me.SavingsPanel.Size = New Global.System.Drawing.Size(416, 204)
            Me.SavingsPanel.Name = "SavingsPanel"
            Me.SavingsPanel.TabIndex = 10
            Me.SavingsPanel.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            ' SavingsCaptionLabel
            Me.SavingsCaptionLabel.Location = New Global.System.Drawing.Point(24, 16)
            Me.SavingsCaptionLabel.Size = New Global.System.Drawing.Size(360, 30)
            Me.SavingsCaptionLabel.Name = "SavingsCaptionLabel"
            Me.SavingsCaptionLabel.TabIndex = 11
            Me.SavingsCaptionLabel.Text = "Savings"
            Me.SavingsCaptionLabel.Font = New Global.System.Drawing.Font("Segoe UI", 13F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.SavingsCaptionLabel.ForeColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            ' SavingsBalanceLabel
            Me.SavingsBalanceLabel.Location = New Global.System.Drawing.Point(24, 52)
            Me.SavingsBalanceLabel.Size = New Global.System.Drawing.Size(360, 50)
            Me.SavingsBalanceLabel.Name = "SavingsBalanceLabel"
            Me.SavingsBalanceLabel.TabIndex = 12
            Me.SavingsBalanceLabel.Text = "$0.00"
            Me.SavingsBalanceLabel.Font = New Global.System.Drawing.Font("Segoe UI", 26F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.SavingsBalanceLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.SavingsBalanceLabel.Visible = False
            ' SavingsAvailableLabel
            Me.SavingsAvailableLabel.Location = New Global.System.Drawing.Point(24, 106)
            Me.SavingsAvailableLabel.Size = New Global.System.Drawing.Size(360, 24)
            Me.SavingsAvailableLabel.Name = "SavingsAvailableLabel"
            Me.SavingsAvailableLabel.TabIndex = 13
            Me.SavingsAvailableLabel.Text = "Available balance"
            Me.SavingsAvailableLabel.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.SavingsAvailableLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            Me.SavingsAvailableLabel.Visible = False
            ' SavingsNumberTextBox
            Me.SavingsNumberTextBox.Location = New Global.System.Drawing.Point(24, 142)
            Me.SavingsNumberTextBox.Size = New Global.System.Drawing.Size(360, 30)
            Me.SavingsNumberTextBox.Name = "SavingsNumberTextBox"
            Me.SavingsNumberTextBox.TabIndex = 14
            Me.SavingsNumberTextBox.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.SavingsNumberTextBox.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.SavingsNumberTextBox.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.SavingsNumberTextBox.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
            Me.SavingsNumberTextBox.ReadOnly = True
            Me.SavingsNumberTextBox.Text = "Account number"
            Me.SavingsNumberTextBox.AccessibleName = "Savings account number"
            Me.SavingsNumberTextBox.Visible = False
            ' SavingsPromptLabel
            Me.SavingsPromptLabel.Location = New Global.System.Drawing.Point(24, 52)
            Me.SavingsPromptLabel.Size = New Global.System.Drawing.Size(360, 44)
            Me.SavingsPromptLabel.Name = "SavingsPromptLabel"
            Me.SavingsPromptLabel.TabIndex = 15
            Me.SavingsPromptLabel.Text = "Open a savings account with a $0 balance."
            Me.SavingsPromptLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.SavingsPromptLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' OpenSavingsButton
            Me.OpenSavingsButton.Location = New Global.System.Drawing.Point(24, 112)
            Me.OpenSavingsButton.Size = New Global.System.Drawing.Size(170, 42)
            Me.OpenSavingsButton.Name = "OpenSavingsButton"
            Me.OpenSavingsButton.TabIndex = 16
            Me.OpenSavingsButton.Text = "Open savings"
            Me.OpenSavingsButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.OpenSavingsButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.OpenSavingsButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.OpenSavingsButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.OpenSavingsButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.OpenSavingsButton.UseVisualStyleBackColor = False
            Me.OpenSavingsButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' TransferButton
            Me.TransferButton.Location = New Global.System.Drawing.Point(32, 474)
            Me.TransferButton.Size = New Global.System.Drawing.Size(170, 42)
            Me.TransferButton.Name = "TransferButton"
            Me.TransferButton.TabIndex = 17
            Me.TransferButton.Text = "Move money"
            Me.TransferButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TransferButton.ForeColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.TransferButton.BackColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.TransferButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.TransferButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
            Me.TransferButton.UseVisualStyleBackColor = False
            Me.TransferButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' RefreshButton
            Me.RefreshButton.Location = New Global.System.Drawing.Point(218, 474)
            Me.RefreshButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.RefreshButton.Name = "RefreshButton"
            Me.RefreshButton.TabIndex = 18
            Me.RefreshButton.Text = "Refresh balances"
            Me.RefreshButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.RefreshButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.RefreshButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.RefreshButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.RefreshButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.RefreshButton.UseVisualStyleBackColor = False
            Me.RefreshButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' RecentLabel
            Me.RecentLabel.Location = New Global.System.Drawing.Point(32, 538)
            Me.RecentLabel.Size = New Global.System.Drawing.Size(850, 34)
            Me.RecentLabel.Name = "RecentLabel"
            Me.RecentLabel.TabIndex = 19
            Me.RecentLabel.Text = "Recent activity"
            Me.RecentLabel.Font = New Global.System.Drawing.Font("Segoe UI", 17F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.RecentLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' EmptyLabel
            Me.EmptyLabel.Location = New Global.System.Drawing.Point(32, 582)
            Me.EmptyLabel.Size = New Global.System.Drawing.Size(850, 36)
            Me.EmptyLabel.Name = "EmptyLabel"
            Me.EmptyLabel.TabIndex = 20
            Me.EmptyLabel.Text = "No transactions yet."
            Me.EmptyLabel.Font = New Global.System.Drawing.Font("Segoe UI", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.EmptyLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            Me.EmptyLabel.Visible = False
            ' RecentGrid
            Me.RecentGrid.Location = New Global.System.Drawing.Point(32, 582)
            Me.RecentGrid.Size = New Global.System.Drawing.Size(850, 210)
            Me.RecentGrid.Name = "RecentGrid"
            Me.RecentGrid.TabIndex = 21
            Me.RecentGrid.BackgroundColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.RecentGrid.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
            Me.RecentGrid.ReadOnly = True
            Me.RecentGrid.AllowUserToAddRows = False
            Me.RecentGrid.AllowUserToDeleteRows = False
            Me.RecentGrid.AllowUserToResizeRows = False
            Me.RecentGrid.RowHeadersVisible = False
            Me.RecentGrid.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.RecentGrid.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.RecentGrid.MultiSelect = False
            Me.RecentGrid.EnableHeadersVisualStyles = False
            Me.RecentGrid.GridColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.RecentGrid.ColumnHeadersHeight = 38
            Me.RecentGrid.RowTemplate.Height = 42
            Me.RecentGrid.AccessibleName = "Transaction history"
            ' RecentGridDate
            Me.RecentGridDate.Name = "RecentGridDate"
            Me.RecentGridDate.HeaderText = "DATE"
            Me.RecentGridDate.FillWeight = 28F
            Me.RecentGridDate.ReadOnly = True
            Me.RecentGridDate.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' RecentGridDescription
            Me.RecentGridDescription.Name = "RecentGridDescription"
            Me.RecentGridDescription.HeaderText = "DESCRIPTION"
            Me.RecentGridDescription.FillWeight = 42F
            Me.RecentGridDescription.ReadOnly = True
            Me.RecentGridDescription.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' RecentGridDirection
            Me.RecentGridDirection.Name = "RecentGridDirection"
            Me.RecentGridDirection.HeaderText = "TYPE"
            Me.RecentGridDirection.FillWeight = 16F
            Me.RecentGridDirection.ReadOnly = True
            Me.RecentGridDirection.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' RecentGridAmount
            Me.RecentGridAmount.Name = "RecentGridAmount"
            Me.RecentGridAmount.HeaderText = "AMOUNT"
            Me.RecentGridAmount.FillWeight = 22F
            Me.RecentGridAmount.ReadOnly = True
            Me.RecentGridAmount.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.RecentGrid.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() {Me.RecentGridDate, Me.RecentGridDescription, Me.RecentGridDirection, Me.RecentGridAmount})
            Me.RecentGrid.DefaultCellStyle = bodyStyle
            Me.RecentGrid.ColumnHeadersDefaultCellStyle = headerStyle
            Me.RecentGridAmount.DefaultCellStyle = amountStyle
            Me.Controls.Add(Me.TitleLabel)
            Me.Controls.Add(Me.TotalPanel)
            Me.TotalPanel.Controls.Add(Me.TotalCaptionLabel)
            Me.TotalPanel.Controls.Add(Me.TotalBalanceLabel)
            Me.TotalPanel.Controls.Add(Me.CurrencyLabel)
            Me.Controls.Add(Me.CheckingPanel)
            Me.CheckingPanel.Controls.Add(Me.CheckingCaptionLabel)
            Me.CheckingPanel.Controls.Add(Me.CheckingBalanceLabel)
            Me.CheckingPanel.Controls.Add(Me.CheckingAvailableLabel)
            Me.CheckingPanel.Controls.Add(Me.CheckingNumberTextBox)
            Me.Controls.Add(Me.SavingsPanel)
            Me.SavingsPanel.Controls.Add(Me.SavingsCaptionLabel)
            Me.SavingsPanel.Controls.Add(Me.SavingsBalanceLabel)
            Me.SavingsPanel.Controls.Add(Me.SavingsAvailableLabel)
            Me.SavingsPanel.Controls.Add(Me.SavingsNumberTextBox)
            Me.SavingsPanel.Controls.Add(Me.SavingsPromptLabel)
            Me.SavingsPanel.Controls.Add(Me.OpenSavingsButton)
            Me.Controls.Add(Me.TransferButton)
            Me.Controls.Add(Me.RefreshButton)
            Me.Controls.Add(Me.RecentLabel)
            Me.Controls.Add(Me.EmptyLabel)
            Me.Controls.Add(Me.RecentGrid)
            Me.AutoScaleDimensions = New Global.System.Drawing.SizeF(7.0F, 15.0F)
            Me.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.Name = "AccountsView"
            Me.Size = New Global.System.Drawing.Size(1024, 760)
            Me.AutoScroll = True
            Me.AutoScrollMinSize = New Global.System.Drawing.Size(900, 740)
            CType(Me.RecentGrid, Global.System.ComponentModel.ISupportInitialize).EndInit()
            Me.SavingsPanel.ResumeLayout(False)
            Me.SavingsPanel.PerformLayout()
            Me.CheckingPanel.ResumeLayout(False)
            Me.CheckingPanel.PerformLayout()
            Me.TotalPanel.ResumeLayout(False)
            Me.TotalPanel.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents TitleLabel As Global.System.Windows.Forms.Label
        Friend WithEvents TotalPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents TotalCaptionLabel As Global.System.Windows.Forms.Label
        Friend WithEvents TotalBalanceLabel As Global.System.Windows.Forms.Label
        Friend WithEvents CurrencyLabel As Global.System.Windows.Forms.Label
        Friend WithEvents CheckingPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents CheckingCaptionLabel As Global.System.Windows.Forms.Label
        Friend WithEvents CheckingBalanceLabel As Global.System.Windows.Forms.Label
        Friend WithEvents CheckingAvailableLabel As Global.System.Windows.Forms.Label
        Friend WithEvents CheckingNumberTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents SavingsPanel As Global.System.Windows.Forms.Panel
        Friend WithEvents SavingsCaptionLabel As Global.System.Windows.Forms.Label
        Friend WithEvents SavingsBalanceLabel As Global.System.Windows.Forms.Label
        Friend WithEvents SavingsAvailableLabel As Global.System.Windows.Forms.Label
        Friend WithEvents SavingsNumberTextBox As Global.System.Windows.Forms.TextBox
        Friend WithEvents SavingsPromptLabel As Global.System.Windows.Forms.Label
        Friend WithEvents OpenSavingsButton As Global.System.Windows.Forms.Button
        Friend WithEvents TransferButton As Global.System.Windows.Forms.Button
        Friend WithEvents RefreshButton As Global.System.Windows.Forms.Button
        Friend WithEvents RecentLabel As Global.System.Windows.Forms.Label
        Friend WithEvents EmptyLabel As Global.System.Windows.Forms.Label
        Friend WithEvents RecentGrid As Global.System.Windows.Forms.DataGridView
        Friend WithEvents RecentGridDate As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecentGridDescription As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecentGridDirection As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RecentGridAmount As Global.System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
