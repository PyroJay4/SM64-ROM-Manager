Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64_ROM_Manager.SM64Lib.Text.Profiles

Namespace Text

    Public Class TextProfileInfoManager

        Private ReadOnly textProfiles As New List(Of TextProfileInfo)

        Public ReadOnly Property DefaultTextProfileInfo As TextProfileInfo
            Get
                Return textProfiles.FirstOrDefault(Function(n) n.Name.ToLower = "default")
            End Get
        End Property

        Private Function Clone(info As TextProfileInfo) As TextProfileInfo
            Return JObject.FromObject(info).ToObject(Of TextProfileInfo)
        End Function

        Public Sub SaveToFile(info As TextProfileInfo, outputFile As String)
            File.WriteAllText(Path.Combine(outputFile), JObject.FromObject(info).ToString)
        End Sub

        Public Function LoadFromFile(inputFile As String) As TextProfileInfo
            Dim info As TextProfileInfo = JObject.Parse(File.ReadAllText(inputFile)).ToObject(Of TextProfileInfo)
            textProfiles.Add(info)
            Return info
        End Function

        Public Sub RemoveTextProfile(p As TextProfileInfo)
            textProfiles.RemoveIfContains(p)
        End Sub

        Public Function GetTextProfiles() As IEnumerable(Of TextProfileInfo)
            Return textProfiles
        End Function

        Public Function CreateTextProfile() As TextProfileInfo
            Dim definfo As TextProfileInfo = DefaultTextProfileInfo
            Dim p As TextProfileInfo = Clone(definfo)
            p.Name = definfo.Name & textProfiles.Count

            textProfiles.Add(p)

            Return p
        End Function

        Public Sub ClearProfleList()
            textProfiles.Clear()
        End Sub

    End Class

End Namespace
