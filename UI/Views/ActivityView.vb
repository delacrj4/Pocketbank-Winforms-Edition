Imports Pocketbank_vWF.Domain

Namespace UI.Views
    Public Class ActivityView
        Public Event RefreshRequested()
        Private data As New Dashboard()
        Private binding As Boolean

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub BindDashboard(value As Dashboard)
            data = value
            binding = True
            Try
                AccountFilter.Items.Clear()
                AccountFilter.Items.Add("All accounts")
                For Each account In data.Accounts
                    AccountFilter.Items.Add(account)
                Next
                AccountFilter.SelectedIndex = 0
            Finally
                binding = False
            End Try
            ApplyFilter()
        End Sub

        Private Sub AccountFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AccountFilter.SelectedIndexChanged
            If Not binding Then ApplyFilter()
        End Sub

        Private Sub ApplyFilter()
            Dim account = TryCast(AccountFilter.SelectedItem, BankAccount)
            Dim rows = data.Transactions.Where(Function(t) account Is Nothing OrElse t.Source = account.Number OrElse t.Destination = account.Number).ToList()
            ActivityBinding.Fill(ActivityGrid, rows, If(account Is Nothing, "", account.Number))
            EmptyLabel.Visible = rows.Count = 0
            DetailsLabel.Text = ""
        End Sub

        Private Sub ActivityGrid_SelectionChanged(sender As Object, e As EventArgs) Handles ActivityGrid.SelectionChanged
            DetailsLabel.Text = ""
            If ActivityGrid.SelectedRows.Count = 0 Then Return
            Dim item = TryCast(ActivityGrid.SelectedRows(0).Tag, Activity)
            If item Is Nothing Then Return
            DetailsLabel.Text = "Reference: " & item.Reference & vbCrLf & "From: " & item.Source & vbCrLf & "To: " & item.Destination
        End Sub

        Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
            RaiseEvent RefreshRequested()
        End Sub
    End Class
End Namespace
