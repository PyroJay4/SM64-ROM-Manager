<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits DevComponents.DotNetBar.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.RibbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.tabGeneral = New SM64_ROM_Manager.Tab_General()
        Me.TabItem_General = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.tabLevelManager = New SM64_ROM_Manager.Tab_LevelManager()
        Me.TabItem_LevelManager = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.tabTextManager = New SM64_ROM_Manager.Tab_TextManager()
        Me.TabItem_TextManager = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.tabMusicManager = New SM64_ROM_Manager.Tab_MusicManager()
        Me.TabItem_MusicManager = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_SaveRom = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_LaunchROM = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem10 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem11 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem_ModelImporter = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_TrajectoryEditor = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem14 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem32 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem22 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_M64ToMidiConverter = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem12 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem23 = New DevComponents.DotNetBar.ButtonItem()
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
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.Panel1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.RibbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControl1.CanCustomize = False
        Me.RibbonControl1.CaptionVisible = True
        Me.RibbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControl1.ForeColor = System.Drawing.Color.Black
        Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl1.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.RibbonControl1.Size = New System.Drawing.Size(686, 30)
        Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControl1.TabGroupHeight = 14
        Me.RibbonControl1.TabIndex = 0
        Me.RibbonControl1.Text = "RibbonControl1"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Bar2)
        Me.Panel1.Location = New System.Drawing.Point(1, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 597)
        Me.Panel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(694, 573)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl1.TabIndex = 4
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem_General)
        Me.TabControl1.Tabs.Add(Me.TabItem_LevelManager)
        Me.TabControl1.Tabs.Add(Me.TabItem_TextManager)
        Me.TabControl1.Tabs.Add(Me.TabItem_MusicManager)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.tabGeneral)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(694, 546)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem_General
        '
        'tabGeneral
        '
        Me.tabGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabGeneral.BackColor = System.Drawing.Color.White
        Me.tabGeneral.Location = New System.Drawing.Point(0, 0)
        Me.tabGeneral.MainForm = Nothing
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.RomMgr = Nothing
        Me.tabGeneral.Size = New System.Drawing.Size(694, 546)
        Me.tabGeneral.TabIndex = 0
        '
        'TabItem_General
        '
        Me.TabItem_General.AttachedControl = Me.TabControlPanel1
        Me.TabItem_General.Name = "TabItem_General"
        Me.TabItem_General.Text = "General"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.tabLevelManager)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(694, 546)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem_LevelManager
        '
        'tabLevelManager
        '
        Me.tabLevelManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLevelManager.BackColor = System.Drawing.Color.White
        Me.tabLevelManager.Location = New System.Drawing.Point(0, 0)
        Me.tabLevelManager.MainForm = Nothing
        Me.tabLevelManager.Name = "tabLevelManager"
        Me.tabLevelManager.RomMgr = Nothing
        Me.tabLevelManager.Size = New System.Drawing.Size(694, 546)
        Me.tabLevelManager.TabIndex = 0
        '
        'TabItem_LevelManager
        '
        Me.TabItem_LevelManager.AttachedControl = Me.TabControlPanel2
        Me.TabItem_LevelManager.Name = "TabItem_LevelManager"
        Me.TabItem_LevelManager.Text = "Level Manager"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.tabTextManager)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(694, 546)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 9
        Me.TabControlPanel3.TabItem = Me.TabItem_TextManager
        '
        'tabTextManager
        '
        Me.tabTextManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTextManager.BackColor = System.Drawing.Color.White
        Me.tabTextManager.Location = New System.Drawing.Point(0, 0)
        Me.tabTextManager.MainForm = Nothing
        Me.tabTextManager.Name = "tabTextManager"
        Me.tabTextManager.RomMgr = Nothing
        Me.tabTextManager.Size = New System.Drawing.Size(694, 546)
        Me.tabTextManager.TabIndex = 0
        '
        'TabItem_TextManager
        '
        Me.TabItem_TextManager.AttachedControl = Me.TabControlPanel3
        Me.TabItem_TextManager.Name = "TabItem_TextManager"
        Me.TabItem_TextManager.Text = "Text Editor"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.tabMusicManager)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(694, 546)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 13
        Me.TabControlPanel4.TabItem = Me.TabItem_MusicManager
        '
        'tabMusicManager
        '
        Me.tabMusicManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMusicManager.BackColor = System.Drawing.Color.White
        Me.tabMusicManager.Location = New System.Drawing.Point(0, 0)
        Me.tabMusicManager.MainForm = Nothing
        Me.tabMusicManager.Name = "tabMusicManager"
        Me.tabMusicManager.RomMgr = Nothing
        Me.tabMusicManager.Size = New System.Drawing.Size(694, 546)
        Me.tabMusicManager.TabIndex = 0
        '
        'TabItem_MusicManager
        '
        Me.TabItem_MusicManager.AttachedControl = Me.TabControlPanel4
        Me.TabItem_MusicManager.Name = "TabItem_MusicManager"
        Me.TabItem_MusicManager.Text = "Music Table"
        '
        'Bar2
        '
        Me.Bar2.AccessibleDescription = "DotNetBar Bar (Bar2)"
        Me.Bar2.AccessibleName = "DotNetBar Bar"
        Me.Bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.MenuBar
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem7, Me.ButtonItem22, Me.ButtonItem12, Me.ButtonItem_Bar_Plugins, Me.ButtonItem558})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.MenuBar = True
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(694, 24)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 3
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3, Me.ButtonItem_SaveRom, Me.ButtonItem_LaunchROM, Me.ButtonItem6})
        Me.ButtonItem2.Text = "File"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlO)
        Me.ButtonItem3.Symbol = "58055"
        Me.ButtonItem3.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.ButtonItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem3.SymbolSize = 12.0!
        Me.ButtonItem3.Text = "Open ..."
        '
        'ButtonItem_SaveRom
        '
        Me.ButtonItem_SaveRom.Name = "ButtonItem_SaveRom"
        Me.ButtonItem_SaveRom.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS)
        Me.ButtonItem_SaveRom.Symbol = "57697"
        Me.ButtonItem_SaveRom.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_SaveRom.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_SaveRom.SymbolSize = 12.0!
        Me.ButtonItem_SaveRom.Text = "Save ROM"
        '
        'ButtonItem_LaunchROM
        '
        Me.ButtonItem_LaunchROM.Name = "ButtonItem_LaunchROM"
        Me.ButtonItem_LaunchROM.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.ButtonItem_LaunchROM.Symbol = ""
        Me.ButtonItem_LaunchROM.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_LaunchROM.SymbolSize = 12.0!
        Me.ButtonItem_LaunchROM.Text = "Launch ROM"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.AlternateShortCutText = "Alt+F4"
        Me.ButtonItem6.BeginGroup = True
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Symbol = "59528"
        Me.ButtonItem6.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem6.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem6.SymbolSize = 12.0!
        Me.ButtonItem6.Text = "Close"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.BeginGroup = True
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.ButtonItem8, Me.ButtonItem10, Me.ButtonItem11, Me.LabelItem3, Me.ButtonItem_ModelImporter, Me.ButtonItem17, Me.ButtonItem_TrajectoryEditor, Me.ButtonItem14, Me.ButtonItem13, Me.ButtonItem32, Me.ButtonItem18})
        Me.ButtonItem7.Text = "Modules"
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
        Me.LabelItem2.Text = "Main:"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Text = "Level Manager"
        '
        'ButtonItem10
        '
        Me.ButtonItem10.Name = "ButtonItem10"
        Me.ButtonItem10.Text = "Music Manager"
        '
        'ButtonItem11
        '
        Me.ButtonItem11.Name = "ButtonItem11"
        Me.ButtonItem11.Text = "Text Manager"
        '
        'LabelItem3
        '
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.LabelItem3.Text = "Advanced:"
        '
        'ButtonItem_ModelImporter
        '
        Me.ButtonItem_ModelImporter.Name = "ButtonItem_ModelImporter"
        Me.ButtonItem_ModelImporter.Text = "Model Importer"
        '
        'ButtonItem17
        '
        Me.ButtonItem17.Name = "ButtonItem17"
        Me.ButtonItem17.Text = "Tweaks"
        '
        'ButtonItem_TrajectoryEditor
        '
        Me.ButtonItem_TrajectoryEditor.Name = "ButtonItem_TrajectoryEditor"
        Me.ButtonItem_TrajectoryEditor.Text = "Trajectory Editor"
        '
        'ButtonItem14
        '
        Me.ButtonItem14.Name = "ButtonItem14"
        Me.ButtonItem14.Text = "Item Box Content Editor"
        '
        'ButtonItem13
        '
        Me.ButtonItem13.Name = "ButtonItem13"
        Me.ButtonItem13.Text = "Star Position Editor"
        '
        'ButtonItem32
        '
        Me.ButtonItem32.Enabled = False
        Me.ButtonItem32.Name = "ButtonItem32"
        Me.ButtonItem32.Text = "Script Editor"
        '
        'ButtonItem18
        '
        Me.ButtonItem18.Enabled = False
        Me.ButtonItem18.Name = "ButtonItem18"
        Me.ButtonItem18.Text = "MOP Manager"
        '
        'ButtonItem22
        '
        Me.ButtonItem22.Name = "ButtonItem22"
        Me.ButtonItem22.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1, Me.ButtonItem4, Me.ButtonItem9, Me.ButtonItem_M64ToMidiConverter})
        Me.ButtonItem22.Text = "More"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Symbol = "T"
        Me.ButtonItem1.SymbolSize = 12.0!
        Me.ButtonItem1.Text = "Text Converter"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.Enabled = False
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "Model Converter"
        '
        'ButtonItem9
        '
        Me.ButtonItem9.Name = "ButtonItem9"
        Me.ButtonItem9.Text = "Appy PPF Patch"
        '
        'ButtonItem_M64ToMidiConverter
        '
        Me.ButtonItem_M64ToMidiConverter.Name = "ButtonItem_M64ToMidiConverter"
        Me.ButtonItem_M64ToMidiConverter.Text = "M64 to MIDI Converter"
        '
        'ButtonItem12
        '
        Me.ButtonItem12.Name = "ButtonItem12"
        Me.ButtonItem12.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem23})
        Me.ButtonItem12.Text = "Tools"
        '
        'ButtonItem23
        '
        Me.ButtonItem23.Name = "ButtonItem23"
        Me.ButtonItem23.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9)
        Me.ButtonItem23.Text = "Update Checksum"
        '
        'ButtonItem_Bar_Plugins
        '
        Me.ButtonItem_Bar_Plugins.BeginGroup = True
        Me.ButtonItem_Bar_Plugins.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Bar_Plugins.Name = "ButtonItem_Bar_Plugins"
        Me.ButtonItem_Bar_Plugins.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem31})
        Me.ButtonItem_Bar_Plugins.Symbol = ""
        Me.ButtonItem_Bar_Plugins.SymbolSize = 12.0!
        Me.ButtonItem_Bar_Plugins.Text = "Plugins"
        Me.ButtonItem_Bar_Plugins.Visible = False
        '
        'ButtonItem31
        '
        Me.ButtonItem31.Name = "ButtonItem31"
        Me.ButtonItem31.Text = "Plugin-Manager"
        '
        'ButtonItem558
        '
        Me.ButtonItem558.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem558.Name = "ButtonItem558"
        Me.ButtonItem558.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem25, Me.ButtonItem5, Me.ButtonItem_Bar_EnableExpertMode, Me.ButtonItem27, Me.ButtonItem28, Me.ButtonItem29, Me.ButtonItem30})
        Me.ButtonItem558.Symbol = ""
        Me.ButtonItem558.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem558.SymbolSize = 12.0!
        Me.ButtonItem558.Text = "Options"
        '
        'ButtonItem25
        '
        Me.ButtonItem25.Name = "ButtonItem25"
        Me.ButtonItem25.Symbol = ""
        Me.ButtonItem25.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem25.SymbolSize = 12.0!
        Me.ButtonItem25.Text = "Settings"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Symbol = ""
        Me.ButtonItem5.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem5.SymbolSize = 12.0!
        Me.ButtonItem5.Text = "Style Manager"
        '
        'ButtonItem_Bar_EnableExpertMode
        '
        Me.ButtonItem_Bar_EnableExpertMode.AutoCheckOnClick = True
        Me.ButtonItem_Bar_EnableExpertMode.BeginGroup = True
        Me.ButtonItem_Bar_EnableExpertMode.Name = "ButtonItem_Bar_EnableExpertMode"
        Me.ButtonItem_Bar_EnableExpertMode.Text = "Enable Expert Mode"
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
        Me.ButtonItem27.Text = "Help"
        '
        'ButtonItem28
        '
        Me.ButtonItem28.Name = "ButtonItem28"
        Me.ButtonItem28.Text = "Send Message"
        '
        'ButtonItem29
        '
        Me.ButtonItem29.Name = "ButtonItem29"
        Me.ButtonItem29.Symbol = ""
        Me.ButtonItem29.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem29.SymbolSize = 12.0!
        Me.ButtonItem29.Text = "Updates"
        '
        'ButtonItem30
        '
        Me.ButtonItem30.Name = "ButtonItem30"
        Me.ButtonItem30.Symbol = "57345"
        Me.ButtonItem30.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem30.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem30.SymbolSize = 12.0!
        Me.ButtonItem30.Text = "About"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1})
        Me.Bar1.Location = New System.Drawing.Point(5, 628)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(686, 20)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 2
        Me.Bar1.TabStop = False
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Ready"
        '
        'MainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(696, 650)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SM64 ROM Manager"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
#If DEBUG Then
#End If
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_SaveRom As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_LaunchROM As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem_ModelImporter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_TrajectoryEditor As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem32 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem14 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem22 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem23 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Bar_Plugins As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem31 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem558 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem25 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Bar_EnableExpertMode As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem27 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem28 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem29 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem30 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem_General As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem_LevelManager As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem_TextManager As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem_MusicManager As DevComponents.DotNetBar.TabItem
    Friend WithEvents tabGeneral As Tab_General
    Friend WithEvents tabLevelManager As Tab_LevelManager
    Friend WithEvents tabMusicManager As Tab_MusicManager
    Friend WithEvents tabTextManager As Tab_TextManager
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_M64ToMidiConverter As DevComponents.DotNetBar.ButtonItem
End Class
