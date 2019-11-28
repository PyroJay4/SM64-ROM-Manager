Imports System.IO
Imports System.Reflection
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Friend Module SerializedAssemblyLoader

    Public Function LoadAsmXml(asm As Assembly) As IEnumerable(Of SerializedAssemblyMember)
        Dim xmlpath As String = Path.ChangeExtension(asm.Location, ".xml")
        Dim members As New List(Of SerializedAssemblyMember)

        If File.Exists(xmlpath) Then
            Dim doc = XDocument.Load(xmlpath)
            Dim objMembers As JArray = JObject.Parse(JsonConvert.SerializeXNode(doc))("doc")("members")("member")

            For Each objMember As JObject In objMembers
                If True OrElse objMember("@name") = "member" Then
                    Dim objMemberName As String = objMember("@name")
                    Dim params As New List(Of SerializedAssemblyMemberParam)
                    Dim summery As String = objMember("summary")
                    Dim returns As String = objMember("returns")
                    Dim mTypeChar As Char = objMemberName(0)
                    Dim mType As SerializedAssemblyMemberType = -1
                    Dim name As String = objMemberName.Substring(2)
                    Dim path As String = ""
                    Dim paramTypes As New List(Of String)

                    Select Case mTypeChar
                        Case "M"c
                            mType = SerializedAssemblyMemberType.Methode
                        Case "T"c
                            mType = SerializedAssemblyMemberType.Type
                        Case "F"c
                            mType = SerializedAssemblyMemberType.Field
                        Case "P"c
                            mType = SerializedAssemblyMemberType.Property
                    End Select

                    Dim iok As Integer = name.IndexOf("("c)
                    If iok > -1 Then
                        name = name.Remove(iok)
                    End If

                    Dim liop = name.LastIndexOf("."c)
                    If liop > -1 Then
                        path = name.Remove(liop)
                        name = name.Substring(liop + 1)
                    End If

                    If objMember.ContainsKey("param") Then
                        'MsgBox(objMember.ToString)
                        Dim objParams As JToken = objMember("param")
                        Dim objParamsList As Object = {}

                        If TypeOf objParams Is JArray Then
                            objParamsList = objParams
                        ElseIf TypeOf objParams Is JProperty Then
                            objParamsList = {objParams}
                        End If

                        For Each objParam As JObject In objParamsList
                            Dim paramType As String = ""
                            params.Add(New SerializedAssemblyMemberParam(objParam("@name"), objParam("#text"), paramType))
                        Next
                    End If

                    members.Add(New SerializedAssemblyMember(name, path, summery, mType, params.ToArray))
                End If
            Next
        End If

        Return members.ToArray
    End Function

End Module
