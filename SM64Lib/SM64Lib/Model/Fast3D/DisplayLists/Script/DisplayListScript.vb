Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.SegmentedBanking

Namespace Model.Fast3D.DisplayLists.Script

    Public Class DisplayListScript
        Inherits List(Of DisplayListCommand)

        Public Sub FromStream(rommgr As RomManager, segAddress As Integer, AreaID As Byte?)
            Close()

            Dim lastPositions As New Stack(Of Integer)
            Dim curSeg As SegmentedBank = FromStream_GetSegBank(rommgr, segAddress, AreaID)

            If curSeg Is Nothing Then Return
            curSeg.Data.Position = curSeg.BankOffsetFromSegAddr(segAddress)

            Do While curSeg.Data.Position < curSeg.Length
                'Read Command
                Dim cmdbytes() As Byte = New Byte(7) {}
                curSeg.Data.Read(cmdbytes, 0, cmdbytes.Length)

                'Create & Add Command
                Dim cmd As New DisplayListCommand(cmdbytes)
                Me.Add(cmd)

                Select Case cmd.CommandType
                    Case CommandTypes.NOOP
                        cmd.Position = 0
                        Dim checkVal As Integer = cmd.ReadInt32
                        cmd.Position = 0
                        If checkVal <> 0 Then Exit Do

                    Case CommandTypes.DisplayList
                        cmd.Position = 4
                        Dim segAddr As Integer = cmd.ReadInt32
                        cmd.Position = 0

                        curSeg = FromStream_GetSegBank(rommgr, segAddr, AreaID)

                        If curSeg IsNot Nothing Then
                            If cmdbytes(1) <> 1 Then
                                lastPositions.Push(curSeg.Data.Position)
                            Else
                                lastPositions.Clear()
                            End If
                            curSeg.Data.Position = curSeg.BankOffsetFromSegAddr(segAddr)
                        Else Exit Do
                        End If

                    Case CommandTypes.EndDisplaylist
                        If lastPositions.Count > 0 Then
                            curSeg.Data.Position = lastPositions.Pop
                        Else
                            Exit Do
                        End If

                End Select

            Loop
        End Sub

        Private Function FromStream_GetSegBank(rommgr As RomManager, segAddr As Integer, areaID As Byte?) As SegmentedBank
            Dim seg As SegmentedBank = rommgr.GetSegBank(segAddr >> 24, areaID)
            seg?.ReadDataIfNull(rommgr.RomFile)
            Return seg
        End Function

        Public Sub ToStream(s As Stream, pos As UInteger)
            s.Position = pos
            For Each cmd As DisplayListCommand In Me
                s.Write(cmd.ToArray, 0, cmd.Length)
            Next
        End Sub

        Public Sub Close()
            For Each cmd In Me
                cmd.Close()
            Next
        End Sub
    End Class

End Namespace