Imports System.IO
Imports System.Runtime.InteropServices
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands
Imports SM64Lib.SegmentedBanking

Namespace Global.SM64Lib.ObjectBanks

    Public Class CustomObjectBank

        Public ReadOnly Property Objects As New List(Of CustomObject)
        Public ReadOnly Property CurSeg As SegmentedBank = Nothing
        Public Property NeedToSave As Boolean = False

        Public Function WriteToSeg(bankID As Byte)
            Dim segStream As New MemoryStream
            Dim seg As New SegmentedBank(bankID, segStream)
            Dim data As New BinaryStreamData(segStream)
            Dim lvlScriptLength As UInteger
            Dim lvlScript As New Levelscript

            'Calculate space of Levelscript
            lvlScriptLength = HexRoundUp1(Objects.Count * 8 + 4)

            'Start Custom Objects
            data.Position = lvlScriptLength
            For Each obj As CustomObject In Objects
                'Write Object Model
                obj.ModelBankOffset = data.Position
                Dim sr As Model.ObjectModel.SaveResult =
                    obj.Model.ToBinaryData(data, data.Position, 0, seg.BankAddress)
                HexRoundUp2(data.Position)

                'Write Model Offset & Length & Collision Offset
                data.Write(obj.ModelBankOffset)
                data.Write(obj.Model.Length)
                data.Write(sr.CollisionPointer And &HFFFFFF)
                HexRoundUp2(data.Position)

                'Copy new Geopointer(s)
                obj.Geolayout.Geopointers.Clear()
                obj.Geolayout.Geopointers.AddRange(sr.GeoPointers.ToArray)

                'Write Geolayout
                obj.GeolayoutBankOffset = data.Position
                obj.Geolayout.Write(data.BaseStream, data.Position)
                data.Position = HexRoundUp1(data.Position + &H30)
            Next

            'Set length of segmented
            HexRoundUp2(data.Position)
            seg.Length = data.Position

            'Create Levelscript
            For Each obj As CustomObject In Objects
                lvlScript.Add(New LevelscriptCommand($"22 08 00 {obj.ModelID.ToString("X")} {bankID.ToString("X")} {Hex((obj.GeolayoutBankOffset >> 16) And &HFF)} {Hex((obj.GeolayoutBankOffset >> 8) And &HFF)} {Hex(obj.GeolayoutBankOffset And &HFF)}"))
            Next
            lvlScript.Add(New LevelscriptCommand("07 04 00 00"))
            lvlScript.Write(data, 0)

            _CurSeg = seg
            _NeedToSave = False
            Return seg
        End Function

        Public Sub ReadFromSeg(rommgr As RomManager, bankID As Byte)
            ReadFromSeg(rommgr, rommgr.GetSegBank(bankID))
        End Sub

        Public Sub ReadFromSeg(rommgr As RomManager, seg As SegmentedBank)
            Dim s As Stream
            Dim data As BinaryData
            Dim lvlscript As New Levelscript

            _CurSeg = seg
            s = seg.ReadDataIfNull(rommgr)
            data = New BinaryStreamData(s)

            'Read Levelscript
            lvlscript.Read(rommgr, seg.BankAddress, LevelscriptCommandTypes.JumpBack, New Dictionary(Of Byte, SegmentedBank) From {{seg.BankID, seg}})

            'Parse Levelscript & Load Models
            For Each cmd As LevelscriptCommand In lvlscript
                Select Case cmd.CommandType
                    Case LevelscriptCommandTypes.LoadPolygonWithGeo
                        Dim obj As New CustomObject

                        'Load Model ID & Geolayout Offset
                        obj.ModelID = clLoadPolygonWithGeo.GetModelID(cmd)
                        Dim geoAddr As Integer = clLoadPolygonWithGeo.GetSegAddress(cmd)
                        obj.GeolayoutBankOffset = geoAddr And &HFFFFFF

                        If (geoAddr >> 24) = seg.BankID Then
                            'Load Model Offset & Length
                            data.Position = obj.GeolayoutBankOffset - &H10
                            obj.ModelBankOffset = data.ReadInt32
                            Dim f3d_length As Integer = data.ReadInt32
                            Dim colOffset As Integer = data.ReadInt32

                            'Load Geolayout
                            obj.Geolayout = New Geolayout.Geolayout(Geolayout.Geolayout.NewScriptCreationMode.None)
                            obj.Geolayout.Read(rommgr, geoAddr)

                            'Load Model
                            obj.Model = New Model.ObjectModel
                            obj.Model.FromBinaryData(data, 0, seg.BankAddress, obj.ModelBankOffset, f3d_length, obj.Geolayout.Geopointers.ToArray, colOffset Or seg.BankAddress)

                            'Add Object to list
                            Objects.Add(obj)
                        End If

                End Select
            Next
        End Sub

    End Class

End Namespace
