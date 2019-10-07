Imports DevComponents.DotNetBar
Imports SM64Lib
Imports SM64Lib.Levels

Public Class ImportLevelDialog

    Private rommgr As RomManager
    Private openrom As RomManager = Nothing

    Public Sub New(rommgr As RomManager)
        InitializeComponent()
        UpdateAmbientColors
        Me.rommgr = rommgr
    End Sub

    Public Function LoadROM(fileName As String) As Boolean
        Dim mgr As New RomManager(fileName)
        If mgr.CheckROM() Then
            openrom = mgr
            LabelX_Romfile.Text = IO.Path.GetFileName(mgr.RomFile)
            mgr.LoadLevels()
            LoadLevels()
            Return True
        Else
            MessageBoxEx.Show("This ROM can't be used.", "Invalid ROM file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Private Sub LoadLevels()
        ItemListBox1.Items.Clear()

        If openrom IsNot Nothing Then
            For Each lvl As Level In openrom.Levels
                Dim lid As LevelInfoDataTabelList.Level = rommgr.LevelInfoData.GetByLevelID(lvl.LevelID)
                Dim btn As New ButtonItem With {
                    .Text = If(lid.Type = LevelInfoDataTabelList.LevelTypes.Level, CByte(lid.Number).ToString("00") & " - ", "") & lid.Name,
                    .Tag = lvl
                }
                ItemListBox1.Items.Add(btn)
            Next
        End If

        If ItemListBox1.Items.Count > 0 Then
            ItemListBox1.SelectedIndex = 0
        End If

        ItemListBox1.Refresh()
    End Sub

    Private Sub ButtonX_Import_Click(sender As Object, e As EventArgs) Handles ButtonX_Import.Click
        Dim selItem As ButtonItem = ItemListBox1.SelectedItem
        Dim lvl As Level = selItem?.Tag
        Dim levelinfo As LevelInfoDataTabelList.Level

        If lvl IsNot Nothing Then
            Dim selector As New LevelSelectorDialog(rommgr)
            If selector.ShowDialog = DialogResult.OK Then
                levelinfo = selector.SelectedLevel

                Dim newLvl As Level

                Select Case openrom.IsSM64EditorMode
                    Case True

                        'Create mew Level
                        newLvl = New Level(levelinfo.ID, levelinfo.Index)

                        'Create new Areas & Copy Area Data
                        For Each a As LevelArea In lvl.Areas
                            Dim newArea As New LevelArea(a.AreaID, newLvl.LevelID, False, False)
                            newArea.Background.Type = a.Background.Type
                            newArea.Background.Color = a.Background.Color
                            newArea.BGMusic = a.BGMusic
                            newArea.TerrainType = a.TerrainType
                            newArea.Objects.AddRange(a.Objects.ToArray)
                            newArea.Warps.AddRange(a.Warps.ToArray)
                            newArea.WarpsForGame.AddRange(a.WarpsForGame.ToArray)
                            newArea.AreaModel = a.AreaModel
                            newLvl.Areas.Add(newArea)
                        Next

                        'Copy Level Data
                        newLvl.Background.Enabled = lvl.Background.Enabled
                        newLvl.Background.ID = lvl.Background.ID
                        newLvl.Background.ImageData = lvl.Background.ImageData
                        newLvl.Background.IsCustom = lvl.Background.IsCustom
                        newLvl.HardcodedCameraSettings = lvl.HardcodedCameraSettings
                        newLvl.ActSelector = lvl.ActSelector

                    Case False

                        newLvl = lvl
                        newLvl.LevelID = levelinfo.ID

                    Case Else

                        newLvl = Nothing

                End Select

                If newLvl IsNot Nothing Then
                    'Add Level
                    rommgr.Levels.Add(newLvl)

                    'Close Window
                    DialogResult = DialogResult.OK
                Else
                    MessageBoxEx.Show("The level can't be added.", "Add Level", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        End If
    End Sub

    Private Sub ItemListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemListBox1.SelectedIndexChanged
        ButtonX_Import.Enabled = ItemListBox1.SelectedIndex > -1
    End Sub

End Class