Namespace Global.SM64Lib.Levels

    Public Enum ObjectBank0x0C
        Disabled = 0
        HauntedObjects
        SnowObjects
        AssortedEnemies1
        DesertObjects
        BigBobOmbBoss
        AssortedEnemies2
        WaterObjects
        AssortedEnemies3
        PeachYoshi
        Switches
        LavaObjects
    End Enum
    Public Enum ObjectBank0x0D
        Disabled = 0
        AssortedEnemies4
        Moneybags
        CastleObjects
        GroundEnemies
        WaterObjects2
        Bowser
    End Enum
    Public Enum ObjectBank0x0E
        Disabled = 0
        HaundetHouse
        CoolCoolMountain
        InsideCastle
        HazyMazeCave
        ShiftingSandLand
        BobOmbBattlefield
        SnowandsLand
        WetDryWorld
        JollyRogerBay
        TinyHugeIsland
        TickTockClock
        RainbowRide
        CastleGrounds
        Bowser1Course
        VanishCap
        Bowser2Course
        Bowser3Course
        LethalLavaLand
        DireDireDocks
        WhompsFortress
        CastleCourtyard
        WingCap
        Bowser2Battle
        Bowser3Battle
        TallTallMountain
    End Enum

    Public Enum ObjectBanks
        Bank0x0C = 0
        Bank0x0D
        Bank0x0E
    End Enum

    Public Enum Levels As Byte
        HaundetHouse = &H4
        CoolCoolMountain
        InsideCastle
        HazyMazeCave
        ShiftingSandLand
        BobOmbsBattlefield
        SnowManLand
        WetDryWorld
        JollyRogerBay
        TinyHugeIsland
        TickTockClock
        RainbowRide
        CastleGrounds
        Bowser1Course
        VanishCap
        Bowser2Course
        SecretAquarium
        Bowser3Course
        LethalLavaLand
        DireDireDocks
        WhompsFortress
        EndCakePicture
        CastleCourtyard
        PeachsSecretSlide
        MetalCap
        WingCap
        Bowser1Battle
        RainbowClouds
        Bowser2Battle = &H21
        Bowser3Battle
        TallTallMountain = &H24
    End Enum
    Public Enum ScrollingTextureAxis
        X = 0
        Y
    End Enum
    Public Enum SpecialBoxType
        Water = 0
        ToxicHaze
        Mist
    End Enum
    Public Enum WaterType
        [Default] = &H0
        JRBWater = &H20000
        GreenWater = &H30000
        LavaWater = &H40000
    End Enum

End Namespace
