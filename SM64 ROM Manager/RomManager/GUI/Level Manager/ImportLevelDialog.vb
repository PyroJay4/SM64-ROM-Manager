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
                Dim btn As New ButtonItem
                btn.Text = If(lid.Type = LevelInfoDataTabelList.LevelTypes.Level, CByte(lid.Number).ToString("00") & " - ", "") & lid.Name
                btn.Tag = lvl
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

                'Set Level ID
                lvl.LevelID = levelinfo.ID

                'Add Level
                rommgr.Levels.Add(lvl)

                DialogResult = DialogResult.OK

            End If
        End If
    End Sub

    Private Sub ItemListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemListBox1.SelectedIndexChanged
        ButtonX_Import.Enabled = ItemListBox1.SelectedIndex > -1
    End Sub
End Class