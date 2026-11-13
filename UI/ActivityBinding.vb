Imports Pocketbank_vWF.Domain

Namespace UI
    Friend Module ActivityBinding
        Public Sub Fill(grid As DataGridView, items As IEnumerable(Of Activity), Optional account As String = "")
            grid.Rows.Clear()
            For Each item In items
                Dim direction = item.Direction
                If account <> "" AndAlso direction = "Internal" Then direction = If(item.Source = account, "Sent", "Received")
                Dim sign = If(direction = "Sent", "−", If(direction = "Received", "+", ""))
                Dim index = grid.Rows.Add(item.CreatedAt.ToLocalTime().ToString("MMM d, yyyy HH:mm"), item.Description, direction, sign & Theme.Money(item.AmountCents))
                grid.Rows(index).Tag = item
                grid.Rows(index).Cells(3).Style.ForeColor = If(direction = "Received", Theme.Good, Theme.Ink)
            Next
            grid.ClearSelection()
        End Sub
    End Module
End Namespace
