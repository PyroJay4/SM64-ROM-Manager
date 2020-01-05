Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design

Namespace Text.Profiles

    Public Class TextTableGroupInfo
        Inherits TextGroupInfo

        Public Property Segmented As New TextTableSegmentedInfo
        Public Property Data As New TextTableDataInfo
        Public Property DialogData As New TextTableDialogDataInfo
        <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))>
        Public Property ItemDescriptions As String = String.Empty

        Public ReadOnly Property TableType As TextTableType
            Get
                Return If(DialogData.TableRomOffset = 0, TextTableType.Default, TextTableType.Dialogs)
            End Get
        End Property

    End Class

End Namespace
