Imports System.Drawing
Imports System.IO
Imports System.Numerics
Imports SM64Lib.Data

Namespace Global.SM64Lib.Objects

    Public Enum StarNames
        KoopaTheQuick1
        KoopaTheQuick2
        KingBobOmbBoss
        WhompBoss
        EyerockBoss
        BigBullyBoss
        ChillBullyBoss
        GiantPiranhaPlants
        PenguinMother
        WigglerBoss
        PeachSlideStar
        BigPenguinRace
        TreasureChests
        BooInHauntedHouse
        Klepto
        MerryGoRoundboss
        MrIboss
        RooftopBoo
        SecondactBigBully
    End Enum

    Public Class StarPosition

        Public Property Position As Vector3
        Public Property Name As StarNames

        Public Sub New()
            Position = Vector3.Zero
        End Sub
        Public Sub New(name As StarNames)
            Me.New
            Me.Name = name
        End Sub
        Public Sub New(name As StarNames, position As Vector3)
            Me.Position = position
            Me.Name = name
        End Sub

        Public Sub SavePosition(rommgr As RomManager)
            Dim rom As BinaryRom = rommgr.GetBinaryRom(FileAccess.ReadWrite)

            If Not {StarNames.KoopaTheQuick1, StarNames.KoopaTheQuick2}.Contains(Name) Then
                WriteStarWrapperFunction(rom)
            End If

            Select Case Name
                Case StarNames.KoopaTheQuick1
                    WritePositionAsShort(rom, Position, &HED868)

                Case StarNames.KoopaTheQuick2
                    WritePositionAsShort(rom, Position, &HED878)

                Case StarNames.KingBobOmbBoss
                    WritePositionAsSingle(rom, Position, &H1204F00)

                    rom.Position = &H62AD4
                    rom.Write(&H3C048040)   ' LUI A0, &H8040
                    rom.Write(&HC1009C0)    ' JAL &H80402700
                    rom.Write(&H34844F00)   ' ORI A0, A0, &H4F40
                    rom.Write(&H0)
                    rom.Write(&H0)
                    rom.Write(&H0)
                    rom.Write(&H0)
                    rom.Write(&H0)

                Case StarNames.WhompBoss
                    WritePositionAsSingle(rom, Position, &H1204F10)

                    rom.Position = &H82900
                    rom.Write(&H3C018040)
                    rom.Write(&HC42C4F10)
                    rom.Write(&HC42E4F14)
                    rom.Write(&H8C264F18)

                    rom.Position = &H82914
                    rom.Write(&H0)

                Case StarNames.EyerockBoss
                    WritePositionAsSingle(rom, Position, &H1204F20)

                    rom.Position = &HC9A1C  ' 0x8030EA1c
                    rom.Write(&H3C048040)   ' LUI A0, &H8040
                    rom.Write(&HC1009C0)    ' JAL &H80402700
                    rom.Write(&H34844F20)   ' ORI A0, A0, &H4F20
                    rom.Write(&H0)          ' NOPs
                    rom.Write(&H0)
                    rom.Write(&H0)

                Case StarNames.BigBullyBoss
                    WritePositionAsSingle(rom, Position, &H1204F30)

                    rom.Position = &HA6970  ' 0x802EB970
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F30)   ' ORI A0, A0, 0x4F30

                Case StarNames.ChillBullyBoss
                    WritePositionAsSingle(rom, Position, &H1204F40)

                    rom.Position = &HA6950  ' 0x802EB950
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F40)   ' ORI A0, A0, 0x4F40

                Case StarNames.GiantPiranhaPlants
                    WritePositionAsSingle(rom, Position, &H1204F50)

                    rom.Position = &HC802C  ' 0x8030D02C
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F50)   ' ORI A0, A0, 0x4F50

                Case StarNames.PenguinMother
                    WritePositionAsSingle(rom, Position, &H1204F60)

                    rom.Position = &H605E4  ' 0x802a55e4
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F60)

                Case StarNames.WigglerBoss
                    WritePositionAsSingle(rom, Position, &H1204F70)

                    rom.Position = &HBCFE0  ' 80301FE0
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F70)

                Case StarNames.PeachSlideStar
                    WritePositionAsSingle(rom, Position, &H1204F80)

                    rom.Position = &HB7D0   ' 80301FE0
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F80)

                Case StarNames.BigPenguinRace
                    WritePositionAsSingle(rom, Position, &H1204F90)

                    rom.Position = &H605E4  ' 80301FE0
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844F90)

                Case StarNames.TreasureChests
                    WritePositionAsSingle(rom, Position, &H1204FA0)

                    rom.Position = &HB32B0
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FA0)

                Case StarNames.BooInHauntedHouse
                    WritePositionAsSingle(rom, Position, &H1204FAC)

                    rom.Position = &H7FBB0
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FAC)

                Case StarNames.Klepto
                    WritePositionAsSingle(rom, Position, &H1204FC4)

                    rom.Position = &HCC47C
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FC4)

                Case StarNames.MerryGoRoundboss
                    WritePositionAsSingle(rom, Position, &H1204FB8)

                    rom.Position = &H7FC24
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FB8)

                Case StarNames.MrIboss
                    WritePositionAsSingle(rom, Position, &H1204FD0)

                    rom.Position = &H61450
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FD0)

                Case StarNames.RooftopBoo
                    WritePositionAsSingle(rom, Position, &H1204FDC)

                    rom.Position = &H7FBEC
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FDC)

                Case StarNames.SecondactBigBully
                    WritePositionAsSingle(rom, Position, &H1204FE4)

                    rom.Position = &H7FBEC
                    rom.Write(&H3C048040)   ' LUI A0, 0x8040
                    rom.Write(&HC1009C0)    ' JAL 0x80402700
                    rom.Write(&H34844FE4)

            End Select

            rom.Close()
        End Sub

        Private Sub WritePositionAsShort(rom As BinaryRom, position As Vector3, offset As Integer)
            rom.Write(CShort(position.X))
            rom.Write(CShort(position.Y))
            rom.Write(CShort(position.Z))
        End Sub
        Private Sub WritePositionAsSingle(rom As BinaryRom, position As Vector3, offset As Integer)
            rom.Position = offset
            rom.Write(position.X)
            rom.Write(position.Y)
            rom.Write(position.Z)
        End Sub

        Public Shared Sub WriteStarWrapperFunction(rom As BinaryRom)
            Dim StarWrapperFunction() As Byte = {&H27, &HBD, &HFF, &HE8, &HAF, &HBF, &H0, &H14, &HC4, &H8C, &H0, &H0, &HC4, &H8E, &H0, &H4, &HC, &HB, &HCA, &HE2, &H8C, &H86, &H0, &H8, &H8F, &HBF, &H0, &H14, &H27, &HBD, &H0, &H18, &H3, &HE0, &H0, &H8, &H0, &H0, &H0, &H0}

            rom.Position = &H1202700

            For Each b As Byte In StarWrapperFunction
                rom.Write(b)
            Next
        End Sub

    End Class

End Namespace
