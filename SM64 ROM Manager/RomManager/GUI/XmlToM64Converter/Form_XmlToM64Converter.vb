Imports System.ComponentModel
Imports System.Text
Imports System.Xml
Imports System.IO
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar

Public Class Form_XmlToM64Converter

    Public TrackDuration As Single = 0
    Public LastTimestamp As Single = 0
    Public StaffWithoutName As Integer = 0
    Public isChord As Boolean
    Public ChordCount As Integer
    Public XmlFile As String = ""

    Private Function CheckBoxState(ByVal chbox As CheckBox) As String
        If chbox.Checked = True Then
            Return "1"
        Else
            Return "0"
        End If
    End Function
    Private Function CheckBoxState(ByVal chbox As CheckBoxX) As String
        If chbox.Checked = True Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Private Sub SetCheckBoxState(ByVal check As CheckBox, ByVal value As String)
        If value = "1" Then
            check.Checked = True
        Else
            check.Checked = False
        End If

    End Sub
    Private Sub SetCheckBoxState(ByVal check As CheckBoxX, ByVal value As String)
        If value = "1" Then
            check.Checked = True
        Else
            check.Checked = False
        End If

    End Sub

    Private Sub ClearParts()
        PartCh1.Items.Clear()
        PartCh2.Items.Clear()
        PartCh3.Items.Clear()
        PartCh4.Items.Clear()
        PartCh5.Items.Clear()
        PartCh6.Items.Clear()
        PartCh7.Items.Clear()
        PartCh8.Items.Clear()
        PartCh9.Items.Clear()
        PartCh10.Items.Clear()
        PartCh11.Items.Clear()
        PartCh12.Items.Clear()
        PartCh13.Items.Clear()
        PartCh14.Items.Clear()
        PartCh15.Items.Clear()
        PartCh16.Items.Clear()
    End Sub

    Private Sub AddInstrument(ByVal inst As String)
        InstCh1.Items.Add(inst)
        InstCh2.Items.Add(inst)
        InstCh3.Items.Add(inst)
        InstCh4.Items.Add(inst)
        InstCh5.Items.Add(inst)
        InstCh6.Items.Add(inst)
        InstCh7.Items.Add(inst)
        InstCh8.Items.Add(inst)
        InstCh9.Items.Add(inst)
        InstCh10.Items.Add(inst)
        InstCh11.Items.Add(inst)
        InstCh12.Items.Add(inst)
        InstCh13.Items.Add(inst)
        InstCh14.Items.Add(inst)
        InstCh15.Items.Add(inst)
        InstCh16.Items.Add(inst)
    End Sub

    Private Sub AddBlankInstruments(ByVal InstCount As Integer)
        For i As Integer = 0 To InstCount - 1
            InstCh1.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh2.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh3.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh4.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh5.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh6.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh7.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh8.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh9.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh10.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh11.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh12.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh13.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh14.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh15.Items.Add("Sound" & i.ToString() & " - ?? ")
            InstCh16.Items.Add("Sound" & i.ToString() & " - ?? ")
        Next i
    End Sub

    Public Sub New()
        InitializeComponent()
        StyleManager.UpdateAmbientColors(Me)
    End Sub

    Public Sub EnableChannels()
        Ch1.Enabled = True
        PartCh1.Enabled = True
        InstCh1.Enabled = True
        VolCh1.Enabled = True
        PanCh1.Enabled = True
        TransCh1.Enabled = True
        PartCh1.SelectedIndex = 0

        Ch2.Enabled = True
        PartCh2.Enabled = True
        InstCh2.Enabled = True
        VolCh2.Enabled = True
        PanCh2.Enabled = True
        TransCh2.Enabled = True
        PartCh2.SelectedIndex = 0

        Ch3.Enabled = True
        PartCh3.Enabled = True
        InstCh3.Enabled = True
        VolCh3.Enabled = True
        PanCh3.Enabled = True
        TransCh3.Enabled = True
        PartCh3.SelectedIndex = 0

        Ch4.Enabled = True
        PartCh4.Enabled = True
        InstCh4.Enabled = True
        VolCh4.Enabled = True
        PanCh4.Enabled = True
        TransCh4.Enabled = True
        PartCh4.SelectedIndex = 0

        Ch5.Enabled = True
        PartCh5.Enabled = True
        InstCh5.Enabled = True
        VolCh5.Enabled = True
        PanCh5.Enabled = True
        TransCh5.Enabled = True
        PartCh5.SelectedIndex = 0

        Ch6.Enabled = True
        PartCh6.Enabled = True
        InstCh6.Enabled = True
        VolCh6.Enabled = True
        PanCh6.Enabled = True
        TransCh6.Enabled = True
        PartCh6.SelectedIndex = 0

        Ch7.Enabled = True
        PartCh7.Enabled = True
        InstCh7.Enabled = True
        VolCh7.Enabled = True
        PanCh7.Enabled = True
        TransCh7.Enabled = True
        PartCh7.SelectedIndex = 0

        Ch8.Enabled = True
        PartCh8.Enabled = True
        InstCh8.Enabled = True
        VolCh8.Enabled = True
        PanCh8.Enabled = True
        TransCh8.Enabled = True
        PartCh8.SelectedIndex = 0

        Ch9.Enabled = True
        PartCh9.Enabled = True
        InstCh9.Enabled = True
        VolCh9.Enabled = True
        PanCh9.Enabled = True
        TransCh9.Enabled = True
        PartCh9.SelectedIndex = 0

        Ch10.Enabled = True
        PartCh10.Enabled = True
        InstCh10.Enabled = True
        VolCh10.Enabled = True
        PanCh10.Enabled = True
        TransCh10.Enabled = True
        PartCh10.SelectedIndex = 0

        Ch11.Enabled = True
        PartCh11.Enabled = True
        InstCh11.Enabled = True
        VolCh11.Enabled = True
        PanCh11.Enabled = True
        TransCh11.Enabled = True
        PartCh11.SelectedIndex = 0

        Ch12.Enabled = True
        PartCh12.Enabled = True
        InstCh12.Enabled = True
        VolCh12.Enabled = True
        PanCh12.Enabled = True
        TransCh12.Enabled = True
        PartCh12.SelectedIndex = 0

        Ch13.Enabled = True
        PartCh13.Enabled = True
        InstCh13.Enabled = True
        VolCh13.Enabled = True
        PanCh13.Enabled = True
        TransCh13.Enabled = True
        PartCh13.SelectedIndex = 0

        Ch14.Enabled = True
        PartCh14.Enabled = True
        InstCh14.Enabled = True
        VolCh14.Enabled = True
        PanCh14.Enabled = True
        TransCh14.Enabled = True
        PartCh14.SelectedIndex = 0

        Ch15.Enabled = True
        PartCh15.Enabled = True
        InstCh15.Enabled = True
        VolCh15.Enabled = True
        PanCh15.Enabled = True
        TransCh15.Enabled = True
        PartCh15.SelectedIndex = 0

        Ch16.Enabled = True
        PartCh16.Enabled = True
        InstCh16.Enabled = True
        VolCh16.Enabled = True
        PanCh16.Enabled = True
        TransCh16.Enabled = True
        PartCh16.SelectedIndex = 0

    End Sub

    Public Sub DisableChannels()
        Ch1.Enabled = False
        PartCh1.Enabled = False
        InstCh1.Enabled = False
        VolCh1.Enabled = False
        PanCh1.Enabled = False
        TransCh1.Enabled = False
        PartCh1.Items.Clear()

        Ch2.Enabled = False
        PartCh2.Enabled = False
        InstCh2.Enabled = False
        VolCh2.Enabled = False
        PanCh2.Enabled = False
        TransCh2.Enabled = False
        PartCh2.Items.Clear()

        Ch3.Enabled = False
        PartCh3.Enabled = False
        InstCh3.Enabled = False
        VolCh3.Enabled = False
        PanCh3.Enabled = False
        TransCh3.Enabled = False
        PartCh3.Items.Clear()

        Ch4.Enabled = False
        PartCh4.Enabled = False
        InstCh4.Enabled = False
        VolCh4.Enabled = False
        PanCh4.Enabled = False
        TransCh4.Enabled = False
        PartCh4.Items.Clear()

        Ch5.Enabled = False
        PartCh5.Enabled = False
        InstCh5.Enabled = False
        VolCh5.Enabled = False
        PanCh5.Enabled = False
        TransCh5.Enabled = False
        PartCh5.Items.Clear()

        Ch6.Enabled = False
        PartCh6.Enabled = False
        InstCh6.Enabled = False
        VolCh6.Enabled = False
        PanCh6.Enabled = False
        TransCh6.Enabled = False
        PartCh6.Items.Clear()

        Ch7.Enabled = False
        PartCh7.Enabled = False
        InstCh7.Enabled = False
        VolCh7.Enabled = False
        PanCh7.Enabled = False
        TransCh7.Enabled = False
        PartCh7.Items.Clear()

        Ch8.Enabled = False
        PartCh8.Enabled = False
        InstCh8.Enabled = False
        VolCh8.Enabled = False
        PanCh8.Enabled = False
        TransCh8.Enabled = False
        PartCh8.Items.Clear()

        Ch9.Enabled = False
        PartCh9.Enabled = False
        InstCh9.Enabled = False
        VolCh9.Enabled = False
        PanCh9.Enabled = False
        TransCh9.Enabled = False
        PartCh9.Items.Clear()

        Ch10.Enabled = False
        PartCh10.Enabled = False
        InstCh10.Enabled = False
        VolCh10.Enabled = False
        PanCh10.Enabled = False
        TransCh10.Enabled = False
        PartCh10.Items.Clear()

        Ch11.Enabled = False
        PartCh11.Enabled = False
        InstCh11.Enabled = False
        VolCh11.Enabled = False
        PanCh11.Enabled = False
        TransCh11.Enabled = False
        PartCh11.Items.Clear()

        Ch12.Enabled = False
        PartCh12.Enabled = False
        InstCh12.Enabled = False
        VolCh12.Enabled = False
        PanCh12.Enabled = False
        TransCh12.Enabled = False
        PartCh12.Items.Clear()

        Ch13.Enabled = False
        PartCh13.Enabled = False
        InstCh13.Enabled = False
        VolCh13.Enabled = False
        PanCh13.Enabled = False
        TransCh13.Enabled = False
        PartCh13.Items.Clear()

        Ch14.Enabled = False
        PartCh14.Enabled = False
        InstCh14.Enabled = False
        VolCh14.Enabled = False
        PanCh14.Enabled = False
        TransCh14.Enabled = False
        PartCh14.Items.Clear()

        Ch15.Enabled = False
        PartCh15.Enabled = False
        InstCh15.Enabled = False
        VolCh15.Enabled = False
        PanCh15.Enabled = False
        TransCh15.Enabled = False
        PartCh15.Items.Clear()

        Ch16.Enabled = False
        PartCh16.Enabled = False
        InstCh16.Enabled = False
        VolCh16.Enabled = False
        PanCh16.Enabled = False
        TransCh16.Enabled = False
        PartCh16.Items.Clear()

    End Sub

    Public Sub AddPart(ByVal part As String)
        PartCh1.Items.Add(part)
        PartCh2.Items.Add(part)
        PartCh3.Items.Add(part)
        PartCh4.Items.Add(part)
        PartCh5.Items.Add(part)
        PartCh6.Items.Add(part)
        PartCh7.Items.Add(part)
        PartCh8.Items.Add(part)
        PartCh9.Items.Add(part)
        PartCh10.Items.Add(part)
        PartCh11.Items.Add(part)
        PartCh12.Items.Add(part)
        PartCh13.Items.Add(part)
        PartCh14.Items.Add(part)
        PartCh15.Items.Add(part)
        PartCh16.Items.Add(part)
    End Sub

    Private Sub LoadXML_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoadXML.Click
        Dim dlg As New OpenFileDialog()
        dlg.Title = "Choose MusicXML file"
        dlg.Filter = "(.xml)|*.xml"

        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            lbXmlFile.Text = dlg.FileName

        End If

    End Sub

    Private Sub InstrumentCh1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PartCh1.SelectedIndexChanged

    End Sub

    Private Sub MusicXMLImporter_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        DisableChannels()
        XmlFile = ""
        cbInstSet.SelectedIndex = 17

    End Sub

    Private Sub InstCh1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InstCh1.SelectedIndexChanged

    End Sub

    Private Sub VolCh1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles VolCh1.Scroll

    End Sub

    Private Sub trackBar27_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles VolCh15.Scroll

    End Sub

    Private Sub XMLFile_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lbXmlFile.TextChanged, lbXmlFile.TextChanged

        If XmlFile IsNot "" Then
            ClearParts()
            StaffWithoutName = 0

            Dim streamReader As New StreamReader(lbXmlFile.Text)
            'INSTANT VB NOTE: The variable xmlfile was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim xmlfile_Renamed As String = streamReader.ReadToEnd()
            streamReader.Close()

            Dim doc As New XmlDocument()

            Try
                doc.XmlResolver = Nothing
                doc.LoadXml(xmlfile_Renamed)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                Return
            End Try

            Dim Path As New FileInfo(Application.ExecutablePath)
            Dim PartPath As String = Path.DirectoryName & "\parts.txt"
            Dim DebugText As New StreamWriter(PartPath)

            Dim parts As XmlNodeList = doc.GetElementsByTagName("part")

            If parts.Count = 0 Then
                MessageBox.Show("Not a valid MusicXML file (no parts found)")
            End If

            If parts.Count <> 0 Then

                For Each node As XmlNode In parts

                    TrackDuration = 0
                    LastTimestamp = 0

                    DebugText.Write("Part ")
                    Dim part As XmlElement = CType(node, XmlElement)

                    If part.HasAttribute("id") Then
                        Dim ID As String = part.Attributes("id").InnerText
                        DebugText.Write(ID & vbLf)

                        Dim scoreparts As XmlNodeList = doc.GetElementsByTagName("score-part")

                        For Each node3 As XmlNode In scoreparts
                            Dim scorepart As XmlElement = CType(node3, XmlElement)

                            If scorepart.HasAttribute("id") Then
                                Dim partname As String = scorepart.Attributes("id").InnerText

                                If partname = ID Then

                                    Dim partname2 As XmlNodeList = scorepart.GetElementsByTagName("part-name")

                                    If partname2.Count <> 0 Then
                                        'INSTANT VB NOTE: The variable PartName was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
                                        Dim PartName_Renamed As String = partname2(0).InnerText

                                        StaffWithoutName += 1
                                        If PartName_Renamed = "" Then
                                            PartName_Renamed = "Unnamed staff #" & StaffWithoutName.ToString()
                                        End If

                                        DebugText.Write("Partname " & PartName_Renamed & vbLf)
                                        AddPart(PartName_Renamed)


                                    End If
                                End If

                            End If

                        Next node3

                    End If

                    Dim div As XmlNodeList = part.GetElementsByTagName("divisions")
                    Dim partdivision As Single = Convert.ToSingle(div(0).InnerText)
                    Dim divnumber As Single = 48 / partdivision

                    ' Proceed measure-wise

                    Dim measure As XmlNodeList = part.GetElementsByTagName("measure")

                    Dim MeasureLenght As Integer = 0
                    Dim MeasureTime As Integer = 0

                    For Each measurenode As XmlNode In measure
                        Dim currentmeasure As XmlElement = CType(measurenode, XmlElement)
                        DebugText.Write("New Measure (" & String.Format("{0:x}", MeasureTime) & ")" & vbLf)

                        Dim time As XmlNodeList = currentmeasure.GetElementsByTagName("time")
                        If time.Count <> 0 Then
                            Dim beats As XmlNodeList = currentmeasure.GetElementsByTagName("beats")
                            Dim beat_type As XmlNodeList = currentmeasure.GetElementsByTagName("beat-type")

                            Dim BeatLenght As Integer = 0
                            Select Case beat_type(0).InnerText
                                Case "8"
                                    BeatLenght = &H18

                                Case "4"
                                    BeatLenght = &H30

                                Case "2"
                                    BeatLenght = &H60
                            End Select

                            MeasureLenght = BeatLenght * Convert.ToInt32(beats(0).InnerText)
                        End If

                        MeasureTime += MeasureLenght

                        Dim note As XmlNodeList = currentmeasure.GetElementsByTagName("note")

                        For Each node2 As XmlNode In note

                            Dim notes As XmlElement = CType(node2, XmlElement)
                            Dim duration As XmlNodeList = notes.GetElementsByTagName("duration")
                            Dim pitch As XmlNodeList = notes.GetElementsByTagName("pitch")
                            Dim staff As XmlNodeList = notes.GetElementsByTagName("staff")
                            Dim rest As XmlNodeList = notes.GetElementsByTagName("rest")
                            Dim chord As XmlNodeList = notes.GetElementsByTagName("chord")
                            Dim voice As XmlNodeList = notes.GetElementsByTagName("voice")
                            Dim tie As XmlNodeList = notes.GetElementsByTagName("tie")

                            If voice.Count <> 0 Then
                                If voice(0).InnerText <> "1" Then
                                    GoTo SkipNote
                                End If
                            End If

                            If staff.Count <> 0 Then
                                If staff(0).InnerText <> "1" Then
                                    GoTo SkipNote
                                End If
                            End If

                            If chord.Count <> 0 Then
                                ChordCount += 1 ' so that first element isn't 0
                                isChord = True
                                DebugText.Write("chord " & ChordCount.ToString() & " ")
                            Else
                                isChord = False
                                ChordCount = 0
                            End If

                            If pitch.Count <> 0 Then
                                If pitch(0).ChildNodes.Count > 1 Then
                                    Dim [step] As XmlNodeList = notes.GetElementsByTagName("step")
                                    Dim alter As XmlNodeList = notes.GetElementsByTagName("alter")
                                    Dim octave As XmlNodeList = notes.GetElementsByTagName("octave")

                                    If isChord = False Then
                                        DebugText.Write("note ")
                                    End If

                                    Dim notenumber As Integer = 0
                                    Select Case [step](0).InnerText
                                        Case "A"
                                            notenumber = 9

                                        Case "B"
                                            notenumber = 11

                                        Case "C"
                                            notenumber = 0

                                        Case "D"
                                            notenumber = 2

                                        Case "E"
                                            notenumber = 4

                                        Case "F"
                                            notenumber = 5

                                        Case "G"
                                            notenumber = 7
                                    End Select

                                    Dim octavenumber As Integer = Convert.ToInt32(octave(0).InnerText)

                                    If octavenumber = 0 Then
                                        notenumber = notenumber + 3
                                    Else
                                        notenumber = (notenumber + ((octavenumber - 1) * 12)) + 3
                                    End If

                                    If notenumber < 0 Then
                                        notenumber = 0
                                    End If

                                    If alter.Count <> 0 Then
                                        notenumber += Convert.ToInt32(alter(0).InnerText)
                                    End If

                                    DebugText.Write(String.Format("{0:x2} ", CUInt(System.Convert.ToUInt32(Convert.ToString(notenumber)))))

                                    If duration.Count <> 0 Then
                                        Dim divduration As Single = Convert.ToSingle(duration(0).InnerText) * divnumber

                                        If isChord = False Then
                                            TrackDuration += divduration
                                        End If

                                        If isChord = False Then
                                            LastTimestamp = divduration
                                        End If

                                        DebugText.Write(String.Format("{0:x2} ", CUInt(System.Convert.ToUInt32(Convert.ToString(divduration)))))
                                    End If

                                    DebugText.Write("64 10") ' note, velocity, gate time, duration comes after

                                    Dim tieStatus As Integer = 0

                                    If tie.Count <> 0 Then
                                        For Each tienode As XmlNode In tie
                                            Dim tied As XmlElement = CType(tienode, XmlElement)
                                            If tied.HasAttribute("type") Then
                                                If tied.Attributes("type").InnerText = "stop" Then
                                                    tieStatus = 2
                                                End If
                                                If tied.Attributes("type").InnerText = "start" Then
                                                    tieStatus = 1
                                                End If
                                            End If
                                        Next tienode
                                    End If
                                    DebugText.Write(" " & tieStatus.ToString() & " ")
                                    DebugText.Write(String.Format("{0:x}", CUInt(System.Convert.ToUInt32(Convert.ToString(TrackDuration - LastTimestamp)))))
                                    DebugText.Write(vbLf)
                                End If
                            End If

                            If rest.Count <> 0 Then
                                DebugText.Write("rest ")

                                If duration.Count <> 0 Then
                                    Dim divduration As Single = Convert.ToSingle(duration(0).InnerText) * divnumber

                                    TrackDuration += divduration

                                    LastTimestamp = divduration

                                    DebugText.Write(String.Format("{0:x2}", CUInt(System.Convert.ToUInt32(Convert.ToString(divduration)))))
                                    DebugText.Write(" " & String.Format("{0:x}" & vbLf, CUInt(System.Convert.ToUInt32(Convert.ToString(TrackDuration - LastTimestamp)))))
                                End If
                            End If
SkipNote:

                        Next node2

                    Next measurenode
                    DebugText.Write(String.Format("TotalTimestamp {0:x2}" & vbLf, CUInt(System.Convert.ToUInt32(Convert.ToString(TrackDuration)))))

                Next node
                DebugText.Close()
                EnableChannels()

            End If


        End If
    End Sub

    Private Sub label9_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub InstSet_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbInstSet.SelectedIndexChanged
        InstCh1.Items.Clear()
        InstCh2.Items.Clear()
        InstCh3.Items.Clear()
        InstCh4.Items.Clear()
        InstCh5.Items.Clear()
        InstCh6.Items.Clear()
        InstCh7.Items.Clear()
        InstCh8.Items.Clear()
        InstCh9.Items.Clear()
        InstCh10.Items.Clear()
        InstCh11.Items.Clear()
        InstCh12.Items.Clear()
        InstCh13.Items.Clear()
        InstCh14.Items.Clear()
        InstCh15.Items.Clear()
        InstCh16.Items.Clear()


        If cbInstSet.SelectedIndex = 0 Then
            AddBlankInstruments(6)
        ElseIf cbInstSet.SelectedIndex = 1 Then
            AddBlankInstruments(9)
        ElseIf cbInstSet.SelectedIndex = 2 Then
            AddBlankInstruments(3)
        ElseIf cbInstSet.SelectedIndex = 3 Then
            AddBlankInstruments(&HA)
        ElseIf cbInstSet.SelectedIndex = 4 Then
            AddBlankInstruments(&H10)
        ElseIf cbInstSet.SelectedIndex = 5 Then
            AddBlankInstruments(&H10)
        ElseIf cbInstSet.SelectedIndex = 6 Then
            AddBlankInstruments(&H10)
        ElseIf cbInstSet.SelectedIndex = 7 Then
            AddBlankInstruments(&HF)
        ElseIf cbInstSet.SelectedIndex = 8 Then
            AddBlankInstruments(&H1B)
        ElseIf cbInstSet.SelectedIndex = 9 Then
            AddBlankInstruments(7)
        ElseIf cbInstSet.SelectedIndex = 10 Then
            AddBlankInstruments(&H18)
        ElseIf cbInstSet.SelectedIndex = 11 Then
            AddInstrument("00 - Acoustic Guitar")
            AddInstrument("01 - Accordeon")
            AddInstrument("02 - Ac??")
            AddInstrument("03 - Ac??")
            AddInstrument("04 - Ac??")
            AddInstrument("05 - Ac??")
            AddInstrument("06 - Low Accordeon")
            AddInstrument("07 - 07?")
            AddInstrument("08 - ??")
            AddInstrument("09 - ??")
            AddInstrument("10 - Crash Cymbal")
            AddInstrument("11 - Cymbal 2(?)")
        ElseIf cbInstSet.SelectedIndex = 12 Then
            AddInstrument("00 - ")
            AddInstrument("01 - ")
            AddInstrument("02 - ")
            AddInstrument("03 - ")
            AddInstrument("04 - ")
            AddInstrument("05 - ")
            AddInstrument("06 - Low instrument?")
            AddInstrument("07 - Recorder")
            AddInstrument("08 - ")
            AddInstrument("09 - ")
            AddInstrument("10 - ")
            AddInstrument("11 - Clash Cymbal")
            AddInstrument("12 - Snare Drum")
            AddInstrument("13 - Triangle")
            AddInstrument("14 - Triangle")
            AddInstrument("15 - Sine wave-like sound")
        ElseIf cbInstSet.SelectedIndex = 13 Then
            AddInstrument("00 - Banjo")
            AddInstrument("01 - Test me!")
            AddInstrument("02 - Fiddle")
            AddInstrument("03 - Test me!")
            AddInstrument("04 - Whistle with vibrato")
            AddInstrument("05 - Test me!")
            AddInstrument("06 - Acoustic Bass")
            AddInstrument("07 - Acoustic Bass")
            AddInstrument("08 - Acoustic Bass")
            AddInstrument("09 - Acoustic Bass")
            AddInstrument("10 - Test me!")
            AddInstrument("11 - Test me!")
            AddInstrument("12 - Test me!")
        ElseIf cbInstSet.SelectedIndex = 14 Then
            AddInstrument("00 - Strings")
            AddInstrument("01 - ?")
            AddInstrument("02 - ?")
            AddInstrument("03 - Pizzicato String")
            AddInstrument("04 - Cello (or low woodwind?)")
            AddInstrument("05 - Eletric Piano")
            AddInstrument("06 - ?")
        ElseIf cbInstSet.SelectedIndex = 15 Then
            AddInstrument("00 - Percussion loop")
            AddInstrument("01 - Voice 'Uhs'")
            AddInstrument("02 - Sitar drone notes")
            AddInstrument("03 - Sitar")
        ElseIf cbInstSet.SelectedIndex = 16 Then
            AddInstrument("00 - Low drone-like haunted sound")
            AddInstrument("01 - ")
            AddInstrument("02 - Low Cowbell")
            AddInstrument("03 - ")
            AddInstrument("04 - High Cowbell")
            AddInstrument("05 - ")
            AddInstrument("06 - ")
        ElseIf cbInstSet.SelectedIndex = 17 Then
            AddInstrument("00 - Snare Drum")
            AddInstrument("01 - Fingered Bass")
            AddInstrument("02 - Fingered Bass")
            AddInstrument("03 - Organ")
            AddInstrument("04 - Steel Drum")
            AddInstrument("05 - Trumpet")
            AddInstrument("06 - Slap Bass")
            AddInstrument("07 - Synth")
            AddInstrument("08 - Clavinet")
            AddInstrument("09 - Clavinet")
            AddInstrument("10 - Drum Sample (hi-hat)")
            AddInstrument("11 - Drum Sample")
            AddInstrument("12 - Drum Sample")
            AddInstrument("13 - Drum Sample")
        ElseIf cbInstSet.SelectedIndex = 18 Then
            AddBlankInstruments(&HC)
        ElseIf cbInstSet.SelectedIndex = 19 Then
            AddBlankInstruments(&H10)
        ElseIf cbInstSet.SelectedIndex = 20 Then
            AddBlankInstruments(5)
        ElseIf cbInstSet.SelectedIndex = 21 Then
            AddBlankInstruments(&HA)
        ElseIf cbInstSet.SelectedIndex = 22 Then
            AddBlankInstruments(2)
        ElseIf cbInstSet.SelectedIndex = 23 Then
            AddBlankInstruments(&HD)
        ElseIf cbInstSet.SelectedIndex = 24 Then
            AddBlankInstruments(&HF)
        ElseIf cbInstSet.SelectedIndex = 25 Then
            AddBlankInstruments(&HD)
        ElseIf cbInstSet.SelectedIndex = 26 Then
            AddBlankInstruments(&HD)
        ElseIf cbInstSet.SelectedIndex = 27 Then
            AddBlankInstruments(&HC)
        ElseIf cbInstSet.SelectedIndex = 28 Then
            AddBlankInstruments(7)
        ElseIf cbInstSet.SelectedIndex = 29 Then
            AddBlankInstruments(6)
        ElseIf cbInstSet.SelectedIndex = 30 Then
            AddBlankInstruments(4)
        ElseIf cbInstSet.SelectedIndex = 31 Then
            AddBlankInstruments(&HD)
        ElseIf cbInstSet.SelectedIndex = 32 Then
            AddBlankInstruments(9)
        ElseIf cbInstSet.SelectedIndex = 33 Then
            AddBlankInstruments(4)
        ElseIf cbInstSet.SelectedIndex = 34 Then
            AddBlankInstruments(&HC)
        ElseIf cbInstSet.SelectedIndex = 35 Then
            AddBlankInstruments(&H8)
        ElseIf cbInstSet.SelectedIndex = 36 Then
            AddBlankInstruments(&HA)
        ElseIf cbInstSet.SelectedIndex = 37 Then
            AddBlankInstruments(&H10)
        End If

        InstCh1.SelectedIndex = 0
        InstCh2.SelectedIndex = 0
        InstCh3.SelectedIndex = 0
        InstCh4.SelectedIndex = 0
        InstCh5.SelectedIndex = 0
        InstCh6.SelectedIndex = 0
        InstCh7.SelectedIndex = 0
        InstCh8.SelectedIndex = 0
        InstCh9.SelectedIndex = 0
        InstCh10.SelectedIndex = 0
        InstCh11.SelectedIndex = 0
        InstCh12.SelectedIndex = 0
        InstCh13.SelectedIndex = 0
        InstCh14.SelectedIndex = 0
        InstCh15.SelectedIndex = 0
        InstCh16.SelectedIndex = 0

    End Sub

    Private Sub producem64FileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles producem64FileToolStripMenuItem.Click

        If XmlFile = "" Then
            MessageBox.Show("Load a valid MusicXML file first!", "Error!", 0, MessageBoxIcon.Error)
            Return
        End If

        If Ch1.Checked = False AndAlso Ch2.Checked = False AndAlso Ch3.Checked = False AndAlso Ch4.Checked = False AndAlso Ch5.Checked = False AndAlso Ch6.Checked = False AndAlso Ch7.Checked = False AndAlso Ch8.Checked = False AndAlso Ch9.Checked = False AndAlso Ch10.Checked = False AndAlso Ch11.Checked = False AndAlso Ch12.Checked = False AndAlso Ch13.Checked = False AndAlso Ch14.Checked = False AndAlso Ch15.Checked = False AndAlso Ch16.Checked = False Then
            MessageBox.Show("No channels selected!", "Error!", 0, MessageBoxIcon.Error)
            Return
        End If

        Dim Path As New FileInfo(Application.ExecutablePath)
        Dim SettingsPath As String = Path.DirectoryName & "\settings.txt"
        Dim ImportSettings As New StreamWriter(SettingsPath)

        ImportSettings.WriteLine("Tempo " & Tempo.Value.ToString())
        ImportSettings.Write("Loop ")
        If cbLoopSequence.Checked = True Then
            ImportSettings.WriteLine("1")
        Else
            ImportSettings.WriteLine("0")
        End If

        ImportSettings.WriteLine("GlobalVolume " & GlobalVolume.Value.ToString())
        ImportSettings.WriteLine("GlobalTrans " & GlobalTransposition.Value.ToString())
        ImportSettings.WriteLine("NInst " & cbInstSet.SelectedIndex.ToString())

        If Ch1.Checked = True Then
            ImportSettings.Write("Ch 1 ")
            ImportSettings.Write(PartCh1.Text & vbLf & "ChSet 1 ")
            ImportSettings.Write(InstCh1.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh1.Value.ToString() & " ")
            ImportSettings.Write(PanCh1.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh1.Value.ToString())
        End If
        If Ch2.Checked = True Then
            ImportSettings.Write("Ch 2 ")
            ImportSettings.Write(PartCh2.Text & vbLf & "ChSet 2 ")
            ImportSettings.Write(InstCh2.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh2.Value.ToString() & " ")
            ImportSettings.Write(PanCh2.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh2.Value.ToString())
        End If
        If Ch3.Checked = True Then
            ImportSettings.Write("Ch 3 ")
            ImportSettings.Write(PartCh3.Text & vbLf & "ChSet 3 ")
            ImportSettings.Write(InstCh3.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh3.Value.ToString() & " ")
            ImportSettings.Write(PanCh3.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh3.Value.ToString())
        End If
        If Ch4.Checked = True Then
            ImportSettings.Write("Ch 4 ")
            ImportSettings.Write(PartCh4.Text & vbLf & "ChSet 4 ")
            ImportSettings.Write(InstCh4.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh4.Value.ToString() & " ")
            ImportSettings.Write(PanCh4.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh4.Value.ToString())
        End If
        If Ch5.Checked = True Then
            ImportSettings.Write("Ch 5 ")
            ImportSettings.Write(PartCh5.Text & vbLf & "ChSet 5 ")
            ImportSettings.Write(InstCh5.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh5.Value.ToString() & " ")
            ImportSettings.Write(PanCh5.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh5.Value.ToString())
        End If
        If Ch6.Checked = True Then
            ImportSettings.Write("Ch 6 ")
            ImportSettings.Write(PartCh6.Text & vbLf & "ChSet 6 ")
            ImportSettings.Write(InstCh6.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh6.Value.ToString() & " ")
            ImportSettings.Write(PanCh6.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh6.Value.ToString())
        End If
        If Ch7.Checked = True Then
            ImportSettings.Write("Ch 7 ")
            ImportSettings.Write(PartCh7.Text & vbLf & "ChSet 7 ")
            ImportSettings.Write(InstCh7.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh7.Value.ToString() & " ")
            ImportSettings.Write(PanCh7.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh7.Value.ToString())
        End If
        If Ch8.Checked = True Then
            ImportSettings.Write("Ch 8 ")
            ImportSettings.Write(PartCh8.Text & vbLf & "ChSet 8 ")
            ImportSettings.Write(InstCh8.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh8.Value.ToString() & " ")
            ImportSettings.Write(PanCh8.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh8.Value.ToString())
        End If
        If Ch9.Checked = True Then
            ImportSettings.Write("Ch 9 ")
            ImportSettings.Write(PartCh9.Text & vbLf & "ChSet 9 ")
            ImportSettings.Write(InstCh9.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh9.Value.ToString() & " ")
            ImportSettings.Write(PanCh9.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh9.Value.ToString())
        End If
        If Ch10.Checked = True Then
            ImportSettings.Write("Ch 10 ")
            ImportSettings.Write(PartCh10.Text & vbLf & "ChSet 10 ")
            ImportSettings.Write(InstCh10.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh10.Value.ToString() & " ")
            ImportSettings.Write(PanCh10.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh10.Value.ToString())
        End If
        If Ch11.Checked = True Then
            ImportSettings.Write("Ch 11 ")
            ImportSettings.Write(PartCh11.Text & vbLf & "ChSet 11 ")
            ImportSettings.Write(InstCh11.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh11.Value.ToString() & " ")
            ImportSettings.Write(PanCh11.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh11.Value.ToString())
        End If
        If Ch12.Checked = True Then
            ImportSettings.Write("Ch 12 ")
            ImportSettings.Write(PartCh12.Text & vbLf & "ChSet 12 ")
            ImportSettings.Write(InstCh12.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh12.Value.ToString() & " ")
            ImportSettings.Write(PanCh12.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh12.Value.ToString())
        End If
        If Ch13.Checked = True Then
            ImportSettings.Write("Ch 13 ")
            ImportSettings.Write(PartCh13.Text & vbLf & "ChSet 13 ")
            ImportSettings.Write(InstCh13.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh13.Value.ToString() & " ")
            ImportSettings.Write(PanCh13.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh13.Value.ToString())
        End If
        If Ch14.Checked = True Then
            ImportSettings.Write("Ch 14 ")
            ImportSettings.Write(PartCh14.Text & vbLf & "ChSet 14 ")
            ImportSettings.Write(InstCh14.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh14.Value.ToString() & " ")
            ImportSettings.Write(PanCh14.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh14.Value.ToString())
        End If
        If Ch15.Checked = True Then
            ImportSettings.Write("Ch 15 ")
            ImportSettings.Write(PartCh15.Text & vbLf & "ChSet 15 ")
            ImportSettings.Write(InstCh15.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh15.Value.ToString() & " ")
            ImportSettings.Write(PanCh15.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh15.Value.ToString())
        End If
        If Ch16.Checked = True Then
            ImportSettings.Write("Ch 16 ")
            ImportSettings.Write(PartCh16.Text & vbLf & "ChSet 16 ")
            ImportSettings.Write(InstCh16.SelectedIndex.ToString() & " ")
            ImportSettings.Write(VolCh16.Value.ToString() & " ")
            ImportSettings.Write(PanCh16.Value.ToString() & " ")
            ImportSettings.WriteLine(TransCh16.Value.ToString())
        End If

        ImportSettings.Close()

        Dim Argv0 As String = Path.DirectoryName & "\M64XML.exe"
        Dim Argv1 As String = Path.DirectoryName & "\parts.txt"
        Dim Argv2 As String = Path.DirectoryName & "\settings.txt"

        If File.Exists(Argv0) Then
            Dim ProcessObj As New Process()

            ProcessObj.StartInfo.FileName = Argv0
            ProcessObj.StartInfo.Arguments = """" & Argv1 & """ """ & Argv2 & """"
            ProcessObj.StartInfo.UseShellExecute = False
            ProcessObj.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Argv0)
            ProcessObj.Start()
            ProcessObj.WaitForExit()

            If ProcessObj.ExitCode = -1 Then
                MessageBox.Show("Error!")
            Else
                MessageBox.Show(".m64 file created as " & System.IO.Path.GetDirectoryName(Argv0) & "\output.m64")
            End If
        Else
            MessageBox.Show("M64XML.EXE not found!")
        End If


    End Sub

    Private Sub loadSettingsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadSettingsToolStripMenuItem.Click
        Dim dlg As New OpenFileDialog()
        dlg.Title = "Choose settings file"
        dlg.Filter = "(.set setting files)|*.set"
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim streamReader As New StreamReader(dlg.FileName)
            Dim setfile As String = streamReader.ReadToEnd()
            streamReader.Close()

            Dim doc As New XmlDocument()

            Try
                doc.LoadXml(setfile)
            Catch [error] As Exception
                MessageBox.Show([error].ToString())
            End Try

            Dim mxmlfile As XmlNodeList = doc.GetElementsByTagName("mxmlfile")
            If mxmlfile.Count <> 0 Then
                lbXmlFile.Text = mxmlfile(0).InnerText
            End If
            'INSTANT VB NOTE: The variable tempo was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim tempo_Renamed As XmlNodeList = doc.GetElementsByTagName("tempo")
            If tempo_Renamed.Count <> 0 Then
                Tempo.Value = Convert.ToInt32(tempo_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable globalvolume was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim globalvolume_Renamed As XmlNodeList = doc.GetElementsByTagName("globalvolume")
            If globalvolume_Renamed.Count <> 0 Then
                GlobalVolume.Value = Convert.ToInt32(globalvolume_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instset was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instset_Renamed As XmlNodeList = doc.GetElementsByTagName("instset")
            If instset_Renamed.Count <> 0 Then
                cbInstSet.SelectedIndex = Convert.ToInt32(instset_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable globaltransposition was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim globaltransposition_Renamed As XmlNodeList = doc.GetElementsByTagName("globaltransposition")
            If globaltransposition_Renamed.Count <> 0 Then
                GlobalTransposition.Value = Convert.ToInt32(globaltransposition_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable loop was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim loop_Renamed As XmlNodeList = doc.GetElementsByTagName("loop")
            If loop_Renamed.Count <> 0 Then
                SetCheckBoxState(cbLoopSequence, loop_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch1 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch1_Renamed As XmlNodeList = doc.GetElementsByTagName("ch1")
            If ch1_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch1, ch1_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch2 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch2_Renamed As XmlNodeList = doc.GetElementsByTagName("ch2")
            If ch2_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch2, ch2_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch3 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch3_Renamed As XmlNodeList = doc.GetElementsByTagName("ch3")
            If ch3_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch3, ch3_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch4 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch4_Renamed As XmlNodeList = doc.GetElementsByTagName("ch4")
            If ch4_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch4, ch4_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch5 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch5_Renamed As XmlNodeList = doc.GetElementsByTagName("ch5")
            If ch5_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch5, ch5_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch6 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch6_Renamed As XmlNodeList = doc.GetElementsByTagName("ch6")
            If ch6_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch6, ch6_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch7 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch7_Renamed As XmlNodeList = doc.GetElementsByTagName("ch7")
            If ch7_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch7, ch7_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch8 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch8_Renamed As XmlNodeList = doc.GetElementsByTagName("ch8")
            If ch8_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch8, ch8_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch9 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch9_Renamed As XmlNodeList = doc.GetElementsByTagName("ch9")
            If ch9_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch9, ch9_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch10 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch10_Renamed As XmlNodeList = doc.GetElementsByTagName("ch10")
            If ch10_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch10, ch10_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch11 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch11_Renamed As XmlNodeList = doc.GetElementsByTagName("ch11")
            If ch11_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch11, ch11_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch12 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch12_Renamed As XmlNodeList = doc.GetElementsByTagName("ch12")
            If ch12_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch12, ch12_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch13 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch13_Renamed As XmlNodeList = doc.GetElementsByTagName("ch13")
            If ch13_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch13, ch13_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch14 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch14_Renamed As XmlNodeList = doc.GetElementsByTagName("ch14")
            If ch14_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch14, ch14_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch15 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch15_Renamed As XmlNodeList = doc.GetElementsByTagName("ch15")
            If ch15_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch15, ch15_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable ch16 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim ch16_Renamed As XmlNodeList = doc.GetElementsByTagName("ch16")
            If ch16_Renamed.Count <> 0 Then
                SetCheckBoxState(Ch16, ch16_Renamed(0).InnerText)
            End If

            'INSTANT VB NOTE: The variable partch1 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch1_Renamed As XmlNodeList = doc.GetElementsByTagName("partch1")
            If partch1_Renamed.Count <> 0 Then
                PartCh1.SelectedIndex = Convert.ToInt32(partch1_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch2 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch2_Renamed As XmlNodeList = doc.GetElementsByTagName("partch2")
            If partch1_Renamed.Count <> 0 Then
                PartCh2.SelectedIndex = Convert.ToInt32(partch2_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch3 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch3_Renamed As XmlNodeList = doc.GetElementsByTagName("partch3")
            If partch1_Renamed.Count <> 0 Then
                PartCh3.SelectedIndex = Convert.ToInt32(partch3_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch4 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch4_Renamed As XmlNodeList = doc.GetElementsByTagName("partch4")
            If partch1_Renamed.Count <> 0 Then
                PartCh4.SelectedIndex = Convert.ToInt32(partch4_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch5 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch5_Renamed As XmlNodeList = doc.GetElementsByTagName("partch5")
            If partch1_Renamed.Count <> 0 Then
                PartCh5.SelectedIndex = Convert.ToInt32(partch5_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch6 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch6_Renamed As XmlNodeList = doc.GetElementsByTagName("partch6")
            If partch1_Renamed.Count <> 0 Then
                PartCh6.SelectedIndex = Convert.ToInt32(partch6_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch7 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch7_Renamed As XmlNodeList = doc.GetElementsByTagName("partch7")
            If partch1_Renamed.Count <> 0 Then
                PartCh7.SelectedIndex = Convert.ToInt32(partch7_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch8 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch8_Renamed As XmlNodeList = doc.GetElementsByTagName("partch8")
            If partch1_Renamed.Count <> 0 Then
                PartCh8.SelectedIndex = Convert.ToInt32(partch8_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch9 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch9_Renamed As XmlNodeList = doc.GetElementsByTagName("partch9")
            If partch1_Renamed.Count <> 0 Then
                PartCh9.SelectedIndex = Convert.ToInt32(partch9_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch10 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch10_Renamed As XmlNodeList = doc.GetElementsByTagName("partch10")
            If partch1_Renamed.Count <> 0 Then
                PartCh10.SelectedIndex = Convert.ToInt32(partch10_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch11 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch11_Renamed As XmlNodeList = doc.GetElementsByTagName("partch11")
            If partch1_Renamed.Count <> 0 Then
                PartCh11.SelectedIndex = Convert.ToInt32(partch11_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch12 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch12_Renamed As XmlNodeList = doc.GetElementsByTagName("partch12")
            If partch1_Renamed.Count <> 0 Then
                PartCh12.SelectedIndex = Convert.ToInt32(partch12_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch13 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch13_Renamed As XmlNodeList = doc.GetElementsByTagName("partch13")
            If partch1_Renamed.Count <> 0 Then
                PartCh13.SelectedIndex = Convert.ToInt32(partch13_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch14 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch14_Renamed As XmlNodeList = doc.GetElementsByTagName("partch14")
            If partch1_Renamed.Count <> 0 Then
                PartCh14.SelectedIndex = Convert.ToInt32(partch14_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch15 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch15_Renamed As XmlNodeList = doc.GetElementsByTagName("partch15")
            If partch1_Renamed.Count <> 0 Then
                PartCh15.SelectedIndex = Convert.ToInt32(partch15_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable partch16 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim partch16_Renamed As XmlNodeList = doc.GetElementsByTagName("partch16")
            If partch1_Renamed.Count <> 0 Then
                PartCh16.SelectedIndex = Convert.ToInt32(partch16_Renamed(0).InnerText)
            End If

            'INSTANT VB NOTE: The variable instch1 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch1_Renamed As XmlNodeList = doc.GetElementsByTagName("instch1")
            If instch1_Renamed.Count <> 0 Then
                InstCh1.SelectedIndex = Convert.ToInt32(instch1_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch2 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch2_Renamed As XmlNodeList = doc.GetElementsByTagName("instch2")
            If instch1_Renamed.Count <> 0 Then
                InstCh2.SelectedIndex = Convert.ToInt32(instch2_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch3 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch3_Renamed As XmlNodeList = doc.GetElementsByTagName("instch3")
            If instch1_Renamed.Count <> 0 Then
                InstCh3.SelectedIndex = Convert.ToInt32(instch3_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch4 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch4_Renamed As XmlNodeList = doc.GetElementsByTagName("instch4")
            If instch1_Renamed.Count <> 0 Then
                InstCh4.SelectedIndex = Convert.ToInt32(instch4_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch5 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch5_Renamed As XmlNodeList = doc.GetElementsByTagName("instch5")
            If instch1_Renamed.Count <> 0 Then
                InstCh5.SelectedIndex = Convert.ToInt32(instch5_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch6 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch6_Renamed As XmlNodeList = doc.GetElementsByTagName("instch6")
            If instch1_Renamed.Count <> 0 Then
                InstCh6.SelectedIndex = Convert.ToInt32(instch6_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch7 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch7_Renamed As XmlNodeList = doc.GetElementsByTagName("instch7")
            If instch1_Renamed.Count <> 0 Then
                InstCh7.SelectedIndex = Convert.ToInt32(instch7_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch8 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch8_Renamed As XmlNodeList = doc.GetElementsByTagName("instch8")
            If instch1_Renamed.Count <> 0 Then
                InstCh8.SelectedIndex = Convert.ToInt32(instch8_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch9 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch9_Renamed As XmlNodeList = doc.GetElementsByTagName("instch9")
            If instch1_Renamed.Count <> 0 Then
                InstCh9.SelectedIndex = Convert.ToInt32(instch9_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch10 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch10_Renamed As XmlNodeList = doc.GetElementsByTagName("instch10")
            If instch1_Renamed.Count <> 0 Then
                InstCh10.SelectedIndex = Convert.ToInt32(instch10_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch11 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch11_Renamed As XmlNodeList = doc.GetElementsByTagName("instch11")
            If instch1_Renamed.Count <> 0 Then
                InstCh11.SelectedIndex = Convert.ToInt32(instch11_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch12 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch12_Renamed As XmlNodeList = doc.GetElementsByTagName("instch12")
            If instch1_Renamed.Count <> 0 Then
                InstCh12.SelectedIndex = Convert.ToInt32(instch12_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch13 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch13_Renamed As XmlNodeList = doc.GetElementsByTagName("instch13")
            If instch1_Renamed.Count <> 0 Then
                InstCh13.SelectedIndex = Convert.ToInt32(instch13_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch14 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch14_Renamed As XmlNodeList = doc.GetElementsByTagName("instch14")
            If instch1_Renamed.Count <> 0 Then
                InstCh14.SelectedIndex = Convert.ToInt32(instch14_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch15 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch15_Renamed As XmlNodeList = doc.GetElementsByTagName("instch15")
            If instch1_Renamed.Count <> 0 Then
                InstCh15.SelectedIndex = Convert.ToInt32(instch15_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable instch16 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim instch16_Renamed As XmlNodeList = doc.GetElementsByTagName("instch16")
            If instch1_Renamed.Count <> 0 Then
                InstCh16.SelectedIndex = Convert.ToInt32(instch16_Renamed(0).InnerText)
            End If

            'INSTANT VB NOTE: The variable volCh1 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh1_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh1")
            If volCh1_Renamed.Count <> 0 Then
                VolCh1.Value = Convert.ToInt32(volCh1_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh2 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh2_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh2")
            If volCh1_Renamed.Count <> 0 Then
                VolCh2.Value = Convert.ToInt32(volCh2_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh3 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh3_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh3")
            If volCh1_Renamed.Count <> 0 Then
                VolCh3.Value = Convert.ToInt32(volCh3_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh4 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh4_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh4")
            If volCh1_Renamed.Count <> 0 Then
                VolCh4.Value = Convert.ToInt32(volCh4_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh5 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh5_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh5")
            If volCh1_Renamed.Count <> 0 Then
                VolCh5.Value = Convert.ToInt32(volCh5_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh6 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh6_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh6")
            If volCh1_Renamed.Count <> 0 Then
                VolCh6.Value = Convert.ToInt32(volCh6_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh7 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh7_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh7")
            If volCh1_Renamed.Count <> 0 Then
                VolCh7.Value = Convert.ToInt32(volCh7_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh8 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh8_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh8")
            If volCh1_Renamed.Count <> 0 Then
                VolCh8.Value = Convert.ToInt32(volCh8_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh9 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh9_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh9")
            If volCh1_Renamed.Count <> 0 Then
                VolCh9.Value = Convert.ToInt32(volCh9_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh10 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh10_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh10")
            If volCh1_Renamed.Count <> 0 Then
                VolCh10.Value = Convert.ToInt32(volCh10_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh11 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh11_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh11")
            If volCh1_Renamed.Count <> 0 Then
                VolCh11.Value = Convert.ToInt32(volCh11_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh12 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh12_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh12")
            If volCh1_Renamed.Count <> 0 Then
                VolCh12.Value = Convert.ToInt32(volCh12_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh13 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh13_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh13")
            If volCh1_Renamed.Count <> 0 Then
                VolCh13.Value = Convert.ToInt32(volCh13_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh14 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh14_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh14")
            If volCh1_Renamed.Count <> 0 Then
                VolCh14.Value = Convert.ToInt32(volCh14_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh15 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh15_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh15")
            If volCh1_Renamed.Count <> 0 Then
                VolCh15.Value = Convert.ToInt32(volCh15_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable volCh16 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim volCh16_Renamed As XmlNodeList = doc.GetElementsByTagName("volCh16")
            If volCh1_Renamed.Count <> 0 Then
                VolCh16.Value = Convert.ToInt32(volCh16_Renamed(0).InnerText)
            End If

            'INSTANT VB NOTE: The variable panCh1 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh1_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh1")
            If panCh1_Renamed.Count <> 0 Then
                PanCh1.Value = Convert.ToInt32(panCh1_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh2 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh2_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh2")
            If panCh1_Renamed.Count <> 0 Then
                PanCh2.Value = Convert.ToInt32(panCh2_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh3 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh3_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh3")
            If panCh1_Renamed.Count <> 0 Then
                PanCh3.Value = Convert.ToInt32(panCh3_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh4 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh4_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh4")
            If panCh1_Renamed.Count <> 0 Then
                PanCh4.Value = Convert.ToInt32(panCh4_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh5 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh5_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh5")
            If panCh1_Renamed.Count <> 0 Then
                PanCh5.Value = Convert.ToInt32(panCh5_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh6 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh6_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh6")
            If panCh1_Renamed.Count <> 0 Then
                PanCh6.Value = Convert.ToInt32(panCh6_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh7 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh7_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh7")
            If panCh1_Renamed.Count <> 0 Then
                PanCh7.Value = Convert.ToInt32(panCh7_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh8 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh8_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh8")
            If panCh1_Renamed.Count <> 0 Then
                PanCh8.Value = Convert.ToInt32(panCh8_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh9 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh9_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh9")
            If panCh1_Renamed.Count <> 0 Then
                PanCh9.Value = Convert.ToInt32(panCh9_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh10 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh10_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh10")
            If panCh1_Renamed.Count <> 0 Then
                PanCh10.Value = Convert.ToInt32(panCh10_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh11 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh11_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh11")
            If panCh1_Renamed.Count <> 0 Then
                PanCh11.Value = Convert.ToInt32(panCh11_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh12 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh12_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh12")
            If panCh1_Renamed.Count <> 0 Then
                PanCh12.Value = Convert.ToInt32(panCh12_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh13 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh13_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh13")
            If panCh1_Renamed.Count <> 0 Then
                PanCh13.Value = Convert.ToInt32(panCh13_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh14 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh14_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh14")
            If panCh1_Renamed.Count <> 0 Then
                PanCh14.Value = Convert.ToInt32(panCh14_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh15 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh15_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh15")
            If panCh1_Renamed.Count <> 0 Then
                PanCh15.Value = Convert.ToInt32(panCh15_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable panCh16 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim panCh16_Renamed As XmlNodeList = doc.GetElementsByTagName("panCh16")
            If panCh1_Renamed.Count <> 0 Then
                PanCh16.Value = Convert.ToInt32(panCh16_Renamed(0).InnerText)
            End If

            'INSTANT VB NOTE: The variable transCh1 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh1_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh1")
            If transCh1_Renamed.Count <> 0 Then
                TransCh1.Value = Convert.ToInt32(transCh1_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh2 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh2_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh2")
            If transCh1_Renamed.Count <> 0 Then
                TransCh2.Value = Convert.ToInt32(transCh2_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh3 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh3_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh3")
            If transCh1_Renamed.Count <> 0 Then
                TransCh3.Value = Convert.ToInt32(transCh3_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh4 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh4_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh4")
            If transCh1_Renamed.Count <> 0 Then
                TransCh4.Value = Convert.ToInt32(transCh4_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh5 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh5_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh5")
            If transCh1_Renamed.Count <> 0 Then
                TransCh5.Value = Convert.ToInt32(transCh5_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh6 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh6_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh6")
            If transCh1_Renamed.Count <> 0 Then
                TransCh6.Value = Convert.ToInt32(transCh6_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh7 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh7_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh7")
            If transCh1_Renamed.Count <> 0 Then
                TransCh7.Value = Convert.ToInt32(transCh7_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh8 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh8_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh8")
            If transCh1_Renamed.Count <> 0 Then
                TransCh8.Value = Convert.ToInt32(transCh8_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh9 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh9_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh9")
            If transCh1_Renamed.Count <> 0 Then
                TransCh9.Value = Convert.ToInt32(transCh9_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh10 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh10_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh10")
            If transCh1_Renamed.Count <> 0 Then
                TransCh10.Value = Convert.ToInt32(transCh10_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh11 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh11_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh11")
            If transCh1_Renamed.Count <> 0 Then
                TransCh11.Value = Convert.ToInt32(transCh11_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh12 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh12_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh12")
            If transCh1_Renamed.Count <> 0 Then
                TransCh12.Value = Convert.ToInt32(transCh12_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh13 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh13_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh13")
            If transCh1_Renamed.Count <> 0 Then
                TransCh13.Value = Convert.ToInt32(transCh13_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh14 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh14_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh14")
            If transCh1_Renamed.Count <> 0 Then
                TransCh14.Value = Convert.ToInt32(transCh14_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh15 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh15_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh15")
            If transCh1_Renamed.Count <> 0 Then
                TransCh15.Value = Convert.ToInt32(transCh15_Renamed(0).InnerText)
            End If
            'INSTANT VB NOTE: The variable transCh16 was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim transCh16_Renamed As XmlNodeList = doc.GetElementsByTagName("transCh16")
            If transCh1_Renamed.Count <> 0 Then
                TransCh16.Value = Convert.ToInt32(transCh16_Renamed(0).InnerText)
            End If

        End If

    End Sub

    Private Sub settomToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settomToolStripMenuItem.Click
        Dim dlg As New SaveFileDialog()
        dlg.Title = "Save settings"
        dlg.Filter = "(.set setting files)|*.set"
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim textWriter As New XmlTextWriter(dlg.FileName, Nothing)
            textWriter.WriteStartDocument()
            textWriter.WriteComment("Mario 64 Music XML Importer Jul Alpha 1 Settings File")

            textWriter.WriteStartElement("m64seq", "")

            textWriter.WriteStartElement("mxmlfile", "")
            textWriter.WriteString(lbXmlFile.Text)
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("tempo", "")
            textWriter.WriteString(Tempo.Value.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("globalvolume", "")
            textWriter.WriteString(GlobalVolume.Value.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("instset", "")
            textWriter.WriteString(cbInstSet.SelectedIndex.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("globaltransposition", "")
            textWriter.WriteString(GlobalTransposition.Value.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("loop", "")
            textWriter.WriteString(CheckBoxState(cbLoopSequence))
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("ch1", "")
            textWriter.WriteString(CheckBoxState(Ch1))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch2", "")
            textWriter.WriteString(CheckBoxState(Ch2))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch3", "")
            textWriter.WriteString(CheckBoxState(Ch3))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch4", "")
            textWriter.WriteString(CheckBoxState(Ch4))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch5", "")
            textWriter.WriteString(CheckBoxState(Ch5))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch6", "")
            textWriter.WriteString(CheckBoxState(Ch6))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch7", "")
            textWriter.WriteString(CheckBoxState(Ch7))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch8", "")
            textWriter.WriteString(CheckBoxState(Ch8))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch9", "")
            textWriter.WriteString(CheckBoxState(Ch9))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch10", "")
            textWriter.WriteString(CheckBoxState(Ch10))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch11", "")
            textWriter.WriteString(CheckBoxState(Ch11))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch12", "")
            textWriter.WriteString(CheckBoxState(Ch12))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch13", "")
            textWriter.WriteString(CheckBoxState(Ch13))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch14", "")
            textWriter.WriteString(CheckBoxState(Ch14))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch15", "")
            textWriter.WriteString(CheckBoxState(Ch15))
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("ch16", "")
            textWriter.WriteString(CheckBoxState(Ch16))
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("partch1", "")
            textWriter.WriteString(PartCh1.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch2", "")
            textWriter.WriteString(PartCh2.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch3", "")
            textWriter.WriteString(PartCh3.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch4", "")
            textWriter.WriteString(PartCh4.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch5", "")
            textWriter.WriteString(PartCh5.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch6", "")
            textWriter.WriteString(PartCh6.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch7", "")
            textWriter.WriteString(PartCh7.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch8", "")
            textWriter.WriteString(PartCh8.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch9", "")
            textWriter.WriteString(PartCh9.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch10", "")
            textWriter.WriteString(PartCh10.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch11", "")
            textWriter.WriteString(PartCh11.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch12", "")
            textWriter.WriteString(PartCh12.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch13", "")
            textWriter.WriteString(PartCh13.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch14", "")
            textWriter.WriteString(PartCh14.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch15", "")
            textWriter.WriteString(PartCh15.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("partch16", "")
            textWriter.WriteString(PartCh16.SelectedIndex.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("instch1", "")
            textWriter.WriteString(InstCh1.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch2", "")
            textWriter.WriteString(InstCh2.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch3", "")
            textWriter.WriteString(InstCh3.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch4", "")
            textWriter.WriteString(InstCh4.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch5", "")
            textWriter.WriteString(InstCh5.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch6", "")
            textWriter.WriteString(InstCh6.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch7", "")
            textWriter.WriteString(InstCh7.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch8", "")
            textWriter.WriteString(InstCh8.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch9", "")
            textWriter.WriteString(InstCh9.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch10", "")
            textWriter.WriteString(InstCh10.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch11", "")
            textWriter.WriteString(InstCh11.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch12", "")
            textWriter.WriteString(InstCh12.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch13", "")
            textWriter.WriteString(InstCh13.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch14", "")
            textWriter.WriteString(InstCh14.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch15", "")
            textWriter.WriteString(InstCh15.SelectedIndex.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("instch16", "")
            textWriter.WriteString(InstCh16.SelectedIndex.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("volCh1", "")
            textWriter.WriteString(VolCh1.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh2", "")
            textWriter.WriteString(VolCh2.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh3", "")
            textWriter.WriteString(VolCh3.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh4", "")
            textWriter.WriteString(VolCh4.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh5", "")
            textWriter.WriteString(VolCh5.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh6", "")
            textWriter.WriteString(VolCh6.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh7", "")
            textWriter.WriteString(VolCh7.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh8", "")
            textWriter.WriteString(VolCh8.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh9", "")
            textWriter.WriteString(VolCh9.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh10", "")
            textWriter.WriteString(VolCh10.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh11", "")
            textWriter.WriteString(VolCh11.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh12", "")
            textWriter.WriteString(VolCh12.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh13", "")
            textWriter.WriteString(VolCh13.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh14", "")
            textWriter.WriteString(VolCh14.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh15", "")
            textWriter.WriteString(VolCh15.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("volCh16", "")
            textWriter.WriteString(VolCh16.Value.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("panCh1", "")
            textWriter.WriteString(PanCh1.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh2", "")
            textWriter.WriteString(PanCh2.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh3", "")
            textWriter.WriteString(PanCh3.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh4", "")
            textWriter.WriteString(PanCh4.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh5", "")
            textWriter.WriteString(PanCh5.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh6", "")
            textWriter.WriteString(PanCh6.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh7", "")
            textWriter.WriteString(PanCh7.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh8", "")
            textWriter.WriteString(PanCh8.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh9", "")
            textWriter.WriteString(PanCh9.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh10", "")
            textWriter.WriteString(PanCh10.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh11", "")
            textWriter.WriteString(PanCh11.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh12", "")
            textWriter.WriteString(PanCh12.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh13", "")
            textWriter.WriteString(PanCh13.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh14", "")
            textWriter.WriteString(PanCh14.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh15", "")
            textWriter.WriteString(PanCh15.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("panCh16", "")
            textWriter.WriteString(PanCh16.Value.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteStartElement("transCh1", "")
            textWriter.WriteString(TransCh1.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh2", "")
            textWriter.WriteString(TransCh2.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh3", "")
            textWriter.WriteString(TransCh3.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh4", "")
            textWriter.WriteString(TransCh4.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh5", "")
            textWriter.WriteString(TransCh5.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh6", "")
            textWriter.WriteString(TransCh6.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh7", "")
            textWriter.WriteString(TransCh7.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh8", "")
            textWriter.WriteString(TransCh8.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh9", "")
            textWriter.WriteString(TransCh9.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh10", "")
            textWriter.WriteString(TransCh10.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh11", "")
            textWriter.WriteString(TransCh11.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh12", "")
            textWriter.WriteString(TransCh12.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh13", "")
            textWriter.WriteString(TransCh13.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh14", "")
            textWriter.WriteString(TransCh14.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh15", "")
            textWriter.WriteString(TransCh15.Value.ToString())
            textWriter.WriteEndElement()
            textWriter.WriteStartElement("transCh16", "")
            textWriter.WriteString(TransCh16.Value.ToString())
            textWriter.WriteEndElement()

            textWriter.WriteEndDocument()
            textWriter.Close()
            MessageBox.Show("Settings saved!")

        End If

    End Sub


    Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
        MessageBox.Show("Mario64 Music XML Importer v1 by messiaen (aka frauber)." & vbLf)
    End Sub

    Private Sub sequenceInserterToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
End Class