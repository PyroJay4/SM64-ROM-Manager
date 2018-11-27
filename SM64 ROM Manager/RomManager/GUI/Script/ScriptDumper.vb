Imports DevComponents.AdvTree
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Imports PaintingControls
Imports SM64Lib.Levels.Script
Imports SM64Lib.Script

Public Class ScriptDumper(Of TCmd, eTypes)

    Private WithEvents PaintingControl1 As New PaintingControl With {.Dock = DockStyle.None, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right, .Location = Point.Empty, .AutoScroll = True, .BackColor = Color.Transparent} '.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top, .Location = New Point(0, 0)
    Public Property Script As BaseCommandCollection(Of TCmd, eTypes) = Nothing
    Private Shared dicLabelItems As New Dictionary(Of String, LabelX)
    Private Shared dicCommands As New Dictionary(Of String, BaseCommand(Of eTypes))

    Public Sub New()
        SuspendLayout()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        PanelEx_PaintingControl1.Controls.Add(PaintingControl1)
        PaintingControl1.Parent = PanelEx_PaintingControl1
        PaintingControl1.AutoMoveObjects = False
        PaintingControl1.Size = PanelEx_PaintingControl1.Size

        PanelEx_PaintingControl1.VerticalScroll.Visible = False

        ResumeLayout()
    End Sub

    Private Sub ScriptDumper_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ListCommands()
    End Sub

    Private Sub ListCommands()
        PaintingControl1.SuspendLayout()
        PaintingControl1.PaintingObjects.Clear()
        dicLabelItems.Clear()
        dicCommands.Clear()

        Dim curY As Integer = 10
        Dim curWidth As Integer = 0

        For Each cmd As BaseCommand(Of eTypes) In Script

            Dim po As New PaintingObject With {.EnableResize = False}
            PaintingControl1.PaintingObjects.Add(po)
            po.Text = $"{cmd.ToString}"
            po.TextColor = Me.ForeColor
            po.Type = PaintingObjectType.Custom
            po.TextFont = New Font(po.TextFont.FontFamily, 12, po.TextFont.Style)
            po.HorizontalTextAlignment = StringAlignment.Near

            Dim lb As New LabelX With {.Text = po.Text, .Font = po.TextFont}
            Dim newName As String = dicLabelItems.Count
            lb.BackColor = PanelEx_PaintingControl1.Style.BackColor1.Color
            po.Name = newName
            lb.Name = newName
            lb.Visible = False
            lb.Refresh()
            dicLabelItems.Add(newName, lb)
            dicCommands.Add(newName, cmd)

            po.Y = curY
            po.X = 10
            po.FitSizeToText()
            lb.Size = Size.Round(po.Size)
            curWidth = Math.Max(curWidth, po.Width)
            curY += po.Height + 10

            AddHandler po.MouseUp, AddressOf PaintingObject_MouseUp

            po.DrawMethodes.Add(AddressOf DrawCmdText)

        Next

        PaintingControl1.Size = New Size(PanelEx_PaintingControl1.Width - 17, curY)

        PaintingControl1.ResumeLayout()
        PaintingControl1.Invalidate()
    End Sub

    Private Shared Sub DrawCmdText(e As PaintingObjectPaintEventArgs)
        Dim lb As LabelX = dicLabelItems(e.PaintingObject.Name)
        Dim bmp As New Bitmap(CInt(e.PaintingObject.Width), CInt(e.PaintingObject.Height))
        lb.Text = e.PaintingObject.Text
        lb.DrawToBitmap(bmp, New Rectangle(Point.Empty, lb.Size))
        e.Graphics.DrawImage(bmp, e.Location)
        bmp.Dispose()
    End Sub

    Private ReadOnly Property SelectedName As String
        Get
            Dim obj As PaintingObject = PaintingControl1.SelectedObjects.FirstOrDefault
            If obj IsNot Nothing Then
                Return obj.Name
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Private Sub CopyRomAddress()
        Dim name As String = SelectedName
        If Not String.IsNullOrEmpty(name) Then
            Clipboard.SetText(TextFromValue(dicCommands(name).RomAddress))
        End If
    End Sub
    Private Sub CopyRamAddress()
        Dim name As String = SelectedName
        If Not String.IsNullOrEmpty(name) Then
            Clipboard.SetText(TextFromValue(dicCommands(name).BankAddress))
        End If
    End Sub
    Private Sub CopyAsHexArray()
        Dim name As String = SelectedName
        If Not String.IsNullOrEmpty(name) Then
            Clipboard.SetText(dicCommands(name).ToString)
        End If
    End Sub

    Private Sub EditHex()
        Dim po As PaintingObject = PaintingControl1.SelectedObjects.FirstOrDefault
        If po IsNot Nothing Then
            Dim cmd As SM64Lib.Script.ICommand = dicCommands(po.Name)
            OpenHexEditor(cmd)
            po.Text = cmd.ToString
            PaintingControl1.Refresh()
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        CopyRomAddress()
    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        CopyRamAddress()
    End Sub
    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        CopyAsHexArray()
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        EditHex()
    End Sub

    Private Sub PaintingObject_MouseUp(sender As PaintingObject, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            PaintingControl1.Refresh()
            CM_Cmd.Popup(Cursor.Position)
        End If
    End Sub

End Class
