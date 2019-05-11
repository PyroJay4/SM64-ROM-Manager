Namespace Global.SM64Lib.Text.Profiles

    Public Class TextSectionInfo

        Public Property Segmented As TextSegmentedInfo
        Public Property Data As TextDataInfo
        Public Property Name As String

        Public ReadOnly Property TableType As TextTableType
            Get
                Return If(Data?.TableRomOffset2 = 0, TextTableType.Default, TextTableType.Dialogs)
            End Get
        End Property

    End Class

End Namespace