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
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
        Me.tabMusicManager = New SM64_ROM_Manager.Tab_MusicManager()
        Me.TabItem_MusicManager = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.tabTextManager = New SM64_ROM_Manager.Tab_TextManager()
        Me.TabItem_TextManager = New DevComponents.DotNetBar.TabItem(Me.components)
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
        Me.ButtonItem15 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem16 = New DevComponents.DotNetBar.ButtonItem()
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
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
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
        resources.ApplyResources(Me.RibbonControl1, "RibbonControl1")
        Me.RibbonControl1.ForeColor = System.Drawing.Color.Black
        Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl1.SystemText.MaximizeRibbonText = resources.GetString("RibbonControl1.SystemText.MaximizeRibbonText")
        Me.RibbonControl1.SystemText.MinimizeRibbonText = resources.GetString("RibbonControl1.SystemText.MinimizeRibbonText")
        Me.RibbonControl1.SystemText.QatAddItemText = resources.GetString("RibbonControl1.SystemText.QatAddItemText")
        Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = resources.GetString("RibbonControl1.SystemText.QatCustomizeMenuLabel")
        Me.RibbonControl1.SystemText.QatCustomizeText = resources.GetString("RibbonControl1.SystemText.QatCustomizeText")
        Me.RibbonControl1.SystemText.QatDialogAddButton = resources.GetString("RibbonControl1.SystemText.QatDialogAddButton")
        Me.RibbonControl1.SystemText.QatDialogCancelButton = resources.GetString("RibbonControl1.SystemText.QatDialogCancelButton")
        Me.RibbonControl1.SystemText.QatDialogCaption = resources.GetString("RibbonControl1.SystemText.QatDialogCaption")
        Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = resources.GetString("RibbonControl1.SystemText.QatDialogCategoriesLabel")
        Me.RibbonControl1.SystemText.QatDialogOkButton = resources.GetString("RibbonControl1.SystemText.QatDialogOkButton")
        Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = resources.GetString("RibbonControl1.SystemText.QatDialogPlacementCheckbox")
        Me.RibbonControl1.SystemText.QatDialogRemoveButton = resources.GetString("RibbonControl1.SystemText.QatDialogRemoveButton")
        Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = resources.GetString("RibbonControl1.SystemText.QatPlaceAboveRibbonText")
        Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = resources.GetString("RibbonControl1.SystemText.QatPlaceBelowRibbonText")
        Me.RibbonControl1.SystemText.QatRemoveItemText = resources.GetString("RibbonControl1.SystemText.QatRemoveItemText")
        Me.RibbonControl1.TabGroupHeight = 14
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Bar2)
        Me.Panel1.Name = "Panel1"
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem_General)
        Me.TabControl1.Tabs.Add(Me.TabItem_LevelManager)
        Me.TabControl1.Tabs.Add(Me.TabItem_TextManager)
        Me.TabControl1.Tabs.Add(Me.TabItem_MusicManager)
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.tabGeneral)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel1, "TabControlPanel1")
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabItem = Me.TabItem_General
        '
        'tabGeneral
        '
        resources.ApplyResources(Me.tabGeneral, "tabGeneral")
        Me.tabGeneral.BackColor = System.Drawing.Color.White
        Me.tabGeneral.MainForm = Nothing
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.RomMgr = Nothing
        '
        'TabItem_General
        '
        Me.TabItem_General.AttachedControl = Me.TabControlPanel1
        Me.TabItem_General.Name = "TabItem_General"
        resources.ApplyResources(Me.TabItem_General, "TabItem_General")
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.tabLevelManager)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel2, "TabControlPanel2")
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabItem = Me.TabItem_LevelManager
        '
        'tabLevelManager
        '
        resources.ApplyResources(Me.tabLevelManager, "tabLevelManager")
        Me.tabLevelManager.BackColor = System.Drawing.Color.White
        Me.tabLevelManager.MainForm = Nothing
        Me.tabLevelManager.Name = "tabLevelManager"
        Me.tabLevelManager.RomMgr = Nothing
        '
        'TabItem_LevelManager
        '
        Me.TabItem_LevelManager.AttachedControl = Me.TabControlPanel2
        Me.TabItem_LevelManager.Name = "TabItem_LevelManager"
        resources.ApplyResources(Me.TabItem_LevelManager, "TabItem_LevelManager")
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.tabMusicManager)
        Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel4, "TabControlPanel4")
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabItem = Me.TabItem_MusicManager
        '
        'tabMusicManager
        '
        resources.ApplyResources(Me.tabMusicManager, "tabMusicManager")
        Me.tabMusicManager.BackColor = System.Drawing.Color.White
        Me.tabMusicManager.MainForm = Nothing
        Me.tabMusicManager.Name = "tabMusicManager"
        Me.tabMusicManager.RomMgr = Nothing
        '
        'TabItem_MusicManager
        '
        Me.TabItem_MusicManager.AttachedControl = Me.TabControlPanel4
        Me.TabItem_MusicManager.Name = "TabItem_MusicManager"
        resources.ApplyResources(Me.TabItem_MusicManager, "TabItem_MusicManager")
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.tabTextManager)
        Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlPanel3, "TabControlPanel3")
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabItem = Me.TabItem_TextManager
        '
        'tabTextManager
        '
        resources.ApplyResources(Me.tabTextManager, "tabTextManager")
        Me.tabTextManager.BackColor = System.Drawing.Color.White
        Me.tabTextManager.MainForm = Nothing
        Me.tabTextManager.Name = "tabTextManager"
        Me.tabTextManager.RomMgr = Nothing
        '
        'TabItem_TextManager
        '
        Me.TabItem_TextManager.AttachedControl = Me.TabControlPanel3
        Me.TabItem_TextManager.Name = "TabItem_TextManager"
        resources.ApplyResources(Me.TabItem_TextManager, "TabItem_TextManager")
        '
        'Bar2
        '
        resources.ApplyResources(Me.Bar2, "Bar2")
        Me.Bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Bar2.AntiAlias = True
        Me.Bar2.BarType = DevComponents.DotNetBar.eBarType.MenuBar
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem7, Me.ButtonItem22, Me.ButtonItem12, Me.ButtonItem_Bar_Plugins, Me.ButtonItem558})
        Me.Bar2.MenuBar = True
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabStop = False
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
        Me.ButtonItem7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.ButtonItem8, Me.ButtonItem10, Me.ButtonItem11, Me.LabelItem3, Me.ButtonItem_ModelImporter, Me.ButtonItem17, Me.ButtonItem_TrajectoryEditor, Me.ButtonItem14, Me.ButtonItem13, Me.ButtonItem15, Me.ButtonItem16, Me.ButtonItem32, Me.ButtonItem18})
        resources.ApplyResources(Me.ButtonItem7, "ButtonItem7")
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
        'LabelItem3
        '
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 10
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        resources.ApplyResources(Me.LabelItem3, "LabelItem3")
        '
        'ButtonItem_ModelImporter
        '
        Me.ButtonItem_ModelImporter.Name = "ButtonItem_ModelImporter"
        resources.ApplyResources(Me.ButtonItem_ModelImporter, "ButtonItem_ModelImporter")
        '
        'ButtonItem17
        '
        Me.ButtonItem17.Name = "ButtonItem17"
        resources.ApplyResources(Me.ButtonItem17, "ButtonItem17")
        '
        'ButtonItem_TrajectoryEditor
        '
        Me.ButtonItem_TrajectoryEditor.Name = "ButtonItem_TrajectoryEditor"
        resources.ApplyResources(Me.ButtonItem_TrajectoryEditor, "ButtonItem_TrajectoryEditor")
        '
        'ButtonItem14
        '
        Me.ButtonItem14.Name = "ButtonItem14"
        resources.ApplyResources(Me.ButtonItem14, "ButtonItem14")
        '
        'ButtonItem13
        '
        Me.ButtonItem13.Name = "ButtonItem13"
        resources.ApplyResources(Me.ButtonItem13, "ButtonItem13")
        '
        'ButtonItem15
        '
        Me.ButtonItem15.Name = "ButtonItem15"
        resources.ApplyResources(Me.ButtonItem15, "ButtonItem15")
        '
        'ButtonItem16
        '
        Me.ButtonItem16.Name = "ButtonItem16"
        resources.ApplyResources(Me.ButtonItem16, "ButtonItem16")
        '
        'ButtonItem32
        '
        Me.ButtonItem32.Enabled = False
        Me.ButtonItem32.Name = "ButtonItem32"
        resources.ApplyResources(Me.ButtonItem32, "ButtonItem32")
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
        Me.ButtonItem22.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1, Me.ButtonItem4, Me.ButtonItem9, Me.ButtonItem_M64ToMidiConverter})
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
        'ButtonItem9
        '
        Me.ButtonItem9.Name = "ButtonItem9"
        resources.ApplyResources(Me.ButtonItem9, "ButtonItem9")
        '
        'ButtonItem_M64ToMidiConverter
        '
        Me.ButtonItem_M64ToMidiConverter.Name = "ButtonItem_M64ToMidiConverter"
        resources.ApplyResources(Me.ButtonItem_M64ToMidiConverter, "ButtonItem_M64ToMidiConverter")
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
        'ButtonItem_Bar_Plugins
        '
        Me.ButtonItem_Bar_Plugins.BeginGroup = True
        Me.ButtonItem_Bar_Plugins.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Bar_Plugins.Name = "ButtonItem_Bar_Plugins"
        Me.ButtonItem_Bar_Plugins.Symbol = ""
        Me.ButtonItem_Bar_Plugins.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_Bar_Plugins, "ButtonItem_Bar_Plugins")
        Me.ButtonItem_Bar_Plugins.Visible = False
        '
        'ButtonItem558
        '
        Me.ButtonItem558.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem558.Name = "ButtonItem558"
        Me.ButtonItem558.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem25, Me.ButtonItem5, Me.ButtonItem_Bar_EnableExpertMode, Me.ButtonItem27, Me.ButtonItem28, Me.ButtonItem29, Me.ButtonItem30})
        Me.ButtonItem558.Symbol = ""
        Me.ButtonItem558.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem558, "ButtonItem558")
        '
        'ButtonItem25
        '
        Me.ButtonItem25.Name = "ButtonItem25"
        Me.ButtonItem25.Symbol = ""
        Me.ButtonItem25.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem25, "ButtonItem25")
        '
        'ButtonItem5
        '
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Symbol = ""
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
        Me.ButtonItem27.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem27.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem27, "ButtonItem27")
        Me.ButtonItem27.Visible = False
        '
        'ButtonItem28
        '
        Me.ButtonItem28.Name = "ButtonItem28"
        resources.ApplyResources(Me.ButtonItem28, "ButtonItem28")
        Me.ButtonItem28.Visible = False
        '
        'ButtonItem29
        '
        Me.ButtonItem29.Name = "ButtonItem29"
        Me.ButtonItem29.Symbol = ""
        Me.ButtonItem29.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem29, "ButtonItem29")
        '
        'ButtonItem30
        '
        Me.ButtonItem30.Name = "ButtonItem30"
        Me.ButtonItem30.Symbol = "57345"
        Me.ButtonItem30.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem30.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem30, "ButtonItem30")
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        resources.ApplyResources(Me.Bar1, "Bar1")
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1})
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabStop = False
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        resources.ApplyResources(Me.LabelItem1, "LabelItem1")
        '
        'MainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
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
    Friend WithEvents ButtonItem15 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem16 As DevComponents.DotNetBar.ButtonItem
End Class
