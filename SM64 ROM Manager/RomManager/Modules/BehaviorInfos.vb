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
                            param.Values.Add(New BParamValue With {.Name = kvp("Name").Value(Of String),
                                                    .Value = ValueFromText(kvp("Value").Value(Of String))})
                        Next
                    End If
                Next

                Add(info)
            Next
        End If
    End Sub

    Public Function GetByBehaviorAddress(addr As UInteger) As BehaviorInfo
        Return FirstOrDefault(Function(n) n.BehaviorAddress = addr)
    End Function

    Public Class BehaviorInfo
        Public Property Name As String = ""
        Public Property BehaviorAddress As UInteger = 0
        Public Property BParam1 As New BParam
        Public Property BParam2 As New BParam
        Public Property BParam3 As New BParam
        Public Property BParam4 As New BParam

        Public ReadOnly Property BehaviorAddressText As String
            Get
                Return TextFromValue(BehaviorAddress, Math.Max(1, SettingsManager.Settings.General.IntegerValueMode))
            End Get
        End Property
    End Class

    Public Class BParam
        Public Property Name As String = ""
        Public Property Values As New List(Of BParamValue)
    End Class

    Public Class BParamValue
        Public Property Name As String = ""
        Public Property Value As Byte = 0
        Public ReadOnly Property ValueText As String
            Get
                Return TextFromValue(Value)
            End Get
        End Property
    End Class

End Class
