Imports System.IO
Imports SM64Lib.Script

Namespace Global.SM64Lib.Model.Fast3D.DisplayLists.Script

    Public Class DisplayListCommand
        Inherits MemoryStream
        Implements ICommand
        Public Property CommandType As CommandTypes = CommandTypes.F3D_EndDisplaylist

        Public Property RomAddress As Integer = 0 Implements ICommand.RomAddress
        Public Property BankAddress As Integer = 0 Implements ICommand.BankAddress

        Public ReadOnly Property IsDirty As Boolean Implements ICommand.IsDirty
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public Sub New(CommandType As Byte)
            Me.CommandType = Command()
            SetLength(&H8)
            Position = 0
            WriteByte(CommandType)
            Position = 0
        End Sub

        Public Sub New(CommandType As String)
            Me.New(Convert.ToByte(CommandType, 16))
        End Sub

        Public Sub New(bytes() As Byte)
            CommandType = bytes(0)
            SetLength(bytes.Count)
            For Each b In bytes
                WriteByte(b)
            Next
            Position = 0
        End Sub

        Public Overrides Function ToString() As String
            ToString = $"{RomAddress.ToString("X")}:"
            For Each b As Byte In Me.ToArray
                ToString &= " " & b.ToString("X2")
            Next
        End Function

    End Class

End Namespace