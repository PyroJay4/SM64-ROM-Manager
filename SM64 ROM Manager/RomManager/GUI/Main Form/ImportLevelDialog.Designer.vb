<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportLevelDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportLevelDialog))
        Me.ButtonX_Import = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX_Romfile = New DevComponents.DotNetBar.LabelX()
        Me.ItemListBox1 = New Publics.Controls.ItemListBox()
        Me.SuspendLayout()
        '
        'ButtonX_Import
        '
        Me.ButtonX_Import.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Import.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX_Import.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Import.Enabled = False
        Me.ButtonX_Import.FocusCuesEnabled = False
        Me.ButtonX_Import.Location = New System.Drawing.Point(276, 12)
        Me.ButtonX_Import.Name = "ButtonX_Import"
        Me.ButtonX_Import.Size = New System.Drawing.Size(96, 23)
        Me.ButtonX_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Import.TabIndex = 2
        Me.ButtonX_Import.Text = "Import Level"
        '
        'LabelX_Romfile
        '
        Me.LabelX_Romfile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.LabelX_Romfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Romfile.Location = New System.Drawing.Point(12, 12)
        Me.LabelX_Romfile.Name = "LabelX_Romfile"
        Me.LabelX_Romfile.Size = New System.Drawing.Size(258, 23)
        Me.LabelX_Romfile.TabIndex = 3
        Me.LabelX_Romfile.Text = "Please open a ROM file!"
        '
        'ItemListBox1
        '
        Me.ItemListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemListBox1.AutoScroll = True
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemListBox1.Location = New System.Drawing.Point(12, 41)
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Size = New System.Drawing.Size(360, 208)
        Me.ItemListBox1.TabIndex = 1
        Me.ItemListBox1.Text = "ItemListBox1"
        '
        'ImportLevelDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.LabelX_Romfile)
        Me.Controls.Add(Me.ButtonX_Import)
        Me.Controls.Add(Me.ItemListBox1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ImportLevelDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Levels"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItemListBox1 As Publics.Controls.ItemListBox
    Friend WithEvents ButtonX_Import As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX_Romfile As DevComponents.DotNetBar.LabelX
End Class
