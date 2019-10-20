Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TweakProfileEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TweakProfileEditor))
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutSpacerItem1 = New DevComponents.DotNetBar.Layout.LayoutSpacerItem()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(4, 21)
        Me.TextBoxX1.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(367, 20)
        Me.TextBoxX1.TabIndex = 0
        '
        'TextBoxX2
        '
        Me.TextBoxX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX2.Location = New System.Drawing.Point(4, 66)
        Me.TextBoxX2.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxX2.Multiline = True
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.PreventEnterBeep = True
        Me.TextBoxX2.Size = New System.Drawing.Size(367, 204)
        Me.TextBoxX2.TabIndex = 1
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonX2.Image = Global.PatchScripts.MyIcons.icons8_checkmark_16px
        Me.ButtonX2.Location = New System.Drawing.Point(213, 278)
        Me.ButtonX2.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(75, 24)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
        Me.ButtonX2.TabIndex = 3
        Me.ButtonX2.Text = "Okay"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX1.Image = Global.PatchScripts.MyIcons.icons8_delete_sign_16px_1
        Me.ButtonX1.Location = New System.Drawing.Point(296, 278)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 24)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        Me.ButtonX1.TabIndex = 4
        Me.ButtonX1.Text = "Cancel"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControl1.Controls.Add(Me.TextBoxX1)
        Me.LayoutControl1.Controls.Add(Me.TextBoxX2)
        Me.LayoutControl1.Controls.Add(Me.ButtonX2)
        Me.LayoutControl1.Controls.Add(Me.ButtonX1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutSpacerItem1, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControl1.Size = New System.Drawing.Size(375, 306)
        Me.LayoutControl1.TabIndex = 5
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextBoxX1
        Me.LayoutControlItem1.Height = 45
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "Name:"
        Me.LayoutControlItem1.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutControlItem1.Width = 100
        Me.LayoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextBoxX2
        Me.LayoutControlItem2.Height = 229
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Text = "Description:"
        Me.LayoutControlItem2.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
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
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ButtonX2
        Me.LayoutControlItem3.Height = 31
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Width = 83
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ButtonX1
        Me.LayoutControlItem4.Height = 31
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Width = 83
        '
        'TweakProfileEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 306)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TweakProfileEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tweak Editor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.LayoutControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Private WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LayoutControl1 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutSpacerItem1 As DevComponents.DotNetBar.Layout.LayoutSpacerItem
    Friend WithEvents LayoutControlItem3 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
End Class
