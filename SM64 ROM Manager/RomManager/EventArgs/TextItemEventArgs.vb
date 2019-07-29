Imports SM64Lib.Music

Namespace EventArguments

    Public Class TextItemEventArgs
        Inherits EventArgs

        Public ReadOnly Property TableName As String
        Public ReadOnly Property ItemIndex As Integer

        Public Sub New(tableName As String, itemIndex As Integer)
            Me.TableName = tableName
            Me.ItemIndex = itemIndex
        End Sub

    End Class

End Namespace
