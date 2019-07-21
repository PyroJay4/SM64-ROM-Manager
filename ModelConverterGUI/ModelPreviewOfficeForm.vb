Imports System.Drawing
Imports System.Reflection
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
        AddHandler ModelPreview.Paint, Sub(sender, e) e.Graphics.DrawString("Hello World", Font, New SolidBrush(Color.Green), New PointF(10.0F, 10.0F))
        'AddHandler KeyUp, AddressOf ModelPreview.HandlesOnKeyUp
        'AddHandler KeyDown, AddressOf ModelPreview.HandlesOnKeyDown

        For Each f As FieldInfo In ModelPreview.GetType.GetFields(BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
            Console.WriteLine(f.Name)
        Next

        ModelPreview.Camera.SetCameraMode(CameraMode.FLY, ModelPreview.CameraMatrix)
        AddHandler ModelPreview.Camera.NeedSelectedObject, AddressOf Camera_NeedSelectedObject

        'Temporary fix
        Dim glControl1 As Control = ModelPreview.GetType.GetField("_glControl1", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic).GetValue(ModelPreview)
        AddHandler glControl1.Paint,
            Sub(sender, e)
                If modelToRender IsNot Nothing Then
                    e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    e.Graphics.DrawString(GetModelInfoAsString, New Font(FontFamily.GenericSerif, 10), New SolidBrush(Color.Green), New Drawing.Point(10, 10))
                End If
            End Sub

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

    Private Sub Camera_NeedSelectedObject(e As Camera.NeedSelectedObjectEventArgs)
        e.Points = Nothing
    End Sub

    Private Sub ModelPreviewOfficeForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ModelPreview.RenderModel(ModelPreview.AddModel(modelToRender))
        ModelPreview.UpdateView()
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
