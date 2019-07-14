Imports SM64Lib.Music

Namespace EventArguments

    Public Class SpecialItemEventArgs
        Inherits EventArgs

        Public ReadOnly Property ItemIndex As Integer
        Public ReadOnly Property LevelIndex As Integer
        Public ReadOnly Property AreaIndex As Integer

        Public Sub New(itemIndex As Integer, levelIndex As Integer, areaIndex As Integer)
            Me.ItemIndex = itemIndex
            Me.LevelIndex = levelIndex
            Me.AreaIndex = areaIndex
        End Sub

    End Class

End Namespace
