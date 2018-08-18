<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainModelConverter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainModelConverter))
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX_Colfile = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Modelfile = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_EnableFog = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Button_ColEditor = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.NUD_Scaling = New DevComponents.Editors.DoubleInput()
        Me.Button_LoadCol = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LoadModel = New DevComponents.DotNetBar.ButtonX()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.Button_ConvertModel = New DevComponents.DotNetBar.ButtonX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.ComboBoxEx_UpAxis = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_ConvertModel = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_ConvertCollision = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_ResizeTextures = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_TextureFlip = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_CenterModel = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ButtonX_VisualMapPreview = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_CollisionMapPreview = New DevComponents.DotNetBar.ButtonX()
        Me.SwitchButton_EnableReduceVertices = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.ColorPickerButton_ShadingLight = New DevComponents.DotNetBar.ColorPickerButton()
        Me.ButtonX_GraphicsEditor = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_FogTyp = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ColorPickerButton_FogColor = New DevComponents.DotNetBar.ColorPickerButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ColorPickerButton_ShadingDarkNeu = New DevComponents.DotNetBar.ColorPickerButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        CType(Me.NUD_Scaling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Line2
        '
        resources.ApplyResources(Me.Line2, "Line2")
        Me.Line2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Line2.Name = "Line2"
        '
        'LabelX_Colfile
        '
        '
        '
        '
        Me.LabelX_Colfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_Colfile, "LabelX_Colfile")
        Me.LabelX_Colfile.Name = "LabelX_Colfile"
        Me.LabelX_Colfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX_Modelfile
        '
        '
        '
        '
        Me.LabelX_Modelfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_Modelfile, "LabelX_Modelfile")
        Me.LabelX_Modelfile.Name = "LabelX_Modelfile"
        Me.LabelX_Modelfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.SuperTooltip1.SetSuperTooltip(Me.LabelX4, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("LabelX4.SuperTooltip"), resources.GetString("LabelX4.SuperTooltip1"), resources.GetString("LabelX4.SuperTooltip2"), CType(resources.GetObject("LabelX4.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("LabelX4.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("LabelX4.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("LabelX4.SuperTooltip6"), Boolean), CType(resources.GetObject("LabelX4.SuperTooltip7"), Boolean), CType(resources.GetObject("LabelX4.SuperTooltip8"), System.Drawing.Size)))
        '
        'SwitchButton_EnableFog
        '
        '
        '
        '
        Me.SwitchButton_EnableFog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_EnableFog.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_EnableFog, "SwitchButton_EnableFog")
        Me.SwitchButton_EnableFog.Name = "SwitchButton_EnableFog"
        Me.SwitchButton_EnableFog.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_EnableFog.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_EnableFog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_EnableFog.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_EnableFog.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_EnableFog.SwitchWidth = 15
        '
        'Button_ColEditor
        '
        Me.Button_ColEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_ColEditor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_ColEditor, "Button_ColEditor")
        Me.Button_ColEditor.FocusCuesEnabled = False
        Me.Button_ColEditor.Name = "Button_ColEditor"
        Me.Button_ColEditor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX20, "LabelX20")
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX16, "LabelX16")
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'NUD_Scaling
        '
        '
        '
        '
        Me.NUD_Scaling.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.NUD_Scaling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.NUD_Scaling.Increment = 1.0R
        Me.NUD_Scaling.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        resources.ApplyResources(Me.NUD_Scaling, "NUD_Scaling")
        Me.NUD_Scaling.MaxValue = 1.0E+15R
        Me.NUD_Scaling.MinValue = 1.0E-32R
        Me.NUD_Scaling.Name = "NUD_Scaling"
        Me.NUD_Scaling.ShowUpDown = True
        Me.SuperTooltip1.SetSuperTooltip(Me.NUD_Scaling, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("NUD_Scaling.SuperTooltip"), resources.GetString("NUD_Scaling.SuperTooltip1"), resources.GetString("NUD_Scaling.SuperTooltip2"), CType(resources.GetObject("NUD_Scaling.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("NUD_Scaling.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("NUD_Scaling.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("NUD_Scaling.SuperTooltip6"), Boolean), CType(resources.GetObject("NUD_Scaling.SuperTooltip7"), Boolean), CType(resources.GetObject("NUD_Scaling.SuperTooltip8"), System.Drawing.Size)))
        Me.NUD_Scaling.Value = 500.0R
        '
        'Button_LoadCol
        '
        Me.Button_LoadCol.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_LoadCol, "Button_LoadCol")
        Me.Button_LoadCol.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LoadCol.FocusCuesEnabled = False
        Me.Button_LoadCol.Name = "Button_LoadCol"
        Me.Button_LoadCol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.Button_LoadCol, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("Button_LoadCol.SuperTooltip"), resources.GetString("Button_LoadCol.SuperTooltip1"), resources.GetString("Button_LoadCol.SuperTooltip2"), CType(resources.GetObject("Button_LoadCol.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("Button_LoadCol.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("Button_LoadCol.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("Button_LoadCol.SuperTooltip6"), Boolean), CType(resources.GetObject("Button_LoadCol.SuperTooltip7"), Boolean), CType(resources.GetObject("Button_LoadCol.SuperTooltip8"), System.Drawing.Size)))
        Me.Button_LoadCol.Symbol = "58055"
        Me.Button_LoadCol.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.Button_LoadCol.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LoadCol.SymbolSize = 12.0!
        '
        'Button_LoadModel
        '
        Me.Button_LoadModel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_LoadModel, "Button_LoadModel")
        Me.Button_LoadModel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LoadModel.FocusCuesEnabled = False
        Me.Button_LoadModel.Name = "Button_LoadModel"
        Me.Button_LoadModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.Button_LoadModel, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("Button_LoadModel.SuperTooltip"), resources.GetString("Button_LoadModel.SuperTooltip1"), resources.GetString("Button_LoadModel.SuperTooltip2"), CType(resources.GetObject("Button_LoadModel.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("Button_LoadModel.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("Button_LoadModel.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("Button_LoadModel.SuperTooltip6"), Boolean), CType(resources.GetObject("Button_LoadModel.SuperTooltip7"), Boolean), CType(resources.GetObject("Button_LoadModel.SuperTooltip8"), System.Drawing.Size)))
        Me.Button_LoadModel.Symbol = "58055"
        Me.Button_LoadModel.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.Button_LoadModel.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LoadModel.SymbolSize = 12.0!
        '
        'Line3
        '
        resources.ApplyResources(Me.Line3, "Line3")
        Me.Line3.BackColor = System.Drawing.Color.Transparent
        Me.Line3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Line3.Name = "Line3"
        Me.Line3.VerticalLine = True
        '
        'Button_ConvertModel
        '
        Me.Button_ConvertModel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_ConvertModel, "Button_ConvertModel")
        Me.Button_ConvertModel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_ConvertModel.FocusCuesEnabled = False
        Me.Button_ConvertModel.Name = "Button_ConvertModel"
        Me.Button_ConvertModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CircularProgress1
        '
        resources.ApplyResources(Me.CircularProgress1, "CircularProgress1")
        Me.CircularProgress1.AnimationSpeed = 50
        Me.CircularProgress1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.FocusCuesEnabled = False
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.SeaGreen
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'SuperTooltip1
        '
        resources.ApplyResources(Me.SuperTooltip1, "SuperTooltip1")
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.SuperTooltip1.MaximumWidth = 200
        '
        'ComboBoxEx_UpAxis
        '
        Me.ComboBoxEx_UpAxis.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_UpAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_UpAxis.DropDownWidth = 107
        Me.ComboBoxEx_UpAxis.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_UpAxis.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx_UpAxis, "ComboBoxEx_UpAxis")
        Me.ComboBoxEx_UpAxis.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.ComboBoxEx_UpAxis.Name = "ComboBoxEx_UpAxis"
        Me.ComboBoxEx_UpAxis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ComboBoxEx_UpAxis, New DevComponents.DotNetBar.SuperTooltipInfo(resources.GetString("ComboBoxEx_UpAxis.SuperTooltip"), resources.GetString("ComboBoxEx_UpAxis.SuperTooltip1"), resources.GetString("ComboBoxEx_UpAxis.SuperTooltip2"), CType(resources.GetObject("ComboBoxEx_UpAxis.SuperTooltip3"), System.Drawing.Image), CType(resources.GetObject("ComboBoxEx_UpAxis.SuperTooltip4"), System.Drawing.Image), CType(resources.GetObject("ComboBoxEx_UpAxis.SuperTooltip5"), DevComponents.DotNetBar.eTooltipColor), CType(resources.GetObject("ComboBoxEx_UpAxis.SuperTooltip6"), Boolean), CType(resources.GetObject("ComboBoxEx_UpAxis.SuperTooltip7"), Boolean), CType(resources.GetObject("ComboBoxEx_UpAxis.SuperTooltip8"), System.Drawing.Size)))
        '
        'ComboItem1
        '
        resources.ApplyResources(Me.ComboItem1, "ComboItem1")
        '
        'ComboItem2
        '
        resources.ApplyResources(Me.ComboItem2, "ComboItem2")
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX9, "LabelX9")
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'CheckBoxX_ConvertModel
        '
        '
        '
        '
        Me.CheckBoxX_ConvertModel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_ConvertModel.Checked = True
        Me.CheckBoxX_ConvertModel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX_ConvertModel.CheckValue = "Y"
        Me.CheckBoxX_ConvertModel.FocusCuesEnabled = False
        resources.ApplyResources(Me.CheckBoxX_ConvertModel, "CheckBoxX_ConvertModel")
        Me.CheckBoxX_ConvertModel.Name = "CheckBoxX_ConvertModel"
        Me.CheckBoxX_ConvertModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'CheckBoxX_ConvertCollision
        '
        '
        '
        '
        Me.CheckBoxX_ConvertCollision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_ConvertCollision.Checked = True
        Me.CheckBoxX_ConvertCollision.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX_ConvertCollision.CheckValue = "Y"
        Me.CheckBoxX_ConvertCollision.FocusCuesEnabled = False
        resources.ApplyResources(Me.CheckBoxX_ConvertCollision, "CheckBoxX_ConvertCollision")
        Me.CheckBoxX_ConvertCollision.Name = "CheckBoxX_ConvertCollision"
        Me.CheckBoxX_ConvertCollision.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'SwitchButton_ResizeTextures
        '
        '
        '
        '
        Me.SwitchButton_ResizeTextures.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_ResizeTextures.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_ResizeTextures, "SwitchButton_ResizeTextures")
        Me.SwitchButton_ResizeTextures.Name = "SwitchButton_ResizeTextures"
        Me.SwitchButton_ResizeTextures.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_ResizeTextures.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_ResizeTextures.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_ResizeTextures.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_ResizeTextures.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_ResizeTextures.SwitchWidth = 15
        Me.SwitchButton_ResizeTextures.Value = True
        Me.SwitchButton_ResizeTextures.ValueObject = "Y"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX6, "LabelX6")
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX7, "LabelX7")
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'SwitchButton_TextureFlip
        '
        '
        '
        '
        Me.SwitchButton_TextureFlip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_TextureFlip.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_TextureFlip, "SwitchButton_TextureFlip")
        Me.SwitchButton_TextureFlip.Name = "SwitchButton_TextureFlip"
        Me.SwitchButton_TextureFlip.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_TextureFlip.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_TextureFlip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_TextureFlip.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_TextureFlip.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_TextureFlip.SwitchWidth = 15
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX8, "LabelX8")
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'SwitchButton_CenterModel
        '
        '
        '
        '
        Me.SwitchButton_CenterModel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_CenterModel.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_CenterModel, "SwitchButton_CenterModel")
        Me.SwitchButton_CenterModel.Name = "SwitchButton_CenterModel"
        Me.SwitchButton_CenterModel.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_CenterModel.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_CenterModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_CenterModel.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_CenterModel.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_CenterModel.SwitchWidth = 15
        '
        'ButtonX_VisualMapPreview
        '
        Me.ButtonX_VisualMapPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_VisualMapPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_VisualMapPreview, "ButtonX_VisualMapPreview")
        Me.ButtonX_VisualMapPreview.FocusCuesEnabled = False
        Me.ButtonX_VisualMapPreview.Name = "ButtonX_VisualMapPreview"
        Me.ButtonX_VisualMapPreview.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_CollisionMapPreview
        '
        Me.ButtonX_CollisionMapPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_CollisionMapPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_CollisionMapPreview, "ButtonX_CollisionMapPreview")
        Me.ButtonX_CollisionMapPreview.FocusCuesEnabled = False
        Me.ButtonX_CollisionMapPreview.Name = "ButtonX_CollisionMapPreview"
        Me.ButtonX_CollisionMapPreview.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_EnableReduceVertices
        '
        '
        '
        '
        Me.SwitchButton_EnableReduceVertices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_EnableReduceVertices.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_EnableReduceVertices, "SwitchButton_EnableReduceVertices")
        Me.SwitchButton_EnableReduceVertices.Name = "SwitchButton_EnableReduceVertices"
        Me.SwitchButton_EnableReduceVertices.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_EnableReduceVertices.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_EnableReduceVertices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_EnableReduceVertices.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_EnableReduceVertices.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_EnableReduceVertices.SwitchWidth = 15
        Me.SwitchButton_EnableReduceVertices.Value = True
        Me.SwitchButton_EnableReduceVertices.ValueObject = "Y"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX10, "LabelX10")
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'ColorPickerButton_ShadingLight
        '
        Me.ColorPickerButton_ShadingLight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ColorPickerButton_ShadingLight.AutoExpandOnClick = True
        Me.ColorPickerButton_ShadingLight.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ColorPickerButton_ShadingLight.FocusCuesEnabled = False
        Me.ColorPickerButton_ShadingLight.Image = CType(resources.GetObject("ColorPickerButton_ShadingLight.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.ColorPickerButton_ShadingLight, "ColorPickerButton_ShadingLight")
        Me.ColorPickerButton_ShadingLight.Name = "ColorPickerButton_ShadingLight"
        Me.ColorPickerButton_ShadingLight.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.ColorPickerButton_ShadingLight.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_GraphicsEditor
        '
        Me.ButtonX_GraphicsEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_GraphicsEditor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_GraphicsEditor, "ButtonX_GraphicsEditor")
        Me.ButtonX_GraphicsEditor.FocusCuesEnabled = False
        Me.ButtonX_GraphicsEditor.Name = "ButtonX_GraphicsEditor"
        Me.ButtonX_GraphicsEditor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_FogTyp
        '
        Me.ComboBox_FogTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_FogTyp.DropDownHeight = 150
        Me.ComboBox_FogTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox_FogTyp, "ComboBox_FogTyp")
        Me.ComboBox_FogTyp.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_FogTyp.FormattingEnabled = True
        Me.ComboBox_FogTyp.Items.AddRange(New Object() {resources.GetString("ComboBox_FogTyp.Items"), resources.GetString("ComboBox_FogTyp.Items1"), resources.GetString("ComboBox_FogTyp.Items2"), resources.GetString("ComboBox_FogTyp.Items3"), resources.GetString("ComboBox_FogTyp.Items4"), resources.GetString("ComboBox_FogTyp.Items5"), resources.GetString("ComboBox_FogTyp.Items6"), resources.GetString("ComboBox_FogTyp.Items7"), resources.GetString("ComboBox_FogTyp.Items8")})
        Me.ComboBox_FogTyp.Name = "ComboBox_FogTyp"
        Me.ComboBox_FogTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ColorPickerButton_FogColor
        '
        Me.ColorPickerButton_FogColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ColorPickerButton_FogColor.AutoExpandOnClick = True
        Me.ColorPickerButton_FogColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ColorPickerButton_FogColor, "ColorPickerButton_FogColor")
        Me.ColorPickerButton_FogColor.FocusCuesEnabled = False
        Me.ColorPickerButton_FogColor.Image = CType(resources.GetObject("ColorPickerButton_FogColor.Image"), System.Drawing.Image)
        Me.ColorPickerButton_FogColor.Name = "ColorPickerButton_FogColor"
        Me.ColorPickerButton_FogColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.ColorPickerButton_FogColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ComboBox_FogTyp)
        Me.Panel1.Controls.Add(Me.LabelX20)
        Me.Panel1.Controls.Add(Me.SwitchButton_EnableFog)
        Me.Panel1.Controls.Add(Me.ColorPickerButton_FogColor)
        Me.Panel1.Name = "Panel1"
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.LabelX9)
        Me.Panel2.Controls.Add(Me.SwitchButton_CenterModel)
        Me.Panel2.Name = "Panel2"
        '
        'Panel3
        '
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.LabelX4)
        Me.Panel3.Controls.Add(Me.SwitchButton_EnableReduceVertices)
        Me.Panel3.Name = "Panel3"
        '
        'Panel4
        '
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.LabelX3)
        Me.Panel4.Controls.Add(Me.SwitchButton_ResizeTextures)
        Me.Panel4.Controls.Add(Me.LabelX8)
        Me.Panel4.Controls.Add(Me.SwitchButton_TextureFlip)
        Me.Panel4.Name = "Panel4"
        '
        'Panel5
        '
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.ColorPickerButton_ShadingDarkNeu)
        Me.Panel5.Controls.Add(Me.LabelX5)
        Me.Panel5.Controls.Add(Me.LabelX6)
        Me.Panel5.Controls.Add(Me.ColorPickerButton_ShadingLight)
        Me.Panel5.Controls.Add(Me.LabelX7)
        Me.Panel5.Name = "Panel5"
        '
        'ColorPickerButton_ShadingDarkNeu
        '
        Me.ColorPickerButton_ShadingDarkNeu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ColorPickerButton_ShadingDarkNeu.AutoExpandOnClick = True
        Me.ColorPickerButton_ShadingDarkNeu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ColorPickerButton_ShadingDarkNeu.FocusCuesEnabled = False
        Me.ColorPickerButton_ShadingDarkNeu.Image = CType(resources.GetObject("ColorPickerButton_ShadingDarkNeu.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.ColorPickerButton_ShadingDarkNeu, "ColorPickerButton_ShadingDarkNeu")
        Me.ColorPickerButton_ShadingDarkNeu.Name = "ColorPickerButton_ShadingDarkNeu"
        Me.ColorPickerButton_ShadingDarkNeu.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.ColorPickerButton_ShadingDarkNeu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel6
        '
        resources.ApplyResources(Me.Panel6, "Panel6")
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.LabelX16)
        Me.Panel6.Controls.Add(Me.NUD_Scaling)
        Me.Panel6.Name = "Panel6"
        '
        'Panel7
        '
        resources.ApplyResources(Me.Panel7, "Panel7")
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.LabelX10)
        Me.Panel7.Controls.Add(Me.ComboBoxEx_UpAxis)
        Me.Panel7.Name = "Panel7"
        '
        'Panel8
        '
        resources.ApplyResources(Me.Panel8, "Panel8")
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.ButtonX_VisualMapPreview)
        Me.Panel8.Controls.Add(Me.ButtonX_GraphicsEditor)
        Me.Panel8.Name = "Panel8"
        '
        'Panel9
        '
        resources.ApplyResources(Me.Panel9, "Panel9")
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Controls.Add(Me.ButtonX_CollisionMapPreview)
        Me.Panel9.Controls.Add(Me.Button_ColEditor)
        Me.Panel9.Name = "Panel9"
        '
        'MainModelConverter
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CheckBoxX_ConvertCollision)
        Me.Controls.Add(Me.CheckBoxX_ConvertModel)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.Line3)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.LabelX_Colfile)
        Me.Controls.Add(Me.LabelX_Modelfile)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Button_LoadCol)
        Me.Controls.Add(Me.Button_LoadModel)
        Me.Controls.Add(Me.Button_ConvertModel)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainModelConverter"
        Me.ShowIcon = False
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.NUD_Scaling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX_Colfile As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Modelfile As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_EnableFog As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Button_ColEditor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NUD_Scaling As DevComponents.Editors.DoubleInput
    Friend WithEvents Button_LoadCol As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LoadModel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Button_ConvertModel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_ResizeTextures As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_TextureFlip As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_CenterModel As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX_VisualMapPreview As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_CollisionMapPreview As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SwitchButton_EnableReduceVertices As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ComboBoxEx_UpAxis As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Public WithEvents CheckBoxX_ConvertModel As DevComponents.DotNetBar.Controls.CheckBoxX
    Public WithEvents CheckBoxX_ConvertCollision As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ColorPickerButton_ShadingLight As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents ButtonX_GraphicsEditor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_FogTyp As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ColorPickerButton_FogColor As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents Panel7 As Windows.Forms.Panel
    Friend WithEvents Panel8 As Windows.Forms.Panel
    Friend WithEvents Panel9 As Windows.Forms.Panel
    Friend WithEvents ColorPickerButton_ShadingDarkNeu As DevComponents.DotNetBar.ColorPickerButton
End Class
