<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_LevelManager
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_LevelManager))
        Me.GroupBox_LM_Areas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Button_LM_AddArea = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem_ImportArea = New DevComponents.DotNetBar.ButtonItem()
        Me.Button_LM_AreaEditor = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_RemoveArea = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_EditAreaLevelScript = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2_EditGeolayoutScript = New DevComponents.DotNetBar.ButtonItem()
        Me.ListBoxAdv_LM_Areas = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ButtonX_LM_LevelsMore = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem20 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem24 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem21 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem15 = New DevComponents.DotNetBar.ButtonItem()
        Me.Button_LM_AddNewLevel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem26 = New DevComponents.DotNetBar.ButtonItem()
        Me.ListBoxAdv_LM_Levels = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.TabControl_LM_Area = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx_LM_AreaBG = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.TextBoxX_LM_ShowMsgID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LM_ShowMsgEnabled = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_LM_Enable2DCamera = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_Music = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_TerrainTyp = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_EnvironmentEffects = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_CameraPreset = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ColorPickerButton_LM_BackgroundColor = New DevComponents.DotNetBar.ColorPickerButton()
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Button_LM_RemoveSpecial = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_AddSpecial = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_EditSpecial = New DevComponents.DotNetBar.ButtonX()
        Me.ListViewEx_LM_Specials = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeaderA1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabItem6 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX_Area_CountOfCustomObjects = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Area_CountOfTexAnimations = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX_CustomObjects = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_LM_ScrollTexEditor = New DevComponents.DotNetBar.ButtonX()
        Me.Button_ImportModel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ExportModel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem_ExportVisualMap = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ExportCollisionMap = New DevComponents.DotNetBar.ButtonItem()
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControl_LM_Level = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelX_TargetLevel = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox_BGImage = New System.Windows.Forms.PictureBox()
        Me.ComboBoxEx_LM_BGMode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LM_ActSelector = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX57 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LM_HardcodedCameraSettings = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_LevelBG = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.NUD_LM_DefaultPositionYRotation = New System.Windows.Forms.NumericUpDown()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.NUD_LM_DefaultPositionAreaID = New System.Windows.Forms.NumericUpDown()
        Me.Button_LM_LoadLevelBG = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_SetUpStartPosition = New DevComponents.DotNetBar.ButtonX()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_UseGlobalObjectBank = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.TableLayoutPanel_ObjectBankSelectorBoxes = New System.Windows.Forms.TableLayoutPanel()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.GroupBox_LM_Areas.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.TabControl_LM_Area, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl_LM_Area.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        CType(Me.TabControl_LM_Level, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl_LM_Level.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.PictureBox_BGImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_LM_DefaultPositionYRotation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_LM_DefaultPositionAreaID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_LM_Areas
        '
        resources.ApplyResources(Me.GroupBox_LM_Areas, "GroupBox_LM_Areas")
        Me.GroupBox_LM_Areas.CanvasColor = System.Drawing.Color.Empty
        Me.GroupBox_LM_Areas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupBox_LM_Areas.Controls.Add(Me.Button_LM_AddArea)
        Me.GroupBox_LM_Areas.Controls.Add(Me.Button_LM_AreaEditor)
        Me.GroupBox_LM_Areas.Controls.Add(Me.ListBoxAdv_LM_Areas)
        Me.GroupBox_LM_Areas.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupBox_LM_Areas.Name = "GroupBox_LM_Areas"
        '
        '
        '
        Me.GroupBox_LM_Areas.Style.BackColorGradientAngle = 90
        Me.GroupBox_LM_Areas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_LM_Areas.Style.BorderBottomWidth = 1
        Me.GroupBox_LM_Areas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupBox_LM_Areas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_LM_Areas.Style.BorderLeftWidth = 1
        Me.GroupBox_LM_Areas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_LM_Areas.Style.BorderRightWidth = 1
        Me.GroupBox_LM_Areas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_LM_Areas.Style.BorderTopWidth = 1
        Me.GroupBox_LM_Areas.Style.CornerDiameter = 4
        Me.GroupBox_LM_Areas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupBox_LM_Areas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupBox_LM_Areas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupBox_LM_Areas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupBox_LM_Areas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupBox_LM_Areas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Button_LM_AddArea
        '
        Me.Button_LM_AddArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AddArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_AddArea, "Button_LM_AddArea")
        Me.Button_LM_AddArea.FocusCuesEnabled = False
        Me.Button_LM_AddArea.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.Button_LM_AddArea.Name = "Button_LM_AddArea"
        Me.Button_LM_AddArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AddArea.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ImportArea})
        Me.Button_LM_AddArea.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_LM_AddArea.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AddArea.SymbolSize = 12.0!
        '
        'ButtonItem_ImportArea
        '
        Me.ButtonItem_ImportArea.GlobalItem = False
        Me.ButtonItem_ImportArea.Name = "ButtonItem_ImportArea"
        resources.ApplyResources(Me.ButtonItem_ImportArea, "ButtonItem_ImportArea")
        '
        'Button_LM_AreaEditor
        '
        Me.Button_LM_AreaEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AreaEditor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_AreaEditor, "Button_LM_AreaEditor")
        Me.Button_LM_AreaEditor.FocusCuesEnabled = False
        Me.Button_LM_AreaEditor.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        Me.Button_LM_AreaEditor.Name = "Button_LM_AreaEditor"
        Me.Button_LM_AreaEditor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AreaEditor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Button_LM_RemoveArea, Me.ButtonItem_EditAreaLevelScript, Me.ButtonItem2_EditGeolayoutScript})
        Me.Button_LM_AreaEditor.SymbolColor = System.Drawing.Color.Goldenrod
        Me.Button_LM_AreaEditor.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AreaEditor.SymbolSize = 12.0!
        '
        'Button_LM_RemoveArea
        '
        Me.Button_LM_RemoveArea.GlobalItem = False
        Me.Button_LM_RemoveArea.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.Button_LM_RemoveArea.Name = "Button_LM_RemoveArea"
        Me.Button_LM_RemoveArea.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_LM_RemoveArea.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_RemoveArea.SymbolSize = 12.0!
        resources.ApplyResources(Me.Button_LM_RemoveArea, "Button_LM_RemoveArea")
        '
        'ButtonItem_EditAreaLevelScript
        '
        Me.ButtonItem_EditAreaLevelScript.BeginGroup = True
        Me.ButtonItem_EditAreaLevelScript.GlobalItem = False
        Me.ButtonItem_EditAreaLevelScript.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        Me.ButtonItem_EditAreaLevelScript.Name = "ButtonItem_EditAreaLevelScript"
        Me.ButtonItem_EditAreaLevelScript.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonItem_EditAreaLevelScript.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_EditAreaLevelScript.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_EditAreaLevelScript, "ButtonItem_EditAreaLevelScript")
        '
        'ButtonItem2_EditGeolayoutScript
        '
        Me.ButtonItem2_EditGeolayoutScript.GlobalItem = False
        Me.ButtonItem2_EditGeolayoutScript.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        Me.ButtonItem2_EditGeolayoutScript.Name = "ButtonItem2_EditGeolayoutScript"
        Me.ButtonItem2_EditGeolayoutScript.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonItem2_EditGeolayoutScript.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem2_EditGeolayoutScript.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem2_EditGeolayoutScript, "ButtonItem2_EditGeolayoutScript")
        '
        'ListBoxAdv_LM_Areas
        '
        resources.ApplyResources(Me.ListBoxAdv_LM_Areas, "ListBoxAdv_LM_Areas")
        Me.ListBoxAdv_LM_Areas.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListBoxAdv_LM_Areas.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_LM_Areas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_LM_Areas.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_LM_Areas.DragDropSupport = True
        Me.ListBoxAdv_LM_Areas.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_LM_Areas.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_LM_Areas.Name = "ListBoxAdv_LM_Areas"
        Me.ListBoxAdv_LM_Areas.ReserveLeftSpace = False
        Me.ListBoxAdv_LM_Areas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ButtonX_LM_LevelsMore)
        Me.GroupPanel1.Controls.Add(Me.Button_LM_AddNewLevel)
        Me.GroupPanel1.Controls.Add(Me.ListBoxAdv_LM_Levels)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel1, "GroupPanel1")
        Me.GroupPanel1.Name = "GroupPanel1"
        '
        '
        '
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonX_LM_LevelsMore
        '
        Me.ButtonX_LM_LevelsMore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_LM_LevelsMore.AutoExpandOnClick = True
        Me.ButtonX_LM_LevelsMore.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_LM_LevelsMore, "ButtonX_LM_LevelsMore")
        Me.ButtonX_LM_LevelsMore.FocusCuesEnabled = False
        Me.ButtonX_LM_LevelsMore.Name = "ButtonX_LM_LevelsMore"
        Me.ButtonX_LM_LevelsMore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_LM_LevelsMore.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem20, Me.ButtonItem1, Me.ButtonItem24, Me.ButtonItem19, Me.ButtonItem21, Me.ButtonItem15})
        Me.ButtonX_LM_LevelsMore.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX_LM_LevelsMore.SymbolSize = 12.0!
        '
        'ButtonItem20
        '
        Me.ButtonItem20.GlobalItem = False
        Me.ButtonItem20.Name = "ButtonItem20"
        Me.ButtonItem20.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonItem20.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem20.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem20, "ButtonItem20")
        '
        'ButtonItem1
        '
        Me.ButtonItem1.GlobalItem = False
        Me.ButtonItem1.Name = "ButtonItem1"
        resources.ApplyResources(Me.ButtonItem1, "ButtonItem1")
        '
        'ButtonItem24
        '
        Me.ButtonItem24.GlobalItem = False
        Me.ButtonItem24.Name = "ButtonItem24"
        resources.ApplyResources(Me.ButtonItem24, "ButtonItem24")
        '
        'ButtonItem19
        '
        Me.ButtonItem19.GlobalItem = False
        Me.ButtonItem19.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonItem19.Name = "ButtonItem19"
        Me.ButtonItem19.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem19.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem19.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem19, "ButtonItem19")
        '
        'ButtonItem21
        '
        Me.ButtonItem21.BeginGroup = True
        Me.ButtonItem21.GlobalItem = False
        Me.ButtonItem21.Name = "ButtonItem21"
        resources.ApplyResources(Me.ButtonItem21, "ButtonItem21")
        '
        'ButtonItem15
        '
        Me.ButtonItem15.BeginGroup = True
        Me.ButtonItem15.GlobalItem = False
        Me.ButtonItem15.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        Me.ButtonItem15.Name = "ButtonItem15"
        Me.ButtonItem15.SymbolColor = System.Drawing.Color.Goldenrod
        Me.ButtonItem15.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem15.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem15, "ButtonItem15")
        '
        'Button_LM_AddNewLevel
        '
        Me.Button_LM_AddNewLevel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AddNewLevel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_AddNewLevel.FocusCuesEnabled = False
        Me.Button_LM_AddNewLevel.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        resources.ApplyResources(Me.Button_LM_AddNewLevel, "Button_LM_AddNewLevel")
        Me.Button_LM_AddNewLevel.Name = "Button_LM_AddNewLevel"
        Me.Button_LM_AddNewLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AddNewLevel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem26})
        Me.Button_LM_AddNewLevel.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_LM_AddNewLevel.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AddNewLevel.SymbolSize = 12.0!
        '
        'ButtonItem26
        '
        Me.ButtonItem26.GlobalItem = False
        Me.ButtonItem26.Name = "ButtonItem26"
        resources.ApplyResources(Me.ButtonItem26, "ButtonItem26")
        '
        'ListBoxAdv_LM_Levels
        '
        resources.ApplyResources(Me.ListBoxAdv_LM_Levels, "ListBoxAdv_LM_Levels")
        Me.ListBoxAdv_LM_Levels.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListBoxAdv_LM_Levels.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_LM_Levels.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_LM_Levels.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_LM_Levels.DragDropSupport = True
        Me.ListBoxAdv_LM_Levels.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_LM_Levels.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_LM_Levels.Name = "ListBoxAdv_LM_Levels"
        Me.ListBoxAdv_LM_Levels.ReserveLeftSpace = False
        Me.ListBoxAdv_LM_Levels.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TabControl_LM_Area
        '
        resources.ApplyResources(Me.TabControl_LM_Area, "TabControl_LM_Area")
        Me.TabControl_LM_Area.BackColor = System.Drawing.Color.Transparent
        Me.TabControl_LM_Area.CanReorderTabs = False
        Me.TabControl_LM_Area.Controls.Add(Me.TabControlPanel4)
        Me.TabControl_LM_Area.Controls.Add(Me.TabControlPanel6)
        Me.TabControl_LM_Area.Controls.Add(Me.TabControlPanel5)
        Me.TabControl_LM_Area.ForeColor = System.Drawing.Color.Black
        Me.TabControl_LM_Area.Name = "TabControl_LM_Area"
        Me.TabControl_LM_Area.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl_LM_Area.SelectedTabIndex = 0
        Me.TabControl_LM_Area.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl_LM_Area.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl_LM_Area.Tabs.Add(Me.TabItem4)
        Me.TabControl_LM_Area.Tabs.Add(Me.TabItem5)
        Me.TabControl_LM_Area.Tabs.Add(Me.TabItem6)
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.LabelX9)
        Me.TabControlPanel4.Controls.Add(Me.ComboBoxEx_LM_AreaBG)
        Me.TabControlPanel4.Controls.Add(Me.TextBoxX_LM_ShowMsgID)
        Me.TabControlPanel4.Controls.Add(Me.LabelX1)
        Me.TabControlPanel4.Controls.Add(Me.SwitchButton_LM_ShowMsgEnabled)
        Me.TabControlPanel4.Controls.Add(Me.LabelX2)
        Me.TabControlPanel4.Controls.Add(Me.CheckBoxX_LM_Enable2DCamera)
        Me.TabControlPanel4.Controls.Add(Me.LabelX6)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox_LM_Music)
        Me.TabControlPanel4.Controls.Add(Me.LabelX7)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox_LM_TerrainTyp)
        Me.TabControlPanel4.Controls.Add(Me.LabelX8)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox_LM_EnvironmentEffects)
        Me.TabControlPanel4.Controls.Add(Me.LabelX11)
        Me.TabControlPanel4.Controls.Add(Me.ComboBox_LM_CameraPreset)
        Me.TabControlPanel4.Controls.Add(Me.ColorPickerButton_LM_BackgroundColor)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel4, "TabControlPanel4")
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabItem = Me.TabItem4
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX9, "LabelX9")
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBoxEx_LM_AreaBG
        '
        Me.ComboBoxEx_LM_AreaBG.DisplayMember = "Text"
        Me.ComboBoxEx_LM_AreaBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_LM_AreaBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_LM_AreaBG.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_LM_AreaBG.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx_LM_AreaBG, "ComboBoxEx_LM_AreaBG")
        Me.ComboBoxEx_LM_AreaBG.Items.AddRange(New Object() {Me.ComboItem12, Me.ComboItem13})
        Me.ComboBoxEx_LM_AreaBG.Name = "ComboBoxEx_LM_AreaBG"
        Me.ComboBoxEx_LM_AreaBG.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboItem12
        '
        resources.ApplyResources(Me.ComboItem12, "ComboItem12")
        '
        'ComboItem13
        '
        resources.ApplyResources(Me.ComboItem13, "ComboItem13")
        '
        'TextBoxX_LM_ShowMsgID
        '
        Me.TextBoxX_LM_ShowMsgID.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_LM_ShowMsgID.Border.Class = "TextBoxBorder"
        Me.TextBoxX_LM_ShowMsgID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_LM_ShowMsgID.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_LM_ShowMsgID.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_LM_ShowMsgID, "TextBoxX_LM_ShowMsgID")
        Me.TextBoxX_LM_ShowMsgID.Name = "TextBoxX_LM_ShowMsgID"
        Me.TextBoxX_LM_ShowMsgID.PreventEnterBeep = True
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_LM_ShowMsgEnabled
        '
        '
        '
        '
        Me.SwitchButton_LM_ShowMsgEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_LM_ShowMsgEnabled.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_LM_ShowMsgEnabled, "SwitchButton_LM_ShowMsgEnabled")
        Me.SwitchButton_LM_ShowMsgEnabled.Name = "SwitchButton_LM_ShowMsgEnabled"
        Me.SwitchButton_LM_ShowMsgEnabled.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_LM_ShowMsgEnabled.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_LM_ShowMsgEnabled.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_LM_ShowMsgEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_LM_ShowMsgEnabled.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_LM_ShowMsgEnabled.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_LM_ShowMsgEnabled.SwitchWidth = 15
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_LM_Enable2DCamera
        '
        '
        '
        '
        Me.CheckBoxX_LM_Enable2DCamera.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_LM_Enable2DCamera.FocusCuesEnabled = False
        resources.ApplyResources(Me.CheckBoxX_LM_Enable2DCamera, "CheckBoxX_LM_Enable2DCamera")
        Me.CheckBoxX_LM_Enable2DCamera.Name = "CheckBoxX_LM_Enable2DCamera"
        Me.CheckBoxX_LM_Enable2DCamera.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CheckBoxX_LM_Enable2DCamera.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.CheckBoxX_LM_Enable2DCamera.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.CheckBoxX_LM_Enable2DCamera.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX_LM_Enable2DCamera.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.CheckBoxX_LM_Enable2DCamera.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.CheckBoxX_LM_Enable2DCamera.SwitchWidth = 15
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX6, "LabelX6")
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_Music
        '
        Me.ComboBox_LM_Music.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_Music.DropDownHeight = 150
        Me.ComboBox_LM_Music.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_Music.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_Music.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_Music, "ComboBox_LM_Music")
        Me.ComboBox_LM_Music.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_Music.Items"), resources.GetString("ComboBox_LM_Music.Items1")})
        Me.ComboBox_LM_Music.Name = "ComboBox_LM_Music"
        Me.ComboBox_LM_Music.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX7, "LabelX7")
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_TerrainTyp
        '
        Me.ComboBox_LM_TerrainTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_TerrainTyp.DropDownHeight = 150
        Me.ComboBox_LM_TerrainTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_TerrainTyp.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_TerrainTyp.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_TerrainTyp, "ComboBox_LM_TerrainTyp")
        Me.ComboBox_LM_TerrainTyp.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_TerrainTyp.Items"), resources.GetString("ComboBox_LM_TerrainTyp.Items1"), resources.GetString("ComboBox_LM_TerrainTyp.Items2"), resources.GetString("ComboBox_LM_TerrainTyp.Items3"), resources.GetString("ComboBox_LM_TerrainTyp.Items4"), resources.GetString("ComboBox_LM_TerrainTyp.Items5"), resources.GetString("ComboBox_LM_TerrainTyp.Items6")})
        Me.ComboBox_LM_TerrainTyp.Name = "ComboBox_LM_TerrainTyp"
        Me.ComboBox_LM_TerrainTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX8, "LabelX8")
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_EnvironmentEffects
        '
        Me.ComboBox_LM_EnvironmentEffects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_EnvironmentEffects.DropDownHeight = 150
        Me.ComboBox_LM_EnvironmentEffects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_EnvironmentEffects.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_EnvironmentEffects.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_EnvironmentEffects, "ComboBox_LM_EnvironmentEffects")
        Me.ComboBox_LM_EnvironmentEffects.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_EnvironmentEffects.Items"), resources.GetString("ComboBox_LM_EnvironmentEffects.Items1"), resources.GetString("ComboBox_LM_EnvironmentEffects.Items2"), resources.GetString("ComboBox_LM_EnvironmentEffects.Items3"), resources.GetString("ComboBox_LM_EnvironmentEffects.Items4"), resources.GetString("ComboBox_LM_EnvironmentEffects.Items5"), resources.GetString("ComboBox_LM_EnvironmentEffects.Items6")})
        Me.ComboBox_LM_EnvironmentEffects.Name = "ComboBox_LM_EnvironmentEffects"
        Me.ComboBox_LM_EnvironmentEffects.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX11, "LabelX11")
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_CameraPreset
        '
        Me.ComboBox_LM_CameraPreset.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_CameraPreset.DropDownHeight = 150
        Me.ComboBox_LM_CameraPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_CameraPreset.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_CameraPreset.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_CameraPreset, "ComboBox_LM_CameraPreset")
        Me.ComboBox_LM_CameraPreset.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_CameraPreset.Items"), resources.GetString("ComboBox_LM_CameraPreset.Items1"), resources.GetString("ComboBox_LM_CameraPreset.Items2"), resources.GetString("ComboBox_LM_CameraPreset.Items3"), resources.GetString("ComboBox_LM_CameraPreset.Items4"), resources.GetString("ComboBox_LM_CameraPreset.Items5"), resources.GetString("ComboBox_LM_CameraPreset.Items6"), resources.GetString("ComboBox_LM_CameraPreset.Items7"), resources.GetString("ComboBox_LM_CameraPreset.Items8"), resources.GetString("ComboBox_LM_CameraPreset.Items9"), resources.GetString("ComboBox_LM_CameraPreset.Items10"), resources.GetString("ComboBox_LM_CameraPreset.Items11"), resources.GetString("ComboBox_LM_CameraPreset.Items12"), resources.GetString("ComboBox_LM_CameraPreset.Items13"), resources.GetString("ComboBox_LM_CameraPreset.Items14"), resources.GetString("ComboBox_LM_CameraPreset.Items15")})
        Me.ComboBox_LM_CameraPreset.Name = "ComboBox_LM_CameraPreset"
        Me.ComboBox_LM_CameraPreset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ColorPickerButton_LM_BackgroundColor
        '
        Me.ColorPickerButton_LM_BackgroundColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ColorPickerButton_LM_BackgroundColor.AutoExpandOnClick = True
        Me.ColorPickerButton_LM_BackgroundColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ColorPickerButton_LM_BackgroundColor.FocusCuesEnabled = False
        Me.ColorPickerButton_LM_BackgroundColor.Image = CType(resources.GetObject("ColorPickerButton_LM_BackgroundColor.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.ColorPickerButton_LM_BackgroundColor, "ColorPickerButton_LM_BackgroundColor")
        Me.ColorPickerButton_LM_BackgroundColor.Name = "ColorPickerButton_LM_BackgroundColor"
        Me.ColorPickerButton_LM_BackgroundColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.ColorPickerButton_LM_BackgroundColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.Name = "TabItem4"
        resources.ApplyResources(Me.TabItem4, "TabItem4")
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.Button_LM_RemoveSpecial)
        Me.TabControlPanel6.Controls.Add(Me.Button_LM_AddSpecial)
        Me.TabControlPanel6.Controls.Add(Me.Button_LM_EditSpecial)
        Me.TabControlPanel6.Controls.Add(Me.ListViewEx_LM_Specials)
        Me.TabControlPanel6.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel6, "TabControlPanel6")
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabItem = Me.TabItem6
        '
        'Button_LM_RemoveSpecial
        '
        Me.Button_LM_RemoveSpecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_LM_RemoveSpecial, "Button_LM_RemoveSpecial")
        Me.Button_LM_RemoveSpecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_RemoveSpecial.FocusCuesEnabled = False
        Me.Button_LM_RemoveSpecial.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.Button_LM_RemoveSpecial.Name = "Button_LM_RemoveSpecial"
        Me.Button_LM_RemoveSpecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_RemoveSpecial.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_LM_RemoveSpecial.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_RemoveSpecial.SymbolSize = 12.0!
        '
        'Button_LM_AddSpecial
        '
        Me.Button_LM_AddSpecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AddSpecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_AddSpecial.FocusCuesEnabled = False
        Me.Button_LM_AddSpecial.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        resources.ApplyResources(Me.Button_LM_AddSpecial, "Button_LM_AddSpecial")
        Me.Button_LM_AddSpecial.Name = "Button_LM_AddSpecial"
        Me.Button_LM_AddSpecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AddSpecial.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_LM_AddSpecial.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AddSpecial.SymbolSize = 12.0!
        '
        'Button_LM_EditSpecial
        '
        Me.Button_LM_EditSpecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_EditSpecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_EditSpecial, "Button_LM_EditSpecial")
        Me.Button_LM_EditSpecial.FocusCuesEnabled = False
        Me.Button_LM_EditSpecial.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        Me.Button_LM_EditSpecial.Name = "Button_LM_EditSpecial"
        Me.Button_LM_EditSpecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_EditSpecial.SymbolColor = System.Drawing.Color.Goldenrod
        Me.Button_LM_EditSpecial.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_EditSpecial.SymbolSize = 12.0!
        '
        'ListViewEx_LM_Specials
        '
        resources.ApplyResources(Me.ListViewEx_LM_Specials, "ListViewEx_LM_Specials")
        Me.ListViewEx_LM_Specials.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx_LM_Specials.Border.Class = "ListViewBorder"
        Me.ListViewEx_LM_Specials.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx_LM_Specials.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderA1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeaderA})
        Me.ListViewEx_LM_Specials.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx_LM_Specials.FocusCuesEnabled = False
        Me.ListViewEx_LM_Specials.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx_LM_Specials.FullRowSelect = True
        Me.ListViewEx_LM_Specials.GridLines = True
        Me.ListViewEx_LM_Specials.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {CType(resources.GetObject("ListViewEx_LM_Specials.Groups"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListViewEx_LM_Specials.Groups1"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListViewEx_LM_Specials.Groups2"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListViewEx_LM_Specials.Groups3"), System.Windows.Forms.ListViewGroup)})
        Me.ListViewEx_LM_Specials.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEx_LM_Specials.HideSelection = False
        Me.ListViewEx_LM_Specials.MultiSelect = False
        Me.ListViewEx_LM_Specials.Name = "ListViewEx_LM_Specials"
        Me.ListViewEx_LM_Specials.ShowGroups = False
        Me.ListViewEx_LM_Specials.UseCompatibleStateImageBehavior = False
        Me.ListViewEx_LM_Specials.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderA1
        '
        resources.ApplyResources(Me.ColumnHeaderA1, "ColumnHeaderA1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'ColumnHeader5
        '
        resources.ApplyResources(Me.ColumnHeader5, "ColumnHeader5")
        '
        'ColumnHeader6
        '
        resources.ApplyResources(Me.ColumnHeader6, "ColumnHeader6")
        '
        'ColumnHeader7
        '
        resources.ApplyResources(Me.ColumnHeader7, "ColumnHeader7")
        '
        'ColumnHeaderA
        '
        resources.ApplyResources(Me.ColumnHeaderA, "ColumnHeaderA")
        '
        'TabItem6
        '
        Me.TabItem6.AttachedControl = Me.TabControlPanel6
        Me.TabItem6.Name = "TabItem6"
        resources.ApplyResources(Me.TabItem6, "TabItem6")
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.Line2)
        Me.TabControlPanel5.Controls.Add(Me.LabelX_Area_CountOfCustomObjects)
        Me.TabControlPanel5.Controls.Add(Me.LabelX_Area_CountOfTexAnimations)
        Me.TabControlPanel5.Controls.Add(Me.LabelX10)
        Me.TabControlPanel5.Controls.Add(Me.LabelX5)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX_CustomObjects)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX_LM_ScrollTexEditor)
        Me.TabControlPanel5.Controls.Add(Me.Button_ImportModel)
        Me.TabControlPanel5.Controls.Add(Me.ButtonItem_ExportModel)
        Me.TabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel5, "TabControlPanel5")
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabItem = Me.TabItem5
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Line2, "Line2")
        Me.Line2.Name = "Line2"
        Me.Line2.VerticalLine = True
        '
        'LabelX_Area_CountOfCustomObjects
        '
        Me.LabelX_Area_CountOfCustomObjects.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_Area_CountOfCustomObjects.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_Area_CountOfCustomObjects, "LabelX_Area_CountOfCustomObjects")
        Me.LabelX_Area_CountOfCustomObjects.Name = "LabelX_Area_CountOfCustomObjects"
        Me.LabelX_Area_CountOfCustomObjects.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX_Area_CountOfTexAnimations
        '
        Me.LabelX_Area_CountOfTexAnimations.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_Area_CountOfTexAnimations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_Area_CountOfTexAnimations, "LabelX_Area_CountOfTexAnimations")
        Me.LabelX_Area_CountOfTexAnimations.Name = "LabelX_Area_CountOfTexAnimations"
        Me.LabelX_Area_CountOfTexAnimations.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX10, "LabelX10")
        Me.LabelX10.Name = "LabelX10"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.Name = "LabelX5"
        '
        'ButtonX_CustomObjects
        '
        Me.ButtonX_CustomObjects.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_CustomObjects.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_CustomObjects, "ButtonX_CustomObjects")
        Me.ButtonX_CustomObjects.FocusCuesEnabled = False
        Me.ButtonX_CustomObjects.Name = "ButtonX_CustomObjects"
        Me.ButtonX_CustomObjects.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_LM_ScrollTexEditor
        '
        Me.ButtonX_LM_ScrollTexEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_LM_ScrollTexEditor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_LM_ScrollTexEditor.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_LM_ScrollTexEditor, "ButtonX_LM_ScrollTexEditor")
        Me.ButtonX_LM_ScrollTexEditor.Name = "ButtonX_LM_ScrollTexEditor"
        Me.ButtonX_LM_ScrollTexEditor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Button_ImportModel
        '
        Me.Button_ImportModel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_ImportModel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_ImportModel.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_ImportModel, "Button_ImportModel")
        Me.Button_ImportModel.Name = "Button_ImportModel"
        Me.Button_ImportModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_ImportModel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem9, Me.ButtonItem13})
        '
        'ButtonItem9
        '
        Me.ButtonItem9.GlobalItem = False
        Me.ButtonItem9.Name = "ButtonItem9"
        resources.ApplyResources(Me.ButtonItem9, "ButtonItem9")
        '
        'ButtonItem13
        '
        Me.ButtonItem13.GlobalItem = False
        Me.ButtonItem13.Name = "ButtonItem13"
        resources.ApplyResources(Me.ButtonItem13, "ButtonItem13")
        '
        'ButtonItem_ExportModel
        '
        Me.ButtonItem_ExportModel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonItem_ExportModel.AutoExpandOnClick = True
        Me.ButtonItem_ExportModel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonItem_ExportModel.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonItem_ExportModel, "ButtonItem_ExportModel")
        Me.ButtonItem_ExportModel.Name = "ButtonItem_ExportModel"
        Me.ButtonItem_ExportModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonItem_ExportModel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ExportVisualMap, Me.ButtonItem_ExportCollisionMap})
        '
        'ButtonItem_ExportVisualMap
        '
        Me.ButtonItem_ExportVisualMap.GlobalItem = False
        Me.ButtonItem_ExportVisualMap.Name = "ButtonItem_ExportVisualMap"
        resources.ApplyResources(Me.ButtonItem_ExportVisualMap, "ButtonItem_ExportVisualMap")
        '
        'ButtonItem_ExportCollisionMap
        '
        Me.ButtonItem_ExportCollisionMap.GlobalItem = False
        Me.ButtonItem_ExportCollisionMap.Name = "ButtonItem_ExportCollisionMap"
        resources.ApplyResources(Me.ButtonItem_ExportCollisionMap, "ButtonItem_ExportCollisionMap")
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel5
        Me.TabItem5.Name = "TabItem5"
        resources.ApplyResources(Me.TabItem5, "TabItem5")
        '
        'TabControl_LM_Level
        '
        resources.ApplyResources(Me.TabControl_LM_Level, "TabControl_LM_Level")
        Me.TabControl_LM_Level.BackColor = System.Drawing.Color.Transparent
        Me.TabControl_LM_Level.CanReorderTabs = False
        Me.TabControl_LM_Level.Controls.Add(Me.TabControlPanel1)
        Me.TabControl_LM_Level.Controls.Add(Me.TabControlPanel2)
        Me.TabControl_LM_Level.ForeColor = System.Drawing.Color.Black
        Me.TabControl_LM_Level.Name = "TabControl_LM_Level"
        Me.TabControl_LM_Level.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl_LM_Level.SelectedTabIndex = 0
        Me.TabControl_LM_Level.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl_LM_Level.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl_LM_Level.Tabs.Add(Me.TabItem1)
        Me.TabControl_LM_Level.Tabs.Add(Me.TabItem2)
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.LabelX_TargetLevel)
        Me.TabControlPanel1.Controls.Add(Me.LabelX12)
        Me.TabControlPanel1.Controls.Add(Me.PictureBox_BGImage)
        Me.TabControlPanel1.Controls.Add(Me.ComboBoxEx_LM_BGMode)
        Me.TabControlPanel1.Controls.Add(Me.LabelX15)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.SwitchButton_LM_ActSelector)
        Me.TabControlPanel1.Controls.Add(Me.LabelX57)
        Me.TabControlPanel1.Controls.Add(Me.SwitchButton_LM_HardcodedCameraSettings)
        Me.TabControlPanel1.Controls.Add(Me.LabelX4)
        Me.TabControlPanel1.Controls.Add(Me.ComboBox_LM_LevelBG)
        Me.TabControlPanel1.Controls.Add(Me.LabelX24)
        Me.TabControlPanel1.Controls.Add(Me.NUD_LM_DefaultPositionYRotation)
        Me.TabControlPanel1.Controls.Add(Me.LabelX25)
        Me.TabControlPanel1.Controls.Add(Me.NUD_LM_DefaultPositionAreaID)
        Me.TabControlPanel1.Controls.Add(Me.Button_LM_LoadLevelBG)
        Me.TabControlPanel1.Controls.Add(Me.Button_LM_SetUpStartPosition)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel1, "TabControlPanel1")
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'LabelX_TargetLevel
        '
        Me.LabelX_TargetLevel.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_TargetLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_TargetLevel, "LabelX_TargetLevel")
        Me.LabelX_TargetLevel.Name = "LabelX_TargetLevel"
        Me.LabelX_TargetLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX12, "LabelX12")
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'PictureBox_BGImage
        '
        Me.PictureBox_BGImage.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBox_BGImage, "PictureBox_BGImage")
        Me.PictureBox_BGImage.Name = "PictureBox_BGImage"
        Me.PictureBox_BGImage.TabStop = False
        '
        'ComboBoxEx_LM_BGMode
        '
        Me.ComboBoxEx_LM_BGMode.DisplayMember = "Text"
        Me.ComboBoxEx_LM_BGMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_LM_BGMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_LM_BGMode.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_LM_BGMode.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx_LM_BGMode, "ComboBoxEx_LM_BGMode")
        Me.ComboBoxEx_LM_BGMode.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.ComboBoxEx_LM_BGMode.Name = "ComboBoxEx_LM_BGMode"
        Me.ComboBoxEx_LM_BGMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboItem1
        '
        resources.ApplyResources(Me.ComboItem1, "ComboItem1")
        '
        'ComboItem2
        '
        resources.ApplyResources(Me.ComboItem2, "ComboItem2")
        '
        'ComboItem3
        '
        resources.ApplyResources(Me.ComboItem3, "ComboItem3")
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX15, "LabelX15")
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_LM_ActSelector
        '
        '
        '
        '
        Me.SwitchButton_LM_ActSelector.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_LM_ActSelector.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_LM_ActSelector, "SwitchButton_LM_ActSelector")
        Me.SwitchButton_LM_ActSelector.Name = "SwitchButton_LM_ActSelector"
        Me.SwitchButton_LM_ActSelector.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_LM_ActSelector.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_LM_ActSelector.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_LM_ActSelector.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_LM_ActSelector.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_LM_ActSelector.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_LM_ActSelector.SwitchWidth = 15
        Me.SwitchButton_LM_ActSelector.Value = True
        Me.SwitchButton_LM_ActSelector.ValueObject = "Y"
        '
        'LabelX57
        '
        Me.LabelX57.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX57.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX57, "LabelX57")
        Me.LabelX57.Name = "LabelX57"
        Me.LabelX57.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_LM_HardcodedCameraSettings
        '
        '
        '
        '
        Me.SwitchButton_LM_HardcodedCameraSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_LM_HardcodedCameraSettings.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_LM_HardcodedCameraSettings, "SwitchButton_LM_HardcodedCameraSettings")
        Me.SwitchButton_LM_HardcodedCameraSettings.Name = "SwitchButton_LM_HardcodedCameraSettings"
        Me.SwitchButton_LM_HardcodedCameraSettings.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_LM_HardcodedCameraSettings.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_LM_HardcodedCameraSettings.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_LM_HardcodedCameraSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_LM_HardcodedCameraSettings.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_LM_HardcodedCameraSettings.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_LM_HardcodedCameraSettings.SwitchWidth = 15
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_LevelBG
        '
        Me.ComboBox_LM_LevelBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_LevelBG.DropDownHeight = 200
        Me.ComboBox_LM_LevelBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_LevelBG.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_LevelBG.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_LevelBG, "ComboBox_LM_LevelBG")
        Me.ComboBox_LM_LevelBG.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_LevelBG.Items"), resources.GetString("ComboBox_LM_LevelBG.Items1"), resources.GetString("ComboBox_LM_LevelBG.Items2"), resources.GetString("ComboBox_LM_LevelBG.Items3"), resources.GetString("ComboBox_LM_LevelBG.Items4"), resources.GetString("ComboBox_LM_LevelBG.Items5"), resources.GetString("ComboBox_LM_LevelBG.Items6"), resources.GetString("ComboBox_LM_LevelBG.Items7"), resources.GetString("ComboBox_LM_LevelBG.Items8"), resources.GetString("ComboBox_LM_LevelBG.Items9")})
        Me.ComboBox_LM_LevelBG.Name = "ComboBox_LM_LevelBG"
        Me.ComboBox_LM_LevelBG.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX24, "LabelX24")
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'NUD_LM_DefaultPositionYRotation
        '
        resources.ApplyResources(Me.NUD_LM_DefaultPositionYRotation, "NUD_LM_DefaultPositionYRotation")
        Me.NUD_LM_DefaultPositionYRotation.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.NUD_LM_DefaultPositionYRotation.Minimum = New Decimal(New Integer() {359, 0, 0, -2147483648})
        Me.NUD_LM_DefaultPositionYRotation.Name = "NUD_LM_DefaultPositionYRotation"
        '
        'LabelX25
        '
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX25, "LabelX25")
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'NUD_LM_DefaultPositionAreaID
        '
        resources.ApplyResources(Me.NUD_LM_DefaultPositionAreaID, "NUD_LM_DefaultPositionAreaID")
        Me.NUD_LM_DefaultPositionAreaID.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NUD_LM_DefaultPositionAreaID.Name = "NUD_LM_DefaultPositionAreaID"
        '
        'Button_LM_LoadLevelBG
        '
        Me.Button_LM_LoadLevelBG.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_LoadLevelBG.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_LoadLevelBG.FocusCuesEnabled = False
        Me.Button_LM_LoadLevelBG.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_open_folder_16px
        resources.ApplyResources(Me.Button_LM_LoadLevelBG, "Button_LM_LoadLevelBG")
        Me.Button_LM_LoadLevelBG.Name = "Button_LM_LoadLevelBG"
        Me.Button_LM_LoadLevelBG.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_LoadLevelBG.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.Button_LM_LoadLevelBG.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_LoadLevelBG.SymbolSize = 12.0!
        '
        'Button_LM_SetUpStartPosition
        '
        Me.Button_LM_SetUpStartPosition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_SetUpStartPosition.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_SetUpStartPosition.FocusCuesEnabled = False
        Me.Button_LM_SetUpStartPosition.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_support_16px
        resources.ApplyResources(Me.Button_LM_SetUpStartPosition, "Button_LM_SetUpStartPosition")
        Me.Button_LM_SetUpStartPosition.Name = "Button_LM_SetUpStartPosition"
        Me.Button_LM_SetUpStartPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_SetUpStartPosition.SymbolColor = System.Drawing.Color.Gray
        Me.Button_LM_SetUpStartPosition.SymbolSize = 12.0!
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        resources.ApplyResources(Me.TabItem1, "TabItem1")
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.LabelX13)
        Me.TabControlPanel2.Controls.Add(Me.SwitchButton_UseGlobalObjectBank)
        Me.TabControlPanel2.Controls.Add(Me.TableLayoutPanel_ObjectBankSelectorBoxes)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel2, "TabControlPanel2")
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX13, "LabelX13")
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_UseGlobalObjectBank
        '
        '
        '
        '
        Me.SwitchButton_UseGlobalObjectBank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.SwitchButton_UseGlobalObjectBank, "SwitchButton_UseGlobalObjectBank")
        Me.SwitchButton_UseGlobalObjectBank.FocusCuesEnabled = False
        Me.SwitchButton_UseGlobalObjectBank.Name = "SwitchButton_UseGlobalObjectBank"
        Me.SwitchButton_UseGlobalObjectBank.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_UseGlobalObjectBank.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_UseGlobalObjectBank.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_UseGlobalObjectBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_UseGlobalObjectBank.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_UseGlobalObjectBank.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_UseGlobalObjectBank.SwitchWidth = 15
        '
        'TableLayoutPanel_ObjectBankSelectorBoxes
        '
        resources.ApplyResources(Me.TableLayoutPanel_ObjectBankSelectorBoxes, "TableLayoutPanel_ObjectBankSelectorBoxes")
        Me.TableLayoutPanel_ObjectBankSelectorBoxes.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel_ObjectBankSelectorBoxes.Name = "TableLayoutPanel_ObjectBankSelectorBoxes"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        resources.ApplyResources(Me.TabItem2, "TabItem2")
        '
        'Tab_LevelManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox_LM_Areas)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TabControl_LM_Area)
        Me.Controls.Add(Me.TabControl_LM_Level)
        Me.Name = "Tab_LevelManager"
        Me.GroupBox_LM_Areas.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.TabControl_LM_Area, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl_LM_Area.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel6.ResumeLayout(False)
        Me.TabControlPanel5.ResumeLayout(False)
        CType(Me.TabControl_LM_Level, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl_LM_Level.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        CType(Me.PictureBox_BGImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_LM_DefaultPositionYRotation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_LM_DefaultPositionAreaID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_LM_Areas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Button_LM_AddArea As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_AreaEditor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_RemoveArea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ListBoxAdv_LM_Areas As Publics.Controls.ItemListBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ButtonX_LM_LevelsMore As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem20 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem21 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem24 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem15 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Button_LM_AddNewLevel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem26 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ListBoxAdv_LM_Levels As Publics.Controls.ItemListBox
    Friend WithEvents TabControl_LM_Area As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx_LM_AreaBG As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents TextBoxX_LM_ShowMsgID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_LM_ShowMsgEnabled As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ColorPickerButton_LM_BackgroundColor As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX_LM_Enable2DCamera As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_LM_Music As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_LM_TerrainTyp As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_LM_EnvironmentEffects As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_LM_CameraPreset As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Button_LM_RemoveSpecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_AddSpecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_EditSpecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListViewEx_LM_Specials As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeaderA1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeaderA As ColumnHeader
    Friend WithEvents TabItem6 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonX_LM_ScrollTexEditor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_ImportModel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ExportModel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem_ExportVisualMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ExportCollisionMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControl_LM_Level As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents PictureBox_BGImage As PictureBox
    Friend WithEvents ComboBoxEx_LM_BGMode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_LM_LoadLevelBG As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SwitchButton_LM_ActSelector As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX57 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_LM_HardcodedCameraSettings As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Button_LM_SetUpStartPosition As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_LM_LevelBG As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NUD_LM_DefaultPositionYRotation As NumericUpDown
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NUD_LM_DefaultPositionAreaID As NumericUpDown
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonX_CustomObjects As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem_EditAreaLevelScript As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2_EditGeolayoutScript As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX_Area_CountOfTexAnimations As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX_Area_CountOfCustomObjects As DevComponents.DotNetBar.LabelX
    Friend WithEvents TableLayoutPanel_ObjectBankSelectorBoxes As TableLayoutPanel
    Friend WithEvents ButtonItem_ImportArea As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX_TargetLevel As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_UseGlobalObjectBank As DevComponents.DotNetBar.Controls.SwitchButton
End Class
