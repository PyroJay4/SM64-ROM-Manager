Imports SM64Lib.Music

Namespace EventArguments

    Public Class LevelEventArgs
        Inherits EventArgs

        Public ReadOnly Property LevelIndex As Integer
        Public ReadOnly Property LevelID As UShort

        Public Sub New(levelIndex As Integer, levelID As UShort)
            Me.LevelIndex = levelIndex
            Me.LevelID = levelID
        End Sub

    End Class

End Namespace
