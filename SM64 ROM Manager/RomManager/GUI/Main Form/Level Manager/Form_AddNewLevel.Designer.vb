﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LevelSelectorDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LevelSelectorDialog))
        Me.Button_Cancel = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.Button_Add = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBox_Level = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Cancel
        '
        Me.Button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_Cancel, "Button_Cancel")
        Me.Button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.FocusCuesEnabled = False
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'LabelX10
        '
        resources.ApplyResources(Me.LabelX10, "LabelX10")
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        '
        'Button_Add
        '
        Me.Button_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.Button_Add, "Button_Add")
        Me.Button_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Button_Add.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Add.FocusCuesEnabled = False
        Me.Button_Add.Name = "Button_Add"
        Me.Button_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'ComboBox_Level
        '
        resources.ApplyResources(Me.ComboBox_Level, "ComboBox_Level")
        Me.ComboBox_Level.DisplayMember = "Text"
        Me.ComboBox_Level.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox_Level.DropDownHeight = 150
        Me.ComboBox_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Level.ForeColor = System.Drawing.Color.Black
        Me.ComboBox_Level.FormattingEnabled = True
        Me.ComboBox_Level.Name = "ComboBox_Level"
        Me.ComboBox_Level.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelX10)
        Me.Panel1.Controls.Add(Me.ComboBox_Level)
        Me.Panel1.Controls.Add(Me.Button_Cancel)
        Me.Panel1.Controls.Add(Me.Button_Add)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LevelSelectorDialog
        '
        Me.AcceptButton = Me.Button_Add
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancel
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LevelSelectorDialog"
        Me.ShowIcon = False
        Me.TopLeftCornerSize = 0
        Me.TopRightCornerSize = 0
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Cancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button_Add As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboBox_Level As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Panel1 As Panel
End Class
