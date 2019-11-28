<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextureGraphicFormatEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextureGraphicFormatEditor))
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_SaveColsettings = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_ColType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX_CollisionType = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_MaxPixels = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_EnableTextureAnimation = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ComboBoxEx_SelectDisplaylist = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX_EnableMirrorS = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_EnableClampS = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_EnableCrystalEffect = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx_RotateFlip = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CheckBoxX_EnableClampT = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_EnableMirrorT = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuBar1 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem_CM_SelDL = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem_EditCustomDisplaylists = New DevComponents.DotNetBar.ButtonItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewEx1
        '
        resources.ApplyResources(Me.ListViewEx1, "ListViewEx1")
        Me.ListViewEx1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.FocusCuesEnabled = False
        Me.ListViewEx1.ForeColor = System.Drawing.Color.Black
        Me.ListViewEx1.FullRowSelect = True
        Me.ListViewEx1.HideSelection = False
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        '
        'LabelX48
        '
        '
        '
        '
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX48, "LabelX48")
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Button_SaveColsettings
        '
        Me.Button_SaveColsettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_SaveColsettings, "Button_SaveColsettings")
        Me.Button_SaveColsettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_SaveColsettings.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_SaveColsettings.FocusCuesEnabled = False
        Me.Button_SaveColsettings.Name = "Button_SaveColsettings"
        Me.Button_SaveColsettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_ColType
        '
        resources.ApplyResources(Me.ComboBox_ColType, "ComboBox_ColType")
        Me.ComboBox_ColType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_ColType.DropDownHeight = 150
        Me.ComboBox_ColType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_ColType.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_ColType.FormattingEnabled = True
        Me.ComboBox_ColType.Name = "ComboBox_ColType"
        Me.ComboBox_ColType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX_CollisionType
        '
        resources.ApplyResources(Me.LabelX_CollisionType, "LabelX_CollisionType")
        '
        '
        '
        Me.LabelX_CollisionType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_CollisionType.Name = "LabelX_CollisionType"
        Me.LabelX_CollisionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'LabelX_MaxPixels
        '
        resources.ApplyResources(Me.LabelX_MaxPixels, "LabelX_MaxPixels")
        '
        '
        '
        Me.LabelX_MaxPixels.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_MaxPixels.Name = "LabelX_MaxPixels"
        '
        'LabelX1
        '
        resources.ApplyResources(Me.LabelX1, "LabelX1")
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Name = "LabelX1"
        '
        'CheckBoxX_EnableTextureAnimation
        '
        resources.ApplyResources(Me.CheckBoxX_EnableTextureAnimation, "CheckBoxX_EnableTextureAnimation")
        '
        '
        '
        Me.CheckBoxX_EnableTextureAnimation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableTextureAnimation.FocusCuesEnabled = False
        Me.CheckBoxX_EnableTextureAnimation.Name = "CheckBoxX_EnableTextureAnimation"
        Me.CheckBoxX_EnableTextureAnimation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBoxEx_SelectDisplaylist
        '
        resources.ApplyResources(Me.ComboBoxEx_SelectDisplaylist, "ComboBoxEx_SelectDisplaylist")
        Me.ContextMenuBar1.SetContextMenuEx(Me.ComboBoxEx_SelectDisplaylist, Me.ButtonItem_CM_SelDL)
        Me.ComboBoxEx_SelectDisplaylist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_SelectDisplaylist.DropDownHeight = 150
        Me.ComboBoxEx_SelectDisplaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_SelectDisplaylist.DropDownWidth = 170
        Me.ComboBoxEx_SelectDisplaylist.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_SelectDisplaylist.FormattingEnabled = True
        Me.ComboBoxEx_SelectDisplaylist.Name = "ComboBoxEx_SelectDisplaylist"
        Me.ComboBoxEx_SelectDisplaylist.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX2
        '
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'CheckBoxX_EnableMirrorS
        '
        resources.ApplyResources(Me.CheckBoxX_EnableMirrorS, "CheckBoxX_EnableMirrorS")
        '
        '
        '
        Me.CheckBoxX_EnableMirrorS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableMirrorS.FocusCuesEnabled = False
        Me.CheckBoxX_EnableMirrorS.Name = "CheckBoxX_EnableMirrorS"
        Me.CheckBoxX_EnableMirrorS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_EnableClampS
        '
        resources.ApplyResources(Me.CheckBoxX_EnableClampS, "CheckBoxX_EnableClampS")
        '
        '
        '
        Me.CheckBoxX_EnableClampS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableClampS.FocusCuesEnabled = False
        Me.CheckBoxX_EnableClampS.Name = "CheckBoxX_EnableClampS"
        Me.CheckBoxX_EnableClampS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_EnableCrystalEffect
        '
        resources.ApplyResources(Me.CheckBoxX_EnableCrystalEffect, "CheckBoxX_EnableCrystalEffect")
        '
        '
        '
        Me.CheckBoxX_EnableCrystalEffect.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableCrystalEffect.FocusCuesEnabled = False
        Me.CheckBoxX_EnableCrystalEffect.Name = "CheckBoxX_EnableCrystalEffect"
        Me.CheckBoxX_EnableCrystalEffect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX3
        '
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Name = "LabelX3"
        '
        'ComboBoxEx_RotateFlip
        '
        resources.ApplyResources(Me.ComboBoxEx_RotateFlip, "ComboBoxEx_RotateFlip")
        Me.ComboBoxEx_RotateFlip.DisplayMember = "Text"
        Me.ComboBoxEx_RotateFlip.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx_RotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx_RotateFlip.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx_RotateFlip.FormattingEnabled = True
        Me.ComboBoxEx_RotateFlip.Name = "ComboBoxEx_RotateFlip"
        Me.ComboBoxEx_RotateFlip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_EnableClampT
        '
        resources.ApplyResources(Me.CheckBoxX_EnableClampT, "CheckBoxX_EnableClampT")
        '
        '
        '
        Me.CheckBoxX_EnableClampT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableClampT.FocusCuesEnabled = False
        Me.CheckBoxX_EnableClampT.Name = "CheckBoxX_EnableClampT"
        Me.CheckBoxX_EnableClampT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_EnableMirrorT
        '
        resources.ApplyResources(Me.CheckBoxX_EnableMirrorT, "CheckBoxX_EnableMirrorT")
        '
        '
        '
        Me.CheckBoxX_EnableMirrorT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableMirrorT.FocusCuesEnabled = False
        Me.CheckBoxX_EnableMirrorT.Name = "CheckBoxX_EnableMirrorT"
        Me.CheckBoxX_EnableMirrorT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX4
        '
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'LabelX5
        '
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'LabelX6
        '
        resources.ApplyResources(Me.LabelX6, "LabelX6")
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'LabelX7
        '
        resources.ApplyResources(Me.LabelX7, "LabelX7")
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CheckBoxX_EnableClampT)
        Me.Panel1.Controls.Add(Me.LabelX48)
        Me.Panel1.Controls.Add(Me.CheckBoxX_EnableMirrorT)
        Me.Panel1.Controls.Add(Me.ComboBoxEx_RotateFlip)
        Me.Panel1.Controls.Add(Me.Button_SaveColsettings)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.CheckBoxX_EnableCrystalEffect)
        Me.Panel1.Controls.Add(Me.LabelX_CollisionType)
        Me.Panel1.Controls.Add(Me.CheckBoxX_EnableClampS)
        Me.Panel1.Controls.Add(Me.ComboBox_ColType)
        Me.Panel1.Controls.Add(Me.CheckBoxX_EnableMirrorS)
        Me.Panel1.Controls.Add(Me.LabelX_MaxPixels)
        Me.Panel1.Controls.Add(Me.ComboBoxEx_SelectDisplaylist)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.LabelX7)
        Me.Panel1.Controls.Add(Me.CheckBoxX_EnableTextureAnimation)
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.LabelX6)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.ListViewEx1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'ContextMenuBar1
        '
        Me.ContextMenuBar1.AntiAlias = True
        resources.ApplyResources(Me.ContextMenuBar1, "ContextMenuBar1")
        Me.ContextMenuBar1.IsMaximized = False
        Me.ContextMenuBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_CM_SelDL})
        Me.ContextMenuBar1.Name = "ContextMenuBar1"
        Me.ContextMenuBar1.Stretch = True
        Me.ContextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar1.TabStop = False
        '
        'ButtonItem_CM_SelDL
        '
        Me.ButtonItem_CM_SelDL.AutoExpandOnClick = True
        Me.ButtonItem_CM_SelDL.Name = "ButtonItem_CM_SelDL"
        Me.ButtonItem_CM_SelDL.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem_EditCustomDisplaylists})
        resources.ApplyResources(Me.ButtonItem_CM_SelDL, "ButtonItem_CM_SelDL")
        '
        'ButtonItem1
        '
        Me.ButtonItem_EditCustomDisplaylists.Image = Global.SM64_ROM_Manager.ModelConverterGUI.My.Resources.Resources.icons8_edit_16px
        Me.ButtonItem_EditCustomDisplaylists.Name = "ButtonItem1"
        resources.ApplyResources(Me.ButtonItem_EditCustomDisplaylists, "ButtonItem1")
        '
        'TextureGraphicFormatEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ContextMenuBar1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextureGraphicFormatEditor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.ContextMenuBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Button_SaveColsettings As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_ColType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX_CollisionType As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_MaxPixels As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX_EnableTextureAnimation As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ComboBoxEx_SelectDisplaylist As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX_EnableMirrorS As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_EnableClampS As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_EnableCrystalEffect As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx_RotateFlip As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CheckBoxX_EnableClampT As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_EnableMirrorT As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents ContextMenuBar1 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem_CM_SelDL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem_EditCustomDisplaylists As DevComponents.DotNetBar.ButtonItem
End Class
