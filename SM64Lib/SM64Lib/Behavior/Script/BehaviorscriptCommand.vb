Namespace Behavior.Script

    Public Class BehaviorscriptCommand
        Inherits SM64Lib.Script.BaseCommand(Of Byte)

        Public Overrides Property CommandType As Byte
            Get
                Position = 0
                Return ReadByte()
            End Get
            Set(value As Byte)
                Position = 0
                WriteByte(value)
            End Set
        End Property
    End Class

End Namespace
