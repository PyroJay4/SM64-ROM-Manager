<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ObjectCatalog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObjectCatalog))
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.ImageList_RefSymbols = New System.Windows.Forms.ImageList(Me.components)
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.TableLayoutPanel_2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel_1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelX_MemberInfo = New DevComponents.DotNetBar.LabelX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel_2.SuspendLayout()
        Me.TableLayoutPanel_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewEx1
        '
        Me.ListViewEx1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx1.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx1.HideSelection = False
        Me.ListViewEx1.Location = New System.Drawing.Point(400, 3)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(391, 358)
        Me.ListViewEx1.TabIndex = 0
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
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
        Me.AdvTree1.DragDropEnabled = False
        Me.AdvTree1.DragDropNodeCopyEnabled = False
        Me.AdvTree1.ImageList = Me.ImageList_RefSymbols
        Me.AdvTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.AdvTree1.Location = New System.Drawing.Point(3, 3)
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.Size = New System.Drawing.Size(391, 358)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.TabIndex = 1
        Me.AdvTree1.Text = "AdvTree1"
        '
        'ImageList_RefSymbols
        '
        Me.ImageList_RefSymbols.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList_RefSymbols.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList_RefSymbols.TransparentColor = System.Drawing.Color.Transparent
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
        'TableLayoutPanel_2
        '
        Me.TableLayoutPanel_2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel_2.ColumnCount = 2
        Me.TableLayoutPanel_2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel_2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel_2.Controls.Add(Me.AdvTree1, 0, 0)
        Me.TableLayoutPanel_2.Controls.Add(Me.ListViewEx1, 1, 0)
        Me.TableLayoutPanel_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel_2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel_2.Name = "TableLayoutPanel_2"
        Me.TableLayoutPanel_2.RowCount = 1
        Me.TableLayoutPanel_2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel_2.Size = New System.Drawing.Size(794, 364)
        Me.TableLayoutPanel_2.TabIndex = 2
        '
        'TableLayoutPanel_1
        '
        Me.TableLayoutPanel_1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel_1.ColumnCount = 1
        Me.TableLayoutPanel_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_1.Controls.Add(Me.TableLayoutPanel_2, 0, 0)
        Me.TableLayoutPanel_1.Controls.Add(Me.LabelX_MemberInfo, 0, 1)
        Me.TableLayoutPanel_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel_1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel_1.Name = "TableLayoutPanel_1"
        Me.TableLayoutPanel_1.RowCount = 2
        Me.TableLayoutPanel_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel_1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel_1.TabIndex = 3
        Me.TableLayoutPanel_1.Visible = False
        '
        'LabelX_MemberInfo
        '
        '
        '
        '
        Me.LabelX_MemberInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_MemberInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelX_MemberInfo.Location = New System.Drawing.Point(3, 373)
        Me.LabelX_MemberInfo.Name = "LabelX_MemberInfo"
        Me.LabelX_MemberInfo.Size = New System.Drawing.Size(794, 74)
        Me.LabelX_MemberInfo.TabIndex = 3
        Me.LabelX_MemberInfo.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(363, 188)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.CircularProgress1.SetVisibleStateOnStart = True
        Me.CircularProgress1.SetVisibleStateOnStop = True
        Me.CircularProgress1.Size = New System.Drawing.Size(75, 75)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 5
        '
        'ObjectCatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CircularProgress1)
        Me.Controls.Add(Me.TableLayoutPanel_1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ObjectCatalog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Object Catalog"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel_2.ResumeLayout(False)
        Me.TableLayoutPanel_1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents TableLayoutPanel_2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel_1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents ImageList_RefSymbols As Windows.Forms.ImageList
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents LabelX_MemberInfo As DevComponents.DotNetBar.LabelX
End Class
