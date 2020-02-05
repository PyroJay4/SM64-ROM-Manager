Public Class TweakDatabaseSyncFile

    Public ReadOnly Property SyncAction As TweakDatabaseSyncAction
    Public ReadOnly Property LocalFile As String
    Public ReadOnly Property RemoteFile As String

    Friend Sub New(syncAction As TweakDatabaseSyncAction, localFile As String, remoteFile As String)
        Me.SyncAction = syncAction
        Me.LocalFile = localFile
        Me.RemoteFile = remoteFile
    End Sub

End Class
