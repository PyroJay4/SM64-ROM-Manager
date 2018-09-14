Imports SettingsMgr

Public Class AreaEditorSettingsStruc

    Public Property DefaultCameraMode As OpenGLCamera.CameraMode
    Public Property DefaultWindowMode As Windows.Forms.FormWindowState
    Public Property RibbonControlExpanded As Boolean

    Public Sub ResetValues()
        DefaultCameraMode = OpenGLCamera.CameraMode.ORBIT
        DefaultWindowMode = Windows.Forms.FormWindowState.Normal
        RibbonControlExpanded = True
    End Sub

End Class
