<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_General
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_General))
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ItemPanel_RecentFiles = New DevComponents.DotNetBar.ItemPanel()
        Me.GroupPanel6 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Button_G_SaveGameName = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_G_Filename = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_G_GameName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX_G_Filesize = New DevComponents.DotNetBar.LabelX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel2
        '
        resources.ApplyResources(Me.GroupPanel2, "GroupPanel2")
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ItemPanel_RecentFiles)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Name = "GroupPanel2"
        '
        '
        '
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemPanel_RecentFiles
        '
        resources.ApplyResources(Me.ItemPanel_RecentFiles, "ItemPanel_RecentFiles")
        '
        '
        '
        Me.ItemPanel_RecentFiles.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel_RecentFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel_RecentFiles.ContainerControlProcessDialogKey = True
        Me.ItemPanel_RecentFiles.DragDropSupport = True
        Me.ItemPanel_RecentFiles.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel_RecentFiles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel_RecentFiles.Name = "ItemPanel_RecentFiles"
        Me.ItemPanel_RecentFiles.ReserveLeftSpace = False
        Me.ItemPanel_RecentFiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'GroupPanel6
        '
        resources.ApplyResources(Me.GroupPanel6, "GroupPanel6")
        Me.GroupPanel6.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel6.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel6.Controls.Add(Me.Button_G_SaveGameName)
        Me.GroupPanel6.Controls.Add(Me.LabelX27)
        Me.GroupPanel6.Controls.Add(Me.LabelX_G_Filename)
        Me.GroupPanel6.Controls.Add(Me.TextBoxX_G_GameName)
        Me.GroupPanel6.Controls.Add(Me.LabelX_G_Filesize)
        Me.GroupPanel6.Controls.Add(Me.LabelX34)
        Me.GroupPanel6.Controls.Add(Me.LabelX35)
        Me.GroupPanel6.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel6.Name = "GroupPanel6"
        '
        '
        '
        Me.GroupPanel6.Style.BackColorGradientAngle = 90
        Me.GroupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderBottomWidth = 1
        Me.GroupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderLeftWidth = 1
        Me.GroupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderRightWidth = 1
        Me.GroupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel6.Style.BorderTopWidth = 1
        Me.GroupPanel6.Style.CornerDiameter = 4
        Me.GroupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'Button_G_SaveGameName
        '
        resources.ApplyResources(Me.Button_G_SaveGameName, "Button_G_SaveGameName")
        Me.Button_G_SaveGameName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_G_SaveGameName.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_G_SaveGameName.FocusCuesEnabled = False
        Me.Button_G_SaveGameName.Name = "Button_G_SaveGameName"
        Me.Button_G_SaveGameName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX27
        '
        resources.ApplyResources(Me.LabelX27, "LabelX27")
        '
        '
        '
        Me.LabelX27.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX_G_Filename
        '
        resources.ApplyResources(Me.LabelX_G_Filename, "LabelX_G_Filename")
        Me.LabelX_G_Filename.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_G_Filename.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_G_Filename.Name = "LabelX_G_Filename"
        Me.LabelX_G_Filename.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TextBoxX_G_GameName
        '
        resources.ApplyResources(Me.TextBoxX_G_GameName, "TextBoxX_G_GameName")
        Me.TextBoxX_G_GameName.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_G_GameName.Border.Class = "TextBoxBorder"
        Me.TextBoxX_G_GameName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_G_GameName.ButtonCustom.DisplayPosition = CType(resources.GetObject("TextBoxX_G_GameName.ButtonCustom.DisplayPosition"), Integer)
        Me.TextBoxX_G_GameName.ButtonCustom.Image = CType(resources.GetObject("TextBoxX_G_GameName.ButtonCustom.Image"), System.Drawing.Image)
        Me.TextBoxX_G_GameName.ButtonCustom.Text = resources.GetString("TextBoxX_G_GameName.ButtonCustom.Text")
        Me.TextBoxX_G_GameName.ButtonCustom.Tooltip = resources.GetString("TextBoxX_G_GameName.ButtonCustom.Tooltip")
        Me.TextBoxX_G_GameName.ButtonCustom2.DisplayPosition = CType(resources.GetObject("TextBoxX_G_GameName.ButtonCustom2.DisplayPosition"), Integer)
        Me.TextBoxX_G_GameName.ButtonCustom2.Image = CType(resources.GetObject("TextBoxX_G_GameName.ButtonCustom2.Image"), System.Drawing.Image)
        Me.TextBoxX_G_GameName.ButtonCustom2.Text = resources.GetString("TextBoxX_G_GameName.ButtonCustom2.Text")
        Me.TextBoxX_G_GameName.ButtonCustom2.Tooltip = resources.GetString("TextBoxX_G_GameName.ButtonCustom2.Tooltip")
        Me.TextBoxX_G_GameName.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_G_GameName.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX_G_GameName.Name = "TextBoxX_G_GameName"
        Me.TextBoxX_G_GameName.PreventEnterBeep = True
        '
        'LabelX_G_Filesize
        '
        resources.ApplyResources(Me.LabelX_G_Filesize, "LabelX_G_Filesize")
        Me.LabelX_G_Filesize.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_G_Filesize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_G_Filesize.Name = "LabelX_G_Filesize"
        Me.LabelX_G_Filesize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX34
        '
        resources.ApplyResources(Me.LabelX34, "LabelX34")
        '
        '
        '
        Me.LabelX34.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX35
        '
        resources.ApplyResources(Me.LabelX35, "LabelX35")
        '
        '
        '
        Me.LabelX35.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Tab_General
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel6)
        Me.Name = "Tab_General"
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ItemPanel_RecentFiles As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents GroupPanel6 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Button_G_SaveGameName As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_G_Filename As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_G_GameName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX_G_Filesize As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
End Class
