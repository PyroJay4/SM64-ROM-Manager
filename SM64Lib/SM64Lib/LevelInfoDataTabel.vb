Imports System.IO
Imports Newtonsoft.Json.Linq

Namespace Global.SM64Lib

    Public Class LevelInfoDataTabelList
        Inherits List(Of Level)

        Public Sub ReadFromFile(FileName As String)
            Dim jobj As JObject = JObject.Parse(File.ReadAllText(FileName))

            If jobj("Levels") IsNot Nothing Then
                For Each entry As JObject In CType(jobj("Levels"), JArray)
                    Me.Add(New Level With {
                           .Name = entry?("Name").ToString,
                           .Number = entry?("Number").ToString,
                           .TypeString = entry?("Type").ToString,
                           .ID = ValueFromText(entry?("ID").ToString),
                           .Pointer = ValueFromText(entry?("Pointer").ToString),
                           .Index = entry?("Index").ToString
                           })
                Next
            End If
        End Sub

        Public Function GetByLevelID(ID As UShort) As Level
            Return Me.FirstOrDefault(Function(n) n.ID = ID)
        End Function

        Public Class Level
            Public Property ID As UInt16 = 0
            Public Property Pointer As UInteger = 0
            Public Property Name As String = ""
            Public Property Number As String = ""
            Public Property Type As LevelTypes = LevelTypes.Level
            Public Property Index As Integer = -1

            Public Property TypeString As String
                Get
                    Select Case Type
                        Case LevelTypes.Level : Return "Level"
                        Case LevelTypes.Sidelevel : Return "Side"
                        Case LevelTypes.Overworld : Return "OW"
                        Case LevelTypes.Bowsercourse : Return "BC"
                        Case LevelTypes.Bowserbattle : Return "BB"
                        Case LevelTypes.Switchpalace : Return "Switch"
                        Case Else : Return ""
                    End Select
                End Get
                Set(value As String)
                    Select Case value
                        Case "Level" : Type = LevelTypes.Level
                        Case "Side" : Type = LevelTypes.Sidelevel
                        Case "OW" : Type = LevelTypes.Overworld
                        Case "BC" : Type = LevelTypes.Bowsercourse
                        Case "BB" : Type = LevelTypes.Bowserbattle
                        Case "Switch" : Type = LevelTypes.Switchpalace
                    End Select
                End Set
            End Property
        End Class

        Public Enum LevelTypes
            Level
            Sidelevel
            Overworld
            Switchpalace
            Bowsercourse
            Bowserbattle
        End Enum
    End Class

End Namespace
