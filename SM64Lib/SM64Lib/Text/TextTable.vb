Imports System.IO
Imports System.Windows.Forms
Imports SM64Lib.Text.Profiles

Namespace Global.SM64Lib.Text

    Public Class TextTable
        Inherits List(Of TextItem)

        Public Property NeedToSave As Boolean = False
        Public ReadOnly Property TextSectionInfo As TextSectionInfo

        Public Sub New(info As TextSectionInfo)
            TextSectionInfo = info
        End Sub

        Public ReadOnly Property BytesCount As Integer
            Get
                Dim count As Integer = 0
                For Each item As TextItem In Me
                    count += item.DataLenght
                Next
                Return count
            End Get
        End Property

        Public Sub FromStream(s As Stream)
            Dim br As New BinaryReader(s)
            Dim BankRamStart, BankRomStart As UInteger

            BankRamStart = TextSectionInfo.Segmented.BankAddress
            BankRomStart = TextSectionInfo.Segmented.BankStartRom

            If TextSectionInfo.TableType = TextTableType.Dialogs Then
                s.Position = TextSectionInfo.Data.TableRomOffset

                For i As Integer = 1 To TextSectionInfo.Data.TableMaxItems
                    Dim entryPointer As Integer = SwapInts.SwapInt32(br.ReadInt32) - BankRamStart + BankRomStart
                    Dim lastPos As Integer = s.Position
                    s.Position = entryPointer

                    s.Position = entryPointer + 12

                    Dim newItem As TextItem = GetTextItem(s, SwapInts.SwapInt32(br.ReadInt32) - BankRamStart + BankRomStart, True)

                    s.Position = entryPointer + &H3
                    newItem.UnknownValue = br.ReadByte
                    newItem.LinesPerSite = br.ReadByte

                    s.Position += 1
                    newItem.VerticalPosition = SwapInts.SwapInt16(br.ReadInt16)
                    newItem.HorizontalPosition = SwapInts.SwapInt16(br.ReadInt16)

                    s.Position += 6

                    Me.Add(newItem)
                    s.Position = lastPos
                Next

            Else
                s.Position = TextSectionInfo.Data.TableRomOffset
                For i As Integer = 1 To TextSectionInfo.Data.TableMaxItems
                    Dim addrInROM As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                    Me.Add(GetTextItem(s, addrInROM - BankRamStart + BankRomStart))
                Next

            End If
        End Sub

        Private Function GetTextItem(s As Stream, RomAddress As Integer, Optional EnableDialogParameters As Boolean = False) As TextItem
            Dim br As New BinaryReader(s)
            Dim lastPos As Integer = 0
            Dim tempByte As Byte = 0
            Dim byteBuffer As New List(Of Byte)

            lastPos = s.Position
            s.Position = RomAddress

            Do
                tempByte = br.ReadByte
                byteBuffer.Add(tempByte)
                If tempByte = &HFF Then Exit Do
            Loop

            s.Position = lastPos
            Dim newItem As TextItem = New TextItem(byteBuffer.ToArray, EnableDialogParameters)
            byteBuffer.Clear()

            Return newItem
        End Function

        Public Sub ToStream(s As Stream)
            Dim bw As New BinaryWriter(s)
            Dim DataRomOffset, lastTableOffset, lastTable2Offset As Integer, BankRomStart, BankRamStart As UInteger

            lastTableOffset = TextSectionInfo.Data.TableRomOffset
            lastTable2Offset = TextSectionInfo.Data.TableRomOffset2
            DataRomOffset = TextSectionInfo.Data.DataRomOffset
            BankRamStart = TextSectionInfo.Segmented.BankAddress
            BankRomStart = TextSectionInfo.Segmented.BankStartRom

            If TextSectionInfo.TableType = TextTableType.Dialogs Then
                For Each textitem As TextItem In Me
                    'Table 1
                    s.Position = lastTableOffset
                    bw.Write(SwapInts.SwapInt32(lastTable2Offset - BankRomStart + BankRamStart))
                    lastTableOffset += 4

                    'Table 2 (including Dialog Params)
                    s.Position = lastTable2Offset
                    bw.Write(SwapInts.SwapInt16(0))
                    s.WriteByte(0)
                    s.WriteByte(textitem.UnknownValue)
                    s.WriteByte(textitem.LinesPerSite)
                    s.WriteByte(0)
                    bw.Write(SwapInts.SwapInt16(textitem.VerticalPosition))
                    bw.Write(SwapInts.SwapInt16(textitem.HorizontalPosition))
                    bw.Write(SwapInts.SwapInt16(0))
                    bw.Write(SwapInts.SwapUInt32(DataRomOffset - BankRomStart + BankRamStart))
                    lastTable2Offset += &H10

                    'Text Data
                    s.Position = DataRomOffset
                    WriteTextItem(s, DataRomOffset, textitem.ToByteArray)
                    DataRomOffset += textitem.DataLenght
                Next
            Else
                For Each textitem As TextItem In Me
                    'Table
                    s.Position = lastTableOffset
                    bw.Write(SwapInts.SwapUInt32(DataRomOffset - BankRomStart + BankRamStart))
                    lastTableOffset += 4

                    'Text Data
                    s.Position = DataRomOffset
                    WriteTextItem(s, DataRomOffset, textitem.ToByteArray)
                    DataRomOffset += textitem.DataLenght
                Next
            End If
        End Sub

        Private Sub WriteTextItem(s As Stream, RomAddress As Integer, Bytes() As Byte)
            s.Position = RomAddress
            For Each b In Bytes
                s.WriteByte(b)
            Next
        End Sub
    End Class

End Namespace