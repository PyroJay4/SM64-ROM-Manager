Imports SM64Lib

Namespace EventArguments

    Public Class RomManagerChangedEventArgs
        Inherits EventArgs

        Public ReadOnly Property Old As RomManager
        Public ReadOnly Property [New] As RomManager

        Public Sub New(old As RomManager, [new] As RomManager)
            Me.Old = old
            Me.[New] = [new]
        End Sub

    End Class

End Namespace
