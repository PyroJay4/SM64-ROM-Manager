Public Module PluginManager

    Private dnbLicenceKey As String = ""

    Public Property DotNetBarLicenceKey As String
        Get
            Return dnbLicenceKey
        End Get
        Friend Set(value As String)
            dnbLicenceKey = value
        End Set
    End Property

End Module
