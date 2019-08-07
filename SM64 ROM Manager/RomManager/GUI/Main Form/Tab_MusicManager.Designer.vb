<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_MusicManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_MusicManager))
        Me.GroupPanel12 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX56 = New DevComponents.DotNetBar.LabelX()
        Me.SwitchButton_MS_OverwriteSizeRestrictions = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupBox_MS_SeqProperties = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX_MS_SeqSize = New DevComponents.DotNetBar.LabelX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_MS_SequenceID = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox_MS_SelectedSequence = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_MS_NInst = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX_MS_Sequencename = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Button_MS_ExtractSequence = New DevComponents.DotNetBar.ButtonX()
        Me.Button_MS_ReplaceSequence = New DevComponents.DotNetBar.ButtonX()
        Me.Line6 = New DevComponents.DotNetBar.Controls.Line()
        Me.GroupPanel9 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ButtonX_MS_RemoveSequence = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX_MS_AddSequence = New DevComponents.DotNetBar.ButtonX()
        Me.ListBoxAdv_MS_MusicSequences = New SM64_ROM_Manager.Publics.Controls.ItemListBox()
        Me.GroupPanel12.SuspendLayout()
        Me.GroupBox_MS_SeqProperties.SuspendLayout()
        Me.GroupBox_MS_SelectedSequence.SuspendLayout()
        Me.GroupPanel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel12
        '
        Me.GroupPanel12.BackColor = System.Drawing.Color.White
        Me.GroupPanel12.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel12.Controls.Add(Me.LabelX56)
        Me.GroupPanel12.Controls.Add(Me.SwitchButton_MS_OverwriteSizeRestrictions)
        Me.GroupPanel12.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupPanel12, "GroupPanel12")
        Me.GroupPanel12.Name = "GroupPanel12"
        '
        '
        '
        Me.GroupPanel12.Style.BackColorGradientAngle = 90
        Me.GroupPanel12.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderBottomWidth = 1
        Me.GroupPanel12.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel12.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderLeftWidth = 1
        Me.GroupPanel12.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderRightWidth = 1
        Me.GroupPanel12.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel12.Style.BorderTopWidth = 1
        Me.GroupPanel12.Style.CornerDiameter = 4
        Me.GroupPanel12.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel12.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel12.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel12.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel12.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel12.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelX56
        '
        Me.LabelX56.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX56.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX56, "LabelX56")
        Me.LabelX56.Name = "LabelX56"
        Me.LabelX56.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'SwitchButton_MS_OverwriteSizeRestrictions
        '
        '
        '
        '
        Me.SwitchButton_MS_OverwriteSizeRestrictions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton_MS_OverwriteSizeRestrictions.FocusCuesEnabled = False
        resources.ApplyResources(Me.SwitchButton_MS_OverwriteSizeRestrictions, "SwitchButton_MS_OverwriteSizeRestrictions")
        Me.SwitchButton_MS_OverwriteSizeRestrictions.Name = "SwitchButton_MS_OverwriteSizeRestrictions"
        Me.SwitchButton_MS_OverwriteSizeRestrictions.OffTextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.OnTextColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton_MS_OverwriteSizeRestrictions.SwitchBackColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.SwitchBorderColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.SwitchButton_MS_OverwriteSizeRestrictions.SwitchWidth = 15
        '
        'GroupBox_MS_SeqProperties
        '
        Me.GroupBox_MS_SeqProperties.BackColor = System.Drawing.Color.White
        Me.GroupBox_MS_SeqProperties.CanvasColor = System.Drawing.Color.Empty
        Me.GroupBox_MS_SeqProperties.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX_MS_SeqSize)
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX33)
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX28)
        Me.GroupBox_MS_SeqProperties.Controls.Add(Me.LabelX_MS_SequenceID)
        Me.GroupBox_MS_SeqProperties.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupBox_MS_SeqProperties, "GroupBox_MS_SeqProperties")
        Me.GroupBox_MS_SeqProperties.Name = "GroupBox_MS_SeqProperties"
        '
        '
        '
        Me.GroupBox_MS_SeqProperties.Style.BackColorGradientAngle = 90
        Me.GroupBox_MS_SeqProperties.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderBottomWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupBox_MS_SeqProperties.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderLeftWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderRightWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SeqProperties.Style.BorderTopWidth = 1
        Me.GroupBox_MS_SeqProperties.Style.CornerDiameter = 4
        Me.GroupBox_MS_SeqProperties.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupBox_MS_SeqProperties.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupBox_MS_SeqProperties.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupBox_MS_SeqProperties.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupBox_MS_SeqProperties.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupBox_MS_SeqProperties.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelX_MS_SeqSize
        '
        Me.LabelX_MS_SeqSize.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_MS_SeqSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_MS_SeqSize, "LabelX_MS_SeqSize")
        Me.LabelX_MS_SeqSize.Name = "LabelX_MS_SeqSize"
        Me.LabelX_MS_SeqSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX33
        '
        Me.LabelX33.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX33, "LabelX33")
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX28, "LabelX28")
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX_MS_SequenceID
        '
        Me.LabelX_MS_SequenceID.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX_MS_SequenceID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX_MS_SequenceID, "LabelX_MS_SequenceID")
        Me.LabelX_MS_SequenceID.Name = "LabelX_MS_SequenceID"
        Me.LabelX_MS_SequenceID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'GroupBox_MS_SelectedSequence
        '
        Me.GroupBox_MS_SelectedSequence.BackColor = System.Drawing.Color.White
        Me.GroupBox_MS_SelectedSequence.CanvasColor = System.Drawing.Color.Empty
        Me.GroupBox_MS_SelectedSequence.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.ButtonX1)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.ComboBox_MS_NInst)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.LabelX32)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.LabelX5)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.TextBoxX_MS_Sequencename)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.Button_MS_ExtractSequence)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.Button_MS_ReplaceSequence)
        Me.GroupBox_MS_SelectedSequence.Controls.Add(Me.Line6)
        Me.GroupBox_MS_SelectedSequence.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.GroupBox_MS_SelectedSequence, "GroupBox_MS_SelectedSequence")
        Me.GroupBox_MS_SelectedSequence.Name = "GroupBox_MS_SelectedSequence"
        '
        '
        '
        Me.GroupBox_MS_SelectedSequence.Style.BackColorGradientAngle = 90
        Me.GroupBox_MS_SelectedSequence.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderBottomWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupBox_MS_SelectedSequence.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderLeftWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderRightWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupBox_MS_SelectedSequence.Style.BorderTopWidth = 1
        Me.GroupBox_MS_SelectedSequence.Style.CornerDiameter = 4
        Me.GroupBox_MS_SelectedSequence.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupBox_MS_SelectedSequence.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupBox_MS_SelectedSequence.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupBox_MS_SelectedSequence.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupBox_MS_SelectedSequence.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupBox_MS_SelectedSequence.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_MS_NInst
        '
        Me.ComboBox_MS_NInst.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_MS_NInst.DropDownHeight = 150
        Me.ComboBox_MS_NInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_MS_NInst.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_MS_NInst.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_MS_NInst, "ComboBox_MS_NInst")
        Me.ComboBox_MS_NInst.Items.AddRange(New Object() {resources.GetString("ComboBox_MS_NInst.Items"), resources.GetString("ComboBox_MS_NInst.Items1"), resources.GetString("ComboBox_MS_NInst.Items2"), resources.GetString("ComboBox_MS_NInst.Items3"), resources.GetString("ComboBox_MS_NInst.Items4"), resources.GetString("ComboBox_MS_NInst.Items5"), resources.GetString("ComboBox_MS_NInst.Items6"), resources.GetString("ComboBox_MS_NInst.Items7"), resources.GetString("ComboBox_MS_NInst.Items8"), resources.GetString("ComboBox_MS_NInst.Items9"), resources.GetString("ComboBox_MS_NInst.Items10"), resources.GetString("ComboBox_MS_NInst.Items11"), resources.GetString("ComboBox_MS_NInst.Items12"), resources.GetString("ComboBox_MS_NInst.Items13"), resources.GetString("ComboBox_MS_NInst.Items14"), resources.GetString("ComboBox_MS_NInst.Items15"), resources.GetString("ComboBox_MS_NInst.Items16"), resources.GetString("ComboBox_MS_NInst.Items17"), resources.GetString("ComboBox_MS_NInst.Items18"), resources.GetString("ComboBox_MS_NInst.Items19"), resources.GetString("ComboBox_MS_NInst.Items20"), resources.GetString("ComboBox_MS_NInst.Items21"), resources.GetString("ComboBox_MS_NInst.Items22"), resources.GetString("ComboBox_MS_NInst.Items23"), resources.GetString("ComboBox_MS_NInst.Items24"), resources.GetString("ComboBox_MS_NInst.Items25"), resources.GetString("ComboBox_MS_NInst.Items26"), resources.GetString("ComboBox_MS_NInst.Items27"), resources.GetString("ComboBox_MS_NInst.Items28"), resources.GetString("ComboBox_MS_NInst.Items29"), resources.GetString("ComboBox_MS_NInst.Items30"), resources.GetString("ComboBox_MS_NInst.Items31"), resources.GetString("ComboBox_MS_NInst.Items32"), resources.GetString("ComboBox_MS_NInst.Items33"), resources.GetString("ComboBox_MS_NInst.Items34"), resources.GetString("ComboBox_MS_NInst.Items35"), resources.GetString("ComboBox_MS_NInst.Items36"), resources.GetString("ComboBox_MS_NInst.Items37")})
        Me.ComboBox_MS_NInst.Name = "ComboBox_MS_NInst"
        Me.ComboBox_MS_NInst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX32, "LabelX32")
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'TextBoxX_MS_Sequencename
        '
        Me.TextBoxX_MS_Sequencename.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX_MS_Sequencename.Border.Class = "TextBoxBorder"
        Me.TextBoxX_MS_Sequencename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX_MS_Sequencename.DisabledBackColor = System.Drawing.Color.White
        Me.TextBoxX_MS_Sequencename.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.TextBoxX_MS_Sequencename, "TextBoxX_MS_Sequencename")
        Me.TextBoxX_MS_Sequencename.Name = "TextBoxX_MS_Sequencename"
        Me.TextBoxX_MS_Sequencename.PreventEnterBeep = True
        '
        'Button_MS_ExtractSequence
        '
        Me.Button_MS_ExtractSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_MS_ExtractSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_MS_ExtractSequence.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_MS_ExtractSequence, "Button_MS_ExtractSequence")
        Me.Button_MS_ExtractSequence.Name = "Button_MS_ExtractSequence"
        Me.Button_MS_ExtractSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Button_MS_ReplaceSequence
        '
        Me.Button_MS_ReplaceSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_MS_ReplaceSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_MS_ReplaceSequence.FocusCuesEnabled = False
        resources.ApplyResources(Me.Button_MS_ReplaceSequence, "Button_MS_ReplaceSequence")
        Me.Button_MS_ReplaceSequence.Name = "Button_MS_ReplaceSequence"
        Me.Button_MS_ReplaceSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Line6
        '
        Me.Line6.BackColor = System.Drawing.Color.Transparent
        Me.Line6.ForeColor = System.Drawing.Color.Gainsboro
        resources.ApplyResources(Me.Line6, "Line6")
        Me.Line6.Name = "Line6"
        '
        'GroupPanel9
        '
        resources.ApplyResources(Me.GroupPanel9, "GroupPanel9")
        Me.GroupPanel9.BackColor = System.Drawing.Color.White
        Me.GroupPanel9.CanvasColor = System.Drawing.Color.Empty
        Me.GroupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel9.Controls.Add(Me.ButtonX_MS_RemoveSequence)
        Me.GroupPanel9.Controls.Add(Me.ButtonX_MS_AddSequence)
        Me.GroupPanel9.Controls.Add(Me.ListBoxAdv_MS_MusicSequences)
        Me.GroupPanel9.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel9.Name = "GroupPanel9"
        '
        '
        '
        Me.GroupPanel9.Style.BackColorGradientAngle = 90
        Me.GroupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderBottomWidth = 1
        Me.GroupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderLeftWidth = 1
        Me.GroupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderRightWidth = 1
        Me.GroupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel9.Style.BorderTopWidth = 1
        Me.GroupPanel9.Style.CornerDiameter = 4
        Me.GroupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel9.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonX_MS_RemoveSequence
        '
        Me.ButtonX_MS_RemoveSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_MS_RemoveSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX_MS_RemoveSequence, "ButtonX_MS_RemoveSequence")
        Me.ButtonX_MS_RemoveSequence.FocusCuesEnabled = False
        Me.ButtonX_MS_RemoveSequence.Name = "ButtonX_MS_RemoveSequence"
        Me.ButtonX_MS_RemoveSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_MS_RemoveSequence.Symbol = "57676"
        Me.ButtonX_MS_RemoveSequence.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonX_MS_RemoveSequence.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_MS_RemoveSequence.SymbolSize = 12.0!
        '
        'ButtonX_MS_AddSequence
        '
        Me.ButtonX_MS_AddSequence.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX_MS_AddSequence.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX_MS_AddSequence.FocusCuesEnabled = False
        resources.ApplyResources(Me.ButtonX_MS_AddSequence, "ButtonX_MS_AddSequence")
        Me.ButtonX_MS_AddSequence.Name = "ButtonX_MS_AddSequence"
        Me.ButtonX_MS_AddSequence.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX_MS_AddSequence.Symbol = "57669"
        Me.ButtonX_MS_AddSequence.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX_MS_AddSequence.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX_MS_AddSequence.SymbolSize = 12.0!
        '
        'ListBoxAdv_MS_MusicSequences
        '
        resources.ApplyResources(Me.ListBoxAdv_MS_MusicSequences, "ListBoxAdv_MS_MusicSequences")
        '
        '
        '
        Me.ListBoxAdv_MS_MusicSequences.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBoxAdv_MS_MusicSequences.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBoxAdv_MS_MusicSequences.ContainerControlProcessDialogKey = True
        Me.ListBoxAdv_MS_MusicSequences.DragDropSupport = True
        Me.ListBoxAdv_MS_MusicSequences.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ListBoxAdv_MS_MusicSequences.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBoxAdv_MS_MusicSequences.Name = "ListBoxAdv_MS_MusicSequences"
        Me.ListBoxAdv_MS_MusicSequences.ReserveLeftSpace = False
        Me.ListBoxAdv_MS_MusicSequences.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Tab_MusicManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupPanel12)
        Me.Controls.Add(Me.GroupBox_MS_SeqProperties)
        Me.Controls.Add(Me.GroupBox_MS_SelectedSequence)
        Me.Controls.Add(Me.GroupPanel9)
        Me.Name = "Tab_MusicManager"
        Me.GroupPanel12.ResumeLayout(False)
        Me.GroupBox_MS_SeqProperties.ResumeLayout(False)
        Me.GroupBox_MS_SelectedSequence.ResumeLayout(False)
        Me.GroupPanel9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupPanel12 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX56 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SwitchButton_MS_OverwriteSizeRestrictions As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupBox_MS_SeqProperties As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX_MS_SeqSize As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_MS_SequenceID As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox_MS_SelectedSequence As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ComboBox_MS_NInst As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX_MS_Sequencename As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Button_MS_ExtractSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_MS_ReplaceSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line6 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents GroupPanel9 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ButtonX_MS_RemoveSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX_MS_AddSequence As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListBoxAdv_MS_MusicSequences As Publics.Controls.ItemListBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
