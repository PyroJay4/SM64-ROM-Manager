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
        Me.ButtonX_CreateNewObject = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_RemoveObject = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX_ModelID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX_ImportModel = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LayoutControl1 = New DevComponents.DotNetBar.Layout.LayoutControl()
        Me.TextBoxX_Name = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX_CollisionPointerDestinationsCount = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX_EditCollisionPointerDestinations = New DevComponents.DotNetBar.ButtonX()
        Me.LayoutControlItem3 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutGroup_ModelInfo = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutControlItem2 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutGroup_CollisionPointerDestinations = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutControlItem5 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.CM_Object = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportModell = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportVisualMap = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ImportCollision = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveCollision = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ShowVisualMap = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_ShowCollision = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_CopyCollisionPointer = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_RemoveObject = New DevComponents.DotNetBar.ButtonItem()
        Me.Panel1.SuspendLayout()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemListBox1
        '
        '
        '
        '
        Me.ItemListBox1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemListBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemListBox1.ContainerControlProcessDialogKey = True
        resources.ApplyResources(Me.ItemListBox1, "ItemListBox1")
        Me.ItemListBox1.DragDropSupport = True
        Me.ItemListBox1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemListBox1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemListBox1.Name = "ItemListBox1"
        Me.ItemListBox1.ReserveLeftSpace = False
        Me.ItemListBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ButtonX_CreateNewObject
        '
        Me.ButtonX_CreateNewObject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX_CreateNewObject, "ButtonX_CreateNewObject")
        Me.ButtonX_CreateNewObject.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.ButtonX_CreateNewObject.FocusCuesEnabled = False
        Me.ButtonX_CreateNewObject.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.ButtonX_CreateNewObject.Name = "ButtonX_CreateNewObject"
        Me.ButtonX_CreateNewObject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_CreateNewObject.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_CreateNewObject.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_CreateNewObject.SymbolSize = 12.0!
        '
        'ButtonX_RemoveObject
        '
        Me.ButtonX_RemoveObject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX_RemoveObject, "ButtonX_RemoveObject")
        Me.ButtonX_RemoveObject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_RemoveObject.FocusCuesEnabled = False
        Me.ButtonX_RemoveObject.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonX_RemoveObject.Name = "ButtonX_RemoveObject"
        Me.ButtonX_RemoveObject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_RemoveObject.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX_RemoveObject.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_RemoveObject.SymbolSize = 12.0!
        '
        'TextBoxX_ModelID
        '
        Me.TextBoxX_ModelID.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ModelID.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ModelID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ModelID.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ModelID.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_ModelID, "TextBoxX_ModelID")
        Me.TextBoxX_ModelID.Name = "TextBoxX_ModelID"
        Me.TextBoxX_ModelID.PreventEnterBeep = True
        '
        'ButtonX_ImportModel
        '
        Me.ButtonX_ImportModel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.ButtonX_ImportModel, "ButtonX_ImportModel")
        Me.ButtonX_ImportModel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_ImportModel.FocusCuesEnabled = False
        Me.ButtonX_ImportModel.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_import_16px
        Me.ButtonX_ImportModel.Name = "ButtonX_ImportModel"
        Me.ButtonX_ImportModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ButtonX_CreateNewObject)
        Me.Panel1.Controls.Add(Me.ItemListBox1)
        Me.Panel1.Controls.Add(Me.LayoutControl1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LayoutControl1.Controls.Add(Me.TextBoxX_ModelID)
        Me.LayoutControl1.Controls.Add(Me.TextBoxX_Name)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_ImportModel)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_RemoveObject)
        Me.LayoutControl1.Controls.Add(Me.LabelX_CollisionPointerDestinationsCount)
        Me.LayoutControl1.Controls.Add(Me.ButtonX_EditCollisionPointerDestinations)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.ForeColor = System.Drawing.Color.Black
        Me.LayoutControl1.Name = "LayoutControl1"
        '
        '
        '
        Me.LayoutControl1.RootGroup.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutGroup_ModelInfo, Me.LayoutGroup_CollisionPointerDestinations})
        '
        'TextBoxX_Name
        '
        Me.TextBoxX_Name.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_Name.Border.Class = "TextBoxBorder"
        Me.TextBoxX_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_Name.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_Name.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_Name, "TextBoxX_Name")
        Me.TextBoxX_Name.Name = "TextBoxX_Name"
        Me.TextBoxX_Name.PreventEnterBeep = True
        '
        'LabelX_CollisionPointerDestinationsCount
        '
        '
        '
        '
        Me.LabelX_CollisionPointerDestinationsCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_CollisionPointerDestinationsCount, "LabelX_CollisionPointerDestinationsCount")
        Me.LabelX_CollisionPointerDestinationsCount.Name = "LabelX_CollisionPointerDestinationsCount"
        Me.LabelX_CollisionPointerDestinationsCount.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ButtonX_EditCollisionPointerDestinations
        '
        Me.ButtonX_EditCollisionPointerDestinations.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_EditCollisionPointerDestinations.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_EditCollisionPointerDestinations.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        resources.ApplyResources(Me.ButtonX_EditCollisionPointerDestinations, "ButtonX_EditCollisionPointerDestinations")
        Me.ButtonX_EditCollisionPointerDestinations.Name = "ButtonX_EditCollisionPointerDestinations"
        Me.ButtonX_EditCollisionPointerDestinations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ButtonX_ImportModel
        Me.LayoutControlItem3.Height = 31
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Width = 99
        Me.LayoutControlItem3.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ButtonX_RemoveObject
        Me.LayoutControlItem4.Height = 31
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Width = 31
        '
        'LayoutGroup_ModelInfo
        '
        Me.LayoutGroup_ModelInfo.Height = 57
        Me.LayoutGroup_ModelInfo.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem2, Me.LayoutControlItem1})
        Me.LayoutGroup_ModelInfo.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup_ModelInfo.Name = "LayoutGroup_ModelInfo"
        Me.LayoutGroup_ModelInfo.Padding = New System.Windows.Forms.Padding(0)
        Me.LayoutGroup_ModelInfo.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup_ModelInfo.Width = 100
        Me.LayoutGroup_ModelInfo.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextBoxX_Name
        Me.LayoutControlItem2.Height = 28
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        resources.ApplyResources(Me.LayoutControlItem2, "LayoutControlItem2")
        Me.LayoutControlItem2.Width = 100
        Me.LayoutControlItem2.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextBoxX_ModelID
        Me.LayoutControlItem1.Height = 28
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.Width = 100
        Me.LayoutControlItem1.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutGroup_CollisionPointerDestinations
        '
        Me.LayoutGroup_CollisionPointerDestinations.Height = 35
        Me.LayoutGroup_CollisionPointerDestinations.Items.AddRange(New DevComponents.DotNetBar.Layout.LayoutItemBase() {Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutGroup_CollisionPointerDestinations.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup_CollisionPointerDestinations.Name = "LayoutGroup_CollisionPointerDestinations"
        Me.LayoutGroup_CollisionPointerDestinations.Padding = New System.Windows.Forms.Padding(0)
        Me.LayoutGroup_CollisionPointerDestinations.TextPadding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.LayoutGroup_CollisionPointerDestinations.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup_CollisionPointerDestinations.Width = 100
        Me.LayoutGroup_CollisionPointerDestinations.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LabelX_CollisionPointerDestinationsCount
        Me.LayoutControlItem5.Height = 31
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        resources.ApplyResources(Me.LayoutControlItem5, "LayoutControlItem5")
        Me.LayoutControlItem5.Width = 99
        Me.LayoutControlItem5.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.ButtonX_EditCollisionPointerDestinations
        Me.LayoutControlItem6.Height = 31
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(32, 20)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Width = 90
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
        Me.CM_Object.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_ImportModell, Me.ButtonItem_ImportVisualMap, Me.ButtonItem_ImportCollision, Me.ButtonItem_RemoveCollision, Me.ButtonItem_ShowVisualMap, Me.ButtonItem_ShowCollision, Me.ButtonItem_CopyCollisionPointer, Me.ButtonItem_RemoveObject})
        resources.ApplyResources(Me.CM_Object, "CM_Object")
        '
        'ButtonItem_ImportModell
        '
        Me.ButtonItem_ImportModell.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_import_16px
        Me.ButtonItem_ImportModell.Name = "ButtonItem_ImportModell"
        resources.ApplyResources(Me.ButtonItem_ImportModell, "ButtonItem_ImportModell")
        '
        'ButtonItem_ImportVisualMap
        '
        Me.ButtonItem_ImportVisualMap.Image = CType(resources.GetObject("ButtonItem_ImportVisualMap.Image"), System.Drawing.Image)
        Me.ButtonItem_ImportVisualMap.Name = "ButtonItem_ImportVisualMap"
        resources.ApplyResources(Me.ButtonItem_ImportVisualMap, "ButtonItem_ImportVisualMap")
        '
        'ButtonItem_ImportCollision
        '
        Me.ButtonItem_ImportCollision.Image = CType(resources.GetObject("ButtonItem_ImportCollision.Image"), System.Drawing.Image)
        Me.ButtonItem_ImportCollision.Name = "ButtonItem_ImportCollision"
        resources.ApplyResources(Me.ButtonItem_ImportCollision, "ButtonItem_ImportCollision")
        '
        'ButtonItem_RemoveCollision
        '
        Me.ButtonItem_RemoveCollision.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_2_16px
        Me.ButtonItem_RemoveCollision.Name = "ButtonItem_RemoveCollision"
        resources.ApplyResources(Me.ButtonItem_RemoveCollision, "ButtonItem_RemoveCollision")
        '
        'ButtonItem_ShowVisualMap
        '
        Me.ButtonItem_ShowVisualMap.BeginGroup = True
        Me.ButtonItem_ShowVisualMap.Image = CType(resources.GetObject("ButtonItem_ShowVisualMap.Image"), System.Drawing.Image)
        Me.ButtonItem_ShowVisualMap.Name = "ButtonItem_ShowVisualMap"
        resources.ApplyResources(Me.ButtonItem_ShowVisualMap, "ButtonItem_ShowVisualMap")
        '
        'ButtonItem_ShowCollision
        '
        Me.ButtonItem_ShowCollision.Image = CType(resources.GetObject("ButtonItem_ShowCollision.Image"), System.Drawing.Image)
        Me.ButtonItem_ShowCollision.Name = "ButtonItem_ShowCollision"
        resources.ApplyResources(Me.ButtonItem_ShowCollision, "ButtonItem_ShowCollision")
        '
        'ButtonItem_CopyCollisionPointer
        '
        Me.ButtonItem_CopyCollisionPointer.BeginGroup = True
        Me.ButtonItem_CopyCollisionPointer.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_copy_16px
        Me.ButtonItem_CopyCollisionPointer.Name = "ButtonItem_CopyCollisionPointer"
        resources.ApplyResources(Me.ButtonItem_CopyCollisionPointer, "ButtonItem_CopyCollisionPointer")
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
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ItemListBox1 As Publics.Controls.ItemListBox
    Friend WithEvents ButtonX_CreateNewObject As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_RemoveObject As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBoxX_ModelID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX_ImportModel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents CM_Object As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ShowVisualMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ShowCollision As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveObject As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ImportModell As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_RemoveCollision As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ImportVisualMap As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_ImportCollision As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_CopyCollisionPointer As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LayoutControl1 As DevComponents.DotNetBar.Layout.LayoutControl
    Friend WithEvents TextBoxX_Name As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LayoutControlItem2 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutGroup_ModelInfo As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutGroup_CollisionPointerDestinations As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents ButtonX_EditCollisionPointerDestinations As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX_CollisionPointerDestinationsCount As DevComponents.DotNetBar.LabelX
    Friend WithEvents LayoutControlItem5 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevComponents.DotNetBar.Layout.LayoutControlItem
End Class
