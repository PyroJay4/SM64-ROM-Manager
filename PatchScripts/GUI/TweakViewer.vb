Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Schedule
Imports DevComponents.Editors
Imports PatchScripts
Imports Publics

Public Class TweakViewer

    Private myPatchs As New List(Of PatchProfile)
    Private rommgr As SM64Lib.RomManager

    Public Sub New(rommgr As SM64Lib.RomManager)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors()
        Panel1.UpdateAmbientColors
        Flyout1.BackColor = BackColor
        Me.rommgr = rommgr

    End Sub

#Region "Functions"

    Private Sub LoadTweaks()
        CircularProgress1.Visible = True
        CircularProgress1.IsRunning = True

        Dim pathTweaks As String = Path.Combine(MyDataPath, "Tweaks")
        Dim mgr As New PatchingManager

        myPatchs.Clear()

        For Each f As String In Directory.GetFiles(pathTweaks, "*.xml", SearchOption.AllDirectories)
            myPatchs.Add(mgr.Read(f))
        Next
        myPatchs = myPatchs.OrderBy(Function(n) n.Name).ToList

        LoadTweakList()

        CircularProgress1.IsRunning = False
        CircularProgress1.Visible = False
    End Sub

    Private Sub LoadTweakList(Optional Filter As String = "")
        Dim enableFilter As Boolean = Filter.Trim <> ""
        Dim filterLower As String = Filter.ToLower
        ItemListBox1.Items.Clear()

        For Each patch As PatchProfile In myPatchs
            If enableFilter AndAlso
                Not patch.Name.ToLower.Contains(filterLower) AndAlso
                patch.Scripts.Where(Function(n) n.Name.ToLower.Contains(filterLower)).Count = 0 Then
                Continue For
            End If

            Dim btnItem As New ButtonItem

            btnItem.Text = patch.Name
            btnItem.Tag = patch

            AddHandler btnItem.MouseUp, AddressOf ItemListBox1_ItemMouseClick

            ItemListBox1.Items.Add(btnItem)
        Next

        If ItemListBox1.Items.Count > 0 Then
            ItemListBox1.SelectedItem = ItemListBox1.Items(0)
        End If

        ItemListBox1.Refresh()
    End Sub

    Private Sub LoadTweak(patch As PatchProfile)
        LabelX_PatchName.Text = patch.Name

        If Not String.IsNullOrEmpty(LabelX_Description.Text) Then
            LabelX_Description.Text = patch.Description
            SuperTooltip1.SetSuperTooltip(LabelX_Description, New SuperTooltipInfo("", "", patch.Description, Nothing, Nothing, eTooltipColor.Default, False, False, Nothing))
        Else
            LabelX_Description.Text = "(No description avaiable.)"
            SuperTooltip1.SetSuperTooltip(LabelX_Description, Nothing)
        End If

        LoadScriptsList(patch)
    End Sub

    Private Sub LoadScriptsList(patch As PatchProfile)
        ComboBoxEx_Scripts.Items.Clear()

        LabelX_PatchName.Text = $"Name: {patch.Name}"
        LabelX_Description.Text = If(String.IsNullOrEmpty(patch.Name), "No description avaiable.", patch.Description)

        For Each script As PatchScript In patch.Scripts
            Dim item As New ComboItem
            If Not String.IsNullOrEmpty(script.Name) Then
                item.Text = script.Name
            Else
                item.Text = "Unnamed"
            End If
            item.Tag = script
            ComboBoxEx_Scripts.Items.Add(item)
        Next

        If ComboBoxEx_Scripts.Items.Count > 0 Then
            ComboBoxEx_Scripts.SelectedIndex = 0
        End If

        Panel1.Refresh()
    End Sub

    Private Sub LoadScript(script As PatchScript)
        SuperTooltip1.SetSuperTooltip(New ComboItem, New SuperTooltipInfo(script.Name, "", script.Description, Nothing, Nothing, eTooltipColor.Default, False, False, Nothing))
    End Sub

    Private Sub SaveSinglePatch(patch As PatchProfile)
        If patch IsNot Nothing Then
            Dim profmgr As New PatchingManager
            profmgr.Save(patch, Path.Combine(MyDataPath, "Tweaks"))
        End If
    End Sub

    Private Function GetSelectedPatch() As PatchProfile
        Return CType(ItemListBox1.SelectedItem, ButtonItem)?.Tag
    End Function

    Private Function GetSelectedScript() As PatchScript
        Return CType(ComboBoxEx_Scripts.SelectedItem, ComboItem)?.Tag
    End Function

#End Region

    Private Sub TweakViewer_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadTweaks()
    End Sub

    Private Sub ItemListBox1_SelectedItemChanged() Handles ItemListBox1.SelectedItemChanged
        Dim btnItem As ButtonItem = ItemListBox1.SelectedItem
        Dim patch As PatchProfile = btnItem.Tag

        LoadScriptsList(patch)
    End Sub

    Private Sub ComboBoxEx_Scripts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx_Scripts.SelectedIndexChanged
        Dim item As ComboItem = ComboBoxEx_Scripts.SelectedItem

        Dim isNotNull As Boolean = item IsNot Nothing
        ButtonX8.Enabled = isNotNull
        ButtonX4.Enabled = isNotNull
        ButtonX6.Enabled = isNotNull

        If isNotNull Then
            Dim script As PatchScript = item.Tag
            LoadScript(script)
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim patch As PatchProfile = CType(ItemListBox1.SelectedItem, ButtonItem)?.Tag
        Dim editor As New TweakProfileEditor

        editor.Titel = patch.Name
        editor.Description = patch.Description

        Flyout1.Close()

        If editor.ShowDialog(Me) = DialogResult.OK Then
            Dim oldName As String = patch.Name
            Dim oldDescription As String = patch.Description

            patch.Name = editor.Titel.Trim
            patch.Description = editor.Description.Trim

            If oldName <> patch.Name Then
                'Rename File
                Dim newFileName As String = Path.Combine(Path.GetDirectoryName(patch.FileName), editor.Titel & Path.GetExtension(patch.FileName))
                newFileName = EnsureFileNameIsNotUsed(newFileName)
                File.Move(patch.FileName, newFileName)
                patch.FileName = newFileName

                'Update Title in ListBox
                ItemListBox1.SelectedItem.Text = patch.Name
                ItemListBox1.Refresh()
            End If

            'Save Patch
            SaveSinglePatch(patch)

            'Update Tweak Infos
            ItemListBox1_SelectedItemChanged()
        End If
    End Sub

    Private Function EnsureFileNameIsNotUsed(fileName As String) As String
        Dim newFileName As String = fileName

        If File.Exists(fileName) Then
            Dim ende As Boolean = False
            Dim count As Integer = 0
            Dim dir As String = Path.GetDirectoryName(fileName)
            Dim name As String = Path.GetFileNameWithoutExtension(fileName)
            Dim ext As String = Path.GetExtension(fileName)

            Do Until ende
                newFileName = Path.Combine(dir, name & count & ext)
                If Not File.Exists(newFileName) Then ende = True
            Loop
        End If

        Return newFileName
    End Function

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Flyout1.Close()
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        Dim btnItem As ButtonItem = ItemListBox1.SelectedItem
        Dim patch As PatchProfile = btnItem?.Tag

        If patch IsNot Nothing AndAlso MessageBoxEx.Show(Me, "Are you sure to remove this Tweak? You would not be able to restore it.", "Remove Tweak", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Flyout1.Close()
            ItemListBox1.Items.Remove(btnItem)
            ItemListBox1.Refresh()
            myPatchs.Remove(patch)
            File.Delete(patch.FileName)
        End If
    End Sub

    Private Sub ButtonX_AddNew_Click(sender As Object, e As EventArgs) Handles ButtonX_AddNew.Click
        Dim patch As New PatchProfile
        patch.Name = "New Profile"

        Dim script As New PatchScript
        script.Name = "New Script"
        patch.Scripts.Add(script)

        Dim btnItem As New ButtonItem
        btnItem.Text = patch.Name
        btnItem.Tag = patch
        AddHandler btnItem.MouseUp, AddressOf ItemListBox1_ItemMouseClick
        ItemListBox1.Items.Add(btnItem)

        SaveSinglePatch(patch)
        ItemListBox1.SelectedItem = btnItem
        ItemListBox1.EnsureVisible(btnItem)
        ItemListBox1.Refresh()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim patch As PatchProfile = GetSelectedPatch()

        Dim script As New PatchScript
        script.Name = "New Script"
        patch.Scripts.Add(script)

        Dim comboItem As New ComboItem
        comboItem.Text = script.Name
        comboItem.Tag = script
        ComboBoxEx_Scripts.Items.Add(comboItem)
        ComboBoxEx_Scripts.SelectedItem = comboItem

        SaveSinglePatch(patch)
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Dim patch As PatchProfile = GetSelectedPatch()
        Dim script As PatchScript = GetSelectedScript()

        If patch IsNot Nothing AndAlso script IsNot Nothing Then
            patch.Scripts.Remove(script)
            ComboBoxEx_Scripts.Items.Remove(ComboBoxEx_Scripts.SelectedItem)
            SaveSinglePatch(patch)
        End If
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        Dim script As PatchScript = GetSelectedScript()

        If script IsNot Nothing Then
            Dim editor As New TweakScriptEditor(script)
            Flyout1.Close()
            editor.ShowDialog(Me)

            Dim ci As ComboItem = ComboBoxEx_Scripts.SelectedItem
            If ci IsNot Nothing Then
                If Not String.IsNullOrEmpty(script.Name) Then
                    ci.Text = script.Name
                Else
                    ci.Text = "Unnamed"
                End If
            End If

            If editor.NeedToSave Then
                SaveSinglePatch(GetSelectedPatch)
                ItemListBox1_SelectedItemChanged()
            End If
        End If
    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        Dim script As PatchScript = GetSelectedScript()

        If script IsNot Nothing Then
            Try
                Dim mgr As New PatchingManager
                mgr.Patch(script, rommgr, "", Me, New Dictionary(Of String, Object) From {{"romfile", rommgr.RomFile}, {"rommgr", rommgr}})
                MessageBoxEx.Show(Me, "Patched successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBoxEx.Show(Me, "Error at executing the script. It probably has errors.", "Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ItemListBox1_ItemMouseClick(sender As Object, e As EventArgs)
        Flyout1.Show(New Rectangle(New Point(Cursor.Position.X - Flyout1.Content.Width / 2, Cursor.Position.Y), Size.Empty), DevComponents.DotNetBar.Controls.ePointerSide.Top, Flyout1.Content.Width / 2, ItemListBox1)
    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        LoadTweakList(TextBoxX1.Text)
    End Sub

    Private Sub TextBoxX1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonX7.PerformClick()
        End If
    End Sub

    Private Sub LabelX_Description_MouseEnter(sender As Object, e As EventArgs) Handles LabelX_Description.TextChanged
        SuperTooltip1.SetSuperTooltip(sender, New SuperTooltipInfo("", "", sender.Text, Nothing, Nothing, eTooltipColor.System, False, False, Nothing))
    End Sub

    Private Sub Flyout1_FlyoutShown(sender As Object, e As EventArgs) Handles Flyout1.FlyoutShown
        Flyout1.Content?.Focus()
    End Sub

    Private Sub ItemListBox1_Scroll(sender As Object, e As ScrollEventArgs) Handles ItemListBox1.Scroll
        Flyout1.Close()
    End Sub

    Private Sub ButtonX9_Click(sender As Object, e As EventArgs) Handles ButtonX9.Click
        TextBoxX1.Text = ""
        LoadTweakList()
    End Sub

End Class