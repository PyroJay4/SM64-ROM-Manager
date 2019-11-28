Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.Text.Profiles

Namespace Text

    Public MustInherit Class TextGroup
        Inherits List(Of TextItem)

        Public Property NeedToSave As Boolean = False
        Public ReadOnly Property TextGroupInfo As TextGroupInfo

        Public ReadOnly Property DataLength As Integer
            Get
                Dim count As Integer = 0

                For Each item As TextItem In Me
                    count += item.Data.Length
                Next

                Return count
            End Get
        End Property

        Public Sub New(groupInfo As TextGroupInfo)
            TextGroupInfo = groupInfo
        End Sub

        Public MustOverride Sub Read(data As BinaryData)
        Public MustOverride Sub Save(data As BinaryData)

    End Class

End Namespace
