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
        Me.CheckBoxX_EnableMirror = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_EnableClamp = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX_EnableCrystalEffect = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBoxEx_RotateFlip = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'CheckBoxX_EnableMirror
        '
        resources.ApplyResources(Me.CheckBoxX_EnableMirror, "CheckBoxX_EnableMirror")
        '
        '
        '
        Me.CheckBoxX_EnableMirror.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableMirror.FocusCuesEnabled = False
        Me.CheckBoxX_EnableMirror.Name = "CheckBoxX_EnableMirror"
        Me.CheckBoxX_EnableMirror.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CheckBoxX_EnableClamp
        '
        resources.ApplyResources(Me.CheckBoxX_EnableClamp, "CheckBoxX_EnableClamp")
        '
        '
        '
        Me.CheckBoxX_EnableClamp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_EnableClamp.FocusCuesEnabled = False
        Me.CheckBoxX_EnableClamp.Name = "CheckBoxX_EnableClamp"
        Me.CheckBoxX_EnableClamp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        'TextureGraphicFormatEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ComboBoxEx_RotateFlip)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.CheckBoxX_EnableCrystalEffect)
        Me.Controls.Add(Me.CheckBoxX_EnableClamp)
        Me.Controls.Add(Me.CheckBoxX_EnableMirror)
        Me.Controls.Add(Me.ComboBoxEx_SelectDisplaylist)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.CheckBoxX_EnableTextureAnimation)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX_MaxPixels)
        Me.Controls.Add(Me.ComboBox_ColType)
        Me.Controls.Add(Me.LabelX_CollisionType)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button_SaveColsettings)
        Me.Controls.Add(Me.ListViewEx1)
        Me.Controls.Add(Me.LabelX48)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextureGraphicFormatEditor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CheckBoxX_EnableMirror As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_EnableClamp As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX_EnableCrystalEffect As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx_RotateFlip As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
