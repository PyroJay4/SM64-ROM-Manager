Namespace Model.Fast3D.DisplayLists.Script

    Public Enum CommandTypes
        NOOP = &H0
        Movemem = &H3
        DisplayList = &H6
        EndDisplaylist = &HB8
        Vertex = &H4
        SetOtherMode_H = &HBA
        Triangle1 = &HBF
        ClearGeometryMode = &HB6
        SetGeometryMode = &HB7
        Loadtlut = &HF0
        SetTileSize = &HF2
        SetImage = &HFD
        Loadback = &HF3
        SetTile = &HF5
        Texture = &HBB
    End Enum

End Namespace