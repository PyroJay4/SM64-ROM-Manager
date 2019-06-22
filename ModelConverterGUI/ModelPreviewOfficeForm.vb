Imports System.Drawing
Imports System.Windows.Forms
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.CameraN
Imports Pilz.S3DFileParser
Imports SM64_ROM_Manager.SettingsManager

Public Class ModelPreviewOfficeForm

    Private modelToRender As Object3D

    Private WithEvents ModelPreview As New Pilz.Drawing.Drawing3D.OpenGLFactory.PreviewN.ModelPreview With {
        .FormBorderStyle = FormBorderStyle.None,
        .Dock = DockStyle.Fill,
        .TopLevel = False,
        .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top,
        .Scaling = 500,
        .RenderWhenWindowsIsInactive = True
    }

    Public Sub New(obj As Object3D, scaling As Single)
        InitializeComponent()

        modelToRender = obj

        ModelPreview.Scaling = scaling
        ModelPreview.Size = ModelPreview.ClientSize
        ModelPreview.Show()

        AddHandler Shown, AddressOf ModelPreview.HandlesOnShown
        AddHandler Activated, AddressOf ModelPreview.HandlesOnActivated
        AddHandler Deactivate, AddressOf ModelPreview.HandlesOnDeactivate
        'AddHandler KeyUp, AddressOf ModelPreview.HandlesOnKeyUp
        'AddHandler KeyDown, AddressOf ModelPreview.HandlesOnKeyDown

        ModelPreview.Camera.SetCameraMode(CameraMode.FLY, ModelPreview.CameraMatrix)
        AddHandler ModelPreview.Camera.NeedSelectedObject, AddressOf Camera_NeedSelectedObject

        Controls.Add(ModelPreview)
    End Sub

    Private Function OpenModel() As String
        Dim ofd As New OpenFileDialog With {
            .Filter = "OBJ File|*.obj"
        }
        ofd.ShowDialog()
        Return ofd.FileName
    End Function

    Private Sub Camera_NeedSelectedObject(e As Camera.NeedSelectedObjectEventArgs)
        e.Points = Nothing
    End Sub

    Private Sub ModelPreviewOfficeForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ModelPreview.RenderModel(ModelPreview.AddModel(modelToRender))
        ModelPreview.UpdateView()
    End Sub
End Class