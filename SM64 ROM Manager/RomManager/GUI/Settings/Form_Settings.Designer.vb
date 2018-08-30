<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Settings
    Inherits DevComponents.DotNetBar.OfficeForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Settings))
        Me.ComboBox_DefaultValueType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_SearchUpdates = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_AreaEditor_DefaultWindowMode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_AreaEditor_DefaultCameraMode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.TabControl2 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX_EmulatorPatch = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.ComboBoxEx_LoaderModule = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_DefaultValueType
        '
        Me.ComboBox_DefaultValueType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_DefaultValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_DefaultValueType.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_DefaultValueType.FormattingEnabled = True
        Me.ComboBox_DefaultValueType.ItemHeight = 15
        Me.ComboBox_DefaultValueType.Items.AddRange(New Object() {"Decimal", "Hex (0x)", "Hex (&H)", "Hex ($)"})
        Me.ComboBox_DefaultValueType.Location = New System.Drawing.Point(288, 33)
        Me.ComboBox_DefaultValueType.Name = "ComboBox_DefaultValueType"
        Me.ComboBox_DefaultValueType.Size = New System.Drawing.Size(80, 21)
        Me.ComboBox_DefaultValueType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_DefaultValueType.TabIndex = 5
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(5, 32)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(113, 22)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "Default Value Type:"
        '
        'SwitchButton_SearchUpdates
        '
        '
        '
        '
        Me.SwitchButton_SearchUpdates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_SearchUpdates.Location = New System.Drawing.Point(288, 4)
        Me.SwitchButton_SearchUpdates.Name = "SwitchButton_SearchUpdates"
        Me.SwitchButton_SearchUpdates.OffText = "Manual"
        Me.SwitchButton_SearchUpdates.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_SearchUpdates.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_SearchUpdates.OnText = "Automatic"
        Me.SwitchButton_SearchUpdates.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_SearchUpdates.Size = New System.Drawing.Size(80, 22)
        Me.SwitchButton_SearchUpdates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_SearchUpdates.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_SearchUpdates.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_SearchUpdates.SwitchWidth = 15
        Me.SwitchButton_SearchUpdates.TabIndex = 3
        Me.SwitchButton_SearchUpdates.Value = True
        Me.SwitchButton_SearchUpdates.ValueObject = "Y"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(5, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(113, 22)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Search for Updates:"
        '
        'ComboBox_AreaEditor_DefaultWindowMode
        '
        Me.ComboBox_AreaEditor_DefaultWindowMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_AreaEditor_DefaultWindowMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_AreaEditor_DefaultWindowMode.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_AreaEditor_DefaultWindowMode.FormattingEnabled = True
        Me.ComboBox_AreaEditor_DefaultWindowMode.ItemHeight = 15
        Me.ComboBox_AreaEditor_DefaultWindowMode.Items.AddRange(New Object() {"Normal", "Maximized"})
        Me.ComboBox_AreaEditor_DefaultWindowMode.Location = New System.Drawing.Point(257, 32)
        Me.ComboBox_AreaEditor_DefaultWindowMode.Name = "ComboBox_AreaEditor_DefaultWindowMode"
        Me.ComboBox_AreaEditor_DefaultWindowMode.Size = New System.Drawing.Size(111, 21)
        Me.ComboBox_AreaEditor_DefaultWindowMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_AreaEditor_DefaultWindowMode.TabIndex = 8
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(5, 32)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(113, 22)
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX7.TabIndex = 7
        Me.LabelX7.Text = "Default Window Mode:"
        '
        'ComboBox_AreaEditor_DefaultCameraMode
        '
        Me.ComboBox_AreaEditor_DefaultCameraMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_AreaEditor_DefaultCameraMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_AreaEditor_DefaultCameraMode.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_AreaEditor_DefaultCameraMode.FormattingEnabled = True
        Me.ComboBox_AreaEditor_DefaultCameraMode.ItemHeight = 15
        Me.ComboBox_AreaEditor_DefaultCameraMode.Items.AddRange(New Object() {"Fly", "Orbit"})
        Me.ComboBox_AreaEditor_DefaultCameraMode.Location = New System.Drawing.Point(257, 4)
        Me.ComboBox_AreaEditor_DefaultCameraMode.Name = "ComboBox_AreaEditor_DefaultCameraMode"
        Me.ComboBox_AreaEditor_DefaultCameraMode.Size = New System.Drawing.Size(111, 21)
        Me.ComboBox_AreaEditor_DefaultCameraMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_AreaEditor_DefaultCameraMode.TabIndex = 6
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(5, 4)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(113, 22)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "Default Camera Mode:"
        '
        'TabControl2
        '
        Me.TabControl2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl2.CanReorderTabs = False
        Me.TabControl2.Controls.Add(Me.TabControlPanel1)
        Me.TabControl2.Controls.Add(Me.TabControlPanel2)
        Me.TabControl2.Controls.Add(Me.TabControlPanel3)
        Me.TabControl2.Controls.Add(Me.TabControlPanel4)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.ForeColor = System.Drawing.Color.Black
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl2.SelectedTabIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(373, 258)
        Me.TabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl2.TabIndex = 1
        Me.TabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl2.Tabs.Add(Me.TabItem1)
        Me.TabControl2.Tabs.Add(Me.TabItem3)
        Me.TabControl2.Tabs.Add(Me.TabItem2)
        Me.TabControl2.Tabs.Add(Me.TabItem4)
        Me.TabControl2.Text = "TabControl2"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.LabelX6)
        Me.TabControlPanel2.Controls.Add(Me.ComboBox_AreaEditor_DefaultCameraMode)
        Me.TabControlPanel2.Controls.Add(Me.ComboBox_AreaEditor_DefaultWindowMode)
        Me.TabControlPanel2.Controls.Add(Me.LabelX7)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(373, 231)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Area Editor"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.ButtonX1)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(373, 231)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 9
        Me.TabControlPanel3.TabItem = Me.TabItem3
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(5, 4)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(129, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 19
        Me.ButtonX1.Text = "Manage Input Settings"
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Level Manager"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ButtonX4)
        Me.TabControlPanel1.Controls.Add(Me.ComboBoxEx1)
        Me.TabControlPanel1.Controls.Add(Me.LabelX10)
        Me.TabControlPanel1.Controls.Add(Me.ButtonX3)
        Me.TabControlPanel1.Controls.Add(Me.ButtonX2)
        Me.TabControlPanel1.Controls.Add(Me.TextBoxX_EmulatorPatch)
        Me.TabControlPanel1.Controls.Add(Me.LabelX9)
        Me.TabControlPanel1.Controls.Add(Me.LabelX1)
        Me.TabControlPanel1.Controls.Add(Me.SwitchButton_SearchUpdates)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.ComboBox_DefaultValueType)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(373, 231)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 15
        Me.ComboBoxEx1.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.ComboBoxEx1.Location = New System.Drawing.Point(248, 114)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(120, 21)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 16
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "None (Ask)"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Yes"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "No"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(5, 114)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(237, 22)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX10.TabIndex = 15
        Me.LabelX10.Text = "Default answer if Update Patches are avaiable:"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Location = New System.Drawing.Point(139, 60)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(128, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX3.TabIndex = 14
        Me.ButtonX3.Text = "Launch via 'Open With'"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Location = New System.Drawing.Point(273, 60)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(95, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.Symbol = "58055"
        Me.ButtonX2.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
        Me.ButtonX2.TabIndex = 13
        Me.ButtonX2.Text = "Select Path ..."
        '
        'TextBoxX_EmulatorPatch
        '
        Me.TextBoxX_EmulatorPatch.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_EmulatorPatch.Border.Class = "TextBoxBorder"
        Me.TextBoxX_EmulatorPatch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_EmulatorPatch.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_EmulatorPatch.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_EmulatorPatch.Location = New System.Drawing.Point(5, 88)
        Me.TextBoxX_EmulatorPatch.Name = "TextBoxX_EmulatorPatch"
        Me.TextBoxX_EmulatorPatch.PreventEnterBeep = True
        Me.TextBoxX_EmulatorPatch.Size = New System.Drawing.Size(363, 20)
        Me.TextBoxX_EmulatorPatch.TabIndex = 12
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(5, 60)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(128, 22)
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX9.TabIndex = 11
        Me.LabelX9.Text = "Launch game arguments:"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "General"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.ComboBoxEx_LoaderModule)
        Me.TabControlPanel4.Controls.Add(Me.LabelX5)
        Me.TabControlPanel4.Controls.Add(Me.LabelX2)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(373, 231)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 16
        Me.TabControlPanel4.TabItem = Me.TabItem4
        '
        'ComboBoxEx_LoaderModule
        '
        Me.ComboBoxEx_LoaderModule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_LoaderModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_LoaderModule.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_LoaderModule.FormattingEnabled = True
        Me.ComboBoxEx_LoaderModule.ItemHeight = 15
        Me.ComboBoxEx_LoaderModule.Location = New System.Drawing.Point(256, 4)
        Me.ComboBoxEx_LoaderModule.Name = "ComboBoxEx_LoaderModule"
        Me.ComboBoxEx_LoaderModule.Size = New System.Drawing.Size(111, 21)
        Me.ComboBoxEx_LoaderModule.TabIndex = 14
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(4, 32)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(363, 96)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX5.TabIndex = 13
        Me.LabelX5.Text = resources.GetString("LabelX5.Text")
        Me.LabelX5.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX5.Visible = False
        Me.LabelX5.WordWrap = True
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(4, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(103, 22)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX2.TabIndex = 11
        Me.LabelX2.Text = "Loader Module:"
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "File Parser"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(248, 204)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(120, 23)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 17
        Me.ButtonX4.Text = "<div padding=""0,0,-1,0""><font color=""#C0504D"">Reset all Settings</font></div>"
        '
        'Form_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 258)
        Me.Controls.Add(Me.TabControl2)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Settings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SwitchButton_SearchUpdates As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_DefaultValueType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBox_AreaEditor_DefaultWindowMode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_AreaEditor_DefaultCameraMode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabControl2 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ComboBoxEx_LoaderModule As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBoxX_EmulatorPatch As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
End Class
