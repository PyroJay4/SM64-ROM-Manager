Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports SM64_ROM_Manager.Publics
Imports System.IO

Public Class Tab_General

    'F i e l d s

    Public WithEvents Controller As MainController

    'C o n t r o l l e r   E v e n t s

    Private Sub Controller_RomLoading() Handles Controller.RomLoading
        TextBoxX_G_GameName.ReadOnly = True
        TextBoxX_G_GameName.Text = Controller.GetGameNAme
        TextBoxX_G_GameName.ReadOnly = False
        LabelX_G_Filesize.Text = String.Format("{0} Megabyte", CInt(Controller.GetRomFileSize))
    End Sub

    Private Sub Controller_RomLoaded() Handles Controller.RomLoaded
        LabelX_G_Filename.Text = Path.GetFileName(Controller.Romfile)
    End Sub

    'G u i

    Private Sub Button_G_SaveGameName_Click(sender As Object, e As EventArgs) Handles Button_G_SaveGameName.Click
        Try
            Controller.SetGameName(TextBoxX_G_GameName.Text)
        Catch ex As Exception
            MessageBoxEx.Show(Form_Main_Resources.MsgBox_GameNameHasInvalidChars, Global_Ressources.Text_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Button_G_SaveGameName.Enabled = False
    End Sub

    Private Sub TextBoxX_G_GameName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_G_GameName.TextChanged
        If TextBoxX_G_GameName.ReadOnly Then Return
        Button_G_SaveGameName.Enabled = True
    End Sub

End Class
