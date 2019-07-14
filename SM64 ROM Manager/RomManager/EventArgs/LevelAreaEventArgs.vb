Imports SM64Lib.Music

Namespace EventArguments

    Public Class LevelAreaEventArgs
        Inherits EventArgs

        Public ReadOnly Property LevelIndex As Integer
        Public ReadOnly Property AreaIndex As Integer
        Public ReadOnly Property AreaID As Byte

        Public Sub New(levelIndex As Integer, areaIndex As Integer, areaID As Byte)
            Me.LevelIndex = levelIndex
            Me.AreaIndex = areaIndex
            Me.AreaID = areaID
        End Sub

    End Class

End Namespace
