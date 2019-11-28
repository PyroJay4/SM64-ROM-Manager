Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands

Namespace Levels

    Public Class WarpTools

        Public Shared Function GetWarpsCountInArea(cArea As LevelArea) As Integer
            Dim count As Integer = 0

            count += cArea.Warps.Where(Function(n) {LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.ConnectedWarp}.Contains(n.CommandType)).Count
            count += cArea.WarpsForGame.Concat(cArea.Warps).Count

            Return count
        End Function

        Public Shared Function GetWarpsCountInLevel(cLevel As Level) As Integer
            Dim count As Integer = 0

            For Each a As LevelArea In cLevel.Areas
                count += GetWarpsCountInArea(a)
            Next

            Return count
        End Function

        Public Shared Function GetNextUnusedWarpID(cArea As LevelArea) As Byte
            Dim forbitten As New List(Of Byte)

            For Each cmd As LevelscriptCommand In cArea.WarpsForGame.Concat(cArea.Warps)
                forbitten.Add(clWarp.GetWarpID(cmd))
            Next

            For i As Integer = Byte.MinValue To Byte.MaxValue
                If Not forbitten.Contains(i) Then Return i
            Next

            Return Byte.MaxValue
        End Function

    End Class

End Namespace
