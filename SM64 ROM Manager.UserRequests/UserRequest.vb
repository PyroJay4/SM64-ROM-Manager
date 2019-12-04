Public Class UserRequest

    'F i e l d s

    Private ReadOnly props As New List(Of UserRequestProperty)

    'P r o p e r t i e s

    Public ReadOnly Property RequestName As String
    Friend ReadOnly Property UploadSettings As UserRequestUploadSettings

    Public ReadOnly Property Properties As IReadOnlyList(Of UserRequestProperty)
        Get
            Return props
        End Get
    End Property

    'C o n s t r u c t o r

    Public Sub New(style As UserRequestLayout)
        props.AddRange(style.Properties)
        UploadSettings = style.UploadSettings
        RequestName = style.Name
    End Sub

End Class
