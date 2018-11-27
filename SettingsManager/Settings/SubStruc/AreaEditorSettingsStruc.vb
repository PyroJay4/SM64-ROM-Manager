Imports SettingsMgr

Public Class AreaEditorSettingsStruc

    Public Property DefaultCameraMode As OpenGLFactory.CameraN.CameraMode
    Public Property DefaultWindowMode As Windows.Forms.FormWindowState
    Public Property RibbonControlExpanded As Boolean

    Public Sub ResetValues()
        DefaultCameraMode = OpenGLFactory.CameraN.CameraMode.ORBIT
        DefaultWindowMode = Windows.Forms.FormWindowState.Normal
        RibbonControlExpanded = True
    End Sub

End Class
