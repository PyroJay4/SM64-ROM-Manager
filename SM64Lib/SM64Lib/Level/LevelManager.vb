Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports N64Graphics
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Windows.Forms
Imports SM64Lib.Geolayout.Script
Imports SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Levels.ScrolTex

Namespace Levels

    Public Enum LevelType
        Original
        SM64RomManager
        SM64Editor
    End Enum

    Public Class LevelManager

        Public Shared Sub LoadSM64EditorLevel(lvl As Level, rommgr As RomManager, LevelID As UShort, Levelindex As Byte, segAddress As UInteger)
            Dim customBGStart As Integer = 0
            Dim customBGEnd As Integer = 0

            lvl.LevelID = LevelID

            'Load Bank 0x19
            lvl.bank0x19 = rommgr.GetSegBank(&H19)
            lvl.bank0x19.ReadDataIfNull(rommgr.RomFile)

            If Not lvl.Closed Then lvl.Close()
            lvl.Closed = False

            'Erstelle Backup von frischem Levelscript
            Dim freshLevelscript As Levelscript = lvl.Levelscript

            'Lade Levelscript
            lvl.Levelscript = New Levelscript
            lvl.Levelscript.Read(rommgr, segAddress)

            'Erstelle Areas / Lade Einstellungen
            Dim AreaOnFly As Boolean = False
            Dim tArea As LevelArea = Nothing
            Dim CurrentLevelScriptCommands = lvl.Levelscript.ToArray
            Dim cmdsToRemove As New List(Of LevelscriptCommand)
            Dim firstArea As LevelArea = Nothing

            For Each c As LevelscriptCommand In CurrentLevelScriptCommands
                Select Case c.CommandType
                    Case LevelscriptCommandTypes.StartArea
                        AreaOnFly = True
                        tArea = New LevelArea
                        If firstArea Is Nothing Then firstArea = tArea
                        tArea.AreaID = clStartArea.GetAreaID(c)
                        tArea.GeolayoutOffset = clStartArea.GetSegGeolayoutAddr(c)
                        tArea.Geolayout.Read(rommgr, tArea.GeolayoutOffset)

                    Case LevelscriptCommandTypes.EndOfArea
                        tArea.Levelscript.Add(c)
                        lvl.Levelscript.Remove(c)
                        lvl.Areas.Add(tArea)
                        AreaOnFly = False

                    Case LevelscriptCommandTypes.AreaMusic
                        tArea.BGMusic = clAreaMusic.GetMusicID(c)

                    Case LevelscriptCommandTypes.AreaMusicSimple
                        tArea.BGMusic = clAreaMusicSimple.GetMusicID(c)

                    Case LevelscriptCommandTypes.Tarrain
                        tArea.TerrainType = clTerrian.GetTerrainType(c)

                    Case LevelscriptCommandTypes.Normal3DObject
                        If clNormal3DObject.GetSegBehaviorAddr(c) = &H400000 Then
                            tArea.ScrollingTextures.Add(New ManagedScrollingTexture(c))
                        Else
                            tArea.Objects.Add(c)
                        End If

                    Case LevelscriptCommandTypes.ConnectedWarp
                        If ({&HF0, &HF1}).Contains(clWarp.GetWarpID(c)) Then
                            tArea.WarpsForGame.Add(c)
                        Else
                            tArea.Warps.Add(c)
                        End If

                    Case LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.InstantWarp
                        tArea.Warps.Add(c)

                    Case LevelscriptCommandTypes.LoadRomToRam
                        Dim bankID As Byte = clLoadRomToRam.GetSegmentedID(c)
                        Dim startAddr As Integer = clLoadRomToRam.GetRomStart(c)
                        Dim endAddr As Integer = clLoadRomToRam.GetRomEnd(c)
                        'rommgr.SetSegBank(bankID, startAddr, endAddr)

                        Select Case bankID
                            Case &HA 'Background-Image
                                customBGStart = startAddr
                                customBGEnd = endAddr - &H140
                        End Select

                    Case LevelscriptCommandTypes.ShowDialog
                        If AreaOnFly Then
                            tArea.ShowMessage.Enabled = True
                            tArea.ShowMessage.DialogID = clShowDialog.GetDialogID(c)
                        End If

                    Case LevelscriptCommandTypes.JumpBack, LevelscriptCommandTypes.JumpToSegAddr
                        If tArea IsNot Nothing Then cmdsToRemove.Add(c)

                End Select

                If AreaOnFly AndAlso Not cmdsToRemove.Contains(c) Then
                    lvl.Levelscript.Remove(c)
                    tArea.Levelscript.Add(c)
                End If
            Next

            'Lösche alle Jump-Commands aus dem Levelscript
            For Each cmd As LevelscriptCommand In cmdsToRemove
                lvl.Levelscript.Remove(cmd)
                cmd.Close()
            Next

            'Stelle frisches Levelscript wieder her
            lvl.Levelscript = freshLevelscript

            'Lösche alle Objekte und Warps aus dem Levelscript
            Dim lvlscrptidstoremove = {LevelscriptCommandTypes.Normal3DObject, LevelscriptCommandTypes.ConnectedWarp, LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.InstantWarp}
            For Each a In lvl.Areas
                For Each c In a.Levelscript.Where(Function(n) lvlscrptidstoremove.Contains(n.CommandType)).ToArray
                    a.Levelscript.Remove(c)
                Next
            Next

            'Lese Custom Background Image
            Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
            Dim br2 As New BinaryReader(fs)
            lvl.Background.Enabled = False
            For Each a As LevelArea In lvl.Areas
                Dim bgglcmd As GeolayoutCommand = a.Geolayout.Geolayoutscript.GetFirst(GeolayoutCommandTypes.Background)
                If cgBackground.GetBackgroundPointer(bgglcmd) = 0 Then
                    a.Background.Type = AreaBGs.Color
                    a.Background.Color = cgBackground.GetRrgbaColor(bgglcmd)
                Else
                    a.Background.Type = AreaBGs.Levelbackground
                    lvl.Background.ID = cgBackground.GetBackgroundID(bgglcmd)
                    lvl.Background.Enabled = True
                End If
            Next
            If lvl.Background.Enabled AndAlso lvl.Background.ID = Geolayout.BackgroundIDs.Custom Then
                fs.Position = customBGStart
                lvl.Background.ReadImage(fs, customBGStart)
            End If

            Dim bank0x19RomStart As Integer
            Dim bank0x19RomEnd As Integer
            Dim brToUse As BinaryReader
            bank0x19RomStart = 0
            bank0x19RomEnd = lvl.bank0x19.Length
            brToUse = New BinaryReader(lvl.bank0x19.Data)

            'Lese Area-Modelle
            Dim modelBank As SegmentedBank = rommgr.GetSegBank(&HE)
            For Each a As LevelArea In lvl.Areas
                a.AreaModel.Collision = New Collision.CollisionMap
                a.AreaModel.Collision.FromStream(fs, modelBank.SegToRomAddr(a.CollisionPointer))
                a.AreaModel.Fast3DBuffer = New Fast3D.Fast3DBuffer
                Throw New NotImplementedException("Es müssen pro Area Fast3D Start & Fast3D Length herausgefunden werden!")
                a.AreaModel.FromStream(fs, a.Bank0x0EOffset, &HE000000, a.Fast3DBankRomStart, a.Fast3DLength, a.Geolayout.Geopointers.ToArray, a.CollisionPointer)
            Next

            'Lese alle Box-Daten
            firstArea.SpecialBoxes.Clear()
            Throw New NotImplementedException("TableStart muss noch geändert werden!")
            firstArea.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Water, bank0x19RomStart, bank0x19RomStart + &H6000))
            firstArea.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.ToxicHaze, bank0x19RomStart, bank0x19RomStart + &H6280))
            firstArea.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Mist, bank0x19RomStart, bank0x19RomStart + &H6500))

            'One-Bank-0xE-System
            lvl.OneBank0xESystemEnabled = True

            'Act Selector
            PatchClass.Openfs(fs)
            lvl.ActSelector = PatchClass.ActSelector_Enabled(LevelID)

            'Hardcoded Camera
            PatchClass.HardcodedCamera_Enabled(LevelID) = lvl.HardcodedCameraSettings

            fs.Close()

            'Object-Banks
            lvl.ObjectBank0x0C = lvl.GetObjectBank0x0C()
            lvl.ObjectBank0x0D = lvl.GetObjectBank0x0D()
            lvl.ObjectBank0x0E = lvl.GetObjectBank0x0E()
        End Sub

        Public Shared Sub LoadRomManagerLevel(lvl As Level, rommgr As RomManager, LevelID As UShort, Levelindex As Byte, segAddress As UInteger)
            Dim customBGStart As Integer = 0
            Dim customBGEnd As Integer = 0

            lvl.LevelID = LevelID

            'Load Bank 0x19
            lvl.bank0x19 = rommgr.GetSegBank(&H19)
            lvl.bank0x19.ReadDataIfNull(rommgr.RomFile)

            If Not lvl.Closed Then lvl.Close()
            lvl.Closed = False

            'Lade Levelscript
            lvl.Levelscript = New Levelscript
            lvl.Levelscript.Read(rommgr, segAddress)

            'Erstelle Areas / Lade Einstellungen
            Dim AreaOnFly As Boolean = False
            Dim tArea As LevelArea = Nothing
            Dim CurrentLevelScriptCommands = lvl.Levelscript.ToArray
            Dim cmdsToRemove As New List(Of LevelscriptCommand)

            For Each c As LevelscriptCommand In CurrentLevelScriptCommands
                Select Case c.CommandType
                    Case LevelscriptCommandTypes.StartArea
                        AreaOnFly = True
                        tArea = New LevelArea
                        tArea.AreaID = clStartArea.GetAreaID(c)
                        tArea.GeolayoutOffset = clStartArea.GetSegGeolayoutAddr(c) '- bank0x19.BankAddress + bank0x19.RomStart
                        tArea.Geolayout.Read(rommgr, tArea.GeolayoutOffset)
                        For i = 0 To 2
                            tArea.Geolayout.DisableWater(CType(i, SpecialBoxType))
                        Next

                    Case LevelscriptCommandTypes.EndOfArea
                        tArea.Levelscript.Add(c)
                        lvl.Levelscript.Remove(c)
                        lvl.Areas.Add(tArea)
                        AreaOnFly = False

                    Case LevelscriptCommandTypes.AreaMusic
                        tArea.BGMusic = clAreaMusic.GetMusicID(c)

                    Case LevelscriptCommandTypes.AreaMusicSimple
                        tArea.BGMusic = clAreaMusicSimple.GetMusicID(c)

                    Case LevelscriptCommandTypes.Tarrain
                        tArea.TerrainType = clTerrian.GetTerrainType(c)

                    Case LevelscriptCommandTypes.Normal3DObject
                        If clNormal3DObject.GetSegBehaviorAddr(c) = &H400000 Then
                            tArea.ScrollingTextures.Add(New ManagedScrollingTexture(c))
                        Else
                            tArea.Objects.Add(c)
                        End If

                    Case LevelscriptCommandTypes.ConnectedWarp
                        If ({&HF0, &HF1}).Contains(clWarp.GetWarpID(c)) Then
                            tArea.WarpsForGame.Add(c)
                        Else
                            tArea.Warps.Add(c)
                        End If

                    Case LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.InstantWarp
                        tArea.Warps.Add(c)

                    Case LevelscriptCommandTypes.LoadRomToRam
                        Dim bankID As Byte = clLoadRomToRam.GetSegmentedID(c)
                        Dim startAddr As Integer = clLoadRomToRam.GetRomStart(c)
                        Dim endAddr As Integer = clLoadRomToRam.GetRomEnd(c)
                        'rommgr.SetSegBank(bankID, startAddr, endAddr)

                        Select Case bankID
                            Case &HA 'Background-Image
                                customBGStart = startAddr
                                customBGEnd = endAddr - &H140
                        End Select

                    Case LevelscriptCommandTypes.ShowDialog
                        If AreaOnFly Then
                            tArea.ShowMessage.Enabled = True
                            tArea.ShowMessage.DialogID = clShowDialog.GetDialogID(c)
                        End If

                    Case LevelscriptCommandTypes.JumpBack, LevelscriptCommandTypes.JumpToSegAddr
                        If tArea IsNot Nothing Then cmdsToRemove.Add(c)

                End Select

                If AreaOnFly AndAlso Not cmdsToRemove.Contains(c) Then
                    lvl.Levelscript.Remove(c)
                    tArea.Levelscript.Add(c)
                End If
            Next

            'Lösche alle Jump-Commands aus dem Levelscript
            For Each cmd As LevelscriptCommand In cmdsToRemove
                lvl.Levelscript.Remove(cmd)
                cmd.Close()
            Next

            'Lösche alle Objekte und Warps aus dem Levelscript
            Dim lvlscrptidstoremove = {LevelscriptCommandTypes.Normal3DObject, LevelscriptCommandTypes.ConnectedWarp, LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.InstantWarp}
            For Each a In lvl.Areas
                For Each c In a.Levelscript.Where(Function(n) lvlscrptidstoremove.Contains(n.CommandType)).ToArray
                    a.Levelscript.Remove(c)
                Next
            Next

            'Lese Custom Background Image
            Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
            Dim br2 As New BinaryReader(fs)
            lvl.Background.Enabled = False
            For Each a As LevelArea In lvl.Areas
                Dim bgglcmd As GeolayoutCommand = a.Geolayout.Geolayoutscript.GetFirst(GeolayoutCommandTypes.Background)
                If cgBackground.GetBackgroundPointer(bgglcmd) = 0 Then
                    a.Background.Type = AreaBGs.Color
                    a.Background.Color = cgBackground.GetRrgbaColor(bgglcmd)
                Else
                    a.Background.Type = AreaBGs.Levelbackground
                    lvl.Background.ID = cgBackground.GetBackgroundID(bgglcmd)
                    lvl.Background.Enabled = True
                End If
            Next
            lvl.Background.IsCustom = True
            For Each val As Integer In [Enum].GetValues(GetType(Geolayout.BackgroundPointers))
                If val <> 0 AndAlso customBGStart = val Then
                    lvl.Background.IsCustom = False
                End If
            Next
            If lvl.Background.Enabled AndAlso lvl.Background.IsCustom Then '.ID = Geolayout.BackgroundIDs.Custom Then
                fs.Position = customBGStart
                lvl.Background.ReadImage(fs, customBGStart)
            End If

            Dim bank0x19RomStart As Integer
            Dim bank0x19RomEnd As Integer
            Dim brToUse As BinaryReader
            bank0x19RomStart = 0
            bank0x19RomEnd = lvl.bank0x19.Length
            brToUse = New BinaryReader(lvl.bank0x19.Data)

            'Lese Area-Table
            For Each a As LevelArea In lvl.Areas
                'Fast3D-Daten
                brToUse.BaseStream.Position = bank0x19RomStart + &H5F00 + (a.AreaID * &H10)
                a.Bank0x0EOffset = SwapInts.SwapInt32(brToUse.ReadInt32)
                Dim romEnd0xE As Integer = SwapInts.SwapInt32(brToUse.ReadInt32)
                rommgr.SetSegBank(&HE, a.Bank0x0EOffset, romEnd0xE, a.AreaID)

                '2D-Kamera
                brToUse.BaseStream.Position = bank0x19RomStart + &H5F0F + (a.AreaID * &H10)
                a.Enable2DCamera = Bits.GetBoolOfByte(brToUse.ReadByte, 7)
            Next

            'Lese Area-Modelle
            For Each a As LevelArea In lvl.Areas
                a.AreaModel.FromStream(fs, a.Bank0x0EOffset, &HE000000, a.Fast3DBankRomStart, a.Fast3DLength, a.Geolayout.Geopointers.ToArray, a.CollisionPointer)
            Next

            'Lese alle Box-Daten
            Dim CurrentBoxOffset As Integer = bank0x19RomStart + &H6A00
            For Each a As LevelArea In lvl.Areas
                a.SpecialBoxes.Clear()
                a.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Water, bank0x19RomStart, bank0x19RomStart + &H6000 + (&H50 * a.AreaID)))
                a.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.ToxicHaze, bank0x19RomStart, bank0x19RomStart + &H6280 + (&H50 * a.AreaID)))
                a.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Mist, bank0x19RomStart, bank0x19RomStart + &H6500 + (&H50 * a.AreaID)))
            Next

            'One-Bank-0xE-System
            lvl.OneBank0xESystemEnabled = True

            'Act Selector
            PatchClass.Openfs(fs)
            lvl.ActSelector = PatchClass.ActSelector_Enabled(LevelID)

            'Hardcoded Camera
            PatchClass.HardcodedCamera_Enabled(LevelID) = lvl.HardcodedCameraSettings

            fs.Close()

            'Object-Banks
            lvl.ObjectBank0x0C = lvl.GetObjectBank0x0C()
            lvl.ObjectBank0x0D = lvl.GetObjectBank0x0D()
            lvl.ObjectBank0x0E = lvl.GetObjectBank0x0E()
        End Sub

        Public Shared Sub SaveRomManagerLevel(lvl As Level, rommgr As RomManager, s As Stream, scriptOffset As Integer, ByRef curOff As UInteger)
            Dim bw As New BinaryWriter(s)
            Dim bw0x19 As BinaryWriter = Nothing
            Dim lid = rommgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = lvl.LevelID)
            Dim offNewBank0x19 As UInteger = curOff

            'Get Bank 0x19
            If lvl.bank0x19 Is Nothing Then
                lvl.bank0x19 = rommgr.SetSegBank(&H19, offNewBank0x19, RomManager.ManagerSettings.defaultLevelscriptSize)
                lvl.bank0x19.Data = New MemoryStream
                lvl.bank0x19.Length = RomManager.ManagerSettings.defaultLevelscriptSize
            Else
                Dim oldData As Stream = lvl.bank0x19.Data
                lvl.bank0x19 = rommgr.SetSegBank(&H19, offNewBank0x19, offNewBank0x19 + lvl.bank0x19.Length)
                lvl.bank0x19.Data = oldData
            End If
            bw0x19 = New BinaryWriter(lvl.bank0x19.Data)

            'Write Area Model & Update Scrolling Texture Vertex Pointers
            Dim CurrentRomOffset As UInteger = lvl.bank0x19.RomEnd
            For Each a As LevelArea In lvl.Areas
                Dim oldModelStart As Integer = a.AreaModel.Fast3DBuffer.Fast3DBankStart
                Dim newModelStart As Integer
                Dim modelOffset As Integer

                'Write Area Model
                Dim res As ObjectModel.SaveResult = a.AreaModel.ToStream(s, CurrentRomOffset, CurrentRomOffset, &HE000000)

                'Calculate Model Offset & Update Scrolling Texture Vertex Pointers
                newModelStart = a.AreaModel.Fast3DBuffer.Fast3DBankStart
                modelOffset = newModelStart - oldModelStart
                If modelOffset <> 0 Then
                    a.UpdateScrollingTextureVertexPointer(modelOffset)
                End If

                a.CollisionPointer = res.CollisionPointer
                a.Geolayout.Geopointers.Clear() : a.Geolayout.Geopointers.AddRange(res.GeoPointers.ToArray)

                a.Bank0x0EOffset = CurrentRomOffset

                CurrentRomOffset += res.Length + &H20
                HexRoundUp2(CurrentRomOffset)
            Next

            'Write Background Image
            HexRoundUp2(s.Position)
            Dim customBGStart As Integer = CurrentRomOffset
            Dim customBGEnd As Integer = 0
            If lvl.Background.IsCustom Then '.ID = Geolayout.BackgroundIDs.Custom Then
                'Write Custom Background
                lvl.Background.WriteImage(s, customBGStart)

                'Write Pointer Table
                Dim bgPtrTable As Byte() = LevelBG.GetBackgroundPointerTable()
                s.Write(bgPtrTable, 0, bgPtrTable.Length)

                customBGEnd = customBGStart + lvl.Background.ImageLength + bgPtrTable.Length
                CurrentRomOffset += lvl.Background.ImageLength + bgPtrTable.Length
                HexRoundUp2(CurrentRomOffset)
            End If

            'Update Geolayouts
            For Each a As LevelArea In lvl.Areas
                'Update Backcolor Command
                Dim cmd As GeolayoutCommand = a.Geolayout.Geolayoutscript.GetFirst(GeolayoutCommandTypes.Background)
                If a.Background.Type = AreaBGs.Levelbackground AndAlso lvl.Background.Enabled Then
                    cgBackground.SetBackgroundPointer(cmd, &H802763D4)
                    cgBackground.SetBackgroundID(cmd, lvl.Background.ID)
                Else
                    cgBackground.SetBackgroundPointer(cmd, 0)
                    cgBackground.SetRgbaColor(cmd, a.Background.Color)
                End If
            Next

            'Write Geolayouts
            Dim GeoIndex As Integer = 0
            For Each a As LevelArea In lvl.Areas
                Dim geooffset As Integer = &H5000 + GeoIndex * &H1E0
                a.GeolayoutOffset = lvl.bank0x19.BankAddress + geooffset

                a.Geolayout.Write(lvl.bank0x19.Data, geooffset)
                a.Geolayout.NewGeoOffset = lvl.bank0x19.RomStart + geooffset

                GeoIndex += 1
            Next

            'Füge Show-Dialog-Command & 2D-Camera-Object ein
            For Each a As LevelArea In lvl.Areas
                'Show-Dialog-Command
                If a.ShowMessage.Enabled Then
                    Dim cmdShowMsg As New LevelscriptCommand($"30 04 00 {a.ShowMessage.DialogID.ToString("X2")}")
                    Dim indexOf1E As Integer = a.Levelscript.IndexOfFirst(LevelscriptCommandTypes.EndOfArea)
                    a.Levelscript.Insert(indexOf1E, cmdShowMsg)
                End If

                '2D-Camera-Object
                Dim cmds2d As New List(Of LevelscriptCommand)
                For Each obj As LevelscriptCommand In a.Objects
                    If obj.CommandType = LevelscriptCommandTypes.Normal3DObject Then
                        If clNormal3DObject.GetSegBehaviorAddr(obj) = &H130053C4 Then 'Behav-ID: '0x130053C4
                            cmds2d.Add(obj)
                        End If
                    End If
                Next
                If a.Enable2DCamera Then
                    If cmds2d.Count = 0 Then
                        Dim cmd As New LevelscriptCommand("24 18 1F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 13 00 53 C4")
                        a.Objects.Add(cmd)
                    End If
                ElseIf cmds2d.Count > 0 Then
                    For Each cmd As LevelscriptCommand In cmds2d
                        a.Objects.Remove(cmd)
                    Next
                End If
            Next

            Dim lvlScript0E As Levelscript = Nothing
            Dim areaobjwarpoffsetdic As Dictionary(Of Byte, UInteger) = Nothing
            Dim firstBank0xE As SegmentedBank = Nothing
            Dim curFirstBank0xEOffset As UInteger = 0

            'Add Objects and Warps to new Levelscript
            lvlScript0E = New Levelscript
            firstBank0xE = rommgr.SetSegBank(&HE, CurrentRomOffset, 0)
            areaobjwarpoffsetdic = New Dictionary(Of Byte, UInteger)

            For Each a As LevelArea In lvl.Areas
                areaobjwarpoffsetdic.Add(a.AreaID, firstBank0xE.BankAddress + curFirstBank0xEOffset)
                For Each c As LevelscriptCommand In a.Objects
                    lvlScript0E.Add(c)
                    curFirstBank0xEOffset += c.Length
                Next
                For Each c As ManagedScrollingTexture In a.ScrollingTextures
                    c.SaveProperties()
                    lvlScript0E.Add(c.Command)
                    curFirstBank0xEOffset += c.Command.Length
                Next
                For Each c As LevelscriptCommand In a.Warps
                    lvlScript0E.Add(c)
                    curFirstBank0xEOffset += c.Length
                Next
                For Each c As LevelscriptCommand In a.WarpsForGame
                    lvlScript0E.Add(c)
                    curFirstBank0xEOffset += c.Length
                Next
                lvlScript0E.Add(New LevelscriptCommand("07 04 00 00"))
                curFirstBank0xEOffset += 4
            Next

            firstBank0xE.Length = curFirstBank0xEOffset
            lvlScript0E.Write(s, firstBank0xE.RomStart)

            curOff += (firstBank0xE.RomEnd - lvl.bank0x19.RomStart)

            'Füge Area dem Levelscript hinzu
            Dim cIndex2 = lvl.Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1E)
            For Each a In lvl.Areas
                For Each c In a.Levelscript
                    lvl.Levelscript.Insert(cIndex2, c)
                    cIndex2 += 1
                Next
            Next

            'Übernehme Level- und Areaeinstellungen
            Dim CurrentAreaIndex As Integer = 0
            Dim areaobjwarpindextoinsertdic As New Dictionary(Of Byte, Integer)
            Dim areaidindex As New Dictionary(Of Byte, Byte)
            Dim tArea As LevelArea = Nothing
            Dim foundCmdShowMsg As Boolean = False
            Dim cmdBgSegLoad As LevelscriptCommand = Nothing
            Dim cmdsToInsertAt As New Dictionary(Of LevelscriptCommand, LevelscriptCommand)
            Dim cmdsToRemove As New List(Of LevelscriptCommand)

            For Each c In lvl.Levelscript
                Select Case c.CommandType
                    Case LevelscriptCommandTypes.StartArea
                        tArea = lvl.Areas(CurrentAreaIndex)
                        Dim areaid As Byte = tArea.AreaID
                        areaidindex.Add(areaid, areaidindex.Count)
                        clStartArea.SetSegGeolayoutAddr(c, lvl.Areas(CurrentAreaIndex).Geolayout.NewGeoOffset - lvl.bank0x19.RomStart + lvl.bank0x19.BankAddress)
                        areaobjwarpindextoinsertdic.Add(areaid, lvl.Levelscript.IndexOf(c) + 1)

                    Case LevelscriptCommandTypes.EndOfArea

                        If Not foundCmdShowMsg AndAlso tArea.ShowMessage.Enabled Then
                            Dim cmdShowMsg As New LevelscriptCommand($"30 04 00 {tArea.ShowMessage.DialogID.ToString("X2")}")
                            cmdsToInsertAt.Add(c, cmdShowMsg)
                        End If

                        foundCmdShowMsg = False
                        CurrentAreaIndex += 1
                        tArea = Nothing

                    Case LevelscriptCommandTypes.AreaMusic
                        clAreaMusic.SetMusicID(c, lvl.Areas(CurrentAreaIndex).BGMusic)

                    Case LevelscriptCommandTypes.AreaMusicSimple
                        clAreaMusicSimple.SetMusicID(c, lvl.Areas(CurrentAreaIndex).BGMusic)

                    Case LevelscriptCommandTypes.Tarrain
                        clTerrian.SetTerrainType(c, lvl.Areas(CurrentAreaIndex).TerrainType)

                    Case LevelscriptCommandTypes.LoadRomToRam
                        Select Case clLoadRomToRam.GetSegmentedID(c)
                            Case &HE 'Bank 0xE
                                clLoadRomToRam.SetRomStart(c, firstBank0xE.RomStart)
                                clLoadRomToRam.SetRomEnd(c, firstBank0xE.RomEnd)
                            Case &HA
                                cmdBgSegLoad = c
                        End Select

                    Case LevelscriptCommandTypes.ShowDialog
                        If tArea?.ShowMessage.Enabled AndAlso Not foundCmdShowMsg Then
                            clShowDialog.SetDialogID(c, tArea.ShowMessage.DialogID)
                            foundCmdShowMsg = True
                        Else
                            cmdsToRemove.Add(c)
                        End If

                End Select
            Next

            'Füge Jump Commands zur ersten 0xE-Bank hinzu
            For Each e In areaobjwarpindextoinsertdic.OrderByDescending(Function(n) n.Value)
                Dim segStartAddr As UInteger = areaobjwarpoffsetdic(e.Key)
                lvl.Levelscript.Insert(e.Value, New LevelscriptCommand({&H6, 8, 0, 0, (segStartAddr >> 24) And &HFF, (segStartAddr >> 16) And &HFF, (segStartAddr >> 8) And &HFF, segStartAddr And &HFF}))
            Next

            'Lösche Commands
            For Each cmd As LevelscriptCommand In cmdsToRemove
                lvl.Levelscript.Remove(cmd)
            Next

            'Füge neue Commands ein
            For Each kvp As KeyValuePair(Of LevelscriptCommand, LevelscriptCommand) In cmdsToInsertAt
                Dim index As Integer = lvl.Levelscript.IndexOf(kvp.Key)
                lvl.Levelscript.Insert(index, kvp.Value)
            Next

            'Füge Background-Command ein
            If lvl.Background.Enabled Then
                Dim newbgcmd As LevelscriptCommand = If(cmdBgSegLoad, New LevelscriptCommand({&H17, &HC, 0, &HA, 0, 0, 0, 0, 0, 0, 0, 0}))

                If lvl.Background.HasImage Then '.ID = Geolayout.BackgroundIDs.Custom Then
                    clLoadRomToRam.SetRomStart(newbgcmd, customBGStart)
                    clLoadRomToRam.SetRomEnd(newbgcmd, customBGEnd)
                Else
                    clLoadRomToRam.SetRomStart(newbgcmd, GetBackgroundAddressOfID(lvl.Background.ID, False))
                    clLoadRomToRam.SetRomEnd(newbgcmd, GetBackgroundAddressOfID(lvl.Background.ID, True))
                End If

                If Not lvl.Levelscript.Contains(newbgcmd) Then
                    Dim indexoffirstx1e As Integer = lvl.Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1D)
                    lvl.Levelscript.Insert(indexoffirstx1e, newbgcmd)
                End If

            ElseIf cmdBgSegLoad IsNot Nothing Then
                lvl.Levelscript.Remove(cmdBgSegLoad)
            End If

            'Write Levelscript
            lvl.Levelscript.Write(lvl.bank0x19.Data, scriptOffset)

            'Parse Levelscript again!
            Dim AreaOnFly As Boolean = False
            For Each c In lvl.Levelscript.ToArray
                Select Case c.CommandType
                    Case LevelscriptCommandTypes.StartArea
                        AreaOnFly = True
                    Case LevelscriptCommandTypes.EndOfArea
                        AreaOnFly = False
                        lvl.Levelscript.Remove(c)
                End Select
                If AreaOnFly Then lvl.Levelscript.Remove(c)
            Next

            'Write Level Start (Start of Bank 0x19)
            lvl.bank0x19.Data.Position = 0
            For Each b As Byte In lvl.LevelscriptStart
                bw0x19.Write(b)
            Next

            Dim bwToUse As BinaryWriter = If(bw0x19, bw)

            'Write 4 checkbytes for the One-0xE-Bank-Per-Area-Code
            lvl.bank0x19.Data.Position = &H5FFC
            bwToUse.Write(SwapInts.SwapInt32(&H4BC9189A))

            'Write Area Table
            For Each a As LevelArea In lvl.Areas
                Dim off As UInteger = &H5F00 + (a.AreaID * &H10)
                lvl.bank0x19.Data.Position = off
                bwToUse.Write(SwapInts.SwapUInt32(a.Bank0x0EOffset))
                bwToUse.Write(SwapInts.SwapUInt32(a.Bank0x0EOffset + a.Bank0xELength))
                bwToUse.Write(SwapInts.SwapUInt32(0))
                bwToUse.Write(CByte(&H0))
                bwToUse.Write(CByte(&H0))
                bwToUse.Write(CByte(&H0))
                bwToUse.Write(Bits.ArrayToByte({False, False, False, False, False, False, False, a.Enable2DCamera}))
            Next

            'Write SpecialBoxes
            Dim bank0x19RomStart As UInteger = 0
            Dim CurrentBoxOffset As Integer = bank0x19RomStart + &H6A00
            For Each a As LevelArea In lvl.Areas
                Dim TableIndex() As Integer = {0, &H32, &H33}
                Dim TableOffset() As Integer = {bank0x19RomStart + &H6000 + (&H50 * a.AreaID),
                    bank0x19RomStart + &H6280 + (&H50 * a.AreaID),
                    bank0x19RomStart + &H6500 + (&H50 * a.AreaID)}

                For Each w As SpecialBox In a.SpecialBoxes
                    'Write Table Entry
                    bwToUse.BaseStream.Position = TableOffset(CInt(w.Type))
                    bwToUse.Write(SwapInts.SwapInt16(TableIndex(CInt(w.Type))))
                    bwToUse.Write(SwapInts.SwapInt16(&H0))
                    bwToUse.Write(SwapInts.SwapInt32(CurrentBoxOffset - bank0x19RomStart + lvl.bank0x19.BankAddress))
                    TableOffset(CInt(w.Type)) = bwToUse.BaseStream.Position

                    'Write Box Data
                    bwToUse.BaseStream.Position = CurrentBoxOffset
                    For Each b As Byte In w.ToArrayBoxData()
                        bwToUse.Write(b)
                    Next

                    TableIndex(CInt(w.Type)) += 1
                    CurrentBoxOffset += &H20
                Next

                For Each i As Integer In TableOffset
                    bwToUse.BaseStream.Position = i
                    bwToUse.Write(SwapInts.SwapUInt16(&HFFFF))
                Next
            Next

            'Write Bank0x19
            lvl.bank0x19.WriteData(s)

            'Hardcoded Camera Settings & Act Selector
            PatchClass.Openfs(s)
            lvl.HardcodedCameraSettings = PatchClass.HardcodedCamera_Enabled(lvl.LevelID)
            PatchClass.ActSelector_Enabled(lvl.LevelID) = lvl.ActSelector

            'Write Pointer to Levelscript
            s.Position = lid.Pointer
            bw.Write(SwapInts.SwapInt32(&H100019))
            bw.Write(SwapInts.SwapUInt32(lvl.bank0x19.RomStart))
            bw.Write(SwapInts.SwapUInt32(lvl.bank0x19.RomEnd))
            bw.Write(SwapInts.SwapUInt32(&H1900001C))
            bw.Write(SwapInts.SwapUInt32(&H7040000))
        End Sub

    End Class

End Namespace
