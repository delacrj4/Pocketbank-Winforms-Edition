Namespace Domain
    Public Class BankUser
        Public Property Id As String = ""
        Public Property DisplayName As String = ""
        Public Property Email As String = ""
    End Class

    Public Class BankAccount
        Public Property Number As String = ""
        Public Property Kind As String = ""
        Public Property BalanceCents As Long
        Public Overrides Function ToString() As String
            Return $"{Kind}  ·  {Number}"
        End Function
    End Class

    Public Class Activity
        Public Property Reference As String = ""
        Public Property CreatedAt As DateTime
        Public Property Description As String = ""
        Public Property Source As String = ""
        Public Property Destination As String = ""
        Public Property Direction As String = ""
        Public Property AmountCents As Long
    End Class

    Public Class Dashboard
        Public Property Accounts As New List(Of BankAccount)
        Public Property Transactions As New List(Of Activity)
    End Class

    Public Class TransferDraft
        Public Property Source As String = ""
        Public Property Destination As String = ""
        Public Property AmountCents As Long
        Public Property Recipient As String = ""
        Public Property DestinationKind As String = ""
        Public Property RequestId As String = Guid.NewGuid().ToString()
    End Class

    Public Class BankingException
        Inherits Exception
        Public Sub New(message As String)
            MyBase.New(message)
        End Sub
    End Class
End Namespace
