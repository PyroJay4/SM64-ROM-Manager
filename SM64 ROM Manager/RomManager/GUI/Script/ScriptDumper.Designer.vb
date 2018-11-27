<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScriptDumper(Of TCmd, eTypes)
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelEx_PaintingControl1 = New DevComponents.DotNetBar.PanelEx()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.CM_Cmd = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx_PaintingControl1
        '
        Me.PanelEx_PaintingControl1.AutoScroll = True
        Me.PanelEx_PaintingControl1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx_PaintingControl1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx_PaintingControl1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx_PaintingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx_PaintingControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx_PaintingControl1.Name = "PanelEx_PaintingControl1"
        Me.PanelEx_PaintingControl1.Size = New System.Drawing.Size(998, 679)
        Me.PanelEx_PaintingControl1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx_PaintingControl1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx_PaintingControl1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx_PaintingControl1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx_PaintingControl1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx_PaintingControl1.Style.GradientAngle = 90
        Me.PanelEx_PaintingControl1.TabIndex = 0
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CM_Cmd})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(772, 0)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(75, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 4
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'CM_Cmd
        '
        Me.CM_Cmd.AutoExpandOnClick = True
        Me.CM_Cmd.Name = "CM_Cmd"
        Me.CM_Cmd.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3, Me.ButtonItem4, Me.ButtonItem1, Me.ButtonItem2})
        Me.CM_Cmd.Text = "CM_Cmd"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlE)
        Me.ButtonItem3.Text = "Edit Command ..."
        '
        'ButtonItem4
        '
        Me.ButtonItem4.BeginGroup = True
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.ButtonItem4.Text = "Copy Command"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Copy ROM Address"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Copy Bank Address"
        '
        'ScriptDumper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(998, 679)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.PanelEx_PaintingControl1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Name = "ScriptDumper"
        Me.Text = "ScriptDumper"
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelEx_PaintingControl1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents CM_Cmd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
End Class
