Imports System.Configuration
Imports System.Windows.Forms
Imports OpenGLCamera

Public Class Configs

    Public Shared Sub InitSettings()
        AreaEditor.Default.DefaultCameraMode = CameraMode.ORBIT
        AreaEditor.Default.DefaultWindowMode = FormWindowState.Normal
    End Sub

    Public Shared Sub SaveSettings()
        AreaEditor.Default.Save()
    End Sub

End Class

Public Class PublicSettings

    Public Shared ReadOnly Property General
        Get
            Return My.Settings
        End Get
    End Property

    Public Shared ReadOnly Property AreaEditor As AreaEditor
        Get
            Return AreaEditor.Default
        End Get
    End Property


End Class
