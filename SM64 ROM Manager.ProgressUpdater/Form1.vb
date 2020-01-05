Imports System.IO
Imports System.Net
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json.Linq
Imports WebDav

Public Class Form1

    'C o n s t a n t s

    Private Const TEMP_DIR_FOLDER_NAME As String = "SM64RM Progress Updater"
    Private Const TEMP_CONF_FILE_NAME As String = "config.dat"
    Private Const CONF_PROXY_USR As String = "ProxyUsr"
    Private Const CONF_PROXY_PWD As String = "ProxyPwd"
    Private Const CONF_WEBDAV_USR As String = "WebDavUsr"
    Private Const CONF_WEBDAV_PWD As String = "WebDavPwd"
    Private Const CONF_WEBDAV_URI As String = "WebDavUri"
    Private Const CONF_VERSION As String = "Version"

    'F i e l d s

    Private ReadOnly crypter As New drsPwEnc.drsPwEnc

    Private Sub PasteFromClipboard()
        If Clipboard.ContainsImage Then
            PictureBox1.Image = Clipboard.GetImage
        End If
    End Sub

    Private Async Function Upload() As Task(Of Boolean)
        Dim result As Boolean
        Dim usr As String = TextBoxX_ProxUsr.Text.Trim
        Dim pwd As String = TextBoxX_ProxPwd.Text
        Dim vers As String = TextBoxX_Version.Text.Trim
        Dim uri As String = TextBoxX_WebDavUploadUri.Text.Trim

        If String.IsNullOrEmpty(uri) OrElse String.IsNullOrEmpty(vers) Then
            result = False
        Else
            'Set web proxy
            If Not String.IsNullOrEmpty(usr) OrElse Not String.IsNullOrEmpty(pwd) Then
                WebRequest.DefaultWebProxy.Credentials = New NetworkCredential(usr, pwd)
            End If

            'Create client
            Dim clientparams As New WebDavClientParams With {
                .BaseAddress = New Uri(uri),
                .Credentials = New NetworkCredential(TextBoxX_WebDavUploadUsr.Text.Trim, TextBoxX_WebDavUploadPwd.Text)
            }
            Dim client As New WebDavClient(clientparams)

            'Save image to memory
            Dim msImage As New MemoryStream
            PictureBox1.Image.Save(msImage, Imaging.ImageFormat.Png)
            msImage.Position = 0

            'Upload image
            Try
                Dim res As WebDavResponse = Await client.PutFile($"{vers}.png", msImage)
                result = res.IsSuccessful
            Catch ex As Exception
                result = False
            Finally
                msImage.Close()
            End Try
        End If

        Return result
    End Function

    Private Function GetTempDirPath() As DirectoryInfo
        Return New DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), TEMP_DIR_FOLDER_NAME))
    End Function

    Private Sub SaveConfig()
        Dim obj As New JObject

        obj(CONF_PROXY_USR) = TextBoxX_ProxUsr.Text
        obj(CONF_PROXY_PWD) = TextBoxX_ProxPwd.Text
        obj(CONF_WEBDAV_URI) = TextBoxX_WebDavUploadUri.Text
        obj(CONF_WEBDAV_USR) = TextBoxX_WebDavUploadUsr.Text
        obj(CONF_WEBDAV_PWD) = TextBoxX_WebDavUploadPwd.Text
        obj(CONF_VERSION) = TextBoxX_Version.Text

        Dim dir As DirectoryInfo = GetTempDirPath()
        Dim confFile As String = Path.Combine(dir.FullName, TEMP_CONF_FILE_NAME)

        If Not dir.Exists Then
            dir.Create()
        End If

        Dim raw As String = crypter.EncryptData(obj.ToString)
        File.WriteAllText(confFile, raw)
    End Sub

    Private Sub LoadConfig()
        Dim dir As DirectoryInfo = GetTempDirPath()
        Dim confFile As String = Path.Combine(dir.FullName, TEMP_CONF_FILE_NAME)

        If File.Exists(confFile) Then
            Dim raw As String = File.ReadAllText(confFile)
            Dim obj As JObject = JObject.Parse(crypter.DecryptData(raw))

            TextBoxX_ProxUsr.Text = obj(CONF_PROXY_USR)
            TextBoxX_ProxPwd.Text = obj(CONF_PROXY_PWD)
            TextBoxX_WebDavUploadUri.Text = obj(CONF_WEBDAV_URI)
            TextBoxX_WebDavUploadUsr.Text = obj(CONF_WEBDAV_USR)
            TextBoxX_WebDavUploadPwd.Text = obj(CONF_WEBDAV_PWD)
            TextBoxX_Version.Text = obj(CONF_VERSION)
        End If
    End Sub

    'G u i

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX_PasteClipboard.Click
        PasteFromClipboard()
    End Sub

    Private Async Sub ButtonX_Upload_Click(sender As Object, e As EventArgs) Handles ButtonX_Upload.Click
        If Await Upload() Then
            MessageBoxEx.Show("Erfolgreich hochgeladen!", "Hochladen", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show("Fehler beim Hochladen!", "Hochladen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadConfig()
        PasteFromClipboard()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveConfig()
    End Sub

End Class
