<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HUDOptionsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HUDOptionsForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel_Positions = New DevComponents.DotNetBar.TabControlPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.IntegerInput_PosX = New DevComponents.Editors.IntegerInput()
        Me.IntegerInput_PosY = New DevComponents.Editors.IntegerInput()
        Me.ButtonX_SavePosition = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_RestorePosition = New DevComponents.DotNetBar.ButtonX()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportPosFromFile = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ExportPosToFile = New DevComponents.DotNetBar.ButtonItem()
        Me.Panel1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel_Positions.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.IntegerInput_PosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_PosY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 426)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel_Positions)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(508, 426)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        '
        'TabControlPanel_Positions
        '
        Me.TabControlPanel_Positions.Controls.Add(Me.Panel2)
        Me.TabControlPanel_Positions.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel_Positions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel_Positions.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanel_Positions.Name = "TabControlPanel_Positions"
        Me.TabControlPanel_Positions.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel_Positions.Size = New System.Drawing.Size(508, 399)
        Me.TabControlPanel_Positions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel_Positions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabControlPanel_Positions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel_Positions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel_Positions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel_Positions.Style.GradientAngle = 90
        Me.TabControlPanel_Positions.TabIndex = 1
        Me.TabControlPanel_Positions.TabItem = Me.TabItem1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.AdvTree1)
        Me.Panel2.Controls.Add(Me.LayoutControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(506, 397)
        Me.Panel2.TabIndex = 1
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
        Me.AdvTree1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.Size = New System.Drawing.Size(312, 397)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.TabIndex = 0
        Me.AdvTree1.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.IntegerInput_PosX)
        Me.LayoutControl1.Controls.Add(Me.IntegerInput_PosY)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_SavePosition)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_RestorePosition)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.LayoutControl1.Location = New System.Drawing.Point(312, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutSpacerItem1, Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.LayoutControl1.Size = New System.Drawing.Size(194, 397)
        Me.LayoutControl1.TabIndex = 1
        '
        'IntegerInput_PosX
        '
        '
        '
        '
        Me.IntegerInput_PosX.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_PosX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_PosX.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_PosX.Location = New System.Drawing.Point(22, 4)
        Me.IntegerInput_PosX.Margin = New System.Windows.Forms.Padding(0)
        Me.IntegerInput_PosX.Name = "IntegerInput_PosX"
        Me.IntegerInput_PosX.ShowUpDown = True
        Me.IntegerInput_PosX.Size = New System.Drawing.Size(168, 20)
        Me.IntegerInput_PosX.TabIndex = 0
        '
        'IntegerInput_PosY
        '
        '
        '
        '
        Me.IntegerInput_PosY.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_PosY.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_PosY.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_PosY.Location = New System.Drawing.Point(22, 32)
        Me.IntegerInput_PosY.Margin = New System.Windows.Forms.Padding(0)
        Me.IntegerInput_PosY.Name = "IntegerInput_PosY"
        Me.IntegerInput_PosY.ShowUpDown = True
        Me.IntegerInput_PosY.Size = New System.Drawing.Size(168, 20)
        Me.IntegerInput_PosY.TabIndex = 1
        '
        'ButtonX_SavePosition
        '
        Me.ButtonX_SavePosition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_SavePosition.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_SavePosition.Location = New System.Drawing.Point(115, 60)
        Me.ButtonX_SavePosition.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonX_SavePosition.Name = "ButtonX_SavePosition"
        Me.ButtonX_SavePosition.Size = New System.Drawing.Size(75, 24)
        Me.ButtonX_SavePosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_SavePosition.TabIndex = 4
        Me.ButtonX_SavePosition.Text = "Save"
        '
        'ButtonX_RestorePosition
        '
        Me.ButtonX_RestorePosition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_RestorePosition.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_RestorePosition.Location = New System.Drawing.Point(32, 60)
        Me.ButtonX_RestorePosition.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonX_RestorePosition.Name = "ButtonX_RestorePosition"
        Me.ButtonX_RestorePosition.Size = New System.Drawing.Size(75, 24)
        Me.ButtonX_RestorePosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_RestorePosition.TabIndex = 3
        Me.ButtonX_RestorePosition.Text = "Restore"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.IntegerInput_PosX
        Me.LayoutControlItem1.Height = 28
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "X:"
        Me.LayoutControlItem1.Width = 100
        Me.LayoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.IntegerInput_PosY
        Me.LayoutControlItem2.Height = 28
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Text = "Y:"
        Me.LayoutControlItem2.Width = 100
        Me.LayoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutSpacerItem1
        '
        Me.LayoutSpacerItem1.Height = 32
        Me.LayoutSpacerItem1.Name = "LayoutSpacerItem1"
        Me.LayoutSpacerItem1.Width = 99
        Me.LayoutSpacerItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ButtonX_RestorePosition
        Me.LayoutControlItem4.Height = 32
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Width = 83
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ButtonX_SavePosition
        Me.LayoutControlItem3.Height = 31
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Width = 83
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel_Positions
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Positions"
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "DotNetBar Bar (Bar1)"
        Me.Bar1.AccessibleName = "DotNetBar Bar"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Bar1.AntiAlias = True
        Me.Bar1.BarType = DevComponents.DotNetBar.eBarType.MenuBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.MenuBar = True
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(508, 24)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 1
        Me.Bar1.TabStop = False
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ImportPosFromFile, Me.ButtonItem_ExportPosToFile})
        Me.ButtonItem1.Text = "Positions"
        '
        'ButtonItem_ImportPosFromFile
        '
        Me.ButtonItem_ImportPosFromFile.Name = "ButtonItem_ImportPosFromFile"
        Me.ButtonItem_ImportPosFromFile.Text = "Import from file ..."
        '
        'ButtonItem_ExportPosToFile
        '
        Me.ButtonItem_ExportPosToFile.Name = "ButtonItem_ExportPosToFile"
        Me.ButtonItem_ExportPosToFile.Text = "Export to file ..."
        '
        'HUDOptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Bar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HUDOptionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HUD Options"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel_Positions.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.IntegerInput_PosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_PosY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel_Positions As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents LayoutControl1 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents IntegerInput_PosY As DevComponents.Editors.IntegerInput
    Friend WithEvents LayoutControlItem2 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents ButtonX_SavePosition As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutControlItem3 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents ButtonX_RestorePosition As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents IntegerInput_PosX As DevComponents.Editors.IntegerInput
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents ButtonItem_ImportPosFromFile As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ExportPosToFile As DevComponents.DotNetBar.ButtonItem
End Class
