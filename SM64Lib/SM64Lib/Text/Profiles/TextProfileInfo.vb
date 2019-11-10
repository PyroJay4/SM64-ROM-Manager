Imports Newtonsoft.Json

Namespace Global.SM64Lib.Text.Profiles

    Public Class TextProfileInfo

        Public Property Name As String
        Public Property TextTableGroups As New List(Of TextTableGroupInfo)
        Public Property TextArrayGroups As New List(Of TextArrayGroupInfo)

        Public Function GetGroup(name As String) As TextGroupInfo
            Return AllGroups.FirstOrDefault(Function(n) n.Name = name)
        End Function

        <JsonIgnore>
        Public ReadOnly Property AllGroups As IEnumerable(Of TextGroupInfo)
            Get
                Dim list As New List(Of TextGroupInfo)

                list.AddRange(TextTableGroups.ToArray)
                list.AddRange(TextArrayGroups.ToArray)

                Return list
            End Get
        End Property

    End Class

End Namespace
