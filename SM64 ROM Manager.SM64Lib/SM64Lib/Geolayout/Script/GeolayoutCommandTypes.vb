Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Geolayout.Script

    Public Enum GeolayoutCommandTypes
        BranchAndStore = &H0
        EndOfGeolayout = &H1
        JumpToSegAddr = &H2
        JumpBack = &H3
        StartOfNode = &H4
        EndOfNode = &H5
        SetScreenRenderArea = &H8
        Scale1 = &H9
        x0A = &HA
        x0B = &HB
        x0C = &HC
        x0D = &HD
        x0E = &HE
        CameraPreset = &HF
        x10 = &H10
        x11 = &H11
        LoadDisplaylistWithOffset = &H13
        BillboardModel = &H14
        LoadDisplaylist = &H15
        ObjectShadown = &H16
        x17 = &H17
        x18 = &H18
        Background = &H19
        x1A = &H1A
        x1C = &H1C
        Scale2 = &H1D
        x1E = &HE
        x1f = &HF
        DrawingDistance = &H20
    End Enum

End Namespace