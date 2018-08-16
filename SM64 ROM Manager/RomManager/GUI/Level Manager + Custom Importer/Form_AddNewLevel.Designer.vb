<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_AddNewLevel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AddNewLevel))
        Me.Button_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Button_Add = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_Level = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SuspendLayout()
        '
        'Button_Cancel
        '
        Me.Button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.FocusCuesEnabled = False
        Me.Button_Cancel.Location = New System.Drawing.Point(89, 65)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(60, 23)
        Me.Button_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Cancel.TabIndex = 0
        Me.Button_Cancel.Text = "Cancel"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(12, 12)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(145, 20)
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX10.TabIndex = 98
        Me.LabelX10.Text = "Level to overwrite:"
        '
        'Button_Add
        '
        Me.Button_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Add.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Add.FocusCuesEnabled = False
        Me.Button_Add.Location = New System.Drawing.Point(12, 65)
        Me.Button_Add.Name = "Button_Add"
        Me.Button_Add.Size = New System.Drawing.Size(71, 23)
        Me.Button_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Add.TabIndex = 100
        Me.Button_Add.Text = "Okay"
        '
        'ComboBox_Level
        '
        Me.ComboBox_Level.DisplayMember = "Text"
        Me.ComboBox_Level.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_Level.DropDownHeight = 150
        Me.ComboBox_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Level.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_Level.FormattingEnabled = True
        Me.ComboBox_Level.IntegralHeight = False
        Me.ComboBox_Level.ItemHeight = 15
        Me.ComboBox_Level.Location = New System.Drawing.Point(12, 38)
        Me.ComboBox_Level.Name = "ComboBox_Level"
        Me.ComboBox_Level.Size = New System.Drawing.Size(137, 21)
        Me.ComboBox_Level.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_Level.TabIndex = 103
        '
        'Form_AddNewLevel
        '
        Me.AcceptButton = Me.Button_Add
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancel
        Me.ClientSize = New System.Drawing.Size(161, 98)
        Me.Controls.Add(Me.ComboBox_Level)
        Me.Controls.Add(Me.Button_Add)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.Button_Cancel)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_AddNewLevel"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Level"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_Add As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_Level As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
