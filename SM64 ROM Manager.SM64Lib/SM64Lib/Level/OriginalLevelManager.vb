Imports SM64_ROM_Manager.SM64Lib.Data

Namespace Levels

    Public Class OriginalLevelManager
        Implements ILevelManager

        Public Sub LoadLevel(lvl As Level, rommgr As RomManager, LevelID As UShort, segAddress As UInteger) Implements ILevelManager.LoadLevel
            Throw New NotImplementedException()
        End Sub

        Public Function SaveLevel(lvl As Level, rommgr As RomManager, output As BinaryData, ByRef curOff As UInteger) As LevelSaveResult Implements ILevelManager.SaveLevel
            Throw New NotImplementedException()
        End Function

    End Class

End Namespace
