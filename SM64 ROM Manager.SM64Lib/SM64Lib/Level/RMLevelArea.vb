Namespace Levels

    Public Class RMLevelArea
        Inherits LevelArea

        Public Sub New(AreaID As Byte)
            MyBase.New(AreaID)
        End Sub

        Public Sub New(AreaID As Byte, LevelID As Byte)
            MyBase.New(AreaID, LevelID)
        End Sub

        Public Sub New(AreaID As Byte, LevelID As Byte, AddWarps As Boolean, AddObjects As Boolean)
            MyBase.New(AreaID, LevelID, AddWarps, AddObjects)
        End Sub

        Public Sub New()
            MyBase.New
        End Sub

    End Class

End Namespace
