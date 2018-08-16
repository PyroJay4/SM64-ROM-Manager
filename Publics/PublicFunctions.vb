Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports S3DFileParser

Public Class Publics

    Public Shared Async Sub ExportModel(model As Object3D, modul As LoaderModule)
        Dim sfd As New SaveFileDialog
        Dim strFilter As String = GetExtensionFilter(modul)
        sfd.Filter = strFilter.Substring(strFilter.IndexOf("|", strFilter.IndexOf("|") + 1) + 1)

        If modul <> LoaderModule.SimpleFileParser Then
            MessageBoxEx.Show("Assimp and Aspose probably crashes at exporting.<br/>Please switch to SimpleFileParser in <b>Settings --> File Parser</b>.<br/>Assimp and Aspose will be working soon.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        If sfd.ShowDialog = DialogResult.OK Then
            Await model.ToFileAsync(sfd.FileName, modul)
        End If
    End Sub

End Class
