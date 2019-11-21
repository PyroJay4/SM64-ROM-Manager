Public Class ToolSelectionWindow

    Private Sub ShowEditorWindow(mode As Byte)
        Select Case mode
            Case 0
                EditorWindow.InitVersionInfoEditor()
            Case 1
                EditorWindow.InitPackageEditor()
        End Select
        EditorWindow.Show()
    End Sub

    Private Sub ButtonX_OpenUpdateInfoManager_Click(sender As Object, e As EventArgs) Handles ButtonX_OpenUpdateInfoManager.Click
        ShowEditorWindow(0)
    End Sub

    Private Sub ButtonX_OpenUpdatePackageEditor_Click(sender As Object, e As EventArgs) Handles ButtonX_OpenUpdatePackageEditor.Click
        ShowEditorWindow(1)
    End Sub

End Class
