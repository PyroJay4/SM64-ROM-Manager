'========================================================================
' This conversion was produced by the Free Edition of
' Instant VB courtesy of Tangible Software Solutions.
' Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
'========================================================================

Imports System.IO
Imports System.Windows.Forms
Imports DevComponents.DotNetBar

Public Class OutputMIDI

    Public Shared ReadOnly Property Settings As New SettingsData
    Public Shared ReadOnly Property HeaderData As New HeaderClass
    Public Shared ReadOnly Property TrackData As New TrackClass
    Public Shared ReadOnly Property LayerData As New LayerClass
    Public Shared ReadOnly Property NoteData As New NoteClass

    Public Shared Function FirstByte(value As Integer) As Byte
        Return BitConverter.GetBytes(value)(0)
    End Function

    Public Shared Sub Advance(br As BinaryReader, value As Integer)
        br.BaseStream.Position += CLng(value)
    End Sub

    Public Shared Sub ReadHeader(br As BinaryReader)
        Do While br.BaseStream.Position < br.BaseStream.Length
            Dim num As Byte = br.ReadByte()
            If CInt(num) >= 144 AndAlso CInt(num) <= 159 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 196 Then
                Exit Do
            End If
            If CInt(num) = 200 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 211 Then
                OutputMIDI.Advance(br, 1)
                OutputMIDI.HeaderData.Valid = True
            End If
            If CInt(num) = 213 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 214 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 215 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 217 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 219 Then
                OutputMIDI.HeaderData.Volume = br.ReadByte()
            End If
            If CInt(num) = 221 Then
                OutputMIDI.HeaderData.Tempo = br.ReadByte()
            End If
            If CInt(num) = 249 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 250 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 251 Then
                OutputMIDI.HeaderData.LoopOffset = CInt(OutputMIDI.Reverse.Int16(br.ReadInt16())) And CInt(UShort.MaxValue)
            End If
            If CInt(num) = 253 Then
                OutputMIDI.HeaderData.MaxTimestamp += CInt(OutputMIDI.ReadParameter(br))
            End If
            If CInt(num) = CInt(Byte.MaxValue) Then
                Exit Do
            End If
        Loop
    End Sub

    Public Shared Sub ReadNote(br As BinaryReader, by As Byte)
        Dim num As Integer = 0
        If CInt(by) >= 0 AndAlso CInt(by) <= 63 Then
            num = CInt(by)
            OutputMIDI.NoteData.Timestamp = CInt(OutputMIDI.ReadParameter(br))
            OutputMIDI.NoteData.Velocity = br.ReadByte()
            OutputMIDI.NoteData.Duration = br.ReadByte()
        End If
        If CInt(by) >= 64 AndAlso CInt(by) <= CInt(SByte.MaxValue) Then
            num = CInt(by) - 64
            OutputMIDI.NoteData.Timestamp = CInt(OutputMIDI.ReadParameter(br))
            OutputMIDI.NoteData.Velocity = br.ReadByte()
        End If
        If CInt(by) >= 128 AndAlso CInt(by) <= 191 Then
            num = CInt(by) - 128
            OutputMIDI.NoteData.Velocity = br.ReadByte()
            OutputMIDI.NoteData.Duration = br.ReadByte()
        End If
        OutputMIDI.NoteData.Key = OutputMIDI.FirstByte(num)
        OutputMIDI.LayerData.TotalTimestamp += OutputMIDI.NoteData.Timestamp
    End Sub

    Public Shared Function ReadParameter(br As BinaryReader) As Short
        Dim num As Integer = CInt(Math.Truncate(br.ReadByte()))
        If (num And 128) = 128 Then
            num = (num << 8) + CInt(Math.Truncate(br.ReadByte()))
            If (num And 32640) = 0 Then
                num = 192
                br.BaseStream.Position -= 1
            End If
        End If
        Return BitConverter.ToInt16(BitConverter.GetBytes(num And CInt(Short.MaxValue)), 0)
    End Function

    Public Shared Sub ConvertHeader(br As BinaryReader, bw As BinaryWriter, track As Byte, layer As Byte)
        If CInt(OutputMIDI.Settings.LimitChunks) = 2 Then
            br.BaseStream.Position = CLng(OutputMIDI.HeaderData.LoopOffset)
        End If
        Do While br.BaseStream.Position < br.BaseStream.Length
            Dim num As Byte = br.ReadByte()
            If CInt(num) >= 144 AndAlso CInt(num) <= 159 Then
                If CInt(num) = (144 Or CInt(track)) Then
                    OutputMIDI.HeaderData.ReturnOffset = br.BaseStream.Position + 2L
                    br.BaseStream.Position = CLng(CInt(OutputMIDI.Reverse.Int16(br.ReadInt16())) And CInt(UShort.MaxValue))
                    OutputMIDI.ConvertTrack(br, bw, track, layer)
                    br.BaseStream.Position = OutputMIDI.HeaderData.ReturnOffset
                Else
                    OutputMIDI.Advance(br, 2)
                End If
            End If
            If CInt(num) = 196 Then
                Exit Do
            End If
            If CInt(num) = 200 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 211 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 213 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 214 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 215 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 217 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 219 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 221 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 249 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 250 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 251 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 253 Then
                OutputMIDI.HeaderData.TotalTimestamp += CInt(OutputMIDI.ReadParameter(br))
                If OutputMIDI.HeaderData.TotalTimestamp > OutputMIDI.LayerData.TotalTimestamp Then
                    OutputMIDI.NoteData.RestTimestamp = OutputMIDI.HeaderData.TotalTimestamp - OutputMIDI.LayerData.TotalTimestamp
                End If
            End If
            If CInt(num) = CInt(Byte.MaxValue) OrElse CInt(OutputMIDI.Settings.LimitChunks) = 1 AndAlso br.BaseStream.Position >= CLng(OutputMIDI.HeaderData.LoopOffset) Then
                Exit Do
            End If
        Loop
    End Sub

    Public Shared Sub ConvertTrack(br As BinaryReader, bw As BinaryWriter, track As Byte, layer As Byte)
        Do While br.BaseStream.Position < br.BaseStream.Length
            Dim num As Byte = br.ReadByte()
            If CInt(num) >= 144 AndAlso CInt(num) <= 159 Then
                If CInt(num) = (144 Or CInt(layer)) Then
                    OutputMIDI.TrackData.ReturnOffset = br.BaseStream.Position + 2L
                    br.BaseStream.Position = CLng(CInt(OutputMIDI.Reverse.Int16(br.ReadInt16())) And CInt(UShort.MaxValue))
                    OutputMIDI.ConvertLayer(br, bw, track, layer)
                    br.BaseStream.Position = OutputMIDI.TrackData.ReturnOffset
                    If Not OutputMIDI.HeaderData.ActiveLayers(CInt(track), CInt(num) And 15) Then
                        OutputMIDI.HeaderData.TotalLayers += 1
                    End If
                    OutputMIDI.HeaderData.ActiveLayers(CInt(track), CInt(num) And 15) = True
                Else
                    OutputMIDI.Advance(br, 2)
                End If
            End If
            If CInt(num) = 193 Then
                OutputMIDI.TrackData.Program = br.ReadByte()
            End If
            If CInt(num) = 194 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 198 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 200 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 202 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 204 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 208 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 211 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 212 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 216 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 220 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 221 Then
                OutputMIDI.TrackData.Pan = br.ReadByte()
            End If
            If CInt(num) = 223 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 224 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 229 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 233 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = 250 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 251 Then
                OutputMIDI.Advance(br, 2)
            End If
            If CInt(num) = 253 Then
                OutputMIDI.TrackData.TotalTimestamp += CInt(OutputMIDI.ReadParameter(br))
                If OutputMIDI.TrackData.TotalTimestamp > OutputMIDI.LayerData.TotalTimestamp Then
                    OutputMIDI.NoteData.RestTimestamp = OutputMIDI.TrackData.TotalTimestamp - OutputMIDI.LayerData.TotalTimestamp
                End If
            End If
            If CInt(num) = 254 Then
                OutputMIDI.Advance(br, 1)
            End If
            If CInt(num) = CInt(Byte.MaxValue) Then
                Exit Do
            End If
        Loop
    End Sub

    Public Shared Sub ConvertLayer(br As BinaryReader, bw As BinaryWriter, track As Byte, layer As Byte)
        OutputMIDI.NoteData.FirstNote = True
        Do While br.BaseStream.Position < br.BaseStream.Length
            Dim by As Byte = br.ReadByte()
            If CInt(by) >= 0 AndAlso CInt(by) <= 191 Then
                OutputMIDI.ReadNote(br, by)
                OutputMIDI.WriteNote(bw, track)
                OutputMIDI.NoteData.RestTimestamp = 0
                OutputMIDI.NoteData.FirstNote = False
            End If
            If CInt(by) = 192 Then
                Dim num As Short = OutputMIDI.ReadParameter(br)
                OutputMIDI.NoteData.RestTimestamp += CInt(num)
                OutputMIDI.LayerData.TotalTimestamp += CInt(num)
            End If
            If CInt(by) = 194 Then
                OutputMIDI.NoteData.Transposition = br.ReadByte()
            End If
            If CInt(by) = 252 Then
                OutputMIDI.LayerData.ReturnOffset = br.BaseStream.Position + 2L
                br.BaseStream.Position = CLng(CInt(OutputMIDI.Reverse.Int16(br.ReadInt16())) And CInt(UShort.MaxValue))
                OutputMIDI.NoteData.InJump = True
            End If
            If CInt(by) = CInt(Byte.MaxValue) Then
                If Not OutputMIDI.NoteData.InJump Then
                    Exit Do
                End If
                br.BaseStream.Position = OutputMIDI.LayerData.ReturnOffset
                OutputMIDI.NoteData.InJump = False
            End If
            If OutputMIDI.LayerData.TotalTimestamp >= OutputMIDI.HeaderData.MaxTimestamp AndAlso OutputMIDI.Settings.Restrict Then
                Exit Do
            End If
        Loop
    End Sub

    Public Shared Sub WriteMeta(bw As BinaryWriter, delta As Integer, value As Integer)
        OutputMIDI.WriteDelta(bw, delta)
        bw.Write(OutputMIDI.FirstByte(CInt(Byte.MaxValue)))
        bw.Write(OutputMIDI.FirstByte(value))
    End Sub

    Public Shared Sub WriteDelta(bw As BinaryWriter, delta As Integer)
        Dim num1 As Integer = 0
        Dim index As Byte = 0
        Do While CInt(index) < 4
            Dim num2 As Byte = OutputMIDI.FirstByte(delta << CInt(index) >> 8 * CInt(index))
            If CInt(index) = 0 Then
                num1 = num1 Or (CInt(num2) And CInt(SByte.MaxValue)) << 8 * CInt(index)
            ElseIf CInt(num2) <> 0 Then
                num1 = num1 Or ((CInt(num2) Or 128) And CInt(Byte.MaxValue)) << 8 * CInt(index)
            End If
            index += 1
        Loop
        Dim bytes() As Byte = BitConverter.GetBytes(num1)
        If CInt(bytes(3)) <> 0 Then
            bw.Write(OutputMIDI.Reverse.Int32(BitConverter.ToInt32(bytes, 0)))
        ElseIf CInt(bytes(2)) <> 0 Then
            bw.Write(bytes(2))
            bw.Write(bytes(1))
            bw.Write(bytes(0))
        ElseIf CInt(bytes(1)) <> 0 Then
            bw.Write(OutputMIDI.Reverse.Int16(BitConverter.ToInt16(bytes, 0)))
        Else
            bw.Write(bytes(0))
        End If
    End Sub

    Public Shared Sub WriteNote(bw As BinaryWriter, track As Byte)
        OutputMIDI.WriteDelta(bw, OutputMIDI.NoteData.RestTimestamp)
        If OutputMIDI.NoteData.FirstNote Then
            bw.Write(OutputMIDI.FirstByte(144 Or CInt(track)))
        End If
        bw.Write(OutputMIDI.FirstByte(CInt(OutputMIDI.NoteData.Key) + CInt(OutputMIDI.NoteData.Transposition) + 21))
        bw.Write(OutputMIDI.NoteData.Velocity)
        OutputMIDI.WriteDelta(bw, OutputMIDI.NoteData.Timestamp)
        bw.Write(OutputMIDI.FirstByte(CInt(OutputMIDI.NoteData.Key) + CInt(OutputMIDI.NoteData.Transposition) + 21))
        bw.Write(OutputMIDI.FirstByte(0))
    End Sub

    Public Shared Sub StartMIDIHeader(bw As BinaryWriter)
        bw.Write(OutputMIDI.Reverse.String32("MThd"))
        bw.Write(OutputMIDI.Reverse.Int32(6))
        bw.Write(OutputMIDI.Reverse.Int16(CShort(1)))
        bw.Write(OutputMIDI.Reverse.Int16(CShort(0)))
        bw.Write(OutputMIDI.Reverse.Int16(CShort(48)))
    End Sub

    Public Shared Sub FinishMIDIHeader(bw As BinaryWriter)
        bw.BaseStream.Position = 10L
        OutputMIDI.HeaderData.TotalLayers += 1
        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: bw.Write(OutputMIDI.Reverse.Int16(++OutputMIDI.HeaderData.TotalLayers));
        bw.Write(OutputMIDI.Reverse.Int16(OutputMIDI.HeaderData.TotalLayers))
    End Sub

    Public Shared Sub StartMIDISettings(bw As BinaryWriter)
        bw.Write(OutputMIDI.Reverse.String32("MTrk"))
        bw.Write(OutputMIDI.Reverse.Int32(25))
        OutputMIDI.WriteMeta(bw, 0, 88)
        bw.Write(OutputMIDI.FirstByte(4))
        bw.Write(OutputMIDI.FirstByte(4))
        bw.Write(OutputMIDI.FirstByte(2))
        bw.Write(OutputMIDI.FirstByte(24))
        bw.Write(OutputMIDI.FirstByte(8))
        OutputMIDI.WriteMeta(bw, 0, 89)
        bw.Write(OutputMIDI.FirstByte(2))
        bw.Write(OutputMIDI.FirstByte(0))
        bw.Write(OutputMIDI.FirstByte(0))
        OutputMIDI.WriteMeta(bw, 0, 81)
        bw.Write(OutputMIDI.Reverse.Int32(0))
        bw.Write(OutputMIDI.Reverse.Int32(16723712))
    End Sub

    Public Shared Sub FinishMIDISettings(bw As BinaryWriter)
        bw.BaseStream.Position = 39L
        'INSTANT VB WARNING: Instant VB cannot determine whether both operands of this division are integer types - if they are then you should use the VB integer division operator:
        bw.Write(OutputMIDI.Reverse.Int32(60000000 / (CInt(OutputMIDI.HeaderData.Tempo) And CInt(Byte.MaxValue)) Or 50331648))
    End Sub

    Public Shared Sub StartMIDITrack(bw As BinaryWriter, track As Byte)
        bw.Write(OutputMIDI.Reverse.String32("MTrk"))
        bw.Write(OutputMIDI.Reverse.Int32(0))
        OutputMIDI.LayerData.WriteOffset = bw.BaseStream.Position
        OutputMIDI.WriteMeta(bw, 0, 3)
        bw.Write(OutputMIDI.FirstByte(0))
        OutputMIDI.WriteControl.Program(bw, track, 0, CByte(0))
        OutputMIDI.WriteControl.Volume(bw, track, 0, CByte(127))
        OutputMIDI.WriteControl.Pan(bw, track, 0, CByte(0))
    End Sub

    Public Shared Sub FinishMIDITrack(bw As BinaryWriter, track As Byte)
        bw.Write(OutputMIDI.Reverse.Int32(16723712))
        Dim num As Long = bw.BaseStream.Position - OutputMIDI.LayerData.WriteOffset
        bw.BaseStream.Position = OutputMIDI.LayerData.WriteOffset - 4L
        Dim bytes() As Byte = BitConverter.GetBytes(num)
        bw.Write(OutputMIDI.Reverse.Int32(BitConverter.ToInt32(bytes, 0)))
        bw.BaseStream.Position = OutputMIDI.LayerData.WriteOffset + 4L
        OutputMIDI.WriteControl.Program(bw, track, 0, OutputMIDI.TrackData.Program)
        bw.BaseStream.Position = OutputMIDI.LayerData.WriteOffset + 11L
        OutputMIDI.WriteControl.Pan(bw, track, 0, OutputMIDI.TrackData.Pan)
        If OutputMIDI.LayerData.TotalTimestamp > 0 Then
            bw.BaseStream.Position = bw.BaseStream.Length
        Else
            bw.BaseStream.Position = bw.BaseStream.Length - 27L
        End If
    End Sub

    Public Shared Sub ConvertToMIDI(outputFile As String, inputStream As Stream, chunk As Byte, restrict As Boolean)
        Settings.LimitChunks = chunk
        Settings.Restrict = restrict

        'Dim fileStream1 As New FileStream(file, FileMode.Open, FileAccess.Read)
        Dim fileStream2 As New FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite)
        Dim br As New BinaryReader(inputStream)
        Dim bw As New BinaryWriter(fileStream2)

        ReadHeader(br)

        If Not HeaderData.Valid Then
            Throw New FormatException("Header of .m64 file is invalid!")
        Else
            StartMIDIHeader(bw)
            StartMIDISettings(bw)

            Dim position As Long = bw.BaseStream.Position
            Dim track As Byte = 0

            Do While CInt(track) < 16
                Dim layer As Byte = 0
                Do While CInt(layer) < 16
                    HeaderData.TotalTimestamp = 0
                    br.BaseStream.Position = 0L
                    StartMIDITrack(bw, track)
                    ConvertHeader(br, bw, track, layer)
                    FinishMIDITrack(bw, track)
                    _TrackData = New TrackClass
                    _LayerData = New LayerClass
                    _NoteData = New NoteClass
                    layer += 1
                Loop
                track += 1
            Loop

            If position = bw.BaseStream.Position Then
                br.Close()
                bw.Flush()
                bw.Close()
                'fileStream1.Close()
                fileStream2.Close()
                _HeaderData = New HeaderClass
                IO.File.Delete(fileStream2.Name)
                Throw New FormatException(".m64 file is invalid!")
            Else
                FinishMIDIHeader(bw)
                FinishMIDISettings(bw)
                br.Close()
                bw.Flush()
                bw.Close()
                'fileStream1.Close()
                fileStream2.Close()
                _HeaderData = New HeaderClass
            End If
        End If
    End Sub

    Public Class SettingsData
        Public LimitChunks As Byte
        Public Restrict As Boolean
    End Class

    Public Class HeaderClass
        Public ActiveLayers(15, 15) As Boolean
        Public ReturnOffset As Long
        Public TotalTimestamp As Integer
        Public MaxTimestamp As Integer
        Public LoopOffset As Integer
        Public TotalLayers As Short
        Public Volume As Byte
        Public Tempo As Byte
        Public Valid As Boolean
    End Class

    Public Class TrackClass
        Public ReturnOffset As Long
        Public TotalTimestamp As Integer
        Public Program As Byte
        Public Pan As Byte
    End Class

    Public Class LayerClass
        Public ReturnOffset As Long
        Public WriteOffset As Long
        Public TotalTimestamp As Integer
    End Class

    Public Class NoteClass
        Public FirstNote As Boolean = True
        Public Timestamp As Integer
        Public RestTimestamp As Integer
        Public Transposition As Byte
        Public Key As Byte
        Public Velocity As Byte
        Public Duration As Byte
        Public InJump As Boolean
    End Class

    Public Class Reverse
        Public Shared Function Int16(value As Short) As Short
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(CType(bytes, Array))
            Return BitConverter.ToInt16(bytes, 0)
        End Function

        Public Shared Function Int32(value As Integer) As Integer
            Dim bytes() As Byte = BitConverter.GetBytes(value)
            Array.Reverse(CType(bytes, Array))
            Return BitConverter.ToInt32(bytes, 0)
        End Function

        Public Shared Function String32(text As String) As Integer
            Dim num As Integer = 0
            For Each ch As Char In text.ToCharArray()
                num = (num << 8) + AscW(ch)
            Next ch
            Dim bytes() As Byte = BitConverter.GetBytes(num)
            Array.Reverse(CType(bytes, Array))
            Return BitConverter.ToInt32(bytes, 0)
        End Function
    End Class

    Public Class WriteControl
        Public Shared Sub Pan(bw As BinaryWriter, track As Byte, delta As Integer, pan As Byte)
            OutputMIDI.WriteDelta(bw, delta)
            bw.Write(OutputMIDI.FirstByte(176 Or CInt(track)))
            bw.Write(OutputMIDI.FirstByte(10))
            bw.Write(pan)
        End Sub

        Public Shared Sub Volume(bw As BinaryWriter, track As Byte, delta As Integer, volume As Byte)
            OutputMIDI.WriteDelta(bw, delta)
            bw.Write(OutputMIDI.FirstByte(176 Or CInt(track)))
            bw.Write(OutputMIDI.FirstByte(7))
            If CInt(volume) > CInt(SByte.MaxValue) Then
                volume = CByte(127)
            End If
            bw.Write(volume)
        End Sub

        Public Shared Sub Program(bw As BinaryWriter, track As Byte, delta As Integer, program As Byte)
            OutputMIDI.WriteDelta(bw, delta)
            bw.Write(OutputMIDI.FirstByte(192 Or CInt(track)))
            bw.Write(program)
        End Sub
    End Class

End Class
