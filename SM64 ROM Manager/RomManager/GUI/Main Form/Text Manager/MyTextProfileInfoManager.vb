Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64Lib.Text.Profiles

Public Class MyTextProfileInfoManager

    Public ReadOnly Property Manager As New SM64Lib.Text.TextProfileInfoManager
    Private ReadOnly filePaths As New Dictionary(Of TextProfileInfo, String)
    Private ReadOnly ids As New Dictionary(Of TextProfileInfo, String)

    Public Sub New()
        LoadAllTextProfilesIfNotLoaded()
    End Sub

    Private Shared ReadOnly Property MyTextEditorPath As String
        Get
            Return Path.Combine(Publics.MyDataPath, "Text Manager")
        End Get
    End Property

    Public Sub SaveAllTextProfile()
        For Each info As TextProfileInfo In Manager.GetTextProfiles
            SaveTextProfile(info)
        Next
    End Sub

    Public Sub SaveTextProfile(info As TextProfileInfo)
        Dim myPath As String

        If info IsNot Manager.DefaultTextProfileInfo Then
            If filePaths.ContainsKey(info) Then
                myPath = filePaths(info)
            Else
                myPath = Path.Combine(MyTextEditorPath, GetID(info) & ".json")
                filePaths.Add(info, myPath)
            End If

            Manager.SaveToFile(info, myPath)
        End If
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
        If Not Manager.GetTextProfiles.Any Then
            LoadAllTextProfiles()
        End If
    End Sub

    Public Sub LoadAllTextProfiles()
        Manager.ClearProfleList()
        filePaths.Clear()
        ids.Clear()

        For Each f As String In Directory.GetFiles(MyTextEditorPath, "*.json")
            Dim info As TextProfileInfo = Manager.LoadFromFile(f)
            filePaths.Add(info, f)
            ids.Add(info, Path.GetFileNameWithoutExtension(f))
        Next
    End Sub

    Public Sub RemoveTextProfile(p As TextProfileInfo)
        If filePaths.ContainsKey(p) Then
            File.Delete(filePaths(p))
            filePaths.Remove(p)
        End If
        Manager.RemoveTextProfile(p)
        ids.RemoveIfContainsKey(p)
    End Sub

    Public Sub Export(info As TextProfileInfo, outputFile As String)
        Manager.SaveToFile(info, outputFile)
    End Sub

    Public Function Import(inputFile As String) As TextProfileInfo
        Return Manager.LoadFromFile(inputFile)
    End Function

End Class
