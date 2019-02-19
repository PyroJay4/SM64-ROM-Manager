Imports TextValueConverter
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports SM64_ROM_Manager.LevelEditor.BehaviorInfo

Namespace LevelEditor

    Public Class BehaviorInfoList
        Inherits List(Of BehaviorInfo)

        Public Sub ReadFromFile(fileName As String)
            Clear()

            Dim jarr As JArray = JArray.Parse(File.ReadAllText(fileName))

            If jarr IsNot Nothing Then
                For Each entry As JObject In jarr
                    Dim info As New BehaviorInfo

                    info.Name = entry("Name").Value(Of String)
                    info.BehaviorAddress = ValueFromText(entry("Behavior").Value(Of String),, 0)

                    For i As Integer = 1 To 4
                        If entry.ContainsKey($"BP{i} Name") Then
                            info.GetValue(Of BParam)($"BParam{i}").Name = entry($"BP{i} Name").Value(Of String)
                        End If

                        If entry.ContainsKey($"BP{i} Entries") Then
                            Dim param As BParam = info.GetValue($"BParam{i}")
                            For Each kvp As JObject In entry($"BP{i} Entries")
                                param.Values.Add(New BParamValue With {.Name = kvp("Name").Value(Of String),
                                                        .Value = ValueFromText(kvp("Value").Value(Of String))})
                            Next
                        End If
                    Next

                    Add(info)
                Next
            End If
        End Sub

        Public Sub WriteToFile(fileName As String)
            Dim jarr As New JArray

            For Each info As BehaviorInfo In Me
                Dim entry As New JObject

                entry("Name") = info.Name
                entry("Behavior") = info.BehaviorAddress

                For i As Integer = 1 To 4
                    Dim param As BParam = info.GetValue(Of BParam)($"BParam{i}")

                    If param IsNot Nothing Then
                        entry($"BP{i} Name") = param.Name

                        If param.Values.Any Then
                            Dim parr As New JArray

                            For Each value As BParamValue In param.Values
                                Dim vobj As New JObject
                                vobj("Value") = TextFromValue(value.Value)
                                vobj("Name") = value.Name
                                parr.Add(vobj)
                            Next

                            entry($"BP{i} Entries") = parr
                        End If
                    End If
                Next

                jarr.Add(entry)
            Next

            File.WriteAllText(fileName, jarr.ToString)
        End Sub

        Public Function GetByBehaviorAddress(addr As UInteger) As BehaviorInfo
            Return FirstOrDefault(Function(n) n.BehaviorAddress = addr)
        End Function

    End Class

End Namespace
