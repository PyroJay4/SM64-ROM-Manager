Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands

Namespace Global.SM64Lib.ObjectBanks

    Public Class CustomObject

        Public Property Geolayout As Geolayout.Geolayout = Nothing
        Public Property Model As Model.ObjectModel = Nothing
        Public Property ModelID As Byte = 0

        Private modelOffset As Integer = 0
        Private geolayoutOffset As Integer = 0

        Public Property ModelBankOffset As Integer
            Get
                Return modelOffset
            End Get
            Friend Set
                modelOffset = Value
            End Set
        End Property

        Public Property GeolayoutBankOffset As Integer
            Get
                Return geolayoutOffset
            End Get
            Friend Set
                geolayoutOffset = Value
            End Set
        End Property

        Public Sub New()
            GenerateNewGeolayout()
        End Sub

        Public Sub New(mdl As Model.ObjectModel)
            GenerateNewGeolayout()
            Model = mdl
        End Sub

        Public Sub New(geo As Geolayout.Geolayout)
            Geolayout = geo
        End Sub

        Public Sub New(geo As Geolayout.Geolayout, mdl As Model.ObjectModel)
            Geolayout = geo
            Model = mdl
        End Sub

        Public Sub GenerateNewGeolayout()
            Geolayout = New Geolayout.Geolayout(SM64Lib.Geolayout.Geolayout.NewScriptCreationMode.Object)
        End Sub

    End Class

End Namespace
