Imports SM64Lib.Text.Profiles

Namespace Global.SM64Lib.Text

    Public Class TextTableItem
        Inherits TextItem

        Public Overloads ReadOnly Property TextGroupInfo As TextTableGroupInfo
            Get
                Return MyBase.TextGroupInfo
            End Get
        End Property

        Public Sub New(bytes As Byte(), info As TextTableGroupInfo)
            MyBase.New(bytes, info)
        End Sub

    End Class

End Namespace
