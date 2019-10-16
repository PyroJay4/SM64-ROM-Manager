Imports System.IO
Imports System.Windows.Forms
Imports SM64Lib.Data
Imports SM64Lib.SegmentedBanking

Namespace Global.SM64Lib.Geolayout.Script

    Public Class Geolayoutscript
        Inherits GeolayoutCommandCollection

        Public GeopointerOffsets As New List(Of Integer)

        Public Sub New()
        End Sub

        Public Function ReadAsync(rommgr As RomManager, segAddress As Integer) As Task
            Dim t As New Task(Sub() Read(rommgr, segAddress))
            t.Start()
            Return t
        End Function

        Public Sub Read(rommgr As RomManager, segAddress As Integer)
            Close()
            Clear()
            GeopointerOffsets.Clear()

            Dim segBank As SegmentedBank = rommgr.GetSegBank(segAddress >> 24)
            If segBank Is Nothing Then Return
            segBank.ReadDataIfNull(rommgr.RomFile)
            Dim data As New BinaryStreamData(segBank.Data)

            data.Position = segBank.BankOffsetFromSegAddr(segAddress)
            Dim tb As New List(Of Byte)
            Dim cb As GeolayoutCommandTypes = Nothing
            Dim subNodeIndex As Integer = 0
            Dim ende As Boolean = False

            Do Until ende

                If data.Position >= data.Length Then Exit Do
                cb = data.ReadByte
                Dim lenth As Byte = 0

                Select Case cb
                    Case GeolayoutCommandTypes.Background : lenth = &H8
                    Case GeolayoutCommandTypes.CameraPreset : lenth = &H14
                    Case GeolayoutCommandTypes.DrawingDistance : lenth = &H4
                    Case GeolayoutCommandTypes.EndOfGeolayout : lenth = &H4
                    Case GeolayoutCommandTypes.EndOfNode : lenth = &H4
                    Case GeolayoutCommandTypes.JumpBack : lenth = &H4
                    Case GeolayoutCommandTypes.JumpToSegAddr : lenth = &H8
                    Case GeolayoutCommandTypes.LoadDisplaylist : lenth = &H8
                    Case GeolayoutCommandTypes.LoadDisplaylistWithOffset : lenth = &HC
                    Case GeolayoutCommandTypes.ObjectShadown : lenth = &H8
                    Case GeolayoutCommandTypes.Scale1 : lenth = &H4
                    Case GeolayoutCommandTypes.Scale2 : lenth = &H8
                    Case GeolayoutCommandTypes.StartOfNode : lenth = &H4
                    Case GeolayoutCommandTypes.SetScreenRenderArea : lenth = &HC
                    Case GeolayoutCommandTypes.BillboardModel : lenth = &H8
                    Case GeolayoutCommandTypes.BranchAndStore : lenth = &H8
                    Case GeolayoutCommandTypes.x0A
                        Select Case data.ReadByte
                            Case &H1 : lenth = &HC
                            Case Else : lenth = &H8
                        End Select : segBank.Data.Position -= 1
                    Case GeolayoutCommandTypes.x0B : lenth = &H4
                    Case GeolayoutCommandTypes.x0C : lenth = &H4
                    Case GeolayoutCommandTypes.x0D : lenth = &H8
                    Case GeolayoutCommandTypes.x0E : lenth = &H8
                    Case GeolayoutCommandTypes.x10 : lenth = &H10
                    Case GeolayoutCommandTypes.x11 : lenth = &H8
                    Case GeolayoutCommandTypes.x17 : lenth = &H4
                    Case GeolayoutCommandTypes.x18 : lenth = &H8
                    Case GeolayoutCommandTypes.x1A : lenth = &H8
                    Case GeolayoutCommandTypes.x1C : lenth = &HC
                    Case GeolayoutCommandTypes.x1E : lenth = &H8
                    Case GeolayoutCommandTypes.x1f : lenth = &H10
                    Case Else : Exit Do
                End Select

                segBank.Data.Position -= 1

                If segBank.Data.Position + lenth > segBank.Data.Length Then
                    Exit Do
                End If

                For i As Integer = 1 To lenth
                    tb.Add(data.ReadByte)
                Next

                Dim tCommand = New GeolayoutCommand(tb.ToArray)
                Dim bankOffset As Integer = segBank.Data.Position - lenth
                tCommand.RomAddress = segBank.RomStart + bankOffset
                tCommand.BankAddress = segBank.BankAddress + bankOffset
                Add(tCommand)

                tb.Clear()

                Select Case tCommand.CommandType
                    Case GeolayoutCommandTypes.EndOfGeolayout
                        ende = True
                    Case GeolayoutCommandTypes.EndOfNode
                        subNodeIndex -= 1
                    Case GeolayoutCommandTypes.StartOfNode
                        subNodeIndex += 1
                End Select

            Loop
        End Sub

        Public Sub Write(s As Stream, GeolayoutStart As Integer)
            Dim bw As New BinaryWriter(s)

            'Write new Levelscript
            s.Position = GeolayoutStart
            For Each c As GeolayoutCommand In Me
                If c.CommandType = GeolayoutCommandTypes.LoadDisplaylist Then GeopointerOffsets.Add(s.Position + &H4)
                For Each b As Byte In c.ToArray
                    bw.Write(b)
                Next
            Next
        End Sub

        Public Function GetFirst(cmdType As GeolayoutCommandTypes) As GeolayoutCommand
            For Each cmd As GeolayoutCommand In Me
                If cmd.CommandType = cmdType Then
                    Return cmd
                End If
            Next
            Return Nothing
        End Function

    End Class

End Namespace