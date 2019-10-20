<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomBankManager
    Inherits DevComponents.DotNetBar.OfficeForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomBankManager))
        Me.ItemListBox1 = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.CM_Object = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportModell = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportVisualMap = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportCollision = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveCollision = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ShowVisualMap = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ShowCollision = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveObject = New DevComponents.DotNetBar.ButtonItem()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemListBox1
        '
        resources.ApplyResources(Me.ItemListBox1, "ItemListBox1")
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX2, "ButtonX2")
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.FocusCuesEnabled = False
        Me.ButtonX2.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX2.SymbolSize = 12.0!
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
        resources.ApplyResources(Me.TextBoxX1, "TextBoxX1")
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX3, "ButtonX3")
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.FocusCuesEnabled = False
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Controls.Add(Me.ItemListBox1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.ButtonX3)
        Me.Panel2.Controls.Add(Me.ButtonX2)
        Me.Panel2.Controls.Add(Me.LabelX1)
        Me.Panel2.Controls.Add(Me.TextBoxX1)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        Me.LabelX1.Name = "LabelX1"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        resources.ApplyResources(Me.ContextMenuBar1, "ContextMenuBar1")
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CM_Object})
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabStop = False
        '
        'CM_Object
        '
        Me.CM_Object.AutoExpandOnClick = True
        Me.CM_Object.Name = "CM_Object"
        Me.CM_Object.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ImportModell, Me.ButtonItem_ImportVisualMap, Me.ButtonItem_ImportCollision, Me.ButtonItem_RemoveCollision, Me.ButtonItem_ShowVisualMap, Me.ButtonItem_ShowCollision, Me.ButtonItem_RemoveObject})
        resources.ApplyResources(Me.CM_Object, "CM_Object")
        '
        'ButtonItem_ImportModell
        '
        Me.ButtonItem_ImportModell.Name = "ButtonItem_ImportModell"
        resources.ApplyResources(Me.ButtonItem_ImportModell, "ButtonItem_ImportModell")
        '
        'ButtonItem_ImportVisualMap
        '
        Me.ButtonItem_ImportVisualMap.Name = "ButtonItem_ImportVisualMap"
        resources.ApplyResources(Me.ButtonItem_ImportVisualMap, "ButtonItem_ImportVisualMap")
        '
        'ButtonItem_ImportCollision
        '
        Me.ButtonItem_ImportCollision.Name = "ButtonItem_ImportCollision"
        resources.ApplyResources(Me.ButtonItem_ImportCollision, "ButtonItem_ImportCollision")
        '
        'ButtonItem_RemoveCollision
        '
        Me.ButtonItem_RemoveCollision.Name = "ButtonItem_RemoveCollision"
        resources.ApplyResources(Me.ButtonItem_RemoveCollision, "ButtonItem_RemoveCollision")
        '
        'ButtonItem_ShowVisualMap
        '
        Me.ButtonItem_ShowVisualMap.BeginGroup = True
        Me.ButtonItem_ShowVisualMap.Name = "ButtonItem_ShowVisualMap"
        resources.ApplyResources(Me.ButtonItem_ShowVisualMap, "ButtonItem_ShowVisualMap")
        '
        'ButtonItem_ShowCollision
        '
        Me.ButtonItem_ShowCollision.Name = "ButtonItem_ShowCollision"
        resources.ApplyResources(Me.ButtonItem_ShowCollision, "ButtonItem_ShowCollision")
        '
        'ButtonItem_RemoveObject
        '
        Me.ButtonItem_RemoveObject.BeginGroup = True
        Me.ButtonItem_RemoveObject.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonItem_RemoveObject.Name = "ButtonItem_RemoveObject"
        Me.ButtonItem_RemoveObject.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonItem_RemoveObject.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonItem_RemoveObject.SymbolSize = 12.0!
        resources.ApplyResources(Me.ButtonItem_RemoveObject, "ButtonItem_RemoveObject")
        '
        'CustomBankManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "CustomBankManager"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ItemListBox1 As Publics.Controls.ItemListBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents CM_Object As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ShowVisualMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ShowCollision As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveObject As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ImportModell As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveCollision As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ImportVisualMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ImportCollision As DevComponents.DotNetBar.ButtonItem
End Class
