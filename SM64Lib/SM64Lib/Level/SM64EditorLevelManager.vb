Imports System.IO
Imports SM64Lib.Model
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports SM64Lib.Geolayout.Script
Imports SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Data
Imports SM64Lib.SegmentedBanking

Namespace Levels

    Public Class SM64EditorLevelManager
        Implements ILevelManager

        ''' <summary>
        ''' Loads a SM64 Editor Level from ROM.
        ''' </summary>
        ''' <param name="lvl"></param>
        ''' <param name="rommgr"></param>
        ''' <param name="LevelID"></param>
        ''' <param name="segAddress"></param>
        Public Sub LoadLevel(lvl As Level, rommgr As RomManager, LevelID As UShort, segAddress As UInteger) Implements ILevelManager.LoadLevel
            Dim customBGStart As Integer = 0
            Dim customBGEnd As Integer = 0

            lvl.LevelID = LevelID

            'Load Bank 0x19
            lvl.Bank0x19 = rommgr.GetSegBank(&H19)
            lvl.Bank0x19.ReadDataIfNull(rommgr.RomFile)
            If lvl.Bank0x19.Length < &H10000 Then
                lvl.Bank0x19.Length = &H10000
            End If

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
                        If clNormal3DObject.GetSegBehaviorAddr(c) = &H13003420 Then
                            'tArea.ScrollingTextures.Add(New ManagedScrollingTexture(c))
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

                        Select Case bankID
                            Case &HA 'Background-Image
                                customBGStart = startAddr
                                customBGEnd = endAddr - &H140
                            Case &HE
                                rommgr.SetSegBank(bankID, startAddr, endAddr)
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
            lvl.CreateNewLevelscript()

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
            bank0x19RomEnd = lvl.Bank0x19.Length
            brToUse = New BinaryReader(lvl.Bank0x19.Data)

            'Lese Area-Modelle
            Dim modelBank As SegmentedBank = rommgr.GetSegBank(&HE)
            Dim curMdlStartOffset As Integer = modelBank.RomStart
            For i As Integer = 0 To lvl.Areas.Count - 1
                Dim a As LevelArea = lvl.Areas(i)
                Dim newEndOffset As Integer = GetModelEnd(fs, modelBank.RomStart, i)
                a.Bank0x0EOffset = curMdlStartOffset
                rommgr.SetSegBank(&HE, a.Bank0x0EOffset, newEndOffset, a.AreaID)

                a.AreaModel.Collision = New Collision.CollisionMap
                a.AreaModel.Collision.FromStream(fs, modelBank.SegToRomAddr(a.CollisionPointer))
                a.AreaModel.Fast3DBuffer = New Fast3D.Fast3DBuffer
                a.AreaModel.FromStream(fs, modelBank.RomStart, &HE000000, curMdlStartOffset, newEndOffset - curMdlStartOffset, a.Geolayout.Geopointers.ToArray, a.CollisionPointer)

                a.AreaModel.Collision.SpecialBoxes.Clear()

                curMdlStartOffset = newEndOffset
            Next

            'Lese alle Box-Daten
            firstArea.SpecialBoxes.Clear()
            firstArea.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Water, bank0x19RomStart, bank0x19RomStart + &H1810))
            firstArea.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.ToxicHaze, bank0x19RomStart, bank0x19RomStart + &H1850))
            firstArea.SpecialBoxes.AddRange(SpecialBoxList.ReadTable(brToUse.BaseStream, SpecialBoxType.Mist, bank0x19RomStart, bank0x19RomStart + &H18A0))

            Dim areaWithBoxData As LevelArea = lvl.Areas.FirstOrDefault(Function(n) n.AreaModel.Collision.SpecialBoxes.Any)
            If areaWithBoxData IsNot Nothing Then
                For i As Integer = 0 To firstArea.SpecialBoxes.Count - 1
                    Dim boxdata As Collision.BoxData = firstArea.AreaModel.Collision.SpecialBoxes.ElementAtOrDefault(i)
                    If boxdata IsNot Nothing Then
                        firstArea.SpecialBoxes(i).Y = boxdata.Y
                    End If
                Next
            End If

            'One-Bank-0xE-System
            lvl.OneBank0xESystemEnabled = True

            'Act Selector
            PatchClass.Open(fs)
            lvl.ActSelector = PatchClass.ActSelector_Enabled(LevelID)

            'Hardcoded Camera
            lvl.HardcodedCameraSettings = PatchClass.HardcodedCamera_Enabled(LevelID)

            fs.Close()

            'Object-Banks
            lvl.ObjectBank0x0C = ObjectBank0x0C.Disabled
            lvl.ObjectBank0x0D = ObjectBank0x0D.Disabled
            lvl.ObjectBank0x0E = ObjectBank0x0E.Disabled
        End Sub

        Public Function SaveLevel(lvl As Level, rommgr As RomManager, output As BinaryData, ByRef curOff As UInteger) As LevelSaveResult Implements ILevelManager.SaveLevel
            Throw New NotImplementedException()
        End Function

        Private Shared Function GetModelEnd(s As Stream, startPos As Integer, areaIndex As Byte) As Integer
            Dim cb As Byte = 0
            Dim Ausnahmen As Integer = 0

            s.Position = startPos

            Do : cb = s.ReadByte
                If s.Position >= s.Length - 1 Then
                    Return s.Length
                ElseIf cb = &H1 Then
                    s.Position -= 1
                    For i As Integer = 1 To &H100
                        If s.ReadByte <> &H1 Then Continue Do
                    Next
                    If Ausnahmen = areaIndex Then
                        Exit Do
                    Else
                        Ausnahmen += 1
                    End If
                End If
            Loop

            Return s.Position
        End Function

    End Class

End Namespace
