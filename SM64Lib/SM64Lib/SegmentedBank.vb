Imports System.IO

Namespace Global.SM64Lib

    Public Class SegmentedBank

        Public Property RomStart As Integer = 0
        Public Property BankID As Byte = 0
        Private _RomEnd As Integer = 0
        Public ReadOnly Property IsMIO0 As Boolean = False
        Public Property Data As MemoryStream = Nothing

        Public Property RomEnd As Integer
            Get
                If _Data Is Nothing Then
                    Return _RomEnd
                Else
                    Return _RomStart + _Data.Length
                End If
            End Get
            Set(value As Integer)
                If _Data Is Nothing Then
                    _RomEnd = value
                Else
                    Dim newLength As Long = value - _RomStart
                    If _Data.Length <> newLength Then
                        _Data.SetLength(newLength)
                    End If
                End If
            End Set
        End Property

        Public Property BankAddress As Integer
            Get
                Return CUInt(BankID) << 24
            End Get
            Set(value As Integer)
                BankID = (value >> 24) And &HFF
            End Set
        End Property

        Public Property Length As Integer
            Get
                If _Data Is Nothing Then
                    Return RomEnd - RomStart
                Else
                    Return _Data.Length
                End If
            End Get
            Set(value As Integer)
                If _Data Is Nothing Then
                    RomEnd = RomStart + value
                Else
                    _Data.SetLength(value)
                End If
            End Set
        End Property

        Public Sub New()
        End Sub
        Public Sub New(bankID As Byte)
            Me.BankID = bankID
        End Sub
        Public Sub New(bankID As Byte, length As UInteger)
            Me.BankID = bankID
            Me.Length = length
        End Sub
        Public Sub New(bankID As Byte, data As MemoryStream)
            Me.BankID = bankID
            Me.Data = data
        End Sub
        Public Sub New(data As MemoryStream)
            Me.Data = data
        End Sub

        Public Sub MakeAsMIO0()
            _IsMIO0 = True
        End Sub

        Public Function SegToRomAddr(SegmentedAddress As Integer) As Integer
            Return SegmentedAddress - Me.BankAddress + Me.RomStart
        End Function
        Public Function RomToSegAddr(RomAddress As Integer) As Integer
            Return RomAddress - Me.RomStart + Me.BankAddress
        End Function
        Public Function BankOffsetFromSegAddr(segPointer As Integer) As Integer
            Return segPointer - Me.BankAddress
        End Function
        Public Function BankOffsetFromRomAddr(RomAddr As Integer) As Integer
            Return RomAddr - Me.RomStart
        End Function

        Public Function ReadData(rommgr As RomManager) As MemoryStream
            Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
            Dim ms As MemoryStream

            ms = ReadDataIfNull(fs)
            fs.Close()

            _Data = ms
            Return ms
        End Function
        Public Function ReadDataIfNull(s As Stream) As MemoryStream
            If _Data Is Nothing Then
                ReadData(s)
            End If
            Return _Data
        End Function
        Public Function ReadDataIfNull(fileName As String) As MemoryStream
            If _Data Is Nothing Then
                Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
                ReadData(fs)
                fs.Close()
            End If
            Return _Data
        End Function
        Public Function ReadDataIfNull(rommgr As RomManager) As MemoryStream
            Return ReadDataIfNull(rommgr.RomFile)
        End Function
        Public Function ReadData(s As Stream) As MemoryStream
            Dim ms As New MemoryStream

            If RomStart > 0 AndAlso Length > 0 AndAlso s.Length >= RomEnd Then
                Dim data As Byte() = New Byte(Length - 1) {}
                s.Position = RomStart
                s.Read(data, 0, data.Length)

                If IsDataMIO0(data) Then
                    data = LIBMIO0.MIO0.mio0_decode(data)
                End If

                ms.Write(data, 0, data.Length)

                ms.Position = 0
            End If

            If _Data IsNot Nothing Then _Data.Close()
            _Data = ms

            Return ms
        End Function

        Private Function IsDataMIO0(arr As Byte()) As Boolean
            Dim check As Integer =
                (CInt(arr(0)) << 24) Or
                (CInt(arr(1)) << 16) Or
                (CInt(arr(2)) << 8) Or
                arr(3)
            Return check = &H4D494F30
        End Function

        Public Sub WriteData(rommgr As RomManager)
            If _Data IsNot Nothing Then
                Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.ReadWrite)
                WriteData(fs)
                fs.Close()
            End If
        End Sub
        Public Sub WriteData(s As Stream)
            If _Data IsNot Nothing Then
                _Data.Position = 0
                s.Position = RomStart
                For i As Integer = 1 To _Data.Length
                    s.WriteByte(_Data.ReadByte)
                Next
            End If
        End Sub

    End Class

End Namespace
