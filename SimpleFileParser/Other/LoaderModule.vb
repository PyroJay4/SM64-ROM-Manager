Imports System.Reflection
Imports Assimp.Unmanaged

Public Class File3DLoaderModule

    Public Delegate Function LoaderAction(fileName As String, options As LoaderOptions) As Object3D
    Public Delegate Sub ExporterAction(obj As Object3D, fileName As String)

    Private Shared _LoaderModules As File3DLoaderModule() = Nothing
    Private Shared _ExporterModules As File3DLoaderModule() = Nothing

    Private ReadOnly method As [Delegate] = Nothing
    Public ReadOnly Property Name As String
    Public ReadOnly Property SupportedFormats As IReadOnlyDictionary(Of String, String)

    Public Sub New(name As String, method As LoaderAction, supportedFormats As IReadOnlyDictionary(Of String, String))
        Me.Name = name
        Me.method = method
        Me.SupportedFormats = supportedFormats
    End Sub

    Public Sub New(name As String, method As ExporterAction, supportedFormats As IReadOnlyDictionary(Of String, String))
        Me.Name = name
        Me.method = method
        Me.SupportedFormats = supportedFormats
    End Sub

    Public Function InvokeAsync(obj As Object3D, fileName As String) As Task
        Return Task.Run(Sub() Invoke(obj, fileName))
    End Function

    Public Sub Invoke(obj As Object3D, fileName As String)
        method.Method.Invoke(Nothing, {obj, fileName})
    End Sub

    Public Function InvokeAsync(fileName As String, options As LoaderOptions) As Task(Of Object3D)
        Return Task.Run(Function() Invoke(fileName, options))
    End Function

    Public Function Invoke(fileName As String, options As LoaderOptions) As Object3D
        Return method.Method.Invoke(Nothing, {fileName, options})
    End Function

    Public Shared ReadOnly Property LoaderModules As File3DLoaderModule()
        Get
            If _LoaderModules Is Nothing Then
                _LoaderModules = GetLoaderModules()
            End If
            Return _LoaderModules
        End Get
    End Property

    Public Shared ReadOnly Property ExporterModules As File3DLoaderModule()
        Get
            If _ExporterModules Is Nothing Then
                _ExporterModules = GetExporterModules()
            End If
            Return _ExporterModules
        End Get
    End Property

    Private Shared Function GetLoaderModules() As File3DLoaderModule()
        Dim list As New List(Of File3DLoaderModule)

        list.Add(New File3DLoaderModule("Simple File Parser",
                                  AddressOf LoadViaSimpleFileParser,
                                  New Dictionary(Of String, String) From {{"obj", "OBJ"}}))

        Publics.LoadAssimpLibs()
        Dim exts As New Dictionary(Of String, String)
        For Each fd As Assimp.ExportFormatDescription In AssimpLibrary.Instance.GetExportFormatDescriptions
            If Not exts.ContainsKey(fd.FileExtension) Then exts.Add(fd.FileExtension, fd.FormatId & " - " & fd.Description)
        Next

        list.Add(New File3DLoaderModule("Assimp",
                                  AddressOf LoadViaAssimp,
                                  exts))

        list.Add(New File3DLoaderModule("Aspose.3D",
                                   AddressOf LoadViaAspose3D,
                                   New Dictionary(Of String, String) From {
                                   {"obj", "OBJ"},
                                   {"dae", "DAE"},
                                   {"fbx", "FBX"},
                                   {"stl", "STL"},
                                   {"3ds", "3DS"},
                                   {"3d", "3D"},
                                   {"gltf", "glTF"},
                                   {"drc", "DRC"},
                                   {"rvm", "RVM"},
                                   {"pdf", "PDF"},
                                   {"x", "X"},
                                   {"jt", "JT"},
                                   {"dfx", "DFX"},
                                   {"ply", "PLY"},
                                   {"3mf", "3MF"},
                                   {"ase", "ASE"}}))

        Return list.ToArray
    End Function

    Private Shared Function GetExporterModules() As File3DLoaderModule()
        Dim list As New List(Of File3DLoaderModule)

        list.Add(New File3DLoaderModule("Simple File Parser",
                                 AddressOf ExportViaSimpleFileParser,
                                  New Dictionary(Of String, String) From {{"obj", "OBJ"}}))

        Publics.LoadAssimpLibs()
        Dim exts As New Dictionary(Of String, String)
        For Each fd As Assimp.ExportFormatDescription In AssimpLibrary.Instance.GetExportFormatDescriptions
            If Not exts.ContainsKey(fd.FileExtension) Then exts.Add(fd.FileExtension, fd.FormatId & " - " & fd.Description)
        Next

        list.Add(New File3DLoaderModule("Assimp",
                                  AddressOf ExportViaAssimp,
                                  exts))

        Return list.ToArray
    End Function

    Private Shared Function LoadViaSimpleFileParser(fileName As String, options As LoaderOptions) As Object3D
        Return Obj.ObjFile.FromFile(fileName, options.LoadMaterials, options.UpAxis)
    End Function

    Private Shared Function LoadViaAssimp(fileName As String, options As LoaderOptions) As Object3D
        Publics.LoadAssimpLibs()
        Return AssimpLoader.AssimpLoader.FromFile(fileName, options.LoadMaterials, options.UpAxis)
    End Function

    Private Shared Function LoadViaAspose3D(fileName As String, options As LoaderOptions) As Object3D
        Return Aspose3DLoader.FromFile(fileName, options.LoadMaterials, options.UpAxis)
    End Function

    Private Shared Sub ExportViaSimpleFileParser(o As Object3D, fileName As String)
        Obj.ObjFile.ToFile(fileName, o)
    End Sub

    Private Shared Sub ExportViaAssimp(o As Object3D, fileName As String)
        Publics.LoadAssimpLibs()
        AssimpLoader.AssimpLoader.ToFile(fileName, o)
    End Sub

End Class
