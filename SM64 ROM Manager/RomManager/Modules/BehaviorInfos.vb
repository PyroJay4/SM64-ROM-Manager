Imports TextValueConverter
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class BehaviorInfoList
    Inherits List(Of BehaviorInfo)

    Public Sub ReadFromFile(fileName As String)
        Clear()

        Dim jarr As JArray = JArray.Parse(File.ReadAllText(fileName))

        If jarr IsNot Nothing Then
            For Each entry As JObject In jarr
                Dim info As New BehaviorInfo

                info.Name = entry("Name").Value(Of String)
                info.BehaviorAddress = ValueFromText(entry("Behavior").Value(Of String))

                For i As Integer = 1 To 4
                    If entry.ContainsKey($"BP{i} Name") Then
                        info.GetValue(Of BParam)($"BParam{i}").Name = entry($"BP{i} Name").Value(Of String)
                    End If
                    If entry.ContainsKey($"BP{i} Entries") Then
                        Dim param As BParam = info.GetValue($"BParam{i}")
                        For Each kvp As JObject In entry($"BP{i} Entries")
                            param.Values.Add(kvp("Name").Value(Of String),
                                                    ValueFromText(kvp("Value").Value(Of String)))
                        Next
                    End If
                Next

                Add(info)
            Next
        End If
    End Sub

    Public Function GetByBehaviorAddress(addr As Integer) As BehaviorInfo
        Return FirstOrDefault(Function(n) n.BehaviorAddress = addr)
    End Function

    Public Class BehaviorInfo
        Public Property Name As String = ""
        Public Property BehaviorAddress As Integer = 0
        Public Property BParam1 As New BParam
        Public Property BParam2 As New BParam
        Public Property BParam3 As New BParam
        Public Property BParam4 As New BParam
    End Class

    Public Class BParam
        Public Property Name As String = ""
        Public Property Values As New Dictionary(Of String, Byte)
    End Class

End Class
