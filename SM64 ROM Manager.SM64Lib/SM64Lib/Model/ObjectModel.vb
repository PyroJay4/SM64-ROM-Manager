Imports System.IO
Imports SM64_ROM_Manager.SM64Lib.Data
Imports SM64_ROM_Manager.SM64Lib.Geolayout

Namespace Model

    Public Class ObjectModel

        'Public DisplayLists As New DisplayListCollection
        Public Property Collision As Collision.CollisionMap = Nothing
        Public Property Fast3DBuffer As Fast3D.Fast3DBuffer = Nothing

        Public Sub FromROM(Romfile As String, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer, Optional Collisionpointer As Integer = -1)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.Read)
            FromStream(fs, BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer, Collisionpointer)
            fs.Close()
        End Sub
        Public Sub FromBinaryData(data As BinaryData, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer, Optional Collisionpointer As Integer = -1)
            'Load Collision
            If Collisionpointer > -1 Then
                Collision = New Collision.CollisionMap
                Dim cRomStart As Integer = Collisionpointer - BankRamStart + BankRomStart
                Collision.FromBinaryData(data, cRomStart)
            Else
                Collision = Nothing
            End If

            'Read Fast3D Buffer
            If Fast3DBuffer IsNot Nothing Then Fast3DBuffer.Close()
            Fast3DBuffer = New Fast3D.Fast3DBuffer
            Fast3DBuffer.FromBinaryData(data, BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer)
        End Sub
        Public Sub FromStream(ByRef s As Stream, BankRomStart As Integer, BankRamStart As Integer, Fast3DStart As Integer, Fast3DLength As Integer, DisplayListpointer() As Geopointer, Optional Collisionpointer As Integer = -1)
            FromBinaryData(New BinaryStreamData(s), BankRomStart, BankRamStart, Fast3DStart, Fast3DLength, DisplayListpointer, Collisionpointer)
        End Sub
        Public Sub FromModel(ObjSettings As ObjectInputSettings, vmap As Pilz.S3DFileParser.Object3D, colmap As Pilz.S3DFileParser.Object3D, texFormatSettings As Fast3D.TextureFormatSettings, Optional colSettings As Collision.CollisionSettings = Nothing)
            'Add Collision
            Collision = New Collision.CollisionMap
            Me.Collision.FromObject3D(ObjSettings, colmap, colSettings)

            'Add Fast3DBuffer (replacement for 'Add Displaylists')
            If Fast3DBuffer IsNot Nothing Then Fast3DBuffer.Close()
            Fast3DBuffer = New Fast3D.Fast3DBuffer
            Fast3DBuffer.FromModel(ObjSettings, vmap, texFormatSettings)
        End Sub

        Public Function FromModelAsync(ObjSettings As ObjectInputSettings, vmap As Pilz.S3DFileParser.Object3D, colmap As Pilz.S3DFileParser.Object3D, Optional texFormatSettings As Fast3D.TextureFormatSettings = Nothing, Optional colSettings As Collision.CollisionSettings = Nothing) As Task
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
        Public Function ToStream(s As Stream, RomPos As Integer, BankRomStart As Integer, BankRamStart As Integer) As SaveResult
            Return ToBinaryData(New BinaryStreamData(s), RomPos, BankRomStart, BankRamStart)
        End Function
        Public Function ToBinaryData(data As BinaryData, dataPos As Integer, BankRomStart As Integer, BankRamStart As Integer) As SaveResult
            Dim tresult As New SaveResult

            data.Position = dataPos

            'Write Fast3D
            If Fast3DBuffer IsNot Nothing Then
                Fast3DBuffer.ToBinaryData(data, data.Position, BankRomStart, BankRamStart)
                tresult.GeoPointers.AddRange(Fast3DBuffer.DLPointers)
                tresult.Length += Fast3DBuffer.Length
            Else
                tresult.GeoPointers.Clear()
            End If

            'Write Collision
            If Collision IsNot Nothing Then
                Dim colStart As Integer = HexRoundUp1(data.Position)
                tresult.CollisionPointer = colStart - BankRomStart + BankRamStart
                Collision.ToBinaryData(data, colStart)
                Collision.Length = data.Position - colStart
                tresult.Length += Collision.Length
            Else
                tresult.CollisionPointer = -1
            End If

            Return tresult
        End Function

        Public ReadOnly Property Length As Integer
            Get
                Return _
                    If(Fast3DBuffer IsNot Nothing, HexRoundUp1(Fast3DBuffer.Length), 0) +
                    If(Collision IsNot Nothing, HexRoundUp1(Collision.Length), 0)
            End Get
        End Property

        Public Class SaveResult
            Public Property CollisionPointer As Integer = -1
            Public Property GeoPointers As New List(Of Geopointer)
            Public Property Length As Long = 0
        End Class
    End Class

End Namespace
