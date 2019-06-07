<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextProfileEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextProfileEditor))
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ItemListBox1 = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.Bar2 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem_ClearArrayItems = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveArrayItem = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_AddArrayItem = New DevComponents.DotNetBar.ButtonItem()
        Me.AdvPropertyGrid1 = New DevComponents.DotNetBar.AdvPropertyGrid()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.ButtonItem_AddTableGroup = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_AddArrayGroup = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveGroup = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.AdvTree1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AdvTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.AdvTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.Size = New System.Drawing.Size(241, 472)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.AdvTree1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(567, 472)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.AdvPropertyGrid1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(241, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(326, 472)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ItemListBox1)
        Me.Panel3.Controls.Add(Me.Bar2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 194)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(326, 278)
        Me.Panel3.TabIndex = 4
        '
        'ItemListBox1
        '
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        Me.ItemListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemListBox1.Location = New System.Drawing.Point(0, 25)
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Size = New System.Drawing.Size(326, 253)
        Me.ItemListBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ItemListBox1.TabIndex = 0
        Me.ItemListBox1.Text = "ItemListBox1"
        '
        'Bar2
        '
        Me.Bar2.AccessibleDescription = "Bar2 (Bar2)"
        Me.Bar2.AccessibleName = "Bar2"
        Me.Bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar2.AntiAlias = True
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar2.IsMaximized = False
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_AddArrayItem, Me.ButtonItem_RemoveArrayItem, Me.ButtonItem_ClearArrayItems})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.RoundCorners = False
        Me.Bar2.Size = New System.Drawing.Size(326, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar2.TabIndex = 3
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'ButtonItem_ClearArrayItems
        '
        Me.ButtonItem_ClearArrayItems.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_ClearArrayItems.Name = "ButtonItem_ClearArrayItems"
        Me.ButtonItem_ClearArrayItems.Symbol = "57676"
        Me.ButtonItem_ClearArrayItems.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem_ClearArrayItems.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_ClearArrayItems.SymbolSize = 12.0!
        Me.ButtonItem_ClearArrayItems.Text = "Clear List"
        '
        'ButtonItem_RemoveArrayItem
        '
        Me.ButtonItem_RemoveArrayItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_RemoveArrayItem.Name = "ButtonItem_RemoveArrayItem"
        Me.ButtonItem_RemoveArrayItem.Symbol = "57676"
        Me.ButtonItem_RemoveArrayItem.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem_RemoveArrayItem.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_RemoveArrayItem.SymbolSize = 12.0!
        Me.ButtonItem_RemoveArrayItem.Text = "Remove Item"
        '
        'ButtonItem_AddArrayItem
        '
        Me.ButtonItem_AddArrayItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_AddArrayItem.Name = "ButtonItem_AddArrayItem"
        Me.ButtonItem_AddArrayItem.Symbol = "57669"
        Me.ButtonItem_AddArrayItem.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_AddArrayItem.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_AddArrayItem.SymbolSize = 12.0!
        Me.ButtonItem_AddArrayItem.Text = "Text Item"
        '
        'AdvPropertyGrid1
        '
        Me.AdvPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AdvPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke
        Me.AdvPropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.AdvPropertyGrid1.Name = "AdvPropertyGrid1"
        Me.AdvPropertyGrid1.Size = New System.Drawing.Size(326, 194)
        Me.AdvPropertyGrid1.TabIndex = 1
        Me.AdvPropertyGrid1.Text = "AdvPropertyGrid1"
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "Bar1 (Bar1)"
        Me.Bar1.AccessibleName = "Bar1"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.IsMaximized = False
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_AddTableGroup, Me.ButtonItem_AddArrayGroup, Me.ButtonItem_RemoveGroup})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.RoundCorners = False
        Me.Bar1.Size = New System.Drawing.Size(567, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 2
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'ButtonItem_AddTableGroup
        '
        Me.ButtonItem_AddTableGroup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_AddTableGroup.Name = "ButtonItem_AddTableGroup"
        Me.ButtonItem_AddTableGroup.Symbol = "57669"
        Me.ButtonItem_AddTableGroup.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_AddTableGroup.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_AddTableGroup.SymbolSize = 12.0!
        Me.ButtonItem_AddTableGroup.Text = "Table Group"
        '
        'ButtonItem_AddArrayGroup
        '
        Me.ButtonItem_AddArrayGroup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_AddArrayGroup.Name = "ButtonItem_AddArrayGroup"
        Me.ButtonItem_AddArrayGroup.Symbol = "57669"
        Me.ButtonItem_AddArrayGroup.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem_AddArrayGroup.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_AddArrayGroup.SymbolSize = 12.0!
        Me.ButtonItem_AddArrayGroup.Text = "Array Group"
        '
        'ButtonItem_RemoveGroup
        '
        Me.ButtonItem_RemoveGroup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem_RemoveGroup.Name = "ButtonItem_RemoveGroup"
        Me.ButtonItem_RemoveGroup.Symbol = "57676"
        Me.ButtonItem_RemoveGroup.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem_RemoveGroup.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_RemoveGroup.SymbolSize = 12.0!
        Me.ButtonItem_RemoveGroup.Text = "Remove Group"
        '
        'TextProfileEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 497)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TextProfileEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Profile Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AdvPropertyGrid1 As DevComponents.DotNetBar.AdvPropertyGrid
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem_AddTableGroup As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_AddArrayGroup As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveGroup As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ItemListBox1 As Publics.Controls.ItemListBox
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem_ClearArrayItems As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveArrayItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_AddArrayItem As DevComponents.DotNetBar.ButtonItem
End Class
