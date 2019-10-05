Namespace LevelEditor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TextureEditor
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextureEditor))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.FlowLayoutPanel_Textures = New System.Windows.Forms.FlowLayoutPanel()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.SideBar1 = New DevComponents.DotNetBar.SideBar()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.PictureBox_CurImage = New System.Windows.Forms.PictureBox()
            Me.AdvPropertyGrid1 = New DevComponents.DotNetBar.AdvPropertyGrid()
            Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
            Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
            Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ExpTex = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem_ImpTex = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
            Me.Panel1.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.PictureBox_CurImage, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Transparent
            Me.Panel1.Controls.Add(Me.FlowLayoutPanel_Textures)
            Me.Panel1.Controls.Add(Me.Panel4)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(684, 561)
            Me.Panel1.TabIndex = 0
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel_Textures.AutoScroll = True
            Me.FlowLayoutPanel_Textures.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel_Textures.Location = New System.Drawing.Point(200, 0)
            Me.FlowLayoutPanel_Textures.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel_Textures.Size = New System.Drawing.Size(484, 561)
            Me.FlowLayoutPanel_Textures.TabIndex = 6
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.SideBar1)
            Me.Panel4.Controls.Add(Me.Panel2)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Panel4.Location = New System.Drawing.Point(0, 0)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(200, 561)
            Me.Panel4.TabIndex = 1
            '
            'SideBar1
            '
            Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
            Me.SideBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.SideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None
            Me.SideBar1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SideBar1.ExpandedPanel = Nothing
            Me.SideBar1.ForeColor = System.Drawing.Color.Black
            Me.SideBar1.Location = New System.Drawing.Point(0, 0)
            Me.SideBar1.Name = "SideBar1"
            Me.SideBar1.Size = New System.Drawing.Size(200, 231)
            Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.SideBar1.TabIndex = 0
            Me.SideBar1.Text = "SideBar1"
            Me.SideBar1.UsingSystemColors = True
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.PictureBox_CurImage)
            Me.Panel2.Controls.Add(Me.AdvPropertyGrid1)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(0, 231)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(200, 330)
            Me.Panel2.TabIndex = 2
            '
            'PictureBox_CurImage
            '
            Me.PictureBox_CurImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBox_CurImage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PictureBox_CurImage.Location = New System.Drawing.Point(0, 0)
            Me.PictureBox_CurImage.Name = "PictureBox_CurImage"
            Me.PictureBox_CurImage.Size = New System.Drawing.Size(200, 178)
            Me.PictureBox_CurImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBox_CurImage.TabIndex = 1
            Me.PictureBox_CurImage.TabStop = False
            '
            'AdvPropertyGrid1
            '
            Me.AdvPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.AdvPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke
            Me.AdvPropertyGrid1.Location = New System.Drawing.Point(0, 178)
            Me.AdvPropertyGrid1.Name = "AdvPropertyGrid1"
            Me.AdvPropertyGrid1.PropertySort = DevComponents.DotNetBar.ePropertySort.Alphabetical
            Me.AdvPropertyGrid1.SearchBoxVisible = False
            Me.AdvPropertyGrid1.Size = New System.Drawing.Size(200, 152)
            Me.AdvPropertyGrid1.TabIndex = 1
            Me.AdvPropertyGrid1.Text = "AdvPropertyGrid1"
            Me.AdvPropertyGrid1.ToolbarVisible = False
            '
            'Highlighter1
            '
            Me.Highlighter1.ContainerControl = Me
            Me.Highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            '
            'ContextMenuBar1
            '
            Me.ContextMenuBar1.AntiAlias = True
            Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.ContextMenuBar1.IsMaximized = False
            Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1, Me.ButtonItem2})
            Me.ContextMenuBar1.Location = New System.Drawing.Point(415, 0)
            Me.ContextMenuBar1.Name = "ContextMenuBar1"
            Me.ContextMenuBar1.Size = New System.Drawing.Size(206, 25)
            Me.ContextMenuBar1.Stretch = True
            Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ContextMenuBar1.TabIndex = 1
            Me.ContextMenuBar1.TabStop = False
            Me.ContextMenuBar1.Text = "ContextMenuBar1"
            '
            'ButtonItem1
            '
            Me.ButtonItem1.AutoExpandOnClick = True
            Me.ButtonItem1.Name = "ButtonItem1"
            Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ExpTex, Me.ButtonItem_ImpTex})
            Me.ButtonItem1.Text = "CM_PictureBox"
            '
            'ButtonItem_ExpTex
            '
            Me.ButtonItem_ExpTex.Name = "ButtonItem_ExpTex"
            Me.ButtonItem_ExpTex.Text = "Export Texture ..."
            '
            'ButtonItem_ImpTex
            '
            Me.ButtonItem_ImpTex.Name = "ButtonItem_ImpTex"
            Me.ButtonItem_ImpTex.Text = "Import Texture ..."
            '
            'ButtonItem2
            '
            Me.ButtonItem2.AutoExpandOnClick = True
            Me.ButtonItem2.Name = "ButtonItem2"
            Me.ButtonItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3, Me.ButtonItem4})
            Me.ButtonItem2.Text = "CM_Block"
            '
            'ButtonItem3
            '
            Me.ButtonItem3.Name = "ButtonItem3"
            Me.ButtonItem3.Text = "Export Textures ..."
            '
            'ButtonItem4
            '
            Me.ButtonItem4.Name = "ButtonItem4"
            Me.ButtonItem4.Text = "Import Textures ..."
            '
            'TextureEditor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(684, 561)
            Me.Controls.Add(Me.ContextMenuBar1)
            Me.Controls.Add(Me.Panel1)
            Me.DoubleBuffered = True
            Me.EnableGlass = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TextureEditor"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Texture Editor"
            Me.TopLeftCornerSize = 0
            Me.TopRightCornerSize = 0
            Me.Panel1.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            CType(Me.PictureBox_CurImage, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
        Friend WithEvents FlowLayoutPanel_Textures As FlowLayoutPanel
        Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
        Friend WithEvents Panel4 As Panel
        Friend WithEvents AdvPropertyGrid1 As DevComponents.DotNetBar.AdvPropertyGrid
        Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
        Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ExpTex As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem_ImpTex As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents Panel2 As Panel
        Friend WithEvents PictureBox_CurImage As PictureBox
        Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
