﻿Imports System.IO
Imports SM64Lib.Geolayout.Script, SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Levels

Namespace Geolayout

    Public Class Geopointer

        Public Property Layer As Byte = Nothing
        Public Property SegPointer As Integer = 0
        Public Property ModelScale As Numerics.Vector3 = Numerics.Vector3.One
        Public Property ModelOffset As Numerics.Vector3 = Numerics.Vector3.Zero

        Public Sub New(Layer As Byte)
            Me.Layer = Layer
        End Sub

        Public Sub New(Layer As Byte, SegPointer As Integer)
            Me.New(Layer)
            Me.SegPointer = SegPointer
        End Sub

        Public Sub New(Layer As Byte, SegPointer As Integer, mdlscale As Numerics.Vector3, mdloffset As Numerics.Vector3)
            Me.New(Layer, SegPointer)
            Me.ModelScale = mdlscale
            Me.ModelOffset = mdloffset
        End Sub

    End Class

End Namespace
