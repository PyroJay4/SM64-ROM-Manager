Imports SM64Lib.Level.Script

Namespace Global.SM64Lib.Level.Script

    Public Interface IManagedLevelscriptCommand

        ReadOnly Property Command As LevelscriptCommand
        Sub LoadpProperties()
        Sub SaveProperties()
        Sub SaveProperties(Command As LevelscriptCommand)

    End Interface

End Namespace
