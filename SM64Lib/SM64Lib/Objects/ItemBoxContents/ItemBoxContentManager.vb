Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64Lib.Data

Namespace Global.SM64Lib.Objects

    Public Class ItemBoxContentManager

        Private Const TableRamLocation As UInteger = &H80404000UI
        Private Const TableRomLocationCustom As UInteger = &H1204000
        Private Const TableRomLocationOriginal As UInteger = &HEBBA0

        Public ReadOnly Property ContentTable As ItemBoxContentTable

        Public Sub New()
            ContentTable = New ItemBoxContentTable
        End Sub
        Public Sub New(table As ItemBoxContentTable)
            ContentTable = table
        End Sub

        Public Sub Read(rommgr As RomManager)
            Read(rommgr, True)
        End Sub
        Public Sub Read(rommgr As RomManager, clearList As Boolean)
            Try
                Dim rom As BinaryRom

                If clearList Then _
                    ContentTable.Clear()

                rom = rommgr.GetBinaryRom(FileAccess.Read)

                'Get RAM location
                Dim address As UInteger = GetRamLocation(rom)

                'Set ROM position
                If address = TableRamLocation Then
                    address = TableRomLocationCustom
                Else
                    address = TableRomLocationOriginal
                End If

                'Read table
                Read(rom, address)

                rom.Close()
            Catch ex As Exception
                Throw New Exception("Error at reading table from ROM.", ex)
            End Try
        End Sub

        Private Function GetRamLocation(rom As BinaryData) As UInteger
            Dim address As UInteger
            rom.Position = &H7C8E2
            address = CUInt(rom.ReadUInt16) << 16
            rom.Position = &H7C8E6
            address = address Or rom.ReadUInt16
            Return address
        End Function

        Public Sub ResetToOriginal(rommgr As RomManager)
            Try
                Dim rom As BinaryRom = rommgr.GetBinaryRom(IO.FileAccess.Read)
                ContentTable.Clear()
                Read(rom, TableRomLocationOriginal)
                rom.Close()
            Catch ex As Exception
                Throw New Exception("Error at reading original content from ROM.", ex)
            End Try
        End Sub

        Private Sub Read(rom As BinaryRom, location As UInteger)
            Dim curID As Integer = -1

            rom.Position = location

            Do While rom.ReadUInt64 <> &H6300000000000000
                Dim entry As New ItemBoxContentEntry
                rom.Position -= 8
                curID = rom.ReadByte
                entry.ID = curID
                entry.BParam1 = rom.ReadByte
                entry.BParam2 = rom.ReadByte
                entry.ModelID = rom.ReadByte
                entry.BehavAddress = rom.ReadUInt32
                ContentTable.Add(entry)
            Loop
        End Sub

        Public Sub Write(rommgr As RomManager)
            Try
                Dim rom As BinaryRom = rommgr.GetBinaryRom(IO.FileAccess.ReadWrite)

                'Set ROM position
                rom.Position = TableRomLocationCustom

                'Write data of each entry in the list
                For i As Integer = 0 To ContentTable.Count - 1
                    Dim entry As ItemBoxContentEntry = ContentTable(i)
                    rom.Write(CByte(i))
                    rom.Write(entry.BParam1)
                    rom.Write(entry.BParam2)
                    rom.Write(entry.ModelID)
                    rom.Write(entry.BehavAddress)
                Next

                'Finish table
                rom.Write(&H6300000000000000)

                'Update RAM Pointer in the ASM Code
                Dim shouldUpdate As Boolean = WriteNewPointer(rom)

                rom.Close()

                'Update Checksum
                If shouldUpdate Then
                    PatchClass.UpdateChecksum(rommgr.RomFile)
                End If
            Catch ex As Exception
                Throw New Exception("Error at writing table to ROM.", ex)
            End Try
        End Sub

        Private Function WriteNewPointer(rom As BinaryRom) As Boolean
            'Get RAM location
            Dim address As UInteger = GetRamLocation(rom)

            'Set ROM position
            If address <> TableRamLocation Then
                rom.Position = &H7C8E2
                rom.Write(CUShort((TableRamLocation >> 16) And &HFFFF))
                rom.Position = &H7C8E6
                rom.Write(CUShort(TableRamLocation And &HFFFF))
                Return True
            End If

            Return False
        End Function

        Public Sub Read(fileName As String)
            Read(fileName, True)
        End Sub
        Public Sub Read(fileName As String, clearList As Boolean)
            If clearList Then _
                ContentTable.Clear()

            Try
                Select Case Path.GetExtension(fileName).ToLower
                    Case ".ibc"
                        ReadFromJson(fileName)
                    Case ".txt"
                        ReadFromTxt(fileName)
                End Select
            Catch ex As Exception
                Throw New FormatException("Error at reading file. It probably has a wrong format.", ex)
            End Try
        End Sub

        Public Sub Write(fileName As String)
            Try
                Select Case Path.GetExtension(fileName).ToLower
                    Case ".ibc"
                        WriteToJson(fileName)
                    Case ".txt"
                        WriteToTxt(fileName)
                End Select
            Catch ex As Exception
                Throw New FormatException("Error at reading file. It probably has a wrong format.", ex)
            End Try
        End Sub

        Private Sub ReadFromJson(fileName As String)
            Dim ct As ItemBoxContentTable = JToken.Parse(File.ReadAllText(fileName)).ToObject(Of ItemBoxContentTable)
            ContentTable.AddRange(ct.ToArray)
        End Sub

        Private Sub ReadFromTxt(fileName As String)
            For Each line As String In File.ReadAllLines(fileName)
                Dim vals As String() = line.Split(",")
                Dim entry As New ItemBoxContentEntry

                entry.ID = Convert.ToByte(vals(0).Trim, 16)
                vals(1) = vals(1).Trim
                entry.BParam1 = Convert.ToByte(vals(1).Substring(0, 2), 16)
                entry.BParam2 = Convert.ToByte(vals(1).Substring(2, 2), 16)
                entry.ModelID = Convert.ToByte(vals(2).Trim, 16)
                entry.BehavAddress = Convert.ToUInt32(vals(3).Trim, 16)

                ContentTable.Add(entry)
            Next
        End Sub

        Private Sub WriteToJson(fileName As String)
            File.WriteAllText(fileName, JToken.FromObject(ContentTable).ToString)
        End Sub

        Private Sub WriteToTxt(fileName As String)
            Dim sw As New StreamWriter(fileName)

            For Each entry As ItemBoxContentEntry In ContentTable
                Dim bparams As UShort = (CUShort(entry.BParam1) << 16) Or entry.BParam2
                sw.WriteLine($"{entry.ID.ToString("X2")}, {bparams.ToString("X4")}, {entry.ModelID.ToString("X2")}, {entry.BehavAddress.ToString("X8")}")
            Next

            sw.Flush()
            sw.Close()
        End Sub

    End Class

End Namespace
