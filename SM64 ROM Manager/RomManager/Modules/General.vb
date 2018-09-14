Imports System.IO
Imports DevComponents.DotNetBar
Imports S3DFileParser
Imports SM64_ROM_Manager.SettingsManager
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Geolayout
Imports SM64Lib.Levels
Imports SM64Lib.Model.Fast3D.DisplayLists
Imports SM64Lib.Patching
Imports SM64Lib.Text

Friend Module General

    Public BehaviorInfos As New BehaviorInfoList
    Public ObjectCombos As New ObjectComboList
    Public PatchClass As New SM64PatchClass
    Public HasToolkitInit As Boolean = False

    Friend Sub SaveRom(rommgr As RomManager)
        If rommgr IsNot Nothing Then
            Dim dontpatchupdates As Boolean

            If rommgr.AreRomUpdatesAvaiable Then
                Select Case Settings.General.ActionIfUpdatePatches
                    Case DialogResult.Yes
                        dontpatchupdates = False
                    Case DialogResult.No
                        dontpatchupdates = True
                    Case Else
                        Dim tdi As New TaskDialogInfo(Form_Main_Resources.MsgBox_UpdatePatchesAvaiable_Title, eTaskDialogIcon.ShieldHelp, Form_Main_Resources.MsgBox_UpdatePatchesAvaiable_Title, Form_Main_Resources.MsgBox_UpdatePatchesAvaiable, eTaskDialogButton.Yes Or eTaskDialogButton.No Or eTaskDialogButton.Cancel)
                        tdi.CheckBoxCommand = New Command With {.Text = "Don't show this message again."}
                        Select Case TaskDialog.Show(tdi) 'MessageBoxEx.Show(Form_Main_Resources.MsgBox_UpdatePatchesAvaiable, Form_Main_Resources.MsgBox_UpdatePatchesAvaiable_Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                            Case eTaskDialogResult.Yes
                                dontpatchupdates = False
                                If tdi.CheckBoxCommand.Checked Then
                                    Settings.General.ActionIfUpdatePatches = DialogResult.Yes
                                End If
                            Case eTaskDialogResult.No
                                dontpatchupdates = True
                                If tdi.CheckBoxCommand.Checked Then
                                    Settings.General.ActionIfUpdatePatches = DialogResult.No
                                End If
                            Case Else
                                Return
                        End Select
                        If Not tdi.CheckBoxCommand.Checked Then
                            Settings.General.ActionIfUpdatePatches = DialogResult.None
                        End If
                End Select
            Else
                dontpatchupdates = False
            End If

            rommgr.SaveRom(, dontpatchupdates)
        End If
    End Sub

    Friend Sub LaunchRom(rommgr As RomManager)
        If rommgr?.RomFile <> "" Then
            Try
                If Settings.General.EmulatorPath <> "" Then
                    Process.Start(Settings.General.EmulatorPath, rommgr.RomFile)
                Else
                    Process.Start(rommgr.RomFile)
                End If
            Catch ex As Exception
                MessageBoxEx.Show(Form_Main_Resources.MsgBox_RomCanNotBestarted, Form_Main_Resources.MsgBox_RomCanNotBestarted_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Friend Async Function LoadAreaVisualMapAsObject3D(rommgr As RomManager, area As LevelArea) As Task(Of Object3D)
        Dim obj As New Object3D

        For Each geop As Geopointer In area.AreaModel.Fast3DBuffer.DLPointers
            Dim dl As New DisplayList
            Await dl.FromStreamAsync(geop, rommgr, area.AreaID)
            Await dl.ToObject3DAsync(obj, rommgr, area.AreaID)
        Next

        Return obj
    End Function

    Public Sub RunSM64TextureFix(ByRef ObjFile As String)
        Dim uvaObjFile As String = Path.GetDirectoryName(ObjFile) & "\" & Path.GetFileNameWithoutExtension(ObjFile) & "_uva" & Path.GetExtension(ObjFile)
        If Not File.Exists(uvaObjFile) OrElse File.GetLastWriteTime(uvaObjFile) < File.GetLastWriteTime(ObjFile) Then
            Application.DoEvents()
            If File.Exists(uvaObjFile) Then File.Delete(uvaObjFile)
            Application.DoEvents()
            Dim pExe As String = MyDataPath & "\Tools\SM64 Texture Fix for Obj-Files.exe"
            RunExeProcess(pExe, {ObjFile}, Path.GetDirectoryName(ObjFile), True)
        End If
        ObjFile = uvaObjFile
    End Sub

    Public Sub ReorderBoxDataPositions(SpecialBox As SpecialBox)
        Dim x1, x2, z1, z2 As Int16

        x1 = Math.Min(SpecialBox.X1, SpecialBox.X2)
        x2 = Math.Max(SpecialBox.X1, SpecialBox.X2)
        z1 = Math.Min(SpecialBox.Z1, SpecialBox.Z2)
        z2 = Math.Max(SpecialBox.Z1, SpecialBox.Z2)

        SpecialBox.X1 = x1
        SpecialBox.X2 = x2
        SpecialBox.Z1 = z1
        SpecialBox.Z2 = z2
    End Sub

    Public Function GetSpecialBoxFromListItem(Item As Object, Boxes() As SpecialBox) As SpecialBox
        For Each b In Boxes
            If b.X1 = Item.Box.X1 And b.X2 = Item.Box.X2 And b.Z1 = Item.Box.Z1 And b.Z2 = Item.Box.Z2 Then Return b
        Next
        Return Nothing
    End Function

#Region "Level Background/Environment/Camera/etc."
    Public Function GetBackgroundAddressOfID(ID As BackgroundIDs, EndAddr As Boolean) As BackgroundPointers
        Select Case ID
            Case BackgroundIDs.AboveClouds
                If EndAddr Then Return BackgroundPointers.AboveCloudsEnd
                Return BackgroundPointers.AboveCloudsStart

            Case BackgroundIDs.BelowClouds
                If EndAddr Then Return BackgroundPointers.BelowCloudsEnd
                Return BackgroundPointers.BelowCloudsStart

            Case BackgroundIDs.Cavern
                If EndAddr Then Return BackgroundPointers.CavernEnd
                Return BackgroundPointers.CavernStart

            Case BackgroundIDs.Desert
                If EndAddr Then Return BackgroundPointers.DesertEnd
                Return BackgroundPointers.DesertStart

            Case BackgroundIDs.FlamingSky
                If EndAddr Then Return BackgroundPointers.FlamingSkyEnd
                Return BackgroundPointers.FlamingSkyStart

            Case BackgroundIDs.HauntedForest
                If EndAddr Then Return BackgroundPointers.HauntedForestEnd
                Return BackgroundPointers.HauntedForestStart

            Case BackgroundIDs.Ocean
                If EndAddr Then Return BackgroundPointers.OceanEnd
                Return BackgroundPointers.OceanStart

            Case BackgroundIDs.PurpleClouds
                If EndAddr Then Return BackgroundPointers.PurpleCloudsEnd
                Return BackgroundPointers.PurpleCloudsStart

            Case BackgroundIDs.SnowyMountains
                If EndAddr Then Return BackgroundPointers.SnowyMountainsEnd
                Return BackgroundPointers.SnowyMountainsStart

            Case BackgroundIDs.UnderwaterCity
                If EndAddr Then Return BackgroundPointers.UnderwaterCityEnd
                Return BackgroundPointers.UnderwaterCityStart

        End Select

        Return If(EndAddr, BackgroundPointers.OceanEnd, BackgroundPointers.OceanStart)
    End Function
    Public Function GetBackgroundIDOfAddress(StartAddr As Integer) As BackgroundIDs
        Select Case StartAddr
            Case BackgroundPointers.AboveCloudsStart : Return BackgroundIDs.AboveClouds
            Case BackgroundPointers.BelowCloudsStart : Return BackgroundIDs.BelowClouds
            Case BackgroundPointers.CavernStart : Return BackgroundIDs.Cavern
            Case BackgroundPointers.DesertStart : Return BackgroundIDs.Desert
            Case BackgroundPointers.FlamingSkyStart : Return BackgroundIDs.FlamingSky
            Case BackgroundPointers.HauntedForestStart : Return BackgroundIDs.HauntedForest
            Case BackgroundPointers.OceanStart : Return BackgroundIDs.Ocean
            Case BackgroundPointers.PurpleCloudsStart : Return BackgroundIDs.PurpleClouds
            Case BackgroundPointers.SnowyMountainsStart : Return BackgroundIDs.SnowyMountains
            Case BackgroundPointers.UnderwaterCityStart : Return BackgroundIDs.UnderwaterCity
            Case Else : Return BackgroundIDs.Custom
        End Select
    End Function
    Public Function GetBackgroundIDOfIndex(Index As Integer) As BackgroundIDs
        Select Case Index
            Case 0 : Return BackgroundIDs.HauntedForest
            Case 1 : Return BackgroundIDs.SnowyMountains
            Case 2 : Return BackgroundIDs.Desert
            Case 3 : Return BackgroundIDs.Ocean
            Case 4 : Return BackgroundIDs.UnderwaterCity
            Case 5 : Return BackgroundIDs.BelowClouds
            Case 6 : Return BackgroundIDs.AboveClouds
            Case 7 : Return BackgroundIDs.Cavern
            Case 8 : Return BackgroundIDs.FlamingSky
            Case 9 : Return BackgroundIDs.PurpleClouds
            Case 10 : Return BackgroundIDs.Custom
            Case Else : Return BackgroundIDs.Ocean
        End Select
    End Function
    Public Function GetBackgroundIndexOfID(ID As BackgroundIDs) As Integer
        Select Case ID
            Case BackgroundIDs.HauntedForest : Return 0
            Case BackgroundIDs.SnowyMountains : Return 1
            Case BackgroundIDs.Desert : Return 2
            Case BackgroundIDs.Ocean : Return 3
            Case BackgroundIDs.UnderwaterCity : Return 4
            Case BackgroundIDs.BelowClouds : Return 5
            Case BackgroundIDs.AboveClouds : Return 6
            Case BackgroundIDs.Cavern : Return 7
            Case BackgroundIDs.FlamingSky : Return 8
            Case BackgroundIDs.PurpleClouds : Return 9
            Case BackgroundIDs.Custom : Return 10
            Case Else : Return BackgroundIDs.Ocean : Return 0
        End Select
    End Function
    Public Function GetEnvironmentTypeOfIndex(Index As Integer) As EnvironmentEffects
        Select Case Index
            Case 0 : Return EnvironmentEffects.NoEffect
            Case 1 : Return EnvironmentEffects.Snow
            Case 2 : Return EnvironmentEffects.Bllizard
            Case 3 : Return EnvironmentEffects.BetaFlower
            Case 4 : Return EnvironmentEffects.Lava
            Case 5 : Return EnvironmentEffects.WaterRelated1
            Case 6 : Return EnvironmentEffects.WaterRelated2
            Case Else : Return EnvironmentEffects.NoEffect
        End Select
    End Function
    Public Function GetEnvironmentIndexOfType(Type As EnvironmentEffects) As Integer
        Select Case Type
            Case EnvironmentEffects.NoEffect : Return 0
            Case EnvironmentEffects.Snow : Return 1
            Case EnvironmentEffects.Bllizard : Return 2
            Case EnvironmentEffects.BetaFlower : Return 3
            Case EnvironmentEffects.Lava : Return 4
            Case EnvironmentEffects.WaterRelated1 : Return 5
            Case EnvironmentEffects.WaterRelated2 : Return 6
            Case Else : Return 0
        End Select
    End Function
    Public Function GetCameraPresetTypeOfIndex(Index As Integer) As CameraPresets
        Return CType(Index + 1, CameraPresets)
    End Function
    Public Function GetCameraPresetIndexOfType(Type As CameraPresets) As Integer
        Return CInt(Type) - 1
    End Function
    Public Function GetAreaBGIndexOfID(ID As AreaBGs) As Integer
        Return CInt(ID)
    End Function
    Public Function GetAreaBGIDOfIndex(Index As Integer) As AreaBGs
        Return CType(Index, AreaBGs)
    End Function
#End Region

End Module
