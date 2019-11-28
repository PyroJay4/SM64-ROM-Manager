Imports System.Drawing
Imports SM64Lib.Model
Imports SM64Lib.Model.ObjectInputSettings

Public Class GuiInputSettings

    Public Property Scaling As Double = 500.0F
    Public Property ReduceDupVerts = ReduceDuplicateVerticesLevel.Level1
    Public Property Fog As Fog = Nothing
    Public Property ResizeTextures As Boolean = True
    Public Property CenterModel As Boolean = False
    Public ReadOnly Property Shading As New Pilz.S3DFileParser.Shading With {.AmbientColor = Color.FromArgb(&HFF7F7F7F), .DiffuseColor = Color.FromArgb(&HFFFFFFFF), .DiffusePosition = Nothing}
    Public Property OptimizeTransparencyChecks As Boolean = False

End Class
