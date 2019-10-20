<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_AddSpecialItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AddSpecialItem))
        Me.Button_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.Button_Okay = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox_Type = New System.Windows.Forms.GroupBox()
        Me.CheckBoxX_Mist = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_ToxicHaze = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_Water = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupBox_Box = New System.Windows.Forms.GroupBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_Alpha = New DevComponents.Editors.IntegerInput()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_WaterType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Button_SetUpHeight = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX_Height = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_Scale = New DevComponents.Editors.IntegerInput()
        Me.Button_SetUpPos2 = New DevComponents.DotNetBar.ButtonX()
        Me.Button_SetUpPos1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX_Pos2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Pos1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX59 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox_Type.SuspendLayout()
        Me.GroupBox_Box.SuspendLayout()
        CType(Me.IntegerInput_Alpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_Scale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Cancel
        '
        Me.Button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.FocusCuesEnabled = False
        Me.Button_Cancel.Location = New System.Drawing.Point(65, 133)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(56, 23)
        Me.Button_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Cancel.TabIndex = 103
        Me.Button_Cancel.Text = "Cancel"
        '
        'Button_Okay
        '
        Me.Button_Okay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Okay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Okay.FocusCuesEnabled = False
        Me.Button_Okay.Location = New System.Drawing.Point(3, 133)
        Me.Button_Okay.Name = "Button_Okay"
        Me.Button_Okay.Size = New System.Drawing.Size(56, 23)
        Me.Button_Okay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Okay.TabIndex = 102
        Me.Button_Okay.Text = "Okay"
        '
        'GroupBox_Type
        '
        Me.GroupBox_Type.Controls.Add(Me.CheckBoxX_Mist)
        Me.GroupBox_Type.Controls.Add(Me.CheckBoxX_ToxicHaze)
        Me.GroupBox_Type.Controls.Add(Me.CheckBoxX_Water)
        Me.GroupBox_Type.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox_Type.Name = "GroupBox_Type"
        Me.GroupBox_Type.Size = New System.Drawing.Size(118, 124)
        Me.GroupBox_Type.TabIndex = 104
        Me.GroupBox_Type.TabStop = False
        Me.GroupBox_Type.Text = "Type"
        '
        'CheckBoxX_Mist
        '
        '
        '
        '
        Me.CheckBoxX_Mist.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_Mist.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX_Mist.FocusCuesEnabled = False
        Me.CheckBoxX_Mist.Location = New System.Drawing.Point(6, 71)
        Me.CheckBoxX_Mist.Name = "CheckBoxX_Mist"
        Me.CheckBoxX_Mist.Size = New System.Drawing.Size(106, 20)
        Me.CheckBoxX_Mist.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_Mist.TabIndex = 2
        Me.CheckBoxX_Mist.Text = "Mist"
        '
        'CheckBoxX_ToxicHaze
        '
        '
        '
        '
        Me.CheckBoxX_ToxicHaze.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_ToxicHaze.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX_ToxicHaze.FocusCuesEnabled = False
        Me.CheckBoxX_ToxicHaze.Location = New System.Drawing.Point(6, 45)
        Me.CheckBoxX_ToxicHaze.Name = "CheckBoxX_ToxicHaze"
        Me.CheckBoxX_ToxicHaze.Size = New System.Drawing.Size(106, 20)
        Me.CheckBoxX_ToxicHaze.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_ToxicHaze.TabIndex = 1
        Me.CheckBoxX_ToxicHaze.Text = "Toxic Haze"
        '
        'CheckBoxX_Water
        '
        '
        '
        '
        Me.CheckBoxX_Water.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_Water.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.CheckBoxX_Water.FocusCuesEnabled = False
        Me.CheckBoxX_Water.Location = New System.Drawing.Point(6, 19)
        Me.CheckBoxX_Water.Name = "CheckBoxX_Water"
        Me.CheckBoxX_Water.Size = New System.Drawing.Size(106, 20)
        Me.CheckBoxX_Water.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_Water.TabIndex = 0
        Me.CheckBoxX_Water.Text = "Water"
        '
        'GroupBox_Box
        '
        Me.GroupBox_Box.Controls.Add(Me.LabelX3)
        Me.GroupBox_Box.Controls.Add(Me.IntegerInput_Alpha)
        Me.GroupBox_Box.Controls.Add(Me.LabelX2)
        Me.GroupBox_Box.Controls.Add(Me.ComboBox_WaterType)
        Me.GroupBox_Box.Controls.Add(Me.LabelX1)
        Me.GroupBox_Box.Controls.Add(Me.Button_SetUpHeight)
        Me.GroupBox_Box.Controls.Add(Me.LabelX_Height)
        Me.GroupBox_Box.Controls.Add(Me.IntegerInput_Scale)
        Me.GroupBox_Box.Controls.Add(Me.Button_SetUpPos2)
        Me.GroupBox_Box.Controls.Add(Me.Button_SetUpPos1)
        Me.GroupBox_Box.Controls.Add(Me.LabelX_Pos2)
        Me.GroupBox_Box.Controls.Add(Me.LabelX_Pos1)
        Me.GroupBox_Box.Controls.Add(Me.LabelX59)
        Me.GroupBox_Box.Location = New System.Drawing.Point(127, 3)
        Me.GroupBox_Box.Name = "GroupBox_Box"
        Me.GroupBox_Box.Size = New System.Drawing.Size(258, 153)
        Me.GroupBox_Box.TabIndex = 105
        Me.GroupBox_Box.TabStop = False
        Me.GroupBox_Box.Text = "Box Settings"
        Me.GroupBox_Box.Visible = False
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(123, 121)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(15, 23)
        Me.LabelX3.TabIndex = 116
        Me.LabelX3.Text = "%"
        '
        'IntegerInput_Alpha
        '
        '
        '
        '
        Me.IntegerInput_Alpha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_Alpha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_Alpha.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_Alpha.Location = New System.Drawing.Point(87, 123)
        Me.IntegerInput_Alpha.MaxValue = 100
        Me.IntegerInput_Alpha.MinValue = 0
        Me.IntegerInput_Alpha.Name = "IntegerInput_Alpha"
        Me.IntegerInput_Alpha.Size = New System.Drawing.Size(30, 20)
        Me.IntegerInput_Alpha.TabIndex = 115
        Me.IntegerInput_Alpha.Value = 30
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(6, 123)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 20)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX2.TabIndex = 114
        Me.LabelX2.Text = "Transparence:"
        '
        'ComboBox_WaterType
        '
        Me.ComboBox_WaterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_WaterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_WaterType.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_WaterType.FormattingEnabled = True
        Me.ComboBox_WaterType.ItemHeight = 15
        Me.ComboBox_WaterType.Items.AddRange(New Object() {"Default Water", "Invisible Water", "JRB Water", "Green Water", "Lava Water"})
        Me.ComboBox_WaterType.Location = New System.Drawing.Point(147, 97)
        Me.ComboBox_WaterType.Name = "ComboBox_WaterType"
        Me.ComboBox_WaterType.Size = New System.Drawing.Size(105, 21)
        Me.ComboBox_WaterType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_WaterType.TabIndex = 111
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(6, 97)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(135, 20)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX1.TabIndex = 110
        Me.LabelX1.Text = "Water Type:"
        '
        'Button_SetUpHeight
        '
        Me.Button_SetUpHeight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_SetUpHeight.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_SetUpHeight.FocusCuesEnabled = False
        Me.Button_SetUpHeight.Location = New System.Drawing.Point(202, 70)
        Me.Button_SetUpHeight.Name = "Button_SetUpHeight"
        Me.Button_SetUpHeight.Size = New System.Drawing.Size(50, 22)
        Me.Button_SetUpHeight.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_SetUpHeight.TabIndex = 109
        Me.Button_SetUpHeight.Text = "Set up"
        '
        'LabelX_Height
        '
        '
        '
        '
        Me.LabelX_Height.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Height.Location = New System.Drawing.Point(120, 71)
        Me.LabelX_Height.Name = "LabelX_Height"
        Me.LabelX_Height.Size = New System.Drawing.Size(76, 20)
        Me.LabelX_Height.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX_Height.TabIndex = 108
        Me.LabelX_Height.Text = "Height: 0"
        '
        'IntegerInput_Scale
        '
        '
        '
        '
        Me.IntegerInput_Scale.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_Scale.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_Scale.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_Scale.Location = New System.Drawing.Point(44, 71)
        Me.IntegerInput_Scale.MaxValue = 8192
        Me.IntegerInput_Scale.MinValue = -8192
        Me.IntegerInput_Scale.Name = "IntegerInput_Scale"
        Me.IntegerInput_Scale.ShowUpDown = True
        Me.IntegerInput_Scale.Size = New System.Drawing.Size(53, 20)
        Me.IntegerInput_Scale.TabIndex = 103
        '
        'Button_SetUpPos2
        '
        Me.Button_SetUpPos2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_SetUpPos2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_SetUpPos2.FocusCuesEnabled = False
        Me.Button_SetUpPos2.Location = New System.Drawing.Point(202, 44)
        Me.Button_SetUpPos2.Name = "Button_SetUpPos2"
        Me.Button_SetUpPos2.Size = New System.Drawing.Size(50, 22)
        Me.Button_SetUpPos2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_SetUpPos2.TabIndex = 102
        Me.Button_SetUpPos2.Text = "Set up"
        '
        'Button_SetUpPos1
        '
        Me.Button_SetUpPos1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_SetUpPos1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_SetUpPos1.FocusCuesEnabled = False
        Me.Button_SetUpPos1.Location = New System.Drawing.Point(202, 18)
        Me.Button_SetUpPos1.Name = "Button_SetUpPos1"
        Me.Button_SetUpPos1.Size = New System.Drawing.Size(50, 22)
        Me.Button_SetUpPos1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_SetUpPos1.TabIndex = 101
        Me.Button_SetUpPos1.Text = "Set up"
        '
        'LabelX_Pos2
        '
        '
        '
        '
        Me.LabelX_Pos2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Pos2.Location = New System.Drawing.Point(6, 45)
        Me.LabelX_Pos2.Name = "LabelX_Pos2"
        Me.LabelX_Pos2.Size = New System.Drawing.Size(190, 20)
        Me.LabelX_Pos2.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX_Pos2.TabIndex = 100
        Me.LabelX_Pos2.Text = "Edge 2: 0, 0"
        '
        'LabelX_Pos1
        '
        '
        '
        '
        Me.LabelX_Pos1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Pos1.Location = New System.Drawing.Point(6, 19)
        Me.LabelX_Pos1.Name = "LabelX_Pos1"
        Me.LabelX_Pos1.Size = New System.Drawing.Size(190, 20)
        Me.LabelX_Pos1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX_Pos1.TabIndex = 98
        Me.LabelX_Pos1.Text = "Edge 1: 0, 0"
        '
        'LabelX59
        '
        '
        '
        '
        Me.LabelX59.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX59.Location = New System.Drawing.Point(6, 71)
        Me.LabelX59.Name = "LabelX59"
        Me.LabelX59.Size = New System.Drawing.Size(32, 20)
        Me.LabelX59.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX59.TabIndex = 95
        Me.LabelX59.Text = "Scale:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GroupBox_Type)
        Me.Panel1.Controls.Add(Me.GroupBox_Box)
        Me.Panel1.Controls.Add(Me.Button_Cancel)
        Me.Panel1.Controls.Add(Me.Button_Okay)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(389, 159)
        Me.Panel1.TabIndex = 106
        '
        'Form_AddSpecialItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 159)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_AddSpecialItem"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Special Item"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.GroupBox_Type.ResumeLayout(False)
        Me.GroupBox_Box.ResumeLayout(False)
        CType(Me.IntegerInput_Alpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_Scale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_Okay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox_Type As GroupBox
    Friend WithEvents CheckBoxX_Water As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_Mist As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_ToxicHaze As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupBox_Box As GroupBox
    Friend WithEvents LabelX59 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Pos2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Pos1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_SetUpPos2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_SetUpPos1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents IntegerInput_Scale As DevComponents.Editors.IntegerInput
    Friend WithEvents Button_SetUpHeight As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX_Height As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_WaterType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents IntegerInput_Alpha As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As Panel
End Class
