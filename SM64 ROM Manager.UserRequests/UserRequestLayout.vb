Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class UserRequestLayout

    'F i e l d s

    <JsonProperty>
    Friend Property Name As String
    <JsonProperty>
    Friend Property Properties As UserRequestProperty()
    <JsonProperty>
    Friend Property UploadSettings As UserRequestUploadSettings

    'C o n s t r u c t o r

    Private Sub New()
    End Sub

    'S h a r e d   F e a t u r e s

    Public Shared Function LoadFrom(filePath As String) As UserRequestLayout
        Dim fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim layout As UserRequestLayout = LoadFrom(fs)
        fs.Close()
        Return layout
    End Function

    Public Shared Function LoadFrom(stream As Stream) As UserRequestLayout
        Dim reader As New StreamReader(stream)
        Dim style As UserRequestLayout = JObject.Parse(reader.ReadToEnd).ToObject(Of UserRequestLayout)
        reader.Close()
        Return style
    End Function

End Class
