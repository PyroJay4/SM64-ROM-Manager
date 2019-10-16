Imports System.IO
Imports System.Text.RegularExpressions
Imports IniParser.Model
Imports SM64Lib.Patching
Imports SM64Lib.Model
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection

Public Module General

    Public ReadOnly Property DisplayListCommandsWithPointerList As Byte() = {&H1, &H3, &H4, &H6, &HFD}
    Public ReadOnly Property ActSelectorDefaultValues As Byte() = {False, False, False, True, True, False, True, True, True, True, True, True, True, True, True, False, False, False, False, False, False, True, True, True, False, False, False, False, False, False, False, False, False, False, False}
    Public ReadOnly Property FileIniParser As New IniParser.FileIniDataParser
    Public ReadOnly Property StreamIniParser As New IniParser.StreamIniDataParser
    Public ReadOnly Property ObjectBankData As New List(Of IniData)
    Public ReadOnly Property PatchClass As New PatchClass

    Public Function KeepInInt16Range(value As Double) As Short
        If value > Short.MaxValue Then
            value = Short.MaxValue
        ElseIf value < Short.MinValue Then
            value = Short.MinValue
        End If
        Return value
    End Function

    Friend ReadOnly Property MyFilePaths As IReadOnlyDictionary(Of String, String)
        Get
            Return FilePathsConfiguration.DefaultConfiguration.Files
        End Get
    End Property

    Public Sub CopyBitmap(src As Bitmap, dest As Bitmap)
        For y As Integer = 0 To src.Height - 1
            For x As Integer = 0 To src.Width - 1
                dest.SetPixel(x, y, src.GetPixel(x, y))
            Next
        Next
    End Sub

    Public Function CopyBitmap(src As Bitmap) As Bitmap
        Return CopyBitmap(src, src.PixelFormat)
    End Function

    Public Function CopyBitmap(src As Bitmap, pixelFormat As Imaging.PixelFormat) As Bitmap
        Dim dest As New Bitmap(src.Width, src.Height, pixelFormat)
        CopyBitmap(src, dest)
        Return dest
    End Function

    Public Function Round(d As Double) As Double
        Return Math.Round(d, MidpointRounding.AwayFromZero)
    End Function

    Public Function CompareTwoByteArrays(arr1() As Byte, arr2() As Byte, Optional size As UInteger = 0) As Boolean
        If arr2.Count <> arr1.Count Then Return False

        For i As Integer = 0 To If(size <> 0, size, arr1.Count) - 1
            If arr1(i) <> arr2(i) Then Return False
        Next

        Return True
    End Function

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

    Public Function HexRoundUp1(ByVal value As Integer) As Integer
        Do While value Mod &H10 <> 0
            value += 1
        Loop
        Return value
    End Function

    Public Sub HexRoundUp2(ByRef value As Long)
        Do While value Mod &H10 <> 0
            value += 1
        Loop
    End Sub

    Public Function FillStrToCharCount(ByVal str As String, charCount As Integer, Optional fillVal As String = "0") As String
        If fillVal.Count = 0 Then Return str
        If charCount = 0 Then Return str
        Do While str.Count < charCount
            str = fillVal & str
        Loop
        Return str
    End Function

    Public Function GetBackgroundAddressOfID(ID As Geolayout.BackgroundIDs, EndAddr As Boolean) As Geolayout.BackgroundPointers
        Select Case ID
            Case Geolayout.BackgroundIDs.AboveClouds
                If EndAddr Then Return Geolayout.BackgroundPointers.AboveCloudsEnd
                Return Geolayout.BackgroundPointers.AboveCloudsStart

            Case Geolayout.BackgroundIDs.BelowClouds
                If EndAddr Then Return Geolayout.BackgroundPointers.BelowCloudsEnd
                Return Geolayout.BackgroundPointers.BelowCloudsStart

            Case Geolayout.BackgroundIDs.Cavern
                If EndAddr Then Return Geolayout.BackgroundPointers.CavernEnd
                Return Geolayout.BackgroundPointers.CavernStart

            Case Geolayout.BackgroundIDs.Desert
                If EndAddr Then Return Geolayout.BackgroundPointers.DesertEnd
                Return Geolayout.BackgroundPointers.DesertStart

            Case Geolayout.BackgroundIDs.FlamingSky
                If EndAddr Then Return Geolayout.BackgroundPointers.FlamingSkyEnd
                Return Geolayout.BackgroundPointers.FlamingSkyStart

            Case Geolayout.BackgroundIDs.HauntedForest
                If EndAddr Then Return Geolayout.BackgroundPointers.HauntedForestEnd
                Return Geolayout.BackgroundPointers.HauntedForestStart

            Case Geolayout.BackgroundIDs.Ocean
                If EndAddr Then Return Geolayout.BackgroundPointers.OceanEnd
                Return Geolayout.BackgroundPointers.OceanStart

            Case Geolayout.BackgroundIDs.PurpleClouds
                If EndAddr Then Return Geolayout.BackgroundPointers.PurpleCloudsEnd
                Return Geolayout.BackgroundPointers.PurpleCloudsStart

            Case Geolayout.BackgroundIDs.SnowyMountains
                If EndAddr Then Return Geolayout.BackgroundPointers.SnowyMountainsEnd
                Return Geolayout.BackgroundPointers.SnowyMountainsStart

            Case Geolayout.BackgroundIDs.UnderwaterCity
                If EndAddr Then Return Geolayout.BackgroundPointers.UnderwaterCityEnd
                Return Geolayout.BackgroundPointers.UnderwaterCityStart

        End Select

        Return If(EndAddr, Geolayout.BackgroundPointers.OceanEnd, Geolayout.BackgroundPointers.OceanStart)
    End Function

End Module
