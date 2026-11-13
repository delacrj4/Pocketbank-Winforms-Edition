Imports System.Globalization
Imports Pocketbank_vWF.Domain

Namespace UI.Views
    Public Class TransferView
        Public Event ReviewRequested()
        Public Event ConfirmationRequested()
        Private accounts As New List(Of BankAccount)
        Private bound As Boolean
        Private reviewed As TransferDraft

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub BindAccounts(value As IEnumerable(Of BankAccount))
            bound = False
            accounts = value.ToList()
            SourceComboBox.Items.Clear()
            For Each account In accounts
                SourceComboBox.Items.Add(account)
            Next
            If SourceComboBox.Items.Count > 0 Then SourceComboBox.SelectedIndex = 0
            UseCheckingButton.Enabled = accounts.Any(Function(a) a.Kind = "Checking")
            UseSavingsButton.Enabled = accounts.Any(Function(a) a.Kind = "Savings")
            bound = True
            InvalidateReview()
            UpdateAvailable()
        End Sub

        Public Function ReadDraft() As TransferDraft
            Dim dollars As Decimal
            If Not Decimal.TryParse(AmountTextBox.Text.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, dollars) OrElse dollars <= 0 OrElse dollars > 90071992547409.91D OrElse dollars * 100D <> Decimal.Truncate(dollars * 100D) Then Throw New BankingException("Enter a positive USD amount with up to two decimal places, such as 25.50.")
            Dim source = TryCast(SourceComboBox.SelectedItem, BankAccount)
            If source Is Nothing Then Throw New BankingException("Choose a source account.")
            Return New TransferDraft With {.Source = source.Number, .Destination = DestinationTextBox.Text.Trim().ToUpperInvariant(), .AmountCents = CLng(dollars * 100D)}
        End Function

        Public ReadOnly Property ReviewedDraft As TransferDraft
            Get
                If reviewed Is Nothing Then Throw New BankingException("Review the transfer before confirming.")
                Return reviewed
            End Get
        End Property

        Public Sub ShowReview(draft As TransferDraft)
            reviewed = draft
            ReviewAmountLabel.Text = Theme.Money(draft.AmountCents)
            RecipientLabel.Text = "To " & draft.Recipient & " · " & draft.DestinationKind
            ReviewDestinationLabel.Text = draft.Destination
            ReviewSourceLabel.Text = "From " & draft.Source
            ReviewPanel.Visible = True
            ScrollControlIntoView(ReviewPanel)
        End Sub

        Private Sub InvalidateReview()
            If Not bound Then Return
            reviewed = Nothing
            ReviewPanel.Visible = False
        End Sub

        Private Sub UpdateAvailable()
            Dim source = TryCast(SourceComboBox.SelectedItem, BankAccount)
            AvailableLabel.Text = If(source Is Nothing, "", Theme.Money(If(source Is Nothing, 0, source.BalanceCents)) & " available")
        End Sub

        Private Sub TransferDetailsChanged(sender As Object, e As EventArgs) Handles SourceComboBox.SelectedIndexChanged, AmountTextBox.TextChanged, DestinationTextBox.TextChanged
            InvalidateReview()
            If bound Then UpdateAvailable()
        End Sub

        Private Sub UseCheckingButton_Click(sender As Object, e As EventArgs) Handles UseCheckingButton.Click
            SelectDestination("Checking")
        End Sub

        Private Sub UseSavingsButton_Click(sender As Object, e As EventArgs) Handles UseSavingsButton.Click
            SelectDestination("Savings")
        End Sub

        Private Sub SelectDestination(kind As String)
            Dim account = accounts.FirstOrDefault(Function(a) a.Kind = kind)
            If account IsNot Nothing Then DestinationTextBox.Text = account.Number
        End Sub

        Private Sub ReviewButton_Click(sender As Object, e As EventArgs) Handles ReviewButton.Click
            RaiseEvent ReviewRequested()
        End Sub

        Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
            RaiseEvent ConfirmationRequested()
        End Sub

        Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
            InvalidateReview()
            AmountTextBox.Focus()
        End Sub
    End Class
End Namespace
