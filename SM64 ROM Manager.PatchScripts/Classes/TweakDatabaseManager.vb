Imports System.IO
Imports System.Net
Imports WebDav

Public Class TweakDatabaseManager

    Private Shared ReadOnly crypter As New drsPwEnc.drsPwEnc

    Public ReadOnly Property Preferences As TweakDatabasePreferences

    Public Sub New(pref As TweakDatabasePreferences)
        Preferences = pref
    End Sub

    Private Function CreateClient(t As TweakDatabaseLoginTypes) As WebDavClient
        Dim login As TweakDatabaseLoginPreferences = Preferences.Logins(t)
        Dim params As New WebDavClientParams With {
            .BaseAddress = New Uri(login.Link),
            .Credentials = New NetworkCredential(login.Username, login.Password)
        }
        Return New WebDavClient(params)
    End Function

    Public Async Function CheckForUpdates(localPath As String) As Task(Of IEnumerable(Of TweakDatabaseSyncFile))
        Dim client As WebDavClient = CreateClient(TweakDatabaseLoginTypes.ReadOnlyAll)
        Dim syncFiles As New List(Of TweakDatabaseSyncFile)
        Dim checkOutFolder As Func(Of String, Task) = Nothing
        Dim resTopFolder As WebDavResource = Nothing

        checkOutFolder =
            Async Function(remotePath As String) As Task
                Dim response As PropfindResponse = Await client.Propfind(remotePath)

                If resTopFolder Is Nothing AndAlso response.Resources.Any Then
                    resTopFolder = response.Resources(0)
                End If

                If response.Resources.Count > 1 Then
                    For i As Integer = 1 To response.Resources.Count - 1
                        Dim res As WebDavResource = response.Resources(i)
                        Dim isFolder As Boolean = False

                        'Check for folder
                        For Each prop As WebDavProperty In res.Properties
                            If prop.Name = "{DAV:}getcontenttype" AndAlso prop.Value = "<d:collection xmlns:d=""DAV:"" />" Then
                                isFolder = True
                            End If
                        Next

                        If isFolder Then
                            Await checkOutFolder(res.Uri)
                        Else
                            Dim syncAction As TweakDatabaseSyncAction? = Nothing
                            Dim localFile As String = String.Empty
                            Dim remoteFile As String = String.Empty

                            'Get remote file path
                            remoteFile = res.Uri.Substring(Path.GetDirectoryName(resTopFolder.Uri).Length)

                            'Get local file path
                            localFile = Path.Combine(localPath, res.Uri.Substring(resTopFolder.Uri.Length))

                            'Check action
                            If File.Exists(localFile) Then
                                If File.GetLastWriteTime(localFile) < res.LastModifiedDate Then
                                    syncAction = TweakDatabaseSyncAction.UpdatedFile
                                End If
                            Else
                                syncAction = TweakDatabaseSyncAction.NewFile
                            End If

                            'Add to list
                            If syncAction IsNot Nothing Then
                                syncFiles.Add(New TweakDatabaseSyncFile(syncAction, localFile, remoteFile))
                            End If
                        End If
                    Next
                End If
            End Function

        'Check for new & updated files
        Await checkOutFolder(Preferences.CategoryPaths(TweakDatabaseCategories.Reviewed))

        'Find all old files to remove
        Dim allLocalFiles As String() = Directory.GetFiles(localPath, String.Empty, SearchOption.AllDirectories)
        For Each lf As String In allLocalFiles
            Dim isKnown As Boolean = False

            For Each syncFile As TweakDatabaseSyncFile In syncFiles
                If Not isKnown AndAlso syncFile.LocalFile = lf Then
                    isKnown = True
                End If
            Next

            If Not isKnown Then
                syncFiles.Add(New TweakDatabaseSyncFile(TweakDatabaseSyncAction.RemovedFile, lf, String.Empty))
            End If
        Next

        client.Dispose()
        Return syncFiles
    End Function

    Public Async Function Update(syncFiles As IEnumerable(Of TweakDatabaseSyncFile)) As Task
        Dim client As WebDavClient = CreateClient(TweakDatabaseLoginTypes.ReadOnlyAll)

        For Each syncFile As TweakDatabaseSyncFile In syncFiles
            If syncFile.SyncAction = TweakDatabaseSyncAction.UpdatedFile OrElse syncFile.SyncAction = TweakDatabaseSyncAction.RemovedFile Then
                File.Delete(syncFile.LocalFile)
            End If

            If syncFile.SyncAction = TweakDatabaseSyncAction.UpdatedFile OrElse syncFile.SyncAction = TweakDatabaseSyncAction.NewFile Then
                Dim response As WebDavStreamResponse = Await client.GetProcessedFile(syncFile.RemoteFile)
                Dim dirParent As New DirectoryInfo(Path.GetDirectoryName(syncFile.LocalFile))

                If Not dirParent.Exists Then
                    dirParent.Create()
                End If

                Dim fs As New FileStream(syncFile.LocalFile, FileMode.Create, FileAccess.Write)
                response.Stream.CopyTo(fs)
                fs.Close()
            End If
        Next

        client.Dispose()
    End Function

    Public Async Function Upload(fileName As String) As Task(Of Boolean)
        Dim client As WebDavClient = CreateClient(TweakDatabaseLoginTypes.UserUploads)
        Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim result As WebDavResponse = Await client.PutFile(Path.GetFileName(fileName), fs)

        fs.Close()
        client.Dispose()

        Return result.IsSuccessful
    End Function

End Class
