Imports System.IO
Imports System.Net
Imports WebDav

Friend Class UserRequestUploadManager

    'F i e l d s

    Private ReadOnly crypter As New drsPwEnc.drsPwEnc

    'F e a t u r e s

    Private Function CreateParams(settings As UserRequestUploadSettings) As WebDavClientParams
        Return New WebDavClientParams With {
            .BaseAddress = New Uri(crypter.DecryptData(settings.Link)),
            .Credentials = New NetworkCredential(crypter.DecryptData(settings.Username), crypter.DecryptData(settings.Password))
        }
    End Function

    Private Function CreateClient(settings As UserRequestUploadSettings) As WebDavClient
        Dim params As WebDavClientParams = CreateParams(settings)
        Return New WebDavClient(params)
    End Function

    Private Async Function UploadFile(client As WebDavClient, filePath As String, uploadName As String) As Task(Of Boolean)
        Dim sFile As New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim result As WebDavResponse = Await client.PutFile(uploadName, sFile)
        sFile.Close()
        Return result.IsSuccessful
    End Function

    Public Async Function Upload(filePath As String, uploadName As String, settings As UserRequestUploadSettings) As Task(Of Boolean)
        Return Await UploadFile(CreateClient(settings), filePath, uploadName)
    End Function

End Class
