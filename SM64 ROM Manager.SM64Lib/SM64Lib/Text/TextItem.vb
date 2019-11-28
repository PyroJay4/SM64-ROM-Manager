Imports SM64Lib.Text.Profiles

Namespace Text

    Public MustInherit Class TextItem

        Public ReadOnly Property Data As Byte()
        Public ReadOnly Property TextGroupInfo As TextGroupInfo

        Public Property Text As String
            Get
                Return TextGroupInfo.Encoding.GetString(_Data)
            End Get
            Set(value As String)
                _Data = TextGroupInfo.Encoding.GetBytes(value)
            End Set
        End Property

        Public Sub New(bytes As Byte(), groupInfo As TextGroupInfo)
            TextGroupInfo = groupInfo
            _Data = bytes
        End Sub

    End Class

End Namespace
