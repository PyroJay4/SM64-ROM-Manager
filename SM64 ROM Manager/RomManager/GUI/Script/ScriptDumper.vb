Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Imports DevComponents.Tree
Imports PaintingControls
Imports SM64Lib.Level.Script
Imports SM64Lib.Script

Public Class ScriptDumper(Of TCmd, eTypes)

    Private pc As New PaintingControl With {.Dock = DockStyle.None, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right, .Location = Point.Empty, .AutoScroll = True, .BackColor = Color.Transparent} '.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top, .Location = New Point(0, 0)
    Public Property Script As BaseCommandCollection(Of TCmd, eTypes) = Nothing
    Private Shared dicLabelItems As New Dictionary(Of String, LabelX)

    Public Sub New()
        SuspendLayout()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        PanelEx_PC.Controls.Add(pc)
        pc.Parent = PanelEx_PC
        pc.AutoMoveObjects = False
        pc.Size = PanelEx_PC.Size

        PanelEx_PC.VerticalScroll.Visible = False

        ResumeLayout()
    End Sub

    Private Sub ScriptDumper_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        pc.SuspendLayout()
        pc.PaintingObjects.Clear()
        dicLabelItems.Clear()

        Dim curY As Integer = 10
        Dim curWidth As Integer = 0

        For Each cmd As BaseCommand(Of eTypes) In Script

            Dim po As New PaintingObject With {.EnableResize = False}
            pc.PaintingObjects.Add(po)
            po.Text = $"{cmd.ToString}"
            po.TextColor = Me.ForeColor
            po.Type = PaintingObjectType.Custom
            po.TextFont = New Font(po.TextFont.FontFamily, 12, po.TextFont.Style)
            po.HorizontalTextAlignment = StringAlignment.Near

            Dim lb As New LabelX With {.Text = po.Text, .Font = po.TextFont}
            Dim newName As String = dicLabelItems.Count
            lb.BackColor = PanelEx_PC.Style.BackColor1.Color
            po.Name = newName
            lb.Name = newName
            lb.Visible = False
            lb.Refresh()
            dicLabelItems.Add(newName, lb)

            po.Y = curY
            po.X = 10
            po.FitSizeToText()
            lb.Size = Size.Round(po.Size)
            curWidth = Math.Max(curWidth, po.Width)
            curY += po.Height + 10

            po.DrawMethodes.Add(AddressOf DrawCmdText)

        Next

        pc.Size = New Size(PanelEx_PC.Width - 17, curY)

        pc.ResumeLayout()
        pc.Invalidate()
    End Sub

    Private Shared Sub DrawCmdText(obj As PaintingObject, e As PaintEventArgs)
        'DefaultDrawMethodes.DrawText(obj, e)
        Dim bmp As New Bitmap(CInt(obj.Width), CInt(obj.Height))
        Dim lb As LabelX = dicLabelItems(obj.Name)
        lb.DrawToBitmap(bmp, New Rectangle(Point.Empty, lb.Size))
        e.Graphics.DrawImage(bmp, obj.Location)
        bmp.Dispose()
    End Sub

End Class
