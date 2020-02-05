Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class TweakDatabasePreferences

    Public Property CategoryPaths As Dictionary(Of TweakDatabaseCategories, String)
    Public Property Logins As Dictionary(Of TweakDatabaseLoginTypes, TweakDatabaseLoginPreferences)

    Public Shared Function Load(filePath As String) As TweakDatabasePreferences
        Return JObject.Parse(File.ReadAllText(filePath)).ToObject(Of TweakDatabasePreferences)
    End Function

End Class
