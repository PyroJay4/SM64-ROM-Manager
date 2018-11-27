Imports SM64Lib.Levels.Script

Namespace Global.SM64Lib.Levels.Script

    Public Interface IManagedLevelscriptCommand

        ReadOnly Property Command As LevelscriptCommand
        Sub LoadProperties()
        Sub SaveProperties()
        Sub SaveProperties(Command As LevelscriptCommand)

    End Interface

End Namespace
