Public Class ToolSelectionWindow

    Private Sub ShowEditorWindow(mode As Byte)
        Dim editor As New EditorWindow

        Select Case mode
            Case 0
                editor.InitVersionInfoEditor()
            Case 1
                editor.InitPackageEditor()
        End Select

        editor.Show()
        Close()
    End Sub

    Private Sub ButtonX_OpenUpdateInfoManager_Click(sender As Object, e As EventArgs) Handles ButtonX_OpenUpdateInfoManager.Click
        ShowEditorWindow(0)
    End Sub

    Private Sub ButtonX_OpenUpdatePackageEditor_Click(sender As Object, e As EventArgs) Handles ButtonX_OpenUpdatePackageEditor.Click
        ShowEditorWindow(1)
    End Sub

End Class
