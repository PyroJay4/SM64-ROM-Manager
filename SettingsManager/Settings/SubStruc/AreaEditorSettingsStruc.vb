Imports Pilz.Drawing.Drawing3D.OpenGLFactory.CameraN
Imports SettingsMgr

Public Class AreaEditorSettingsStruc

    Public Property DefaultCameraMode As CameraMode
    Public Property DefaultWindowMode As Windows.Forms.FormWindowState
    Public Property RibbonControlExpanded As Boolean

    Public Sub ResetValues()
        DefaultCameraMode = CameraMode.ORBIT
        DefaultWindowMode = Windows.Forms.FormWindowState.Normal
        RibbonControlExpanded = True
    End Sub

End Class
