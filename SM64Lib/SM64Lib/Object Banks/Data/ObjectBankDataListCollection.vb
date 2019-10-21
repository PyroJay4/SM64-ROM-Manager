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

        'Public Sub DoIt1()
        '    Dim dicBankIndexID As New List(Of Byte) From {&HB, &HC, &HD, &H9}

        '    Clear()

        '    For bankIndex As Integer = 0 To 3
        '        Dim iniData = General.ObjectBankData(bankIndex)
        '        Dim obdList As New ObjectBankDataList

        '        For Each section In iniData.Sections
        '            Dim obdData As New ObjectBankData With {
        '                .Name = section.SectionName
        '            }

        '            Dim keyList = section.Keys("List")
        '            If keyList IsNot Nothing Then
        '                obdData.Objects.AddRange(keyList.Split("|"c))
        '            End If

        '            For Each cmditem As String In {"cmd22", "cmd06", "cmd1A", "cmd17"}
        '                Dim keyValue = section.Keys(cmditem)
        '                If keyValue IsNot Nothing Then
        '                    For Each s As String In keyValue.Split("|")
        '                        Dim stringBytes() As String = s.Split(" "c)
        '                        Dim bytesList As New List(Of Byte)
        '                        For Each sb As String In stringBytes
        '                            If Not String.IsNullOrEmpty(sb) Then bytesList.Add("&H" & sb)
        '                        Next
        '                        obdData.Commands.Add(New ObjectBankDataCommand(bytesList.ToArray))
        '                    Next
        '                End If
        '            Next

        '            obdList.Add(obdData)
        '        Next

        '        Add(dicBankIndexID(bankIndex), obdList)
        '    Next
        'End Sub

    End Class

End Namespace
