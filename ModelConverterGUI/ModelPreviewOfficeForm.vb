Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports Pilz.Drawing.Drawing3D.OpenGLFactory.CameraN
Imports Pilz.S3DFileParser
Imports Pilz.UI
Imports SM64_ROM_Manager.SettingsManager

Public Class ModelPreviewOfficeForm

    Private pc As PaintingControl
    Private modelToRender As Object3D
    Private poModelInfo As PaintingObject

    Private WithEvents ModelPreview As New Pilz.Drawing.Drawing3D.OpenGLFactory.PreviewN.ModelPreview With {
        .FormBorderStyle = FormBorderStyle.None,
        .Dock = DockStyle.Fill,
        .TopLevel = False,
        .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top,
        .Scaling = 500
    }

    Public Sub New(obj As Object3D, scaling As Single)
        InitializeComponent()

        modelToRender = obj

#If Not RelLinux Then
        ModelPreview.EnableCameraControlling = True
#End If
        ModelPreview.Scaling = scaling
        ModelPreview.Size = ModelPreview.ClientSize
        ModelPreview.Show()

        AddHandler Shown, AddressOf ModelPreview.HandlesOnShown
        AddHandler Activated, AddressOf ModelPreview.HandlesOnActivated
        AddHandler Deactivate, AddressOf ModelPreview.HandlesOnDeactivate
        'AddHandler ModelPreview.Paint, Sub(sender, e) e.Graphics.DrawString("Hello World", Font, New SolidBrush(Color.Green), New PointF(10.0F, 10.0F))
        'AddHandler KeyUp, AddressOf ModelPreview.HandlesOnKeyUp
        'AddHandler KeyDown, AddressOf ModelPreview.HandlesOnKeyDown

        ModelPreview.Camera.SetCameraMode(CameraMode.FLY, ModelPreview.CameraMatrix)
        AddHandler ModelPreview.Camera.NeedSelectedObject, AddressOf Camera_NeedSelectedObject

        'Create Model Infos Panel (Temporary)
        AddHandler ModelPreview.GLControl.Paint,
            Sub(sender, e)
                If modelToRender IsNot Nothing Then
                    e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    e.Graphics.DrawString(GetModelInfoAsString, New Font(FontFamily.GenericSerif, 10), New SolidBrush(Color.Green), New Drawing.Point(10, 10))
                End If
            End Sub

        'Create Model Infos Panel
        'poModelInfo = New PaintingObject With {
        '    .Type = PaintingObjectType.Text,
        '    .TextFont = New Font(Control.DefaultFont.FontFamily, 10),
        '    .TextColor = Color.Green,
        '    .EnableFill = False,
        '    .EnableOutline = False,
        '    .Text = GetModelInfoAsString(),
        '    .HorizontalTextAlignment = StringAlignment.Near,
        '    .Location = PointF.Empty
        '}
        'pc = New PaintingControl With {
        '    .BackColor = Color.Transparent,
        '    .VisibleForMouseEvents = False,
        '    .AutoSingleSelection = False,
        '    .AutoAreaSelection = False,
        '    .AutoMoveObjects = False,
        '    .AutoMultiselection = False,
        '    .AutoRemoveSelection = False
        '}

        'Set clear color
        ModelPreview.ClearColor = If(Settings.StyleManager.AlwaysKeepBlueColors, Color.CornflowerBlue, BackColor)

        Controls.Add(ModelPreview)
    End Sub

    Private Function OpenModel() As String
        Dim ofd As New OpenFileDialog With {
            .Filter = "OBJ File|*.obj"
        }
        ofd.ShowDialog()
        Return ofd.FileName
    End Function

    Private Sub Camera_NeedSelectedObject(sender As Object, e As Camera.NeedSelectedObjectEventArgs)
        e.Points = Nothing
    End Sub

    Private Sub ModelPreviewOfficeForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ModelPreview.RenderModel(ModelPreview.AddModel(modelToRender))
        ModelPreview.UpdateView()

        'Show Model Infos
        'pc.PaintingObjects.Add(poModelInfo)
        'ModelPreview.GLControl.Controls.Add(pc)
        'poModelInfo.FitSizeToText()
        'pc.Refresh()
    End Sub

    Private Function GetModelInfoAsString() As String
        Dim matsCount As Long = modelToRender.Materials.Count
        Dim facesCount As Long = 0
        Dim vertsCount As Long = 0
        Dim vcCount As Long = 0
        Dim uvCount As Long = 0

        For Each m As Mesh In modelToRender.Meshes
            vertsCount += m.Vertices.Count
            facesCount += m.Faces.Count
            vcCount += m.VertexColors.Count
            uvCount += m.UVs.Count
        Next

        Return String.Format("Materials:{0}{1}
Faces:{0}{0}{2}
Vertices:{0}{3}
Vertex Colors{0}{4}
UVs:{0}{0}{5}",
vbTab, matsCount, facesCount, vertsCount, vcCount, uvCount)
    End Function

End Class
