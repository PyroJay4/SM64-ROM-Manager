Imports System.IO

Namespace Global.SM64Lib.Music

    Public Class MusicSequence

        Public Property Name As String = ""
        Public BinaryData() As Byte = {}
        Public InstrumentSets As New InstrumentSetList

        Public ReadOnly Property Lenght As Integer
            Get
                Return BinaryData?.Length
            End Get
        End Property

        Public Sub ReadData(s As Stream, RomAddress As Integer, Length As Integer)
            ReDim BinaryData(Length - 1)
            s.Position = RomAddress
            s.Read(BinaryData, 0, Length)
        End Sub

        Public Sub WriteData(s As Stream, RomAddress As Integer)
            s.Position = RomAddress
            s.Write(BinaryData, 0, BinaryData.Length)

            Do While s.Position Mod &H10 <> 0
                s.WriteByte(&HFF)
            Loop
        End Sub

    End Class

End Namespace
