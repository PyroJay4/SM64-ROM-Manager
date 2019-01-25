<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RGBEditInfoEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RGBEditInfoEditor))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX_Okay = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.SwitchButton_Alpha = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.SwitchButton_Dark = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.SwitchButton_Light = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.SwitchButton_DarkMult = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_Alpha = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_Dark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LightMult = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.TextBoxX_Light = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_Name = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperValidator1 = New DevComponents.DotNetBar.Validator.SuperValidator()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        Me.RegularExpressionValidator1 = New DevComponents.DotNetBar.Validator.RegularExpressionValidator()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonX_Okay)
        Me.Panel1.Controls.Add(Me.ButtonX_Cancel)
        Me.Panel1.Controls.Add(Me.SwitchButton_Alpha)
        Me.Panel1.Controls.Add(Me.SwitchButton_Dark)
        Me.Panel1.Controls.Add(Me.SwitchButton_Light)
        Me.Panel1.Controls.Add(Me.SwitchButton_DarkMult)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.TextBoxX_Alpha)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.TextBoxX_Dark)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.SwitchButton_LightMult)
        Me.Panel1.Controls.Add(Me.TextBoxX_Light)
        Me.Panel1.Controls.Add(Me.TextBoxX_Name)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 140)
        Me.Panel1.TabIndex = 1
        '
        'ButtonX_Okay
        '
        Me.ButtonX_Okay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Okay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_Okay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX_Okay.FocusCuesEnabled = False
        Me.ButtonX_Okay.Location = New System.Drawing.Point(206, 114)
        Me.ButtonX_Okay.Name = "ButtonX_Okay"
        Me.ButtonX_Okay.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_Okay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Okay.TabIndex = 108
        Me.ButtonX_Okay.Text = "Okay"
        '
        'ButtonX_Cancel
        '
        Me.ButtonX_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX_Cancel.FocusCuesEnabled = False
        Me.ButtonX_Cancel.Location = New System.Drawing.Point(125, 114)
        Me.ButtonX_Cancel.Name = "ButtonX_Cancel"
        Me.ButtonX_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Cancel.TabIndex = 107
        Me.ButtonX_Cancel.Text = "Cancel"
        '
        'SwitchButton_Alpha
        '
        '
        '
        '
        Me.SwitchButton_Alpha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_Alpha.FocusCuesEnabled = False
        Me.SwitchButton_Alpha.Location = New System.Drawing.Point(58, 82)
        Me.SwitchButton_Alpha.Name = "SwitchButton_Alpha"
        Me.SwitchButton_Alpha.OffText = "No"
        Me.SwitchButton_Alpha.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_Alpha.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_Alpha.OnText = "Yes"
        Me.SwitchButton_Alpha.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_Alpha.Size = New System.Drawing.Size(57, 20)
        Me.SwitchButton_Alpha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_Alpha.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_Alpha.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_Alpha.SwitchWidth = 15
        Me.SwitchButton_Alpha.TabIndex = 106
        '
        'SwitchButton_Dark
        '
        '
        '
        '
        Me.SwitchButton_Dark.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_Dark.FocusCuesEnabled = False
        Me.SwitchButton_Dark.Location = New System.Drawing.Point(58, 56)
        Me.SwitchButton_Dark.Name = "SwitchButton_Dark"
        Me.SwitchButton_Dark.OffText = "No"
        Me.SwitchButton_Dark.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_Dark.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_Dark.OnText = "Yes"
        Me.SwitchButton_Dark.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_Dark.Size = New System.Drawing.Size(57, 20)
        Me.SwitchButton_Dark.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_Dark.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_Dark.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_Dark.SwitchWidth = 15
        Me.SwitchButton_Dark.TabIndex = 105
        '
        'SwitchButton_Light
        '
        '
        '
        '
        Me.SwitchButton_Light.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_Light.FocusCuesEnabled = False
        Me.SwitchButton_Light.Location = New System.Drawing.Point(58, 30)
        Me.SwitchButton_Light.Name = "SwitchButton_Light"
        Me.SwitchButton_Light.OffText = "No"
        Me.SwitchButton_Light.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_Light.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_Light.OnText = "Yes"
        Me.SwitchButton_Light.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_Light.Size = New System.Drawing.Size(57, 20)
        Me.SwitchButton_Light.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_Light.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_Light.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_Light.SwitchWidth = 15
        Me.SwitchButton_Light.TabIndex = 104
        '
        'SwitchButton_DarkMult
        '
        '
        '
        '
        Me.SwitchButton_DarkMult.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_DarkMult.FocusCuesEnabled = False
        Me.SwitchButton_DarkMult.Location = New System.Drawing.Point(121, 56)
        Me.SwitchButton_DarkMult.Name = "SwitchButton_DarkMult"
        Me.SwitchButton_DarkMult.OffText = "Single"
        Me.SwitchButton_DarkMult.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_DarkMult.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_DarkMult.OnText = "Double"
        Me.SwitchButton_DarkMult.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_DarkMult.Size = New System.Drawing.Size(63, 20)
        Me.SwitchButton_DarkMult.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_DarkMult.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_DarkMult.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_DarkMult.SwitchWidth = 15
        Me.SwitchButton_DarkMult.TabIndex = 103
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(3, 82)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(49, 20)
        Me.LabelX3.TabIndex = 102
        Me.LabelX3.Text = "Alpha:"
        '
        'TextBoxX_Alpha
        '
        Me.TextBoxX_Alpha.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Alpha.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Alpha.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Alpha.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Alpha.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Alpha.Location = New System.Drawing.Point(190, 82)
        Me.TextBoxX_Alpha.Name = "TextBoxX_Alpha"
        Me.TextBoxX_Alpha.PreventEnterBeep = True
        Me.TextBoxX_Alpha.Size = New System.Drawing.Size(91, 20)
        Me.TextBoxX_Alpha.TabIndex = 100
        Me.TextBoxX_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxX_Alpha.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_Alpha.WatermarkText = "Address"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 56)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(49, 20)
        Me.LabelX2.TabIndex = 99
        Me.LabelX2.Text = "Dark:"
        '
        'TextBoxX_Dark
        '
        Me.TextBoxX_Dark.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Dark.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Dark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Dark.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Dark.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Dark.Location = New System.Drawing.Point(190, 56)
        Me.TextBoxX_Dark.Name = "TextBoxX_Dark"
        Me.TextBoxX_Dark.PreventEnterBeep = True
        Me.TextBoxX_Dark.Size = New System.Drawing.Size(91, 20)
        Me.TextBoxX_Dark.TabIndex = 97
        Me.TextBoxX_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxX_Dark.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_Dark.WatermarkText = "Address"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 30)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(49, 20)
        Me.LabelX1.TabIndex = 96
        Me.LabelX1.Text = "Light:"
        '
        'SwitchButton_LightMult
        '
        '
        '
        '
        Me.SwitchButton_LightMult.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_LightMult.FocusCuesEnabled = False
        Me.SwitchButton_LightMult.Location = New System.Drawing.Point(121, 30)
        Me.SwitchButton_LightMult.Name = "SwitchButton_LightMult"
        Me.SwitchButton_LightMult.OffText = "Single"
        Me.SwitchButton_LightMult.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_LightMult.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_LightMult.OnText = "Double"
        Me.SwitchButton_LightMult.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_LightMult.Size = New System.Drawing.Size(63, 20)
        Me.SwitchButton_LightMult.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_LightMult.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_LightMult.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_LightMult.SwitchWidth = 15
        Me.SwitchButton_LightMult.TabIndex = 95
        '
        'TextBoxX_Light
        '
        Me.TextBoxX_Light.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Light.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Light.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Light.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Light.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Light.Location = New System.Drawing.Point(190, 30)
        Me.TextBoxX_Light.Name = "TextBoxX_Light"
        Me.TextBoxX_Light.PreventEnterBeep = True
        Me.TextBoxX_Light.Size = New System.Drawing.Size(91, 20)
        Me.TextBoxX_Light.TabIndex = 2
        Me.TextBoxX_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxX_Light.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_Light.WatermarkText = "Address"
        '
        'TextBoxX_Name
        '
        Me.TextBoxX_Name.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Name.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Name.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Name.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Name.Location = New System.Drawing.Point(3, 4)
        Me.TextBoxX_Name.Name = "TextBoxX_Name"
        Me.TextBoxX_Name.PreventEnterBeep = True
        Me.TextBoxX_Name.Size = New System.Drawing.Size(278, 20)
        Me.TextBoxX_Name.TabIndex = 1
        Me.SuperValidator1.SetValidator1(Me.TextBoxX_Name, Me.RegularExpressionValidator1)
        Me.TextBoxX_Name.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_Name.WatermarkText = "Name"
        '
        'SuperValidator1
        '
        Me.SuperValidator1.ContainerControl = Me
        Me.SuperValidator1.ErrorProvider = Me.ErrorProvider1
        Me.SuperValidator1.Highlighter = Me.Highlighter1
        Me.SuperValidator1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        '
        'RegularExpressionValidator1
        '
        Me.RegularExpressionValidator1.ErrorMessage = "Your error message here."
        Me.RegularExpressionValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red
        Me.RegularExpressionValidator1.ValidationExpression = "\S{5,5}"
        Me.RegularExpressionValidator1.ValuePropertyName = "Text"
        '
        'RGBEditInfoEditor
        '
        Me.AcceptButton = Me.ButtonX_Okay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX_Cancel
        Me.ClientSize = New System.Drawing.Size(284, 140)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "RGBEditInfoEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit RGB Info"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBoxX_Name As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_Light As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_LightMult As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_Alpha As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_Dark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SwitchButton_DarkMult As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton_Dark As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton_Light As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton_Alpha As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ButtonX_Okay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperValidator1 As DevComponents.DotNetBar.Validator.SuperValidator
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
    Friend WithEvents RegularExpressionValidator1 As DevComponents.DotNetBar.Validator.RegularExpressionValidator
End Class
