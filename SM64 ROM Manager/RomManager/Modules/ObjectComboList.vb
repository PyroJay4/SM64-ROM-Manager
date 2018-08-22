Imports System.IO
Imports Newtonsoft.Json.Linq
Imports OpenGLCamera
Imports SM64Lib.Levels.Script, SM64Lib.Levels.Script.Commands
Imports TextValueConverter

Public Class ObjectComboList
    Inherits List(Of ObjectCombo)

    Public ReadOnly unknownCombo As New ObjectCombo With {.Name = "Unknown Combo"}

    Public Sub ReadFromFile(FileName As String)
        Me.Clear()

        Dim jobj As JObject = JObject.Parse(File.ReadAllText(FileName))

        If jobj("ObjectCombos") IsNot Nothing Then
            For Each entry As JObject In CType(jobj("ObjectCombos"), JArray)
                Me.Add(New ObjectCombo With {
                       .Name = entry?("Name"),
                       .ModelID = CByte(ValueFromText(entry?("ModelID"))),
                       .ModelAddress = CUInt(ValueFromText(entry?("ModelAddress"))),
                       .BehaviorID = CUInt(ValueFromText(entry?("Behavior"))),
                       .BParam1 = New BParam With {.Name = entry?("BP1_NAME"), .Description = entry?("BP1_DESCRIPTION")},
                       .BParam2 = New BParam With {.Name = entry?("BP2_NAME"), .Description = entry?("BP2_DESCRIPTION")}
                       })
            Next
        End If
    End Sub

    Public Function GetObjectComboOfObject(obj As Managed3DObject) As ObjectCombo
        Return GetObjectComboOfObject(obj.ModelID, obj.BehaviorID)
    End Function
    Public Function GetObjectComboOfObject(modelID As Byte, behavID As UInteger) As ObjectCombo
        For Each objcombo In Me
            If objcombo.ModelID = modelID AndAlso objcombo.BehaviorID = behavID Then Return objcombo
        Next
        Return unknownCombo
    End Function

    Public Class ObjectCombo
        Public Property Name As String = "Unknown Combo"
        Public Property ModelID As Byte = 0
        Public Property ModelAddress As Integer = 0
        Public Property BehaviorID As UInteger = 0
        Public Property BehaviorAddress As UInteger = 0
        Public Property BParam1 As New BParam
        Public Property BParam2 As New BParam
        Public Property BParam3 As New BParam
        Public Property BParam4 As New BParam
    End Class

    Public Class BParam
        Public Property Name As String = ""
        Public Property Description As String = ""
    End Class
End Class