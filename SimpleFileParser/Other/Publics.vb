Imports System.IO
Imports Assimp.Unmanaged

Public Class Publics

    Friend Shared Sub LoadAssimpLibs()
        If Not AssimpLibrary.Instance.IsLibraryLoaded Then
            Dim appPath = Environment.CurrentDirectory
            Dim p32 = Path.Combine(appPath, "Data\Lib\Assimp32.dll")
            Dim p64 = Path.Combine(appPath, "Data\Lib\Assimp64.dll")
            AssimpLibrary.Instance.LoadLibrary(p32, p64)
        End If
    End Sub

    Public Shared Function GetAllowedFileExtensions(modul As LoaderModule) As String()
        Select Case modul
            Case LoaderModule.SimpleFileParser

                Return {".obj"}

            Case LoaderModule.Assimp

                LoadAssimpLibs()
                Return AssimpLibrary.Instance.GetExtensionList

            Case LoaderModule.Aspose

                Return {
                ".obj",
                ".dae",
                ".fbx",
                ".stl",
                ".3ds",
                ".3d",
                ".gltf",
                ".drc",
                ".rvm",
                ".pdf",
                ".x",
                ".jt",
                ".dfx",
                ".ply",
                ".3mf",
                ".ase"
                }

            Case Else

                Return {"*"}

        End Select
    End Function

    Public Shared Function GetAllFileFormatDescriptions(modul As LoaderModule) As Dictionary(Of String, String)
        Dim exts As New Dictionary(Of String, String)

        Select Case modul
            Case LoaderModule.SimpleFileParser

                exts.Add("obj", "Wavefront")

            Case LoaderModule.Assimp

                LoadAssimpLibs()
                For Each fd As Assimp.ExportFormatDescription In AssimpLibrary.Instance.GetExportFormatDescriptions
                    If Not exts.ContainsKey(fd.FileExtension) Then exts.Add(fd.FileExtension, fd.Description)
                Next

            Case LoaderModule.Aspose

                exts.Add("obj", "Wavefront")
                exts.Add("dae", "Collada")
                exts.Add("fbx", "Autodesk")
                exts.Add("stl", "3D Systems CAD")
                exts.Add("3ds", "Discreet 3D Studio")
                exts.Add("3d", "Universal3D")
                exts.Add("gltf", "GL Transmission")
                exts.Add("drc", "Google Draco")
                exts.Add("rvm", "Portable Document Format")
                exts.Add("pdf", "PDF")
                exts.Add("x", "DirectX")
                exts.Add("jt", "Siemens")
                exts.Add("dfx", "DFX")
                exts.Add("ply", "PLY")
                exts.Add("3mf", "3D Manufacturing Format")
                exts.Add("ase", "ASE")

        End Select

        Return exts
    End Function

    Public Shared Function GetAllFileFormatIDs(modul As LoaderModule) As Dictionary(Of String, String)
        Dim exts As New Dictionary(Of String, String)

        Select Case modul
            Case LoaderModule.SimpleFileParser

                exts.Add("obj", "OBJ")

            Case LoaderModule.Assimp

                LoadAssimpLibs()
                For Each fd As Assimp.ExportFormatDescription In AssimpLibrary.Instance.GetExportFormatDescriptions
                    If Not exts.ContainsKey(fd.FileExtension) Then exts.Add(fd.FileExtension, fd.FormatId)
                Next

            Case LoaderModule.Aspose

                exts.Add("obj", "OBJ")
                exts.Add("dae", "DAE")
                exts.Add("fbx", "FBX")
                exts.Add("stl", "STL")
                exts.Add("3ds", "3DS")
                exts.Add("3d", "3D")
                exts.Add("gltf", "glTF")
                exts.Add("drc", "DRC")
                exts.Add("rvm", "RVM")
                exts.Add("pdf", "PDF")
                exts.Add("x", "X")
                exts.Add("jt", "JT")
                exts.Add("dfx", "DFX")
                exts.Add("ply", "PLY")
                exts.Add("3mf", "3MF")
                exts.Add("ase", "ASE")

        End Select

        Return exts
    End Function

End Class
