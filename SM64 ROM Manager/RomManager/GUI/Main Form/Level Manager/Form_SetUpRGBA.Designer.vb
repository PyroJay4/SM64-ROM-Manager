<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_SetUpRGBA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SetUpRGBA))
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_Okay = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.NumericUpDown_FogBlue = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_FogGreen = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_FogRed = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NumericUpDown_FogBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_FogGreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_FogRed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Cancel
        '
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.Location = New System.Drawing.Point(80, 226)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(56, 23)
        Me.Button_Cancel.TabIndex = 98
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_Okay
        '
        Me.Button_Okay.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Okay.Location = New System.Drawing.Point(12, 226)
        Me.Button_Okay.Name = "Button_Okay"
        Me.Button_Okay.Size = New System.Drawing.Size(56, 23)
        Me.Button_Okay.TabIndex = 97
        Me.Button_Okay.Text = "Okay"
        Me.Button_Okay.UseVisualStyleBackColor = True
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
        Me.GroupBox5.Size = New System.Drawing.Size(119, 102)
        Me.GroupBox5.TabIndex = 100
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Color"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "Blue:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Green:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 13)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Red:"
        '
        'NumericUpDown_FogBlue
        '
        Me.NumericUpDown_FogBlue.Location = New System.Drawing.Point(53, 71)
        Me.NumericUpDown_FogBlue.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_FogBlue.Name = "NumericUpDown_FogBlue"
        Me.NumericUpDown_FogBlue.Size = New System.Drawing.Size(59, 20)
        Me.NumericUpDown_FogBlue.TabIndex = 23
        '
        'NumericUpDown_FogGreen
        '
        Me.NumericUpDown_FogGreen.Location = New System.Drawing.Point(53, 45)
        Me.NumericUpDown_FogGreen.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_FogGreen.Name = "NumericUpDown_FogGreen"
        Me.NumericUpDown_FogGreen.Size = New System.Drawing.Size(59, 20)
        Me.NumericUpDown_FogGreen.TabIndex = 22
        '
        'NumericUpDown_FogRed
        '
        Me.NumericUpDown_FogRed.Location = New System.Drawing.Point(53, 19)
        Me.NumericUpDown_FogRed.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_FogRed.Name = "NumericUpDown_FogRed"
        Me.NumericUpDown_FogRed.Size = New System.Drawing.Size(59, 20)
        Me.NumericUpDown_FogRed.TabIndex = 21
        '
        'Form_SetUpRGBA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(156, 256)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Okay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_SetUpRGBA"
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

    Friend WithEvents Button_Cancel As Button
    Friend WithEvents Button_Okay As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents NumericUpDown_FogBlue As NumericUpDown
    Friend WithEvents NumericUpDown_FogGreen As NumericUpDown
    Friend WithEvents NumericUpDown_FogRed As NumericUpDown
End Class
