Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64_ROM_Manager.LevelEditor.ObjectCombo
Imports TextValueConverter

Namespace LevelEditor

    Public Class ObjectComboList
        Inherits List(Of ObjectCombo)

        Public Shared ReadOnly Property UnknownCombo As New ObjectCombo With {.Name = "Unknown Combo"}

        Public Sub ReadFromFile(fileName As String)
            Me.Clear()

            Dim jobj As JObject = JObject.Parse(File.ReadAllText(fileName))

            If jobj?("ObjectCombos") IsNot Nothing Then
                For Each entry As JObject In CType(jobj("ObjectCombos"), JArray)
                    Me.Add(New ObjectCombo With {
                           .Name = entry?("Name"),
                           .ModelID = entry?("ModelID"),
                           .ModelAddress = entry?("ModelAddress"),
                           .BehaviorAddress = entry?("Behavior"),
                           .BParam1 = New BParam With {.Name = entry?("BP1_NAME"), .Description = entry?("BP1_DESCRIPTION")},
                           .BParam2 = New BParam With {.Name = entry?("BP2_NAME"), .Description = entry?("BP2_DESCRIPTION")},
                           .BParam3 = New BParam With {.Name = entry?("BP3_NAME"), .Description = entry?("BP3_DESCRIPTION")},
                           .BParam4 = New BParam With {.Name = entry?("BP4_NAME"), .Description = entry?("BP4_DESCRIPTION")}
                           })
                Next
            End If
        End Sub

        Public Sub WriteToFile(fileName As String)
            Dim jobj As New JObject
            Dim jarr As New JArray

            jobj.Add("ObjectCombos", jarr)

            For Each cb As ObjectCombo In Me
                Dim entry As New JObject

                entry("Name") = cb.Name
                entry("ModelID") = cb.ModelID
                entry("ModelAddress") = cb.ModelAddress
                entry("Behavior") = cb.BehaviorAddress

                If cb.BParam1 IsNot Nothing Then
                    entry("BP1_NAME") = cb.BParam1.Name
                    entry("BP1_DESCRIPTION") = cb.BParam1.Description
                End If

                If cb.BParam2 IsNot Nothing Then
                    entry("BP2_NAME") = cb.BParam2.Name
                    entry("BP2_DESCRIPTION") = cb.BParam2.Description
                End If

                If cb.BParam3 IsNot Nothing Then
                    entry("BP3_NAME") = cb.BParam3.Name
                    entry("BP3_DESCRIPTION") = cb.BParam3.Description
                End If

                If cb.BParam4 IsNot Nothing Then
                    entry("BP4_NAME") = cb.BParam4.Name
                    entry("BP4_DESCRIPTION") = cb.BParam4.Description
                End If

                jarr.Add(entry)
            Next

            File.WriteAllText(fileName, jobj.ToString)
        End Sub

        Public Function GetObjectComboOfObject(obj As Managed3DObject) As ObjectCombo
            Return GetObjectComboOfObject(obj.ModelID, obj.BehaviorID)
        End Function
        Public Function GetObjectComboOfObject(modelID As Byte, behavID As UInteger) As ObjectCombo
            For Each objcombo In Me
                If objcombo.ModelID = modelID AndAlso objcombo.BehaviorAddress = behavID Then Return objcombo
            Next
            Return unknownCombo
        End Function

    End Class

End Namespace
