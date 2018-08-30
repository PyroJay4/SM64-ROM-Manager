Imports System.Collections.Specialized
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports S3DFileParser

Public Module Publics

    Public Async Sub ExportModel(model As Object3D, modul As LoaderModule)
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

    Public Sub AddRecentFile(ByRef collection As StringCollection, fileName As String)
        If collection.Contains(fileName) Then
            collection.Remove(fileName)
        End If

        collection.Insert(0, fileName)
    End Sub

    Public Sub MergeRecentFiles(ByRef collection As StringCollection)
        Dim toRemove As New List(Of String)

        For Each f As String In collection
            If Not IO.File.Exists(f) Then
                toRemove.Add(f)
            End If
        Next

        For Each f As String In toRemove
            collection.Remove(f)
        Next
    End Sub

End Module
