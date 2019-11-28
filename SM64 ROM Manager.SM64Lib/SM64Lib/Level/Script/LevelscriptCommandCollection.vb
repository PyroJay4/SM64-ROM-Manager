Imports System.IO
Imports System.Numerics
Imports SM64_ROM_Manager.SM64Lib.Script

Namespace Levels.Script

    Public Class LevelscriptCommandCollection
        Inherits BaseCommandCollection(Of LevelscriptCommand, LevelscriptCommandTypes)

        Public Function IndexOfFirst(cmdType As LevelscriptCommandTypes) As Integer
            For index As Integer = 0 To Me.Count - 1
                If Me(index).CommandType = cmdType Then Return index
            Next
            Return -1
        End Function

    End Class

End Namespace
