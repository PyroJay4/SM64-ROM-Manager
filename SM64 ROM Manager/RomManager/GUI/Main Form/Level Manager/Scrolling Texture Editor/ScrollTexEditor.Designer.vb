<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScrollTexEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScrollTexEditor))
        Me.ListViewEx_LM_ScrollTexList = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AdvPropertyGrid1 = New DevComponents.DotNetBar.AdvPropertyGrid()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem_CM = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem44 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem43 = New DevComponents.DotNetBar.ButtonItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewEx_LM_ScrollTexList
        '
        Me.ListViewEx_LM_ScrollTexList.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx_LM_ScrollTexList.Border.Class = "ListViewBorder"
        Me.ListViewEx_LM_ScrollTexList.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx_LM_ScrollTexList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewEx_LM_ScrollTexList.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx_LM_ScrollTexList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx_LM_ScrollTexList.FocusCuesEnabled = False
        Me.ListViewEx_LM_ScrollTexList.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx_LM_ScrollTexList.FullRowSelect = True
        Me.ListViewEx_LM_ScrollTexList.GridLines = True
        Me.ListViewEx_LM_ScrollTexList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEx_LM_ScrollTexList.HideSelection = False
        Me.ListViewEx_LM_ScrollTexList.Location = New System.Drawing.Point(0, 0)
        Me.ListViewEx_LM_ScrollTexList.MultiSelect = False
        Me.ListViewEx_LM_ScrollTexList.Name = "ListViewEx_LM_ScrollTexList"
        Me.ListViewEx_LM_ScrollTexList.ShowGroups = False
        Me.ListViewEx_LM_ScrollTexList.Size = New System.Drawing.Size(583, 633)
        Me.ListViewEx_LM_ScrollTexList.TabIndex = 2
        Me.ListViewEx_LM_ScrollTexList.UseCompatibleStateImageBehavior = False
        Me.ListViewEx_LM_ScrollTexList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "#"
        Me.ColumnHeader8.Width = 30
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Behavior"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Type"
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Duration"
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Speed"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Vertex Pointer"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Vertices"
        Me.ColumnHeader2.Width = 100
        '
        'AdvPropertyGrid1
        '
        Me.AdvPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke
        Me.AdvPropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.AdvPropertyGrid1.Name = "AdvPropertyGrid1"
        Me.AdvPropertyGrid1.Size = New System.Drawing.Size(315, 633)
        Me.AdvPropertyGrid1.TabIndex = 8
        Me.AdvPropertyGrid1.Text = "AdvPropertyGrid1"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_CM})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(787, 0)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(78, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 9
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'ButtonItem_CM
        '
        Me.ButtonItem_CM.AutoExpandOnClick = True
        Me.ButtonItem_CM.Name = "ButtonItem_CM"
        Me.ButtonItem_CM.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem44, Me.ButtonItem43})
        Me.ButtonItem_CM.Text = "ContextMenu"
        '
        'ButtonItem44
        '
        Me.ButtonItem44.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem44.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem44.Name = "ButtonItem44"
        Me.ButtonItem44.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN)
        Me.ButtonItem44.SubItemsExpandWidth = 14
        Me.ButtonItem44.Symbol = "57669"
        Me.ButtonItem44.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem44.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem44.SymbolSize = 12.0!
        Me.ButtonItem44.Text = "Add New"
        '
        'ButtonItem43
        '
        Me.ButtonItem43.BeginGroup = True
        Me.ButtonItem43.Name = "ButtonItem43"
        Me.ButtonItem43.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.ButtonItem43.Symbol = "57676"
        Me.ButtonItem43.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem43.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem43.SymbolSize = 12.0!
        Me.ButtonItem43.Text = "Remove"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewEx_LM_ScrollTexList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AdvPropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(902, 633)
        Me.SplitContainer1.SplitterDistance = 583
        Me.SplitContainer1.TabIndex = 9
        '
        'ScrollTexEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 633)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ScrollTexEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Texture Animation Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.AdvPropertyGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewEx_LM_ScrollTexList As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents AdvPropertyGrid1 As DevComponents.DotNetBar.AdvPropertyGrid
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem_CM As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem44 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem43 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
