Namespace ImporterPresets

    Public Class ImporterProfile

        Public Property Name As String = ""
        Public Property Description As String = ""
        Public ReadOnly Property Presets As New List(Of ImporterPreset)
        Public Property Version As New Version("1.0.0.0")
        Public Property FileName As String = ""

    End Class

    Public Class ImporterPreset

        Public Property Name As String = ""
        Public Property Description As String = ""

        Public Property Script As PatchScripts.PatchScript = Nothing

        Public Property RomAddress As Integer = 0
        Public Property RamAddress As Integer = 0
        Public Property MaxLength As Integer = 0

        Public ReadOnly Property CollisionPointers As New List(Of Integer)
        Public ReadOnly Property GeometryPointers As New List(Of Integer)

    End Class

End Namespace
