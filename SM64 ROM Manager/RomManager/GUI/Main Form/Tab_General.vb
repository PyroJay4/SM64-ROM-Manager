Imports DevComponents.DotNetBar
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib
Imports Publics
Imports System.IO

Public Class Tab_General

    Public Property MainForm As MainForm
    Public Property RomMgr As RomManager

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button_G_SaveGameName_Click(sender As Object, e As EventArgs) Handles Button_G_SaveGameName.Click
        Try
            TextBoxX_G_GameName.Text = TextBoxX_G_GameName.Text.Trim
            RomMgr.GameName = TextBoxX_G_GameName.Text
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
