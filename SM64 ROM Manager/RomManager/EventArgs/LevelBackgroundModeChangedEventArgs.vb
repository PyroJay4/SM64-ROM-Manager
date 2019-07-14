Imports SM64Lib.Geolayout
Imports SM64Lib.Music

Namespace EventArguments

    Public Class LevelBackgroundModeChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property BackgroundMode As Integer
        Public ReadOnly Property BackgroundID As BackgroundIDs
        Public ReadOnly Property BackgroundImage As Image

        Public Sub New(mode As Integer, id As BackgroundIDs, image As Image)
            BackgroundMode = mode
            BackgroundID = id
            BackgroundImage = image
        End Sub

    End Class

End Namespace
