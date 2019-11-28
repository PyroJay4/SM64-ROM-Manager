Imports System.IO

Namespace Levels

    Public Class LevelNumberTable
        Inherits List(Of Byte)

        Public Sub ReadFromROM(Romfile As String, Optional Address As Integer = &HE8D98)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.Read)
            ReadFromROM(fs)
            fs.Close()
        End Sub

        Public Sub ReadFromROM(ByRef fs As FileStream, Optional Address As Integer = &HE8D98)
            Me.Clear()
            For i As Integer = 0 To 30
                fs.Position = Address + GetLevelIDFromIndex(i)
                Me.Add(fs.ReadByte)
            Next
        End Sub

    End Class

End Namespace
