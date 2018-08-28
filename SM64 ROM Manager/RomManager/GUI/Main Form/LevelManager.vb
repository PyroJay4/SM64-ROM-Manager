Imports System.IO, System.Text, System.Drawing
Imports System.Numerics
Imports DevComponents.DotNetBar
Imports IniParser, IniParser.Model, IniParser.Parser
Imports ModelConverterGUI
Imports S3DFileParser
Imports SettingsManager
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Levels.Script.Commands
Imports SM64Lib.Levels.ScrolTex
Imports SM64Lib.Model
Imports SM64Lib.Model.Collision

Partial Class Form_Main

    'Flags
    Private LM_LoadingAreaList As Boolean = False
    Private LM_SavingRom As Boolean = False
    Private LM_LoadingArea As Boolean = False
    Private LM_LoadingLevel As Boolean = False

    Private ReadOnly Property CurrentLevel As Levels.Level
        Get
            If ListBoxAdv_LM_Levels.SelectedIndex < 0 Then Return Nothing
            Return rommgr.Levels(ListBoxAdv_LM_Levels.SelectedIndex)
        End Get
    End Property
    Private ReadOnly Property CurrentLevelID As Byte
        Get
            If ListBoxAdv_LM_Levels.SelectedIndex < 0 Then Return Nothing
            Return rommgr.Levels(ListBoxAdv_LM_Levels.SelectedIndex).LevelID
        End Get
    End Property
    Private ReadOnly Property CurrentLevelIndex As Byte
        Get
            If ListBoxAdv_LM_Levels.SelectedIndex < 0 Then Return Nothing
            Return GetLevelIndexFromID(CurrentLevelID)
        End Get
    End Property
    Private ReadOnly Property CurrentArea As Levels.LevelArea
        Get
            Dim cl As Levels.Level = CurrentLevel
            Dim si As Integer = ListBoxAdv_LM_Areas.SelectedIndex
            If cl IsNot Nothing AndAlso si > -1 Then
                Return cl.Areas(si)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property AllowSavingLevelSettings As Boolean
        Get
            Return Not LoadingROM AndAlso Not LM_LoadingLevel AndAlso CurrentLevel IsNot Nothing
        End Get
    End Property
    Private ReadOnly Property AllowSavingAreaSettings As Boolean
        Get
            Return Not LoadingROM AndAlso Not LM_LoadingLevel AndAlso Not LM_LoadingAreaList AndAlso Not LM_LoadingArea AndAlso CurrentArea IsNot Nothing
        End Get
    End Property

    Private Sub LM_ReloadLevelListBox()
        ListBoxAdv_LM_Levels.Items.Clear()
        For Each e As Levels.Level In rommgr.Levels
            ListBoxAdv_LM_Levels.Items.Add(New ButtonItem With {.Text = rommgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = e.LevelID).Name})
        Next
        ListBoxAdv_LM_Levels.Refresh()
    End Sub
    Private Sub LM_LoadAreaList()
        LM_LoadingAreaList = True
        With ListBoxAdv_LM_Areas
            .Items.Clear()
            For Each a As Levels.LevelArea In CurrentLevel.Areas
                Dim btn As New ButtonItem
                btn.Text = Form_Main_Resources.Text_Area & " " & a.AreaID
                AddHandler btn.MouseUp, Sub() Button_LM_AreaEditor.Popup(Cursor.Position)
                .Items.Add(btn)
            Next
            If .Items.Count > 0 Then .SelectedItem = .Items(0)
        End With
        ListBoxAdv_LM_Areas.Refresh()
        LM_LoadingAreaList = False
    End Sub

    Private Sub LM_AddNewLevel() Handles Button_LM_AddNewLevel.Click
        Dim frm As New LevelSelectorDialog(rommgr)
        frm.rommgr = rommgr

        If frm.ShowDialog <> DialogResult.OK Then Return

        rommgr.AddLevel(frm.SelectedLevel.ID)
        rommgr.Levels.Last.ActSelector = (frm.SelectedLevel.Type = LevelInfoDataTabelList.LevelTypes.Level)

        ListBoxAdv_LM_Levels.Items.Add(New ButtonItem With {.Checked = False, .Text = rommgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = frm.SelectedLevel.ID).Name})
        ListBoxAdv_LM_Levels.Refresh()
        ListBoxAdv_LM_Levels.SelectedItem = ListBoxAdv_LM_Levels.Items(ListBoxAdv_LM_Levels.Items.Count - 1)
    End Sub
    Private Sub LM_AddNewArea() Handles Button_LM_AddArea.Click
        Dim ReamingIDs As New List(Of Byte)({&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H0})
        For Each a As Levels.LevelArea In CurrentLevel.Areas
            ReamingIDs.Remove(a.AreaID)
        Next
        If ReamingIDs.Count = 0 Then
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_MaxCountAreasReached, Form_Main_Resources.MsgBox_MaxCountAreasReached_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Button_LM_AddArea.Enabled = False
            Return
        End If

        Dim tArea As New Levels.LevelArea(ReamingIDs(0))
        Dim frm As New MainModelConverter
        frm.CheckBoxX_ConvertCollision.Enabled = False
        frm.CheckBoxX_ConvertModel.Enabled = False
ShowForm: If frm.ShowDialog <> DialogResult.OK Then Return

        tArea.AreaModel = frm.ResModel

        If ReamingIDs.Count = 1 Then Button_LM_AddArea.Enabled = False
        CurrentLevel.Areas.Add(tArea)
        LM_LoadAreaList()
        ListBoxAdv_LM_Areas.SelectedItem = ListBoxAdv_LM_Areas.Items(ListBoxAdv_LM_Areas.Items.Count - 1)
    End Sub
    Private Sub LM_RemoveArea() Handles Button_LM_RemoveArea.Click
        If LM_LoadingArea Then Return
        If LM_LoadingAreaList Then Return
        If Not FinishedLoading Then Return

        Dim index = ListBoxAdv_LM_Areas.SelectedIndex
        If index < 0 Then Return

        CurrentLevel.Areas.RemoveAt(index)

        Button_LM_AddArea.Enabled = True
        If CurrentLevel.Areas.Count = 0 Then TabControl_LM_Area.Enabled = False

        LM_LoadAreaList()
    End Sub

    Private Function LM_GetLengthOfAreas(Optional ExcaptIndex As Integer = -1) As Long
        LM_GetLengthOfAreas = 0
        Dim tIndex As Integer = 0
        For Each a As Levels.LevelArea In CurrentLevel.Areas
            If tIndex = ExcaptIndex Then Continue For
            LM_GetLengthOfAreas += a.AreaModel.Length
            tIndex += 1
        Next
        Return LM_GetLengthOfAreas
    End Function

    Private Sub LM_SaveObjectBank0D() Handles ComboBox_LM_OB0x0D.SelectedIndexChanged
        If AllowSavingLevelSettings Then CurrentLevel?.ChangeObjectBank(CType(ComboBox_LM_OB0x0D.SelectedIndex, Levels.ObjectBank0x0D))
    End Sub
    Private Sub LM_SaveObjectBank0C() Handles ComboBox_LM_OB0x0C.SelectedIndexChanged
        If AllowSavingLevelSettings Then CurrentLevel?.ChangeObjectBank(CType(ComboBox_LM_OB0x0C.SelectedIndex, Levels.ObjectBank0x0C))
    End Sub
    Private Sub LM_SaveObjectBank09() Handles ComboBox_LM_OB0x09.SelectedIndexChanged
        If AllowSavingLevelSettings Then CurrentLevel?.ChangeObjectBank(CType(ComboBox_LM_OB0x09.SelectedIndex, Levels.ObjectBank0x0E))
    End Sub

    Private Sub LM_SaveDefaultStartPosition() Handles NUD_LM_DefaultPositionYRotation.ValueChanged, NUD_LM_DefaultPositionAreaID.ValueChanged
        If AllowSavingLevelSettings Then
            With CurrentLevel
                clDefaultPosition.SetAreaID(CurrentLevel.GetDefaultPositionCmd, NUD_LM_DefaultPositionAreaID.Value)
                clDefaultPosition.SetRotation(CurrentLevel.GetDefaultPositionCmd, NUD_LM_DefaultPositionYRotation.Value)
            End With
        End If
    End Sub
    Private Sub LM_SaveActSelector() Handles SwitchButton_LM_ActSelector.ValueChanged
        If AllowSavingLevelSettings Then
            CurrentLevel.ActSelector = SwitchButton_LM_ActSelector.Value
        End If
    End Sub
    Private Sub LM_SaveHardcodedCameraSettings() Handles SwitchButton_LM_HardcodedCameraSettings.ValueChanged
        If AllowSavingLevelSettings Then
            CurrentLevel.HardcodedCameraSettings = SwitchButton_LM_HardcodedCameraSettings.Value
        End If
    End Sub
    Private Sub LM_SaveGameBackground() Handles ComboBox_LM_LevelBG.SelectedIndexChanged
        If AllowSavingLevelSettings Then
            With CurrentLevel.Background
                .ID = GetBackgroundIDOfIndex(ComboBox_LM_LevelBG.SelectedIndex)
                .Enabled = True
                .IsCustom = ComboBox_LM_LevelBG.SelectedIndex = 1
            End With
        End If
    End Sub
    Private Sub ComboBoxEx_LM_BGMode_SelectedIndexChanged() Handles ComboBoxEx_LM_BGMode.SelectedIndexChanged
        Me.SuspendLayout()

        ComboBox_LM_LevelBG.Visible = False
        Button_LM_LoadLevelBG.Visible = False
        PictureBox_BGImage.Image = Nothing

        Select Case ComboBoxEx_LM_BGMode.SelectedIndex
            Case 0 ' Game Image
                ComboBox_LM_LevelBG.Visible = True
                If CurrentLevel.Background.ID <> Geolayout.BackgroundIDs.Custom Then
                    ComboBox_LM_LevelBG.SelectedIndex = GetBackgroundIndexOfID(CurrentLevel.Background.ID)
                Else
                    ComboBox_LM_LevelBG.SelectedIndex = GetBackgroundIndexOfID(Geolayout.BackgroundIDs.Ocean)
                End If
                CurrentLevel.Background.Enabled = True
                CurrentLevel.Background.IsCustom = False
            Case 1 'Custom Image
                Button_LM_LoadLevelBG.Visible = True
                PictureBox_BGImage.Image = CurrentLevel.Background.GetImage
                CurrentLevel.Background.Enabled = True
                CurrentLevel.Background.IsCustom = True
            Case 2 'Disable
                CurrentLevel.Background.Enabled = False
                CurrentLevel.Background.IsCustom = False
        End Select

        Me.ResumeLayout()
    End Sub
    Private Sub ComboBoxEx_LM_AreaBG_SelectedIndexChanged() Handles ComboBoxEx_LM_AreaBG.SelectedIndexChanged
        Me.SuspendLayout()

        ColorPickerButton_LM_BackgroundColor.Visible = False

        Select Case ComboBoxEx_LM_AreaBG.SelectedIndex
            Case 0 'Levelbackground
                CurrentArea.Background.Type = Levels.AreaBGs.Levelbackground
            Case 1 'Color
                CurrentArea.Background.Type = Levels.AreaBGs.Color
                ColorPickerButton_LM_BackgroundColor.Visible = True
                ColorPickerButton_LM_BackgroundColor.SelectedColor = CurrentArea.Background.Color
        End Select

        Me.ResumeLayout()
    End Sub
    Private Sub LM_LoadCustomBackground() Handles Button_LM_LoadLevelBG.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "All supported Image files|*.png;*.jpeg;*.jpg;*.bmp;*.gif"

        If ofd.ShowDialog = DialogResult.OK Then
            Dim sImg As Stream = New MemoryStream(File.ReadAllBytes(ofd.FileName))
            Dim tBGImage As New Bitmap(sImg)

            If tBGImage.Size <> New Size(248, 248) And tBGImage.Size <> New Size(256, 256) Then
                MessageBoxEx.Show(Form_Main_Resources.MsgBox_InvalidBgImageSize, Form_Main_Resources.MsgBox_InvalidBgImageSize_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            With CurrentLevel.Background
                .SetImage(tBGImage)
                PictureBox_BGImage.Image = .GetImage()
                .ID = Geolayout.BackgroundIDs.Desert
                .IsCustom = True
                .Enabled = True
            End With

            sImg.Close()
        End If
    End Sub
    Private Sub LM_SaveAreaBackgorund() Handles ColorPickerButton_LM_BackgroundColor.SelectedColorChanged
        If AllowSavingAreaSettings Then
            With CurrentArea.Background
                .Type = Levels.AreaBGs.Color
                .Color = ColorPickerButton_LM_BackgroundColor.SelectedColor
            End With
        End If
    End Sub

    Private Sub LM_SaveTerrainType() Handles ComboBox_LM_TerrainTyp.SelectedIndexChanged
        If AllowSavingAreaSettings Then
            CurrentArea.TerrainType = CType(ComboBox_LM_TerrainTyp.SelectedIndex, Geolayout.TerrainTypes)
        End If
    End Sub
    Private Sub LM_SaveMusicID() Handles ComboBox_LM_Music.SelectedIndexChanged
        If AllowSavingAreaSettings Then
            CurrentArea.BGMusic = ComboBox_LM_Music.SelectedIndex
        End If
    End Sub
    Private Sub LM_SaveEnvironmentEffects() Handles ComboBox_LM_EnvironmentEffects.SelectedIndexChanged
        If AllowSavingAreaSettings Then
            CurrentArea.Geolayout.EnvironmentEffect = GetEnvironmentTypeOfIndex(ComboBox_LM_EnvironmentEffects.SelectedIndex)
        End If
    End Sub
    Private Sub LM_SaveCameraPreset() Handles ComboBox_LM_CameraPreset.SelectedIndexChanged
        If AllowSavingAreaSettings Then
            CurrentArea.Geolayout.CameraPreset = GetCameraPresetTypeOfIndex(ComboBox_LM_CameraPreset.SelectedIndex)
        End If
    End Sub
    Private Sub LM_Save2DCamera() Handles CheckBoxX_LM_Enable2DCamera.ValueChanged
        If AllowSavingAreaSettings Then
            CurrentArea.Enable2DCamera = CheckBoxX_LM_Enable2DCamera.Value
        End If
    End Sub

    Private Sub LM_ImportModel(sender As Object, e As EventArgs) Handles ButtonItem9.Click, ButtonItem13.Click, Button_ImportModel.Click
        Dim frm As New MainModelConverter
        frm.CheckBoxX_ConvertModel.Checked = sender Is Button_ImportModel OrElse sender Is ButtonItem9
        frm.CheckBoxX_ConvertCollision.Checked = sender Is Button_ImportModel OrElse sender Is ButtonItem13

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.SelectedIndex)
ShowForm:   If frm.ShowDialog() <> DialogResult.OK Then Return

            If frm.CheckBoxX_ConvertCollision.Checked AndAlso frm.CheckBoxX_ConvertModel.Checked Then
                Dim OldAreaModel As ObjectModel = .AreaModel
                .AreaModel = frm.ResModel
                .AreaModel.Collision.SpecialBoxes = OldAreaModel.Collision.SpecialBoxes
            ElseIf frm.CheckBoxX_ConvertCollision.Checked Then
                Dim OldAreaModel As ObjectModel = .AreaModel
                .AreaModel.Collision = frm.ResModel.Collision
                .AreaModel.Collision.SpecialBoxes = OldAreaModel.Collision.SpecialBoxes
            ElseIf frm.CheckBoxX_ConvertModel.Checked Then
                Dim OldAreaModel As ObjectModel = .AreaModel
                .AreaModel = frm.ResModel
                .AreaModel.Collision = OldAreaModel.Collision
            End If

            If frm.CheckBoxX_ConvertModel.Checked Then
                .ScrollingTextures.Clear()
                .ScrollingTextures.AddRange(.AreaModel.Fast3DBuffer.ConvertResult.ScrollingCommands.ToArray)
            End If

            .SetSegmentedBanks(rommgr)
        End With
    End Sub

    Private Sub LM_RemoveAllWaterBoxes(boxList As List(Of Levels.SpecialBox))
        Dim toremove() As Levels.SpecialBox = boxList.Where(Function(n) n.Type = Levels.SpecialBoxType.Water)
        For Each box As Levels.SpecialBox In toremove
            boxList.Remove(box)
        Next
    End Sub

    Private Sub LM_UpdateObjectBankList(sender As Object, e As EventArgs) Handles ComboBox_LM_OB0x0C.SelectedIndexChanged, ComboBox_LM_OB0x0D.SelectedIndexChanged, ComboBox_LM_OB0x09.SelectedIndexChanged
        Dim Index As Integer = 1
        Dim Text As String = ""
        Dim SelectedIndex As Integer = 0

        Select Case sender.GetHashCode
            Case ComboBox_LM_OB0x0C.GetHashCode
                SelectedIndex = ComboBox_LM_OB0x0C.SelectedIndex
                Text = ComboBox_LM_OB0x0C.SelectedItem.ToString
                Index = 1
                ListBoxAdv_LM_ContentOfOB0x0C.Items.Clear()
            Case ComboBox_LM_OB0x0D.GetHashCode
                SelectedIndex = ComboBox_LM_OB0x0D.SelectedIndex
                Text = ComboBox_LM_OB0x0D.SelectedItem.ToString
                Index = 2
                ListBoxAdv_LM_ContentOfOB0x0D.Items.Clear()
            Case ComboBox_LM_OB0x09.GetHashCode
                SelectedIndex = ComboBox_LM_OB0x09.SelectedIndex
                Text = ComboBox_LM_OB0x09.SelectedItem.ToString
                Index = 3
                ListBoxAdv_LM_ContentOfOB0x09.Items.Clear()
        End Select

        If SelectedIndex >= 1 Then
            For Each n As String In ObjectBankData(Index).Sections(Text)("List").Split("|")
                Select Case sender.GetHashCode
                    Case ComboBox_LM_OB0x0C.GetHashCode
                        ListBoxAdv_LM_ContentOfOB0x0C.Items.Add(New LabelItem With {.Text = n})
                    Case ComboBox_LM_OB0x0D.GetHashCode
                        ListBoxAdv_LM_ContentOfOB0x0D.Items.Add(New LabelItem With {.Text = n})
                    Case ComboBox_LM_OB0x09.GetHashCode
                        ListBoxAdv_LM_ContentOfOB0x09.Items.Add(New LabelItem With {.Text = n})
                End Select
            Next
        End If

        ListBoxAdv_LM_ContentOfOB0x0C.Refresh()
        ListBoxAdv_LM_ContentOfOB0x0D.Refresh()
        ListBoxAdv_LM_ContentOfOB0x09.Refresh()
    End Sub

    Private Function LM_GetNewSpecialBoxListViewItem() As ListViewItem
        Dim lvi As New ListViewItem
        With lvi
            For i As Integer = 0 To 7
                .SubItems.Add(New ListViewItem.ListViewSubItem)
            Next
        End With
        Return lvi
    End Function
    Private Function LM_GetNewSpecialBoxListViewItem(bd As BoxData, sd As Levels.SpecialBox, ItemNumber As Integer) As ListViewItem
        Dim lvi As ListViewItem = Me.LM_GetNewSpecialBoxListViewItem
        LM_UpdateSpecialBoxListViewItem(lvi, bd, sd, ItemNumber)
        Return lvi
    End Function
    Private Sub LM_UpdateSpecialBoxListViewItem(lvi As ListViewItem, bd As BoxData, sd As Levels.SpecialBox, ItemNumber As Integer)
        With lvi
            .Tag = bd
            .Text = ItemNumber
            .SubItems(1).Text = sd.Type.ToString
            .SubItems(2).Text = bd.X1
            .SubItems(3).Text = bd.Z1
            .SubItems(4).Text = bd.X2
            .SubItems(5).Text = bd.Z2
            .SubItems(6).Text = bd.Y
            .SubItems(7).Text = If(sd.Type = Levels.SpecialBoxType.Water, If(sd.InvisibleWater, Form_Main_Resources.Text_Invisible, sd.WaterType.ToString), "-")
        End With
    End Sub

    Private Sub LM_ListViewSpecialsAktuallisieren()
        ListViewEx_LM_Specials.Items.Clear()

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.SelectedIndex)
            For i As Integer = 0 To .AreaModel.Collision.SpecialBoxes.Count - 1
                Dim bd As BoxData = .AreaModel.Collision.SpecialBoxes(i)
                Dim typeToSelect As Levels.SpecialBoxType = Levels.SpecialBoxType.Water
                Dim lvgToSelect As ListViewGroup = Nothing

                Select Case bd.Type
                    Case BoxDataType.Water
                        typeToSelect = Levels.SpecialBoxType.Water
                        lvgToSelect = lvg_SpecialBox_Water
                    Case BoxDataType.ToxicHaze
                        typeToSelect = Levels.SpecialBoxType.ToxicHaze
                        lvgToSelect = lvg_SpecialBox_ToxicHaze
                    Case BoxDataType.Mist
                        typeToSelect = Levels.SpecialBoxType.Mist
                        lvgToSelect = lvg_SpecialBox_Mist
                End Select

                Dim lvi As ListViewItem = LM_GetNewSpecialBoxListViewItem(bd, .SpecialBoxes.GetSpecialBox(bd, typeToSelect), lvgToSelect.Items.Count + 1)
                lvi.Group = lvgToSelect

                ListViewEx_LM_Specials.Items.Add(lvi)
            Next
        End With

        ListViewEx_LM_Specials.Refresh()
    End Sub

    Private Sub Button_LM_AddEditSpecial_Click(sender As Object, e As EventArgs) Handles Button_LM_EditSpecial.Click, Button_LM_AddSpecial.Click
        If LM_LoadingLevel Then Return
        Dim bd As BoxData = Nothing
        Dim sb As Levels.SpecialBox = Nothing
        Dim lvi As ListViewItem = Nothing

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.SelectedIndex)
            Dim frm As Form_AddSpecialItem = Nothing

            If sender Is Button_LM_EditSpecial Then
                lvi = ListViewEx_LM_Specials.SelectedItems(0)
                bd = lvi.Tag
                If lvi.Group Is lvg_SpecialBox_Water Then
                    sb = .SpecialBoxes.GetSpecialBox(bd, Levels.SpecialBoxType.Water)
                ElseIf lvi.Group Is lvg_SpecialBox_Mist Then
                    sb = .SpecialBoxes.GetSpecialBox(bd, Levels.SpecialBoxType.Mist)
                ElseIf lvi.Group Is lvg_SpecialBox_ToxicHaze Then
                    sb = .SpecialBoxes.GetSpecialBox(bd, Levels.SpecialBoxType.ToxicHaze)
                End If
            Else
                bd = New BoxData
                sb = New Levels.SpecialBox
                lvi = LM_GetNewSpecialBoxListViewItem()
            End If

            frm = New Form_AddSpecialItem(sb, bd)
            If frm.ShowDialog <> DialogResult.OK Then Return

            Dim newType As Levels.SpecialBoxType
            Select Case True
                Case frm.CheckBoxX_Water.Checked
                    newType = Levels.SpecialBoxType.Water
                    lvi.Group = lvg_SpecialBox_Water
                Case frm.CheckBoxX_Mist.Checked
                    newType = Levels.SpecialBoxType.Mist
                    lvi.Group = lvg_SpecialBox_Mist
                Case frm.CheckBoxX_ToxicHaze.Checked
                    newType = Levels.SpecialBoxType.ToxicHaze
                    lvi.Group = lvg_SpecialBox_ToxicHaze
            End Select

            'Define new Type for BoxData
            Select Case True
                Case frm.CheckBoxX_Water.Checked
                    bd.Type = BoxDataType.Water
                Case frm.CheckBoxX_Mist.Checked
                    bd.Type = BoxDataType.Mist
                Case frm.CheckBoxX_ToxicHaze.Checked
                    bd.Type = BoxDataType.ToxicHaze
            End Select

            'Reorder Positions in BoxData
            ReorderBoxDataPositions(sb)
            ReorderBoxDataPositions(bd)

            If sender Is Button_LM_AddSpecial Then
                'Get new Itemnumber
                Dim newItemNumber As Integer = .SpecialBoxes.Where(Function(n) n.Type = newType).Count + 1

                'Define new Type for SpecialBox
                sb.Type = newType

                'Add new SpecialBox
                .SpecialBoxes.Add(sb)

                'Add new BoxData
                .AreaModel.Collision.SpecialBoxes.Add(bd)

                'Update ListViewItem
                LM_UpdateSpecialBoxListViewItem(lvi, bd, sb, newItemNumber)

                'Add ListViewItem
                ListViewEx_LM_Specials.Items.Add(lvi)
                ListViewEx_LM_Specials.Refresh()
            Else
                'Define new Type for SpecialBox
                sb.Type = newType

                'Update ListViewItem
                LM_UpdateSpecialBoxListViewItem(lvi, bd, sb, lvi.Index + 1)
            End If
        End With

    End Sub

    Private Sub Button_LM_RemoveSpecial_Click(sender As Object, e As EventArgs) Handles Button_LM_RemoveSpecial.Click
        If LM_LoadingLevel Then Return

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.SelectedIndex)
            For Each lvi As ListViewItem In ListViewEx_LM_Specials.SelectedItems
                Dim bd As BoxData = Nothing
                Dim sb As Levels.SpecialBox = Nothing

                bd = lvi.Tag
                .AreaModel.Collision.SpecialBoxes.Remove(bd)

                Select Case True
                    Case lvi.Group.Equals(lvg_SpecialBox_Water)
                        sb = .SpecialBoxes.GetSpecialBox(bd, Levels.SpecialBoxType.Water)
                    Case lvi.Group.Equals(lvg_SpecialBox_Mist)
                        sb = .SpecialBoxes.GetSpecialBox(bd, Levels.SpecialBoxType.Mist)
                    Case lvi.Group.Equals(lvg_SpecialBox_ToxicHaze)
                        sb = .SpecialBoxes.GetSpecialBox(bd, Levels.SpecialBoxType.ToxicHaze)
                End Select

                .SpecialBoxes.Remove(sb)
                ListViewEx_LM_Specials.Items.Remove(lvi)
            Next
        End With
    End Sub

    Private Sub ListViewEx_LM_Specials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx_LM_Specials.SelectedIndexChanged
        Dim isNull As Boolean = (ListViewEx_LM_Specials.SelectedItems.Count = 0)
        Button_LM_EditSpecial.Enabled = Not isNull
        Button_LM_RemoveSpecial.Enabled = Not isNull
    End Sub

    Private Sub ComboBox_LM_CameraPreset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_LM_CameraPreset.SelectedIndexChanged
        Dim IsE As Boolean = ComboBox_LM_CameraPreset.SelectedIndex = &HE - 1
        CheckBoxX_LM_Enable2DCamera.Visible = IsE
        If Not IsE Then CheckBoxX_LM_Enable2DCamera.Value = False
    End Sub

    Private Sub LM_OpenAreaEditor() Handles Button_LM_AreaEditor.Click
        If Not LM_SavingRom Then
            Dim frm As New Form_AreaEditor(rommgr,
                                           CurrentLevel,
                                           CurrentLevelID,
                                           CurrentLevel.Areas(ListBoxAdv_LM_Areas.SelectedIndex).AreaID)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub Button_LM_SetUpOffsetModelPosition_Click(sender As Object, e As EventArgs) Handles Button_LM_SetUpStartPosition.Click
        Dim ShowX As Boolean = False
        Dim ShowY As Boolean = False
        Dim ShowZ As Boolean = False
        Dim XVal As Integer = 0
        Dim YVal As Integer = 0
        Dim ZVal As Integer = 0
        Dim Title As String = ""

        ShowX = True : ShowY = True : ShowZ = True

        Dim curPos As Vector3 = clDefaultPosition.GetPosition(CurrentLevel.GetDefaultPositionCmd)

        With curPos
            XVal = .X
            YVal = .Y
            ZVal = .Z
        End With

        Title = Form_Main_Resources.Text_StartPosition

        Dim frm As New Form_SetUpPoint(Title, ShowX, ShowY, ShowZ, XVal, YVal, ZVal)
        If frm.ShowDialog() <> DialogResult.OK Then Return

        XVal = ValueFromText(frm.IntegerInput_X.Value)
        YVal = ValueFromText(frm.IntegerInput_Y.Value)
        ZVal = ValueFromText(frm.IntegerInput_Z.Value)

        With curPos
            .X = XVal
            .Y = YVal
            .Z = ZVal
        End With

        clDefaultPosition.SetPosition(CurrentLevel.GetDefaultPositionCmd, curPos)
    End Sub

    Private Sub ListBoxAdv_LM_Areas_ItemClick(sender As Object, e As EventArgs) Handles ListBoxAdv_LM_Areas.SelectedItemChanged
        Dim item = ListBoxAdv_LM_Areas.SelectedItem
        Dim skip As Boolean = item Is Nothing

        TabControl_LM_Area.Enabled = Not skip
        Button_LM_RemoveArea.Enabled = Not skip
        Button_LM_AreaEditor.Enabled = Not skip

        If LoadingROM Then Return
        If LM_LoadingLevel Then Return
        If LM_LoadingAreaList Then Return
        If skip Then Return

        LM_LoadingArea = True

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.Items.IndexOf(item))
            'Set Area Segmented Banks
            .SetSegmentedBanks(rommgr)

            'Load Area Settings
            ComboBox_LM_TerrainTyp.SelectedIndex = .TerrainType
            ComboBox_LM_Music.SelectedIndex = .BGMusic
            ComboBox_LM_CameraPreset.SelectedIndex = GetCameraPresetIndexOfType(.Geolayout.CameraPreset)
            ComboBox_LM_EnvironmentEffects.SelectedIndex = GetEnvironmentIndexOfType(.Geolayout.EnvironmentEffect)

            'Load 2D-Camera Settings
            CheckBoxX_LM_Enable2DCamera.Value = .Enable2DCamera

            'Area Background
            Select Case .Background.Type
                Case Levels.AreaBGs.Levelbackground
                    ComboBoxEx_LM_AreaBG.SelectedIndex = 0
                Case Levels.AreaBGs.Color
                    ComboBoxEx_LM_AreaBG.SelectedIndex = 1
                    ColorPickerButton_LM_BackgroundColor.SelectedColor = .Background.Color
            End Select
            ComboBoxEx_LM_AreaBG_SelectedIndexChanged()

            'Load Show Message
            With .ShowMessage
                SwitchButton_LM_ShowMsgEnabled.Value = .Enabled
                If .Enabled Then
                    TextBoxX_LM_ShowMsgID.Text = TextFromValue(.DialogID)
                End If
            End With
        End With

        LM_ListViewSpecialsAktuallisieren()

        LM_LoadingArea = False
    End Sub

    Private Sub ListBoxAdv_LM_Levels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdv_LM_Levels.SelectedItemChanged, ListBoxAdv_LM_Levels.ItemRemoved
        Dim index As Integer = ListBoxAdv_LM_Levels.Items.IndexOf(ListBoxAdv_LM_Levels.SelectedItem)
        TabControl_LM_Level.Enabled = Not (index < 0)
        TabControl_LM_Level.Enabled = Not (index < 0)
        If LM_LoadingLevel Then Return
        If index < 0 Then
            TabControl_LM_Area.Enabled = False
            GroupBox_LM_Areas.Enabled = False
            Button_LM_AddArea.Enabled = False
            ButtonX_LM_LevelsMore.Enabled = False
            ListBoxAdv_LM_Areas.Items.Clear()
            Return
        End If

        If LoadingROM Then Return

        LM_LoadingLevel = True
        StatusText = Form_Main_Resources.Status_LoadingLevel

        'Load Level Segemented Banks
        CurrentLevel.SetSegmentedBanks(rommgr)

        'Load Levelsettings
        ComboBox_LM_OB0x0C.SelectedIndex = CInt(CurrentLevel.ObjectBank0x0C)
        ComboBox_LM_OB0x0D.SelectedIndex = CInt(CurrentLevel.ObjectBank0x0D)
        ComboBox_LM_OB0x09.SelectedIndex = CInt(CurrentLevel.ObjectBank0x0E)
        SwitchButton_LM_ActSelector.Value = CurrentLevel.ActSelector
        SwitchButton_LM_HardcodedCameraSettings.Value = CurrentLevel.HardcodedCameraSettings
        NUD_LM_DefaultPositionAreaID.Value = clDefaultPosition.GetAreaID(CurrentLevel.GetDefaultPositionCmd)
        NUD_LM_DefaultPositionYRotation.Value = clDefaultPosition.GetRotation(CurrentLevel.GetDefaultPositionCmd)

        'Load Level Bachground
        With CurrentLevel.Background
            If Not .Enabled Then
                ComboBoxEx_LM_BGMode.SelectedIndex = 2
            ElseIf .HasImage Then
                ComboBoxEx_LM_BGMode.SelectedIndex = 1
            Else
                ComboBoxEx_LM_BGMode.SelectedIndex = 0
            End If
            ComboBoxEx_LM_BGMode_SelectedIndexChanged()
        End With

        Button_LM_AddArea.Enabled = Not (CurrentLevel.Areas.Count = 8)
        StatusText = ""
        LM_LoadingLevel = False
        LM_LoadAreaList()
        GroupBox_LM_Areas.Enabled = True
        TabControl_LM_Area.Enabled = True
        ButtonX_LM_LevelsMore.Enabled = True
        ListBoxAdv_LM_Areas_ItemClick(sender, e)
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs) Handles ButtonItem19.Click
        rommgr.RemoveLevel(CurrentLevel)
        ListBoxAdv_LM_Levels.Items.Remove(ListBoxAdv_LM_Levels.SelectedItem)
        ListBoxAdv_LM_Levels.Refresh()
    End Sub

    Private Sub ButtonItem20_Click(sender As Object, e As EventArgs) Handles ButtonItem20.Click
        Dim frm As New LevelSelectorDialog(rommgr)
        frm.rommgr = rommgr
        frm.Button_Add.Text = Global_Ressources.Button_Okay
        frm.Text = Form_Main_Resources.Text_ChangeReplacingLevel

        If frm.ShowDialog <> DialogResult.OK Then Return

        rommgr.ChangeLevelID(CurrentLevel, CurrentLevel.LevelID,
                             frm.SelectedLevel.Type = LevelInfoDataTabelList.LevelTypes.Level)

        ListBoxAdv_LM_Levels.Items(CurrentLevelIndex).Text = frm.SelectedLevel.Name
    End Sub

    Private Sub ButtonItem21_Click(sender As Object, e As EventArgs) Handles ButtonItem21.Click
        Clipboard.SetText(CurrentLevel.LastRomOffset.ToString("X8"))
    End Sub

    Private Async Sub ButtonItem_ExportVisualMap_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportVisualMap.Click
        If AllowSavingAreaSettings Then
            StatusText = Form_Main_Resources.Status_LoadingModel
            Dim mdl As Object3D = Await LoadAreaVisualMapAsObject3D(rommgr, CurrentArea)

            StatusText = Form_Main_Resources.Status_ExportingModel
            Publics.Publics.ExportModel(mdl, LoaderModule.SimpleFileParser)

            StatusText = ""
        End If
    End Sub

    Private Async Sub ButtonItem_ExportCollisionMap_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportCollisionMap.Click
        If AllowSavingAreaSettings Then
            StatusText = Form_Main_Resources.Status_LoadingModel
            Dim mdl As Object3D = Await CurrentArea.AreaModel.Collision.ToObject3DAsync

            StatusText = Form_Main_Resources.Status_ExportingModel
            Publics.Publics.ExportModel(mdl, LoaderModule.SimpleFileParser)

            StatusText = ""
        End If
    End Sub

    Private Sub SwitchButton_LM_ShowMsgEnabled_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_LM_ShowMsgEnabled.ValueChanged
        Dim enabled As Boolean = SwitchButton_LM_ShowMsgEnabled.Value
        TextBoxX_LM_ShowMsgID.Visible = enabled
        LabelX9.Visible = enabled
        If AllowSavingLevelSettings Then
            CurrentArea.ShowMessage.Enabled = enabled
        End If
    End Sub

    Private Sub TextBoxX_LM_ShowMsgID_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_LM_ShowMsgID.TextChanged
        If AllowSavingLevelSettings Then
            CurrentArea.ShowMessage.DialogID = ValueFromText(TextBoxX_LM_ShowMsgID.Text)
        End If
    End Sub

    Private Sub ButtonItem15_Click(sender As Object, e As EventArgs) Handles ButtonItem15.Click
        If CurrentLevel IsNot Nothing Then
            Dim sd As New ScriptDumper(Of Levels.Script.LevelscriptCommand, Levels.Script.LevelscriptCommandTypes)
            sd.Script = CurrentLevel.Levelscript
            sd.ShowDialog()
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If CurrentArea IsNot Nothing Then
            Dim frm As New ScriptDumper(Of Levels.Script.LevelscriptCommand, Levels.Script.LevelscriptCommandTypes)
            frm.Script = CurrentArea.Levelscript
            frm.ShowDialog()
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If CurrentArea IsNot Nothing Then
            Dim frm As New ScriptDumper(Of Geolayout.Script.GeolayoutCommand, Geolayout.Script.GeolayoutCommandTypes)
            frm.Script = CurrentArea.Geolayout.Geolayoutscript
            frm.ShowDialog()
        End If
    End Sub

    Private Sub ButtonX_LM_ScrollTexEditor_Click(sender As Object, e As EventArgs) Handles ButtonX_LM_ScrollTexEditor.Click
        If CurrentArea IsNot Nothing Then
            Dim editor As New ScrollTexEditor(CurrentArea)
            editor.ShowDialog()
        End If
    End Sub

    Private Sub ButtonItem26_Click(sender As Object, e As EventArgs) Handles ButtonItem26.Click
        Dim ofd As New OpenFileDialog With {.Filter = "SM64 ROMs (*.z64)|*.z64"}
        If ofd.ShowDialog = DialogResult.OK Then
            Dim frm As New ImportLevelDialog(rommgr)
            If frm.LoadROM(ofd.FileName) Then
                If frm.ShowDialog = DialogResult.OK Then
                    LM_ReloadLevelListBox()
                End If
            End If
        End If
    End Sub

End Class
