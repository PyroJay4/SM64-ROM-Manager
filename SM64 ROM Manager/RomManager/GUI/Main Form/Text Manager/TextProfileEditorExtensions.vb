Imports System.Runtime.CompilerServices
Imports SM64Lib.Text.Profiles

Friend Module TextProfileEditorExtensions

    <Extension>
    Public Function IsTextTableGroupInfo(tg As TextGroupInfo) As Boolean
        Return TypeOf tg Is TextTableGroupInfo
    End Function

    <Extension>
    Public Function IsTextArrayGroupInfo(tg As TextGroupInfo) As Boolean
        Return TypeOf tg Is TextArrayGroupInfo
    End Function

End Module
