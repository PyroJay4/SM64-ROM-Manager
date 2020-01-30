Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64Lib.Model
Imports SM64Lib.Model.ObjectInputSettings

Public Class GuiInputPreferences

    Public Property Scaling As Double = 500.0F
    Public Property ReduceDupVerts = ReduceDuplicateVerticesLevel.Level1
    Public Property Fog As Fog = Nothing
    Public Property ResizeTextures As Boolean = True
    Public Property CenterModel As Boolean = False
    Public ReadOnly Property Shading As New Pilz.S3DFileParser.Shading With {.AmbientColor = Color.FromArgb(&HFF7F7F7F), .DiffuseColor = Color.FromArgb(&HFFFFFFFF), .DiffusePosition = Nothing}
    Public Property OptimizeTransparencyChecks As Boolean = False

    Public Shared Function Load(filePath As String) As GuiInputPreferences
        If File.Exists(filePath) Then
            Return JObject.Parse(File.ReadAllText(filePath)).ToObject(Of GuiInputPreferences)
        Else
            Return New GuiInputPreferences
        End If
    End Function

    Public Sub Save(filePath As String)
        File.WriteAllText(filePath, JObject.FromObject(Me).ToString)
    End Sub

End Class
