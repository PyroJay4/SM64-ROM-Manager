Imports System.IO
Imports System.Reflection
Imports Newtonsoft.Json.Linq

Friend Class UpdatePackageManager

    'F i e l d s

    Private template As UpdatePackageTemplate

    'P r o p e r t i e s

    Public Property FilesToCopyPath As String
        Get
            Return template.FilesToCopyPath
        End Get
        Set(value As String)
            template.FilesToCopyPath = value
        End Set
    End Property

    'C o n s t r u c o t r s

    Public Sub New()
        NewTemplate()
    End Sub

    'F e a t u r e s

    Public Sub LoadTemplate(filePath As String)
        template = JObject.Parse(File.ReadAllText(filePath)).ToObject(Of UpdatePackageTemplate)
    End Sub

    Public Sub SaveTemplate(filePath As String)
        File.WriteAllText(filePath, JObject.FromObject(template).ToString)
    End Sub

    Public Sub NewTemplate()
        template = New UpdatePackageTemplate
    End Sub

    Public Sub ExportPackage(path As String)
        Dim exporter As New UpdatePackagePackager(template)
        exporter.Export(path)
    End Sub

    Private Function CheckUpdateInstallerAddOn(path As String)
        Dim asm As Assembly = Assembly.ReflectionOnlyLoadFrom(path)
        Dim t As Type = asm.GetType($"{UPDATE_INSTALLER_ADDON_NAMESPACE}.{UPDATE_INSTALLER_ADDON_TYPE}", False)
        Dim isSupported As Boolean = False

        If t IsNot Nothing Then
            Dim mi As MethodInfo = t.GetMethod(UPDATE_INSTALLER_ADDON_METHOD, BindingFlags.Static Or BindingFlags.Public)
            If mi IsNot Nothing Then
                Dim params As ParameterInfo() = mi.GetParameters
                If params.Length = 1 AndAlso params.GetType = GetType(Dictionary(Of String, Object)) Then
                    isSupported = True
                End If
            End If
        End If

        Return isSupported
    End Function

    Public Function AddUpdateInstallerAddOn(path As String) As Boolean
        If Not template.UpdateInstallerAddOns.Contains(path) AndAlso CheckUpdateInstallerAddOn(path) Then
            template.UpdateInstallerAddOns.Add(path)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetAllUpdateInstallerÁddOn() As IEnumerable(Of String)
        Return template.UpdateInstallerAddOns
    End Function

    Public Sub RemoveUpdateInstallerAddOn(path As String)
        template.UpdateInstallerAddOns.RemoveIfContains(path)
    End Sub

End Class
