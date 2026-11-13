Imports Pocketbank_vWF.Domain

Namespace UI.Views
    Public Class AccountsView
        Public Event OpenSavingsRequested()
        Public Event TransferRequested()
        Public Event RefreshRequested()

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub BindDashboard(data As Dashboard)
            TotalBalanceLabel.Text = Theme.Money(data.Accounts.Sum(Function(a) a.BalanceCents))
            Dim checking = data.Accounts.FirstOrDefault(Function(a) a.Kind = "Checking")
            CheckingBalanceLabel.Text = Theme.Money(If(checking Is Nothing, 0, checking.BalanceCents))
            CheckingNumberTextBox.Text = If(checking Is Nothing, "", checking.Number)
            Dim savings = data.Accounts.FirstOrDefault(Function(a) a.Kind = "Savings")
            SavingsBalanceLabel.Visible = savings IsNot Nothing
            SavingsAvailableLabel.Visible = savings IsNot Nothing
            SavingsNumberTextBox.Visible = savings IsNot Nothing
            SavingsPromptLabel.Visible = savings Is Nothing
            OpenSavingsButton.Visible = savings Is Nothing
            SavingsBalanceLabel.Text = Theme.Money(If(savings Is Nothing, 0, savings.BalanceCents))
            SavingsNumberTextBox.Text = If(savings Is Nothing, "", savings.Number)
            ActivityBinding.Fill(RecentGrid, data.Transactions.Take(4))
            RecentGrid.Visible = data.Transactions.Count > 0
            EmptyLabel.Visible = data.Transactions.Count = 0
        End Sub

        Private Sub OpenSavingsButton_Click(sender As Object, e As EventArgs) Handles OpenSavingsButton.Click
            RaiseEvent OpenSavingsRequested()
        End Sub

        Private Sub TransferButton_Click(sender As Object, e As EventArgs) Handles TransferButton.Click
            RaiseEvent TransferRequested()
        End Sub

        Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
            RaiseEvent RefreshRequested()
        End Sub
    End Class
End Namespace
