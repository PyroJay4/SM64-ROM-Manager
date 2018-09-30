<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StarPositionEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StarPositionEditor))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_z = New DevComponents.Editors.IntegerInput()
        Me.IntegerInput_Y = New DevComponents.Editors.IntegerInput()
        Me.IntegerInput_X = New DevComponents.Editors.IntegerInput()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Panel1.SuspendLayout()
        CType(Me.IntegerInput_z, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Controls.Add(Me.LabelX2)
        Me.Panel1.Controls.Add(Me.IntegerInput_z)
        Me.Panel1.Controls.Add(Me.IntegerInput_Y)
        Me.Panel1.Controls.Add(Me.IntegerInput_X)
        Me.Panel1.Controls.Add(Me.ComboBoxEx1)
        Me.Panel1.Controls.Add(Me.LabelX1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX5, "LabelX5")
        Me.LabelX5.Name = "LabelX5"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX4, "LabelX4")
        Me.LabelX4.Name = "LabelX4"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX3, "LabelX3")
        Me.LabelX3.Name = "LabelX3"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.ButtonX1, "ButtonX1")
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = "57697"
        Me.ButtonX1.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.SymbolSize = 12.0!
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.LabelX2, "LabelX2")
        Me.LabelX2.Name = "LabelX2"
        '
        'IntegerInput_z
        '
        '
        '
        '
        Me.IntegerInput_z.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_z.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_z.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_z, "IntegerInput_z")
        Me.IntegerInput_z.MaxValue = 32767
        Me.IntegerInput_z.MinValue = -32768
        Me.IntegerInput_z.Name = "IntegerInput_z"
        Me.IntegerInput_z.ShowUpDown = True
        '
        'IntegerInput_Y
        '
        '
        '
        '
        Me.IntegerInput_Y.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_Y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_Y.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_Y, "IntegerInput_Y")
        Me.IntegerInput_Y.MaxValue = 32767
        Me.IntegerInput_Y.MinValue = -32768
        Me.IntegerInput_Y.Name = "IntegerInput_Y"
        Me.IntegerInput_Y.ShowUpDown = True
        '
        'IntegerInput_X
        '
        '
        '
        '
        Me.IntegerInput_X.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_X.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        resources.ApplyResources(Me.IntegerInput_X, "IntegerInput_X")
        Me.IntegerInput_X.MaxValue = 32767
        Me.IntegerInput_X.MinValue = -32768
        Me.IntegerInput_X.Name = "IntegerInput_X"
        Me.IntegerInput_X.ShowUpDown = True
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEx1.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEx1, "ComboBoxEx1")
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        'StarPositionEditor
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "StarPositionEditor"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        CType(Me.IntegerInput_z, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents IntegerInput_z As DevComponents.Editors.IntegerInput
    Friend WithEvents IntegerInput_Y As DevComponents.Editors.IntegerInput
    Friend WithEvents IntegerInput_X As DevComponents.Editors.IntegerInput
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
