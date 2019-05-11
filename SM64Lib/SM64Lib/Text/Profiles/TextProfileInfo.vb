Namespace Global.SM64Lib.Text.Profiles

    Public Class TextProfileInfo

        Public Property Sections As New List(Of TextSectionInfo)

        Public Function GetSection(name As String) As TextSectionInfo
            Return Sections.FirstOrDefault(Function(n) n.Name = name)
        End Function

    End Class

End Namespace
