Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Geolayout.Script

    Public Class GeolayoutCommand
        Inherits BaseCommand(Of GeolayoutCommandTypes)

        Public Sub New(bytes() As Byte)
            MyBase.New(bytes)
        End Sub
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(bytes As String, Optional enabledHex As Boolean = True)
            MyBase.New(bytes, enabledHex)
        End Sub

        Public Overrides Property CommandType As GeolayoutCommandTypes
            Get
                Position = 0
                Dim t As GeolayoutCommandTypes = ReadByte()
                Position = 0
                Return t
            End Get
            Set(value As GeolayoutCommandTypes)
                Position = 0
                WriteByte(value)
                Position = 0
            End Set
        End Property

    End Class

End Namespace