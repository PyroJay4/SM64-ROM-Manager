﻿Imports System.IO
Imports DevComponents.DotNetBar
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64Lib.Levels
Imports SM64Lib.Music

Public Class Tab_MusicManager

    Public Property MainForm As MainForm
    Public Property RomMgr As RomManager

    Public Sub New()
        InitializeComponent()
    End Sub

    Private ReadOnly Property SelectedSequence As MusicSequence
        Get
            Dim index As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
            If index > -1 Then
                Return RomMgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub ListBoxAdv_MS_MusicSequences_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdv_MS_MusicSequences.SelectedItemChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            LoadCurrentSequence()
        End If
    End Sub
    Private Sub MusicSettings_SequenceNameChanged(sender As Object, e As EventArgs) Handles TextBoxX_MS_Sequencename.TextChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            SelectedSequence.Name = TextBoxX_MS_Sequencename.Text
            RomMgr.MusicList.NeedToSaveSequenceNames = True
            MainForm.MusicSettings_RefreshList()
        End If
    End Sub
    Private Sub ComboBox_MS_NInst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_MS_NInst.SelectedIndexChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            With RomMgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex).InstrumentSets
                .Sets.Clear()
                .Sets.Add(ComboBox_MS_NInst.SelectedIndex)
            End With
            RomMgr.MusicList.NeedToSaveNInsts = True
        End If
    End Sub

    Private Sub SwitchButton_MS_OverwriteSizeRestrictions_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_MS_OverwriteSizeRestrictions.ValueChanged
        If TextBoxX_MS_Sequencename.ReadOnly Then Return
        RomMgr.MusicList.EnableMusicHack = SwitchButton_MS_OverwriteSizeRestrictions.Value
        RomMgr.MusicList.NeedToSaveMusicHackSettings = True
    End Sub

    Private Function MS_OpenFileDialog_SelectSequenceFile() As OpenFileDialog
        Dim ofd As New OpenFileDialog With {.Filter = "M64 Sequence (*.m64)|*.m64"}
        If ofd.ShowDialog = DialogResult.OK Then
            Return ofd
        Else
            Return Nothing
        End If
    End Function
    Private Sub Button_MS_ReplaceSequence_Click(sender As Object, e As EventArgs) Handles Button_MS_ReplaceSequence.Click, ButtonX_MS_AddSequence.Click
        Dim addNew As Boolean = sender Is ButtonX_MS_AddSequence

        If addNew Then
            Select Case RomMgr?.MusicList.Count
                Case 127
                    If MessageBoxEx.Show(Form_Main_Resources.MsgBox_LimitSequenceCountReached, Form_Main_Resources.MsgBox_LimitSequenceCountReached_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                        Return
                    End If
                Case Is >= 255
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_MaxSequenceCountReached, Form_Main_Resources.MsgBox_MaxSequenceCountReached_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
            End Select
        End If

        Dim ofd As OpenFileDialog = MS_OpenFileDialog_SelectSequenceFile()

        If ofd IsNot Nothing Then
            Dim curMusic As MusicSequence = Nothing
            If addNew Then
                MainForm.StatusText = Form_Main_Resources.Status_CreatingNewSequence
                curMusic = New MusicSequence
                RomMgr.MusicList.Add(curMusic)
                MainForm.MusicSettings_CreateList()
            Else
                MainForm.StatusText = Form_Main_Resources.Status_ImportingSequence
                curMusic = RomMgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)
            End If

            Select Case ofd.FilterIndex
                Case 1
                    Dim fs As New FileStream(ofd.FileName, FileMode.Open, FileAccess.Read)
                    curMusic.BinaryData = New Byte(fs.Length - 1) {}
                    fs.Read(curMusic.BinaryData, 0, fs.Length)
                    fs.Close()

            End Select

            curMusic.Name = Path.GetFileNameWithoutExtension(ofd.FileName)
            If curMusic.Name.Count > TextBoxX_MS_Sequencename.MaxLength Then
                curMusic.Name = curMusic.Name.Substring(0, TextBoxX_MS_Sequencename.MaxLength)
            End If

            curMusic.InstrumentSets.Sets.Clear()
            curMusic.InstrumentSets.Sets.Add(37)

            MainForm.MusicSettings_RefreshList()
            RomMgr.MusicList.NeedToSaveSequences = True
            RomMgr.MusicList.NeedToSaveSequenceNames = True
            If addNew Then RomMgr.MusicList.NeedToSaveNInsts = True
            MainForm.StatusText = ""

            If addNew Then
                Dim newItem As BaseItem = Nothing
                If ListBoxAdv_MS_MusicSequences.Items.Count > 0 Then _
                    newItem = ListBoxAdv_MS_MusicSequences.Items(ListBoxAdv_MS_MusicSequences.Items.Count - 1)
                ListBoxAdv_MS_MusicSequences.SelectedItem = newItem
                ListBoxAdv_MS_MusicSequences.EnsureVisible(newItem)
            Else
                ListBoxAdv_MS_MusicSequences_SelectedIndexChanged(ListBoxAdv_MS_MusicSequences, New EventArgs)
            End If
        End If
    End Sub
    Private Sub Button_MS_ExtractSequence_Click(sender As Object, e As EventArgs) Handles Button_MS_ExtractSequence.Click
        Dim curMusic As MusicSequence = RomMgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)

        Dim sfd As New CommonSaveFileDialog
        sfd.Filters.Add(New CommonFileDialogFilter("M64 Sequence", ".m64"))
        sfd.Filters.Add(New CommonFileDialogFilter("MIDI File", ".mid"))
        sfd.DefaultFileName = curMusic.Name
        sfd.Controls.Add(GetMidiExportDialogControls)
        AddHandler sfd.FileTypeChanged, AddressOf ExportSeqenceDialogFilterIndexChanged
        If sfd.ShowDialog <> DialogResult.OK Then Return

        MainForm.StatusText = Form_Main_Resources.Status_ExportingSequence

        Select Case sfd.SelectedFileTypeIndex
            Case 1 '.m64

                Try
                    Dim fs As New FileStream(sfd.FileName, FileMode.Create, FileAccess.Write)
                    fs.Write(curMusic.BinaryData, 0, curMusic.BinaryData.Length)
                    fs.Close()
                Catch ex As Exception
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_ErrorSavingSequence, Global_Ressources.Text_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case 2 '.midi
                Dim chunks As Byte = 2
                Select Case CType(sfd.Controls("MidiChunksSelector"), CommonFileDialogComboBox).SelectedIndex
                    Case 0
                        chunks = 1
                    Case 1
                        chunks = 2
                End Select

                'Create input stream
                Dim ms As New MemoryStream(curMusic.BinaryData)
                ms.Position = 0

                'Convert .m64 to .midi
                Try
                    OutputMIDI.ConvertToMIDI(sfd.FileName, ms, chunks, True)
                Catch ex As Exception
                    MessageBoxEx.Show(Form_Main_Resources.MsgBox_ExportToMidi_Failed & vbNewLine & ex.Message, Form_Main_Resources.MsgBox_ExportToMidi_Failed_Titel, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    ms.Close()
                End Try

        End Select

        MainForm.StatusText = ""
    End Sub

    Private Sub ExportSeqenceDialogFilterIndexChanged(sender As Object, e As EventArgs)
        Dim dialog As CommonSaveFileDialog = sender
        Dim filterIndex As Integer = dialog.SelectedFileTypeIndex
        Dim c As CommonFileDialogControl = dialog.Controls("MidiChunksSelector")
        c.Visible = filterIndex = 2
        dialog.DefaultExtension = dialog.Filters(dialog.SelectedFileTypeIndex - 1).Extensions.First
    End Sub

    Private Sub ButtonX_MS_RemoveSequence_Click(sender As Object, e As EventArgs) Handles ButtonX_MS_RemoveSequence.Click
        MainForm.MusicSettings_RemoveEntry()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        OpenHexEditor(SelectedSequence.BinaryData)
        RomMgr.MusicList.NeedToSaveSequences = True
        LoadCurrentSequence()
    End Sub

    Private Sub LoadCurrentSequence()
        Dim cIndex As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
        Dim IsNoIndex = (cIndex < 0)
        Dim IsIndex0 = (cIndex = 0)
        ' Dim IsIndex10 = (cIndex = 10)
        'Dim IsIndex23 = (cIndex < &H23)
        GroupBox_MS_SelectedSequence.Enabled = Not IsIndex0 'AndAlso Not IsIndex10
        GroupBox_MS_SeqProperties.Enabled = Not IsIndex0 'AndAlso Not IsIndex10
        ButtonX_MS_RemoveSequence.Enabled = Not IsIndex0 'Not IsIndex23

        If Not IsNoIndex Then
            'Load Sequence Informations
            Dim tID As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
            Dim item As MusicSequence = RomMgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)
            TextBoxX_MS_Sequencename.ReadOnly = True
            TextBoxX_MS_Sequencename.Text = item.Name
            LabelX_MS_SequenceID.Text = String.Format("{0}", TextFromValue(tID))
            LabelX_MS_SeqSize.Text = String.Format("{0} Bytes", TextFromValue(item.Lenght))
            ComboBox_MS_NInst.SelectedIndex = item.InstrumentSets.Sets(0)
            TextBoxX_MS_Sequencename.ReadOnly = False
        End If
    End Sub

End Class