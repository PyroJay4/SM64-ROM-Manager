Imports System.ComponentModel
Imports System.IO
Imports System.Numerics
Imports DevComponents.DotNetBar
Imports ModelConverterGUI
Imports S3DFileParser
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Levels.Script.Commands
Imports SM64Lib.Model

Public Class Tab_LevelManager

    Public Property MainForm As MainForm
    Public Property RomMgr As RomManager

    'Flags
    Private LM_LoadingAreaList As Boolean = False
    Private LM_SavingRom As Boolean = False
    Private LM_LoadingArea As Boolean = False
    Private LM_LoadingLevel As Boolean = False

    Private ReadOnly Property OpenAreaEditors As IEnumerable(Of Form_AreaEditor)
        Get
            Dim list As New List(Of Form_AreaEditor)

            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is Form_AreaEditor Then
                    list.Add(frm)
                End If
            Next

            Return list
        End Get
    End Property

    Private Function GetAreaEditor(level As Levels.Level)
        Return OpenAreaEditors.FirstOrDefault(Function(n) n.cLevel Is level)
    End Function

    Public Sub New()
        InitializeComponent()
    End Sub

    Private ReadOnly Property CurrentLevel As Levels.Level
        Get
            If ListBoxAdv_LM_Levels.SelectedItem Is Nothing Then Return Nothing
            Return RomMgr.Levels(ListBoxAdv_LM_Levels.SelectedIndex)
        End Get
    End Property
    Private ReadOnly Property CurrentLevelID As Byte
        Get
            If ListBoxAdv_LM_Levels.SelectedIndex < 0 Then Return Nothing
            Return RomMgr.Levels(ListBoxAdv_LM_Levels.SelectedIndex).LevelID
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
            Return Not mainForm?.LoadingROM AndAlso Not LM_LoadingLevel AndAlso CurrentLevel IsNot Nothing
        End Get
    End Property
    Private ReadOnly Property AllowSavingAreaSettings As Boolean
        Get
            Return Not mainForm?.LoadingROM AndAlso Not LM_LoadingLevel AndAlso Not LM_LoadingAreaList AndAlso Not LM_LoadingArea AndAlso CurrentArea IsNot Nothing
        End Get
    End Property

    Public Sub LoadListBoxEntries()
        Dim temp_1 As String = MyDataPath & "\Other\Object Bank Data\Bank 0x{0}.txt"
        For Each t As String In {"B", "C", "D", "9"}
            SM64Lib.ObjectBankData.Add(FileIniParser.ReadFile(String.Format(temp_1, t)))
        Next

        With ComboBox_LM_OB0x0C.Items
            .Clear()
            .Add(Form_Main_Resources.Text_Disabled)
            For Each s In ObjectBankData(1).Sections
                .Add(s.SectionName)
            Next
        End With
        With ComboBox_LM_OB0x0D.Items
            .Clear()
            .Add(Form_Main_Resources.Text_Disabled)
            For Each s In ObjectBankData(2).Sections
                .Add(s.SectionName)
            Next
        End With
        With ComboBox_LM_OB0x09.Items
            .Clear()
            .Add(Form_Main_Resources.Text_Disabled)
            For Each s In ObjectBankData(3).Sections
                .Add(s.SectionName)
            Next
        End With
    End Sub

    Friend Sub LM_LoadLevelList()
        ListBoxAdv_LM_Levels.Items.Clear()
        For Each lvl As Levels.Level In RomMgr.Levels
            Dim btn As New ButtonItem
            btn.Text = RomMgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = lvl.LevelID).Name
            AddHandler btn.MouseUp, Sub(sender As Object, e As MouseEventArgs) If e.Button = MouseButtons.Right Then ButtonX_LM_LevelsMore.Popup(Cursor.Position)
            ListBoxAdv_LM_Levels.Items.Add(btn)
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
                AddHandler btn.MouseUp, Sub(sender As Object, e As MouseEventArgs) If e.Button = MouseButtons.Right Then Button_LM_AreaEditor.Popup(Cursor.Position)
                .Items.Add(btn)
            Next
            If .Items.Count > 0 Then .SelectedItem = .Items(0)
        End With
        ListBoxAdv_LM_Areas.Refresh()
        LM_LoadingAreaList = False
    End Sub

    Private Sub LM_AddNewLevel() Handles Button_LM_AddNewLevel.Click
        Dim frm As New LevelSelectorDialog(RomMgr)
        frm.rommgr = RomMgr

        If frm.ShowDialog <> DialogResult.OK Then Return

        RomMgr.AddLevel(frm.SelectedLevel.ID)
        RomMgr.Levels.Last.ActSelector = (frm.SelectedLevel.Type = LevelInfoDataTabelList.LevelTypes.Level)

        Dim btn As New ButtonItem With {.Checked = False, .Text = RomMgr.LevelInfoData.FirstOrDefault(Function(n) n.ID = frm.SelectedLevel.ID).Name}
        ListBoxAdv_LM_Levels.Items.Add(btn)
        ListBoxAdv_LM_Areas.EnsureVisible(btn)
        ListBoxAdv_LM_Levels.Refresh()
        ListBoxAdv_LM_Levels.SelectedItem = ListBoxAdv_LM_Levels.Items(ListBoxAdv_LM_Levels.Items.Count - 1)
    End Sub
    Private Sub LM_AddNewArea() Handles Button_LM_AddArea.Click
        'Check for left area IDs
        Dim ReamingIDs As New List(Of Byte)({&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H0})
        For Each a As Levels.LevelArea In CurrentLevel.Areas
            ReamingIDs.Remove(a.AreaID)
        Next
        If ReamingIDs.Count = 0 Then
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_MaxCountAreasReached, Form_Main_Resources.MsgBox_MaxCountAreasReached_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Button_LM_AddArea.Enabled = False
            Return
        End If

        'Convert a model
        Dim frm As New MainModelConverter
        frm.CheckBoxX_ConvertCollision.Enabled = False
        frm.CheckBoxX_ConvertModel.Enabled = False

        If frm.ShowDialog = DialogResult.OK Then
            'Create new area
            Dim tArea As New Levels.LevelArea(ReamingIDs(0))
            tArea.AreaModel = frm.ResModel
            tArea.ScrollingTextures.AddRange(frm.ResModel.Fast3DBuffer.ConvertResult.ScrollingCommands.ToArray)

            'Add area to level
            CurrentLevel.Areas.Add(tArea)
            LM_LoadAreaList()
            ListBoxAdv_LM_Areas.SelectedItem = ListBoxAdv_LM_Areas.Items(ListBoxAdv_LM_Areas.Items.Count - 1)

            If ReamingIDs.Count = 1 Then Button_LM_AddArea.Enabled = False
        End If
    End Sub
    Private Sub LM_RemoveArea() Handles Button_LM_RemoveArea.Click
        If LM_LoadingArea Then Return
        If LM_LoadingAreaList Then Return
        If Not mainForm.FinishedLoading Then Return

        Dim index = ListBoxAdv_LM_Areas.SelectedIndex
        If index < 0 Then Return

        If MessageBoxEx.Show("You are going to remove the selected area. Continue?", "Remove Area", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            CurrentLevel.Areas.RemoveAt(index)

            Button_LM_AddArea.Enabled = True
            If CurrentLevel.Areas.Count = 0 Then TabControl_LM_Area.Enabled = False

            LM_LoadAreaList()
        End If
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
            If frm.ShowDialog() <> DialogResult.OK Then Return

            If frm.CheckBoxX_ConvertCollision.Checked AndAlso frm.CheckBoxX_ConvertModel.Checked Then
                Dim OldAreaModel As ObjectModel = .AreaModel
                .AreaModel = frm.ResModel
            ElseIf frm.CheckBoxX_ConvertCollision.Checked Then
                Dim OldAreaModel As ObjectModel = .AreaModel
                .AreaModel.Collision = frm.ResModel.Collision
            ElseIf frm.CheckBoxX_ConvertModel.Checked Then
                Dim OldAreaModel As ObjectModel = .AreaModel
                .AreaModel = frm.ResModel
                .AreaModel.Collision = OldAreaModel.Collision
            End If

            If frm.CheckBoxX_ConvertModel.Checked Then
                .ScrollingTextures.Clear()
                .ScrollingTextures.AddRange(.AreaModel.Fast3DBuffer.ConvertResult.ScrollingCommands.ToArray)
            End If

            .SetSegmentedBanks(RomMgr)
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
    Private Function LM_GetNewSpecialBoxListViewItem(sd As Levels.SpecialBox, ItemNumber As Integer) As ListViewItem
        Dim lvi As ListViewItem = Me.LM_GetNewSpecialBoxListViewItem
        LM_UpdateSpecialBoxListViewItem(lvi, sd, ItemNumber)
        Return lvi
    End Function
    Private Sub LM_UpdateSpecialBoxListViewItem(lvi As ListViewItem, sd As Levels.SpecialBox, ItemNumber As Integer)
        With lvi
            .Tag = sd
            .Text = ItemNumber
            .SubItems(1).Text = sd.Type.ToString
            .SubItems(2).Text = sd.X1
            .SubItems(3).Text = sd.Z1
            .SubItems(4).Text = sd.X2
            .SubItems(5).Text = sd.Z2
            .SubItems(6).Text = sd.Y
            .SubItems(7).Text = If(sd.Type = Levels.SpecialBoxType.Water, If(sd.InvisibleWater, Form_Main_Resources.Text_Invisible, sd.WaterType.ToString), "-")
        End With
    End Sub

    Private Sub LM_ListViewSpecialsAktuallisieren()
        'Clear everything
        ListViewEx_LM_Specials.Items.Clear()
        'lvg_SpecialBox_Water.Items.Clear()
        'lvg_SpecialBox_ToxicHaze.Items.Clear()
        'lvg_SpecialBox_Mist.Items.Clear()

        'List all special boxes
        For Each sb As Levels.SpecialBox In CurrentArea.SpecialBoxes
            Dim typeToSelect As Levels.SpecialBoxType = Levels.SpecialBoxType.Water
            'Dim lvgToSelect As ListViewGroup = Nothing

            Select Case sb.Type
                Case Levels.SpecialBoxType.Water
                    typeToSelect = Levels.SpecialBoxType.Water
                    'lvgToSelect = lvg_SpecialBox_Water
                Case Levels.SpecialBoxType.ToxicHaze
                    typeToSelect = Levels.SpecialBoxType.ToxicHaze
                    'lvgToSelect = lvg_SpecialBox_ToxicHaze
                Case Levels.SpecialBoxType.Mist
                    typeToSelect = Levels.SpecialBoxType.Mist
                    'lvgToSelect = lvg_SpecialBox_Mist
            End Select

            Dim lvi As ListViewItem = LM_GetNewSpecialBoxListViewItem(sb, ListViewEx_LM_Specials.Items.Count + 1)
            'lvi.Group = lvgToSelect

            ListViewEx_LM_Specials.Items.Add(lvi)
        Next

        ListViewEx_LM_Specials.Refresh()
    End Sub

    Private Sub Button_LM_AddEditSpecial_Click(sender As Object, e As EventArgs) Handles Button_LM_EditSpecial.Click, Button_LM_AddSpecial.Click
        If LM_LoadingLevel Then Return

        Dim curArea As Levels.LevelArea = CurrentArea
        Dim sb As Levels.SpecialBox
        Dim lvi As ListViewItem
        Dim frm As Form_AddSpecialItem

        If sender Is Button_LM_EditSpecial Then
            lvi = ListViewEx_LM_Specials.SelectedItems(0)
            sb = lvi.Tag
        Else
            sb = New Levels.SpecialBox
            lvi = LM_GetNewSpecialBoxListViewItem()
        End If

        frm = New Form_AddSpecialItem(sb)
        If frm.ShowDialog <> DialogResult.OK Then Return

        Dim newType As Levels.SpecialBoxType
        Select Case True
            Case frm.CheckBoxX_Water.Checked
                newType = Levels.SpecialBoxType.Water
                'lvi.Group = lvg_SpecialBox_Water
            Case frm.CheckBoxX_Mist.Checked
                newType = Levels.SpecialBoxType.Mist
                'lvi.Group = lvg_SpecialBox_Mist
            Case frm.CheckBoxX_ToxicHaze.Checked
                newType = Levels.SpecialBoxType.ToxicHaze
                'lvi.group = lvg_specialbox_toxichaze
        End Select

        'Reorder Positions in BoxData
        ReorderBoxDataPositions(sb)

        If sender Is Button_LM_AddSpecial Then
            'Get new Itemnumber
            Dim newItemNumber As Integer = curArea.SpecialBoxes.Where(Function(n) n.Type = newType).Count + 1

            'Define new Type for SpecialBox
            sb.Type = newType

            'Add new SpecialBox
            curArea.SpecialBoxes.Add(sb)

            'Update ListViewItem
            LM_UpdateSpecialBoxListViewItem(lvi, sb, newItemNumber)

            'Add ListViewItem
            ListViewEx_LM_Specials.Items.Add(lvi)
            ListViewEx_LM_Specials.Refresh()
        Else
            'Define new Type for SpecialBox
            sb.Type = newType

            'Update ListViewItem
            LM_UpdateSpecialBoxListViewItem(lvi, sb, lvi.Index + 1)
        End If
    End Sub

    Private Sub Button_LM_RemoveSpecial_Click(sender As Object, e As EventArgs) Handles Button_LM_RemoveSpecial.Click
        If LM_LoadingLevel Then Return

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.SelectedIndex)
            For Each lvi As ListViewItem In ListViewEx_LM_Specials.SelectedItems
                Dim sb As Levels.SpecialBox = lvi.Tag
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
        Dim openAreaEditor As Form_AreaEditor = GetAreaEditor(CurrentLevel)
        If Not LM_SavingRom AndAlso openAreaEditor Is Nothing Then
            Dim frm As New Form_AreaEditor(RomMgr,
                                           CurrentLevel,
                                           CurrentLevelID,
                                           CurrentArea.AreaID)
            frm.Show()
        Else
            openAreaEditor.BringToFront()
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

        If mainForm.LoadingROM Then Return
        If LM_LoadingLevel Then Return
        If LM_LoadingAreaList Then Return
        If skip Then Return

        LM_LoadingArea = True

        With CurrentLevel.Areas(ListBoxAdv_LM_Areas.Items.IndexOf(item))
            'Set Area Segmented Banks
            .SetSegmentedBanks(RomMgr)

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

        If mainForm.LoadingROM Then Return

        LM_LoadingLevel = True
        mainForm.StatusText = Form_Main_Resources.Status_LoadingLevel

        'Load Level Segemented Banks
        CurrentLevel.SetSegmentedBanks(RomMgr)

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
        mainForm.StatusText = ""
        LM_LoadingLevel = False
        LM_LoadAreaList()
        GroupBox_LM_Areas.Enabled = True
        TabControl_LM_Area.Enabled = True
        ButtonX_LM_LevelsMore.Enabled = True
        ListBoxAdv_LM_Areas_ItemClick(sender, e)
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs) Handles ButtonItem19.Click
        If MessageBoxEx.Show("You are going to remove the selected area. Continue?", "Remove Area", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            RomMgr.RemoveLevel(CurrentLevel)
            ListBoxAdv_LM_Levels.Items.Remove(ListBoxAdv_LM_Levels.SelectedItem)
            ListBoxAdv_LM_Levels.Refresh()
        End If
    End Sub

    Private Sub ButtonItem20_Click(sender As Object, e As EventArgs) Handles ButtonItem20.Click
        Dim frm As New LevelSelectorDialog(RomMgr)
        frm.rommgr = RomMgr
        frm.Button_Add.Text = Global_Ressources.Button_Okay
        frm.Text = Form_Main_Resources.Text_ChangeReplacingLevel

        If frm.ShowDialog <> DialogResult.OK Then Return

        RomMgr.ChangeLevelID(CurrentLevel, CurrentLevel.LevelID,
                             frm.SelectedLevel.Type = LevelInfoDataTabelList.LevelTypes.Level)

        ListBoxAdv_LM_Levels.Items(CurrentLevelIndex).Text = frm.SelectedLevel.Name
    End Sub

    Private Sub ButtonItem21_Click(sender As Object, e As EventArgs) Handles ButtonItem21.Click
        Clipboard.SetText(CurrentLevel.LastRomOffset.ToString("X8"))
    End Sub

    Private Async Sub ButtonItem_ExportVisualMap_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportVisualMap.Click
        If AllowSavingAreaSettings Then
            mainForm.StatusText = Form_Main_Resources.Status_LoadingModel
            Dim mdl As Object3D = Await LoadAreaVisualMapAsObject3D(RomMgr, CurrentArea)

            mainForm.StatusText = Form_Main_Resources.Status_ExportingModel
            Publics.Publics.ExportModel(mdl, LoaderModule.SimpleFileParser)

            mainForm.StatusText = ""
        End If
    End Sub

    Private Async Sub ButtonItem_ExportCollisionMap_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExportCollisionMap.Click
        If AllowSavingAreaSettings Then
            mainForm.StatusText = Form_Main_Resources.Status_LoadingModel
            Dim mdl As Object3D = Await CurrentArea.AreaModel.Collision.ToObject3DAsync

            mainForm.StatusText = Form_Main_Resources.Status_ExportingModel
            Publics.Publics.ExportModel(mdl, LoaderModule.SimpleFileParser)

            mainForm.StatusText = ""
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
            Dim frm As New ImportLevelDialog(RomMgr)
            If frm.LoadROM(ofd.FileName) Then
                If frm.ShowDialog = DialogResult.OK Then
                    LM_LoadLevelList()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxAdv_LM_Levels_ItemDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBoxAdv_LM_Levels.ItemDoubleClick, ListBoxAdv_LM_Areas.ItemDoubleClick
        Button_LM_AreaEditor.PerformClick()
    End Sub

    Private Sub ButtonItem24_Click(sender As Object, e As EventArgs) Handles ButtonItem24.Click
        Dim frm As New ValueInputDialog
        frm.InfoLabel.Text = Form_Main_Resources.Text_NewLength & ":"
        frm.ValueTextBox.Text = TextFromValue(CurrentLevel.bank0x19.Length)

        Dim [continue] As Boolean = True
        Dim minSize As UInteger = SM64Lib.RomManager.ManagerSettings.defaultLevelscriptSize

        Do While [continue]
            If frm.ShowDialog = DialogResult.OK Then
                Dim newVal As Integer = ValueFromText(frm.ValueTextBox.Text)
                If newVal < minSize Then
                    MessageBoxEx.Show(String.Format(Form_Main_Resources.MsgBox_InvalidBankSize, minSize.ToString("X")), Form_Main_Resources.MsgBox_InvalidBankSize_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    CurrentLevel.bank0x19.Length = newVal
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_BankSizeChangedSuccess, Form_Main_Resources.MsgBox_BankSizeChangedSuccess_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    [continue] = False
                End If
            Else
                [continue] = False
            End If
        Loop
    End Sub

    Private Sub ButtonX_LM_LevelsMore_PopupOpen(sender As Object, e As EventArgs) Handles ButtonX_LM_LevelsMore.PopupOpen
        ButtonItem24.Visible = CurrentLevel?.bank0x19 IsNot Nothing
    End Sub

End Class
