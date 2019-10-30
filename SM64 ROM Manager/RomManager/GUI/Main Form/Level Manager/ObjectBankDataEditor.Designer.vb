<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObjectBankDataEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObjectBankDataEditor))
        Me.ObdTree = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem_CM_ObdList = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveObdList = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_CM_Obd = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveObd = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_CM_Cmds = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_CM_Cmd = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveCmd = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_CM_Objs = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_CM_Obj = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveObj = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_AddObj = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_AddCmd = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_AddObd = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.ObdTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ObdTree
        '
        Me.ObdTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.ObdTree.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.ObdTree.BackgroundStyle.Class = "TreeBorderKey"
        Me.ObdTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ObdTree.CellEdit = True
        Me.ObdTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ObdTree.DragDropEnabled = False
        Me.ObdTree.DragDropNodeCopyEnabled = False
        Me.ObdTree.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ObdTree.Location = New System.Drawing.Point(0, 0)
        Me.ObdTree.Name = "ObdTree"
        Me.ObdTree.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.ObdTree.NodesConnector = Me.NodeConnector1
        Me.ObdTree.NodeStyle = Me.ElementStyle1
        Me.ObdTree.PathSeparator = ";"
        Me.ObdTree.Size = New System.Drawing.Size(484, 661)
        Me.ObdTree.Styles.Add(Me.ElementStyle1)
        Me.ObdTree.TabIndex = 0
        Me.ObdTree.Text = "AdvTree1"
        Me.ObdTree.TileSize = New System.Drawing.Size(200, 30)
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
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        Me.ContextMenuBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_CM_ObdList, Me.ButtonItem_CM_Obd, Me.ButtonItem_CM_Cmds, Me.ButtonItem_CM_Cmd, Me.ButtonItem_CM_Objs, Me.ButtonItem_CM_Obj})
        Me.ContextMenuBar1.Location = New System.Drawing.Point(140, 0)
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Size = New System.Drawing.Size(341, 25)
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabIndex = 1
        Me.ContextMenuBar1.TabStop = False
        Me.ContextMenuBar1.Text = "ContextMenuBar1"
        '
        'ButtonItem_CM_ObdList
        '
        Me.ButtonItem_CM_ObdList.AutoExpandOnClick = True
        Me.ButtonItem_CM_ObdList.Name = "ButtonItem_CM_ObdList"
        Me.ButtonItem_CM_ObdList.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_AddObd, Me.ButtonItem_RemoveObdList})
        Me.ButtonItem_CM_ObdList.Text = "ObdList"
        '
        'ButtonItem_RemoveObdList
        '
        Me.ButtonItem_RemoveObdList.BeginGroup = True
        Me.ButtonItem_RemoveObdList.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonItem_RemoveObdList.Name = "ButtonItem_RemoveObdList"
        Me.ButtonItem_RemoveObdList.Text = "Remove"
        '
        'ButtonItem_CM_Obd
        '
        Me.ButtonItem_CM_Obd.AutoExpandOnClick = True
        Me.ButtonItem_CM_Obd.Name = "ButtonItem_CM_Obd"
        Me.ButtonItem_CM_Obd.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_RemoveObd})
        Me.ButtonItem_CM_Obd.Text = "Obd"
        '
        'ButtonItem_RemoveObd
        '
        Me.ButtonItem_RemoveObd.BeginGroup = True
        Me.ButtonItem_RemoveObd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonItem_RemoveObd.Name = "ButtonItem_RemoveObd"
        Me.ButtonItem_RemoveObd.Text = "Remove"
        '
        'ButtonItem_CM_Cmds
        '
        Me.ButtonItem_CM_Cmds.AutoExpandOnClick = True
        Me.ButtonItem_CM_Cmds.Name = "ButtonItem_CM_Cmds"
        Me.ButtonItem_CM_Cmds.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_AddCmd})
        Me.ButtonItem_CM_Cmds.Text = "Cmds"
        '
        'ButtonItem_CM_Cmd
        '
        Me.ButtonItem_CM_Cmd.AutoExpandOnClick = True
        Me.ButtonItem_CM_Cmd.Name = "ButtonItem_CM_Cmd"
        Me.ButtonItem_CM_Cmd.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_RemoveCmd})
        Me.ButtonItem_CM_Cmd.Text = "Cmd"
        '
        'ButtonItem_RemoveCmd
        '
        Me.ButtonItem_RemoveCmd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonItem_RemoveCmd.Name = "ButtonItem_RemoveCmd"
        Me.ButtonItem_RemoveCmd.Text = "Remove"
        '
        'ButtonItem_CM_Objs
        '
        Me.ButtonItem_CM_Objs.AutoExpandOnClick = True
        Me.ButtonItem_CM_Objs.Name = "ButtonItem_CM_Objs"
        Me.ButtonItem_CM_Objs.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_AddObj})
        Me.ButtonItem_CM_Objs.Text = "Objs"
        '
        'ButtonItem_CM_Obj
        '
        Me.ButtonItem_CM_Obj.AutoExpandOnClick = True
        Me.ButtonItem_CM_Obj.Name = "ButtonItem_CM_Obj"
        Me.ButtonItem_CM_Obj.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_RemoveObj})
        Me.ButtonItem_CM_Obj.Text = "Obj"
        '
        'ButtonItem_RemoveObj
        '
        Me.ButtonItem_RemoveObj.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonItem_RemoveObj.Name = "ButtonItem_RemoveObj"
        Me.ButtonItem_RemoveObj.Text = "Remove"
        '
        'ButtonItem_AddObj
        '
        Me.ButtonItem_AddObj.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.ButtonItem_AddObj.Name = "ButtonItem_AddObj"
        Me.ButtonItem_AddObj.Text = "Add Object Name"
        '
        'ButtonItem_AddCmd
        '
        Me.ButtonItem_AddCmd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.ButtonItem_AddCmd.Name = "ButtonItem_AddCmd"
        Me.ButtonItem_AddCmd.Text = "Add Command"
        '
        'ButtonItem_AddObd
        '
        Me.ButtonItem_AddObd.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.ButtonItem_AddObd.Name = "ButtonItem_AddObd"
        Me.ButtonItem_AddObd.Text = "Add Object Bank Data"
        '
        'ObjectBankDataEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 661)
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.ObdTree)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ObjectBankDataEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Object Bank Data Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.ObdTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ObdTree As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem_CM_Cmd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_CM_Cmds As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_CM_Objs As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_CM_Obj As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_CM_Obd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_CM_ObdList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveObj As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveCmd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveObd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveObdList As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_AddObj As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_AddCmd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_AddObd As DevComponents.DotNetBar.ButtonItem
End Class
