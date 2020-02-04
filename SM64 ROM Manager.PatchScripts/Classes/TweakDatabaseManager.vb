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
        Dim list As New List(Of TweakDatabaseSyncFile)

        Dim res As PropfindResponse = Await client.Propfind(Preferences.CategoryPaths(TweakDatabaseCategories.Reviewed))
        Dim fileName As String = Path.GetFileName(res.Resources(1).Uri)

        '...

        client.Dispose()
        Return list
    End Function

    Public Sub Update(syncFiles As IEnumerable(Of TweakDatabaseSyncFile))
        Dim client As WebDavClient = CreateClient(TweakDatabaseLoginTypes.ReadOnlyAll)

        For Each syncFile As TweakDatabaseSyncFile In syncFiles
            '...
        Next

        client.Dispose()
    End Sub

    Public Async Function Upload(fileName As String) As Task(Of Boolean)
        Dim client As WebDavClient = CreateClient(TweakDatabaseLoginTypes.UserUploads)
        Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim result As WebDavResponse = Await client.PutFile(Path.GetFileName(fileName), fs)

        fs.Close()
        client.Dispose()

        Return result.IsSuccessful
    End Function

End Class
