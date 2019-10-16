<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CollisionEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CollisionEditor))
        Me.TextBoxX_ColParam2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX_ColParam1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX_ColParamsTipp = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Param2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Param1 = New DevComponents.DotNetBar.LabelX()
        Me.Button_SaveColsettings = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.ComboBox_ColType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX_CollisionType = New DevComponents.DotNetBar.LabelX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxX_IsNonSolid = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxX_ColParam2
        '
        resources.ApplyResources(Me.TextBoxX_ColParam2, "TextBoxX_ColParam2")
        Me.TextBoxX_ColParam2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ColParam2.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ColParam2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ColParam2.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ColParam2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ColParam2.Name = "TextBoxX_ColParam2"
        Me.TextBoxX_ColParam2.PreventEnterBeep = True
        '
        'TextBoxX_ColParam1
        '
        resources.ApplyResources(Me.TextBoxX_ColParam1, "TextBoxX_ColParam1")
        Me.TextBoxX_ColParam1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_ColParam1.Border.Class = "TextBoxBorder"
        Me.TextBoxX_ColParam1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_ColParam1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_ColParam1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_ColParam1.Name = "TextBoxX_ColParam1"
        Me.TextBoxX_ColParam1.PreventEnterBeep = True
        '
        'LabelX_ColParamsTipp
        '
        resources.ApplyResources(Me.LabelX_ColParamsTipp, "LabelX_ColParamsTipp")
        '
        '
        '
        Me.LabelX_ColParamsTipp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_ColParamsTipp.Name = "LabelX_ColParamsTipp"
        Me.LabelX_ColParamsTipp.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.LabelX_ColParamsTipp.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'LabelX_Param2
        '
        resources.ApplyResources(Me.LabelX_Param2, "LabelX_Param2")
        '
        '
        '
        Me.LabelX_Param2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Param2.Name = "LabelX_Param2"
        Me.LabelX_Param2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'LabelX_Param1
        '
        resources.ApplyResources(Me.LabelX_Param1, "LabelX_Param1")
        '
        '
        '
        Me.LabelX_Param1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Param1.Name = "LabelX_Param1"
        Me.LabelX_Param1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
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
        'CheckBoxX1
        '
        resources.ApplyResources(Me.CheckBoxX1, "CheckBoxX1")
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.FocusCuesEnabled = False
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TextBoxX1
        '
        resources.ApplyResources(Me.TextBoxX1, "TextBoxX1")
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
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
        'SuperTooltip1
        '
        resources.ApplyResources(Me.SuperTooltip1, "SuperTooltip1")
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX_CollisionType)
        Me.Panel1.Controls.Add(Me.ComboBox_ColType)
        Me.Panel1.Controls.Add(Me.LabelX_Param2)
        Me.Panel1.Controls.Add(Me.LabelX_ColParamsTipp)
        Me.Panel1.Controls.Add(Me.LabelX_Param1)
        Me.Panel1.Controls.Add(Me.TextBoxX_ColParam1)
        Me.Panel1.Controls.Add(Me.CheckBoxX1)
        Me.Panel1.Controls.Add(Me.TextBoxX_ColParam2)
        Me.Panel1.Controls.Add(Me.TextBoxX1)
        Me.Panel1.Name = "Panel1"
        '
        'CheckBoxX_IsNonSolid
        '
        resources.ApplyResources(Me.CheckBoxX_IsNonSolid, "CheckBoxX_IsNonSolid")
        '
        '
        '
        Me.CheckBoxX_IsNonSolid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX_IsNonSolid.FocusCuesEnabled = False
        Me.CheckBoxX_IsNonSolid.Name = "CheckBoxX_IsNonSolid"
        Me.CheckBoxX_IsNonSolid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'CircularProgress1
        '
        resources.ApplyResources(Me.CircularProgress1, "CircularProgress1")
        Me.CircularProgress1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.SetVisibleStateOnStart = True
        Me.CircularProgress1.SetVisibleStateOnStop = True
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LabelX48)
        Me.Panel2.Controls.Add(Me.CircularProgress1)
        Me.Panel2.Controls.Add(Me.Button_SaveColsettings)
        Me.Panel2.Controls.Add(Me.CheckBoxX_IsNonSolid)
        Me.Panel2.Controls.Add(Me.ListViewEx1)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'CollisionEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CollisionEditor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxX_ColParam2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX_ColParam1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX_ColParamsTipp As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Param2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Param1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_SaveColsettings As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBox_ColType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX_CollisionType As DevComponents.DotNetBar.LabelX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents CheckBoxX_IsNonSolid As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Panel2 As Windows.Forms.Panel
End Class
