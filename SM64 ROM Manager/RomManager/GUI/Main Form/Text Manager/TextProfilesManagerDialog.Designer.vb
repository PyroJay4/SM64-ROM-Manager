<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextProfilesManagerDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextProfilesManagerDialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBoxX_ProfileName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX_Delete = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Export = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Import = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Edit = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_Create = New DevComponents.DotNetBar.ButtonX()
        Me.ItemPanel_Profiles = New DevComponents.DotNetBar.ItemPanel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TextBoxX_ProfileName)
        Me.Panel1.Controls.Add(Me.ButtonX_Delete)
        Me.Panel1.Controls.Add(Me.ButtonX_Export)
        Me.Panel1.Controls.Add(Me.ButtonX_Import)
        Me.Panel1.Controls.Add(Me.ButtonX_Edit)
        Me.Panel1.Controls.Add(Me.ButtonX_Create)
        Me.Panel1.Controls.Add(Me.ItemPanel_Profiles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(455, 261)
        Me.Panel1.TabIndex = 0
        '
        'TextBoxX_ProfileName
        '
        Me.TextBoxX_ProfileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxX_ProfileName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ProfileName.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ProfileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ProfileName.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ProfileName.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ProfileName.Location = New System.Drawing.Point(3, 32)
        Me.TextBoxX_ProfileName.Name = "TextBoxX_ProfileName"
        Me.TextBoxX_ProfileName.PreventEnterBeep = True
        Me.TextBoxX_ProfileName.Size = New System.Drawing.Size(449, 20)
        Me.TextBoxX_ProfileName.TabIndex = 2
        Me.TextBoxX_ProfileName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.TextBoxX_ProfileName.WatermarkText = "Profile Name"
        '
        'ButtonX_Delete
        '
        Me.ButtonX_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Delete.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_delete_sign_16px
        Me.ButtonX_Delete.Location = New System.Drawing.Point(367, 3)
        Me.ButtonX_Delete.Name = "ButtonX_Delete"
        Me.ButtonX_Delete.Size = New System.Drawing.Size(85, 23)
        Me.ButtonX_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Delete.TabIndex = 1
        Me.ButtonX_Delete.Text = "Delete"
        '
        'ButtonX_Export
        '
        Me.ButtonX_Export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Export.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Export.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_export_16px
        Me.ButtonX_Export.Location = New System.Drawing.Point(185, 3)
        Me.ButtonX_Export.Name = "ButtonX_Export"
        Me.ButtonX_Export.Size = New System.Drawing.Size(85, 23)
        Me.ButtonX_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Export.TabIndex = 1
        Me.ButtonX_Export.Text = "Export"
        '
        'ButtonX_Import
        '
        Me.ButtonX_Import.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Import.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Import.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_import_16px
        Me.ButtonX_Import.Location = New System.Drawing.Point(94, 3)
        Me.ButtonX_Import.Name = "ButtonX_Import"
        Me.ButtonX_Import.Size = New System.Drawing.Size(85, 23)
        Me.ButtonX_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Import.TabIndex = 1
        Me.ButtonX_Import.Text = "Import"
        '
        'ButtonX_Edit
        '
        Me.ButtonX_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Edit.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_edit_16px
        Me.ButtonX_Edit.Location = New System.Drawing.Point(276, 3)
        Me.ButtonX_Edit.Name = "ButtonX_Edit"
        Me.ButtonX_Edit.Size = New System.Drawing.Size(85, 23)
        Me.ButtonX_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Edit.TabIndex = 1
        Me.ButtonX_Edit.Text = "Edit"
        '
        'ButtonX_Create
        '
        Me.ButtonX_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_Create.Image = Global.SM64_ROM_Manager.My.Resources.MyIcons.icons8_plus_math_16px
        Me.ButtonX_Create.Location = New System.Drawing.Point(3, 3)
        Me.ButtonX_Create.Name = "ButtonX_Create"
        Me.ButtonX_Create.Size = New System.Drawing.Size(85, 23)
        Me.ButtonX_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_Create.TabIndex = 1
        Me.ButtonX_Create.Text = "Create"
        '
        'ItemPanel_Profiles
        '
        Me.ItemPanel_Profiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemPanel_Profiles.AutoScroll = True
        '
        '
        '
        Me.ItemPanel_Profiles.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel_Profiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel_Profiles.ContainerControlProcessDialogKey = True
        Me.ItemPanel_Profiles.DragDropSupport = True
        Me.ItemPanel_Profiles.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel_Profiles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel_Profiles.Location = New System.Drawing.Point(3, 58)
        Me.ItemPanel_Profiles.Name = "ItemPanel_Profiles"
        Me.ItemPanel_Profiles.ReserveLeftSpace = False
        Me.ItemPanel_Profiles.Size = New System.Drawing.Size(449, 200)
        Me.ItemPanel_Profiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ItemPanel_Profiles.TabIndex = 0
        Me.ItemPanel_Profiles.Text = "ItemPanel1"
        '
        'TextProfilesManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TextProfilesManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Text Profiles"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonX_Delete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Edit As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Create As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ItemPanel_Profiles As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents TextBoxX_ProfileName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX_Export As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_Import As DevComponents.DotNetBar.ButtonX
End Class
