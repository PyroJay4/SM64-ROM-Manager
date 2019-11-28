Imports System.IO
Imports SM64Lib.Model

Namespace Levels

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

End Namespace
