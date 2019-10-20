<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SetUpPoint
    Inherits DevComponents.DotNetBar.OfficeForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SetUpPoint))
        Me.Button_Okay = New DevComponents.DotNetBar.ButtonX()
        Me.IntegerInput_X = New DevComponents.Editors.IntegerInput()
        Me.LabelX_X = New DevComponents.DotNetBar.LabelX()
        Me.LabelX_Y = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_Y = New DevComponents.Editors.IntegerInput()
        Me.LabelX_Z = New DevComponents.DotNetBar.LabelX()
        Me.IntegerInput_Z = New DevComponents.Editors.IntegerInput()
        Me.Button_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.IntegerInput_X, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInput_Z, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Okay
        '
        Me.Button_Okay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Okay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Okay.FocusCuesEnabled = False
        Me.Button_Okay.Location = New System.Drawing.Point(3, 81)
        Me.Button_Okay.Name = "Button_Okay"
        Me.Button_Okay.Size = New System.Drawing.Size(56, 23)
        Me.Button_Okay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Okay.TabIndex = 0
        Me.Button_Okay.Text = "Okay"
        '
        'IntegerInput_X
        '
        '
        '
        '
        Me.IntegerInput_X.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_X.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_X.Location = New System.Drawing.Point(27, 3)
        Me.IntegerInput_X.MaxValue = 32767
        Me.IntegerInput_X.MinValue = -32767
        Me.IntegerInput_X.Name = "IntegerInput_X"
        Me.IntegerInput_X.ShowUpDown = True
        Me.IntegerInput_X.Size = New System.Drawing.Size(100, 20)
        Me.IntegerInput_X.TabIndex = 1
        Me.IntegerInput_X.Visible = False
        '
        'LabelX_X
        '
        '
        '
        '
        Me.LabelX_X.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_X.Location = New System.Drawing.Point(3, 3)
        Me.LabelX_X.Name = "LabelX_X"
        Me.LabelX_X.Size = New System.Drawing.Size(18, 20)
        Me.LabelX_X.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX_X.TabIndex = 91
        Me.LabelX_X.Text = "X:"
        Me.LabelX_X.Visible = False
        '
        'LabelX_Y
        '
        '
        '
        '
        Me.LabelX_Y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Y.Location = New System.Drawing.Point(3, 29)
        Me.LabelX_Y.Name = "LabelX_Y"
        Me.LabelX_Y.Size = New System.Drawing.Size(18, 20)
        Me.LabelX_Y.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX_Y.TabIndex = 93
        Me.LabelX_Y.Text = "Y:"
        Me.LabelX_Y.Visible = False
        '
        'IntegerInput_Y
        '
        '
        '
        '
        Me.IntegerInput_Y.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_Y.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_Y.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_Y.Location = New System.Drawing.Point(27, 29)
        Me.IntegerInput_Y.MaxValue = 32767
        Me.IntegerInput_Y.MinValue = -32767
        Me.IntegerInput_Y.Name = "IntegerInput_Y"
        Me.IntegerInput_Y.ShowUpDown = True
        Me.IntegerInput_Y.Size = New System.Drawing.Size(100, 20)
        Me.IntegerInput_Y.TabIndex = 92
        Me.IntegerInput_Y.Visible = False
        '
        'LabelX_Z
        '
        '
        '
        '
        Me.LabelX_Z.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX_Z.Location = New System.Drawing.Point(3, 55)
        Me.LabelX_Z.Name = "LabelX_Z"
        Me.LabelX_Z.Size = New System.Drawing.Size(18, 20)
        Me.LabelX_Z.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.LabelX_Z.TabIndex = 95
        Me.LabelX_Z.Text = "Z:"
        Me.LabelX_Z.Visible = False
        '
        'IntegerInput_Z
        '
        '
        '
        '
        Me.IntegerInput_Z.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInput_Z.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInput_Z.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInput_Z.Location = New System.Drawing.Point(27, 55)
        Me.IntegerInput_Z.MaxValue = 32767
        Me.IntegerInput_Z.MinValue = -32767
        Me.IntegerInput_Z.Name = "IntegerInput_Z"
        Me.IntegerInput_Z.ShowUpDown = True
        Me.IntegerInput_Z.Size = New System.Drawing.Size(100, 20)
        Me.IntegerInput_Z.TabIndex = 94
        Me.IntegerInput_Z.Visible = False
        '
        'Button_Cancel
        '
        Me.Button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.FocusCuesEnabled = False
        Me.Button_Cancel.Location = New System.Drawing.Point(71, 81)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(56, 23)
        Me.Button_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Cancel.TabIndex = 96
        Me.Button_Cancel.Text = "Cancel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX_X)
        Me.Panel1.Controls.Add(Me.Button_Cancel)
        Me.Panel1.Controls.Add(Me.Button_Okay)
        Me.Panel1.Controls.Add(Me.LabelX_Z)
        Me.Panel1.Controls.Add(Me.IntegerInput_X)
        Me.Panel1.Controls.Add(Me.IntegerInput_Z)
        Me.Panel1.Controls.Add(Me.IntegerInput_Y)
        Me.Panel1.Controls.Add(Me.LabelX_Y)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(130, 107)
        Me.Panel1.TabIndex = 97
        '
        'Form_SetUpPoint
        '
        Me.AcceptButton = Me.Button_Okay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancel
        Me.ClientSize = New System.Drawing.Size(130, 107)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_SetUpPoint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Point"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        CType(Me.IntegerInput_X, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInput_Z, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Okay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents IntegerInput_X As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX_X As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX_Y As DevComponents.DotNetBar.LabelX
    Friend WithEvents IntegerInput_Y As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX_Z As DevComponents.DotNetBar.LabelX
    Friend WithEvents IntegerInput_Z As DevComponents.Editors.IntegerInput
    Friend WithEvents Button_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As Panel
End Class
