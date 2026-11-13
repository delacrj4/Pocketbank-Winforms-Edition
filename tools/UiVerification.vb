Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Pocketbank_vWF.Domain
Imports Pocketbank_vWF.UI.Views

' Offscreen control tests: no desktop input, visible windows, database, or user credentials.
Module UiVerification
    Private count As Integer

    Public Sub Run(renderFolder As String)
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2)
        Application.EnableVisualStyles()
        If renderFolder <> "" Then Directory.CreateDirectory(renderFolder)
        Using form As New Pocketbank_vWF.Form1()
            Check(Find(Of SignInView)(form, "SignInPage") IsNot Nothing, "Main form contains the Designer sign-in view before startup")
            Check(AllControls(form).OfType(Of Button)().All(Function(b) Not b.Text.Contains("connection", StringComparison.OrdinalIgnoreCase)), "No connection-status button")
            Render(form, renderFolder, "MainForm")
        End Using
        Using view As New SignInView()
            Dim sent = False
            AddHandler view.SignInRequested, Sub(email, password) sent = email = "sample@example.invalid" AndAlso password = "sample-pass"
            Find(Of TextBox)(view, "EmailTextBox").Text = "sample@example.invalid"
            Find(Of TextBox)(view, "PasswordTextBox").Text = "sample-pass"
            Click(Find(Of Button)(view, "SubmitButton"))
            Check(sent, "Designer sign-in button forwards entered credentials")
            Find(Of CheckBox)(view, "ShowPasswordCheckBox").Checked = True
            Check(Not Find(Of TextBox)(view, "PasswordTextBox").UseSystemPasswordChar, "Show-password control works")
            view.ClearPassword()
            Check(Find(Of TextBox)(view, "PasswordTextBox").Text = "", "Password clears after sign-in")
            Find(Of TextBox)(view, "EmailTextBox").Clear()
            Find(Of CheckBox)(view, "ShowPasswordCheckBox").Checked = False
            Render(view, renderFolder, "SignIn")
            Check(Find(Of Panel)(view, "CredentialsPanel").Width = 480, "Sign-in form retains its Designer dimensions")
        End Using
        Using view As New RegistrationView()
            Dim sent = False
            AddHandler view.RegistrationRequested, Sub(name, email, password) sent = name = "Sample" AndAlso email = "sample@example.invalid" AndAlso password = "sample-pass"
            Find(Of TextBox)(view, "NameTextBox").Text = "Sample"
            Find(Of TextBox)(view, "EmailTextBox").Text = "sample@example.invalid"
            Find(Of TextBox)(view, "PasswordTextBox").Text = "sample-pass"
            Click(Find(Of Button)(view, "SubmitButton"))
            Check(sent, "Designer registration button forwards the registration fields")
            Find(Of TextBox)(view, "NameTextBox").Clear()
            Find(Of TextBox)(view, "EmailTextBox").Clear()
            view.ClearPassword()
            Render(view, renderFolder, "Registration")
        End Using

        Dim checking As New BankAccount With {.Number = "AAAAAAAAAAAAAAAA", .Kind = "Checking", .BalanceCents = 75000}
        Dim savings As New BankAccount With {.Number = "BBBBBBBBBBBBBBBB", .Kind = "Savings", .BalanceCents = 25000}
        Dim data As New Dashboard With {.Accounts = New List(Of BankAccount) From {checking, savings}}
        Dim internalTransfer As New Activity With {.Reference = "sample-reference", .CreatedAt = DateTime.UtcNow, .Source = checking.Number, .Destination = savings.Number, .Direction = "Internal", .AmountCents = 25000, .Description = "Between your accounts"}
        data.Transactions.Add(internalTransfer)
        Using view As New AccountsView()
            view.BindDashboard(New Dashboard With {.Accounts = New List(Of BankAccount) From {checking}})
            Check(Find(Of Button)(view, "OpenSavingsButton").Visible, "Open-savings action available without savings")
            Check(Find(Of Label)(view, "EmptyLabel").Visible, "Empty activity state displayed")
            Render(view, renderFolder, "Accounts-empty")
            view.BindDashboard(data)
            Check(Find(Of Label)(view, "TotalBalanceLabel").Text = "$1,000.00", "Account total binds in the Designer label")
            Check(Not Find(Of Button)(view, "OpenSavingsButton").Visible, "Savings action hides after account creation")
            Check(Find(Of TextBox)(view, "SavingsNumberTextBox").Text = savings.Number, "Savings account details bind")
            Check(Find(Of DataGridView)(view, "RecentGrid").Rows.Count = 1, "Recent activity binds into the Designer grid")
            Render(view, renderFolder, "Accounts")
        End Using
        Using view As New TransferView()
            Check(Find(Of Panel)(view, "ReviewPanel").Visible, "Transfer confirmation layout is visible before runtime binding")
            Render(view, renderFolder, "Transfer-designer")
            view.BindAccounts(data.Accounts)
            Check(Not Find(Of Panel)(view, "ReviewPanel").Visible, "Confirmation stays hidden until review at runtime")
            Find(Of TextBox)(view, "DestinationTextBox").Text = savings.Number
            Find(Of TextBox)(view, "AmountTextBox").Text = "25.50"
            Dim draft = view.ReadDraft()
            Check(draft.AmountCents = 2550 AndAlso draft.Source = checking.Number AndAlso draft.Destination = savings.Number, "Transfer fields produce exact integer cents")
            draft.Recipient = "Sample Recipient"
            draft.DestinationKind = "Savings"
            view.ShowReview(draft)
            Check(view.ReviewedDraft.RequestId = draft.RequestId, "Review preserves retry identity")
            Dim confirmed = False
            AddHandler view.ConfirmationRequested, Sub() confirmed = True
            Click(Find(Of Button)(view, "ConfirmButton"))
            Check(confirmed, "Designer confirmation button raises its action")
            Render(view, renderFolder, "Transfer-review")
            Find(Of TextBox)(view, "AmountTextBox").Text = "30.00"
            Rejected(Sub()
                         Dim changed = view.ReviewedDraft
                     End Sub, "Editing details invalidates the reviewed transfer")
            Find(Of TextBox)(view, "AmountTextBox").Text = "1.001"
            Rejected(Sub() view.ReadDraft(), "Fractional cents are rejected")
            Find(Of TextBox)(view, "AmountTextBox").Text = "0"
            Rejected(Sub() view.ReadDraft(), "Zero transfer amount rejected")
            Click(Find(Of Button)(view, "UseCheckingButton"))
            Check(Find(Of TextBox)(view, "DestinationTextBox").Text = checking.Number, "Own-account shortcut works")
            Find(Of TextBox)(view, "AmountTextBox").Clear()
            Find(Of TextBox)(view, "DestinationTextBox").Clear()
            Render(view, renderFolder, "Transfer")
        End Using
        Using view As New ActivityView()
            view.BindDashboard(data)
            Dim grid = Find(Of DataGridView)(view, "ActivityGrid")
            Check(grid.Rows.Count = 1 AndAlso CStr(grid.Rows(0).Cells(2).Value) = "Internal", "All-accounts activity shows internal transfer")
            Find(Of ComboBox)(view, "AccountFilter").SelectedIndex = 2
            Check(CStr(grid.Rows(0).Cells(2).Value) = "Received" AndAlso CStr(grid.Rows(0).Cells(3).Value) = "+$250.00", "Savings filter shows incoming side of internal transfer")
            Find(Of ComboBox)(view, "AccountFilter").SelectedIndex = 1
            Check(CStr(grid.Rows(0).Cells(2).Value) = "Sent", "Checking filter shows outgoing side")
            grid.Rows(0).Selected = True
            Check(Find(Of Label)(view, "DetailsLabel").Text.Contains(internalTransfer.Reference), "Selecting activity shows its reference")
            Render(view, renderFolder, "Activity")
            view.BindDashboard(New Dashboard With {.Accounts = data.Accounts})
            Check(grid.Rows.Count = 0 AndAlso Find(Of Label)(view, "EmptyLabel").Visible, "Account history handles empty data")
        End Using
        Console.WriteLine($"{count} offscreen UI checks passed. No Oracle access or desktop control used.")
    End Sub

    Private Function Find(Of T As Control)(root As Control, name As String) As T
        Dim found = root.Controls.Find(name, True)
        If found.Length <> 1 Then Throw New Exception($"Expected one control named {name}, found {found.Length}.")
        Return DirectCast(found(0), T)
    End Function

    Private Iterator Function AllControls(root As Control) As IEnumerable(Of Control)
        For Each child As Control In root.Controls
            Yield child
            For Each nested In AllControls(child)
                Yield nested
            Next
        Next
    End Function

    Private Sub Click(button As Button)
        ' Invoke the control's own click event without sending mouse input or showing a window.
        GetType(Button).GetMethod("OnClick", BindingFlags.Instance Or BindingFlags.NonPublic).Invoke(button, {EventArgs.Empty})
    End Sub

    Private Sub Check(condition As Boolean, description As String)
        If Not condition Then Throw New Exception("FAIL: " & description)
        count += 1
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

    Private Sub Render(control As Control, folder As String, name As String)
        If folder = "" Then Return
        control.CreateControl()
        Layout(control)
        Using bitmap As New Bitmap(control.Width, control.Height)
            control.DrawToBitmap(bitmap, New Rectangle(Point.Empty, bitmap.Size))
            bitmap.Save(Path.Combine(folder, name & ".png"), Imaging.ImageFormat.Png)
        End Using
    End Sub

    Private Sub Layout(control As Control)
        ' A hidden Form does not create child handles automatically. Force handles for
        ' offscreen painting without showing a window or triggering its Shown event.
        Dim handle = control.Handle
        control.PerformLayout()
        For Each child As Control In control.Controls
            Layout(child)
        Next
    End Sub
End Module
