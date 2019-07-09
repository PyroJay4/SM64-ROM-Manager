Friend Class SerializedAssemblyMemberParam

    Public ReadOnly Property Name As String
    Public ReadOnly Property Description As String
    Public ReadOnly Property TypeString As String

    Public Sub New(name As String, description As String, typeString As String)
        Me.Name = name
        Me.Description = description
        Me.TypeString = typeString
    End Sub

End Class
