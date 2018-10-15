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

Namespace Global.SM64Lib

    Public Module General

        Private _MyDataPath As String = String.Empty

        Public DisplayListCommandsWithPointerList As Byte() = {&H1, &H3, &H4, &H6, &HFD}
        Public FileIniParser As New IniParser.FileIniDataParser
        Public StreamIniParser As New IniParser.StreamIniDataParser
        Public ObjectBankData As New List(Of IniData)
        Public ActSelectorDefaultValues As Byte() = {False, False, False, True, True, False, True, True, True, True, True, True, True, True, True, False, False, False, False, False, False, True, True, True, False, False, False, False, False, False, False, False, False, False, False}
        Public PatchClass As New SM64PatchClass

        Public ReadOnly Property MyDataPath As String
            Get
                If String.IsNullOrEmpty(_MyDataPath) Then
                    _MyDataPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Data")
                End If
                Return _MyDataPath
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

        Public Function ResizeImage(image As Image, size As Size, Optional preserveAspectRatio As Boolean = False) As Image
            Dim result As New Size
            Dim clientRectangle As New Rectangle(New Point(0, 0), size)

            If preserveAspectRatio Then
                Dim val As Single = clientRectangle.Width / size.Width
                Dim num As Single = Math.Min(val, clientRectangle.Height / size.Height)
                result.Width = CInt(Math.Truncate(size.Width * num))
                result.Height = CInt(Math.Truncate(size.Height * num))
            Else
                result = size
            End If

            Dim newImage As Image = New Bitmap(image, result)
            Using g As Graphics = Graphics.FromImage(newImage)
                g.SmoothingMode = SmoothingMode.HighQuality
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.PageUnit = GraphicsUnit.Pixel
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.DrawImage(image, New Rectangle(New Point(0, 0), result))
                g.Dispose()
            End Using

            'Dim frm As New Form
            'Dim pb As New PictureBox
            'pb.Dock = DockStyle.Fill
            'frm.Controls.Add(pb)
            'pb.SizeMode = PictureBoxSizeMode.Zoom
            'pb.Image = newImage
            'frm.ShowDialog()
            'frm.Dispose()

            Return newImage
        End Function

        Public Sub RunSM64TextureFix(ByRef ObjFile As String)
            Dim uvaObjFile As String = Path.GetDirectoryName(ObjFile) & "\" & Path.GetFileNameWithoutExtension(ObjFile) & "_uva" & Path.GetExtension(ObjFile)
            If Not File.Exists(uvaObjFile) OrElse File.GetLastWriteTime(uvaObjFile) < File.GetLastWriteTime(ObjFile) Then
                If File.Exists(uvaObjFile) Then File.Delete(uvaObjFile)
                Dim pExe As String = MyDataPath & "\Tools\SM64 Texture Fix for Obj-Files.exe"
                RunExeProcess(pExe, {ObjFile}, Path.GetDirectoryName(ObjFile), True)
            End If
            ObjFile = uvaObjFile
        End Sub

        Public Function FindWaterBoxFromSpecialBox(WaterBoxes() As Collision.BoxData, SpecialBoxes As Levels.SpecialBox) As Collision.BoxData
            For Each b In WaterBoxes
                If b.X1 = SpecialBoxes.X1 And b.X2 = SpecialBoxes.X2 And b.Z1 = SpecialBoxes.Z1 And b.Z2 = SpecialBoxes.Z2 Then Return b
            Next
            Return Nothing
        End Function

        Public Sub ClearFakeROM(FakeROMFile As String, StartOffset As Integer, EndOffset As Integer)
            Dim bwFakeROM As New BinaryWriter(New FileStream(FakeROMFile, FileMode.Open, FileAccess.Write))
            bwFakeROM.BaseStream.Position = StartOffset
            For i As Integer = StartOffset To EndOffset - 1
                bwFakeROM.Write(CByte(&H1))
            Next
            bwFakeROM.BaseStream.Close()
        End Sub

        Public Function GetDigitOfByte(value As Byte, digit As Byte) As Byte
            Dim chars() As Char = Hex(value).ToCharArray
            Select Case digit
                Case 0 '0x15 --> 1
                    Return CInt("&H" & If(chars.Count = 2, chars(0), 0))
                Case 1 '0x15 --> 5
                    Return CInt("&H" & chars(If(chars.Count = 2, 1, 0)))
                Case Else
                    Return 0
            End Select
        End Function

        Public Function RunExeProcess(PathToExe As String, ExeArgs() As String, WorkingDirectory As String, CheckForSpaces As Boolean) As Integer
            Dim pExe As New Process
            With pExe.StartInfo
                .UseShellExecute = False
                .CreateNoWindow = True
                .FileName = PathToExe
                .WorkingDirectory = WorkingDirectory
                For Each a As String In ExeArgs
                    If .Arguments IsNot "" Then .Arguments &= " "
                    If CheckForSpaces Then
                        If a.Contains(" ") Then .Arguments &= """"
                        .Arguments &= a
                        If a.Contains(" ") Then .Arguments &= """"
                    Else : .Arguments &= a
                    End If
                Next
                .RedirectStandardOutput = True
            End With

            pExe.Start()

            Dim OldOutput As String = Nothing
            Do Until pExe.HasExited
                Dim NewOutput As String = pExe.StandardOutput.ReadToEnd
                If Not (NewOutput = OldOutput) Then
                    OldOutput = NewOutput
                    Console.Write(NewOutput)
                End If
            Loop

            Return pExe.ExitCode
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
        Public Function GetBackgroundIDOfAddress(StartAddr As Integer) As Geolayout.BackgroundIDs
            Select Case StartAddr
                Case Geolayout.BackgroundPointers.AboveCloudsStart : Return Geolayout.BackgroundIDs.AboveClouds
                Case Geolayout.BackgroundPointers.BelowCloudsStart : Return Geolayout.BackgroundIDs.BelowClouds
                Case Geolayout.BackgroundPointers.CavernStart : Return Geolayout.BackgroundIDs.Cavern
                Case Geolayout.BackgroundPointers.DesertStart : Return Geolayout.BackgroundIDs.Desert
                Case Geolayout.BackgroundPointers.FlamingSkyStart : Return Geolayout.BackgroundIDs.FlamingSky
                Case Geolayout.BackgroundPointers.HauntedForestStart : Return Geolayout.BackgroundIDs.HauntedForest
                Case Geolayout.BackgroundPointers.OceanStart : Return Geolayout.BackgroundIDs.Ocean
                Case Geolayout.BackgroundPointers.PurpleCloudsStart : Return Geolayout.BackgroundIDs.PurpleClouds
                Case Geolayout.BackgroundPointers.SnowyMountainsStart : Return Geolayout.BackgroundIDs.SnowyMountains
                Case Geolayout.BackgroundPointers.UnderwaterCityStart : Return Geolayout.BackgroundIDs.UnderwaterCity
                Case Else : Return Geolayout.BackgroundIDs.Custom
            End Select
        End Function
        Public Function GetBackgroundIDOfIndex(Index As Integer) As Geolayout.BackgroundIDs
            Select Case Index
                Case 1 : Return Geolayout.BackgroundIDs.HauntedForest
                Case 2 : Return Geolayout.BackgroundIDs.SnowyMountains
                Case 3 : Return Geolayout.BackgroundIDs.Desert
                Case 4 : Return Geolayout.BackgroundIDs.Ocean
                Case 5 : Return Geolayout.BackgroundIDs.UnderwaterCity
                Case 6 : Return Geolayout.BackgroundIDs.BelowClouds
                Case 7 : Return Geolayout.BackgroundIDs.AboveClouds
                Case 8 : Return Geolayout.BackgroundIDs.Cavern
                Case 9 : Return Geolayout.BackgroundIDs.FlamingSky
                Case 10 : Return Geolayout.BackgroundIDs.PurpleClouds
                Case 11 : Return Geolayout.BackgroundIDs.Custom
                Case Else : Return Geolayout.BackgroundIDs.Ocean
            End Select
        End Function
        Public Function GetBackgroundIndexOfID(ID As Geolayout.BackgroundIDs) As Integer
            Select Case ID
                Case Geolayout.BackgroundIDs.HauntedForest : Return 1
                Case Geolayout.BackgroundIDs.SnowyMountains : Return 2
                Case Geolayout.BackgroundIDs.Desert : Return 3
                Case Geolayout.BackgroundIDs.Ocean : Return 4
                Case Geolayout.BackgroundIDs.UnderwaterCity : Return 5
                Case Geolayout.BackgroundIDs.BelowClouds : Return 6
                Case Geolayout.BackgroundIDs.AboveClouds : Return 7
                Case Geolayout.BackgroundIDs.Cavern : Return 8
                Case Geolayout.BackgroundIDs.FlamingSky : Return 9
                Case Geolayout.BackgroundIDs.PurpleClouds : Return 10
                Case Geolayout.BackgroundIDs.Custom : Return 11
                Case Else : Return Geolayout.BackgroundIDs.Ocean : Return 0
            End Select
        End Function
        Public Function GetEnvironmentTypeOfIndex(Index As Integer) As Geolayout.EnvironmentEffects
            Select Case Index
                Case 0 : Return Geolayout.EnvironmentEffects.NoEffect
                Case 1 : Return Geolayout.EnvironmentEffects.Snow
                Case 2 : Return Geolayout.EnvironmentEffects.Bllizard
                Case 3 : Return Geolayout.EnvironmentEffects.BetaFlower
                Case 4 : Return Geolayout.EnvironmentEffects.Lava
                Case 5 : Return Geolayout.EnvironmentEffects.WaterRelated1
                Case 6 : Return Geolayout.EnvironmentEffects.WaterRelated2
                Case Else : Return Geolayout.EnvironmentEffects.NoEffect
            End Select
        End Function
        Public Function GetEnvironmentIndexOfType(Type As Geolayout.EnvironmentEffects) As Integer
            Select Case Type
                Case Geolayout.EnvironmentEffects.NoEffect : Return 0
                Case Geolayout.EnvironmentEffects.Snow : Return 1
                Case Geolayout.EnvironmentEffects.Bllizard : Return 2
                Case Geolayout.EnvironmentEffects.BetaFlower : Return 3
                Case Geolayout.EnvironmentEffects.Lava : Return 4
                Case Geolayout.EnvironmentEffects.WaterRelated1 : Return 5
                Case Geolayout.EnvironmentEffects.WaterRelated2 : Return 6
                Case Else : Return 0
            End Select
        End Function
        Public Function GetCameraPresetTypeOfIndex(Index As Integer) As Geolayout.CameraPresets
            Return CType(Index + 1, Geolayout.CameraPresets)
        End Function
        Public Function GetCameraPresetIndexOfType(Type As Geolayout.CameraPresets) As Integer
            Return CInt(Type) - 1
        End Function
        Public Function GetAreaBGIndexOfID(ID As Levels.AreaBGs) As Integer
            Return CInt(ID)
        End Function
        Public Function GetAreaBGIDOfIndex(Index As Integer) As Levels.AreaBGs
            Return CType(Index, Levels.AreaBGs)
        End Function

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

    Public Class RGBColor
        Public Red As Byte = 0
        Public Green As Byte = 0
        Public Blue As Byte = 0
    End Class
    Public Class RGBAColor
        Inherits RGBColor
        Public Alpha As Byte = 0
    End Class

    Public Class ObjInputSettings

        Public Property ForceDisplaylist As Geolayout.Geolayer = -1
        Public Property Scaling As Double = 500.0
        Public Property ReduceDupVertLevel = ReduceDuplicateVerticesLevel.Level1
        Public Property FlipTextures As Boolean = False
        Public Property Fog As Fog = Nothing
        Public Property ResizeTextures As Boolean = True
        Public Property CenterModel As Boolean = False
        Public ReadOnly Property Shading As New S3DFileParser.Shading

        Public Enum ReduceDuplicateVerticesLevel
            ''' <summary>Don't reduce vertices.</summary>
            Level0
            ''' <summary>Reduce only, if in the same 0x4 group.</summary>
            Level1
            ''' <summary>Reduce and push up. [Buggy]</summary>
            Level2
        End Enum
    End Class
    Public Class SM64ImportException
        Inherits Exception

        Public Sub New()
            MyBase.New("Unknown Error at converting Model.")
        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Shared Function CheckSM64ImportExitCode(ExitCode As String) As Boolean
            Select Case ExitCode
                Case 0
                    Return True
                Case 504
                    Throw New SM64ImportException("Image Error.")
                Case 500
                    Throw New SM64ImportException("Could not find extension for a image file.")
                Case 100
                    Throw New SM64ImportException("Import data limit has been exceeded!")
                Case 101
                    Throw New SM64ImportException("Could not save to the FakeROM.")
                Case 10
                    Throw New SM64ImportException("Invalid ROM path.")
                Case 1
                    Throw New SM64ImportException("Segmented pointer is not in hex format.")
                Case 3
                    Throw New SM64ImportException("There is not defined a ROM position yet.")
                Case 4
                    Throw New SM64ImportException("There is not defined a segmented pointer.")
                Case 10000
                    Throw New SM64ImportException("External program error.")
                Case 2
                    Throw New SM64ImportException("There is not defined a path to the ROM.")
                Case &HC0000409
                    Throw New SM64ImportException("External program crashed.")
                Case Else
                    Return True
                    'Throw New SM64ImportException
            End Select
        End Function
    End Class

    Module Datatypecastes

        Public Function LongToInt16(ByVal value As Long) As Int16
            Dim cast As CasterLongInt16
            cast.LongValue = value
            Return cast.Int16Value
        End Function
        <StructLayout(LayoutKind.Explicit)>
        Private Structure CasterLongInt16
            <FieldOffset(0)> Public LongValue As Long
            <FieldOffset(0)> Public Int16Value As Int16
        End Structure

        Public Function LongToByte(ByVal value As Long) As Byte
            Dim cast As CasterLongByte
            cast.LongValue = value
            Return cast.ByteValue
        End Function
        <StructLayout(LayoutKind.Explicit)>
        Private Structure CasterLongByte
            <FieldOffset(0)> Public LongValue As Long
            <FieldOffset(0)> Public ByteValue As Byte
        End Structure
    End Module

End Namespace
