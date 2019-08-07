Imports System.ComponentModel
Imports SM64Lib.Levels

Namespace LevelEditor

    Public Class ManagedSpecialBox

        <Browsable(False)>
        Public ReadOnly Property SpecialBox As SpecialBox

        Public Property Type As SpecialBoxType
        Public Property X1 As Int16 = 8192
        Public Property Z1 As Int16 = 8192
        Public Property X2 As Int16 = -8192
        Public Property Z2 As Int16 = -8192
        Public Property Y As Int16 = 0
        Public Property Scale As Int16 = 16
        Public Property InvisibleWater As Boolean = False
        Public Property WaterType As WaterType = WaterType.Default
        Public Property Alpha As Byte = 78

        Public Sub New(sb As SpecialBox)
            SpecialBox = sb
            Load()
        End Sub

        Public Sub Save()
            SpecialBox.Type = Type
            SpecialBox.X1 = X1
            SpecialBox.Z1 = Z1
            SpecialBox.X2 = X2
            SpecialBox.Z2 = Z2
            SpecialBox.Y = Y
            SpecialBox.Scale = Scale
            SpecialBox.InvisibleWater = InvisibleWater
            SpecialBox.WaterType = WaterType
            SpecialBox.Alpha = Alpha
        End Sub

        Public Sub Load()
            Type = SpecialBox.Type
            X1 = SpecialBox.X1
            Z1 = SpecialBox.Z1
            X2 = SpecialBox.X2
            Z2 = SpecialBox.Z2
            Y = SpecialBox.Y
            Scale = SpecialBox.Scale
            InvisibleWater = SpecialBox.InvisibleWater
            WaterType = SpecialBox.WaterType
            Alpha = SpecialBox.Alpha
        End Sub

    End Class

End Namespace
