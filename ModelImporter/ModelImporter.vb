Imports DevComponents.DotNetBar
Imports SM64Lib.Model
Imports Publics
Imports SettingsManager
Imports TextValueConverter
Imports ModelConverterGUI
Imports System.IO
Imports System.Text
Imports SM64Lib.Geolayout

Public Class ModelImporter

    Public _RomFile As String = ""
    Private mdl As AreaModel = Nothing

    Public Property StyleManager As StyleManager = Nothing

    Public Property RomFile As String
        Get
            Return _RomFile
        End Get
        Set(value As String)
            _RomFile = value
            If value <> "" Then
                LabelX1.Text = Path.GetFileName(value)
                LabelX1.Symbol = ""
            End If
        End Set
    End Property

    Private Sub ClearOutput()
        TextBoxX_Output.Text = ""
    End Sub
    Private Sub WriteOutput()
        TextBoxX_Output.AppendText(vbNewLine)
    End Sub
    Private Sub WriteOutput(msg As String)
        TextBoxX_Output.AppendText(msg & vbNewLine)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxEx1.Items.Clear()
        Dim layers As String() = [Enum].GetNames(GetType(Geolayer))
        ComboBoxEx1.Items.Add("Don't force")
        ComboBoxEx1.Items.AddRange(layers)
        ComboBoxEx1.SelectedIndex = Array.IndexOf(layers, [Enum].GetName(GetType(Geolayer), &H4)) + 1

        If StyleManager Is Nothing Then 'If Me.Owner Is Nothing Then
            StyleManager = New StyleManager
            StyleManager.ManagerStyle = eStyle.Metro
            Settings.LoadSettings()
        End If
        UpdateAmbientColors()
    End Sub

    Private Sub ButtonX_OpenRom_Click(sender As Object, e As EventArgs) Handles ButtonX_OpenRom.Click
        Dim ofd As New OpenFileDialog With {.Filter = "SM64 ROMs (*.z64)|*.z64|All files (*.*)|*.*"}

        If ofd.ShowDialog = DialogResult.OK Then
            RomFile = ofd.FileName
        End If
    End Sub

    Private Sub ButtonX_ConvertMdl_Click(sender As Object, e As EventArgs) Handles ButtonX_ConvertMdl.Click
        Dim frm As New MainModelConverter

        If ComboBoxEx1.SelectedIndex > 0 Then
            frm.ForceDisplaylist = [Enum].GetValues(GetType(Geolayer))(ComboBoxEx1.SelectedIndex - 1)
        End If

        If frm.ShowDialog = DialogResult.OK Then
            mdl = frm.ResModel
            ButtonX_ConvertMdl.Symbol = ""
            ButtonX_ImportMdl.Enabled = True
        End If
    End Sub

    Private Sub ButtonX_ImportMdl_Click(sender As Object, e As EventArgs) Handles ButtonX_ImportMdl.Click
        ButtonX_ImportMdl.Symbol = ""

        Dim romAddr As Integer = ValueFromText(TextBoxX_RomAddr.Text)
        Dim bankAddr As Integer = ValueFromText(TextBoxX_BankAddr.Text)
        Dim maxLength As Integer = ValueFromText(TextBoxX_MaxLength.Text)

        If maxLength > 0 AndAlso mdl.Length > maxLength Then
            MessageBoxEx.Show("Model is bigger then the max allowed length!", "Model too big", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim col As Integer = -1
        Dim geo() As Geopointer = {}
        Dim len As Integer = 0
        Dim sr As AreaModel.SaveResult = Nothing
        Dim iscollisionempty As Boolean = mdl.Collision Is Nothing
        Dim isf3disempty As Boolean = mdl.Fast3DBuffer Is Nothing

        'Write to stream
        sr = mdl.ToRom(_RomFile, romAddr, romAddr - (bankAddr And &HFFFFFF), bankAddr And &HFF000000)

        If sr IsNot Nothing Then
            geo = sr.GeoPointers.ToArray
            col = sr.CollisionPointer
            len = sr.Length
        End If

        ClearOutput()
        If col > -1 Then
            WriteOutput($"Collision Pointer:{vbTab}{sr.CollisionPointer.ToString("X")}")
        End If
        For Each g As Geopointer In sr.GeoPointers
            WriteOutput($"DL-Pointer:{vbTab}{g.SegPointer.ToString("X")} ({g.Layer.ToString})")
        Next
        WriteOutput()
        WriteOutput(DateTime.Now.ToShortTimeString & " - Done")

        'MessageBoxEx.Show("Model has been imported succesfully!", "Model imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ButtonX_ImportMdl.Symbol = ""
    End Sub
End Class
