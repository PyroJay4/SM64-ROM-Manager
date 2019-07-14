Imports SM64Lib.Music

Namespace EventArguments

    Public Class MusicSequenceEventArgs
        Inherits EventArgs

        Public ReadOnly Property Index As Integer
        Public ReadOnly Property Sequence As MusicSequence

        Public Sub New(index As Integer, sequence As MusicSequence)
            Me.Index = index
            Me.Sequence = sequence
        End Sub

    End Class

End Namespace
