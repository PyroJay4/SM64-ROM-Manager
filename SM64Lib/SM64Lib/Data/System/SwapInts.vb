Namespace Data.System

    Friend Module SwapInts

        Function SwapInt16(ByVal value As Int16) As Int16
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToInt16(bytes, 0)
        End Function

        Function SwapUInt16(ByVal value As UInt16) As UInt16
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToUInt16(bytes, 0)
        End Function

        Function SwapInt32(ByVal value As Int32) As Int32
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToInt32(bytes, 0)
        End Function

        Function SwapUInt32(ByVal value As UInt32) As UInt32
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToUInt32(bytes, 0)
        End Function

        Function SwapInt64(ByVal value As Int64) As Int64
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToInt64(bytes, 0)
        End Function

        Function SwapUInt64(ByVal value As UInt64) As UInt64
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToUInt64(bytes, 0)
        End Function

        Function SwapSingle(value As Single) As Single
            Dim bytes As Byte() = BitConverter.GetBytes(value)
            Array.Reverse(bytes)
            Return BitConverter.ToSingle(bytes, 0)
        End Function
    End Module

End Namespace
