Namespace EventArguments

    Public Class RomVersionEventArgs
        Inherits EventArgs

        Public Property RomVersion As RomVersion

        Friend Sub New(romVersion As RomVersion)
            Me.RomVersion = romVersion
        End Sub

    End Class

End Namespace
