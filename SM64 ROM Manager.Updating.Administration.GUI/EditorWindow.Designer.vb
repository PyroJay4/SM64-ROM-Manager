<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditorWindow
    Inherits DevComponents.DotNetBar.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorWindow))
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListViewEx_Files = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuperTabItem_Pkg_Extensions = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LayoutControl2 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem6 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.SuperTabItem_UI_General = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutControlItem5 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.SuperTabItem_UI_PackageInfo = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBoxX_Pkg_Changelog = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuperTabItem_UI_Changelog = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.SuperTabItem_Pkg_Files = New DevComponents.DotNetBar.SuperTabItem()
        Me.RibbonControl_Main = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel2 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar4 = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.ComboBoxItem1 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_UI_EditVersion = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_UI_EditDownloadlink = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar5 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem_UI_NewPackage = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_UI_Open = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_UI_Save = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_UI_SaveAs = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar_Pkg_Erweiterungen = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem_Pkg_AddExtension = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Pkg_RemoveExtension = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar_Pkg_Dateien = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem_Pkg_SelectFileFolder = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Pkg_RemoveFileFolder = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem_ButtonItem_Pkg_Export = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem_Pkg_NewTemplate = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Pkg_OpenTemplate = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Pkg_SaveTemplate = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_Pkg_SaveTemplateAs = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItem_UpdateInfo = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem_Packaging = New DevComponents.DotNetBar.RibbonTabItem()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.LayoutControl2.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        Me.LayoutControl1.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControl_Main.SuspendLayout()
        Me.RibbonPanel2.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SuperTabControl1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
        Me.SuperTabControl1.Location = New System.Drawing.Point(1, 155)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(648, 394)
        Me.SuperTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 1
        Me.SuperTabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem_UI_General, Me.SuperTabItem_UI_PackageInfo, Me.SuperTabItem_UI_Changelog, Me.SuperTabItem_Pkg_Files, Me.SuperTabItem_Pkg_Extensions})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.Panel4)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(98, 0)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(550, 394)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem_Pkg_Extensions
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.ListViewEx_Files)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(550, 394)
        Me.Panel4.TabIndex = 1
        '
        'ListViewEx_Files
        '
        Me.ListViewEx_Files.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx_Files.Border.Class = "ListViewBorder"
        Me.ListViewEx_Files.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx_Files.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewEx_Files.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx_Files.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx_Files.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx_Files.FullRowSelect = True
        Me.ListViewEx_Files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEx_Files.HideSelection = False
        Me.ListViewEx_Files.Location = New System.Drawing.Point(0, 0)
        Me.ListViewEx_Files.Name = "ListViewEx_Files"
        Me.ListViewEx_Files.Size = New System.Drawing.Size(550, 394)
        Me.ListViewEx_Files.TabIndex = 0
        Me.ListViewEx_Files.UseCompatibleStateImageBehavior = False
        Me.ListViewEx_Files.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Datei"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Ort"
        Me.ColumnHeader2.Width = 360
        '
        'SuperTabItem_Pkg_Extensions
        '
        Me.SuperTabItem_Pkg_Extensions.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem_Pkg_Extensions.GlobalItem = False
        Me.SuperTabItem_Pkg_Extensions.Name = "SuperTabItem_Pkg_Extensions"
        Me.SuperTabItem_Pkg_Extensions.Text = "Erweiterungen"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.LayoutControl2)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(98, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(550, 394)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem_UI_General
        '
        'LayoutControl2
        '
        Me.LayoutControl2.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControl2.Controls.Add(Me.LabelX6)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.ForeColor = System.Drawing.Color.Black
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        '
        '
        '
        Me.LayoutControl2.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem6})
        Me.LayoutControl2.Size = New System.Drawing.Size(550, 394)
        Me.LayoutControl2.TabIndex = 0
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(183, 4)
        Me.LabelX6.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(363, 23)
        Me.LabelX6.TabIndex = 0
        Me.LabelX6.Text = "-"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LabelX6
        Me.LayoutControlItem6.Height = 31
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Text = "UpdateInstaller.exe Downloadlink:"
        Me.LayoutControlItem6.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem6.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem6.Width = 100
        Me.LayoutControlItem6.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'SuperTabItem_UI_General
        '
        Me.SuperTabItem_UI_General.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem_UI_General.GlobalItem = False
        Me.SuperTabItem_UI_General.Name = "SuperTabItem_UI_General"
        Me.SuperTabItem_UI_General.Text = "Allgemein"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.LayoutControl1)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(98, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(550, 394)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem_UI_PackageInfo
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControl1.Controls.Add(Me.LabelX1)
        Me.LayoutControl1.Controls.Add(Me.LabelX2)
        Me.LayoutControl1.Controls.Add(Me.LabelX3)
        Me.LayoutControl1.Controls.Add(Me.LabelX4)
        Me.LayoutControl1.Controls.Add(Me.LabelX5)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.ForeColor = System.Drawing.Color.Black
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutSpacerItem1, Me.LayoutControlItem5})
        Me.LayoutControl1.Size = New System.Drawing.Size(550, 394)
        Me.LayoutControl1.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(82, 4)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(464, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "-"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(82, 35)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(464, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "-"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(82, 66)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(464, 23)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "-"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(82, 97)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(464, 23)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "-"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(82, 160)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(464, 23)
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "-"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LabelX1
        Me.LayoutControlItem1.Height = 31
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "Name:"
        Me.LayoutControlItem1.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem1.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem1.Width = 100
        Me.LayoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LabelX2
        Me.LayoutControlItem2.Height = 31
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Text = "Version:"
        Me.LayoutControlItem2.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem2.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem2.Width = 100
        Me.LayoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LabelX3
        Me.LayoutControlItem3.Height = 31
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Text = "Kanal:"
        Me.LayoutControlItem3.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem3.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem3.Width = 100
        Me.LayoutControlItem3.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.LabelX4
        Me.LayoutControlItem4.Height = 31
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Text = "Build:"
        Me.LayoutControlItem4.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem4.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem4.Width = 100
        Me.LayoutControlItem4.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 32
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 100
        Me.LayoutSpacerItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LabelX5
        Me.LayoutControlItem5.Height = 31
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Text = "Downloadlink:"
        Me.LayoutControlItem5.TextLineAlignment = DevComponents.DotNetBar.Layout.eTextLineAlignment.Middle
        Me.LayoutControlItem5.TextPadding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.LayoutControlItem5.Width = 100
        Me.LayoutControlItem5.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'SuperTabItem_UI_PackageInfo
        '
        Me.SuperTabItem_UI_PackageInfo.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItem_UI_PackageInfo.GlobalItem = False
        Me.SuperTabItem_UI_PackageInfo.Name = "SuperTabItem_UI_PackageInfo"
        Me.SuperTabItem_UI_PackageInfo.Text = "Paket-Info"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.Panel3)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(98, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(550, 394)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem_UI_Changelog
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.TextBoxX_Pkg_Changelog)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(550, 394)
        Me.Panel3.TabIndex = 1
        '
        'TextBoxX_Pkg_Changelog
        '
        Me.TextBoxX_Pkg_Changelog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_Pkg_Changelog.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Pkg_Changelog.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Pkg_Changelog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Pkg_Changelog.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Pkg_Changelog.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_Pkg_Changelog.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxX_Pkg_Changelog.Multiline = True
        Me.TextBoxX_Pkg_Changelog.Name = "TextBoxX_Pkg_Changelog"
        Me.TextBoxX_Pkg_Changelog.PreventEnterBeep = True
        Me.TextBoxX_Pkg_Changelog.Size = New System.Drawing.Size(550, 394)
        Me.TextBoxX_Pkg_Changelog.TabIndex = 0
        Me.TextBoxX_Pkg_Changelog.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_Pkg_Changelog.WatermarkText = "Änderungen hier hinschreiben ..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Beispiel:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Fehler behoben" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Neue Funktion:" &
    " Etwas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Änderung des Datenbanksystems" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Optimierung"
        '
        'SuperTabItem_UI_Changelog
        '
        Me.SuperTabItem_UI_Changelog.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem_UI_Changelog.GlobalItem = False
        Me.SuperTabItem_UI_Changelog.Name = "SuperTabItem_UI_Changelog"
        Me.SuperTabItem_UI_Changelog.Text = "Änderungsliste"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.AdvTree1)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(98, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(550, 394)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem_Pkg_Files
        '
        'AdvTree1
        '
        Me.AdvTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.AdvTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AdvTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.AdvTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.Size = New System.Drawing.Size(550, 394)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.TabIndex = 0
        Me.AdvTree1.Text = "AdvTree1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'SuperTabItem_Pkg_Files
        '
        Me.SuperTabItem_Pkg_Files.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem_Pkg_Files.GlobalItem = False
        Me.SuperTabItem_Pkg_Files.Name = "SuperTabItem_Pkg_Files"
        Me.SuperTabItem_Pkg_Files.Text = "Dateien"
        '
        'RibbonControl_Main
        '
        Me.RibbonControl_Main.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.RibbonControl_Main.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControl_Main.CanCustomize = False
        Me.RibbonControl_Main.CaptionVisible = True
        Me.RibbonControl_Main.Controls.Add(Me.RibbonPanel2)
        Me.RibbonControl_Main.Controls.Add(Me.RibbonPanel1)
        Me.RibbonControl_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControl_Main.ForeColor = System.Drawing.Color.Black
        Me.RibbonControl_Main.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem_UpdateInfo, Me.RibbonTabItem_Packaging})
        Me.RibbonControl_Main.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl_Main.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControl_Main.Name = "RibbonControl_Main"
        Me.RibbonControl_Main.Size = New System.Drawing.Size(640, 154)
        Me.RibbonControl_Main.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl_Main.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControl_Main.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControl_Main.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControl_Main.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControl_Main.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControl_Main.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControl_Main.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControl_Main.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControl_Main.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControl_Main.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControl_Main.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl_Main.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControl_Main.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControl_Main.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl_Main.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControl_Main.TabGroupHeight = 14
        Me.RibbonControl_Main.TabIndex = 2
        '
        'RibbonPanel2
        '
        Me.RibbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar4)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar5)
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel2.Location = New System.Drawing.Point(0, 55)
        Me.RibbonPanel2.Name = "RibbonPanel2"
        Me.RibbonPanel2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanel2.Size = New System.Drawing.Size(640, 99)
        '
        '
        '
        Me.RibbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel2.TabIndex = 2
        '
        'RibbonBar4
        '
        Me.RibbonBar4.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.ContainerControlProcessDialogKey = True
        Me.RibbonBar4.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar4.DragDropSupport = True
        Me.RibbonBar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ButtonItem_UI_EditVersion, Me.ButtonItem_UI_EditDownloadlink})
        Me.RibbonBar4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar4.Location = New System.Drawing.Point(327, 0)
        Me.RibbonBar4.Name = "RibbonBar4"
        Me.RibbonBar4.Size = New System.Drawing.Size(302, 97)
        Me.RibbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar4.TabIndex = 1
        Me.RibbonBar4.Text = "Paket-Info"
        '
        '
        '
        Me.RibbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItem1, Me.ButtonItem1, Me.ButtonItem2})
        '
        '
        '
        Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ComboBoxItem1
        '
        Me.ComboBoxItem1.ComboWidth = 150
        Me.ComboBoxItem1.DropDownHeight = 106
        Me.ComboBoxItem1.Name = "ComboBoxItem1"
        Me.ComboBoxItem1.Text = "ComboBoxItem1"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_add_16px
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Neue Paket-Info"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_delete_sign_16px
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Paket-Info löschen"
        '
        'ButtonItem_UI_EditVersion
        '
        Me.ButtonItem_UI_EditVersion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_UI_EditVersion.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_versions_32px
        Me.ButtonItem_UI_EditVersion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_UI_EditVersion.Name = "ButtonItem_UI_EditVersion"
        Me.ButtonItem_UI_EditVersion.SubItemsExpandWidth = 14
        Me.ButtonItem_UI_EditVersion.Text = "Version bearbeiten"
        '
        'ButtonItem_UI_EditDownloadlink
        '
        Me.ButtonItem_UI_EditDownloadlink.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_UI_EditDownloadlink.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_link_32px
        Me.ButtonItem_UI_EditDownloadlink.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_UI_EditDownloadlink.Name = "ButtonItem_UI_EditDownloadlink"
        Me.ButtonItem_UI_EditDownloadlink.SubItemsExpandWidth = 14
        Me.ButtonItem_UI_EditDownloadlink.Text = "Downloadlink bearbeiten"
        '
        'RibbonBar5
        '
        Me.RibbonBar5.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar5.ContainerControlProcessDialogKey = True
        Me.RibbonBar5.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar5.DragDropSupport = True
        Me.RibbonBar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3})
        Me.RibbonBar5.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar5.Location = New System.Drawing.Point(233, 0)
        Me.RibbonBar5.Name = "RibbonBar5"
        Me.RibbonBar5.Size = New System.Drawing.Size(94, 97)
        Me.RibbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar5.TabIndex = 2
        Me.RibbonBar5.Text = "Allgemein"
        '
        '
        '
        Me.RibbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_edit_property_32px
        Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.SubItemsExpandWidth = 14
        Me.ButtonItem3.Text = "Konfiguration bearbeiten"
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar2.DragDropSupport = True
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_UI_NewPackage, Me.ButtonItem_UI_Open, Me.ButtonItem_UI_Save, Me.ButtonItem_UI_SaveAs})
        Me.RibbonBar2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar2.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(230, 97)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 0
        Me.RibbonBar2.Text = "Konfiguration"
        '
        '
        '
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem_UI_NewPackage
        '
        Me.ButtonItem_UI_NewPackage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_UI_NewPackage.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_new_file_32px
        Me.ButtonItem_UI_NewPackage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_UI_NewPackage.Name = "ButtonItem_UI_NewPackage"
        Me.ButtonItem_UI_NewPackage.SubItemsExpandWidth = 14
        Me.ButtonItem_UI_NewPackage.Text = "Neue Info"
        '
        'ButtonItem_UI_Open
        '
        Me.ButtonItem_UI_Open.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_UI_Open.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_code_file_32px
        Me.ButtonItem_UI_Open.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_UI_Open.Name = "ButtonItem_UI_Open"
        Me.ButtonItem_UI_Open.SubItemsExpandWidth = 14
        Me.ButtonItem_UI_Open.Text = "Info Öffnen"
        '
        'ButtonItem_UI_Save
        '
        Me.ButtonItem_UI_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_UI_Save.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_save_32px
        Me.ButtonItem_UI_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_UI_Save.Name = "ButtonItem_UI_Save"
        Me.ButtonItem_UI_Save.SubItemsExpandWidth = 14
        Me.ButtonItem_UI_Save.Text = "Info Speichern"
        '
        'ButtonItem_UI_SaveAs
        '
        Me.ButtonItem_UI_SaveAs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_UI_SaveAs.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_save_as_32px
        Me.ButtonItem_UI_SaveAs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_UI_SaveAs.Name = "ButtonItem_UI_SaveAs"
        Me.ButtonItem_UI_SaveAs.SubItemsExpandWidth = 14
        Me.ButtonItem_UI_SaveAs.Text = "Speichern unter"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar_Pkg_Erweiterungen)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar_Pkg_Dateien)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar3)
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 55)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanel1.Size = New System.Drawing.Size(640, 99)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        Me.RibbonPanel1.Visible = False
        '
        'RibbonBar_Pkg_Erweiterungen
        '
        Me.RibbonBar_Pkg_Erweiterungen.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar_Pkg_Erweiterungen.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar_Pkg_Erweiterungen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar_Pkg_Erweiterungen.ContainerControlProcessDialogKey = True
        Me.RibbonBar_Pkg_Erweiterungen.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar_Pkg_Erweiterungen.DragDropSupport = True
        Me.RibbonBar_Pkg_Erweiterungen.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_Pkg_AddExtension, Me.ButtonItem_Pkg_RemoveExtension})
        Me.RibbonBar_Pkg_Erweiterungen.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar_Pkg_Erweiterungen.Location = New System.Drawing.Point(463, 0)
        Me.RibbonBar_Pkg_Erweiterungen.Name = "RibbonBar_Pkg_Erweiterungen"
        Me.RibbonBar_Pkg_Erweiterungen.Size = New System.Drawing.Size(144, 97)
        Me.RibbonBar_Pkg_Erweiterungen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar_Pkg_Erweiterungen.TabIndex = 3
        Me.RibbonBar_Pkg_Erweiterungen.Text = "Erweiterungen"
        '
        '
        '
        Me.RibbonBar_Pkg_Erweiterungen.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar_Pkg_Erweiterungen.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem_Pkg_AddExtension
        '
        Me.ButtonItem_Pkg_AddExtension.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_AddExtension.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_merge_files_32px
        Me.ButtonItem_Pkg_AddExtension.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_AddExtension.Name = "ButtonItem_Pkg_AddExtension"
        Me.ButtonItem_Pkg_AddExtension.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_AddExtension.Text = "Erweiterung hinzufügen"
        '
        'ButtonItem_Pkg_RemoveExtension
        '
        Me.ButtonItem_Pkg_RemoveExtension.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_RemoveExtension.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_delete_sign_32px_1
        Me.ButtonItem_Pkg_RemoveExtension.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_RemoveExtension.Name = "ButtonItem_Pkg_RemoveExtension"
        Me.ButtonItem_Pkg_RemoveExtension.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_RemoveExtension.Text = "Erweiterung entfernen"
        '
        'RibbonBar_Pkg_Dateien
        '
        Me.RibbonBar_Pkg_Dateien.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar_Pkg_Dateien.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar_Pkg_Dateien.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar_Pkg_Dateien.ContainerControlProcessDialogKey = True
        Me.RibbonBar_Pkg_Dateien.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar_Pkg_Dateien.DragDropSupport = True
        Me.RibbonBar_Pkg_Dateien.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_Pkg_SelectFileFolder, Me.ButtonItem_Pkg_RemoveFileFolder})
        Me.RibbonBar_Pkg_Dateien.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar_Pkg_Dateien.Location = New System.Drawing.Point(314, 0)
        Me.RibbonBar_Pkg_Dateien.Name = "RibbonBar_Pkg_Dateien"
        Me.RibbonBar_Pkg_Dateien.Size = New System.Drawing.Size(149, 97)
        Me.RibbonBar_Pkg_Dateien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar_Pkg_Dateien.TabIndex = 2
        Me.RibbonBar_Pkg_Dateien.Text = "Dateien"
        '
        '
        '
        Me.RibbonBar_Pkg_Dateien.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar_Pkg_Dateien.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem_Pkg_SelectFileFolder
        '
        Me.ButtonItem_Pkg_SelectFileFolder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_SelectFileFolder.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_opened_folder_32px
        Me.ButtonItem_Pkg_SelectFileFolder.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_SelectFileFolder.Name = "ButtonItem_Pkg_SelectFileFolder"
        Me.ButtonItem_Pkg_SelectFileFolder.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_SelectFileFolder.Text = "Ordner auswählen"
        '
        'ButtonItem_Pkg_RemoveFileFolder
        '
        Me.ButtonItem_Pkg_RemoveFileFolder.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_RemoveFileFolder.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_delete_sign_32px_1
        Me.ButtonItem_Pkg_RemoveFileFolder.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_RemoveFileFolder.Name = "ButtonItem_Pkg_RemoveFileFolder"
        Me.ButtonItem_Pkg_RemoveFileFolder.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_RemoveFileFolder.Text = "Ordner entfernen"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.DragDropSupport = True
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ButtonItem_Pkg_Export})
        Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar1.Location = New System.Drawing.Point(233, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(81, 97)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        Me.RibbonBar1.Text = "Paket"
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem_ButtonItem_Pkg_Export
        '
        Me.ButtonItem_ButtonItem_Pkg_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_ButtonItem_Pkg_Export.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_export_32px_3
        Me.ButtonItem_ButtonItem_Pkg_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_ButtonItem_Pkg_Export.Name = "ButtonItem_ButtonItem_Pkg_Export"
        Me.ButtonItem_ButtonItem_Pkg_Export.SubItemsExpandWidth = 14
        Me.ButtonItem_ButtonItem_Pkg_Export.Text = "Paket exportieren"
        '
        'RibbonBar3
        '
        Me.RibbonBar3.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.ContainerControlProcessDialogKey = True
        Me.RibbonBar3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar3.DragDropSupport = True
        Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_Pkg_NewTemplate, Me.ButtonItem_Pkg_OpenTemplate, Me.ButtonItem_Pkg_SaveTemplate, Me.ButtonItem_Pkg_SaveTemplateAs})
        Me.RibbonBar3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar3.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar3.Name = "RibbonBar3"
        Me.RibbonBar3.Size = New System.Drawing.Size(230, 97)
        Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar3.TabIndex = 1
        Me.RibbonBar3.Text = "Vorlage"
        '
        '
        '
        Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem_Pkg_NewTemplate
        '
        Me.ButtonItem_Pkg_NewTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_NewTemplate.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_new_file_32px
        Me.ButtonItem_Pkg_NewTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_NewTemplate.Name = "ButtonItem_Pkg_NewTemplate"
        Me.ButtonItem_Pkg_NewTemplate.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_NewTemplate.Text = "Neues Template"
        '
        'ButtonItem_Pkg_OpenTemplate
        '
        Me.ButtonItem_Pkg_OpenTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_OpenTemplate.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_template_32px
        Me.ButtonItem_Pkg_OpenTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_OpenTemplate.Name = "ButtonItem_Pkg_OpenTemplate"
        Me.ButtonItem_Pkg_OpenTemplate.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_OpenTemplate.Text = "Vorlage Öffnen"
        '
        'ButtonItem_Pkg_SaveTemplate
        '
        Me.ButtonItem_Pkg_SaveTemplate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_SaveTemplate.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_save_32px
        Me.ButtonItem_Pkg_SaveTemplate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_SaveTemplate.Name = "ButtonItem_Pkg_SaveTemplate"
        Me.ButtonItem_Pkg_SaveTemplate.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_SaveTemplate.Text = "Vorlage Speichern"
        '
        'ButtonItem_Pkg_SaveTemplateAs
        '
        Me.ButtonItem_Pkg_SaveTemplateAs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_Pkg_SaveTemplateAs.Image = Global.SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.Resources.icons8_save_as_32px
        Me.ButtonItem_Pkg_SaveTemplateAs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem_Pkg_SaveTemplateAs.Name = "ButtonItem_Pkg_SaveTemplateAs"
        Me.ButtonItem_Pkg_SaveTemplateAs.SubItemsExpandWidth = 14
        Me.ButtonItem_Pkg_SaveTemplateAs.Text = "Speichern unter"
        '
        'RibbonTabItem_UpdateInfo
        '
        Me.RibbonTabItem_UpdateInfo.Checked = True
        Me.RibbonTabItem_UpdateInfo.Name = "RibbonTabItem_UpdateInfo"
        Me.RibbonTabItem_UpdateInfo.Panel = Me.RibbonPanel2
        Me.RibbonTabItem_UpdateInfo.Text = "Update-Info"
        '
        'RibbonTabItem_Packaging
        '
        Me.RibbonTabItem_Packaging.Name = "RibbonTabItem_Packaging"
        Me.RibbonTabItem_Packaging.Panel = Me.RibbonPanel1
        Me.RibbonTabItem_Packaging.Text = "Paketierung"
        '
        'EditorWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 550)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.RibbonControl_Main)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditorWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "650; 550"
        Me.Text = "Update-Administration"
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.LayoutControl2.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        Me.LayoutControl1.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControl_Main.ResumeLayout(False)
        Me.RibbonControl_Main.PerformLayout()
        Me.RibbonPanel2.ResumeLayout(False)
        Me.RibbonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem_Pkg_Extensions As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem_UI_Changelog As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents RibbonControl_Main As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonPanel2 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonTabItem_Packaging As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents RibbonTabItem_UpdateInfo As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ButtonItem_ButtonItem_Pkg_Export As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem_UI_Open As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_UI_Save As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_UI_SaveAs As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem_Pkg_OpenTemplate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Pkg_SaveTemplate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Pkg_SaveTemplateAs As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem_UI_PackageInfo As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem_Pkg_Files As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents TextBoxX_Pkg_Changelog As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ListViewEx_Files As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents LayoutControl1 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem_UI_EditVersion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_UI_EditDownloadlink As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ComboBoxItem1 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem_UI_General As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LayoutControlItem5 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents RibbonBar5 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LayoutControlItem6 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents RibbonBar_Pkg_Erweiterungen As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar_Pkg_Dateien As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ButtonItem_Pkg_AddExtension As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Pkg_RemoveExtension As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Pkg_SelectFileFolder As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_UI_NewPackage As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_Pkg_NewTemplate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ButtonItem_Pkg_RemoveFileFolder As DevComponents.DotNetBar.ButtonItem
End Class
