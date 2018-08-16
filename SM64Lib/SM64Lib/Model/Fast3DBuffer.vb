Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports N64Graphics
Imports S3DFileParser
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Collision
Imports SM64Lib.Model.Fast3D.DisplayLists

Namespace Global.SM64Lib.Model.Fast3D

    Public Class Fast3DBuffer
        Inherits MemoryStream

        Public Property ConvertResult As SM64Convert.Fast3DWriter.ConvertResult = Nothing
        Public Property Fast3DBankStart As Integer = &HE000000
        Public Property DLPointers As Geopointer() = {}

        ''' <summary>
        ''' Creates a Fast3D Model from a Obj File
        ''' </summary>
        Public Sub FromModel(ObjSettings As ObjInputSettings, model As Object3D, Optional texFormatSettings As TextureFormatSettings = Nothing)
            Dim tBankRomOffset As Integer = 0
            Dim ilenght As Integer = 0
            Dim pointerList As New List(Of Geopointer)

            'Convert Model
            Dim conSettings As New SM64Convert.Fast3DWriter.ConvertSettings With {
                .CenterModel = ObjSettings.CenterModel,
                .Scale = ObjSettings.Scaling,
                .ResizeTextures = ObjSettings.ResizeTextures,
                .FlipTexturesVerticaly = ObjSettings.FlipTextures,
                .ReduceVertLevel = ObjSettings.ReduceDupVertLevel,
                .SegmentedAddress = &HE000000,
                .ForceDisplaylist = ObjSettings.ForceDisplaylist,
                .Fog = ObjSettings.Fog}

            Dim con As New SM64Convert.Fast3DWriter
            Dim ms As New MemoryStream

            ConvertResult = con.ConvertModel(ms, conSettings, model, texFormatSettings)

            For i As Integer = ms.Position To HexRoundUp1(ms.Position)
                ms.WriteByte(1)
            Next

            'Collect Pointers
            If ConvertResult.PtrSolid <> 0 Then
                pointerList.Add(New Geopointer(Geolayer.Solid, ConvertResult.PtrSolid))
            End If
            If ConvertResult.PtrAlpha <> 0 Then
                pointerList.Add(New Geopointer(Geolayer.Alpha, ConvertResult.PtrAlpha))
            End If
            If ConvertResult.PtrTrans <> 0 Then
                pointerList.Add(New Geopointer(Geolayer.Transparent, ConvertResult.PtrTrans))
            End If
            ilenght = ms.Length

            'Read Fast3D
            FromStream(ms, 0, &HE000000, 0, ilenght, pointerList.ToArray)
            ms.Close()
        End Sub
        Public Sub FromStream(s As Stream, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer)
            DLPointers = DisplayListpointer
            Fast3DBankStart = Fast3DStart - BankRomStart + BankRamStart

            s.Position = Fast3DStart
            Me.SetLength(Fast3DLength)
            Me.Position = 0

            For i As Integer = 1 To Fast3DLength
                Me.WriteByte(s.ReadByte)
            Next
        End Sub

        Public Function FromModelAsync(ObjSettings As ObjInputSettings, model As Object3D, Optional texFormatSettings As TextureFormatSettings = Nothing) As Task
            Dim t As New Task(Sub() FromModel(ObjSettings, model, texFormatSettings))
            t.Start()
            Return t
        End Function
        Public Function FromStreamAsync(s As Stream, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer) As Task
            Dim t As New Task(Sub() FromStream(s, BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer))
            t.Start()
            Return t
        End Function

        Public Sub ToStream(s As Stream, RomPos As Integer, BankRomStart As Integer, BankRamStart As Integer)
            Dim bw As New BinaryWriter(s)
            s.Position = RomPos

            'Update all Pointers
            Dim newBankStart As Integer = (RomPos - BankRomStart + BankRamStart)
            Dim tdif As Integer = newBankStart - Fast3DBankStart

            For Each geop As Geopointer In DLPointers
                If geop.SegPointer >> 24 = &HE Then
                    Me.Position = geop.SegPointer - Fast3DBankStart

                    Do
                        Select Case Me.ReadByte
                            Case &HB8
                                Exit Do

                            Case &H3, &H4, &H6, &HFD
                                Me.Position += 3

                                Dim brBuffer As New BinaryReader(Me)
                                Dim bwBuffer As New BinaryWriter(Me)

                                Dim p As Integer = SwapInts.SwapInt32(brBuffer.ReadInt32)
                                p += tdif

                                Me.Position -= 4

                                bwBuffer.Write(SwapInts.SwapInt32(p))

                            Case Else
                                Me.Position += 7

                        End Select
                    Loop While Me.Position < Me.Length

                    geop.SegPointer += tdif
                End If
            Next

            'Write Fast3D
            For Each b As Byte In Me.ToArray
                bw.Write(b)
            Next

            Fast3DBankStart = newBankStart 'RomPos - BankRomStart + BankRamStart
        End Sub

    End Class

End Namespace