Imports System.IO
Imports DevComponents.DotNetBar
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports SM64_ROM_Manager.EventArguments
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Levels

Public Class Tab_MusicManager

    'F i e l d s

    Public WithEvents Controller As MainController

    'P r o p e r t i e s

    Private ReadOnly Property SelectedSequenceIndex As Integer
        Get
            Return ListBoxAdv_MS_MusicSequences.SelectedIndex
        End Get
    End Property

    'C o n t r o l l e r   E v e n t s

    Private Sub Controller_MusicSequenceRemoved(e As MusicSequenceEventArgs) Handles Controller.MusicSequenceRemoved
        RemoveSequenceFromList(e.Index)
    End Sub

    Private Sub Controller_MusicSequenceChanged(e As MusicSequenceEventArgs) Handles Controller.MusicSequenceChanged
        UpdateSequenceInList(e.Index)
        If e.Index = SelectedSequenceIndex Then
            LoadCurrentSequence(e.Index)
        End If
    End Sub

    Private Sub Controller_MusicSequenceAdded(e As MusicSequenceEventArgs) Handles Controller.MusicSequenceAdded
        AddSequenceToList(e.Index, True)
    End Sub

    Private Sub Controller_RomMusicLoaded() Handles Controller.RomMusicLoaded
        LoadSequenceList()
    End Sub

    'G u i

    Private Sub LoadSequenceList()
        TextBoxX_MS_Sequencename.ReadOnly = True
        ListBoxAdv_MS_MusicSequences.SuspendLayout()

        'Remember old Index
        Dim IndexBefore As Integer = SelectedSequenceIndex

        'Clear Items
        ListBoxAdv_MS_MusicSequences.Items.Clear()

        'Add new items
        For i As Integer = 0 To Controller.GetMusicSeuenceCount - 1
            AddSequenceToList(i, False)
        Next

        ListBoxAdv_MS_MusicSequences.ResumeLayout()
        ListBoxAdv_MS_MusicSequences.Refresh()
        SwitchButton_MS_OverwriteSizeRestrictions.Value = Controller.EnableMusicHack
        TextBoxX_MS_Sequencename.ReadOnly = False

        If IndexBefore < 0 Then IndexBefore = 1
        If ListBoxAdv_MS_MusicSequences.Items.Count > IndexBefore Then
            ListBoxAdv_MS_MusicSequences.SelectedIndex = IndexBefore
            ListBoxAdv_MS_MusicSequences.SelectedIndex = IndexBefore
        ElseIf ListBoxAdv_MS_MusicSequences.Items.Count > 1 Then
            ListBoxAdv_MS_MusicSequences.SelectedIndex = 1
        End If
    End Sub

    Private Sub RemoveSequenceFromList(index As Integer)
        ListBoxAdv_MS_MusicSequences.Items.RemoveAt(index)
        ListBoxAdv_MS_MusicSequences.Refresh()

        If index > 0 Then
            ListBoxAdv_MS_MusicSequences.SelectedItem = ListBoxAdv_MS_MusicSequences.Items(index - 1)
        End If
    End Sub

    Private Sub LoadCurrentSequence(index As Integer)
        Dim cIndex As Integer = index
        Dim IsNoIndex = cIndex < 0
        Dim IsIndex0 = cIndex = 0
        GroupBox_MS_SelectedSequence.Enabled = Not IsIndex0
        GroupBox_MS_SeqProperties.Enabled = Not IsIndex0
        ButtonX_MS_RemoveSequence.Enabled = Not IsIndex0

        'Load Sequence Informations
        If Not IsNoIndex Then
            Dim tID As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
            Dim info = Controller.GetMusicSequenceInfos(index)
            TextBoxX_MS_Sequencename.ReadOnly = True
            TextBoxX_MS_Sequencename.Text = info.name
            LabelX_MS_SequenceID.Text = String.Format("{0}", TextFromValue(tID))
            LabelX_MS_SeqSize.Text = String.Format("{0} Bytes", TextFromValue(info.length))
            ComboBox_MS_NInst.SelectedIndex = info.instSet
            TextBoxX_MS_Sequencename.ReadOnly = False
        End If
    End Sub

    Private Sub AddSequenceToList(index As Integer, refreshAndSelect As Boolean)
        Dim btnItem As New ButtonItem

        UpdateSequenceInList(index, btnItem)

        ListBoxAdv_MS_MusicSequences.Items.Insert(index, btnItem)

        If refreshAndSelect Then
            ListBoxAdv_MS_MusicSequences.Refresh()
            ListBoxAdv_MS_MusicSequences.EnsureVisible(btnItem)
        End If
    End Sub

    Private Sub UpdateSequenceInList(index As Integer)
        UpdateSequenceInList(index, ListBoxAdv_MS_MusicSequences.Items(index))
        ListBoxAdv_MS_MusicSequences.Refresh()
    End Sub

    Private Sub UpdateSequenceInList(index As Integer, buttonItem As ButtonItem)
        Dim infos = Controller.GetMusicSequenceInfos(index)
        Dim tName As String = $"{TextFromValue(index,, 2)} - {infos.name}"
        buttonItem.Text = tName
    End Sub

    Private Sub ListBoxAdv_MS_MusicSequences_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdv_MS_MusicSequences.SelectedItemChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            LoadCurrentSequence(SelectedSequenceIndex)
        End If
    End Sub

    Private Sub MusicSettings_SequenceNameChanged(sender As Object, e As EventArgs) Handles TextBoxX_MS_Sequencename.TextChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            Controller.SetMusicSequenceName(SelectedSequenceIndex, TextBoxX_MS_Sequencename.Text)
        End If
    End Sub

    Private Sub ComboBox_MS_NInst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_MS_NInst.SelectedIndexChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            Controller.SetMusicSequenceInstrumentSet(SelectedSequenceIndex, ComboBox_MS_NInst.SelectedIndex)
        End If
    End Sub

    Private Sub SwitchButton_MS_OverwriteSizeRestrictions_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_MS_OverwriteSizeRestrictions.ValueChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            Controller.EnableMusicHack = SwitchButton_MS_OverwriteSizeRestrictions.Value
        End If
    End Sub

    Private Sub Button_MS_ReplaceSequence_Click(sender As Object, e As EventArgs) Handles Button_MS_ReplaceSequence.Click
        Controller.ReplaceMusicSequence(SelectedSequenceIndex)
    End Sub

    Private Sub ButtonX_MS_AddSequence_Click(sender As Object, e As EventArgs) Handles ButtonX_MS_AddSequence.Click
        Controller.AddNewMusicSequence()
    End Sub

    Private Sub Button_MS_ExtractSequence_Click(sender As Object, e As EventArgs) Handles Button_MS_ExtractSequence.Click
        Controller.ExtractMusicSequence(SelectedSequenceIndex)
    End Sub

    Private Sub ButtonX_MS_RemoveSequence_Click(sender As Object, e As EventArgs) Handles ButtonX_MS_RemoveSequence.Click
        Controller.RemoveMusicSequence(SelectedSequenceIndex)
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Controller.EditMusicSequenceInHexEditor(SelectedSequenceIndex)
    End Sub

End Class
