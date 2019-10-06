Imports System.IO

Namespace Global.SM64Lib.Data

    Public MustInherit Class BinaryData

        Public Delegate Sub AnyBinaryDataEventHandler(data As BinaryData)

        Public Shared Event AnyBinaryDataOpened As AnyBinaryDataEventHandler
        Public Shared Event AnyBinaryDataClosing As AnyBinaryDataEventHandler
        Public Shared Event AnyBinaryDataClosed As AnyBinaryDataEventHandler
        Public Shared Event AnyBinaryDataDisposed()

        Private _BaseStream As Stream = Nothing
        Private _writer As BinaryWriter = Nothing
        Private _reader As BinaryReader = Nothing

        Public ReadOnly Property RomManager As RomManager

        Protected MustOverride Function GetBaseStream() As Stream

        Protected ReadOnly Property Writer As BinaryWriter
            Get
                If _writer Is Nothing Then
                    _writer = New BinaryWriter(BaseStream)
                End If
                Return _writer
            End Get
        End Property

        Protected ReadOnly Property Reader As BinaryReader
            Get
                If _reader Is Nothing Then
                    _reader = New BinaryReader(BaseStream)
                End If
                Return _reader
            End Get
        End Property

        Public Property Position As Long
            Get
                Return BaseStream.Position
            End Get
            Set
                BaseStream.Position = Value
            End Set
        End Property

        Public ReadOnly Property Length As Long
            Get
                Return BaseStream.Length
            End Get
        End Property

        Public ReadOnly Property BaseStream As Stream
            Get
                If _BaseStream Is Nothing Then
                    _BaseStream = GetBaseStream()
                    RaiseEvent AnyBinaryDataOpened(Me)
                End If
                Return _BaseStream
            End Get
        End Property

        Protected Overrides Sub Finalize()
            RaiseEvent AnyBinaryDataDisposed()
        End Sub

        Protected Sub SetRomManager(rommgr As RomManager)
            _RomManager = rommgr
        End Sub

        Public Sub Write(value As SByte)
            Writer.Write(value)
        End Sub

        Public Sub Write(value As Byte)
            Writer.Write(value)
        End Sub

        Public Sub WriteByte(value As Byte)
            Write(value)
        End Sub

        Public Sub Write(value As Int16)
            Writer.Write(SwapInts.SwapInt16(value))
        End Sub

        Public Sub Write(value As UInt16)
            Writer.Write(SwapInts.SwapUInt16(value))
        End Sub

        Public Sub Write(value As Int32)
            Writer.Write(SwapInts.SwapInt32(value))
        End Sub

        Public Sub Write(value As UInt32)
            Writer.Write(SwapInts.SwapUInt32(value))
        End Sub

        Public Sub Write(value As Int64)
            Writer.Write(SwapInts.SwapInt64(value))
        End Sub

        Public Sub Write(value As UInt64)
            Writer.Write(SwapInts.SwapUInt64(value))
        End Sub

        Public Sub Write(value As Single)
            Writer.Write(SwapInts.SwapSingle(value))
        End Sub

        Public Sub Write(value As String)
            Writer.Write(value)
        End Sub

        Public Sub Write(buffer As Byte())
            Write(buffer, 0, buffer.Length)
        End Sub

        Public Sub Write(buffer As Byte(), index As Integer, count As Integer)
            Writer.Write(buffer, index, count)
        End Sub

        Public Function ReadByte() As Byte
            Return Reader.ReadByte
        End Function

        Public Function ReadSByte() As SByte
            Return Reader.ReadSByte
        End Function

        Public Function ReadInt16() As Int16
            Return SwapInts.SwapInt16(Reader.ReadInt16)
        End Function

        Public Function ReadUInt16() As UInt16
            Return SwapInts.SwapUInt16(Reader.ReadUInt16)
        End Function

        Public Function ReadInt32() As Int32
            Return SwapInts.SwapInt32(Reader.ReadInt32)
        End Function

        Public Function ReadUInt32() As UInt32
            Return SwapInts.SwapUInt32(Reader.ReadUInt32)
        End Function

        Public Function ReadInt64() As Int64
            Return SwapInts.SwapInt64(Reader.ReadInt64)
        End Function

        Public Function ReadUInt64() As UInt64
            Return SwapInts.SwapUInt64(Reader.ReadUInt64)
        End Function

        Public Function ReadSingle() As Single
            Return SwapInts.SwapSingle(Reader.ReadSingle)
        End Function

        Public Function ReadString() As String
            Return Reader.ReadString
        End Function

        Public Sub Read(buffer As Byte())
            Read(buffer, 0, buffer.Length)
        End Sub

        Public Sub Read(buffer As Byte(), index As Integer, count As Integer)
            Reader.Read(buffer, index, count)
        End Sub

        Public Function Read(count As Integer) As Byte()
            Dim buf As Byte() = New Byte(count - 1) {}
            Read(buf, 0, count)
            Return buf
        End Function

        Public Sub Close()
            RaiseEvent AnyBinaryDataClosing(Me)
            BaseStream.Close()
            RaiseEvent AnyBinaryDataClosed(Me)
        End Sub

        Public ReadOnly Property CanRead As Boolean
            Get
                Return BaseStream.CanRead
            End Get
        End Property

        Public ReadOnly Property CanWrite As Boolean
            Get
                Return BaseStream.CanWrite
            End Get
        End Property

        Public Sub SetLength(length As Long)
            BaseStream.SetLength(length)
        End Sub

    End Class

End Namespace
