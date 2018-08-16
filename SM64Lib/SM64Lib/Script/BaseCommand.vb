Imports System.IO
Imports SM64Lib.Script

Namespace Global.SM64Lib.Script

    <Serializable>
    Public MustInherit Class BaseCommand(Of eTypes)
        Inherits MemoryStream
        Implements ICommand

        Public Property RomAddress As Integer = 0 Implements ICommand.RomAddress
        Public Property BankAddress As Integer = 0 Implements ICommand.BankAddress
        Public MustOverride Property CommandType As eTypes

        Public Sub New(bytes As String, Optional enabledHex As Boolean = True)
            Dim bts As New List(Of Byte)
            For Each b As String In bytes.Split(" ")
                If enabledHex Then b = CInt("&H" & b)
                bts.Add(b)
            Next
            NewBytes(bts.ToArray)
        End Sub

        Public Sub New()
        End Sub

        Public Sub New(bytes() As Byte)
            NewBytes(bytes)
        End Sub

        Private Sub NewBytes(bytes() As Byte)
            SetLength(bytes.Count)
            For Each b As Byte In bytes
                WriteByte(b)
            Next
            Position = 0
        End Sub

        Public Overrides Function ToString() As String
            ToString = $"{RomAddress.ToString("X")} ({BankAddress.ToString("X")}):"
            For Each b As Byte In Me.ToArray
                ToString &= " " & b.ToString("X2")
            Next
        End Function

    End Class

End Namespace
