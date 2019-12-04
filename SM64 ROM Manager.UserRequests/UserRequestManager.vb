Imports System.IO
Imports System.IO.Compression

Public Class UserRequestManager

    Private Async Function GenerateInfo(request As UserRequest) As Task(Of String)
        Dim writer As New StringWriter

        For Each prop As UserRequestProperty In request.Properties
            Await writer.WriteLineAsync(prop.Name)

            Select Case prop.Type
                Case UserRequestPropertyType.Text, UserRequestPropertyType.LongText
                    Await writer.WriteLineAsync(prop.Value)
                Case UserRequestPropertyType.Files
            End Select

            Await writer.WriteLineAsync()
        Next

        Return writer.ToString
    End Function

    Private Sub CopyAttachments(request As UserRequest, destDir As DirectoryInfo)
        For Each prop As UserRequestProperty In request.Properties.Where(Function(n) n.Type = UserRequestPropertyType.Files)
            If Not String.IsNullOrEmpty(prop.Value) Then
                Dim dir As DirectoryInfo = destDir.CreateSubdirectory(prop.Name)
                For Each f As String In prop.Value.Split(",")
                    File.Copy(f, Path.Combine(dir.FullName, Path.GetFileName(f)))
                Next
            End If
        Next
    End Sub

    Public Async Function UploadRequest(request As UserRequest) As Task(Of Boolean)
        Dim curDate As Date = Now.ToUniversalTime
        Dim zipFileName As String = curDate.ToString("yyyy.MM.dd HH.mm.ss.fffffff") & ".zip"
        Dim files As New Dictionary(Of String, String)
        Dim zipDir As DirectoryInfo
        Dim tempDir As DirectoryInfo

        'Create temporary folder
        tempDir = New DirectoryInfo(Path.Combine(Path.GetTempPath, "SM64 ROM Manager\UserRequestUploads"))
        If tempDir.Exists Then
            tempDir.Delete(True)
        End If
        tempDir.Create()
        zipDir = tempDir.CreateSubdirectory("pkg")

        'Copy attachments
        CopyAttachments(request, zipDir)

        'Write help text
        Dim info As String = Await GenerateInfo(request)
        File.WriteAllText(Path.Combine(zipDir.FullName, "request.txt"), info)

        'Zip temporary folder
        Dim zipFilePath As String = Path.Combine(tempDir.FullName, zipFileName)
        ZipFile.CreateFromDirectory(zipDir.FullName, zipFilePath)

        'Delete package directory
        zipDir.Delete(True)

        'Upload
        Dim mgr As New UserRequestUploadManager
        Dim result As Boolean = Await mgr.Upload(zipFilePath, zipFileName, request.UploadSettings)

        'Return result
        Return result
    End Function

End Class
