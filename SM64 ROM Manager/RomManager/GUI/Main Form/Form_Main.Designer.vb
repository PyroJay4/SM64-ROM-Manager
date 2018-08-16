<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.Button_G_SaveGameName = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX_G_Filename = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_G_Filesize = New DevComponents.DotNetBar.LabelX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_G_GameName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_LM_Enable2DCamera = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ComboBox_LM_Music = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_TerrainTyp = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBox_LM_EnvironmentEffects = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_CameraPreset = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonItem_ExportModel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem_ExportVisualMap = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ExportCollisionMap = New DevComponents.DotNetBar.ButtonItem()
        Me.Button_ImportModel = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem()
        Me.Button_LM_RemoveSpecial = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_EditSpecial = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_AddSpecial = New DevComponents.DotNetBar.ButtonX()
        Me.ListViewEx_LM_Specials = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeaderA1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button_LM_RemoveArea = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_AreaEditor = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_AddArea = New DevComponents.DotNetBar.ButtonX()
        Me.Button_LM_AddNewLevel = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.Button_LM_LoadLevelBG = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX57 = New DevComponents.DotNetBar.LabelX()
        Me.Button_LM_SetUpStartPosition = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_LM_LevelBG = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.NUD_LM_DefaultPositionYRotation = New System.Windows.Forms.NumericUpDown()
        Me.NUD_LM_DefaultPositionAreaID = New System.Windows.Forms.NumericUpDown()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LM_HardcodedCameraSettings = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LM_ActSelector = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_LM_OB0x09 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBox_LM_OB0x0D = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboBox_LM_OB0x0C = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ListBoxAdv_LM_ContentOfOB0x09 = New DevComponents.DotNetBar.ItemPanel()
        Me.ListBoxAdv_LM_ContentOfOB0x0D = New DevComponents.DotNetBar.ItemPanel()
        Me.ListBoxAdv_LM_ContentOfOB0x0C = New DevComponents.DotNetBar.ItemPanel()
        Me.Line_TM_Green = New DevComponents.DotNetBar.Controls.Line()
        Me.Line_TM_Warning1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line_TM_Warning2 = New DevComponents.DotNetBar.Controls.Line()
        Me.TextBoxX_TM_TextEditor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX_MS_SeqSize = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_MS_SequenceID = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX56 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_MS_OverwriteSizeRestrictions = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ComboBox_MS_NInst = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.Button_MS_ExtractSequence = New DevComponents.DotNetBar.ButtonX()
        Me.Line6 = New DevComponents.DotNetBar.Controls.Line()
        Me.Button_MS_ReplaceSequence = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_MS_Sequencename = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperTabControl_Main = New DevComponents.DotNetBar.TabControl()
        Me.SuperTabControlPanel_General = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ItemPanel_RecentFiles = New DevComponents.DotNetBar.ItemPanel()
        Me.GroupPanel6 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.SuperTabItem_General = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTabControlPanel_LM = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBox_LM_Areas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ListBoxAdv_LM_Areas = New Publics.Controls.ItemListBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ButtonX_LM_LevelsMore = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem20 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem21 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem24 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem15 = New DevComponents.DotNetBar.ButtonItem()
        Me.ListBoxAdv_LM_Levels = New Publics.Controls.ItemListBox()
        Me.TabControl_LM_Area = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx_LM_AreaBG = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.TextBoxX_LM_ShowMsgID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_LM_ShowMsgEnabled = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ColorPickerButton_LM_BackgroundColor = New DevComponents.DotNetBar.ColorPickerButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonX_LM_ScrollTexEditor = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem6 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControl_LM_Level = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.PictureBox_BGImage = New System.Windows.Forms.PictureBox()
        Me.ComboBoxEx_LM_BGMode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTabItem_LM = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTabControlPanel_MS = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupPanel12 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox_MS_SeqProperties = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox_MS_SelectedSequence = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel9 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ButtonX_MS_RemoveSequence = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_MS_AddSequence = New DevComponents.DotNetBar.ButtonX()
        Me.ListBoxAdv_MS_MusicSequences = New Publics.Controls.ItemListBox()
        Me.SuperTabItem_MS = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTabControlPanel_TM = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupPanel_TM_DialogProps = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx_TM_DialogPosY = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.IntegerInput_TM_DialogSize = New DevComponents.Editors.IntegerInput()
        Me.ComboBoxEx_TM_DialogPosX = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.TabStrip_TM_TableSelection = New DevComponents.DotNetBar.TabStrip()
        Me.LabelX_TM_BytesLeft = New DevComponents.DotNetBar.LabelX()
        Me.TabItem_TM_Dialogs = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem_TM_LevelNames = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem_TM_ActNames = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ListViewEx_TM_TableEntries = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuperTabItem_TM = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_SaveRom = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_LaunchROM = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem10 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem11 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem_ModelImporter = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem58 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem32 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem14 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_TrajectoryEditor = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem22 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Bar_Plugins = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem31 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem558 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem25 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Bar_EnableExpertMode = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem27 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem28 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem29 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem30 = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem12 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem23 = New DevComponents.DotNetBar.ButtonItem()
        Me.DotNetBarManager1 = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
        Me.MetroStatusBar1 = New DevComponents.DotNetBar.Metro.MetroStatusBar()
        Me.LabelItem_Status = New DevComponents.DotNetBar.LabelItem()
        CType(Me.NUD_LM_DefaultPositionYRotation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_LM_DefaultPositionAreaID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl_Main.SuspendLayout()
        Me.SuperTabControlPanel_General.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel6.SuspendLayout()
        Me.SuperTabControlPanel_LM.SuspendLayout()
        Me.GroupBox_LM_Areas.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.TabControl_LM_Area, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl_LM_Area.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        CType(Me.TabControl_LM_Level, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl_LM_Level.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.PictureBox_BGImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuperTabControlPanel_MS.SuspendLayout()
        Me.GroupPanel12.SuspendLayout()
        Me.GroupBox_MS_SeqProperties.SuspendLayout()
        Me.GroupBox_MS_SelectedSequence.SuspendLayout()
        Me.GroupPanel9.SuspendLayout()
        Me.SuperTabControlPanel_TM.SuspendLayout()
        Me.GroupPanel_TM_DialogProps.SuspendLayout()
        CType(Me.IntegerInput_TM_DialogSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabStrip_TM_TableSelection.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_G_SaveGameName
        '
        Me.Button_G_SaveGameName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_G_SaveGameName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_G_SaveGameName, "Button_G_SaveGameName")
        Me.Button_G_SaveGameName.FocusCuesEnabled = False
        Me.Button_G_SaveGameName.Name = "Button_G_SaveGameName"
        Me.Button_G_SaveGameName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX_G_Filename
        '
        Me.LabelX_G_Filename.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_G_Filename.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_G_Filename, "LabelX_G_Filename")
        Me.LabelX_G_Filename.Name = "LabelX_G_Filename"
        Me.LabelX_G_Filename.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX_G_Filesize
        '
        Me.LabelX_G_Filesize.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_G_Filesize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_G_Filesize, "LabelX_G_Filesize")
        Me.LabelX_G_Filesize.Name = "LabelX_G_Filesize"
        Me.LabelX_G_Filesize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX35
        '
        '
        '
        '
        Me.LabelX35.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX35, "LabelX35")
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX34
        '
        '
        '
        '
        Me.LabelX34.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX34, "LabelX34")
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TextBoxX_G_GameName
        '
        Me.TextBoxX_G_GameName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_G_GameName.Border.Class = "TextBoxBorder"
        Me.TextBoxX_G_GameName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_G_GameName.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_G_GameName.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_G_GameName, "TextBoxX_G_GameName")
        Me.TextBoxX_G_GameName.Name = "TextBoxX_G_GameName"
        Me.TextBoxX_G_GameName.PreventEnterBeep = True
        '
        'LabelX27
        '
        '
        '
        '
        Me.LabelX27.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX27, "LabelX27")
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        'Button_LM_RemoveSpecial
        '
        Me.Button_LM_RemoveSpecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_RemoveSpecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_RemoveSpecial, "Button_LM_RemoveSpecial")
        Me.Button_LM_RemoveSpecial.FocusCuesEnabled = False
        Me.Button_LM_RemoveSpecial.Name = "Button_LM_RemoveSpecial"
        Me.Button_LM_RemoveSpecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_RemoveSpecial.Symbol = "57676"
        Me.Button_LM_RemoveSpecial.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_LM_RemoveSpecial.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_RemoveSpecial.SymbolSize = 12.0!
        '
        'Button_LM_EditSpecial
        '
        Me.Button_LM_EditSpecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_EditSpecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_EditSpecial, "Button_LM_EditSpecial")
        Me.Button_LM_EditSpecial.FocusCuesEnabled = False
        Me.Button_LM_EditSpecial.Name = "Button_LM_EditSpecial"
        Me.Button_LM_EditSpecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_EditSpecial.Symbol = "57680"
        Me.Button_LM_EditSpecial.SymbolColor = System.Drawing.Color.Goldenrod
        Me.Button_LM_EditSpecial.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_EditSpecial.SymbolSize = 12.0!
        '
        'Button_LM_AddSpecial
        '
        Me.Button_LM_AddSpecial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AddSpecial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_AddSpecial.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_LM_AddSpecial, "Button_LM_AddSpecial")
        Me.Button_LM_AddSpecial.Name = "Button_LM_AddSpecial"
        Me.Button_LM_AddSpecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AddSpecial.Symbol = "57669"
        Me.Button_LM_AddSpecial.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_LM_AddSpecial.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AddSpecial.SymbolSize = 12.0!
        '
        'ListViewEx_LM_Specials
        '
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
        resources.ApplyResources(Me.ListViewEx_LM_Specials, "ListViewEx_LM_Specials")
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
        'Button_LM_RemoveArea
        '
        Me.Button_LM_RemoveArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_RemoveArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_RemoveArea, "Button_LM_RemoveArea")
        Me.Button_LM_RemoveArea.FocusCuesEnabled = False
        Me.Button_LM_RemoveArea.Name = "Button_LM_RemoveArea"
        Me.Button_LM_RemoveArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_RemoveArea.Symbol = "57676"
        Me.Button_LM_RemoveArea.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_LM_RemoveArea.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_RemoveArea.SymbolSize = 12.0!
        '
        'Button_LM_AreaEditor
        '
        Me.Button_LM_AreaEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AreaEditor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.Button_LM_AreaEditor, "Button_LM_AreaEditor")
        Me.Button_LM_AreaEditor.FocusCuesEnabled = False
        Me.Button_LM_AreaEditor.Name = "Button_LM_AreaEditor"
        Me.Button_LM_AreaEditor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AreaEditor.Symbol = "57680"
        Me.Button_LM_AreaEditor.SymbolColor = System.Drawing.Color.Goldenrod
        Me.Button_LM_AreaEditor.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AreaEditor.SymbolSize = 12.0!
        '
        'Button_LM_AddArea
        '
        Me.Button_LM_AddArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AddArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_AddArea.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_LM_AddArea, "Button_LM_AddArea")
        Me.Button_LM_AddArea.Name = "Button_LM_AddArea"
        Me.Button_LM_AddArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AddArea.Symbol = "57669"
        Me.Button_LM_AddArea.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_LM_AddArea.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AddArea.SymbolSize = 12.0!
        '
        'Button_LM_AddNewLevel
        '
        Me.Button_LM_AddNewLevel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_AddNewLevel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_AddNewLevel.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_LM_AddNewLevel, "Button_LM_AddNewLevel")
        Me.Button_LM_AddNewLevel.Name = "Button_LM_AddNewLevel"
        Me.Button_LM_AddNewLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_AddNewLevel.Symbol = "57669"
        Me.Button_LM_AddNewLevel.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button_LM_AddNewLevel.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_AddNewLevel.SymbolSize = 12.0!
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
        'Button_LM_LoadLevelBG
        '
        Me.Button_LM_LoadLevelBG.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_LoadLevelBG.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_LoadLevelBG.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_LM_LoadLevelBG, "Button_LM_LoadLevelBG")
        Me.Button_LM_LoadLevelBG.Name = "Button_LM_LoadLevelBG"
        Me.Button_LM_LoadLevelBG.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_LoadLevelBG.Symbol = "58055"
        Me.Button_LM_LoadLevelBG.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.Button_LM_LoadLevelBG.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.Button_LM_LoadLevelBG.SymbolSize = 12.0!
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
        'Button_LM_SetUpStartPosition
        '
        Me.Button_LM_SetUpStartPosition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_LM_SetUpStartPosition.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_LM_SetUpStartPosition.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_LM_SetUpStartPosition, "Button_LM_SetUpStartPosition")
        Me.Button_LM_SetUpStartPosition.Name = "Button_LM_SetUpStartPosition"
        Me.Button_LM_SetUpStartPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_LM_SetUpStartPosition.Symbol = ""
        Me.Button_LM_SetUpStartPosition.SymbolColor = System.Drawing.Color.Gray
        Me.Button_LM_SetUpStartPosition.SymbolSize = 12.0!
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
        'NUD_LM_DefaultPositionYRotation
        '
        resources.ApplyResources(Me.NUD_LM_DefaultPositionYRotation, "NUD_LM_DefaultPositionYRotation")
        Me.NUD_LM_DefaultPositionYRotation.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.NUD_LM_DefaultPositionYRotation.Minimum = New Decimal(New Integer() {359, 0, 0, -2147483648})
        Me.NUD_LM_DefaultPositionYRotation.Name = "NUD_LM_DefaultPositionYRotation"
        '
        'NUD_LM_DefaultPositionAreaID
        '
        resources.ApplyResources(Me.NUD_LM_DefaultPositionAreaID, "NUD_LM_DefaultPositionAreaID")
        Me.NUD_LM_DefaultPositionAreaID.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NUD_LM_DefaultPositionAreaID.Name = "NUD_LM_DefaultPositionAreaID"
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
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX31, "LabelX31")
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX31.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX30
        '
        Me.LabelX30.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX30, "LabelX30")
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX30.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX29
        '
        Me.LabelX29.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX29, "LabelX29")
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX29.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ComboBox_LM_OB0x09
        '
        Me.ComboBox_LM_OB0x09.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_OB0x09.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_OB0x09.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_OB0x09.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_OB0x09, "ComboBox_LM_OB0x09")
        Me.ComboBox_LM_OB0x09.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_OB0x09.Items"), resources.GetString("ComboBox_LM_OB0x09.Items1"), resources.GetString("ComboBox_LM_OB0x09.Items2"), resources.GetString("ComboBox_LM_OB0x09.Items3"), resources.GetString("ComboBox_LM_OB0x09.Items4"), resources.GetString("ComboBox_LM_OB0x09.Items5"), resources.GetString("ComboBox_LM_OB0x09.Items6"), resources.GetString("ComboBox_LM_OB0x09.Items7"), resources.GetString("ComboBox_LM_OB0x09.Items8"), resources.GetString("ComboBox_LM_OB0x09.Items9"), resources.GetString("ComboBox_LM_OB0x09.Items10"), resources.GetString("ComboBox_LM_OB0x09.Items11"), resources.GetString("ComboBox_LM_OB0x09.Items12"), resources.GetString("ComboBox_LM_OB0x09.Items13"), resources.GetString("ComboBox_LM_OB0x09.Items14"), resources.GetString("ComboBox_LM_OB0x09.Items15"), resources.GetString("ComboBox_LM_OB0x09.Items16"), resources.GetString("ComboBox_LM_OB0x09.Items17"), resources.GetString("ComboBox_LM_OB0x09.Items18"), resources.GetString("ComboBox_LM_OB0x09.Items19"), resources.GetString("ComboBox_LM_OB0x09.Items20"), resources.GetString("ComboBox_LM_OB0x09.Items21"), resources.GetString("ComboBox_LM_OB0x09.Items22"), resources.GetString("ComboBox_LM_OB0x09.Items23"), resources.GetString("ComboBox_LM_OB0x09.Items24"), resources.GetString("ComboBox_LM_OB0x09.Items25")})
        Me.ComboBox_LM_OB0x09.Name = "ComboBox_LM_OB0x09"
        Me.ComboBox_LM_OB0x09.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_OB0x0D
        '
        Me.ComboBox_LM_OB0x0D.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_OB0x0D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_OB0x0D.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_OB0x0D.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_OB0x0D, "ComboBox_LM_OB0x0D")
        Me.ComboBox_LM_OB0x0D.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_OB0x0D.Items"), resources.GetString("ComboBox_LM_OB0x0D.Items1"), resources.GetString("ComboBox_LM_OB0x0D.Items2"), resources.GetString("ComboBox_LM_OB0x0D.Items3"), resources.GetString("ComboBox_LM_OB0x0D.Items4"), resources.GetString("ComboBox_LM_OB0x0D.Items5"), resources.GetString("ComboBox_LM_OB0x0D.Items6")})
        Me.ComboBox_LM_OB0x0D.Name = "ComboBox_LM_OB0x0D"
        Me.ComboBox_LM_OB0x0D.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_LM_OB0x0C
        '
        Me.ComboBox_LM_OB0x0C.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_LM_OB0x0C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_LM_OB0x0C.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_LM_OB0x0C.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_LM_OB0x0C, "ComboBox_LM_OB0x0C")
        Me.ComboBox_LM_OB0x0C.Items.AddRange(New Object() {resources.GetString("ComboBox_LM_OB0x0C.Items"), resources.GetString("ComboBox_LM_OB0x0C.Items1"), resources.GetString("ComboBox_LM_OB0x0C.Items2"), resources.GetString("ComboBox_LM_OB0x0C.Items3"), resources.GetString("ComboBox_LM_OB0x0C.Items4"), resources.GetString("ComboBox_LM_OB0x0C.Items5"), resources.GetString("ComboBox_LM_OB0x0C.Items6"), resources.GetString("ComboBox_LM_OB0x0C.Items7"), resources.GetString("ComboBox_LM_OB0x0C.Items8"), resources.GetString("ComboBox_LM_OB0x0C.Items9"), resources.GetString("ComboBox_LM_OB0x0C.Items10"), resources.GetString("ComboBox_LM_OB0x0C.Items11")})
        Me.ComboBox_LM_OB0x0C.Name = "ComboBox_LM_OB0x0C"
        Me.ComboBox_LM_OB0x0C.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ListBoxAdv_LM_ContentOfOB0x09
        '
        resources.ApplyResources(Me.ListBoxAdv_LM_ContentOfOB0x09, "ListBoxAdv_LM_ContentOfOB0x09")
        '
        '
        '
        Me.ListBoxAdv_LM_ContentOfOB0x09.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_LM_ContentOfOB0x09.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_LM_ContentOfOB0x09.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_LM_ContentOfOB0x09.DragDropSupport = True
        Me.ListBoxAdv_LM_ContentOfOB0x09.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_LM_ContentOfOB0x09.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_LM_ContentOfOB0x09.Name = "ListBoxAdv_LM_ContentOfOB0x09"
        Me.ListBoxAdv_LM_ContentOfOB0x09.ReserveLeftSpace = False
        Me.ListBoxAdv_LM_ContentOfOB0x09.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ListBoxAdv_LM_ContentOfOB0x0D
        '
        resources.ApplyResources(Me.ListBoxAdv_LM_ContentOfOB0x0D, "ListBoxAdv_LM_ContentOfOB0x0D")
        '
        '
        '
        Me.ListBoxAdv_LM_ContentOfOB0x0D.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_LM_ContentOfOB0x0D.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_LM_ContentOfOB0x0D.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_LM_ContentOfOB0x0D.DragDropSupport = True
        Me.ListBoxAdv_LM_ContentOfOB0x0D.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_LM_ContentOfOB0x0D.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_LM_ContentOfOB0x0D.Name = "ListBoxAdv_LM_ContentOfOB0x0D"
        Me.ListBoxAdv_LM_ContentOfOB0x0D.ReserveLeftSpace = False
        Me.ListBoxAdv_LM_ContentOfOB0x0D.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ListBoxAdv_LM_ContentOfOB0x0C
        '
        resources.ApplyResources(Me.ListBoxAdv_LM_ContentOfOB0x0C, "ListBoxAdv_LM_ContentOfOB0x0C")
        '
        '
        '
        Me.ListBoxAdv_LM_ContentOfOB0x0C.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_LM_ContentOfOB0x0C.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_LM_ContentOfOB0x0C.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_LM_ContentOfOB0x0C.DragDropSupport = True
        Me.ListBoxAdv_LM_ContentOfOB0x0C.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_LM_ContentOfOB0x0C.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_LM_ContentOfOB0x0C.Name = "ListBoxAdv_LM_ContentOfOB0x0C"
        Me.ListBoxAdv_LM_ContentOfOB0x0C.ReserveLeftSpace = False
        Me.ListBoxAdv_LM_ContentOfOB0x0C.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Line_TM_Green
        '
        Me.Line_TM_Green.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line_TM_Green.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Line_TM_Green.ForeColor = System.Drawing.Color.YellowGreen
        resources.ApplyResources(Me.Line_TM_Green, "Line_TM_Green")
        Me.Line_TM_Green.Name = "Line_TM_Green"
        Me.Line_TM_Green.VerticalLine = True
        '
        'Line_TM_Warning1
        '
        Me.Line_TM_Warning1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line_TM_Warning1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Line_TM_Warning1.ForeColor = System.Drawing.Color.Orange
        resources.ApplyResources(Me.Line_TM_Warning1, "Line_TM_Warning1")
        Me.Line_TM_Warning1.Name = "Line_TM_Warning1"
        Me.Line_TM_Warning1.VerticalLine = True
        '
        'Line_TM_Warning2
        '
        Me.Line_TM_Warning2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line_TM_Warning2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Line_TM_Warning2.ForeColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Line_TM_Warning2, "Line_TM_Warning2")
        Me.Line_TM_Warning2.Name = "Line_TM_Warning2"
        Me.Line_TM_Warning2.VerticalLine = True
        '
        'TextBoxX_TM_TextEditor
        '
        Me.TextBoxX_TM_TextEditor.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_TM_TextEditor.Border.Class = "TextBoxBorder"
        Me.TextBoxX_TM_TextEditor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_TM_TextEditor.DisabledBackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.TextBoxX_TM_TextEditor, "TextBoxX_TM_TextEditor")
        Me.TextBoxX_TM_TextEditor.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_TM_TextEditor.Name = "TextBoxX_TM_TextEditor"
        Me.TextBoxX_TM_TextEditor.PreventEnterBeep = True
        Me.TextBoxX_TM_TextEditor.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        '
        'LabelX_MS_SeqSize
        '
        Me.LabelX_MS_SeqSize.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_MS_SeqSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_MS_SeqSize, "LabelX_MS_SeqSize")
        Me.LabelX_MS_SeqSize.Name = "LabelX_MS_SeqSize"
        Me.LabelX_MS_SeqSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX28, "LabelX28")
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX_MS_SequenceID
        '
        Me.LabelX_MS_SequenceID.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_MS_SequenceID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_MS_SequenceID, "LabelX_MS_SequenceID")
        Me.LabelX_MS_SequenceID.Name = "LabelX_MS_SequenceID"
        Me.LabelX_MS_SequenceID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX33
        '
        Me.LabelX33.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX33, "LabelX33")
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX56
        '
        Me.LabelX56.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX56, "LabelX56")
        Me.LabelX56.Name = "LabelX56"
        Me.LabelX56.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_MS_OverwriteSizeRestrictions
        '
        '
        '
        '
        Me.SwitchButton_MS_OverwriteSizeRestrictions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_MS_OverwriteSizeRestrictions.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_MS_OverwriteSizeRestrictions, "SwitchButton_MS_OverwriteSizeRestrictions")
        Me.SwitchButton_MS_OverwriteSizeRestrictions.Name = "SwitchButton_MS_OverwriteSizeRestrictions"
        Me.SwitchButton_MS_OverwriteSizeRestrictions.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_MS_OverwriteSizeRestrictions.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.SwitchWidth = 15
        '
        'ComboBox_MS_NInst
        '
        Me.ComboBox_MS_NInst.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_MS_NInst.DropDownHeight = 150
        Me.ComboBox_MS_NInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_MS_NInst.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_MS_NInst.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_MS_NInst, "ComboBox_MS_NInst")
        Me.ComboBox_MS_NInst.Items.AddRange(New Object() {resources.GetString("ComboBox_MS_NInst.Items"), resources.GetString("ComboBox_MS_NInst.Items1"), resources.GetString("ComboBox_MS_NInst.Items2"), resources.GetString("ComboBox_MS_NInst.Items3"), resources.GetString("ComboBox_MS_NInst.Items4"), resources.GetString("ComboBox_MS_NInst.Items5"), resources.GetString("ComboBox_MS_NInst.Items6"), resources.GetString("ComboBox_MS_NInst.Items7"), resources.GetString("ComboBox_MS_NInst.Items8"), resources.GetString("ComboBox_MS_NInst.Items9"), resources.GetString("ComboBox_MS_NInst.Items10"), resources.GetString("ComboBox_MS_NInst.Items11"), resources.GetString("ComboBox_MS_NInst.Items12"), resources.GetString("ComboBox_MS_NInst.Items13"), resources.GetString("ComboBox_MS_NInst.Items14"), resources.GetString("ComboBox_MS_NInst.Items15"), resources.GetString("ComboBox_MS_NInst.Items16"), resources.GetString("ComboBox_MS_NInst.Items17"), resources.GetString("ComboBox_MS_NInst.Items18"), resources.GetString("ComboBox_MS_NInst.Items19"), resources.GetString("ComboBox_MS_NInst.Items20"), resources.GetString("ComboBox_MS_NInst.Items21"), resources.GetString("ComboBox_MS_NInst.Items22"), resources.GetString("ComboBox_MS_NInst.Items23"), resources.GetString("ComboBox_MS_NInst.Items24"), resources.GetString("ComboBox_MS_NInst.Items25"), resources.GetString("ComboBox_MS_NInst.Items26"), resources.GetString("ComboBox_MS_NInst.Items27"), resources.GetString("ComboBox_MS_NInst.Items28"), resources.GetString("ComboBox_MS_NInst.Items29"), resources.GetString("ComboBox_MS_NInst.Items30"), resources.GetString("ComboBox_MS_NInst.Items31"), resources.GetString("ComboBox_MS_NInst.Items32"), resources.GetString("ComboBox_MS_NInst.Items33"), resources.GetString("ComboBox_MS_NInst.Items34"), resources.GetString("ComboBox_MS_NInst.Items35"), resources.GetString("ComboBox_MS_NInst.Items36"), resources.GetString("ComboBox_MS_NInst.Items37")})
        Me.ComboBox_MS_NInst.Name = "ComboBox_MS_NInst"
        Me.ComboBox_MS_NInst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Button_MS_ExtractSequence
        '
        Me.Button_MS_ExtractSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_MS_ExtractSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_MS_ExtractSequence.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_MS_ExtractSequence, "Button_MS_ExtractSequence")
        Me.Button_MS_ExtractSequence.Name = "Button_MS_ExtractSequence"
        Me.Button_MS_ExtractSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Line6
        '
        Me.Line6.BackColor = System.Drawing.Color.Transparent
        Me.Line6.ForeColor = System.Drawing.Color.Gainsboro
        resources.ApplyResources(Me.Line6, "Line6")
        Me.Line6.Name = "Line6"
        '
        'Button_MS_ReplaceSequence
        '
        Me.Button_MS_ReplaceSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_MS_ReplaceSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_MS_ReplaceSequence.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_MS_ReplaceSequence, "Button_MS_ReplaceSequence")
        Me.Button_MS_ReplaceSequence.Name = "Button_MS_ReplaceSequence"
        Me.Button_MS_ReplaceSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX32, "LabelX32")
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TextBoxX_MS_Sequencename
        '
        Me.TextBoxX_MS_Sequencename.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_MS_Sequencename.Border.Class = "TextBoxBorder"
        Me.TextBoxX_MS_Sequencename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_MS_Sequencename.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_MS_Sequencename.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_MS_Sequencename, "TextBoxX_MS_Sequencename")
        Me.TextBoxX_MS_Sequencename.Name = "TextBoxX_MS_Sequencename"
        Me.TextBoxX_MS_Sequencename.PreventEnterBeep = True
        '
        'SuperTabControl_Main
        '
        Me.SuperTabControl_Main.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperTabControl_Main.CanReorderTabs = False
        Me.SuperTabControl_Main.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right
        Me.SuperTabControl_Main.Controls.Add(Me.SuperTabControlPanel_General)
        Me.SuperTabControl_Main.Controls.Add(Me.SuperTabControlPanel_LM)
        Me.SuperTabControl_Main.Controls.Add(Me.SuperTabControlPanel_MS)
        Me.SuperTabControl_Main.Controls.Add(Me.SuperTabControlPanel_TM)
        resources.ApplyResources(Me.SuperTabControl_Main, "SuperTabControl_Main")
        Me.SuperTabControl_Main.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl_Main.Name = "SuperTabControl_Main"
        Me.SuperTabControl_Main.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl_Main.SelectedTabIndex = 0
        Me.SuperTabControl_Main.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.SuperTabControl_Main.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.SuperTabControl_Main.Tabs.Add(Me.SuperTabItem_General)
        Me.SuperTabControl_Main.Tabs.Add(Me.SuperTabItem_LM)
        Me.SuperTabControl_Main.Tabs.Add(Me.SuperTabItem_TM)
        Me.SuperTabControl_Main.Tabs.Add(Me.SuperTabItem_MS)
        '
        'SuperTabControlPanel_General
        '
        Me.SuperTabControlPanel_General.Controls.Add(Me.GroupPanel2)
        Me.SuperTabControlPanel_General.Controls.Add(Me.GroupPanel6)
        Me.SuperTabControlPanel_General.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.SuperTabControlPanel_General, "SuperTabControlPanel_General")
        Me.SuperTabControlPanel_General.Name = "SuperTabControlPanel_General"
        Me.SuperTabControlPanel_General.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperTabControlPanel_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SuperTabControlPanel_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.SuperTabControlPanel_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SuperTabControlPanel_General.Style.GradientAngle = 90
        Me.SuperTabControlPanel_General.TabItem = Me.SuperTabItem_General
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ItemPanel_RecentFiles)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel2, "GroupPanel2")
        Me.GroupPanel2.Name = "GroupPanel2"
        '
        '
        '
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemPanel_RecentFiles
        '
        resources.ApplyResources(Me.ItemPanel_RecentFiles, "ItemPanel_RecentFiles")
        '
        '
        '
        Me.ItemPanel_RecentFiles.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel_RecentFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel_RecentFiles.ContainerControlProcessDialogKey = True
        Me.ItemPanel_RecentFiles.DragDropSupport = True
        Me.ItemPanel_RecentFiles.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel_RecentFiles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel_RecentFiles.Name = "ItemPanel_RecentFiles"
        Me.ItemPanel_RecentFiles.ReserveLeftSpace = False
        Me.ItemPanel_RecentFiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'GroupPanel6
        '
        Me.GroupPanel6.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel6.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel6.Controls.Add(Me.Button_G_SaveGameName)
        Me.GroupPanel6.Controls.Add(Me.LabelX27)
        Me.GroupPanel6.Controls.Add(Me.LabelX_G_Filename)
        Me.GroupPanel6.Controls.Add(Me.TextBoxX_G_GameName)
        Me.GroupPanel6.Controls.Add(Me.LabelX_G_Filesize)
        Me.GroupPanel6.Controls.Add(Me.LabelX34)
        Me.GroupPanel6.Controls.Add(Me.LabelX35)
        Me.GroupPanel6.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel6, "GroupPanel6")
        Me.GroupPanel6.Name = "GroupPanel6"
        '
        '
        '
        Me.GroupPanel6.Style.BackColorGradientAngle = 90
        Me.GroupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderBottomWidth = 1
        Me.GroupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderLeftWidth = 1
        Me.GroupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderRightWidth = 1
        Me.GroupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderTopWidth = 1
        Me.GroupPanel6.Style.CornerDiameter = 4
        Me.GroupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'SuperTabItem_General
        '
        Me.SuperTabItem_General.AttachedControl = Me.SuperTabControlPanel_General
        Me.SuperTabItem_General.CloseButtonVisible = False
        Me.SuperTabItem_General.Name = "SuperTabItem_General"
        resources.ApplyResources(Me.SuperTabItem_General, "SuperTabItem_General")
        '
        'SuperTabControlPanel_LM
        '
        Me.SuperTabControlPanel_LM.Controls.Add(Me.GroupBox_LM_Areas)
        Me.SuperTabControlPanel_LM.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel_LM.Controls.Add(Me.TabControl_LM_Area)
        Me.SuperTabControlPanel_LM.Controls.Add(Me.TabControl_LM_Level)
        Me.SuperTabControlPanel_LM.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.SuperTabControlPanel_LM, "SuperTabControlPanel_LM")
        Me.SuperTabControlPanel_LM.Name = "SuperTabControlPanel_LM"
        Me.SuperTabControlPanel_LM.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperTabControlPanel_LM.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SuperTabControlPanel_LM.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.SuperTabControlPanel_LM.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SuperTabControlPanel_LM.Style.GradientAngle = 90
        Me.SuperTabControlPanel_LM.TabItem = Me.SuperTabItem_LM
        '
        'GroupBox_LM_Areas
        '
        Me.GroupBox_LM_Areas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox_LM_Areas.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupBox_LM_Areas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupBox_LM_Areas.Controls.Add(Me.Button_LM_RemoveArea)
        Me.GroupBox_LM_Areas.Controls.Add(Me.Button_LM_AddArea)
        Me.GroupBox_LM_Areas.Controls.Add(Me.Button_LM_AreaEditor)
        Me.GroupBox_LM_Areas.Controls.Add(Me.ListBoxAdv_LM_Areas)
        Me.GroupBox_LM_Areas.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupBox_LM_Areas, "GroupBox_LM_Areas")
        Me.GroupBox_LM_Areas.Name = "GroupBox_LM_Areas"
        '
        '
        '
        Me.GroupBox_LM_Areas.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupBox_LM_Areas.Style.BackColorGradientAngle = 90
        Me.GroupBox_LM_Areas.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
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
        Me.GroupBox_LM_Areas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
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
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
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
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
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
        Me.ButtonX_LM_LevelsMore.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem20, Me.ButtonItem19, Me.ButtonItem21, Me.ButtonItem24, Me.ButtonItem15})
        Me.ButtonX_LM_LevelsMore.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX_LM_LevelsMore.SymbolSize = 12.0!
        '
        'ButtonItem20
        '
        Me.ButtonItem20.GlobalItem = False
        Me.ButtonItem20.Name = "ButtonItem20"
        Me.ButtonItem20.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem20, "ButtonItem20")
        '
        'ButtonItem19
        '
        Me.ButtonItem19.GlobalItem = False
        Me.ButtonItem19.Name = "ButtonItem19"
        Me.ButtonItem19.Symbol = "57676"
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
        'ButtonItem24
        '
        Me.ButtonItem24.BeginGroup = True
        Me.ButtonItem24.GlobalItem = False
        Me.ButtonItem24.Name = "ButtonItem24"
        resources.ApplyResources(Me.ButtonItem24, "ButtonItem24")
        '
        'ButtonItem15
        '
        Me.ButtonItem15.BeginGroup = True
        Me.ButtonItem15.GlobalItem = False
        Me.ButtonItem15.Name = "ButtonItem15"
        resources.ApplyResources(Me.ButtonItem15, "ButtonItem15")
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
        Me.TabControl_LM_Area.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl_LM_Area.CanReorderTabs = False
        Me.TabControl_LM_Area.Controls.Add(Me.TabControlPanel4)
        Me.TabControl_LM_Area.Controls.Add(Me.TabControlPanel5)
        Me.TabControl_LM_Area.Controls.Add(Me.TabControlPanel6)
        resources.ApplyResources(Me.TabControl_LM_Area, "TabControl_LM_Area")
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
        Me.TabControlPanel4.Controls.Add(Me.ColorPickerButton_LM_BackgroundColor)
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
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel4, "TabControlPanel4")
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
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
        'ColorPickerButton_LM_BackgroundColor
        '
        Me.ColorPickerButton_LM_BackgroundColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ColorPickerButton_LM_BackgroundColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ColorPickerButton_LM_BackgroundColor.FocusCuesEnabled = False
        Me.ColorPickerButton_LM_BackgroundColor.Image = CType(resources.GetObject("ColorPickerButton_LM_BackgroundColor.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.ColorPickerButton_LM_BackgroundColor, "ColorPickerButton_LM_BackgroundColor")
        Me.ColorPickerButton_LM_BackgroundColor.Name = "ColorPickerButton_LM_BackgroundColor"
        Me.ColorPickerButton_LM_BackgroundColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.ColorPickerButton_LM_BackgroundColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.Name = "TabItem4"
        resources.ApplyResources(Me.TabItem4, "TabItem4")
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.ButtonX_LM_ScrollTexEditor)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX3)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX1)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX2)
        Me.TabControlPanel5.Controls.Add(Me.Button_ImportModel)
        Me.TabControlPanel5.Controls.Add(Me.ButtonItem_ExportModel)
        Me.TabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel5, "TabControlPanel5")
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabItem = Me.TabItem5
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
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX3, "ButtonX3")
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX2, "ButtonX2")
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel5
        Me.TabItem5.Name = "TabItem5"
        resources.ApplyResources(Me.TabItem5, "TabItem5")
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
        Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabItem = Me.TabItem6
        '
        'TabItem6
        '
        Me.TabItem6.AttachedControl = Me.TabControlPanel6
        Me.TabItem6.Name = "TabItem6"
        resources.ApplyResources(Me.TabItem6, "TabItem6")
        '
        'TabControl_LM_Level
        '
        Me.TabControl_LM_Level.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl_LM_Level.CanReorderTabs = False
        Me.TabControl_LM_Level.Controls.Add(Me.TabControlPanel1)
        Me.TabControl_LM_Level.Controls.Add(Me.TabControlPanel2)
        resources.ApplyResources(Me.TabControl_LM_Level, "TabControl_LM_Level")
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
        Me.TabControlPanel1.Controls.Add(Me.PictureBox_BGImage)
        Me.TabControlPanel1.Controls.Add(Me.ComboBoxEx_LM_BGMode)
        Me.TabControlPanel1.Controls.Add(Me.LabelX15)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.Button_LM_LoadLevelBG)
        Me.TabControlPanel1.Controls.Add(Me.SwitchButton_LM_ActSelector)
        Me.TabControlPanel1.Controls.Add(Me.LabelX57)
        Me.TabControlPanel1.Controls.Add(Me.SwitchButton_LM_HardcodedCameraSettings)
        Me.TabControlPanel1.Controls.Add(Me.Button_LM_SetUpStartPosition)
        Me.TabControlPanel1.Controls.Add(Me.LabelX4)
        Me.TabControlPanel1.Controls.Add(Me.ComboBox_LM_LevelBG)
        Me.TabControlPanel1.Controls.Add(Me.LabelX24)
        Me.TabControlPanel1.Controls.Add(Me.NUD_LM_DefaultPositionYRotation)
        Me.TabControlPanel1.Controls.Add(Me.LabelX25)
        Me.TabControlPanel1.Controls.Add(Me.NUD_LM_DefaultPositionAreaID)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel1, "TabControlPanel1")
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabItem = Me.TabItem1
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
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        resources.ApplyResources(Me.TabItem1, "TabItem1")
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.LabelX31)
        Me.TabControlPanel2.Controls.Add(Me.ComboBox_LM_OB0x0C)
        Me.TabControlPanel2.Controls.Add(Me.LabelX30)
        Me.TabControlPanel2.Controls.Add(Me.ListBoxAdv_LM_ContentOfOB0x0C)
        Me.TabControlPanel2.Controls.Add(Me.LabelX29)
        Me.TabControlPanel2.Controls.Add(Me.ListBoxAdv_LM_ContentOfOB0x0D)
        Me.TabControlPanel2.Controls.Add(Me.ComboBox_LM_OB0x09)
        Me.TabControlPanel2.Controls.Add(Me.ListBoxAdv_LM_ContentOfOB0x09)
        Me.TabControlPanel2.Controls.Add(Me.ComboBox_LM_OB0x0D)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel2, "TabControlPanel2")
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        resources.ApplyResources(Me.TabItem2, "TabItem2")
        '
        'SuperTabItem_LM
        '
        Me.SuperTabItem_LM.AttachedControl = Me.SuperTabControlPanel_LM
        Me.SuperTabItem_LM.Name = "SuperTabItem_LM"
        resources.ApplyResources(Me.SuperTabItem_LM, "SuperTabItem_LM")
        '
        'SuperTabControlPanel_MS
        '
        Me.SuperTabControlPanel_MS.Controls.Add(Me.GroupPanel12)
        Me.SuperTabControlPanel_MS.Controls.Add(Me.GroupBox_MS_SeqProperties)
        Me.SuperTabControlPanel_MS.Controls.Add(Me.GroupBox_MS_SelectedSequence)
        Me.SuperTabControlPanel_MS.Controls.Add(Me.GroupPanel9)
        Me.SuperTabControlPanel_MS.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.SuperTabControlPanel_MS, "SuperTabControlPanel_MS")
        Me.SuperTabControlPanel_MS.Name = "SuperTabControlPanel_MS"
        Me.SuperTabControlPanel_MS.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperTabControlPanel_MS.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SuperTabControlPanel_MS.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.SuperTabControlPanel_MS.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SuperTabControlPanel_MS.Style.GradientAngle = 90
        Me.SuperTabControlPanel_MS.TabItem = Me.SuperTabItem_MS
        '
        'GroupPanel12
        '
        Me.GroupPanel12.BackColor = System.Drawing.Color.White
        Me.GroupPanel12.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel12.Controls.Add(Me.LabelX56)
        Me.GroupPanel12.Controls.Add(Me.SwitchButton_MS_OverwriteSizeRestrictions)
        Me.GroupPanel12.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel12, "GroupPanel12")
        Me.GroupPanel12.Name = "GroupPanel12"
        '
        '
        '
        Me.GroupPanel12.Style.BackColorGradientAngle = 90
        Me.GroupPanel12.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderBottomWidth = 1
        Me.GroupPanel12.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel12.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderLeftWidth = 1
        Me.GroupPanel12.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderRightWidth = 1
        Me.GroupPanel12.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderTopWidth = 1
        Me.GroupPanel12.Style.CornerDiameter = 4
        Me.GroupPanel12.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel12.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel12.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel12.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel12.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel12.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'GroupBox_MS_SeqProperties
        '
        Me.GroupBox_MS_SeqProperties.BackColor = System.Drawing.Color.White
        Me.GroupBox_MS_SeqProperties.CanvasColor = System.Drawing.Color.Empty
        Me.GroupBox_MS_SeqProperties.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX_MS_SeqSize)
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX33)
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX28)
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX_MS_SequenceID)
        Me.GroupBox_MS_SeqProperties.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupBox_MS_SeqProperties, "GroupBox_MS_SeqProperties")
        Me.GroupBox_MS_SeqProperties.Name = "GroupBox_MS_SeqProperties"
        '
        '
        '
        Me.GroupBox_MS_SeqProperties.Style.BackColorGradientAngle = 90
        Me.GroupBox_MS_SeqProperties.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderBottomWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupBox_MS_SeqProperties.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderLeftWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderRightWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderTopWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.CornerDiameter = 4
        Me.GroupBox_MS_SeqProperties.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupBox_MS_SeqProperties.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupBox_MS_SeqProperties.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupBox_MS_SeqProperties.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupBox_MS_SeqProperties.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupBox_MS_SeqProperties.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'GroupBox_MS_SelectedSequence
        '
        Me.GroupBox_MS_SelectedSequence.BackColor = System.Drawing.Color.White
        Me.GroupBox_MS_SelectedSequence.CanvasColor = System.Drawing.Color.Empty
        Me.GroupBox_MS_SelectedSequence.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.ComboBox_MS_NInst)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.LabelX32)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.LabelX5)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.TextBoxX_MS_Sequencename)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.Button_MS_ExtractSequence)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.Button_MS_ReplaceSequence)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.Line6)
        Me.GroupBox_MS_SelectedSequence.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupBox_MS_SelectedSequence, "GroupBox_MS_SelectedSequence")
        Me.GroupBox_MS_SelectedSequence.Name = "GroupBox_MS_SelectedSequence"
        '
        '
        '
        Me.GroupBox_MS_SelectedSequence.Style.BackColorGradientAngle = 90
        Me.GroupBox_MS_SelectedSequence.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderBottomWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupBox_MS_SelectedSequence.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderLeftWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderRightWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderTopWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.CornerDiameter = 4
        Me.GroupBox_MS_SelectedSequence.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupBox_MS_SelectedSequence.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupBox_MS_SelectedSequence.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupBox_MS_SelectedSequence.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupBox_MS_SelectedSequence.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupBox_MS_SelectedSequence.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'GroupPanel9
        '
        Me.GroupPanel9.BackColor = System.Drawing.Color.White
        Me.GroupPanel9.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel9.Controls.Add(Me.ButtonX_MS_RemoveSequence)
        Me.GroupPanel9.Controls.Add(Me.ButtonX_MS_AddSequence)
        Me.GroupPanel9.Controls.Add(Me.ListBoxAdv_MS_MusicSequences)
        Me.GroupPanel9.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel9, "GroupPanel9")
        Me.GroupPanel9.Name = "GroupPanel9"
        '
        '
        '
        Me.GroupPanel9.Style.BackColorGradientAngle = 90
        Me.GroupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderBottomWidth = 1
        Me.GroupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderLeftWidth = 1
        Me.GroupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderRightWidth = 1
        Me.GroupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderTopWidth = 1
        Me.GroupPanel9.Style.CornerDiameter = 4
        Me.GroupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonX_MS_RemoveSequence
        '
        Me.ButtonX_MS_RemoveSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_MS_RemoveSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_MS_RemoveSequence, "ButtonX_MS_RemoveSequence")
        Me.ButtonX_MS_RemoveSequence.FocusCuesEnabled = False
        Me.ButtonX_MS_RemoveSequence.Name = "ButtonX_MS_RemoveSequence"
        Me.ButtonX_MS_RemoveSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_MS_RemoveSequence.Symbol = "57676"
        Me.ButtonX_MS_RemoveSequence.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX_MS_RemoveSequence.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_MS_RemoveSequence.SymbolSize = 12.0!
        '
        'ButtonX_MS_AddSequence
        '
        Me.ButtonX_MS_AddSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_MS_AddSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_MS_AddSequence.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_MS_AddSequence, "ButtonX_MS_AddSequence")
        Me.ButtonX_MS_AddSequence.Name = "ButtonX_MS_AddSequence"
        Me.ButtonX_MS_AddSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_MS_AddSequence.Symbol = "57669"
        Me.ButtonX_MS_AddSequence.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_MS_AddSequence.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_MS_AddSequence.SymbolSize = 12.0!
        '
        'ListBoxAdv_MS_MusicSequences
        '
        resources.ApplyResources(Me.ListBoxAdv_MS_MusicSequences, "ListBoxAdv_MS_MusicSequences")
        '
        '
        '
        Me.ListBoxAdv_MS_MusicSequences.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_MS_MusicSequences.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_MS_MusicSequences.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_MS_MusicSequences.DragDropSupport = True
        Me.ListBoxAdv_MS_MusicSequences.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_MS_MusicSequences.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_MS_MusicSequences.Name = "ListBoxAdv_MS_MusicSequences"
        Me.ListBoxAdv_MS_MusicSequences.ReserveLeftSpace = False
        Me.ListBoxAdv_MS_MusicSequences.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SuperTabItem_MS
        '
        Me.SuperTabItem_MS.AttachedControl = Me.SuperTabControlPanel_MS
        Me.SuperTabItem_MS.Name = "SuperTabItem_MS"
        resources.ApplyResources(Me.SuperTabItem_MS, "SuperTabItem_MS")
        '
        'SuperTabControlPanel_TM
        '
        Me.SuperTabControlPanel_TM.Controls.Add(Me.GroupPanel_TM_DialogProps)
        Me.SuperTabControlPanel_TM.Controls.Add(Me.TabStrip_TM_TableSelection)
        Me.SuperTabControlPanel_TM.Controls.Add(Me.ListViewEx_TM_TableEntries)
        Me.SuperTabControlPanel_TM.Controls.Add(Me.Line_TM_Green)
        Me.SuperTabControlPanel_TM.Controls.Add(Me.Line_TM_Warning1)
        Me.SuperTabControlPanel_TM.Controls.Add(Me.Line_TM_Warning2)
        Me.SuperTabControlPanel_TM.Controls.Add(Me.TextBoxX_TM_TextEditor)
        Me.SuperTabControlPanel_TM.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.SuperTabControlPanel_TM, "SuperTabControlPanel_TM")
        Me.SuperTabControlPanel_TM.Name = "SuperTabControlPanel_TM"
        Me.SuperTabControlPanel_TM.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SuperTabControlPanel_TM.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.SuperTabControlPanel_TM.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.SuperTabControlPanel_TM.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.SuperTabControlPanel_TM.Style.GradientAngle = 90
        Me.SuperTabControlPanel_TM.TabItem = Me.SuperTabItem_TM
        '
        'GroupPanel_TM_DialogProps
        '
        Me.GroupPanel_TM_DialogProps.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel_TM_DialogProps.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel_TM_DialogProps.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel_TM_DialogProps.Controls.Add(Me.LabelX22)
        Me.GroupPanel_TM_DialogProps.Controls.Add(Me.LabelX21)
        Me.GroupPanel_TM_DialogProps.Controls.Add(Me.ComboBoxEx_TM_DialogPosY)
        Me.GroupPanel_TM_DialogProps.Controls.Add(Me.IntegerInput_TM_DialogSize)
        Me.GroupPanel_TM_DialogProps.Controls.Add(Me.ComboBoxEx_TM_DialogPosX)
        Me.GroupPanel_TM_DialogProps.Controls.Add(Me.LabelX18)
        Me.GroupPanel_TM_DialogProps.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel_TM_DialogProps, "GroupPanel_TM_DialogProps")
        Me.GroupPanel_TM_DialogProps.Name = "GroupPanel_TM_DialogProps"
        '
        '
        '
        Me.GroupPanel_TM_DialogProps.Style.BackColorGradientAngle = 90
        Me.GroupPanel_TM_DialogProps.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel_TM_DialogProps.Style.BorderBottomWidth = 1
        Me.GroupPanel_TM_DialogProps.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel_TM_DialogProps.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel_TM_DialogProps.Style.BorderLeftWidth = 1
        Me.GroupPanel_TM_DialogProps.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel_TM_DialogProps.Style.BorderRightWidth = 1
        Me.GroupPanel_TM_DialogProps.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel_TM_DialogProps.Style.BorderTopWidth = 1
        Me.GroupPanel_TM_DialogProps.Style.CornerDiameter = 4
        Me.GroupPanel_TM_DialogProps.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel_TM_DialogProps.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel_TM_DialogProps.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel_TM_DialogProps.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel_TM_DialogProps.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel_TM_DialogProps.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX22, "LabelX22")
        Me.LabelX22.Name = "LabelX22"
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX21, "LabelX21")
        Me.LabelX21.Name = "LabelX21"
        '
        'ComboBoxEx_TM_DialogPosY
        '
        Me.ComboBoxEx_TM_DialogPosY.DisplayMember = "Text"
        Me.ComboBoxEx_TM_DialogPosY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_TM_DialogPosY.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_TM_DialogPosY.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx_TM_DialogPosY, "ComboBoxEx_TM_DialogPosY")
        Me.ComboBoxEx_TM_DialogPosY.Items.AddRange(New Object() {Me.ComboItem10, Me.ComboItem8})
        Me.ComboBoxEx_TM_DialogPosY.Name = "ComboBoxEx_TM_DialogPosY"
        Me.ComboBoxEx_TM_DialogPosY.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboItem10
        '
        resources.ApplyResources(Me.ComboItem10, "ComboItem10")
        '
        'ComboItem8
        '
        resources.ApplyResources(Me.ComboItem8, "ComboItem8")
        '
        'IntegerInput_TM_DialogSize
        '
        '
        '
        '
        Me.IntegerInput_TM_DialogSize.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_TM_DialogSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_TM_DialogSize.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_TM_DialogSize, "IntegerInput_TM_DialogSize")
        Me.IntegerInput_TM_DialogSize.MaxValue = 255
        Me.IntegerInput_TM_DialogSize.MinValue = 1
        Me.IntegerInput_TM_DialogSize.Name = "IntegerInput_TM_DialogSize"
        Me.IntegerInput_TM_DialogSize.ShowUpDown = True
        Me.IntegerInput_TM_DialogSize.Value = 1
        '
        'ComboBoxEx_TM_DialogPosX
        '
        Me.ComboBoxEx_TM_DialogPosX.DisplayMember = "Text"
        Me.ComboBoxEx_TM_DialogPosX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_TM_DialogPosX.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_TM_DialogPosX.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx_TM_DialogPosX, "ComboBoxEx_TM_DialogPosX")
        Me.ComboBoxEx_TM_DialogPosX.Items.AddRange(New Object() {Me.ComboItem5, Me.ComboItem6, Me.ComboItem7})
        Me.ComboBoxEx_TM_DialogPosX.Name = "ComboBoxEx_TM_DialogPosX"
        Me.ComboBoxEx_TM_DialogPosX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboItem5
        '
        resources.ApplyResources(Me.ComboItem5, "ComboItem5")
        '
        'ComboItem6
        '
        resources.ApplyResources(Me.ComboItem6, "ComboItem6")
        '
        'ComboItem7
        '
        resources.ApplyResources(Me.ComboItem7, "ComboItem7")
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX18, "LabelX18")
        Me.LabelX18.Name = "LabelX18"
        '
        'TabStrip_TM_TableSelection
        '
        Me.TabStrip_TM_TableSelection.AutoSelectAttachedControl = True
        Me.TabStrip_TM_TableSelection.CanReorderTabs = False
        Me.TabStrip_TM_TableSelection.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right
        Me.TabStrip_TM_TableSelection.CloseButtonVisible = True
        Me.TabStrip_TM_TableSelection.Controls.Add(Me.LabelX_TM_BytesLeft)
        Me.TabStrip_TM_TableSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabStrip_TM_TableSelection.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TabStrip_TM_TableSelection, "TabStrip_TM_TableSelection")
        Me.TabStrip_TM_TableSelection.Name = "TabStrip_TM_TableSelection"
        Me.TabStrip_TM_TableSelection.SelectedTab = Me.TabItem_TM_Dialogs
        Me.TabStrip_TM_TableSelection.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabStrip_TM_TableSelection.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.TabStrip_TM_TableSelection.Tabs.Add(Me.TabItem_TM_Dialogs)
        Me.TabStrip_TM_TableSelection.Tabs.Add(Me.TabItem_TM_LevelNames)
        Me.TabStrip_TM_TableSelection.Tabs.Add(Me.TabItem_TM_ActNames)
        '
        'LabelX_TM_BytesLeft
        '
        Me.LabelX_TM_BytesLeft.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_TM_BytesLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_TM_BytesLeft, "LabelX_TM_BytesLeft")
        Me.LabelX_TM_BytesLeft.Name = "LabelX_TM_BytesLeft"
        Me.LabelX_TM_BytesLeft.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'TabItem_TM_Dialogs
        '
        Me.TabItem_TM_Dialogs.Name = "TabItem_TM_Dialogs"
        resources.ApplyResources(Me.TabItem_TM_Dialogs, "TabItem_TM_Dialogs")
        '
        'TabItem_TM_LevelNames
        '
        Me.TabItem_TM_LevelNames.Name = "TabItem_TM_LevelNames"
        resources.ApplyResources(Me.TabItem_TM_LevelNames, "TabItem_TM_LevelNames")
        '
        'TabItem_TM_ActNames
        '
        Me.TabItem_TM_ActNames.Name = "TabItem_TM_ActNames"
        resources.ApplyResources(Me.TabItem_TM_ActNames, "TabItem_TM_ActNames")
        '
        'ListViewEx_TM_TableEntries
        '
        Me.ListViewEx_TM_TableEntries.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx_TM_TableEntries.Border.Class = "ListViewBorder"
        Me.ListViewEx_TM_TableEntries.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx_TM_TableEntries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.ListViewEx_TM_TableEntries.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx_TM_TableEntries.FocusCuesEnabled = False
        Me.ListViewEx_TM_TableEntries.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx_TM_TableEntries.FullRowSelect = True
        Me.ListViewEx_TM_TableEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEx_TM_TableEntries.HideSelection = False
        resources.ApplyResources(Me.ListViewEx_TM_TableEntries, "ListViewEx_TM_TableEntries")
        Me.ListViewEx_TM_TableEntries.Name = "ListViewEx_TM_TableEntries"
        Me.ListViewEx_TM_TableEntries.UseCompatibleStateImageBehavior = False
        Me.ListViewEx_TM_TableEntries.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader13
        '
        resources.ApplyResources(Me.ColumnHeader13, "ColumnHeader13")
        '
        'ColumnHeader14
        '
        resources.ApplyResources(Me.ColumnHeader14, "ColumnHeader14")
        '
        'SuperTabItem_TM
        '
        Me.SuperTabItem_TM.AttachedControl = Me.SuperTabControlPanel_TM
        Me.SuperTabItem_TM.Name = "SuperTabItem_TM"
        resources.ApplyResources(Me.SuperTabItem_TM, "SuperTabItem_TM")
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.Name = "SuperTabItem2"
        resources.ApplyResources(Me.SuperTabItem2, "SuperTabItem2")
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.SuperTabControlPanel2, "SuperTabControlPanel2")
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(123, Byte), Integer)))
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3, Me.ButtonItem_SaveRom, Me.ButtonItem_LaunchROM, Me.ButtonItem6})
        resources.ApplyResources(Me.ButtonItem2, "ButtonItem2")
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlO)
        Me.ButtonItem3.Symbol = "58055"
        Me.ButtonItem3.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ButtonItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem3.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem3, "ButtonItem3")
        '
        'ButtonItem_SaveRom
        '
        Me.ButtonItem_SaveRom.Name = "ButtonItem_SaveRom"
        Me.ButtonItem_SaveRom.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS)
        Me.ButtonItem_SaveRom.Symbol = "57697"
        Me.ButtonItem_SaveRom.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_SaveRom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_SaveRom.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_SaveRom, "ButtonItem_SaveRom")
        '
        'ButtonItem_LaunchROM
        '
        Me.ButtonItem_LaunchROM.Name = "ButtonItem_LaunchROM"
        Me.ButtonItem_LaunchROM.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.ButtonItem_LaunchROM.Symbol = ""
        Me.ButtonItem_LaunchROM.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_LaunchROM.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_LaunchROM, "ButtonItem_LaunchROM")
        '
        'ButtonItem6
        '
        resources.ApplyResources(Me.ButtonItem6, "ButtonItem6")
        Me.ButtonItem6.BeginGroup = True
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Symbol = "59528"
        Me.ButtonItem6.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem6.SymbolSize = 12.0!
        '
        'ButtonItem7
        '
        Me.ButtonItem7.BeginGroup = True
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ButtonItem8, Me.ButtonItem10, Me.ButtonItem11, Me.LabelItem2, Me.ButtonItem_ModelImporter, Me.ButtonItem58, Me.ButtonItem17, Me.ButtonItem_TrajectoryEditor, Me.ButtonItem32, Me.ButtonItem14, Me.ButtonItem18})
        resources.ApplyResources(Me.ButtonItem7, "ButtonItem7")
        '
        'LabelItem1
        '
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        resources.ApplyResources(Me.LabelItem1, "LabelItem1")
        '
        'ButtonItem8
        '
        Me.ButtonItem8.Name = "ButtonItem8"
        resources.ApplyResources(Me.ButtonItem8, "ButtonItem8")
        '
        'ButtonItem10
        '
        Me.ButtonItem10.Name = "ButtonItem10"
        resources.ApplyResources(Me.ButtonItem10, "ButtonItem10")
        '
        'ButtonItem11
        '
        Me.ButtonItem11.Name = "ButtonItem11"
        resources.ApplyResources(Me.ButtonItem11, "ButtonItem11")
        '
        'LabelItem2
        '
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.PaddingBottom = 1
        Me.LabelItem2.PaddingLeft = 10
        Me.LabelItem2.PaddingTop = 1
        Me.LabelItem2.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        resources.ApplyResources(Me.LabelItem2, "LabelItem2")
        '
        'ButtonItem_ModelImporter
        '
        Me.ButtonItem_ModelImporter.Name = "ButtonItem_ModelImporter"
        resources.ApplyResources(Me.ButtonItem_ModelImporter, "ButtonItem_ModelImporter")
        '
        'ButtonItem58
        '
        Me.ButtonItem58.Name = "ButtonItem58"
        resources.ApplyResources(Me.ButtonItem58, "ButtonItem58")
        Me.ButtonItem58.Visible = False
        '
        'ButtonItem17
        '
        Me.ButtonItem17.Name = "ButtonItem17"
        resources.ApplyResources(Me.ButtonItem17, "ButtonItem17")
        '
        'ButtonItem32
        '
        Me.ButtonItem32.Enabled = False
        Me.ButtonItem32.Name = "ButtonItem32"
        resources.ApplyResources(Me.ButtonItem32, "ButtonItem32")
        '
        'ButtonItem14
        '
        Me.ButtonItem14.Enabled = False
        Me.ButtonItem14.Name = "ButtonItem14"
        resources.ApplyResources(Me.ButtonItem14, "ButtonItem14")
        '
        'ButtonItem_TrajectoryEditor
        '
        Me.ButtonItem_TrajectoryEditor.Name = "ButtonItem_TrajectoryEditor"
        resources.ApplyResources(Me.ButtonItem_TrajectoryEditor, "ButtonItem_TrajectoryEditor")
        '
        'ButtonItem18
        '
        Me.ButtonItem18.Enabled = False
        Me.ButtonItem18.Name = "ButtonItem18"
        resources.ApplyResources(Me.ButtonItem18, "ButtonItem18")
        '
        'ButtonItem22
        '
        Me.ButtonItem22.Name = "ButtonItem22"
        Me.ButtonItem22.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1, Me.ButtonItem4})
        resources.ApplyResources(Me.ButtonItem22, "ButtonItem22")
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Symbol = "T"
        Me.ButtonItem1.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem1, "ButtonItem1")
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Enabled = False
        Me.ButtonItem4.Name = "ButtonItem4"
        resources.ApplyResources(Me.ButtonItem4, "ButtonItem4")
        '
        'ButtonItem_Bar_Plugins
        '
        Me.ButtonItem_Bar_Plugins.BeginGroup = True
        Me.ButtonItem_Bar_Plugins.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Bar_Plugins.Name = "ButtonItem_Bar_Plugins"
        Me.ButtonItem_Bar_Plugins.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem31})
        Me.ButtonItem_Bar_Plugins.Symbol = ""
        Me.ButtonItem_Bar_Plugins.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_Bar_Plugins, "ButtonItem_Bar_Plugins")
        Me.ButtonItem_Bar_Plugins.Visible = False
        '
        'ButtonItem31
        '
        Me.ButtonItem31.Name = "ButtonItem31"
        resources.ApplyResources(Me.ButtonItem31, "ButtonItem31")
        '
        'ButtonItem558
        '
        Me.ButtonItem558.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem558.Name = "ButtonItem558"
        Me.ButtonItem558.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem25, Me.ButtonItem5, Me.ButtonItem_Bar_EnableExpertMode, Me.ButtonItem27, Me.ButtonItem28, Me.ButtonItem29, Me.ButtonItem30})
        Me.ButtonItem558.Symbol = ""
        Me.ButtonItem558.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem558.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem558, "ButtonItem558")
        '
        'ButtonItem25
        '
        Me.ButtonItem25.Name = "ButtonItem25"
        Me.ButtonItem25.Symbol = ""
        Me.ButtonItem25.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem25.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem25, "ButtonItem25")
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Symbol = ""
        Me.ButtonItem5.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem5.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem5, "ButtonItem5")
        '
        'ButtonItem_Bar_EnableExpertMode
        '
        Me.ButtonItem_Bar_EnableExpertMode.AutoCheckOnClick = True
        Me.ButtonItem_Bar_EnableExpertMode.BeginGroup = True
        Me.ButtonItem_Bar_EnableExpertMode.Name = "ButtonItem_Bar_EnableExpertMode"
        resources.ApplyResources(Me.ButtonItem_Bar_EnableExpertMode, "ButtonItem_Bar_EnableExpertMode")
        Me.ButtonItem_Bar_EnableExpertMode.Visible = False
        '
        'ButtonItem27
        '
        Me.ButtonItem27.BeginGroup = True
        Me.ButtonItem27.Name = "ButtonItem27"
        Me.ButtonItem27.Symbol = "59645"
        Me.ButtonItem27.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem27.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem27.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem27, "ButtonItem27")
        '
        'ButtonItem28
        '
        Me.ButtonItem28.Name = "ButtonItem28"
        resources.ApplyResources(Me.ButtonItem28, "ButtonItem28")
        '
        'ButtonItem29
        '
        Me.ButtonItem29.Name = "ButtonItem29"
        Me.ButtonItem29.Symbol = ""
        Me.ButtonItem29.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem29.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem29, "ButtonItem29")
        '
        'ButtonItem30
        '
        Me.ButtonItem30.Name = "ButtonItem30"
        Me.ButtonItem30.Symbol = "57345"
        Me.ButtonItem30.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem30.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem30.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem30, "ButtonItem30")
        '
        'Bar1
        '
        resources.ApplyResources(Me.Bar1, "Bar1")
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Bar1.AntiAlias = True
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem7, Me.ButtonItem22, Me.ButtonItem12, Me.ButtonItem_Bar_Plugins, Me.ButtonItem558})
        Me.Bar1.MenuBar = True
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabStop = False
        '
        'ButtonItem12
        '
        Me.ButtonItem12.Name = "ButtonItem12"
        Me.ButtonItem12.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem23})
        resources.ApplyResources(Me.ButtonItem12, "ButtonItem12")
        '
        'ButtonItem23
        '
        Me.ButtonItem23.Name = "ButtonItem23"
        Me.ButtonItem23.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9)
        resources.ApplyResources(Me.ButtonItem23, "ButtonItem23")
        '
        'DotNetBarManager1
        '
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins)
        Me.DotNetBarManager1.BottomDockSite = Me.DockSite4
        Me.DotNetBarManager1.EnableFullSizeDock = False
        Me.DotNetBarManager1.LeftDockSite = Me.DockSite1
        Me.DotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.DotNetBarManager1.ParentForm = Me
        Me.DotNetBarManager1.RightDockSite = Me.DockSite2
        Me.DotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.DotNetBarManager1.ToolbarBottomDockSite = Me.DockSite8
        Me.DotNetBarManager1.ToolbarLeftDockSite = Me.DockSite5
        Me.DotNetBarManager1.ToolbarRightDockSite = Me.DockSite6
        Me.DotNetBarManager1.ToolbarTopDockSite = Me.DockSite7
        Me.DotNetBarManager1.TopDockSite = Me.DockSite3
        '
        'DockSite4
        '
        Me.DockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite4, "DockSite4")
        Me.DockSite4.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite4.Name = "DockSite4"
        Me.DockSite4.TabStop = False
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite1, "DockSite1")
        Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.TabStop = False
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite2, "DockSite2")
        Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.TabStop = False
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite8, "DockSite8")
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.TabStop = False
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite5, "DockSite5")
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite6, "DockSite6")
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite7, "DockSite7")
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.TabStop = False
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me.DockSite3, "DockSite3")
        Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.TabStop = False
        '
        'MetroStatusBar1
        '
        '
        '
        '
        Me.MetroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroStatusBar1.ContainerControlProcessDialogKey = True
        resources.ApplyResources(Me.MetroStatusBar1, "MetroStatusBar1")
        Me.MetroStatusBar1.DragDropSupport = True
        Me.MetroStatusBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem_Status})
        Me.MetroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroStatusBar1.Name = "MetroStatusBar1"
        Me.MetroStatusBar1.ResizeHandleVisible = False
        '
        'LabelItem_Status
        '
        Me.LabelItem_Status.Name = "LabelItem_Status"
        resources.ApplyResources(Me.LabelItem_Status, "LabelItem_Status")
        '
        'Form_Main
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SuperTabControl_Main)
        Me.Controls.Add(Me.MetroStatusBar1)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_Main"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.NUD_LM_DefaultPositionYRotation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_LM_DefaultPositionAreaID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl_Main.ResumeLayout(False)
        Me.SuperTabControlPanel_General.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel6.ResumeLayout(False)
        Me.SuperTabControlPanel_LM.ResumeLayout(False)
        Me.GroupBox_LM_Areas.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.TabControl_LM_Area, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl_LM_Area.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel5.ResumeLayout(False)
        Me.TabControlPanel6.ResumeLayout(False)
        CType(Me.TabControl_LM_Level, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl_LM_Level.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        CType(Me.PictureBox_BGImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel_MS.ResumeLayout(False)
        Me.GroupPanel12.ResumeLayout(False)
        Me.GroupBox_MS_SeqProperties.ResumeLayout(False)
        Me.GroupBox_MS_SelectedSequence.ResumeLayout(False)
        Me.GroupPanel9.ResumeLayout(False)
        Me.SuperTabControlPanel_TM.ResumeLayout(False)
        Me.GroupPanel_TM_DialogProps.ResumeLayout(False)
        CType(Me.IntegerInput_TM_DialogSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabStrip_TM_TableSelection.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxAdv_LM_Areas As Publics.Controls.ItemListBox
    Friend WithEvents SwitchButton_LM_ActSelector As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton_LM_HardcodedCameraSettings As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_LM_LevelBG As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBox_LM_CameraPreset As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBox_LM_EnvironmentEffects As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBox_LM_TerrainTyp As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListBoxAdv_LM_Levels As Publics.Controls.ItemListBox
    Friend WithEvents Button_LM_LoadLevelBG As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_AddNewLevel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_AddArea As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListBoxAdv_LM_ContentOfOB0x09 As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents ListBoxAdv_LM_ContentOfOB0x0D As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents ListBoxAdv_LM_ContentOfOB0x0C As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents ComboBox_LM_OB0x09 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBox_LM_OB0x0D As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboBox_LM_OB0x0C As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListBoxAdv_MS_MusicSequences As Publics.Controls.ItemListBox
    Friend WithEvents TextBoxX_MS_Sequencename As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX_MS_SequenceID As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_MS_ReplaceSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line6 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Button_MS_ExtractSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX56 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_MS_OverwriteSizeRestrictions As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Button_LM_SetUpStartPosition As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX57 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_LM_RemoveArea As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_LM_Music As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX_MS_SeqSize As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_MS_NInst As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX_G_Filename As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_G_Filesize As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_G_GameName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_G_SaveGameName As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NUD_LM_DefaultPositionYRotation As NumericUpDown
    Friend WithEvents NUD_LM_DefaultPositionAreaID As NumericUpDown
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_ImportModel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line_TM_Warning1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line_TM_Warning2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents TextBoxX_TM_TextEditor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Button_LM_AreaEditor As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line_TM_Green As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents SuperTabControl_Main As DevComponents.DotNetBar.TabControl
    Friend WithEvents SuperTabControlPanel_General As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents SuperTabItem_General As DevComponents.DotNetBar.TabItem
    Friend WithEvents SuperTabControlPanel_LM As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents SuperTabItem_LM As DevComponents.DotNetBar.TabItem
    Friend WithEvents SuperTabControlPanel_MS As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents SuperTabItem_MS As DevComponents.DotNetBar.TabItem
    Friend WithEvents SuperTabControlPanel_TM As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents SuperTabItem_TM As DevComponents.DotNetBar.TabItem
    Friend WithEvents CheckBoxX_LM_Enable2DCamera As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ListViewEx_LM_Specials As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents Button_LM_RemoveSpecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_EditSpecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_LM_AddSpecial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeaderA1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeaderA As ColumnHeader
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonItem_ExportModel As DevComponents.DotNetBar.ButtonX
    Public WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_LaunchROM As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem58 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem32 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem22 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Bar_Plugins As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem31 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem558 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem25 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Bar_EnableExpertMode As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem27 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem28 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem29 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem30 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DotNetBarManager1 As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TabControl_LM_Area As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem6 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControl_LM_Level As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox_LM_Areas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel6 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel12 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox_MS_SeqProperties As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox_MS_SelectedSequence As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel9 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents MetroStatusBar1 As DevComponents.DotNetBar.Metro.MetroStatusBar
    Friend WithEvents LabelItem_Status As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ItemPanel_RecentFiles As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ButtonItem_SaveRom As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ListViewEx_TM_TableEntries As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents TabStrip_TM_TableSelection As DevComponents.DotNetBar.TabStrip
    Friend WithEvents TabItem_TM_Dialogs As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabItem_TM_LevelNames As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabItem_TM_ActNames As DevComponents.DotNetBar.TabItem
    Friend WithEvents GroupPanel_TM_DialogProps As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx_TM_DialogPosY As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents IntegerInput_TM_DialogSize As DevComponents.Editors.IntegerInput
    Friend WithEvents ComboBoxEx_TM_DialogPosX As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonItem_ExportVisualMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ExportCollisionMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonX_LM_LevelsMore As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem14 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_TrajectoryEditor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem20 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem21 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX_TM_BytesLeft As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX_MS_RemoveSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_MS_AddSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem23 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem24 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ModelImporter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ColorPickerButton_LM_BackgroundColor As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents ComboBoxEx_LM_BGMode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents PictureBox_BGImage As PictureBox
    Friend WithEvents ComboBoxEx_LM_AreaBG As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_LM_ShowMsgEnabled As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_LM_ShowMsgID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonItem15 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonX_LM_ScrollTexEditor As DevComponents.DotNetBar.ButtonX
End Class
