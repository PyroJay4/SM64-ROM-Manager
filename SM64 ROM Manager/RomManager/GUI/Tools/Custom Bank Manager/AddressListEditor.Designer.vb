<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddressListEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddressListEditor))
        Me.ItemPanel_Values = New DevComponents.DotNetBar.ItemPanel()
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.TextBoxX_Value = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX_Hinzufügen = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Entfernen = New DevComponents.DotNetBar.ButtonX()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItemPanel_Values
        '
        resources.ApplyResources(Me.ItemPanel_Values, "ItemPanel_Values")
        Me.ItemPanel_Values.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ItemPanel_Values.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel_Values.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel_Values.ContainerControlProcessDialogKey = True
        Me.ItemPanel_Values.DragDropSupport = True
        Me.ItemPanel_Values.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel_Values.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel_Values.Name = "ItemPanel_Values"
        Me.ItemPanel_Values.ReserveLeftSpace = False
        Me.ItemPanel_Values.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControl1.Controls.Add(Me.TextBoxX_Value)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_Hinzufügen)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_Entfernen)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.ForeColor = System.Drawing.Color.Black
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        '
        'TextBoxX_Value
        '
        Me.TextBoxX_Value.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Value.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Value.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Value.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Value.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_Value, "TextBoxX_Value")
        Me.TextBoxX_Value.Name = "TextBoxX_Value"
        Me.TextBoxX_Value.PreventEnterBeep = True
        '
        'ButtonX_Hinzufügen
        '
        Me.ButtonX_Hinzufügen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Hinzufügen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Hinzufügen.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        resources.ApplyResources(Me.ButtonX_Hinzufügen, "ButtonX_Hinzufügen")
        Me.ButtonX_Hinzufügen.Name = "ButtonX_Hinzufügen"
        Me.ButtonX_Hinzufügen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_Entfernen
        '
        Me.ButtonX_Entfernen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Entfernen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Entfernen.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        resources.ApplyResources(Me.ButtonX_Entfernen, "ButtonX_Entfernen")
        Me.ButtonX_Entfernen.Name = "ButtonX_Entfernen"
        Me.ButtonX_Entfernen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextBoxX_Value
        Me.LayoutControlItem1.Height = 28
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Width = 100
        Me.LayoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ButtonX_Hinzufügen
        Me.LayoutControlItem2.Height = 31
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Width = 50
        Me.LayoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ButtonX_Entfernen
        Me.LayoutControlItem3.Height = 31
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Width = 50
        Me.LayoutControlItem3.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'AddressListEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ItemPanel_Values)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "AddressListEditor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.LayoutControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItemPanel_Values As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents LayoutControl1 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents TextBoxX_Value As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX_Hinzufügen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Entfernen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevComponents.DotNetBar.Layout.LayoutControlItem
End Class
