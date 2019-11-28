Friend Class SerializedAssemblyMember

    Public ReadOnly Property Name As String
    Public ReadOnly Property Path As String
    Public ReadOnly Property Description As String
    Public ReadOnly Property Type As SerializedAssemblyMemberType
    Public ReadOnly Property Params As SerializedAssemblyMemberParam()

    Public Sub New(name As String, path As String, description As String, type As SerializedAssemblyMemberType, params As SerializedAssemblyMemberParam())
        Me.Name = name
        Me.Path = path
        Me.Description = description
        Me.Type = type
        Me.Params = params
    End Sub

End Class
