Imports System.IO

Namespace Data

    Public Class BinaryArrayData
        Inherits BinaryStreamData

        Public ReadOnly Property RomAccess As FileAccess = FileAccess.Read

        Public Sub New(buffer As Byte())
            MyBase.New(New MemoryStream(buffer))
        End Sub

        'Inherits BinaryData

        'Private ReadOnly myBaseStream As Stream

        'Public ReadOnly Property RomAccess As FileAccess = FileAccess.Read

        'Public Sub New(buffer As Byte())
        '    myBaseStream = New MemoryStream(buffer)
        'End Sub

        'Protected Overrides Function GetBaseStream() As Stream
        '    Return myBaseStream
        'End Function

    End Class

End Namespace
