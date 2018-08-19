<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextureGraphicFormatEditor
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextureGraphicFormatEditor))
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_SaveColsettings = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_ColType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX_CollisionType = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_MaxPixels = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_EnableTextureAnimation = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ComboBoxEx_SelectDisplaylist = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewEx1
        '
        Me.ListViewEx1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewEx1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.FocusCuesEnabled = False
        Me.ListViewEx1.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx1.FullRowSelect = True
        Me.ListViewEx1.HideSelection = False
        Me.ListViewEx1.Location = New System.Drawing.Point(12, 41)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(457, 458)
        Me.ListViewEx1.TabIndex = 117
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        '
        'LabelX48
        '
        '
        '
        '
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX48.Location = New System.Drawing.Point(12, 12)
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Size = New System.Drawing.Size(149, 23)
        Me.LabelX48.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX48.TabIndex = 116
        Me.LabelX48.Text = "Textures:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(475, 263)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(211, 207)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 119
        Me.PictureBox1.TabStop = False
        '
        'Button_SaveColsettings
        '
        Me.Button_SaveColsettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_SaveColsettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_SaveColsettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_SaveColsettings.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_SaveColsettings.FocusCuesEnabled = False
        Me.Button_SaveColsettings.Location = New System.Drawing.Point(595, 476)
        Me.Button_SaveColsettings.Name = "Button_SaveColsettings"
        Me.Button_SaveColsettings.Size = New System.Drawing.Size(91, 23)
        Me.Button_SaveColsettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_SaveColsettings.TabIndex = 118
        Me.Button_SaveColsettings.Text = "Save && Exit"
        '
        'ComboBox_ColType
        '
        Me.ComboBox_ColType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_ColType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_ColType.DropDownHeight = 150
        Me.ComboBox_ColType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_ColType.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_ColType.FormattingEnabled = True
        Me.ComboBox_ColType.IntegralHeight = False
        Me.ComboBox_ColType.ItemHeight = 15
        Me.ComboBox_ColType.Location = New System.Drawing.Point(475, 41)
        Me.ComboBox_ColType.Name = "ComboBox_ColType"
        Me.ComboBox_ColType.Size = New System.Drawing.Size(211, 21)
        Me.ComboBox_ColType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_ColType.TabIndex = 121
        '
        'LabelX_CollisionType
        '
        Me.LabelX_CollisionType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_CollisionType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_CollisionType.Location = New System.Drawing.Point(475, 12)
        Me.LabelX_CollisionType.Name = "LabelX_CollisionType"
        Me.LabelX_CollisionType.Size = New System.Drawing.Size(211, 23)
        Me.LabelX_CollisionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX_CollisionType.TabIndex = 120
        Me.LabelX_CollisionType.Text = "Texture Type:"
        '
        'LabelX_MaxPixels
        '
        Me.LabelX_MaxPixels.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_MaxPixels.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_MaxPixels.Location = New System.Drawing.Point(475, 68)
        Me.LabelX_MaxPixels.Name = "LabelX_MaxPixels"
        Me.LabelX_MaxPixels.Size = New System.Drawing.Size(211, 23)
        Me.LabelX_MaxPixels.TabIndex = 122
        Me.LabelX_MaxPixels.Text = "Max Pixels: 0"
        '
        'LabelX1
        '
        Me.LabelX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(475, 126)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(211, 23)
        Me.LabelX1.TabIndex = 124
        '
        'CheckBoxX_EnableTextureAnimation
        '
        Me.CheckBoxX_EnableTextureAnimation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX_EnableTextureAnimation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableTextureAnimation.FocusCuesEnabled = False
        Me.CheckBoxX_EnableTextureAnimation.Location = New System.Drawing.Point(475, 97)
        Me.CheckBoxX_EnableTextureAnimation.Name = "CheckBoxX_EnableTextureAnimation"
        Me.CheckBoxX_EnableTextureAnimation.Size = New System.Drawing.Size(211, 23)
        Me.CheckBoxX_EnableTextureAnimation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_EnableTextureAnimation.TabIndex = 125
        Me.CheckBoxX_EnableTextureAnimation.Text = "Enable Texture Animation"
        '
        'ComboBoxEx_SelectDisplaylist
        '
        Me.ComboBoxEx_SelectDisplaylist.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEx_SelectDisplaylist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_SelectDisplaylist.DropDownHeight = 150
        Me.ComboBoxEx_SelectDisplaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_SelectDisplaylist.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_SelectDisplaylist.FormattingEnabled = True
        Me.ComboBoxEx_SelectDisplaylist.IntegralHeight = False
        Me.ComboBoxEx_SelectDisplaylist.ItemHeight = 15
        Me.ComboBoxEx_SelectDisplaylist.Location = New System.Drawing.Point(581, 127)
        Me.ComboBoxEx_SelectDisplaylist.Name = "ComboBoxEx_SelectDisplaylist"
        Me.ComboBoxEx_SelectDisplaylist.Size = New System.Drawing.Size(105, 21)
        Me.ComboBoxEx_SelectDisplaylist.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx_SelectDisplaylist.TabIndex = 127
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(475, 126)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(100, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX2.TabIndex = 126
        Me.LabelX2.Text = "Select Displaylist:"
        '
        'TextureGraphicFormatEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 511)
        Me.Controls.Add(Me.ComboBoxEx_SelectDisplaylist)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.CheckBoxX_EnableTextureAnimation)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX_MaxPixels)
        Me.Controls.Add(Me.ComboBox_ColType)
        Me.Controls.Add(Me.LabelX_CollisionType)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button_SaveColsettings)
        Me.Controls.Add(Me.ListViewEx1)
        Me.Controls.Add(Me.LabelX48)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextureGraphicFormatEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Texture Format Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Button_SaveColsettings As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_ColType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX_CollisionType As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_MaxPixels As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX_EnableTextureAnimation As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ComboBoxEx_SelectDisplaylist As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
