Imports SM64Lib.Music

Namespace EventArguments

    Public Class TextItemEventArgs
        Inherits EventArgs

        Public ReadOnly Property GroupIndex As Integer
        Public ReadOnly Property ItemIndex As Integer

        Public Sub New(groupIndex As Integer, itemIndex As Integer)
            Me.GroupIndex = groupIndex
            Me.ItemIndex = itemIndex
        End Sub

    End Class

End Namespace
