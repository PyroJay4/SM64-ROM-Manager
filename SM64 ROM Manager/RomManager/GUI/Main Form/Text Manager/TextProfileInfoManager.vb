Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64Lib.Text.Profiles

Public Class TextProfileInfoManager

    Private ReadOnly textProfiles As New List(Of TextProfileInfo)
    Private ReadOnly filePaths As New Dictionary(Of TextProfileInfo, String)
    Private ReadOnly ids As New Dictionary(Of TextProfileInfo, String)

    Public ReadOnly Property DefaultTextProfileInfo As TextProfileInfo
        Get
            LoadAllTextProfilesIfNotLoaded()
            Return textProfiles.FirstOrDefault(Function(n) n.Name.ToLower = "default")
        End Get
    End Property

    Private Shared ReadOnly Property MyTextEditorPath As String
        Get
            Return Path.Combine(Publics.MyDataPath, "Text Manager")
        End Get
    End Property

    Private Function Clone(info As TextProfileInfo) As TextProfileInfo
        Return JObject.FromObject(info).ToObject(Of TextProfileInfo)
    End Function

    Public Sub SaveAllTextProfile()
        For Each info As TextProfileInfo In textProfiles
            SaveTextProfile(info)
        Next
    End Sub

    Public Sub SaveTextProfile(info As TextProfileInfo)
        Dim myPath As String

        If info Is DefaultTextProfileInfo Then
            If filePaths.ContainsKey(info) Then
                myPath = filePaths(info)
            Else
                myPath = Path.Combine(MyTextEditorPath, GetID(info) & ".json")
                filePaths.Add(info, myPath)
            End If

            SaveToFile(info, myPath)
        End If
    End Sub

    Private Sub SaveToFile(info As TextProfileInfo, outputFile As String)
        File.WriteAllText(Path.Combine(outputFile), JObject.FromObject(info).ToString)
    End Sub

    Private Function GetID(info As TextProfileInfo) As String
        If ids.ContainsKey(info) Then
            Return ids(info)
        Else
            Static rnd As New Random
            Dim ende As Boolean = False
            Dim id As Integer

            Do Until ende
                id = rnd.Next
                If Not ids.Values.Contains(id) Then
                    ende = True
                End If
            Loop

            ids.Add(info, id)
            Return id
        End If
    End Function

    Public Sub LoadAllTextProfilesIfNotLoaded()
        If Not textProfiles.Any Then
            LoadAllTextProfiles()
        End If
    End Sub

    Public Sub LoadAllTextProfiles()
        textProfiles.Clear()
        filePaths.Clear()
        ids.Clear()

        For Each f As String In Directory.GetFiles(MyTextEditorPath, "*.json")
            Dim info As TextProfileInfo = LoadFromFile(f)
            textProfiles.Add(info)
            filePaths.Add(info, f)
            ids.Add(info, Path.GetFileNameWithoutExtension(f))
        Next
    End Sub

    Private Function LoadFromFile(inputFile As String) As TextProfileInfo
        Return JObject.Parse(File.ReadAllText(inputFile)).ToObject(Of TextProfileInfo)
    End Function

    Public Sub RemoveTextProfile(p As TextProfileInfo)
        If filePaths.ContainsKey(p) Then
            File.Delete(filePaths(p))
            filePaths.Remove(p)
        End If
        textProfiles.RemoveIfContains(p)
        ids.RemoveIfContainsKey(p)
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

    Public Sub Export(info As TextProfileInfo, outputFile As String)
        SaveToFile(info, outputFile)
    End Sub

    Public Function Import(inputFile As String) As TextProfileInfo
        Dim p As TextProfileInfo = LoadFromFile(inputFile)
        textProfiles.Add(p)
        Return p
    End Function

End Class
