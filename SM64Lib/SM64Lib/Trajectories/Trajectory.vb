Imports System.IO
Imports System.Numerics

Namespace Global.SM64Lib.Trajectorys

    Public Class Trajectory

        Public ReadOnly Property Points As New List(Of Vector3)
        Public Property NeedToSave As Boolean = False
        Public Property Name As TrajectoryName = TrajectoryName.None

        Public Sub Write(rom As Stream, startPos As UInteger)
            Dim bw As New BinaryWriter(rom)

            'Set position
            rom.Position = startPos

            'Write xyz
            For i As Int16 = 0 To Points.Count
                Dim point As Vector3 = Points(i)
                bw.Write(SwapInts.SwapInt16(i))
                bw.Write(SwapInts.SwapInt16(point.X))
                bw.Write(SwapInts.SwapInt16(point.Y))
                bw.Write(SwapInts.SwapInt16(point.Z))
            Next
        End Sub

        Public Sub Read(rom As Stream, startPos As UInteger)
            Dim br As New BinaryReader(rom)
            Dim ende As Boolean = False

            'Set position
            rom.Position = startPos

            'Clear list
            Points.Clear()

            'Read xyz
            Do Until ende
                If SwapInts.SwapInt64(br.ReadInt64) <> &HFFFFFFFFFFFFFFFF Then
                    rom.Position -= 6
                    Dim point As New Vector3
                    point.X = SwapInts.SwapInt16(br.ReadInt16)
                    point.Y = SwapInts.SwapInt16(br.ReadInt16)
                    point.Z = SwapInts.SwapInt16(br.ReadInt16)
                    Points.Add(point)
                Else
                    ende = True
                End If
            Loop
        End Sub

    End Class

End Namespace
