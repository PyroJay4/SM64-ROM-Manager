Imports System.IO
Imports System.Resources
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib.Level
Imports SM64Lib.Music
Imports TextValueConverter

Partial Class Form_Main

    Private Sub ListBoxAdv_MS_MusicSequences_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdv_MS_MusicSequences.SelectedItemChanged
        If TextBoxX_MS_Sequencename.ReadOnly Then Return

        Dim cIndex As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
        Dim IsNoIndex = (cIndex < 0)
        Dim IsIndex0 = (cIndex = 0)
        ' Dim IsIndex10 = (cIndex = 10)
        'Dim IsIndex23 = (cIndex < &H23)
        GroupBox_MS_SelectedSequence.Enabled = Not IsIndex0 'AndAlso Not IsIndex10
        GroupBox_MS_SeqProperties.Enabled = Not IsIndex0 'AndAlso Not IsIndex10
        'ButtonX_MS_RemoveSequence.Enabled = Not IsIndex23

        If Not IsNoIndex Then
            'Load Sequence Informations
            Dim tID As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
            Dim item As MusicSequence = rommgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)
            TextBoxX_MS_Sequencename.ReadOnly = True
            TextBoxX_MS_Sequencename.Text = item.Name
            LabelX_MS_SequenceID.Text = String.Format("{0}", TextFromValue(tID))
            LabelX_MS_SeqSize.Text = String.Format("{0} Bytes", TextFromValue(item.Lenght))
            ComboBox_MS_NInst.SelectedIndex = item.InstrumentSets.Sets(0)
            TextBoxX_MS_Sequencename.ReadOnly = False
        End If
    End Sub
    Private Sub MusicSettings_SequenceNameChanged(sender As Object, e As EventArgs) Handles TextBoxX_MS_Sequencename.TextChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            rommgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex).Name = TextBoxX_MS_Sequencename.Text
            rommgr.MusicList.NeedToSaveSequenceNames = True
            MusicSettings_RefreshList()
        End If
    End Sub
    Private Sub MusicSettings_CreateList()
        Dim IndexBefore1 As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
        Dim IndexBefore2 As Integer = ComboBox_LM_Music.SelectedIndex

        TextBoxX_MS_Sequencename.ReadOnly = True
        ListBoxAdv_MS_MusicSequences.Items.Clear()
        ComboBox_LM_Music.Items.Clear()

        For Each s As MusicSequence In rommgr.MusicList
            ListBoxAdv_MS_MusicSequences.Items.Add(New ButtonItem)
            ComboBox_LM_Music.Items.Add("")
        Next
        MusicSettings_RefreshList()

        SwitchButton_MS_OverwriteSizeRestrictions.Value = rommgr.MusicList.EnableMusicHack
        TextBoxX_MS_Sequencename.ReadOnly = False

        If IndexBefore1 < 0 Then IndexBefore1 = 1
        If IndexBefore2 < 0 Then IndexBefore2 = 3
        If ListBoxAdv_MS_MusicSequences.Items.Count > IndexBefore1 Then ListBoxAdv_MS_MusicSequences.SelectedIndex = IndexBefore1
        If ComboBox_LM_Music.Items.Count > IndexBefore2 Then ComboBox_LM_Music.SelectedIndex = IndexBefore2
    End Sub
    Private Sub MusicSettings_RefreshList()
        For i As Integer = 0 To rommgr.MusicList.Count - 1
            Dim tName As String = $"{TextFromValue(i,, 2)} - {rommgr.MusicList(i).Name}"
            ListBoxAdv_MS_MusicSequences.Items(i).Text = tName
            ComboBox_LM_Music.Items(i) = tName
        Next
        ListBoxAdv_MS_MusicSequences.Refresh()
        ComboBox_LM_Music.Refresh()
        StyleManager.UpdateAmbientColors(ListBoxAdv_MS_MusicSequences)
    End Sub
    Private Sub ComboBox_MS_NInst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_MS_NInst.SelectedIndexChanged
        If Not TextBoxX_MS_Sequencename.ReadOnly Then
            With rommgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex).InstrumentSets
                .Sets.Clear()
                .Sets.Add(ComboBox_MS_NInst.SelectedIndex)
            End With
            rommgr.MusicList.NeedToSaveNInsts = True
        End If
    End Sub

    Private Sub SwitchButton_MS_OverwriteSizeRestrictions_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton_MS_OverwriteSizeRestrictions.ValueChanged
        If TextBoxX_MS_Sequencename.ReadOnly Then Return
        rommgr.MusicList.EnableMusicHack = SwitchButton_MS_OverwriteSizeRestrictions.Value
        rommgr.MusicList.NeedToSaveMusicHackSettings = True
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
            Select Case rommgr?.MusicList.Count
                Case 127
                    If MessageBox.Show(Form_Main_Resources.MsgBox_LimitSequenceCountReached, Form_Main_Resources.MsgBox_LimitSequenceCountReached_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
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
                StatusText = Form_Main_Resources.Status_CreatingNewSequence
                curMusic = New MusicSequence
                rommgr.MusicList.Add(curMusic)
                MusicSettings_CreateList()
            Else
                StatusText = Form_Main_Resources.Status_ImportingSequence
                curMusic = rommgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)
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

            MusicSettings_RefreshList()
            rommgr.MusicList.NeedToSaveSequences = True
            rommgr.MusicList.NeedToSaveSequenceNames = True
            If addNew Then rommgr.MusicList.NeedToSaveNInsts = True
            StatusText = ""

            If addNew Then
                Dim newItem As BaseItem = Nothing
                If ListBoxAdv_MS_MusicSequences.Items.Count > 0 Then _
                    newItem = ListBoxAdv_MS_MusicSequences.Items(ListBoxAdv_MS_MusicSequences.Items.Count - 1)
                ListBoxAdv_MS_MusicSequences.SelectedItem = newItem
            Else
                ListBoxAdv_MS_MusicSequences_SelectedIndexChanged(ListBoxAdv_MS_MusicSequences, New EventArgs)
            End If
        End If
    End Sub
    Private Sub Button_MS_ExtractSequence_Click(sender As Object, e As EventArgs) Handles Button_MS_ExtractSequence.Click
        Dim curMusic As MusicSequence = rommgr.MusicList(ListBoxAdv_MS_MusicSequences.SelectedIndex)

        Dim sfd As New SaveFileDialog
        sfd.Filter = "M64 Sequence (*.m64)|*.m64|MIDI File (*.mid) [Experimental]|*.mid"
        sfd.FileName = curMusic.Name
        If sfd.ShowDialog <> DialogResult.OK Then Return

        Try
            StatusText = Form_Main_Resources.Status_ExportingSequence

            Select Case sfd.FilterIndex
                Case 1 '.m64
                    Dim fs As New FileStream(sfd.FileName, FileMode.Create, FileAccess.Write)
                    fs.Write(curMusic.BinaryData, 0, curMusic.BinaryData.Length)
                    fs.Close()

                Case 2 '.midi
                    Dim ms As New MemoryStream(curMusic.BinaryData)
                    ms.Position = 0
                    OutputMIDI.ConvertToMIDI(sfd.FileName, ms, &H1, True)
                    ms.Position = 0
                    OutputMIDI.ConvertToMIDI(sfd.FileName, ms, &H2, True)
                    ms.Close()

            End Select
        Catch ex As Exception
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_ErrorSavingSequence, Global_Ressources.Text_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            StatusText = ""
        End Try
    End Sub

    Private Sub ButtonX_MS_RemoveSequence_Click(sender As Object, e As EventArgs) Handles ButtonX_MS_RemoveSequence.Click
        Dim index As Integer = ListBoxAdv_MS_MusicSequences.SelectedIndex
        If index >= 0 Then
            rommgr.MusicList.RemoveAt(index)
            ListBoxAdv_MS_MusicSequences.Items.RemoveAt(index)
            ComboBox_LM_Music.Items.RemoveAt(index)

            For Each lvl As Level In rommgr.Levels
                For Each a As LevelArea In lvl.Areas
                    If a.BGMusic = index Then
                        Do While a.BGMusic >= rommgr.MusicList.Count
                            a.BGMusic -= 1
                        Loop
                    ElseIf a.BGMusic > index Then
                        a.BGMusic -= 1
                    End If
                Next
            Next

            MusicSettings_CreateList()
        End If
    End Sub

End Class
