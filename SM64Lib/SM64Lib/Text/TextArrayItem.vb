Imports SM64Lib.Text.Profiles

Namespace Text

    Public Class TextArrayItem
        Inherits TextItem

        Public ReadOnly Property ItemInfo As TextArrayItemInfo

        Public Overloads ReadOnly Property TextGroupInfo As TextArrayGroupInfo
            Get
                Return MyBase.TextGroupInfo
            End Get
        End Property

        Public Sub New(bytes As Byte(), groupInfo As TextArrayGroupInfo, info As TextArrayItemInfo)
            MyBase.New(bytes, groupInfo)
            ItemInfo = info

            'Remove empty chars at the end of ascii text
            If groupInfo.Encoding Is System.Text.Encoding.ASCII Then
                Text = Text.TrimEnd
            End If
        End Sub

    End Class

End Namespace
