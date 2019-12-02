Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class UserRequestPropertyStyle

    'F i e l d s

    <JsonProperty>
    Friend Property Properties As UserRequestProperty()
    <JsonProperty>
    Friend Property UploadSettings As UserRequestUploadSettings

    'C o n s t r u c t o r

    Private Sub New()
    End Sub

    'S h a r e d   F e a t u r e s

    Public Shared Function LoadFrom(stream As Stream) As UserRequestPropertyStyle
        Dim reader As New StreamReader(stream)
        Dim style As UserRequestPropertyStyle = JObject.Parse(reader.ReadToEnd).ToObject(Of UserRequestPropertyStyle)
        reader.Close()
        Return style
    End Function

End Class
