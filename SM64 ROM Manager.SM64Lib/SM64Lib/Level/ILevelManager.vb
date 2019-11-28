Imports SM64_ROM_Manager.SM64Lib.Data
Imports SM64_ROM_Manager.SM64Lib.Data
Imports SM64_ROM_Manager.SM64Lib.Levels

Namespace Levels

    Public Interface ILevelManager

        Sub LoadLevel(lvl As Level, rommgr As RomManager, LevelID As UShort, segAddress As UInteger)
        Function SaveLevel(lvl As Level, rommgr As RomManager, output As BinaryData, ByRef curOff As UInteger) As LevelSaveResult

    End Interface

End Namespace
