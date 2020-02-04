Imports Newtonsoft.Json

Public Class TweakDatabaseLoginPreferences

    Private Shared crypter As New drsPwEnc.drsPwEnc

    <JsonProperty(NameOf(Link))>
    Private encryptedLink As String

    <JsonProperty(NameOf(Username))>
    Private encryptedUsername As String

    <JsonProperty(NameOf(Password))>
    Private encryptedPassword As String

    <JsonIgnore>
    Public ReadOnly Property Link As String
        Get
            Return crypter.DecryptData(encryptedLink)
        End Get
    End Property

    <JsonIgnore>
    Public ReadOnly Property Username As String
        Get
            Return crypter.DecryptData(encryptedUsername)
        End Get
    End Property

    <JsonIgnore>
    Public ReadOnly Property Password As String
        Get
            Return crypter.DecryptData(encryptedPassword)
        End Get
    End Property


End Class
