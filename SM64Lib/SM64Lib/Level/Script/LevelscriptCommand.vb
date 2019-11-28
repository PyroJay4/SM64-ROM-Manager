Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Levels.Script

    <Serializable>
    Public Class LevelscriptCommand
        Inherits BaseCommand(Of LevelscriptCommandTypes)

        Public Sub New(bytes() As Byte)
            MyBase.New(bytes)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(bytes As String, Optional enabledHex As Boolean = True)
            MyBase.New(bytes, enabledHex)
        End Sub

        Public Overrides Property CommandType As LevelscriptCommandTypes
            Get
                Position = 0
                Dim t As LevelscriptCommandTypes = ReadByte()
                Position = 0
                Return t
            End Get
            Set(value As LevelscriptCommandTypes)
                Position = 0
                WriteByte(value)
                Position = 0
            End Set
        End Property

    End Class

End Namespace
