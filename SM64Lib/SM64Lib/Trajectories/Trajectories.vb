Imports System.IO

Namespace Trajectorys

    Public Class Trajectories
        Inherits List(Of Trajectory)

        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return Me.FirstOrDefault(Function(n) n.NeedToSave) IsNot Nothing
            End Get
        End Property

        Public Sub WriteTrajectories(rom As Stream)
            Dim bw As New BinaryWriter(rom)
            Dim curPos As Integer = &H1205000
            Dim romstartAddr As Integer = &H1200000
            Dim ramStartAddr As Integer = &H80400000

            For Each traj As Trajectory In Me
                Dim ramAddr As Integer = curPos - romstartAddr + ramStartAddr

                Select Case traj.Name
                    Case TrajectoryName.KoopaTheQuick1
                        rom.Position = &HED864
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.KoopaTheQuick2
                        rom.Position = &HED874
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.RacingPenguin
                        rom.Position = &HCCA6E
                        bw.Write(SwapInts.SwapUInt16(ramAddr >> 16))
                        rom.Position = &HCCA76
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.SnowmansBottom
                        rom.Position = &HABC9E
                        bw.Write(SwapInts.SwapUInt16(ramAddr >> 16))
                        rom.Position = &HABCA6
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_00
                        rom.Position = &HED9DC + (0 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_01
                        rom.Position = &HED9DC + (1 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_02
                        rom.Position = &HED9DC + (2 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_03
                        rom.Position = &HED9DC + (3 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_04
                        rom.Position = &HED9DC + (4 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_05
                        rom.Position = &HED9DC + (5 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_06
                        rom.Position = &HED9DC + (6 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.PlatformOnTracksBehavior_BParam2_07
                        rom.Position = &HED9DC + (7 * 4)
                        bw.Write(SwapInts.SwapInt32(ramAddr))

                    Case TrajectoryName.MetalBallsGenerators_BParam2_00
                        rom.Position = &HA9AB4
                        bw.Write(SwapInts.SwapInt32(&H3C048040)) 'LUI A0, 0x8040
                        rom.Position = &HA9ABC
                        bw.Write(SwapInts.SwapUInt16(&H3484)) 'ORI A0, A0, 0x8040xxxx
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.MetalBallsGenerators_BParam2_01
                        rom.Position = &HA9AD4
                        bw.Write(SwapInts.SwapInt32(&H3C048040)) 'LUI A0, 0x8040
                        rom.Position = &HA9ADC
                        bw.Write(SwapInts.SwapUInt16(&H3484)) 'ORI A0, A0, 0x8040xxxx
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.MetalBallsGenerators_BParam2_02
                        rom.Position = &HA9AF4
                        bw.Write(SwapInts.SwapInt32(&H3C048040)) 'LUI A0, 0x8040
                        rom.Position = &HA9AFC
                        bw.Write(SwapInts.SwapUInt16(&H3484)) 'ORI A0, A0, 0x8040xxxx
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.MiniMetalBallGenerator_BParam2_03
                        rom.Position = &HA9B1C
                        bw.Write(SwapInts.SwapInt32(&H3C098040)) 'LU3 T3, 0x8040
                        bw.Write(SwapInts.SwapUInt16(&H356B)) 'ORI T3, T3, 0x8040xxxx
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.MiniMetalBallGenerator_BParam2_04
                        rom.Position = &HA9B38
                        bw.Write(SwapInts.SwapInt32(&H3C098040)) 'LU3 T3, 0x8040
                        bw.Write(SwapInts.SwapUInt16(&H356B)) 'ORI T3, T3, 0x8040xxxx
                        bw.Write(SwapInts.SwapUInt16(ramAddr And &HFFFF))

                    Case TrajectoryName.MipsTheRabbit
                        Continue For

                End Select

                traj.Write(rom, curPos)
                curPos = rom.Position
            Next

            'Mips the Rabbit
            Dim mipsTrajects As Trajectory() = Where(Function(n) n.Name = TrajectoryName.MipsTheRabbit).ToArray
            If mipsTrajects.Length > 0 Then
                rom.Position = &HB3816
                bw.Write(SwapInts.SwapUInt16(&H8040))
                rom.Position += 6
                bw.Write(SwapInts.SwapUInt16((curPos - romstartAddr + ramStartAddr) And &HFFFF))

                For Each traj As Trajectory In mipsTrajects
                    traj.Write(rom, curPos)
                    curPos = rom.Position
                Next

                rom.Position = &HB371E
                bw.Write(SwapInts.SwapUInt16(mipsTrajects.Length))
            End If
        End Sub

        Private Sub AddTrajectory(rom As Stream, addr As Integer, name As TrajectoryName)
            AddTrajectory(rom, addr, name, 1)
        End Sub
        Private Sub AddTrajectory(rom As Stream, addr As Integer, name As TrajectoryName, count As UInt16)
            If addr > &H80400000 AndAlso addr < &H80410000 Then
                rom.Position = addr - &H80400000 + &H1200000
                For i As Integer = 1 To count
                    Dim trajectory As New Trajectory
                    trajectory.Name = name
                    trajectory.Read(rom, rom.Position)
                    Me.Add(trajectory)
                Next
            End If
        End Sub

        Public Sub ReadTrajectories(rom As Stream)
            Dim br As New BinaryReader(rom)
            Dim addr As Integer

            'Clear list
            Me.Clear()

            'Koopa-The-Quick #1
            rom.Position = &HED864
            addr = SwapInts.SwapInt32(br.ReadInt32)
            AddTrajectory(rom, addr, TrajectoryName.KoopaTheQuick1)

            'Koopa-The-Quick #2
            rom.Position = &HED874
            addr = SwapInts.SwapInt32(br.ReadInt32)
            AddTrajectory(rom, addr, TrajectoryName.KoopaTheQuick2)

            'Racing Penguin
            rom.Position = &HCCA6E
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position = &HCCA76
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.RacingPenguin)

            'Snowman's Bottom
            rom.Position = &HABC9E
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position = &HABCA6
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.SnowmansBottom)

            'Platform on Tracks Behavior (B.Param 2 = 0 - 8)
            For bparam As Byte = 0 To 8
                rom.Position = &HED9DC + bparam * 4
                addr = SwapInts.SwapInt32(br.ReadInt32)
                AddTrajectory(rom, addr, TrajectoryName.PlatformOnTracksBehavior_BParam2_00 + bparam)
            Next

            'Metal Balls Generators - B.Param 2 = 00
            rom.Position = &HA9AB4 + 2
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position = &HA9ABC + 2
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.MetalBallsGenerators_BParam2_00)

            'Metal Balls Generators - B.Param 2 = 01
            rom.Position = &HA9AD4 + 2
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position = &HA9ADC + 2
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.MetalBallsGenerators_BParam2_01)

            'Metal Balls Generators - B.Param 2 = 02
            rom.Position = &HA9AF4 + 2
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position = &HA9AFC + 2
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.MetalBallsGenerators_BParam2_02)

            'Mini-Metal Ball Generator - B.Param 2 = 03
            rom.Position = &HA9B1C + 2
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position += 2
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.MiniMetalBallGenerator_BParam2_03)

            'Mini-Metal Ball Generator - B.Param 2 = 04
            rom.Position = &HA9B1C + 2
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position += 2
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.MiniMetalBallGenerator_BParam2_04)

            'Mips the Rabbit
            rom.Position = &HB3816
            addr = CInt(SwapInts.SwapUInt16(br.ReadUInt16)) << 16
            rom.Position += 6
            addr = addr Or SwapInts.SwapUInt16(br.ReadUInt16)
            rom.Position = &HB371E
            Dim numOfPaths As UInt16 = SwapInts.SwapUInt16(br.ReadUInt16)
            AddTrajectory(rom, addr, TrajectoryName.MipsTheRabbit, numOfPaths)

        End Sub

    End Class

End Namespace
