<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits Global.System.Windows.Forms.Form

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
        Me.SidebarPanel = New Global.System.Windows.Forms.Panel()
        Me.BrandLabel = New Global.System.Windows.Forms.Label()
        Me.AccountsButton = New Global.System.Windows.Forms.Button()
        Me.TransferButton = New Global.System.Windows.Forms.Button()
        Me.ActivityButton = New Global.System.Windows.Forms.Button()
        Me.UserNameLabel = New Global.System.Windows.Forms.Label()
        Me.SignOutButton = New Global.System.Windows.Forms.Button()
        Me.ContentPanel = New Global.System.Windows.Forms.Panel()
        Me.PageHost = New Global.System.Windows.Forms.Panel()
        Me.SignInPage = New Global.Pocketbank_vWF.UI.Views.SignInView()
        Me.StatusLabel = New Global.System.Windows.Forms.Label()
        Me.SessionTimer = New Global.System.Windows.Forms.Timer(Me.components)
        Me.SidebarPanel.SuspendLayout()
        Me.ContentPanel.SuspendLayout()
        Me.PageHost.SuspendLayout()
        Me.SuspendLayout()
        '
        ' SidebarPanel
        '
        Me.SidebarPanel.BackColor = Global.System.Drawing.Color.FromArgb(17, 26, 44)
        Me.SidebarPanel.Controls.Add(Me.BrandLabel)
        Me.SidebarPanel.Controls.Add(Me.AccountsButton)
        Me.SidebarPanel.Controls.Add(Me.TransferButton)
        Me.SidebarPanel.Controls.Add(Me.ActivityButton)
        Me.SidebarPanel.Controls.Add(Me.UserNameLabel)
        Me.SidebarPanel.Controls.Add(Me.SignOutButton)
        Me.SidebarPanel.Dock = Global.System.Windows.Forms.DockStyle.Left
        Me.SidebarPanel.Location = New Global.System.Drawing.Point(0, 0)
        Me.SidebarPanel.Name = "SidebarPanel"
        Me.SidebarPanel.Size = New Global.System.Drawing.Size(210, 820)
        Me.SidebarPanel.TabIndex = 0
        Me.SidebarPanel.Visible = False
        '
        ' BrandLabel
        '
        Me.BrandLabel.Font = New Global.System.Drawing.Font("Segoe UI", 16.0F, Global.System.Drawing.FontStyle.Bold)
        Me.BrandLabel.ForeColor = Global.System.Drawing.Color.FromArgb(83, 147, 255)
        Me.BrandLabel.Location = New Global.System.Drawing.Point(18, 30)
        Me.BrandLabel.Name = "BrandLabel"
        Me.BrandLabel.Size = New Global.System.Drawing.Size(180, 44)
        Me.BrandLabel.Text = "Pocket Bank"
        '
        ' AccountsButton
        '
        Me.AccountsButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
        Me.AccountsButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
        Me.AccountsButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
        Me.AccountsButton.Font = New Global.System.Drawing.Font("Segoe UI", 10.0F, Global.System.Drawing.FontStyle.Bold)
        Me.AccountsButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
        Me.AccountsButton.Location = New Global.System.Drawing.Point(18, 100)
        Me.AccountsButton.Name = "AccountsButton"
        Me.AccountsButton.Size = New Global.System.Drawing.Size(174, 44)
        Me.AccountsButton.TabIndex = 0
        Me.AccountsButton.Text = "Accounts"
        Me.AccountsButton.UseVisualStyleBackColor = False
        '
        ' TransferButton
        '
        Me.TransferButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
        Me.TransferButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
        Me.TransferButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
        Me.TransferButton.Font = New Global.System.Drawing.Font("Segoe UI", 10.0F, Global.System.Drawing.FontStyle.Bold)
        Me.TransferButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
        Me.TransferButton.Location = New Global.System.Drawing.Point(18, 158)
        Me.TransferButton.Name = "TransferButton"
        Me.TransferButton.Size = New Global.System.Drawing.Size(174, 44)
        Me.TransferButton.TabIndex = 1
        Me.TransferButton.Text = "Transfer"
        Me.TransferButton.UseVisualStyleBackColor = False
        '
        ' ActivityButton
        '
        Me.ActivityButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
        Me.ActivityButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
        Me.ActivityButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
        Me.ActivityButton.Font = New Global.System.Drawing.Font("Segoe UI", 10.0F, Global.System.Drawing.FontStyle.Bold)
        Me.ActivityButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
        Me.ActivityButton.Location = New Global.System.Drawing.Point(18, 216)
        Me.ActivityButton.Name = "ActivityButton"
        Me.ActivityButton.Size = New Global.System.Drawing.Size(174, 44)
        Me.ActivityButton.TabIndex = 2
        Me.ActivityButton.Text = "Activity"
        Me.ActivityButton.UseVisualStyleBackColor = False
        '
        ' UserNameLabel
        '
        Me.UserNameLabel.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
        Me.UserNameLabel.Font = New Global.System.Drawing.Font("Segoe UI", 11.0F, Global.System.Drawing.FontStyle.Bold)
        Me.UserNameLabel.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
        Me.UserNameLabel.Location = New Global.System.Drawing.Point(18, 684)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New Global.System.Drawing.Size(174, 52)
        Me.UserNameLabel.Text = "Account holder"
        '
        ' SignOutButton
        '
        Me.SignOutButton.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
        Me.SignOutButton.BackColor = Global.System.Drawing.Color.FromArgb(24, 36, 57)
        Me.SignOutButton.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
        Me.SignOutButton.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(46, 63, 87)
        Me.SignOutButton.Font = New Global.System.Drawing.Font("Segoe UI", 10.0F, Global.System.Drawing.FontStyle.Bold)
        Me.SignOutButton.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
        Me.SignOutButton.Location = New Global.System.Drawing.Point(18, 752)
        Me.SignOutButton.Name = "SignOutButton"
        Me.SignOutButton.Size = New Global.System.Drawing.Size(174, 44)
        Me.SignOutButton.TabIndex = 3
        Me.SignOutButton.Text = "Sign out"
        Me.SignOutButton.UseVisualStyleBackColor = False
        '
        ' ContentPanel
        '
        Me.ContentPanel.Controls.Add(Me.PageHost)
        Me.ContentPanel.Controls.Add(Me.StatusLabel)
        Me.ContentPanel.Dock = Global.System.Windows.Forms.DockStyle.Fill
        Me.ContentPanel.Location = New Global.System.Drawing.Point(210, 0)
        Me.ContentPanel.Name = "ContentPanel"
        Me.ContentPanel.Size = New Global.System.Drawing.Size(1030, 820)
        Me.ContentPanel.TabIndex = 1
        '
        ' PageHost
        '
        Me.PageHost.Controls.Add(Me.SignInPage)
        Me.PageHost.Dock = Global.System.Windows.Forms.DockStyle.Fill
        Me.PageHost.Location = New Global.System.Drawing.Point(0, 0)
        Me.PageHost.Name = "PageHost"
        Me.PageHost.Size = New Global.System.Drawing.Size(1030, 764)
        Me.PageHost.TabIndex = 0
        '
        ' SignInPage
        '
        Me.SignInPage.Dock = Global.System.Windows.Forms.DockStyle.Fill
        Me.SignInPage.Location = New Global.System.Drawing.Point(0, 0)
        Me.SignInPage.Name = "SignInPage"
        Me.SignInPage.Size = New Global.System.Drawing.Size(1030, 764)
        Me.SignInPage.TabIndex = 0
        '
        ' StatusLabel
        '
        Me.StatusLabel.AccessibleRole = Global.System.Windows.Forms.AccessibleRole.Alert
        Me.StatusLabel.Dock = Global.System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.Font = New Global.System.Drawing.Font("Segoe UI", 10.0F)
        Me.StatusLabel.ForeColor = Global.System.Drawing.Color.FromArgb(161, 179, 203)
        Me.StatusLabel.Location = New Global.System.Drawing.Point(0, 764)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Padding = New Global.System.Windows.Forms.Padding(24, 8, 24, 8)
        Me.StatusLabel.Size = New Global.System.Drawing.Size(1030, 56)
        Me.StatusLabel.TabIndex = 1
        '
        ' SessionTimer
        '
        Me.SessionTimer.Interval = 60000
        '
        ' Form1
        '
        Me.AutoScaleDimensions = New Global.System.Drawing.SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.System.Drawing.Color.FromArgb(13, 20, 35)
        Me.ClientSize = New Global.System.Drawing.Size(1240, 820)
        Me.Controls.Add(Me.ContentPanel)
        Me.Controls.Add(Me.SidebarPanel)
        Me.DoubleBuffered = True
        Me.Font = New Global.System.Drawing.Font("Segoe UI", 9.0F)
        Me.ForeColor = Global.System.Drawing.Color.FromArgb(239, 244, 252)
        Me.MinimumSize = New Global.System.Drawing.Size(1100, 740)
        Me.Name = "Form1"
        Me.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pocket Bank"
        Me.SidebarPanel.ResumeLayout(False)
        Me.ContentPanel.ResumeLayout(False)
        Me.PageHost.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents SidebarPanel As Global.System.Windows.Forms.Panel
    Friend WithEvents BrandLabel As Global.System.Windows.Forms.Label
    Friend WithEvents AccountsButton As Global.System.Windows.Forms.Button
    Friend WithEvents TransferButton As Global.System.Windows.Forms.Button
    Friend WithEvents ActivityButton As Global.System.Windows.Forms.Button
    Friend WithEvents UserNameLabel As Global.System.Windows.Forms.Label
    Friend WithEvents SignOutButton As Global.System.Windows.Forms.Button
    Friend WithEvents ContentPanel As Global.System.Windows.Forms.Panel
    Friend WithEvents PageHost As Global.System.Windows.Forms.Panel
    Friend WithEvents SignInPage As Global.Pocketbank_vWF.UI.Views.SignInView
    Friend WithEvents StatusLabel As Global.System.Windows.Forms.Label
    Friend WithEvents SessionTimer As Global.System.Windows.Forms.Timer
End Class
