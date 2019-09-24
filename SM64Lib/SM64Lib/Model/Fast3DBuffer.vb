Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports N64Graphics
Imports Pilz.S3DFileParser
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Model.Collision
Imports SM64Lib.Model.Fast3D.DisplayLists

Namespace Model.Fast3D

    Public Class Fast3DBuffer
        Inherits MemoryStream

        Public Property ConvertResult As SM64Convert.Fast3DWriter.ConvertResult = Nothing
        Public Property Fast3DBankStart As Integer = &HE000000
        Public Property DLPointers As Geopointer() = {}

        ''' <summary>
        ''' Creates a Fast3D Model from a Obj File
        ''' </summary>
        Public Sub FromModel(ObjSettings As ObjectInputSettings, model As Object3D, Optional texFormatSettings As TextureFormatSettings = Nothing)
            'Setup Settings
            Dim conSettings As New SM64Convert.Fast3DWriter.ConvertSettings With {
                .CenterModel = ObjSettings.CenterModel,
                .Scale = ObjSettings.Scaling,
                .ResizeTextures = ObjSettings.ResizeTextures,
                .ReduceVertLevel = ObjSettings.ReduceDupVertLevel,
                .SegmentedAddress = &HE000000,
                .ForceDisplaylist = ObjSettings.ForceDisplaylist,
                .Fog = ObjSettings.Fog,
                .OptimizeTransparencyChecks = ObjSettings.OptimizeTransparencyChecks,
                .TextureFormatSettings = texFormatSettings
            }
            model.Shading = ObjSettings.Shading

            'Convert Model
            Dim con As New SM64Convert.Fast3DWriter
            ConvertResult = con.ConvertModel(Me, conSettings, model)

            'Fit to align
            SetLength(HexRoundUp1(Length))

            'Copy Geopointer etc.
            DLPointers = ConvertResult.PtrGeometry.ToArray
            Fast3DBankStart = &HE000000
        End Sub
        Public Sub FromStream(s As Stream, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer)
            FromBinaryData(New BinaryStreamData(s), BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer)
        End Sub
        Public Sub FromBinaryData(data As BinaryData, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer)
            DLPointers = DisplayListpointer
            Fast3DBankStart = Fast3DStart - BankRomStart + BankRamStart

            data.Position = Fast3DStart
            SetLength(Fast3DLength)
            Position = 0

            For i As Integer = 1 To Fast3DLength
                WriteByte(data.ReadByte)
            Next
        End Sub

        Public Function FromModelAsync(ObjSettings As ObjectInputSettings, model As Object3D, Optional texFormatSettings As TextureFormatSettings = Nothing) As Task
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
            ToBinaryData(New BinaryStreamData(s), RomPos, BankRomStart, BankRamStart)
        End Sub

        Public Sub ToBinaryData(data As BinaryData, dataPos As Integer, BankRomStart As Integer, BankRamStart As Integer)
            data.Position = dataPos

            'Update all Pointers
            Dim newBankStart As Integer = (dataPos - BankRomStart + BankRamStart)
            Dim tdif As Integer = newBankStart - Fast3DBankStart

            For Each geop As Geopointer In DLPointers
                If geop.SegPointer >> 24 = &HE Then
                    Me.Position = geop.SegPointer - Fast3DBankStart

                    Do
                        Select Case Me.ReadByte
                            Case &HB8
                                Exit Do

                            Case &H3, &H4, &H6, &HFD
                                Position += 3

                                Dim sd As New BinaryStreamData(Me)

                                Dim p As Integer = sd.ReadInt32
                                p += tdif

                                Position -= 4

                                sd.Write(p)

                            Case Else
                                Position += 7

                        End Select
                    Loop While Position < Length

                    geop.SegPointer += tdif
                End If
            Next

            'Write Fast3D
            For Each b As Byte In ToArray()
                data.Write(b)
            Next

            Fast3DBankStart = newBankStart
        End Sub

    End Class

End Namespace