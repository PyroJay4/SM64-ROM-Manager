Namespace Levels

    Public Class OriginalLevel
        Inherits Level

        Public Sub New(LevelID As UShort, LevelIndex As Integer)
            MyBase.New(LevelID, LevelIndex)
        End Sub

        Public Sub New()
            MyBase.New
        End Sub

    End Class

End Namespace
