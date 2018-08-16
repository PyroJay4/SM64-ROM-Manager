Imports System.IO
Imports DevComponents.DotNetBar
Imports SettingsManager
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Patching
Imports SM64Lib.Text

Friend Module General

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

    Public Sub ReorderBoxDataPositions(BoxData As SM64Lib.Model.Collision.BoxData)
        Dim x1, x2, z1, z2 As Int16

        x1 = Math.Min(BoxData.X1, BoxData.X2)
        x2 = Math.Max(BoxData.X1, BoxData.X2)
        z1 = Math.Min(BoxData.Z1, BoxData.Z2)
        z2 = Math.Max(BoxData.Z1, BoxData.Z2)

        BoxData.X1 = x1
        BoxData.X2 = x2
        BoxData.Z1 = z1
        BoxData.Z2 = z2
    End Sub
    Public Sub ReorderBoxDataPositions(SpecialBox As Level.SpecialBox)
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

    Public Function GetSpecialBoxFromListItem(Item As Object, Boxes() As Level.SpecialBox) As Level.SpecialBox
        For Each b In Boxes
            If b.X1 = Item.Box.X1 And b.X2 = Item.Box.X2 And b.Z1 = Item.Box.Z1 And b.Z2 = Item.Box.Z2 Then Return b
        Next
        Return Nothing
    End Function

#Region "Level Background/Environment/Camera/etc."
    Public Function GetBackgroundAddressOfID(ID As Geolayout.BackgroundIDs, EndAddr As Boolean) As Geolayout.BackgroundPointers
        Select Case ID
            Case Geolayout.BackgroundIDs.AboveClouds
                If EndAddr Then Return Geolayout.BackgroundPointers.AboveCloudsEnd
                Return Geolayout.BackgroundPointers.AboveCloudsStart

            Case Geolayout.BackgroundIDs.BelowClouds
                If EndAddr Then Return Geolayout.BackgroundPointers.BelowCloudsEnd
                Return Geolayout.BackgroundPointers.BelowCloudsStart

            Case Geolayout.BackgroundIDs.Cavern
                If EndAddr Then Return Geolayout.BackgroundPointers.CavernEnd
                Return Geolayout.BackgroundPointers.CavernStart

            Case Geolayout.BackgroundIDs.Desert
                If EndAddr Then Return Geolayout.BackgroundPointers.DesertEnd
                Return Geolayout.BackgroundPointers.DesertStart

            Case Geolayout.BackgroundIDs.FlamingSky
                If EndAddr Then Return Geolayout.BackgroundPointers.FlamingSkyEnd
                Return Geolayout.BackgroundPointers.FlamingSkyStart

            Case Geolayout.BackgroundIDs.HauntedForest
                If EndAddr Then Return Geolayout.BackgroundPointers.HauntedForestEnd
                Return Geolayout.BackgroundPointers.HauntedForestStart

            Case Geolayout.BackgroundIDs.Ocean
                If EndAddr Then Return Geolayout.BackgroundPointers.OceanEnd
                Return Geolayout.BackgroundPointers.OceanStart

            Case Geolayout.BackgroundIDs.PurpleClouds
                If EndAddr Then Return Geolayout.BackgroundPointers.PurpleCloudsEnd
                Return Geolayout.BackgroundPointers.PurpleCloudsStart

            Case Geolayout.BackgroundIDs.SnowyMountains
                If EndAddr Then Return Geolayout.BackgroundPointers.SnowyMountainsEnd
                Return Geolayout.BackgroundPointers.SnowyMountainsStart

            Case Geolayout.BackgroundIDs.UnderwaterCity
                If EndAddr Then Return Geolayout.BackgroundPointers.UnderwaterCityEnd
                Return Geolayout.BackgroundPointers.UnderwaterCityStart

        End Select

        Return If(EndAddr, Geolayout.BackgroundPointers.OceanEnd, Geolayout.BackgroundPointers.OceanStart)
    End Function
    Public Function GetBackgroundIDOfAddress(StartAddr As Integer) As Geolayout.BackgroundIDs
        Select Case StartAddr
            Case Geolayout.BackgroundPointers.AboveCloudsStart : Return Geolayout.BackgroundIDs.AboveClouds
            Case Geolayout.BackgroundPointers.BelowCloudsStart : Return Geolayout.BackgroundIDs.BelowClouds
            Case Geolayout.BackgroundPointers.CavernStart : Return Geolayout.BackgroundIDs.Cavern
            Case Geolayout.BackgroundPointers.DesertStart : Return Geolayout.BackgroundIDs.Desert
            Case Geolayout.BackgroundPointers.FlamingSkyStart : Return Geolayout.BackgroundIDs.FlamingSky
            Case Geolayout.BackgroundPointers.HauntedForestStart : Return Geolayout.BackgroundIDs.HauntedForest
            Case Geolayout.BackgroundPointers.OceanStart : Return Geolayout.BackgroundIDs.Ocean
            Case Geolayout.BackgroundPointers.PurpleCloudsStart : Return Geolayout.BackgroundIDs.PurpleClouds
            Case Geolayout.BackgroundPointers.SnowyMountainsStart : Return Geolayout.BackgroundIDs.SnowyMountains
            Case Geolayout.BackgroundPointers.UnderwaterCityStart : Return Geolayout.BackgroundIDs.UnderwaterCity
            Case Else : Return Geolayout.BackgroundIDs.Custom
        End Select
    End Function
    Public Function GetBackgroundIDOfIndex(Index As Integer) As Geolayout.BackgroundIDs
        Select Case Index
            Case 0 : Return Geolayout.BackgroundIDs.HauntedForest
            Case 1 : Return Geolayout.BackgroundIDs.SnowyMountains
            Case 2 : Return Geolayout.BackgroundIDs.Desert
            Case 3 : Return Geolayout.BackgroundIDs.Ocean
            Case 4 : Return Geolayout.BackgroundIDs.UnderwaterCity
            Case 5 : Return Geolayout.BackgroundIDs.BelowClouds
            Case 6 : Return Geolayout.BackgroundIDs.AboveClouds
            Case 7 : Return Geolayout.BackgroundIDs.Cavern
            Case 8 : Return Geolayout.BackgroundIDs.FlamingSky
            Case 9 : Return Geolayout.BackgroundIDs.PurpleClouds
            Case 10 : Return Geolayout.BackgroundIDs.Custom
            Case Else : Return Geolayout.BackgroundIDs.Ocean
        End Select
    End Function
    Public Function GetBackgroundIndexOfID(ID As Geolayout.BackgroundIDs) As Integer
        Select Case ID
            Case Geolayout.BackgroundIDs.HauntedForest : Return 0
            Case Geolayout.BackgroundIDs.SnowyMountains : Return 1
            Case Geolayout.BackgroundIDs.Desert : Return 2
            Case Geolayout.BackgroundIDs.Ocean : Return 3
            Case Geolayout.BackgroundIDs.UnderwaterCity : Return 4
            Case Geolayout.BackgroundIDs.BelowClouds : Return 5
            Case Geolayout.BackgroundIDs.AboveClouds : Return 6
            Case Geolayout.BackgroundIDs.Cavern : Return 7
            Case Geolayout.BackgroundIDs.FlamingSky : Return 8
            Case Geolayout.BackgroundIDs.PurpleClouds : Return 9
            Case Geolayout.BackgroundIDs.Custom : Return 10
            Case Else : Return Geolayout.BackgroundIDs.Ocean : Return 0
        End Select
    End Function
    Public Function GetEnvironmentTypeOfIndex(Index As Integer) As Geolayout.EnvironmentEffects
        Select Case Index
            Case 0 : Return Geolayout.EnvironmentEffects.NoEffect
            Case 1 : Return Geolayout.EnvironmentEffects.Snow
            Case 2 : Return Geolayout.EnvironmentEffects.Bllizard
            Case 3 : Return Geolayout.EnvironmentEffects.BetaFlower
            Case 4 : Return Geolayout.EnvironmentEffects.Lava
            Case 5 : Return Geolayout.EnvironmentEffects.WaterRelated1
            Case 6 : Return Geolayout.EnvironmentEffects.WaterRelated2
            Case Else : Return Geolayout.EnvironmentEffects.NoEffect
        End Select
    End Function
    Public Function GetEnvironmentIndexOfType(Type As Geolayout.EnvironmentEffects) As Integer
        Select Case Type
            Case Geolayout.EnvironmentEffects.NoEffect : Return 0
            Case Geolayout.EnvironmentEffects.Snow : Return 1
            Case Geolayout.EnvironmentEffects.Bllizard : Return 2
            Case Geolayout.EnvironmentEffects.BetaFlower : Return 3
            Case Geolayout.EnvironmentEffects.Lava : Return 4
            Case Geolayout.EnvironmentEffects.WaterRelated1 : Return 5
            Case Geolayout.EnvironmentEffects.WaterRelated2 : Return 6
            Case Else : Return 0
        End Select
    End Function
    Public Function GetCameraPresetTypeOfIndex(Index As Integer) As Geolayout.CameraPresets
        Return CType(Index + 1, Geolayout.CameraPresets)
    End Function
    Public Function GetCameraPresetIndexOfType(Type As Geolayout.CameraPresets) As Integer
        Return CInt(Type) - 1
    End Function
    Public Function GetAreaBGIndexOfID(ID As Level.AreaBGs) As Integer
        Return CInt(ID)
    End Function
    Public Function GetAreaBGIDOfIndex(Index As Integer) As Level.AreaBGs
        Return CType(Index, Level.AreaBGs)
    End Function
#End Region

End Module

Public Class ListBoxItemSM64Text
    Inherits ListBoxItem
    Private _TableType As TextTable.TableType = TextTable.TableType.Dialogs
    Public ReadOnly Property TableType As TextTable.TableType
        Get
            Return _TableType
        End Get
    End Property
    Public RefItem As Object = Nothing
    Public Property TextItem As TextItem
        Get
            Return RefItem
        End Get
        Set(value As TextItem)
            RefItem = value
        End Set
    End Property

    Public Sub New(TableType As TextTable.TableType)
        Me._TableType = TableType
    End Sub
End Class
