<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CollisionEditor
    Inherits DevComponents.DotNetBar.OfficeForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CollisionEditor))
        Me.TextBoxX_ColParam2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_ColParam1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX_ColParamsTipp = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Param2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Param1 = New DevComponents.DotNetBar.LabelX()
        Me.Button_SaveColsettings = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_ColType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX_CollisionType = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxX_IsNonSolid = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxX_ColParam2
        '
        Me.TextBoxX_ColParam2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_ColParam2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ColParam2.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ColParam2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ColParam2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ColParam2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ColParam2.Location = New System.Drawing.Point(166, 140)
        Me.TextBoxX_ColParam2.Name = "TextBoxX_ColParam2"
        Me.TextBoxX_ColParam2.PreventEnterBeep = True
        Me.TextBoxX_ColParam2.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxX_ColParam2.TabIndex = 110
        Me.TextBoxX_ColParam2.Text = "0x7F"
        Me.TextBoxX_ColParam2.Visible = False
        '
        'TextBoxX_ColParam1
        '
        Me.TextBoxX_ColParam1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_ColParam1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ColParam1.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ColParam1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ColParam1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ColParam1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ColParam1.Location = New System.Drawing.Point(166, 114)
        Me.TextBoxX_ColParam1.Name = "TextBoxX_ColParam1"
        Me.TextBoxX_ColParam1.PreventEnterBeep = True
        Me.TextBoxX_ColParam1.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxX_ColParam1.TabIndex = 109
        Me.TextBoxX_ColParam1.Text = "0xFF"
        Me.TextBoxX_ColParam1.Visible = False
        '
        'LabelX_ColParamsTipp
        '
        Me.LabelX_ColParamsTipp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_ColParamsTipp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_ColParamsTipp.Location = New System.Drawing.Point(0, 166)
        Me.LabelX_ColParamsTipp.Name = "LabelX_ColParamsTipp"
        Me.LabelX_ColParamsTipp.Size = New System.Drawing.Size(211, 0)
        Me.LabelX_ColParamsTipp.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX_ColParamsTipp.TabIndex = 108
        Me.LabelX_ColParamsTipp.Text = "<u>Params-Tipp:</u><br></br>No tipp."
        Me.LabelX_ColParamsTipp.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX_ColParamsTipp.Visible = False
        '
        'LabelX_Param2
        '
        Me.LabelX_Param2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_Param2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Param2.Location = New System.Drawing.Point(0, 140)
        Me.LabelX_Param2.Name = "LabelX_Param2"
        Me.LabelX_Param2.Size = New System.Drawing.Size(160, 20)
        Me.LabelX_Param2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX_Param2.TabIndex = 107
        Me.LabelX_Param2.Text = "Param 2:"
        Me.LabelX_Param2.Visible = False
        '
        'LabelX_Param1
        '
        Me.LabelX_Param1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_Param1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Param1.Location = New System.Drawing.Point(0, 114)
        Me.LabelX_Param1.Name = "LabelX_Param1"
        Me.LabelX_Param1.Size = New System.Drawing.Size(160, 20)
        Me.LabelX_Param1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX_Param1.TabIndex = 106
        Me.LabelX_Param1.Text = "Param 1:"
        Me.LabelX_Param1.Visible = False
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
        Me.Button_SaveColsettings.TabIndex = 105
        Me.Button_SaveColsettings.Text = "Save && Exit"
        Me.Button_SaveColsettings.Visible = False
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
        Me.LabelX48.TabIndex = 103
        Me.LabelX48.Text = "Textures:"
        '
        'ComboBox_ColType
        '
        Me.ComboBox_ColType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_ColType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_ColType.DropDownHeight = 150
        Me.ComboBox_ColType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_ColType.Enabled = False
        Me.ComboBox_ColType.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_ColType.FormattingEnabled = True
        Me.ComboBox_ColType.IntegralHeight = False
        Me.ComboBox_ColType.ItemHeight = 15
        Me.ComboBox_ColType.Items.AddRange(New Object() {"00: Default", "01: Lava / Lethal ice", "05: Hang from ceiling", "0A: Death floor", "0B: Close-up camera movement", "0D: Water-related", "0E: Water currents", "12: Falling in void (Big Boo's Haunt)", "13: Very slippery hill", "14: Slippery hill", "15: Climbable hill", "1A: Used in Merry-go-round room", "1B: Switches to area 1 (WDW)", "1C: Switches to area 2 (WDW and TTM)", "1D: Switches to area 3 (TTM)", "1E: Switches to Area 4 (TTM)", "21: Gripping sand or grass", "22: Sinking sand (with death)", "23: Quicksand", "24: Moving sand 1", "25: Moving sand 2", "26: Sinking sand (without death)", "27: Alternate moving sand", "28: Wall / fence", "29: Grass / flat", "2A: Un-climbable hill", "2C: Wind", "2D: Moving sand ( with death)", "2E: Ice (CCM race)", "2F: Look up and warp (Wing Cap)", "30: Flat (Non-slippery on ice terrain)", "32: Death at bottom (alternate)", "33: Starting line (Peach's Secret Slide)", "34: Finish line (Peach's Secret Slide)", "35: Solid and slippery snow / sand", "36: Snow / ice", "37: Non-slippery areas in ice levels", "38: Death at bottom with wind", "65: Wide camera (Bob-Omb Battlefield)", "66: Walls (THI area 3)", "6E: Step on 4 to make Pyramide Top Explode", "6F: Camera-related (Bower First Course)", "70: Camera-related (Bob-Omb Battlefield)", "72: Inaccessible Area", "75: Camera-related (Cool, Cool Mountain)", "76: Wodden log / breakable boxes", "79: Solid floor in slide terrain", "7A: Activate cap and floor switches", "7B: Vanish cap walls", "FD: Pool warp (Hazy Maze Cave)", "FF: Below Bowser trapdoor"})
        Me.ComboBox_ColType.Location = New System.Drawing.Point(0, 29)
        Me.ComboBox_ColType.Name = "ComboBox_ColType"
        Me.ComboBox_ColType.Size = New System.Drawing.Size(211, 21)
        Me.ComboBox_ColType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_ColType.TabIndex = 102
        Me.ComboBox_ColType.Visible = False
        '
        'LabelX_CollisionType
        '
        Me.LabelX_CollisionType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_CollisionType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_CollisionType.Location = New System.Drawing.Point(0, 0)
        Me.LabelX_CollisionType.Name = "LabelX_CollisionType"
        Me.LabelX_CollisionType.Size = New System.Drawing.Size(211, 23)
        Me.LabelX_CollisionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX_CollisionType.TabIndex = 101
        Me.LabelX_CollisionType.Text = "Collision-Type:"
        Me.LabelX_CollisionType.Visible = False
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.FocusCuesEnabled = False
        Me.CheckBoxX1.Location = New System.Drawing.Point(0, 56)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(68, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 114
        Me.CheckBoxX1.Text = "Custom:"
        '
        'TextBoxX1
        '
        Me.TextBoxX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(74, 57)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxX1.TabIndex = 113
        Me.TextBoxX1.Text = "0xFF"
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
        Me.ListViewEx1.TabIndex = 115
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, True, False, New System.Drawing.Size(0, 0))
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(475, 263)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(211, 207)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 116
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX_CollisionType)
        Me.Panel1.Controls.Add(Me.ComboBox_ColType)
        Me.Panel1.Controls.Add(Me.LabelX_Param2)
        Me.Panel1.Controls.Add(Me.LabelX_ColParamsTipp)
        Me.Panel1.Controls.Add(Me.LabelX_Param1)
        Me.Panel1.Controls.Add(Me.TextBoxX_ColParam1)
        Me.Panel1.Controls.Add(Me.CheckBoxX1)
        Me.Panel1.Controls.Add(Me.TextBoxX_ColParam2)
        Me.Panel1.Controls.Add(Me.TextBoxX1)
        Me.Panel1.Location = New System.Drawing.Point(475, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(211, 245)
        Me.Panel1.TabIndex = 119
        '
        'CheckBoxX_IsNonSolid
        '
        Me.CheckBoxX_IsNonSolid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CheckBoxX_IsNonSolid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_IsNonSolid.Location = New System.Drawing.Point(475, 97)
        Me.CheckBoxX_IsNonSolid.Name = "CheckBoxX_IsNonSolid"
        Me.CheckBoxX_IsNonSolid.Size = New System.Drawing.Size(211, 23)
        Me.CheckBoxX_IsNonSolid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_IsNonSolid.TabIndex = 120
        Me.CheckBoxX_IsNonSolid.Text = "Is Non-Solid"
        '
        'CollisionEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 511)
        Me.Controls.Add(Me.CheckBoxX_IsNonSolid)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListViewEx1)
        Me.Controls.Add(Me.Button_SaveColsettings)
        Me.Controls.Add(Me.LabelX48)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CollisionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Collision Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxX_ColParam2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_ColParam1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX_ColParamsTipp As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Param2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Param1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_SaveColsettings As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_ColType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX_CollisionType As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents CheckBoxX_IsNonSolid As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
