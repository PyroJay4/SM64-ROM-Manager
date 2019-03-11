Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Global.SM64Lib.Levels.Script

    <Serializable>
    Public Enum LevelscriptCommandTypes
        x00 = &H0
        x01 = &H1
        EndOfLevel = &H2
        x03 = &H3
        x04 = &H4
        x05 = &H5
        JumpToSegAddr = &H6
        JumpBack = &H7
        x0A = &HA
        x0C = &HC
        x10 = &H10
        x11 = &H11
        x12 = &H12
        x16 = &H16
        LoadRomToRam = &H17
        x18 = &H18
        x19 = &H19
        x1A = &H1A
        x1B = &H1B
        x1C = &H1C
        x1D = &H1D
        x1E = &H1E
        StartArea = &H1F
        EndOfArea = &H20
        LoadPolygonWithGeo = &H22
        LoadPolygonWithoutGeo = &H21
        Normal3DObject = &H24
        x25 = &H25
        ConnectedWarp = &H26
        PaintingWarp = &H27
        InstantWarp = &H28
        DefaultPosition = &H2B
        AreaCollision = &H2E
        ShowDialog = &H30
        Tarrain = &H31
        x34 = &H34
        AreaMusic = &H36
        AreaMusicSimple = &H37
        Macro3DObject = &H39
        x3B = &H3B
    End Enum

End Namespace
