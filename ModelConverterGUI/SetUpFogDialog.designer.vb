Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetUpFogDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetUpFogDialog))
        Me.Button_Cancle = New DevComponents.DotNetBar.ButtonX()
        Me.Button_Okay = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New DevComponents.DotNetBar.LabelX()
        Me.Label21 = New DevComponents.DotNetBar.LabelX()
        Me.Label20 = New DevComponents.DotNetBar.LabelX()
        Me.NumericUpDown_FogBlue = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_FogGreen = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_FogRed = New System.Windows.Forms.NumericUpDown()
        Me.ComboBox_FogTyp = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NumericUpDown_FogBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_FogGreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_FogRed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Cancle
        '
        Me.Button_Cancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Cancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancle.FocusCuesEnabled = False
        Me.Button_Cancle.Location = New System.Drawing.Point(80, 147)
        Me.Button_Cancle.Name = "Button_Cancle"
        Me.Button_Cancle.Size = New System.Drawing.Size(56, 23)
        Me.Button_Cancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Cancle.TabIndex = 98
        Me.Button_Cancle.Text = "Cancle"
        '
        'Button_Okay
        '
        Me.Button_Okay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Button_Okay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Okay.FocusCuesEnabled = False
        Me.Button_Okay.Location = New System.Drawing.Point(12, 147)
        Me.Button_Okay.Name = "Button_Okay"
        Me.Button_Okay.Size = New System.Drawing.Size(56, 23)
        Me.Button_Okay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Button_Okay.TabIndex = 97
        Me.Button_Okay.Text = "Okay"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.NumericUpDown_FogBlue)
        Me.GroupBox5.Controls.Add(Me.NumericUpDown_FogGreen)
        Me.GroupBox5.Controls.Add(Me.NumericUpDown_FogRed)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(124, 102)
        Me.GroupBox5.TabIndex = 100
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Color"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        '
        '
        '
        Me.Label22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label22.Location = New System.Drawing.Point(6, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(28, 15)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "Blue:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        '
        '
        '
        Me.Label21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label21.Location = New System.Drawing.Point(6, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 15)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Green:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        '
        '
        '
        Me.Label20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label20.Location = New System.Drawing.Point(6, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(26, 15)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Red:"
        '
        'NumericUpDown_FogBlue
        '
        Me.NumericUpDown_FogBlue.Location = New System.Drawing.Point(53, 71)
        Me.NumericUpDown_FogBlue.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_FogBlue.Name = "NumericUpDown_FogBlue"
        Me.NumericUpDown_FogBlue.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown_FogBlue.TabIndex = 23
        '
        'NumericUpDown_FogGreen
        '
        Me.NumericUpDown_FogGreen.Location = New System.Drawing.Point(53, 45)
        Me.NumericUpDown_FogGreen.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_FogGreen.Name = "NumericUpDown_FogGreen"
        Me.NumericUpDown_FogGreen.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown_FogGreen.TabIndex = 22
        '
        'NumericUpDown_FogRed
        '
        Me.NumericUpDown_FogRed.Location = New System.Drawing.Point(53, 19)
        Me.NumericUpDown_FogRed.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_FogRed.Name = "NumericUpDown_FogRed"
        Me.NumericUpDown_FogRed.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown_FogRed.TabIndex = 21
        '
        'ComboBox_FogTyp
        '
        Me.ComboBox_FogTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_FogTyp.DropDownHeight = 150
        Me.ComboBox_FogTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_FogTyp.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_FogTyp.FormattingEnabled = True
        Me.ComboBox_FogTyp.IntegralHeight = False
        Me.ComboBox_FogTyp.ItemHeight = 15
        Me.ComboBox_FogTyp.Items.AddRange(New Object() {"Subtle Fog #1", "Subtle Fog #2", "Moderate Fog #1", "Moderate Fog #2", "Moderate Fog #3", "Moderate Fog #4", "Intense Fog", "Very Intense Fog", "Hardcore Fog"})
        Me.ComboBox_FogTyp.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox_FogTyp.Name = "ComboBox_FogTyp"
        Me.ComboBox_FogTyp.Size = New System.Drawing.Size(124, 21)
        Me.ComboBox_FogTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBox_FogTyp.TabIndex = 101
        '
        'Form_SetUpFog
        '
        Me.AcceptButton = Me.Button_Okay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancle
        Me.ClientSize = New System.Drawing.Size(148, 180)
        Me.Controls.Add(Me.ComboBox_FogTyp)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Button_Cancle)
        Me.Controls.Add(Me.Button_Okay)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_SetUpFog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fog"
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NumericUpDown_FogBlue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_FogGreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_FogRed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Cancle As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button_Okay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NumericUpDown_FogBlue As NumericUpDown
    Friend WithEvents NumericUpDown_FogGreen As NumericUpDown
    Friend WithEvents NumericUpDown_FogRed As NumericUpDown
    Friend WithEvents ComboBox_FogTyp As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
