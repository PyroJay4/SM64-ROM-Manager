Imports System.IO
Imports SM64Lib.Data

Namespace Global.SM64Lib.Music

    Public Class MusicSequence

        Private _InstrumentSets As New InstrumentSetList

        Public Property BinaryData As Byte() = {}
        Public Property Name As String = ""

        Public Property InstrumentSets As InstrumentSetList
            Get
                Return _InstrumentSets
            End Get
            Friend Set(value As InstrumentSetList)
                _InstrumentSets = value
            End Set
        End Property

        Public ReadOnly Property Lenght As Integer
            Get
                Return BinaryData?.Length
            End Get
        End Property

        Public Sub ReadData(s As BinaryData, RomAddress As Integer, Length As Integer)
            ReDim BinaryData(Length - 1)
            s.Position = RomAddress
            s.Read(BinaryData, 0, Length)
        End Sub

        Public Sub WriteData(s As BinaryData, RomAddress As Integer)
            s.Position = RomAddress
            s.Write(BinaryData, 0, BinaryData.Length)

            Do While s.Position Mod &H10 <> 0
                s.WriteByte(&HFF)
            Loop
        End Sub

    End Class

End Namespace
