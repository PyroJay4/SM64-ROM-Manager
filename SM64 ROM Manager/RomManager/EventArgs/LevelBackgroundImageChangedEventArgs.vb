Imports SM64Lib.Geolayout
Imports SM64Lib.Music

Namespace EventArguments

    Public Class LevelBackgroundImageChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property BackgroundID As BackgroundIDs
        Public ReadOnly Property BackgroundImage As Image

        Public Sub New(id As BackgroundIDs, image As Image)
            BackgroundID = id
            BackgroundImage = image
        End Sub

    End Class

End Namespace
