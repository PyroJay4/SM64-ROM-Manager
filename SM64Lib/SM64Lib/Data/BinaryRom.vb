Imports System.IO

Namespace Global.SM64Lib.Data

    Public Class BinaryRom
        Inherits BinaryData

        Public ReadOnly Property RomAccess As FileAccess = FileAccess.Read

        Public Sub New(rommgr As RomManager, romAccess As FileAccess)
            SetRomManager(rommgr)
            Me.RomAccess = romAccess
        End Sub

        Protected Overrides Function GetBaseStream() As Stream
            Return RomManager.GetStream(RomAccess)
        End Function

    End Class

End Namespace
