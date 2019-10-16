Namespace Data.System

    Public Class Bits
        Shared Function ByteToBitArray(b As Byte) As Byte()
            Dim bitarray As New BitArray({b})
            Dim temp(0 To bitarray.Length - 1) As Byte
            For i As Integer = 0 To bitarray.Length - 1
                temp(i) = bitarray(i)
            Next
            Dim tindex As Integer = 0
            Dim temp2(0 To temp.Count - 1) As Byte
            For i As Integer = temp.Length - 1 To 0 Step -1
                temp2(tindex) = temp(i)
                tindex += 1
            Next
            Return temp2
        End Function
        Shared Function ByteToBoolArray(b As Byte) As Boolean()
            Dim bitarray As New BitArray({b})
            Dim temp(0 To bitarray.Length - 1) As Boolean
            For i As Integer = 0 To bitarray.Length - 1
                temp(i) = Convert.ToBoolean(bitarray(i))
            Next
            Dim tindex As Integer = 0
            Dim temp2(0 To temp.Count - 1) As Boolean
            For i As Integer = temp.Length - 1 To 0 Step -1
                temp2(tindex) = temp(i)
                tindex += 1
            Next
            Return temp2
        End Function

        Shared Function ArrayToByte(ba() As Byte) As Byte
            'ODER: BitArray.ToByte()

            Dim endval As Byte = 0
            Dim index As Integer = ba.Count - 1
            For Each bit In ba
                endval += bit * (2 ^ index)
                index -= 1
            Next
            Return endval
        End Function
        Shared Function ArrayToByte(ba() As Boolean) As Byte
            'ODER: BitArray.ToByte()

            Dim endval As Byte = 0
            Dim index As Integer = ba.Count - 1
            For Each bit In ba
                endval += If(bit, 1, 0) * (2 ^ index)
                index -= 1
            Next
            Return endval
        End Function

        Shared Function SetInByte(b As Byte, index As Integer, value As Byte) As Byte
            Dim temp = ByteToBitArray(b)
            temp(index) = value
            Return ArrayToByte(temp)
        End Function
        Shared Function SetInByte(b As Byte, index As Integer, value As Boolean) As Byte
            Dim temp = ByteToBoolArray(b)
            temp(index) = value
            Return ArrayToByte(temp)
        End Function

        Shared Function GetBitOfByte(b As Byte, index As Integer) As Byte
            Return ByteToBitArray(b)(index)
        End Function
        Shared Function GetBoolOfByte(b As Byte, index As Integer) As Boolean
            Return ByteToBoolArray(b)(index)
        End Function
    End Class

End Namespace
