Imports SM64Lib.Geolayout
Imports SM64Lib.Levels
Imports SM64Lib.Music

Namespace EventArguments

    Public Class LevelAreaBackgroundModeChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property BackgroundType As AreaBGs
        Public ReadOnly Property BackgroundColor As Color

        Public Sub New(typ As AreaBGs, color As Color)
            BackgroundType = typ
            BackgroundColor = color
        End Sub

    End Class

End Namespace
