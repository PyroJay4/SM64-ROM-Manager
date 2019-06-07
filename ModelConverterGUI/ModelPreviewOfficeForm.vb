Imports System.Drawing
Imports System.Windows.Forms
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.CameraN
Imports Pilz.S3DFileParser
Imports SM64_ROM_Manager.SettingsManager

Public Class ModelPreviewOfficeForm

    Private WithEvents ModelPreview As New Pilz.Drawing.Drawing3D.OpenGLFactory.PreviewN.ModelPreview With {
        .FormBorderStyle = FormBorderStyle.None,
        .Dock = DockStyle.Fill,
        .TopLevel = False,
        .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top,
        .Scaling = 500
    }

    Public Sub New(obj As Object3D, scaling As Single)
        InitializeComponent()

        ModelPreview.ClearColor = If(Settings.StyleManager.AlwaysKeepBlueColors, Color.CornflowerBlue, Me.BackColor)
        ModelPreview.Scaling = scaling
        ModelPreview.AddModel(obj)
        ModelPreview.Size = ModelPreview.ClientSize
        ModelPreview.Show()

        AddHandler Shown, AddressOf ModelPreview.HandlesOnShown
        AddHandler Activated, AddressOf ModelPreview.HandlesOnActivated
        AddHandler Deactivate, AddressOf ModelPreview.HandlesOnDeactivate
        AddHandler KeyUp, AddressOf ModelPreview.HandlesOnKeyUp
        AddHandler KeyDown, AddressOf ModelPreview.HandlesOnKeyDown

        ModelPreview.Camera.SetCameraMode(CameraMode.ORBIT, ModelPreview.CameraMatrix)
        AddHandler ModelPreview.Camera.NeedSelectedObject, AddressOf Camera_NeedSelectedObject

        Controls.Add(ModelPreview)
    End Sub

    Private Sub Camera_NeedSelectedObject(e As Camera.NeedSelectedObjectEventArgs)
        e.Points = Nothing
    End Sub

End Class