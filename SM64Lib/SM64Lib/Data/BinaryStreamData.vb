Imports System.IO

Namespace Global.SM64Lib.Data

    Public Class BinaryStreamData
        Inherits BinaryData

        Private ReadOnly myBaseStream As Stream
        Public ReadOnly Property RomAccess As FileAccess = FileAccess.Read

        Public Sub New(stream As Stream)
            myBaseStream = stream
        End Sub

        Protected Overrides Function GetBaseStream() As Stream
            Return myBaseStream
        End Function

    End Class

End Namespace
