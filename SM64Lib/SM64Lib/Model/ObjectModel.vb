﻿Imports System.IO
Imports S3DFileParser
Imports SM64Lib.Geolayout

Namespace Global.SM64Lib.Model

    Public Class ObjectModel

        'Public DisplayLists As New DisplayListCollection
        Public Property Collision As Collision.CollisionMap = Nothing
        Public Property Fast3DBuffer As Fast3D.Fast3DBuffer = Nothing

        Public Sub FromROM(Romfile As String, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer, Optional Collisionpointer As Integer = -1)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.Read)
            FromStream(fs, BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer, Collisionpointer)
            fs.Close()
        End Sub
        Public Sub FromStream(ByRef s As Stream, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer, Optional Collisionpointer As Integer = -1)
            'Load Collision
            If Collisionpointer > -1 Then
                Collision = New Collision.CollisionMap
                Dim cRomStart As Integer = Collisionpointer - BankRamStart + BankRomStart
                Collision.FromStream(s, cRomStart)
            Else
                Collision = Nothing
            End If

            'Read Fast3D Buffer
            If Fast3DBuffer IsNot Nothing Then Fast3DBuffer.Close()
            Fast3DBuffer = New Fast3D.Fast3DBuffer
            Fast3DBuffer.FromStream(s, BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer)
        End Sub
        Public Sub FromModel(ObjSettings As ObjInputSettings, vmap As S3DFileParser.Object3D, colmap As S3DFileParser.Object3D, texFormatSettings As Fast3D.TextureFormatSettings, Optional colSettings As Collision.CollisionSettings = Nothing)
            'Add Collision
            Collision = New Collision.CollisionMap
            Me.Collision.FromObject3D(ObjSettings, colmap, colSettings)

            'Add Fast3DBuffer (replacement for 'Add Displaylists')
            If Fast3DBuffer IsNot Nothing Then Fast3DBuffer.Close()
            Fast3DBuffer = New Fast3D.Fast3DBuffer
            Me.Fast3DBuffer.FromModel(ObjSettings, vmap, texFormatSettings)
        End Sub

        Public Function FromModelAsync(ObjSettings As ObjInputSettings, vmap As S3DFileParser.Object3D, colmap As S3DFileParser.Object3D, Optional texFormatSettings As Fast3D.TextureFormatSettings = Nothing, Optional colSettings As Collision.CollisionSettings = Nothing) As Task
            Dim t As New Task(Sub() FromModel(ObjSettings, vmap, colmap, texFormatSettings, colSettings))
            t.Start()
            Return t
        End Function

        Public Function ToRom(Romfile As String, RomPos As Integer, BankRomStart As Integer, BankRamStart As Integer) As SaveResult
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.ReadWrite)
            Dim treturn = ToStream(fs, RomPos, BankRomStart, BankRamStart)
            fs.Close()
            Return treturn
        End Function
        Public Function ToStream(ByRef s As Stream, RomPos As Integer, BankRomStart As Integer, BankRamStart As Integer) As SaveResult
            Dim tresult As New SaveResult

            Dim bw As New BinaryWriter(s)
            s.Position = RomPos

            'Write Fast3D
            If Fast3DBuffer IsNot Nothing Then
                Fast3DBuffer.ToStream(s, s.Position, BankRomStart, BankRamStart)
                tresult.GeoPointers.AddRange(Fast3DBuffer.DLPointers)
                tresult.Length += Fast3DBuffer.Length
            Else
                tresult.GeoPointers.Clear()
            End If

            'Write Collision
            If Collision IsNot Nothing Then
                Dim colStart As Integer = HexRoundUp1(s.Position)
                tresult.CollisionPointer = colStart - BankRomStart + BankRamStart
                Collision.ToStream(s, colStart)
                Collision.Length = s.Position - colStart
                tresult.Length += Collision.Length
            Else
                tresult.CollisionPointer = -1
            End If

            Return tresult
        End Function

        Public ReadOnly Property Length
            Get
                Length = &H10 'Shading

                Length += Collision.Length
                'For Each dl In DisplayLists
                '    Length += dl.Length
                'Next
                'For Each t In DisplayLists.Textures
                '    Length += t.ImageBuffer.Count
                'Next
                Length += Fast3DBuffer.Length

                Return Length
            End Get
        End Property

        Public Class SaveResult
            Public Property CollisionPointer As Integer = 0
            Public Property GeoPointers As New List(Of Geopointer)
            Public Property Length As Long = 0
        End Class
    End Class

    Public Class Fog
        Public Property Color As Drawing.Color = Drawing.Color.White
        Public Property Type As New FogPreset
    End Class
    Public Enum FogPreset
        SubtleFog1 = 0
        SubtleFog2
        ModerateFog1
        ModerateFog2
        ModerateFog3
        ModerateFog4
        IntenseFog
        VeryIntenseFog
        HardcoreFog
    End Enum
End Namespace