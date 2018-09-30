Namespace Global.SM64Lib.Text.Profiles

    Public Class Segmented
        Public Property BankID As Byte
        Public Property BankStartRom As Integer
    End Class

    Public Class Data
        Public Property TableRomOffset As Integer
        Public Property TableRomOffset2 As Integer
        Public Property TableMaxItems As Integer
        Public Property DataRomOffset As Integer
        Public Property DataMaxSize As Integer
    End Class

    Public Class Section
        Public Property Segmented As Segmented
        Public Property Data As Data
    End Class

    Public Class Profile
        Public Property Acts As Section
        Public Property Dialogs As Section
        Public Property Levels As Section
    End Class

End Namespace
