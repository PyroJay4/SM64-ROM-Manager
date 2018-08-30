Imports System.IO
Imports SM64Lib.Model

Namespace Global.SM64Lib.Levels

    Public Class SpecialBox

        Public Property Type As SpecialBoxType = SpecialBoxType.Water
        Public Property X1 As Int16 = 8192
        Public Property Z1 As Int16 = 8192
        Public Property X2 As Int16 = -8192
        Public Property Z2 As Int16 = -8192
        Public Property Y As Int16 = 0
        Public Property Scale As Int16 = 16
        Public Property InvisibleWater As Boolean = False
        Public Property WaterType As WaterType = WaterType.Default
        Public Property Alpha As Byte = 78

        Public Function ToArrayBoxData() As Byte()
            Dim ms As New MemoryStream(&H20)
            Dim bw As New BinaryWriter(ms)
            ms.Position = 0

            'Stand: SM64 Editor v2.0.7

            bw.Write(SwapInts.SwapInt32(If(InvisibleWater, &H0, &H10000))) 'Type = SpecialBoxType.ToxicHaze OrElse
            bw.Write(SwapInts.SwapInt16(&HF))
            bw.Write(SwapInts.SwapInt16(Scale))

            bw.Write(SwapInts.SwapInt16(X1))
            bw.Write(SwapInts.SwapInt16(Z1))
            bw.Write(SwapInts.SwapInt16(X2))
            bw.Write(SwapInts.SwapInt16(Z1))
            bw.Write(SwapInts.SwapInt16(X2))
            bw.Write(SwapInts.SwapInt16(Z2))
            bw.Write(SwapInts.SwapInt16(X1))
            bw.Write(SwapInts.SwapInt16(Z2))

            If Type = SpecialBoxType.ToxicHaze Then
                bw.Write(SwapInts.SwapInt32(Alpha)) '&HB4
                bw.Write(SwapInts.SwapInt32(&H10000))
            Else
                bw.Write(SwapInts.SwapInt32(&H10000 Or Alpha))
                bw.Write(SwapInts.SwapInt32(WaterType))
            End If

            ms.Close()
            Return ms.GetBuffer
        End Function
    End Class
    Public Class SpecialBoxList
        Inherits List(Of SpecialBox)

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
