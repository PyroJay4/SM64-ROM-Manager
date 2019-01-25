Imports System.IO
Imports DevComponents.Editors
Imports Newtonsoft.Json.Linq
Imports SM64Lib
Imports SM64Lib.Data

Public Class RGBEditor

    Public Class RGBEditInfo
        Public Property Name As String = ""
        Public Property AlphaAddress As UInteger? = Nothing
        Public Property LightAddress As UInteger? = Nothing
        Public Property DarkAddress As UInteger? = Nothing
        Public Property DoubleLightRGB As Boolean = False
        Public Property DoubleDarkRGB As Boolean = False
    End Class

    'Declarations

    Private ReadOnly rommgr As RomManager
    Private ReadOnly predifnedEntryFile As String = Path.Combine(MyDataPath, "RGB Editor\RGB Entries.json")
    Private ReadOnly customEntryFile As String = Path.Combine(MyDataPath, "RGB Editor\RGB Entries Custom.json")
    Private ReadOnly predifinedRgbEntries As New List(Of RGBEditInfo)
    Private ReadOnly customRgbEntries As New List(Of RGBEditInfo)

    'Properties

    Private ReadOnly Property CurItem As (item As ComboItem, info As RGBEditInfo)
        Get
            Dim c As ComboItem = comboBox1.SelectedItem
            If c IsNot Nothing Then
                CurItem = (c, Nothing)
                CurItem.info = c.Tag
            Else
                Return Nothing
            End If
        End Get
    End Property

    'Constructor

    Public Sub New(rommgr As RomManager)
        Me.rommgr = rommgr
        InitializeComponent()
        comboBox1.UpdateAmbientColors
        textBox2.UpdateAmbientColors
        textBox3.UpdateAmbientColors
        textBox4.UpdateAmbientColors
        textBox5.UpdateAmbientColors
        textBox6.UpdateAmbientColors
        textBox7.UpdateAmbientColors
        textBox8.UpdateAmbientColors
    End Sub

    'Functions

    Private Sub LoadRgbEntries()
        If File.Exists(predifnedEntryFile) Then
            predifinedRgbEntries.AddRange(JArray.Parse(File.ReadAllText(predifnedEntryFile)).ToObject(Of RGBEditInfo()))
        End If

        If File.Exists(customEntryFile) Then
            customRgbEntries.AddRange(JArray.Parse(File.ReadAllText(customEntryFile)).ToObject(Of RGBEditInfo()))
        End If
    End Sub

    Private Sub SaveRgbEntries()
        File.WriteAllText(customEntryFile, JArray.FromObject(customRgbEntries).ToString)
    End Sub

    Private Sub ListRgbEntries()
        comboBox1.Items.Clear()

        For Each e As RGBEditInfo In predifinedRgbEntries.Concat(customRgbEntries)
            AddComboItem(e)
        Next

        If comboBox1.Items.Count > 0 Then
            comboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub AddComboItem(e As RGBEditInfo)
        Dim c As New ComboItem
        SetTextOnComboItem(c, e)
        c.Tag = e
        comboBox1.Items.Add(c)
    End Sub

    Private Sub SetTextOnComboItem(c As ComboItem, e As RGBEditInfo)
        c.Text = e.Name
    End Sub

    Private Sub AddNewEntry()
        Dim e As RGBEditInfo

        'Edit
        Dim editor As New RGBEditInfoEditor
        If editor.ShowDialog = DialogResult.OK Then
            e = editor.RGBEditInfo

            'Add to lists
            customRgbEntries.Add(e)
            AddComboItem(e)

            'Save Custom Entries
            SaveRgbEntries()
        End If
    End Sub

    Private Function IsPredifined(e As RGBEditInfo) As Boolean
        Return predifinedRgbEntries.Contains(e)
    End Function

    Private Function EditCurEntry() As Boolean
        Dim cur = CurItem

        If Not IsPredifined(cur.info) Then
            'Edit
            Dim editor As New RGBEditInfoEditor With {.RGBEditInfo = cur.info}
            If editor.ShowDialog = DialogResult.OK Then
                'Update list item
                SetTextOnComboItem(cur.item, cur.info)

                'Save Custom Entries
                SaveRgbEntries()

                Return True
            End If
        End If

        Return False
    End Function

    Private Function RemoveEntry() As Boolean
        Dim cur = CurItem

        If Not IsPredifined(cur.info) Then
            'Remove item
            customRgbEntries.Remove(cur.info)
            comboBox1.Items.Remove(cur.item)

            'Select first
            If comboBox1.Items.Count > 0 Then
                comboBox1.SelectedIndex = 0
            End If

            'Save Custom Entries
            SaveRgbEntries()

            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadValues()
        Dim rom As BinaryData = Nothing
        Dim info = CurItem.info
        Dim infoisnotnothing As Boolean = info IsNot Nothing

        button2.Enabled = infoisnotnothing

        If infoisnotnothing Then
            rom = rommgr.GetBinaryRom(FileAccess.Read)

            'Alpha

            Dim enableAlpha As Boolean = info.AlphaAddress IsNot Nothing

            textBox8.Enabled = enableAlpha

            If enableAlpha Then
                rom.Position = info.AlphaAddress
                textBox8.Text = TextFromValue(rom.ReadByte)
            End If

            'Dark

            Dim enableDark As Boolean = info.DarkAddress IsNot Nothing

            textBox5.Enabled = enableDark
            textBox6.Enabled = enableDark
            textBox7.Enabled = enableDark

            If enableDark Then
                rom.Position = info.DarkAddress
                textBox7.Text = TextFromValue(rom.ReadByte)
                textBox6.Text = TextFromValue(rom.ReadByte)
                textBox5.Text = TextFromValue(rom.ReadByte)
            End If

            'Light

            Dim enableLight As Boolean = info.LightAddress IsNot Nothing

            textBox2.Enabled = enableLight
            textBox3.Enabled = enableLight
            textBox4.Enabled = enableLight

            If enableLight Then
                rom.Position = info.LightAddress
                textBox2.Text = TextFromValue(rom.ReadByte)
                textBox3.Text = TextFromValue(rom.ReadByte)
                textBox4.Text = TextFromValue(rom.ReadByte)
            End If

        End If

        rom?.Close()
    End Sub

    Private Sub PatchValues()
        Dim rom As BinaryData = Nothing
        Dim info = CurItem.info

        If info IsNot Nothing Then
            rom = rommgr.GetBinaryRom(FileAccess.ReadWrite)

            'Light

            Dim enableLight As Boolean = info.LightAddress IsNot Nothing

            If enableLight Then
                rom.Position = info.LightAddress
                For i As Integer = 1 To If(info.DoubleLightRGB, 2, 1)
                    rom.WriteByte(ValueFromText(textBox2.Text))
                    rom.WriteByte(ValueFromText(textBox3.Text))
                    rom.WriteByte(ValueFromText(textBox4.Text))
                    rom.Position += 1
                Next
            End If

            'Dark

            Dim enableDark As Boolean = info.DarkAddress IsNot Nothing

            If enableDark Then
                rom.Position = info.DarkAddress
                For i As Integer = 1 To If(info.DoubleDarkRGB, 2, 1)
                    rom.WriteByte(ValueFromText(textBox7.Text))
                    rom.WriteByte(ValueFromText(textBox6.Text))
                    rom.WriteByte(ValueFromText(textBox5.Text))
                    rom.Position += 1
                Next
            End If

            'Alpha

            Dim enableAlpha As Boolean = info.AlphaAddress IsNot Nothing

            If enableAlpha Then
                rom.Position = info.AlphaAddress
                rom.WriteByte(ValueFromText(textBox8.Text))
            End If

        End If

        rom?.Close()
    End Sub

    'User Interface

    Private Sub RGBEditor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadRgbEntries()
        ListRgbEntries()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        PatchValues()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        AddNewEntry()
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX_Edit.Click
        EditCurEntry()
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX_Remove.Click
        RemoveEntry()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
        Dim enableEdit As Boolean = Not IsPredifined(CurItem.info)
        ButtonX_Edit.Enabled = enableEdit
        ButtonX_Remove.Enabled = enableEdit
        LoadValues()
    End Sub

End Class
