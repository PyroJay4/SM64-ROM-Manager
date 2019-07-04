Imports System.CodeDom.Compiler
Imports System.Windows.Forms
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports FastColoredTextBoxNS
Imports PatchScripts

Public Class TweakScriptEditor

    'F i e l d s

    Private WithEvents CodeEditor As FastColoredTextBox
    Private script As PatchScript
    Private ntsScript As Boolean = False
    Private ntsDescription As Boolean = False
    Private ntsName As Boolean = False
    Private ntsType As Boolean = False
    Private ntsReferences As Boolean = False
    Private runInTestMode As Boolean = True

    'P r o p e r t i e s

    Public ReadOnly Property NeedToSave As Boolean
        Get
            Return ntsScript OrElse ntsDescription OrElse ntsName OrElse ntsType OrElse ntsReferences
        End Get
    End Property

    'C o n s t r u c t o r s

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

    'F e a t u r e s

    Private Sub ChangeCurScriptType(lang As Language, typ As ScriptType)
        CodeEditor.Language = lang
        script.Type = typ
        ntsType = True
    End Sub

    Private Sub LoadReferences()
        For Each ref As String In script.References
            ItemListBox1.Items.Add(New ButtonItem With {.Text = ref})
            ntsReferences = True
        Next

        ItemListBox1.Refresh()
    End Sub

    Private Sub AddReference(txt As String)
        If Not String.IsNullOrEmpty(txt) Then
            script.References.Add(txt)
            ItemListBox1.Items.Add(New ButtonItem With {.Text = txt})
        End If
    End Sub

    Private Sub RemoveReference(index As Integer)
        If index > -1 Then
            ItemListBox1.Items.RemoveAt(index)
            script.References.RemoveAt(index)
            ntsReferences = True
        End If
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

    Private Sub LoadDefaultScript(typ As ScriptType)
        Select Case typ
            Case ScriptType.CSharp
                CheckBoxX_CSharpScript.Checked = True
                CodeEditor.Text =
        "using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SM64Lib;

class Script
{

    static void Main(IReadOnlyDictionary<string, object> pars)
    {
        
    }

}
"
            Case ScriptType.VisualBasic
                CheckBoxX_VBScript.Checked = True
                CodeEditor.Text =
        "Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports SM64Lib

Module Script

    Sub Main(params as IReadOnlyDictionary(Of String, Object))
        
    End Sub

End Module
"
        End Select
    End Sub

    Private Sub SaveToFile()
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

    Private Sub LoadFromFile()
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Alls supported files (*.txt, *.vb, *.cs)|*.txt;*.vb;*.cs|Textfile (*.txt)|*.txt|VB code file (*.vb)|*.vb|C# code file(*.cs)|*.cs"

        If ofd.ShowDialog = DialogResult.OK Then
            Select Case IO.Path.GetExtension(ofd.FileName).ToLower
                Case ".vb"
                    CheckBoxX_VBScript.Checked = True
                Case ".cs"
                    CheckBoxX_CSharpScript.Checked = True
                Case Else
                    CheckBoxX_TweakScript.Checked = True
            End Select

            CodeEditor.Text = IO.File.ReadAllText(ofd.FileName)
        End If
    End Sub

    Private Sub TestScript()
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

    Private Sub RunScript()
        Dim mgr As New PatchingManager


    End Sub

    'G u i

    Private Sub TweakScriptEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllData()
    End Sub

    Private Sub CheckBoxX_ScriptChange_CheckedChanged(sender As CheckBoxX, e As EventArgs) Handles CheckBoxX_TweakScript.CheckedChanged, CheckBoxX_CSharpScript.CheckedChanged, CheckBoxX_VBScript.CheckedChanged
        If sender.Checked AndAlso CodeEditor IsNot Nothing Then
            If sender Is CheckBoxX_TweakScript Then
                ChangeCurScriptType(Language.Custom, ScriptType.TweakScript)
            ElseIf sender Is CheckBoxX_CSharpScript Then
                ChangeCurScriptType(Language.CSharp, ScriptType.CSharp)
            ElseIf sender Is CheckBoxX_VBScript Then
                ChangeCurScriptType(Language.VB, ScriptType.VisualBasic)
            End If
        End If

        If sender Is CheckBoxX_TweakScript Then
            Panel3.Visible = Not sender.Checked
            ButtonX_CheckForErros.Enabled = Not sender.Checked
        End If
    End Sub

    Private Sub TweakScriptEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not {CloseReason.ApplicationExitCall, CloseReason.WindowsShutDown, CloseReason.TaskManagerClosing}.Contains(e.CloseReason) Then
            Select Case MessageBoxEx.Show("Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    SaveAllData()
                Case DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Dim txt As String = TextBoxX_ReferenceName.Text.Trim
        AddReference(txt)
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
        RemoveReference(selIndex)
        ItemListBox1.Refresh()
    End Sub

    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs)
        If TypeOf sender.Parent.Tag Is FastColoredTextBox Then
            sender.Parent.Tag.Redo()
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        LoadDefaultScript(ScriptType.VisualBasic)
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        LoadDefaultScript(ScriptType.CSharp)
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        SaveToFile()
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        LoadFromFile()
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX_CheckForErros.Click
        SaveAllData()
        TestScript()
    End Sub

    Private Sub AnyTextChanged(sender As Object, e As EventArgs) Handles TextBoxX_ScriptName.TextChanged, TextBoxX_ScriptDescription.TextChanged, CodeEditor.TextChanged
        ntsName = True
    End Sub

    Private Sub ButtonItem_RunInTestMode_CheckedChanged(sender As ButtonItem, e As EventArgs) Handles ButtonItem_RunInTestMode.CheckedChanged
        runInTestMode = sender.Checked
    End Sub

    Private Sub ButtonX_RunScript_Click(sender As Object, e As EventArgs) Handles ButtonX_RunScript.Click
        RunScript()
    End Sub

    Private Sub ButtonX_ShowObjectCatalog_Click(sender As Object, e As EventArgs) Handles ButtonX_ShowObjectCatalog.Click

    End Sub

End Class