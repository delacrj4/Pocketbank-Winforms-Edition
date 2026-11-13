Namespace UI.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class ActivityView
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
            Me.FilterLabel = New Global.System.Windows.Forms.Label()
            Me.AccountFilter = New Global.System.Windows.Forms.ComboBox()
            Me.RefreshButton = New Global.System.Windows.Forms.Button()
            Me.ActivityGrid = New Global.System.Windows.Forms.DataGridView()
            Me.ActivityGridDate = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ActivityGridDescription = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ActivityGridDirection = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ActivityGridAmount = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EmptyLabel = New Global.System.Windows.Forms.Label()
            Me.DetailsHintLabel = New Global.System.Windows.Forms.Label()
            Me.DetailsLabel = New Global.System.Windows.Forms.Label()
            CType(Me.ActivityGrid, Global.System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.TitleLabel.Text = "Activity"
            Me.TitleLabel.Font = New Global.System.Drawing.Font("Segoe UI", 27F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.TitleLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            ' FilterLabel
            Me.FilterLabel.Location = New Global.System.Drawing.Point(32, 96)
            Me.FilterLabel.Size = New Global.System.Drawing.Size(300, 28)
            Me.FilterLabel.Name = "FilterLabel"
            Me.FilterLabel.TabIndex = 1
            Me.FilterLabel.Text = "Account"
            Me.FilterLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.FilterLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' AccountFilter
            Me.AccountFilter.Location = New Global.System.Drawing.Point(32, 128)
            Me.AccountFilter.Size = New Global.System.Drawing.Size(340, 32)
            Me.AccountFilter.Name = "AccountFilter"
            Me.AccountFilter.TabIndex = 2
            Me.AccountFilter.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.AccountFilter.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
            Me.AccountFilter.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.AccountFilter.Font = New Global.System.Drawing.Font("Segoe UI", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.AccountFilter.AccessibleName = "Filter activity by account"
            ' RefreshButton
            Me.RefreshButton.Location = New Global.System.Drawing.Point(390, 123)
            Me.RefreshButton.Size = New Global.System.Drawing.Size(180, 42)
            Me.RefreshButton.Name = "RefreshButton"
            Me.RefreshButton.TabIndex = 3
            Me.RefreshButton.Text = "Refresh balances"
            Me.RefreshButton.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point)
            Me.RefreshButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.RefreshButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.RefreshButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
            Me.RefreshButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.RefreshButton.UseVisualStyleBackColor = False
            Me.RefreshButton.Cursor = Global.System.Windows.Forms.Cursors.Hand
            ' ActivityGrid
            Me.ActivityGrid.Location = New Global.System.Drawing.Point(32, 190)
            Me.ActivityGrid.Size = New Global.System.Drawing.Size(850, 360)
            Me.ActivityGrid.Name = "ActivityGrid"
            Me.ActivityGrid.TabIndex = 4
            Me.ActivityGrid.BackgroundColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
            Me.ActivityGrid.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
            Me.ActivityGrid.ReadOnly = True
            Me.ActivityGrid.AllowUserToAddRows = False
            Me.ActivityGrid.AllowUserToDeleteRows = False
            Me.ActivityGrid.AllowUserToResizeRows = False
            Me.ActivityGrid.RowHeadersVisible = False
            Me.ActivityGrid.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.ActivityGrid.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.ActivityGrid.MultiSelect = False
            Me.ActivityGrid.EnableHeadersVisualStyles = False
            Me.ActivityGrid.GridColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
            Me.ActivityGrid.ColumnHeadersHeight = 38
            Me.ActivityGrid.RowTemplate.Height = 42
            Me.ActivityGrid.AccessibleName = "Transaction history"
            ' ActivityGridDate
            Me.ActivityGridDate.Name = "ActivityGridDate"
            Me.ActivityGridDate.HeaderText = "DATE"
            Me.ActivityGridDate.FillWeight = 28F
            Me.ActivityGridDate.ReadOnly = True
            Me.ActivityGridDate.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' ActivityGridDescription
            Me.ActivityGridDescription.Name = "ActivityGridDescription"
            Me.ActivityGridDescription.HeaderText = "DESCRIPTION"
            Me.ActivityGridDescription.FillWeight = 42F
            Me.ActivityGridDescription.ReadOnly = True
            Me.ActivityGridDescription.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' ActivityGridDirection
            Me.ActivityGridDirection.Name = "ActivityGridDirection"
            Me.ActivityGridDirection.HeaderText = "TYPE"
            Me.ActivityGridDirection.FillWeight = 16F
            Me.ActivityGridDirection.ReadOnly = True
            Me.ActivityGridDirection.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' ActivityGridAmount
            Me.ActivityGridAmount.Name = "ActivityGridAmount"
            Me.ActivityGridAmount.HeaderText = "AMOUNT"
            Me.ActivityGridAmount.FillWeight = 22F
            Me.ActivityGridAmount.ReadOnly = True
            Me.ActivityGridAmount.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            ' EmptyLabel
            Me.EmptyLabel.Location = New Global.System.Drawing.Point(32, 562)
            Me.EmptyLabel.Size = New Global.System.Drawing.Size(850, 32)
            Me.EmptyLabel.Name = "EmptyLabel"
            Me.EmptyLabel.TabIndex = 9
            Me.EmptyLabel.Text = "No transactions for this account."
            Me.EmptyLabel.Font = New Global.System.Drawing.Font("Segoe UI", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.EmptyLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' DetailsHintLabel
            Me.DetailsHintLabel.Location = New Global.System.Drawing.Point(32, 606)
            Me.DetailsHintLabel.Size = New Global.System.Drawing.Size(850, 30)
            Me.DetailsHintLabel.Name = "DetailsHintLabel"
            Me.DetailsHintLabel.TabIndex = 10
            Me.DetailsHintLabel.Text = "Select a transaction to see its reference and account details."
            Me.DetailsHintLabel.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.DetailsHintLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            ' DetailsLabel
            Me.DetailsLabel.Location = New Global.System.Drawing.Point(32, 642)
            Me.DetailsLabel.Size = New Global.System.Drawing.Size(850, 86)
            Me.DetailsLabel.Name = "DetailsLabel"
            Me.DetailsLabel.TabIndex = 11
            Me.DetailsLabel.Text = "Reference and account details"
            Me.DetailsLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.DetailsLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
            Me.ActivityGrid.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() {Me.ActivityGridDate, Me.ActivityGridDescription, Me.ActivityGridDirection, Me.ActivityGridAmount})
            Me.ActivityGrid.DefaultCellStyle = bodyStyle
            Me.ActivityGrid.ColumnHeadersDefaultCellStyle = headerStyle
            Me.ActivityGridAmount.DefaultCellStyle = amountStyle
            Me.Controls.Add(Me.TitleLabel)
            Me.Controls.Add(Me.FilterLabel)
            Me.Controls.Add(Me.AccountFilter)
            Me.Controls.Add(Me.RefreshButton)
            Me.Controls.Add(Me.ActivityGrid)
            Me.Controls.Add(Me.EmptyLabel)
            Me.Controls.Add(Me.DetailsHintLabel)
            Me.Controls.Add(Me.DetailsLabel)
            Me.AutoScaleDimensions = New Global.System.Drawing.SizeF(7.0F, 15.0F)
            Me.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
            Me.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
            Me.Font = New Global.System.Drawing.Font("Segoe UI", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point)
            Me.Name = "ActivityView"
            Me.Size = New Global.System.Drawing.Size(1024, 760)
            Me.AutoScroll = True
            Me.AutoScrollMinSize = New Global.System.Drawing.Size(900, 740)
            CType(Me.ActivityGrid, Global.System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents TitleLabel As Global.System.Windows.Forms.Label
        Friend WithEvents FilterLabel As Global.System.Windows.Forms.Label
        Friend WithEvents AccountFilter As Global.System.Windows.Forms.ComboBox
        Friend WithEvents RefreshButton As Global.System.Windows.Forms.Button
        Friend WithEvents ActivityGrid As Global.System.Windows.Forms.DataGridView
        Friend WithEvents ActivityGridDate As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ActivityGridDescription As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ActivityGridDirection As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ActivityGridAmount As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EmptyLabel As Global.System.Windows.Forms.Label
        Friend WithEvents DetailsHintLabel As Global.System.Windows.Forms.Label
        Friend WithEvents DetailsLabel As Global.System.Windows.Forms.Label
    End Class
End Namespace
