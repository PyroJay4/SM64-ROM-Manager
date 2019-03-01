Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Global.SM64Lib.Geolayout.Script

    Public Class GeolayoutCommandCollection
        Inherits BaseCommandCollection(Of GeolayoutCommand, GeolayoutCommandTypes)

        Public Function IndexOfFirst(cmdType As GeolayoutCommandTypes) As Integer
            For index As Integer = 0 To Me.Count - 1
                If Me(index).CommandType = cmdType Then Return index
            Next
            Return -1
        End Function

    End Class

End Namespace