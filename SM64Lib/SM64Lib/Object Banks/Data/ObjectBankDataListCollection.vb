Imports System.IO
Imports Newtonsoft.Json.Linq

Namespace ObjectBanks.Data

    Public Class ObjectBankDataListCollection
        Inherits Dictionary(Of Byte, ObjectBankDataList)

        Default Public Overloads ReadOnly Property Item(index As Integer) As ObjectBankDataList
            Get
                Return ElementAt(index).Value
            End Get
        End Property

        Public Sub Load(filePath As String)
            If File.Exists(filePath) Then
                Dim strContent As String = File.ReadAllText(filePath)
                Dim tempDic = JToken.Parse(strContent).ToObject(Of Dictionary(Of Byte, ObjectBankDataList))

                Clear()

                For Each kvp In tempDic
                    Add(kvp.Key, kvp.Value)
                Next
            End If
        End Sub

        Public Sub Save(filePath As String)
            File.WriteAllText(filePath, JObject.FromObject(Me).ToString)
        End Sub

    End Class

End Namespace
