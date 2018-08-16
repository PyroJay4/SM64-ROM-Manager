Imports DevComponents.DotNetBar
Imports System.IO
Imports Publics
Imports Publics.Publics
Imports SM64Lib.Geolayout
Imports SM64Lib.Model
Imports TextValueConverter
Imports ModelConverterGUI

Public Class Form_CustomImporter

    Private CI_MtlFile As String = ""
    Private CI_Modelfile As String = ""
    Private CI_Colfile As String = ""
    Private CI_LoadingTextures As Boolean = False
    Private CI_OffsetModelPosition As New Numerics.Vector3
    Private CI_Fog As New Fog

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        UpdateAmbientColors()
        ComboBoxEx_CI_GeoPointerLayer.SelectedIndex = 0

    End Sub

    Private Sub CI_LoadModelList()
        Dim CustomItem As New ListBoxCustomModelItem
        CustomItem.Text = "Custom"
        ListBoxAdv_CI_Objects.Items.Add(CustomItem)

        For Each f As String In Directory.GetFiles(MyDataPath & "\Custom Importer", "*.xml", SearchOption.TopDirectoryOnly)
            Dim item As New ListBoxCustomModelItem
            Dim XML As New Xml.XmlTextReader(f)
            With XML
                Do While .Read
CheckElement:       If .NodeType <> System.Xml.XmlNodeType.Element Then Continue Do
                    Dim tName As String = .Name
                    .Read()
                    If .NodeType <> System.Xml.XmlNodeType.Text Then GoTo CheckElement
                    Select Case tName
                        Case "ram" : item.RamOffset = ValueFromText("0x" & .Value)
                        Case "rom" : item.RomOffset = ValueFromText("0x" & .Value)
                        Case "limit" : item.MaxRomOffset = ValueFromText("0x" & .Value)
                        Case "colpointer" : item.Colpointer = ValueFromText("0x" & .Value)
                        Case "collision" : item.EnableCollision = Convert.ToBoolean(CInt(.Value))
                        Case "geometry" : item.Geopointer.Add(New Geopointer(-1, ValueFromText("0x" & .Value)))
                        Case "extra" : item.ExtraData = .Value
                        Case "obj-name" : item.Text = .Value
                    End Select
                    Application.DoEvents()
                Loop
                XML.Close()
            End With
            If item.Text = "" Then item.Text = Path.GetFileNameWithoutExtension(f)
            ListBoxAdv_CI_Objects.Items.Add(item)
        Next

        ListBoxAdv_CI_Objects.SelectedIndex = 0
    End Sub
    Private Sub ListBoxAdv_CI_Objects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdv_CI_Objects.SelectedIndexChanged
        Dim item As ListBoxCustomModelItem = ListBoxAdv_CI_Objects.SelectedItem
        With item
            TextBoxX_CI_RomOffset.Text = TextFromValue(.RomOffset)
            TextBoxX_CI_RamOffset.Text = TextFromValue(.RamOffset)
            TextBoxX_CI_MaxRomOffset.Text = TextFromValue(.MaxRomOffset)
            TextBoxX_CI_Collisionpointer.Text = TextFromValue(.Colpointer)
            TextBoxX_CI_Code.Text = .ExtraData

            ListBoxAdv_CI_Geopointers.Items.Clear()
            For Each geop As Geopointer In .Geopointer
                Dim layertext As String = ""
                Select Case ComboBoxEx_CI_GeoPointerLayer.SelectedIndex
                    Case 1 : layertext = "Solid"
                    Case 2 : layertext = "Alpha"
                    Case 3 : layertext = "Transparent"
                End Select
                ListBoxAdv_CI_Geopointers.Items.Add(If(layertext <> "", layertext & " - ", "") & TextFromValue(geop.SegPointer))
            Next

            If ListBoxAdv_CI_Geopointers.Items.Count > 0 Then ListBoxAdv_CI_Geopointers.SelectedIndex = 0
        End With
    End Sub
    Private Sub ListBoxAdv_CI_Geopointers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAdv_CI_Geopointers.SelectedIndexChanged
        If ListBoxAdv_CI_Geopointers.SelectedIndex < 0 Then Return

        Dim geop As Geopointer = CType(ListBoxAdv_CI_Objects.SelectedItem, ListBoxCustomModelItem).Geopointer(ListBoxAdv_CI_Geopointers.SelectedIndex)

        With ComboBoxEx_CI_GeoPointerLayer
            Select Case geop.Layer
                Case -1 : .SelectedIndex = 0
                Case 1 : .SelectedIndex = 1
                Case 4 : .SelectedIndex = 2
                Case 5 : .SelectedIndex = 3
            End Select
        End With

        TextBoxX_CI_Geopointer.Text = TextFromValue(geop.SegPointer)
    End Sub
    Private Sub Button_CI_AddGeopointer_Click(sender As Object, e As EventArgs) Handles Button_CI_AddGeopointer.Click

        Dim layervalue As Integer = -1
        Select Case ComboBoxEx_CI_GeoPointerLayer.SelectedIndex
            Case 1 : layervalue = 1
            Case 2 : layervalue = 4
            Case 3 : layervalue = 5
        End Select

        CType(ListBoxAdv_CI_Objects.SelectedItem, ListBoxCustomModelItem).Geopointer.Add(New Geopointer(layervalue, ValueFromText(TextBoxX_CI_Geopointer.Text)))

        Dim layertext As String = ""
        Select Case ComboBoxEx_CI_GeoPointerLayer.SelectedIndex
            Case 1 : layertext = "Solid"
            Case 2 : layertext = "Alpha"
            Case 3 : layertext = "Transparent"
        End Select
        ListBoxAdv_CI_Geopointers.Items.Add(If(layertext <> "", layertext & " - ", "") & TextFromValue(ValueFromText(TextBoxX_CI_Geopointer.Text)))
        ListBoxAdv_CI_Geopointers.SelectedIndex = ListBoxAdv_CI_Geopointers.Items.Count - 1
    End Sub
    Private Sub Button_CI_RemoveGeopointer_Click(sender As Object, e As EventArgs) Handles Button_CI_RemoveGeopointer.Click
        Button_CI_RemoveGeopointer.Enabled = ListBoxAdv_CI_Geopointers.SelectedIndex > 0
        If Not Button_CI_RemoveGeopointer.Enabled Then Return
        ListBoxAdv_CI_Geopointers.Items.Remove(ListBoxAdv_CI_Geopointers.SelectedItem)
    End Sub
    Private Sub Button_CI_SaveObjectList_Click(sender As Object, e As EventArgs) Handles Button_CI_SaveObjectList.Click
        'Dim curciitem As ListBoxCustomModelItem = ListBoxAdv_CI_Objects.SelectedItem

        ''Convert Model
        'Dim frm As New MainModelConverter
        'frm.CheckBoxX_ConvertCollision.Enabled = False
        'frm.CheckBoxX_ConvertModel.Enabled = False
        'If frm.ShowDialog(CI_Modelfile, CI_Colfile) <> DialogResult.OK Then Return

        'Dim res As AreaModel = frm.resModel
        'Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.ReadWrite)
        'Dim bw As New BinaryWriter(fs)

        ''Write Model to ROM
        'Dim bankOffset As Integer = curciitem.RamOffset
        'Dim bankStart As Integer = bankOffset And &HFF000000
        'Dim romOffset As Integer = curciitem.RomOffset
        'Dim maxRomOffset As Integer = curciitem.MaxRomOffset

        'Dim saveRes As AreaModel.SaveResult = res.ToStream(fs, romOffset, romOffset - (bankOffset And &HFFFFFF), bankStart)

        ''Write Collision Pointer
        'If frm.CheckBoxX_ConvertCollision.Checked Then
        '    fs.Position = curciitem.Colpointer
        '    bw.Write(SwapInts.SwapInt32(saveRes.CollisionPointer))
        'End If

        ''Write Geopointer
        'Dim geops As Geopointer() = curciitem.Geopointer.ToArray

        'If saveRes.GeoPointers.Count > 0 Then
        '    For Each resgeop As Geopointer In saveRes.GeoPointers
        '        For Each geop As Geopointer In geops.Where(Function(n) n.Layer = -1 OrElse n.Layer = resgeop.Layer)
        '            'Write Pointer
        '            fs.Position = CInt("&H" & geop.SegPointer)
        '            bw.Write(SwapInts.SwapInt32(resgeop.SegPointer))

        '            'Check Layer
        '            If geop.Layer <> -1 Then

        '                fs.Position -= &H8
        '                If fs.ReadByte = &H15 Then
        '                    fs.WriteByte(resgeop.Layer)
        '                    Exit For
        '                End If
        '            End If
        '        Next
        '    Next

        '    'For i As Integer = 0 To saveRes.GeoPointers.Count - 1
        '    '    Dim resgeop As Geolayout.Geopointer = saveRes.GeoPointers(i)
        '    '    Dim mygeops() = geops.Where(Function(n) n.Layer = -1 OrElse n.Layer = resgeop.Layer).ToArray

        '    '    For j As Integer = 0 To mygeops.Length - 1
        '    '        Dim geop As Geolayout.Geopointer = mygeops(j)


        '    '        'Write Pointer
        '    '        fs.Position = CInt("&H" & geop.SegPointer)
        '    '        bw.Write(SwapInts.SwapInt32(.SegPointer))

        '    '        'Check Layer
        '    '        If geop.Layer <> -1 Then

        '    '            fs.Position -= &H8
        '    '            If fs.ReadByte = &H15 Then
        '    '                fs.WriteByte(resgeop.Layer)
        '    '                Exit For
        '    '            End If
        '    '        End If

        '    '    Next

        '    'Next

        '    'Dim resGeoIndex As Integer = 0
        '    'Dim GeoIndex As Integer = 0

        '    'Do While (geops.Length > GeoIndex) AndAlso (saveRes.GeoPointers.Count > resGeoIndex)





        '    'Loop



        'End If

        'fs.Close()

        ''Apply Tweak
        'If SwitchButton_CI_ApplyTweakFile.Value Then
        '    If Debugger.IsAttached Then
        '        Throw New NotImplementedException
        '    Else
        '        MessageBoxEx.Show("The Code hasn't been patched. The Patch-Engine is missing and is comming with an future update.", "Missing Patch-Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End If

        'MessageBoxEx.Show("Model successfully imported!", "Model Imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form_CustomImporter_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CI_LoadModelList()
    End Sub
End Class