Imports System.IO
Imports System.Reflection
Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.SettingsManager
Imports ApplyPPF.My.Resources

Public Class ApplyPPFDialog

    Private romFile As String = ""
    Private patchFile As String = ""

    Public Sub New()
        If Assembly.GetExecutingAssembly = Assembly.GetEntryAssembly Then
            Settings.AutoSave = False
            Settings.SettingsConfigFilePath = Path.Combine(Application.StartupPath, "Data\Settings.json")
            StyleManager.Style = eStyle.Metro
            StyleManager.MetroColorGeneratorParameters = Settings.StyleManager.MetroColorParams
        End If
        InitializeComponent()
    End Sub
    Public Sub New(romFile As String, patchFile As String)
        Me.New
        Me.romFile = romFile
        Me.patchFile = patchFile
        UpdateSafeFileNames()
    End Sub

    Private Sub UpdateSafeFileNames()
        LabelX3.Text = If(Not String.IsNullOrEmpty(romFile), Path.GetFileName(romFile), ApplyPPFTranslation.Text_NoFileLoaded)
        LabelX4.Text = If(Not String.IsNullOrEmpty(patchFile), Path.GetFileName(patchFile), ApplyPPFTranslation.Text_NoFileLoaded)
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        ApplyPPF(romFile, patchFile, CheckBoxX1.Checked)
    End Sub

    Private Sub ApplyPPF(romFile As String, patchFile As String, updateChecksum As Boolean)
        Try
            Dim p As New Process
            p.StartInfo.FileName = Path.Combine(Application.StartupPath, "Data\Tools\ApplyPPF3.exe")
            p.StartInfo.Arguments = $"a ""{romFile}"" ""{patchFile}"""
            p.StartInfo.CreateNoWindow = True
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            p.StartInfo.ErrorDialog = True
            p.Start()
            SetEnabled(False)
            Do Until p.HasExited
                Application.DoEvents()
            Loop
            If updateChecksum Then
                SM64Lib.PatchClass.UpdateChecksum(romFile)
            End If
            MessageBoxEx.Show(Me, ApplyPPFTranslation.MsgBox_Success, ApplyPPFTranslation.MsgBox_Success_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As FileNotFoundException
            MessageBoxEx.Show(Me, ApplyPPFTranslation.MsgBox_FileNotFound, ApplyPPFTranslation.MsgBox_FileNotFound_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBoxEx.Show(Me, ApplyPPFTranslation.MsgBox_UnkownError, ApplyPPFTranslation.MsgBox_UnkownError_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SetEnabled(True)
        End Try
    End Sub

    Private Sub SetEnabled(value As Boolean)
        CircularProgress1.IsRunning = Not value
        CircularProgress1.Visible = Not value
        ButtonX1.Visible = value
        ButtonX2.Enabled = value
        ButtonX3.Enabled = value
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Dim ofd As New OpenFileDialog With {.Filter = "SM64 ROMs (*.z64)|*.z64|All files|*"}
        If ofd.ShowDialog = DialogResult.OK Then
            romFile = ofd.FileName
            UpdateSafeFileNames()
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Dim ofd As New OpenFileDialog With {.Filter = "PPF Patch (*.ppf)|*.ppf|All files|*"}
        If ofd.ShowDialog = DialogResult.OK Then
            patchFile = ofd.FileName
            UpdateSafeFileNames()
        End If
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles LabelX3.TextChanged, LabelX4.TextChanged
        ButtonX1.Enabled = Not String.IsNullOrEmpty(romFile) AndAlso Not String.IsNullOrEmpty(patchFile)
    End Sub
End Class
