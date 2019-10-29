Imports System.IO
Imports SM64Lib.Script

Namespace Global.SM64Lib.Script

    <Serializable>
    Public MustInherit Class BaseCommand(Of eTypes)
        Inherits Data.BinaryStreamData
        Implements ICommand

        Private dirtyHash As Integer = 0

        Public Property RomAddress As Integer = 0 Implements ICommand.RomAddress
        Public Property BankAddress As Integer = 0 Implements ICommand.BankAddress
        Public MustOverride Property CommandType As eTypes

        Public Sub New(bytes As String, Optional enabledHex As Boolean = True)
            Me.New
            Dim bts As New List(Of Byte)
            For Each b As String In bytes.Split(" ")
                If enabledHex Then b = Convert.ToInt32(b, 16)
                bts.Add(b)
            Next
            NewBytes(bts.ToArray)
        End Sub

        Public Sub New()
            MyBase.New(New MemoryStream)
        End Sub

        Public Sub New(bytes() As Byte)
            Me.New
            NewBytes(bytes)
        End Sub

        Private Sub NewBytes(bytes() As Byte)
            SetLength(bytes.Count)
            For Each b As Byte In bytes
                WriteByte(b)
            Next
            Position = 0
        End Sub

        Public Function ToArray() As Byte()
            Return CType(BaseStream, MemoryStream).ToArray
        End Function

        Public Overrides Function ToString() As String
            Return $"{RomAddress.ToString("X")} ({BankAddress.ToString("X")}): {CommandByteArrayToString(ToArray)}"
        End Function

        Public Shared Operator =(cmd1 As BaseCommand(Of eTypes), cmd2 As BaseCommand(Of eTypes)) As Boolean
            If cmd1.Length <> cmd2.Length Then
                Return False
            End If

            Dim buf1 As Byte() = CType(cmd1.BaseStream, MemoryStream).GetBuffer
            Dim buf2 As Byte() = CType(cmd2.BaseStream, MemoryStream).GetBuffer

            For i As Integer = 0 To cmd1.Length - 1
                If buf1(i) <> buf2(i) Then
                    Return False
                End If
            Next

            Return True
        End Operator

        Public Shared Operator <>(cmd1 As BaseCommand(Of eTypes), cmd2 As BaseCommand(Of eTypes)) As Boolean
            Return Not (cmd1 = cmd2)
        End Operator

        Public Sub RefreshDirty()
            dirtyHash = CType(BaseStream, MemoryStream).GetHashCode()
        End Sub

        Public ReadOnly Property IsDirty As Boolean Implements ICommand.IsDirty
            Get
                Return CType(BaseStream, MemoryStream).GetHashCode() <> dirtyHash
            End Get
        End Property

    End Class

End Namespace
