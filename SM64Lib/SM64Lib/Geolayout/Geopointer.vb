Imports System.IO
Imports SM64Lib.Geolayout.Script, SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Levels

Namespace Global.SM64Lib.Geolayout

    Public Class Geopointer

        Public Property Layer As Geolayer = Nothing
        Public Property SegPointer As Integer = 0
        Public Property ModelScale As Numerics.Vector3 = Numerics.Vector3.One
        Public Property ModelOffset As Numerics.Vector3 = Numerics.Vector3.Zero

        Public Sub New(Layer As Geolayer)
            Me.Layer = Layer
        End Sub

        Public Sub New(Layer As Geolayer, SegPointer As Integer)
            Me.Layer = Layer
            Me.SegPointer = SegPointer
        End Sub

        Public Sub New(Layer As Geolayer, SegPointer As Integer, mdlscale As Numerics.Vector3, mdloffset As Numerics.Vector3)
            Me.Layer = Layer
            Me.SegPointer = SegPointer
            Me.ModelScale = mdlscale
            Me.ModelOffset = mdloffset
        End Sub

    End Class

End Namespace
