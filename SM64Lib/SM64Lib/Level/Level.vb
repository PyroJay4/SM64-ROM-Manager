Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Level.Script, SM64Lib.Level.Script.Commands
Imports N64Graphics
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Windows.Forms
Imports SM64Lib.Geolayout.Script
Imports SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Level.ScrolTex

Namespace Global.SM64Lib.Level

    Public Class LevelList
        Inherits List(Of Level)
        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return Me.Where(Function(n) n.NeedToSaveLevelscript OrElse n.NeedToSaveBanks0E).Count > 0
            End Get
        End Property
    End Class

    Public Class Level

        Public ReadOnly LevelscriptStart() As Byte = {&H80, &H8, &H0, &H0, &H19, &H0, &H0, &H1C, &H8, &H0, &H0, &HA, &H0, &HA0, &H0, &H78, &H0, &HA0, &H0, &H78, &H4, &H0, &H0, &H0, &HC, &H0, &H0, &H0}
        Public ReadOnly Property Levelscript As New Levelscript
        Public ReadOnly Property Areas As New List(Of LevelArea)
        Public Property ObjectBank0x0C As ObjectBank0x0C = 0
        Public Property ObjectBank0x0D As ObjectBank0x0D = 0
        Public Property ObjectBank0x0E As ObjectBank0x0E = 0
        Public Property DefaultTerrainType As Integer = 0
        Public Property LevelID As UShort = 0
        Public Property SegmentedID As Byte = &H19
        Public ReadOnly Property Background As New LevelBG
        Public Property ActSelector As Boolean = False
        Public Property HardcodedCameraSettings As Boolean = False
        Public Property Closed As Boolean = False
        Public Property LastRomOffset As Integer = -1
        Public Property LevelFast3DBuffer As MemoryStream = Nothing
        Public ReadOnly Property SM64EditorMode As Boolean = False
        Public Property NeedToSaveLevelscript As Boolean = False
        Public Property NeedToSaveBanks0E As Boolean = False
        Public Property OneBank0xESystemEnabled As Boolean = True

        Public additionalRange() As Byte = {}
        Public bank0x19 As SegmentedBank = Nothing

        Public Sub New(LevelID As UShort, LevelIndex As Integer)
            Me.LevelID = LevelID

            With Levelscript
                .Close()
                .Clear()

                .Add(New LevelscriptCommand({&H1B, &H4, &H0, &H0}))

                .Add(New LevelscriptCommand({&H17, &HC, &H1, &HE, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}))

                .Add(New LevelscriptCommand({&H1D, &H4, &H0, &H0}))

                .Add(New LevelscriptCommand({&H25, &HC, &H0, &H1, &H0, &H0, &H0, &H1, &H13, &H0, &H2E, &HC0}))

                .Add(New LevelscriptCommand({&H1E, &H4, &H0, &H0}))

                .Add(New LevelscriptCommand({&H2B, &HC, &H1, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}))
                .Add(New LevelscriptCommand({&H11, &H8, &H0, &H0, &H80, &H24, &HBC, &HD8}))
                .Add(New LevelscriptCommand({&H12, &H8, &H0, &H1, &H80, &H24, &HBC, &HD8}))
                .Add(New LevelscriptCommand({&H1C, &H4, &H0, &H0}))
                .Add(New LevelscriptCommand({&H4, &H4, &H0, &H1}))
                .Add(New LevelscriptCommand({&H2, &H4, &H0, &H0}))

                ChangeObjectBank(0, 0, -1)
            End With

            For Each c As LevelscriptCommand In Levelscript
                Application.DoEvents()
                If c.CommandType <> LevelscriptCommandTypes.LoadRomToRam Then Continue For
                If clLoadRomToRam.GetSegmentedID(c) <> &HE Then Continue For
            Next

            HardcodedCameraSettings = False
            ActSelector = ActSelectorDefaultValues(LevelIndex)
        End Sub
        Public Sub New()
        End Sub

        Public Sub SetSegmentedBanks(rommgr As RomManager)
            For Each cmd As LevelscriptCommand In Levelscript
                Select Case cmd.CommandType
                    Case LevelscriptCommandTypes.LoadRomToRam, LevelscriptCommandTypes.x1A, LevelscriptCommandTypes.x18
                        cmd.Position = 0
                        Dim bankID As Byte = clLoadRomToRam.GetSegmentedID(cmd)
                        Dim startAddr As Integer = clLoadRomToRam.GetRomStart(cmd)
                        Dim endAddr As Integer = clLoadRomToRam.GetRomEnd(cmd)
                        Dim seg As SegmentedBank = rommgr.SetSegBank(bankID, startAddr, endAddr)
                        If cmd.CommandType = LevelscriptCommandTypes.x1A Then seg.MakeAsMIO0()
                End Select
            Next

            If bank0x19 IsNot Nothing Then
                rommgr.SetSegBank(bank0x19)
            End If
        End Sub

        Public Function GetDefaultPositionCmd() As LevelscriptCommand
            Return Levelscript.FirstOrDefault(Function(n) n.CommandType = LevelscriptCommandTypes.DefaultPosition)
        End Function

        Public Sub Load(rommgr As RomManager, LevelID As UShort, Levelindex As Byte, segAddress As UInteger)
            Dim customBGStart As Integer = 0
            Dim customBGEnd As Integer = 0

            Me._SM64EditorMode = SM64EditorMode
            Me.LevelID = LevelID

            Me.bank0x19 = rommgr.GetSegBank(&H19)
            bank0x19.ReadDataIfNull(rommgr.RomFile)

            If Not Closed Then Close()
            Closed = False

            'Load Bank 0x19
            bank0x19.ReadData(rommgr)

            'Lade Levelscript
            _Levelscript = New Levelscript
            Levelscript.Read(rommgr, segAddress)

            'Erstelle Areas / Lade Einstellungen
            Dim AreaOnFly As Boolean = False
            Dim tArea As LevelArea = Nothing
            Dim CurrentLevelScriptCommands = Levelscript.ToArray
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
                        Levelscript.Remove(c)
                        Areas.Add(tArea)
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
                    Levelscript.Remove(c)
                    tArea.Levelscript.Add(c)
                End If
            Next

            'Lösche alle Jump-Commands aus dem Levelscript
            For Each cmd As LevelscriptCommand In cmdsToRemove
                Levelscript.Remove(cmd)
                cmd.Close()
            Next

            'Lösche alle Objekte und Warps aus dem Levelscript
            Dim lvlscrptidstoremove = {LevelscriptCommandTypes.Normal3DObject, LevelscriptCommandTypes.ConnectedWarp, LevelscriptCommandTypes.PaintingWarp, LevelscriptCommandTypes.InstantWarp}
            For Each a In Areas
                For Each c In a.Levelscript.Where(Function(n) lvlscrptidstoremove.Contains(n.CommandType)).ToArray
                    a.Levelscript.Remove(c)
                Next
            Next

            'Lese Custom Background Image
            Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
            Dim br2 As New BinaryReader(fs)
            Background.Enabled = False
            For Each a As LevelArea In Areas
                Dim bgglcmd As GeolayoutCommand = a.Geolayout.Geolayoutscript.GetFirst(GeolayoutCommandTypes.Background)
                If cgBackground.GetBackgroundPointer(bgglcmd) = 0 Then
                    a.Background.Type = AreaBGs.Color
                    a.Background.Color = cgBackground.GetRrgbaColor(bgglcmd)
                Else
                    a.Background.Type = AreaBGs.Levelbackground
                    Background.ID = cgBackground.GetBackgroundID(bgglcmd)
                    Background.Enabled = True
                End If
            Next
            If Background.Enabled AndAlso Background.ID = Geolayout.BackgroundIDs.Custom Then
                fs.Position = customBGStart
                Background.ReadImage(fs, customBGStart)
            End If

            Dim bank0x19RomStart As Integer
            Dim bank0x19RomEnd As Integer
            Dim brToUse As BinaryReader
            bank0x19RomStart = 0
            bank0x19RomEnd = bank0x19.Length
            brToUse = New BinaryReader(bank0x19.Data)

            'Lese Area-Table
            For Each a As LevelArea In Areas
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
            For Each a As LevelArea In Areas
                a.AreaModel.FromStream(fs, a.Bank0x0EOffset, &HE000000, a.Fast3DBankRomStart, a.Fast3DLength, a.Geolayout.Geopointers.ToArray, a.CollisionPointer)
            Next

            'Lese alle Box-Daten
            Dim CurrentBoxOffset As Integer = bank0x19RomStart + &H6A00
            For Each a As LevelArea In Areas
                a.SpecialBoxes.Clear()
                a.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Water, bank0x19RomStart, bank0x19RomStart + &H6000 + (&H50 * a.AreaID)))
                a.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.ToxicHaze, bank0x19RomStart, bank0x19RomStart + &H6280 + (&H50 * a.AreaID)))
                a.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Mist, bank0x19RomStart, bank0x19RomStart + &H6500 + (&H50 * a.AreaID)))
            Next

            'One-Bank-0xE-System
            OneBank0xESystemEnabled = True

            'Act Selector
            PatchClass.Openfs(fs)
            ActSelector = PatchClass.ActSelector_Enabled(LevelID)

            'Hardcoded Camera
            PatchClass.HardcodedCamera_Enabled(LevelID) = HardcodedCameraSettings

            fs.Close()

            'Object-Banks
            ObjectBank0x0C = GetObjectBank0x0C()
            ObjectBank0x0D = GetObjectBank0x0D()
            ObjectBank0x0E = GetObjectBank0x0E()
        End Sub

        Public Sub Save(rommgr As RomManager, s As Stream, Levelindex As Byte, scriptOffset As Integer, ByRef fullLength As UInteger)
            Dim bw As New BinaryWriter(s)
            Dim bw0x19 As BinaryWriter = Nothing

            bank0x19 = rommgr.GetSegBank(&H19)
            bw0x19 = New BinaryWriter(bank0x19.Data)

            'Write Area Model & Update Scrolling Texture Vertex Pointers
            Dim CurrentRomOffset As UInteger = bank0x19.RomEnd
            For Each a As LevelArea In Areas
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
            If Background.ID = Geolayout.BackgroundIDs.Custom Then
                'Write Custom Background
                Background.WriteImage(s, customBGStart)

                'Write Pointer Table
                Dim bgPtrTable As Byte() = LevelBG.GetBackgroundPointerTable()
                s.Write(bgPtrTable, 0, bgPtrTable.Length)

                customBGEnd = customBGStart + Background.ImageLength + bgPtrTable.Length
                CurrentRomOffset += Background.ImageLength + bgPtrTable.Length
                HexRoundUp2(CurrentRomOffset)
            End If

            'Update Geolayouts
            For Each a As LevelArea In Areas
                'Update Backcolor Command
                Dim cmd As GeolayoutCommand = a.Geolayout.Geolayoutscript.GetFirst(GeolayoutCommandTypes.Background)
                If a.Background.Type = AreaBGs.Levelbackground AndAlso Background.Enabled Then
                    cgBackground.SetBackgroundPointer(cmd, &H802763D4)
                    cgBackground.SetBackgroundID(cmd, Background.ID)
                Else
                    cgBackground.SetBackgroundPointer(cmd, 0)
                    cgBackground.SetRgbaColor(cmd, a.Background.Color)
                End If
            Next

            'Write Geolayouts
            Dim GeoIndex As Integer = 0
            For Each a As LevelArea In Areas
                Dim geooffset As Integer = &H5000 + GeoIndex * &H1E0
                a.GeolayoutOffset = bank0x19.BankAddress + geooffset

                a.Geolayout.Write(bank0x19.Data, geooffset)
                a.Geolayout.NewGeoOffset = bank0x19.RomStart + geooffset

                GeoIndex += 1
            Next

            'Füge Show-Dialog-Command & 2D-Camera-Object ein
            For Each a As LevelArea In Areas
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

            For Each a As LevelArea In Areas
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

            fullLength = firstBank0xE.RomEnd - bank0x19.RomStart

            'Füge Area dem Levelscript hinzu
            Dim cIndex2 = Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1E)
            For Each a In Areas
                For Each c In a.Levelscript
                    Levelscript.Insert(cIndex2, c)
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

            For Each c In Levelscript
                Select Case c.CommandType
                    Case LevelscriptCommandTypes.StartArea
                        tArea = Areas(CurrentAreaIndex)
                        Dim areaid As Byte = tArea.AreaID
                        areaidindex.Add(areaid, areaidindex.Count)
                        clStartArea.SetSegGeolayoutAddr(c, Areas(CurrentAreaIndex).Geolayout.NewGeoOffset - bank0x19.RomStart + bank0x19.BankAddress)
                        areaobjwarpindextoinsertdic.Add(areaid, Levelscript.IndexOf(c) + 1)

                    Case LevelscriptCommandTypes.EndOfArea

                        If Not foundCmdShowMsg AndAlso tArea.ShowMessage.Enabled Then
                            Dim cmdShowMsg As New LevelscriptCommand($"30 04 00 {tArea.ShowMessage.DialogID.ToString("X2")}")
                            cmdsToInsertAt.Add(c, cmdShowMsg)
                        End If

                        foundCmdShowMsg = False
                        CurrentAreaIndex += 1
                        tArea = Nothing

                    Case LevelscriptCommandTypes.AreaMusic
                        clAreaMusic.SetMusicID(c, Areas(CurrentAreaIndex).BGMusic)

                    Case LevelscriptCommandTypes.AreaMusicSimple
                        clAreaMusicSimple.SetMusicID(c, Areas(CurrentAreaIndex).BGMusic)

                    Case LevelscriptCommandTypes.Tarrain
                        clTerrian.SetTerrainType(c, Areas(CurrentAreaIndex).TerrainType)

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
                'For Each c In Areas(areaidindex(e.Key)).WarpsForGame
                '    Levelscript.Insert(e.Value, c)
                '    curFirstBank0xEOffset += c.Length
                'Next

                Dim segStartAddr As UInteger = areaobjwarpoffsetdic(e.Key)
                Levelscript.Insert(e.Value, New LevelscriptCommand({&H6, 8, 0, 0, (segStartAddr >> 24) And &HFF, (segStartAddr >> 16) And &HFF, (segStartAddr >> 8) And &HFF, segStartAddr And &HFF}))
            Next

            'Lösche Commands
            For Each cmd As LevelscriptCommand In cmdsToRemove
                Levelscript.Remove(cmd)
            Next

            'Füge neue Commands ein
            For Each kvp As KeyValuePair(Of LevelscriptCommand, LevelscriptCommand) In cmdsToInsertAt
                Dim index As Integer = Levelscript.IndexOf(kvp.Key)
                Levelscript.Insert(index, kvp.Value)
            Next

            'Füge Background-Command ein
            If Background.Enabled Then
                Dim newbgcmd As LevelscriptCommand = If(cmdBgSegLoad, New LevelscriptCommand({&H17, &HC, 0, &HA, 0, 0, 0, 0, 0, 0, 0, 0}))

                If Background.ID = Geolayout.BackgroundIDs.Custom Then
                    clLoadRomToRam.SetRomStart(newbgcmd, customBGStart)
                    clLoadRomToRam.SetRomEnd(newbgcmd, customBGEnd)
                Else
                    clLoadRomToRam.SetRomStart(newbgcmd, GetBackgroundAddressOfID(Background.ID, False))
                    clLoadRomToRam.SetRomEnd(newbgcmd, GetBackgroundAddressOfID(Background.ID, True))
                End If

                If Not Levelscript.Contains(newbgcmd) Then
                    Dim indexoffirstx1e As Integer = Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1D)
                    Levelscript.Insert(indexoffirstx1e, newbgcmd)
                End If

            ElseIf cmdBgSegLoad IsNot Nothing Then
                Levelscript.Remove(cmdBgSegLoad)
            End If

            'Write Levelscript
            Levelscript.Write(bank0x19.Data, scriptOffset)

            'Parse Levelscript again!
            Dim AreaOnFly As Boolean = False
            For Each c In Levelscript.ToArray
                Select Case c.CommandType
                    Case LevelscriptCommandTypes.StartArea
                        AreaOnFly = True
                    Case LevelscriptCommandTypes.EndOfArea
                        AreaOnFly = False
                        Levelscript.Remove(c)
                End Select
                If AreaOnFly Then Levelscript.Remove(c)
            Next

            'Write Level Start (Start of Bank 0x19)
            bank0x19.Data.Position = 0
            For Each b As Byte In LevelscriptStart
                bw0x19.Write(b)
            Next

            Dim bwToUse As BinaryWriter = If(bw0x19, bw)

            'Write 4 checkbytes for the One-0xE-Bank-Per-Area-Code
            bank0x19.Data.Position = &H5FFC
            bwToUse.Write(SwapInts.SwapInt32(&H4BC9189A))

            'Write Area Table
            For Each a As LevelArea In Me.Areas
                Dim off As UInteger = &H5F00 + (a.AreaID * &H10)
                bank0x19.Data.Position = off
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
            For Each a As LevelArea In Areas
                Dim TableIndex() As Integer = {0, &H32, &H33}
                Dim TableOffset() As Integer = {bank0x19RomStart + &H6000 + (&H50 * a.AreaID),
                    bank0x19RomStart + &H6280 + (&H50 * a.AreaID),
                    bank0x19RomStart + &H6500 + (&H50 * a.AreaID)}

                For Each w As SpecialBox In a.SpecialBoxes
                    'Write Table Entry
                    bwToUse.BaseStream.Position = TableOffset(CInt(w.Type))
                    bwToUse.Write(SwapInts.SwapInt16(TableIndex(CInt(w.Type))))
                    bwToUse.Write(SwapInts.SwapInt16(&H0))
                    bwToUse.Write(SwapInts.SwapInt32(CurrentBoxOffset - bank0x19RomStart + bank0x19.BankAddress))
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
            bank0x19.WriteData(s)

            'Hardcoded Camera Settings & Act Selector
            PatchClass.Openfs(s)
            HardcodedCameraSettings = PatchClass.HardcodedCamera_Enabled(LevelID)
            PatchClass.ActSelector_Enabled(LevelID) = ActSelector
        End Sub

        Public Sub ChangeObjectBank(BankEntries As ObjectBank0x0C)
            ChangeObjectBank(1, CInt(BankEntries) - 1, CInt(ObjectBank0x0C) - 1)
            ObjectBank0x0C = BankEntries
        End Sub
        Public Function GetObjectBank0x0C() As ObjectBank0x0C
            Return CType(GetObjectBank(1) + 1, ObjectBank0x0C)
        End Function

        Public Sub ChangeObjectBank(BankEntries As ObjectBank0x0D)
            ChangeObjectBank(2, CInt(BankEntries) - 1, CInt(ObjectBank0x0D) - 1)
            ObjectBank0x0D = BankEntries
        End Sub
        Public Function GetObjectBank0x0D() As ObjectBank0x0D
            Return CType(GetObjectBank(2) + 1, ObjectBank0x0D)
        End Function

        Public Sub ChangeObjectBank(BankEntries As ObjectBank0x0E)
            ChangeObjectBank(3, CInt(BankEntries) - 1, CInt(ObjectBank0x0E) - 1)
            ObjectBank0x0E = BankEntries
        End Sub
        Public Function GetObjectBank0x0E() As ObjectBank0x0E
            Return CType(GetObjectBank(3) + 1, ObjectBank0x0E)
        End Function

        Private Sub ChangeObjectBank(BankIndex As Integer, NewEntryIndex As Integer, OldEntryIndex As Integer)
            Dim oldiniindex As String = GetObjectBankSectionNameOfIndex(BankIndex, OldEntryIndex)
            Dim newiniindex As String = GetObjectBankSectionNameOfIndex(BankIndex, NewEntryIndex)

            'Remove old commands
            If OldEntryIndex = -1 Then GoTo AddCmds

            For Each cmditem As String In {"cmd22", "cmd06", "cmd1A", "cmd17"}
                Dim tKeyValue As String = ObjectBankData(BankIndex)(oldiniindex)(cmditem)
                If tKeyValue = String.Empty Then Continue For

                For Each s As String In tKeyValue.Split("|")
                    Dim stringBytes() As String = s.Split(" ")

                    Dim bytesList As New List(Of Byte)
                    For Each sb As String In stringBytes
                        If Not sb = String.Empty Then bytesList.Add(CByte("&H" & sb))
                    Next

                    For Each cmd In Levelscript.Where(Function(n) CompareTwoByteArrays(n.ToArray, bytesList.ToArray)).ToArray
                        cmd.Close()
                        Levelscript.Remove(cmd)
                    Next
                Next
            Next

AddCmds:'Add new commands
            If NewEntryIndex = -1 Then Return

            For Each cmditem As String In {"cmd22", "cmd06", "cmd1A", "cmd17"}
                Dim tKeyValue As String = ObjectBankData(BankIndex)(newiniindex)(cmditem)
                If tKeyValue = String.Empty Then Continue For

                Dim startIndex As Integer = Levelscript.IndexOfFirst(LevelscriptCommandTypes.x1D)
                If Not (cmditem.EndsWith("1A") OrElse cmditem.EndsWith("17")) Then
                    startIndex += 1
                End If

                For Each s As String In tKeyValue.Split("|")
                    Dim stringBytes() As String = s.Split(" ")

                    Dim bytesList As New List(Of Byte)
                    For Each sb As String In stringBytes
                        If Not sb = String.Empty Then bytesList.Add(CByte("&H" & sb))
                    Next

                    Dim cmd As New LevelscriptCommand(bytesList.ToArray)
                    Levelscript.Insert(startIndex, cmd)
                    startIndex += 1
                Next
            Next
        End Sub

        Private Function GetObjectBank(BankIndex As Integer) As Integer
            Dim Found As New List(Of Boolean)

            For Each s In ObjectBankData(BankIndex).Sections
                For Each cmdkey In {"cmd22", "cmd06", "cmd1A", "cmd17"}
                    Dim tKeyValue As String = s.Keys(cmdkey)
                    If tKeyValue = String.Empty Then Continue For

                    For Each k As String In tKeyValue.Split("|")
                        Dim stringBytes() As String = k.Split(" ")

                        Dim bytesList As New List(Of Byte)
                        For Each sb As String In stringBytes
                            If Not sb = String.Empty Then bytesList.Add(CByte("&H" & sb))
                        Next

                        Found.Add(Levelscript.Where(Function(n) CompareTwoByteArrays(n.ToArray, bytesList.ToArray)).Count > 0)
                    Next
                Next

                If Not Found.Contains(False) Then Return GetObjectBankSectionIndexOfName(BankIndex, s.SectionName)
                Found.Clear()
            Next

            Return -1
        End Function

        Private Function GetObjectBankSectionNameOfIndex(Bank As Integer, Index As Integer) As String
            If Index < 0 Then Return ""
            Dim NameLists As New List(Of String)
            For Each s In ObjectBankData(Bank).Sections
                NameLists.Add(s.SectionName)
            Next
            Return NameLists(Index)
        End Function
        Private Function GetObjectBankSectionIndexOfName(Bank As Integer, Name As String) As Integer
            Dim cIndex As Integer = 0
            For Each s In ObjectBankData(Bank).Sections
                If s.SectionName = Name Then Return cIndex
                cIndex += 1
            Next
            Return 0
        End Function

        Public Sub Close()
            For Each c In Levelscript
                c.Close()
            Next
            Levelscript.Clear()
            For Each a In Areas
                a.Close()
            Next
            Areas.Clear()
            Closed = True
        End Sub

        Public ReadOnly Property ObjectsCount As Integer
            Get
                Dim tcount As Integer = 0
                For Each a In Areas
                    tcount += a.Objects.Count
                Next
                Return tcount
            End Get
        End Property
        Public ReadOnly Property WarpsCount As Integer
            Get
                Dim tcount As Integer = 0
                For Each a In Areas
                    tcount += a.Warps.Count
                Next
                Return tcount
            End Get
        End Property

        Public Overrides Function ToString() As String
            Dim output As String = ""
            For Each cmd In Levelscript
                Dim tbytelist As String = ""
                For Each b As Byte In cmd.ToArray
                    If tbytelist IsNot String.Empty Then tbytelist &= " "
                    tbytelist &= Hex(b)
                Next
                If output IsNot String.Empty Then output &= vbNewLine
                output &= tbytelist
            Next
            Return output
        End Function

        Shared Sub GetLevelIDList(Romfile As String, Optional LevelCount As Integer = 30)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.ReadWrite)
            GetLevelIDList(fs)
            fs.Close()
        End Sub
        Shared Function GetLevelIDList(ByRef fs As FileStream, Optional LevelCount As Integer = 30) As Byte()
            Dim br As New BinaryReader(fs)
            Dim tlist As New List(Of Byte)
            Console.WriteLine("Warning! Die Methode 'GetLevelIDList()' in der Klasse 'Level' wurde noch nicht getestet.")
            fs.Position = &H1202E50
            For i As Integer = 0 To LevelCount - 1
                fs.Position = GetLevelIDFromIndex(i)
                tlist.Add(br.ReadByte)
            Next
            Return tlist.ToArray
        End Function

    End Class

End Namespace