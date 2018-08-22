Imports System.CodeDom.Compiler
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports FastColoredTextBoxNS
Imports PatchScripts

Public Class TweakScriptEditor

    Private WithEvents CodeEditor As FastColoredTextBox
    Private script As PatchScript
    Private ntsScript As Boolean = False
    Private ntsDescription As Boolean = False
    Private ntsName As Boolean = False
    Private ntsType As Boolean = False
    Private ntsReferences As Boolean = False

    Public ReadOnly Property NeedToSave As Boolean
        Get
            Return ntsScript OrElse ntsDescription OrElse ntsName OrElse ntsType OrElse ntsReferences
        End Get
    End Property

    Public Sub New(script As PatchScript)
        Me.SuspendLayout()

        InitializeComponent()

        CodeEditor = New FastColoredTextBox
        CodeEditor.Language = Language.Custom
        CodeEditor.Dock = DockStyle.Fill
        CodeEditor.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(CodeEditor)

        Me.script = script

        UpdateAmbientColors
        Me.ResumeLayout(False)
    End Sub

    Private Sub TweakScriptEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllData()
    End Sub

    Private Sub CheckBoxX1_CheckedChanged(sender As CheckBoxX, e As EventArgs) Handles CheckBoxX_TweakScript.CheckedChanged
        If sender.Checked AndAlso CodeEditor IsNot Nothing Then
            CodeEditor.Language = Language.Custom
            script.Type = ScriptType.TweakScript
            ntsType = True
        End If
        Panel3.Visible = Not sender.Checked
        ButtonX_CheckForErros.Enabled = Not sender.Checked
    End Sub
    Private Sub CheckBoxX2_CheckedChanged(sender As CheckBoxX, e As EventArgs) Handles CheckBoxX_VBScript.CheckedChanged
        If sender.Checked AndAlso CodeEditor IsNot Nothing Then
            CodeEditor.Language = Language.VB
            script.Type = ScriptType.VisualBasic
            ntsType = True
        End If
    End Sub
    Private Sub CheckBoxX3_CheckedChanged(sender As CheckBoxX, e As EventArgs) Handles CheckBoxX_CSharpScript.CheckedChanged
        If sender.Checked AndAlso CodeEditor IsNot Nothing Then
            CodeEditor.Language = Language.CSharp
            script.Type = ScriptType.CSharp
            ntsType = True
        End If
    End Sub

    Private Sub CodeEditor_MouseClick(sender As Object, e As MouseEventArgs) Handles CodeEditor.MouseClick, TextBoxX_ReferenceName.MouseClick, TextBoxX_ScriptDescription.MouseClick, TextBoxX_ScriptName.MouseClick
        If e.Button = MouseButtons.Right Then
            ButtonItem5.Popup(Cursor.Position)
        End If
    End Sub
    Private Sub CodeEditor_GotFocus(sender As Object, e As EventArgs) Handles CodeEditor.GotFocus, TextBoxX_ReferenceName.GotFocus, TextBoxX_ScriptDescription.GotFocus, TextBoxX_ScriptName.GotFocus
        ButtonItem5.Tag = sender
    End Sub

    Private Sub TweakScriptEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveAllData()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Dim txt As String = TextBoxX_ReferenceName.Text.Trim

        If Not String.IsNullOrEmpty(txt) Then
            script.References.Add(txt)
            ItemListBox1.Items.Add(New ButtonItem With {.Text = txt})
        End If

        ItemListBox1.Refresh()
    End Sub

    Private Sub ItemListBox1_SelectedItemChanged(sender As Object, e As EventArgs) Handles ItemListBox1.SelectedItemChanged
        Dim btnItem As ButtonItem = ItemListBox1.SelectedItem

        If btnItem IsNot Nothing Then
            TextBoxX_ReferenceName.Text = btnItem.Text
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Dim selIndex As Integer = ItemListBox1.SelectedIndex

        If selIndex > -1 Then
            ItemListBox1.Items.RemoveAt(selIndex)
            script.References.RemoveAt(selIndex)
            ntsReferences = True
        End If

        ItemListBox1.Refresh()
    End Sub

    Private Sub LoadReferences()
        For Each ref As String In script.References
            ItemListBox1.Items.Add(New ButtonItem With {.Text = ref})
            ntsReferences = True
        Next

        ItemListBox1.Refresh()
    End Sub

    Private Sub LoadAllData()
        TextBoxX_ScriptName.Text = script.Name
        TextBoxX_ScriptDescription.Text = script.Description

        Select Case script.Type
            Case ScriptType.TweakScript
                CheckBoxX_TweakScript.Checked = True
            Case ScriptType.VisualBasic
                CheckBoxX_VBScript.Checked = True
            Case ScriptType.CSharp
                CheckBoxX_CSharpScript.Checked = True
        End Select

        CodeEditor.Text = script.Script

        ntsScript = False
        ntsName = False
        ntsDescription = False
        ntsType = False

        LoadReferences()
    End Sub

    Private Sub SaveAllData()
        script.Name = TextBoxX_ScriptName.Text.Trim
        script.Description = TextBoxX_ScriptDescription.Text

        Select Case True
            Case CheckBoxX_TweakScript.Checked
                script.Type = ScriptType.TweakScript
            Case CheckBoxX_VBScript.Checked
                script.Type = ScriptType.VisualBasic
            Case CheckBoxX_CSharpScript.Checked
                script.Type = ScriptType.CSharp
        End Select

        If ntsScript Then
            script.Script = CodeEditor.Text
        End If
    End Sub

    Private Sub ButtonItem_Copy_Click(sender As ButtonItem, e As EventArgs) Handles ButtonItem_Copy.Click
        sender.Parent.Tag.Copy()
    End Sub
    Private Sub ButtonItem_cut_Click(sender As Object, e As EventArgs) Handles ButtonItem_cut.Click
        sender.Parent.Tag.Cut()
    End Sub
    Private Sub ButtonItem_Paste_Click(sender As Object, e As EventArgs) Handles ButtonItem_Paste.Click
        sender.Parent.Tag.Paste()
    End Sub
    Private Sub ButtonItem_SelectAll_Click(sender As Object, e As EventArgs) Handles ButtonItem_SelectAll.Click
        sender.Parent.Tag.SelectAll()
    End Sub
    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        sender.Parent.Tag.Undo()
    End Sub
    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        If TypeOf sender.Parent.Tag Is FastColoredTextBox Then
            sender.Parent.Tag.Redo()
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        CheckBoxX_VBScript.Checked = True
        CodeEditor.Text = "Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows.Forms
Imports System.IO


Module Script

    Sub Main(rom As Stream)
        
        
        
    End Sub

End Module
"
    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        CheckBoxX_CSharpScript.Checked = True
        CodeEditor.Text = "using Microsoft.CSharp;
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;


class Script
{

    static void Main(Stream rom)
    {
    
    
    
    }

}
"
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Textfile (*.txt)|*.txt|VB code file (*.vb)|*.vb|C# code file(*.cs)|*.cs"

        Select Case True
            Case CheckBoxX_TweakScript.Checked
                sfd.FilterIndex = 1
            Case CheckBoxX_VBScript.Checked
                sfd.FilterIndex = 2
            Case CheckBoxX_CSharpScript.Checked
                sfd.FilterIndex = 3
        End Select

        If sfd.ShowDialog = DialogResult.OK Then
            IO.File.WriteAllText(sfd.FileName, CodeEditor.Text)
        End If
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Alls supported files (*.txt, *.vb, *.cs)|*.txt;*.vb;*.cs|Textfile (*.txt)|*.txt|VB code file (*.vb)|*.vb|C# code file(*.cs)|*.cs"

        If ofd.ShowDialog = DialogResult.OK Then
            Select Case IO.Path.GetExtension(ofd.FileName).ToLower
                Case ".vb"
                    CheckBoxX_VBScript.Checked = True
                Case ".cs"
                    CheckBoxX_CSharpScript.Checked = True
            End Select

            CodeEditor.Text = IO.File.ReadAllText(ofd.FileName)
        End If
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX_CheckForErros.Click
        SaveAllData()

        Dim mgr As New PatchingManager
        Dim res As CompilerResults = mgr.CompileScript(script)

        Dim msg As String = ""
        Dim icon As eTaskDialogIcon
        Dim title As String

        If res.Errors.HasErrors Then
            title = "Script has Errors"
            icon = eTaskDialogIcon.Delete
        Else
            title = "Script is fine"
            If res.Errors.HasWarnings Then
                icon = eTaskDialogIcon.Exclamation
            Else
                icon = eTaskDialogIcon.Information
            End If
        End If

        For Each er As CompilerError In res.Errors
            If msg <> "" Then
                msg &= vbNewLine & vbNewLine
            End If

            If er.IsWarning Then
                msg &= "WARNING"
            Else
                msg &= "ERROR"
            End If

            msg &= " Code: " & er.ErrorNumber
            msg &= " Line: " & er.Line
            msg &= vbNewLine & er.ErrorText
        Next

        TaskDialog.Show("Compiler Result", icon, title, msg, eTaskDialogButton.Ok)
    End Sub

    Private Sub CodeEditor_TextChanged(sender As Object, e As TextChangedEventArgs) Handles CodeEditor.TextChanged
        ntsScript = True
    End Sub
    Private Sub TextBoxX_ScriptName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ScriptName.TextChanged
        ntsName = True
    End Sub
    Private Sub TextBoxX_ScriptDescription_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ScriptDescription.TextChanged
        ntsDescription = True
    End Sub

End Class