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
        CType(Me.ObdTree, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ObjectBankDataEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 661)
        Me.Controls.Add(Me.ObdTree)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ObjectBankDataEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Object Bank Data Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.ObdTree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ObdTree As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
End Class
