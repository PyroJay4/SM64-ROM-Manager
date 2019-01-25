Imports System.IO
Imports SM64Lib.Model

Namespace Global.SM64Lib.Levels

    Public Class SpecialBoxList
        Inherits List(Of SpecialBox)

        Public Sub SortByHeight()
            Dim boxes As SpecialBox() = OrderByDescending(Function(n) n.Y).ToArray
            Clear()
            AddRange(boxes)
        End Sub

        Public Shared Function ReadTable(Romfile As String, Type As SpecialBoxType, Levelscriptstart As Integer, TabelStart As Integer) As SpecialBox()
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.Read)
            Dim temp = ReadTable(fs, Type, Levelscriptstart, TabelStart)
            fs.Close()
            Return temp
        End Function
        Public Shared Function ReadTable(ByRef s As Stream, Type As SpecialBoxType, Levelscriptstart As Integer, TabelStart As Integer) As SpecialBox()
            Dim br As New BinaryReader(s)
            Dim boxlist As New List(Of SpecialBox)
            s.Position = TabelStart

            If SwapInts.SwapInt32(br.ReadInt32) = &H1010101 Then
                Return {}
            Else
                s.Position -= &H4
            End If

            Do Until SwapInts.SwapUInt16(br.ReadUInt16) = &HFFFF
                s.Position += &H2

                Dim tbox As New SpecialBox
                tbox.Type = Type

                Dim lastpos As Integer = s.Position + &H4
                s.Position = SwapInts.SwapInt32(br.ReadInt32) - &H19000000 + Levelscriptstart

                If Type = SpecialBoxType.Water Then
                    tbox.InvisibleWater = (SwapInts.SwapInt32(br.ReadInt32) = &H0)
                Else
                    s.Position += &H4
                End If

                s.Position += &H2
                tbox.Scale = SwapInts.SwapInt16(br.ReadInt16)
                tbox.X1 = SwapInts.SwapInt16(br.ReadInt16)
                tbox.Z1 = SwapInts.SwapInt16(br.ReadInt16)
                tbox.X2 = SwapInts.SwapInt16(br.ReadInt16)
                s.Position += &H4
                tbox.Z2 = SwapInts.SwapInt16(br.ReadInt16)
                s.Position += &H7
                tbox.Alpha = br.ReadByte
                tbox.WaterType = SwapInts.SwapInt32(br.ReadInt32)

                s.Position = lastpos
                boxlist.Add(tbox)
            Loop

            Return boxlist.ToArray
        End Function
    End Class

End Namespace