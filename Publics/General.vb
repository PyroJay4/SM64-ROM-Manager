Imports System.Text.RegularExpressions
Imports System.IO
Imports IniParser, IniParser.Model
Imports DevComponents.DotNetBar
Imports Newtonsoft.Json.Linq
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.Editors
Imports SettingsManager
Imports System.Windows.Forms
Imports S3DFileParser
Imports System.Runtime.CompilerServices

Public Module General

    Public DisplayListCommandsWithPointerList As Byte() = {&H1, &H3, &H4, &H6, &HFD}
    Public FileIniParser As New FileIniDataParser
    Public StreamIniParser As New StreamIniDataParser
    Public ActSelectorDefaultValues As Byte() = New Byte() {False, False, False, True, True, False, True, True, True, True, True, True, True, True, True, False, False, False, False, False, False, True, True, True, False, False, False, False, False, False, False, False, False, False, False}

    Public ReadOnly Property MyDataPath As String
        Get
            Return Path.Combine(Directory.GetCurrentDirectory, "Data")
        End Get
    End Property

    Public Function GetExtensionFilter(modul As LoaderModule) As String
        Dim combiFormats As String = ""
        Dim splittedFormats As String = ""

        Dim ids As Dictionary(Of String, String) = S3DFileParser.Publics.GetAllFileFormatIDs(modul)
        Dim descriptions As Dictionary(Of String, String) = S3DFileParser.Publics.GetAllFileFormatDescriptions(modul)

        For Each ext As String In S3DFileParser.Publics.GetAllowedFileExtensions(modul)
            Dim desc As String = ""

            If descriptions.ContainsKey(ext.Substring(1)) Then desc = descriptions(ext.Substring(1))

            If combiFormats <> "" Then
                combiFormats &= ";"
            End If
            combiFormats &= "*" & ext

            If splittedFormats <> "" Then
                splittedFormats &= "|"
            End If

            If desc = "" Then
                If ids.ContainsKey(ext.Substring(1)) Then desc = ids(ext.Substring(1))
            End If
            If desc = "" Then
                desc = $"{ext.Substring(1)} Files"
            End If

            splittedFormats &= $"{desc} (*{ext})|*{ext}"
        Next

        Return $"All supported files|{combiFormats}|{splittedFormats}"
    End Function

    Public Function keepDegreesWithin360(value As Short) As Short
        If value < 0 Then
            Return 360 + (value Mod -360)
        Else
            Return value Mod 360
        End If
    End Function

    Public Sub DisableAmbientColor(c As Control, types() As Type, state As eAmbientSettings)
        Dim abm As New StyleManagerAmbient
        If types.Contains(c.GetType) Then
            abm.SetEnableAmbientSettings(c, state)
        End If
        For Each cc As Control In c.Controls
            DisableAmbientColor(cc, types, eAmbientSettings.BackColor)
        Next
    End Sub

    Public Function CompareTwoByteArrays(arr1() As Byte, arr2() As Byte) As Boolean
        If arr2.Count <> arr1.Count Then Return False

        For i As Integer = 0 To arr1.Count - 1
            If arr1(i) <> arr2(i) Then Return False
        Next

        Return True
    End Function

    Public Sub ShowToadnotifiaction(Parent As Control, Text As String, Color As eToastGlowColor, Optional Timeout As Integer = 5000)
        'ToastNotification.ToastBackColor = Drawing.Color.LightGray
        'ToastNotification.ToastForeColor = Drawing.Color.Black
        ToastNotification.Show(Parent, Text, Nothing, Timeout, Color)
    End Sub

    Public Function GetLevelIndexFromID(LevelID As Byte) As Byte
        Select Case LevelID
            Case &H4 : Return 0
            Case &H5 : Return 1
            Case &H6 : Return 2
            Case &H7 : Return 3
            Case &H8 : Return 4
            Case &H9 : Return 5
            Case &HA : Return 6
            Case &HB : Return 7
            Case &HC : Return 8
            Case &HD : Return 9
            Case &HE : Return 10
            Case &HF : Return 11
            Case &H10 : Return 12
            Case &H11 : Return 13
            Case &H12 : Return 14
            Case &H13 : Return 15
            Case &H14 : Return 16
            Case &H15 : Return 17
            Case &H16 : Return 18
            Case &H17 : Return 19
            Case &H18 : Return 20
            Case &H19 : Return 21
            Case &H1A : Return 22
            Case &H1B : Return 23
            Case &H1C : Return 24
            Case &H1D : Return 25
            Case &H1E : Return 26
            Case &H1F : Return 27
            Case &H21 : Return 28
            Case &H22 : Return 29
            Case &H24 : Return 30
            Case Else : Return 5
        End Select
    End Function
    Public Function GetLevelIDFromIndex(LevelID As Byte) As Byte
        Select Case LevelID
            Case 0 : Return &H4
            Case 1 : Return &H5
            Case 2 : Return &H6
            Case 3 : Return &H7
            Case 4 : Return &H8
            Case 5 : Return &H9
            Case 6 : Return &HA
            Case 7 : Return &HB
            Case 8 : Return &HC
            Case 9 : Return &HD
            Case 10 : Return &HE
            Case 11 : Return &HF
            Case 12 : Return &H10
            Case 13 : Return &H11
            Case 14 : Return &H12
            Case 15 : Return &H13
            Case 16 : Return &H14
            Case 17 : Return &H15
            Case 18 : Return &H16
            Case 19 : Return &H17
            Case 20 : Return &H18
            Case 21 : Return &H19
            Case 22 : Return &H1A
            Case 23 : Return &H1B
            Case 24 : Return &H1C
            Case 25 : Return &H1D
            Case 26 : Return &H1E
            Case 27 : Return &H1F
            Case 28 : Return &H21
            Case 29 : Return &H22
            Case 30 : Return &H24
            Case Else : Return 5
        End Select
    End Function

    Public Sub UpdateChecksum(Romfile As String)
        Dim proc As New Process
        With proc.StartInfo
            .FileName = MyDataPath & "\Tools\rn64crc.exe"
            .Arguments = String.Format("""{0}"" -u", Romfile)
            .UseShellExecute = False
            .CreateNoWindow = True
        End With
        proc.Start()
        proc.WaitForExit()
    End Sub
    Public Sub RestoreChecksum(Romfile As String)
        Dim proc As New Process
        With proc.StartInfo
            .FileName = MyDataPath & "\Tools\chksum64.exe"
            .Arguments = String.Format("""{0}""", Romfile)
            .UseShellExecute = False
            .CreateNoWindow = True
        End With
        proc.Start()
        proc.WaitForExit()
    End Sub

    Public Function TrimString(str As String) As String
        Dim str1 As String
        Try
            str1 = (New Regex("^[ \t]+|[ \t]+$", RegexOptions.IgnoreCase)).Replace(str, "")
        Catch exception As Exception
            exception.ToString()
            str1 = str
        End Try
        Return str1
    End Function

    Public Function HexRoundUp1(value As Integer) As Integer
        Do
            Application.DoEvents()
            If Hex(value).EndsWith("0") Then Exit Do 'Or Hex(value).EndsWith("8")
            value += 1
        Loop
        Return value
    End Function
    Public Sub HexRoundUp2(ByRef value As Integer)
        Do
            Application.DoEvents()
            If Hex(value).EndsWith("0") Then Exit Do 'Or Hex(value).EndsWith("8")
            value += 1
        Loop
    End Sub

    Public Class Bits
        Shared Function ByteToBitArray(b As Byte) As Byte()
            Dim bitarray As New BitArray({b})
            Dim temp(0 To bitarray.Length - 1) As Byte
            For i As Integer = 0 To bitarray.Length - 1
                temp(i) = bitarray(i)
            Next
            Dim tindex As Integer = 0
            Dim temp2(0 To temp.Count - 1) As Byte
            For i As Integer = temp.Length - 1 To 0 Step -1
                temp2(tindex) = temp(i)
                tindex += 1
            Next
            Return temp2
        End Function
        Shared Function ByteToBoolArray(b As Byte) As Boolean()
            Dim bitarray As New BitArray({b})
            Dim temp(0 To bitarray.Length - 1) As Boolean
            For i As Integer = 0 To bitarray.Length - 1
                temp(i) = Convert.ToBoolean(bitarray(i))
            Next
            Dim tindex As Integer = 0
            Dim temp2(0 To temp.Count - 1) As Boolean
            For i As Integer = temp.Length - 1 To 0 Step -1
                temp2(tindex) = temp(i)
                tindex += 1
            Next
            Return temp2
        End Function

        Shared Function ArrayToByte(ba() As Byte) As Byte
            'ODER: BitArray.ToByte()

            Dim endval As Byte = 0
            Dim index As Integer = ba.Count - 1
            For Each bit In ba
                endval += bit * (2 ^ index)
                index -= 1
            Next
            Return endval
        End Function
        Shared Function ArrayToByte(ba() As Boolean) As Byte
            'ODER: BitArray.ToByte()

            Dim endval As Byte = 0
            Dim index As Integer = ba.Count - 1
            For Each bit In ba
                endval += If(bit, 1, 0) * (2 ^ index)
                index -= 1
            Next
            Return endval
        End Function

        Shared Function SetInByte(b As Byte, index As Integer, value As Byte) As Byte
            Dim temp = ByteToBitArray(b)
            temp(index) = value
            Return ArrayToByte(temp)
        End Function
        Shared Function SetInByte(b As Byte, index As Integer, value As Boolean) As Byte
            Dim temp = ByteToBoolArray(b)
            temp(index) = value
            Return ArrayToByte(temp)
        End Function

        Shared Function GetBitOfByte(b As Byte, index As Integer) As Byte
            Return ByteToBitArray(b)(index)
        End Function
        Shared Function GetBoolOfByte(b As Byte, index As Integer) As Boolean
            Return ByteToBoolArray(b)(index)
        End Function
    End Class

End Module

Public Module VersionInfo
    Public ReadOnly Property AppVersion As String
        Get
            Return Application.ProductVersion
        End Get
    End Property
    Public Const IsBetaVersion As Boolean = False
    Public ReadOnly Property IsRegistred As Boolean
        Get
            Return True
        End Get
    End Property
    Public Sub RegisterKey()

    End Sub
    Public Sub RemoveKey()

    End Sub
End Module
