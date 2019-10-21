Namespace ObjectBanks.Data

    Public Class ObjectBankData

        Public Property Name As String
        Public ReadOnly Property Objects As New List(Of String)
        Public ReadOnly Property Commands As New List(Of ObjectBankDataCommand)

    End Class

End Namespace
