Public Class LoaderOptions

    Public Property LoadMaterials As Boolean = False
    Public Property UpAxis As UpAxis = False

    Public Sub New()
    End Sub

    Public Sub New(loadMaterials As Boolean, upAxis As UpAxis)
        Me.LoadMaterials = loadMaterials
        Me.UpAxis = upAxis
    End Sub

End Class
