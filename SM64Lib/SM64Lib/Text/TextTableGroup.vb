Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.Text.Profiles

Namespace Global.SM64Lib.Text

    Public Class TextTableGroup
        Inherits TextGroup

        Default Public Overloads ReadOnly Property Item(index As Integer) As TextTableItem
            Get
                Return MyBase.Item(index)
            End Get
        End Property

        Public Overloads ReadOnly Property TextGroupInfo As TextTableGroupInfo
            Get
                Return MyBase.TextGroupInfo
            End Get
        End Property

        Public Sub New(groupInfo As TextTableGroupInfo)
            MyBase.New(groupInfo)
        End Sub

        Public Overrides Sub Read(data As BinaryData)
            Dim BankRamStart, BankRomStart As UInteger

            BankRamStart = TextGroupInfo.Segmented.BankAddress
            BankRomStart = TextGroupInfo.Segmented.BankStartRom

            If TextGroupInfo.TableType = TextTableType.Dialogs Then
                data.Position = TextGroupInfo.Data.TableRomOffset

                For i As Integer = 1 To TextGroupInfo.Data.TableMaxItems
                    Dim entryPointer As Integer = data.ReadInt32 - BankRamStart + BankRomStart
                    Dim lastPos As Integer = data.Position
                    data.Position = entryPointer

                    data.Position = entryPointer + 12

                    Dim addr As Integer = data.ReadInt32
                    If addr <> 0 Then
                        Dim bytes As Byte() = GetTextData(data, addr - BankRamStart + BankRomStart, True)
                        Dim newItem As New TextTableDialogItem(bytes, TextGroupInfo)

                        data.Position = entryPointer + &H3
                        newItem.UnknownValue = data.ReadByte
                        newItem.LinesPerSite = data.ReadByte

                        data.Position += 1
                        newItem.VerticalPosition = data.ReadInt16
                        newItem.HorizontalPosition = data.ReadInt16

                        data.Position += 6

                        Add(newItem)
                        data.Position = lastPos
                    End If
                Next

            Else
                data.Position = TextGroupInfo.Data.TableRomOffset
                For i As Integer = 1 To TextGroupInfo.Data.TableMaxItems
                    Dim addrInROM As UInteger = data.ReadUInt32
                    If addrInROM <> 0 Then
                        Dim bytes As Byte() = GetTextData(data, addrInROM - BankRamStart + BankRomStart)
                        Add(New TextTableItem(bytes, TextGroupInfo))
                    End If
                Next

            End If
        End Sub

        Private Function GetTextData(data As BinaryData, RomAddress As Integer, Optional EnableDialogParameters As Boolean = False) As Byte()
            Dim lastPos As Integer = 0
            Dim tempByte As Byte = 0
            Dim byteBuffer As New List(Of Byte)

            lastPos = data.Position
            data.Position = RomAddress

            Do
                tempByte = data.ReadByte
                byteBuffer.Add(tempByte)
                If tempByte = &HFF Then Exit Do
            Loop

            data.Position = lastPos
            Return byteBuffer.ToArray
        End Function

        Public Overrides Sub Save(data As BinaryData)
            Dim DataRomOffset, lastTableOffset, lastTable2Offset As Integer, BankRomStart, BankRamStart As UInteger

            lastTableOffset = TextGroupInfo.Data.TableRomOffset
            DataRomOffset = TextGroupInfo.Data.DataRomOffset
            BankRamStart = TextGroupInfo.Segmented.BankAddress
            BankRomStart = TextGroupInfo.Segmented.BankStartRom

            If TextGroupInfo.TableType = TextTableType.Dialogs Then
                lastTable2Offset = TextGroupInfo.DialogData?.TableRomOffset

                For i As Integer = 0 To Count - 1
                    Dim textitem As TextTableDialogItem = ElementAtOrDefault(i)

                    'Table 1
                    data.Position = lastTableOffset
                    data.Write(If(textitem Is Nothing, 0, CInt(lastTable2Offset - BankRomStart + BankRamStart)))
                    lastTableOffset += 4

                    'Table 2 (including Dialog Params)
                    data.Position = lastTable2Offset
                    If textitem IsNot Nothing Then
                        data.Write(CShort(0))
                        data.WriteByte(0)
                        data.WriteByte(textitem.UnknownValue)
                        data.WriteByte(textitem.LinesPerSite)
                        data.WriteByte(0)
                        data.Write(CShort(textitem.VerticalPosition))
                        data.Write(CShort(textitem.HorizontalPosition))
                        data.Write(CShort(0))
                        data.Write(CUInt(DataRomOffset - BankRomStart + BankRamStart))
                    Else
                        data.Write(CShort(0))
                        data.WriteByte(0)
                        data.WriteByte(0)
                        data.WriteByte(0)
                        data.WriteByte(0)
                        data.Write(CShort(0))
                        data.Write(CShort(0))
                        data.Write(CShort(0))
                        data.Write(CUInt(0))
                    End If
                    lastTable2Offset += &H10

                    'Text Data
                    data.Position = DataRomOffset
                    If textitem IsNot Nothing Then _
                        WriteTextItem(data, DataRomOffset, textitem)
                    DataRomOffset += textitem.Data.Length
                Next
            Else
                For i As Integer = 0 To Count - 1
                    Dim textitem As TextTableItem = ElementAtOrDefault(i)

                    'Table
                    data.Position = lastTableOffset
                    data.Write(If(textitem Is Nothing, CUInt(0), CUInt(DataRomOffset - BankRomStart + BankRamStart)))
                    lastTableOffset += 4

                    'Text Data
                    data.Position = DataRomOffset
                    If textitem IsNot Nothing Then _
                        WriteTextItem(data, DataRomOffset, textitem)
                    DataRomOffset += textitem.Data.Length
                Next
            End If
        End Sub

        Private Sub WriteTextItem(data As BinaryData, RomAddress As Integer, item As TextTableItem)
            data.Position = RomAddress
            For Each b In item.Data
                data.WriteByte(b)
            Next
        End Sub

    End Class

End Namespace
