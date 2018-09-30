Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.Geolayout
Imports SM64Lib.Levels.Script
Imports SM64Lib.Levels.Script.Commands

Namespace Global.SM64Lib.ObjectBanks

    Public Class CustomObjectBank

        Public ReadOnly Property Objects As New List(Of CustomObject)

        Public Function WriteToSeg(bankID As Byte, offset As Integer)
            Dim segStream As New MemoryStream
            Dim seg As New SegmentedBank(bankID, segStream)
            Dim data As New BinaryStreamData(segStream)
            Dim lvlScriptLength As UInteger
            Dim lvlScript As New Levelscript

            'Calculate space of Levelscript
            lvlScriptLength = HexRoundUp1(Objects.Count * 8 + 4)

            'Start Custom Objects
            data.Position = lvlScriptLength
            For Each obj As CustomObject In Objects
                'Write Object Model
                obj.modelOffset = data.Position
                Dim sr As Model.ObjectModel.SaveResult =
                    obj.Model.ToBinaryData(data, data.Position, 0, seg.BankAddress)
                HexRoundUp2(data.Position)

                'Write Model Offset & Length & Collision Offset
                data.Write(obj.modelOffset)
                data.Write(obj.Model.Length)
                data.Write(sr.CollisionPointer And &HFFFFFF)

                'Copy new Geopointer(s)
                obj.Geolayout.Geopointers.Clear()
                obj.Geolayout.Geopointers.AddRange(sr.GeoPointers.ToArray)

                'Write Geolayout
                obj.geolayoutOffset = data.Position
                obj.Geolayout.Write(data.BaseStream, data.Position)
                data.Position = HexRoundUp1(data.Position + &H30)
            Next

            'Create Levelscript
            data.Position = 0
            For Each obj As CustomObject In Objects
                lvlScript.Add(New LevelscriptCommand($"22 08 00 {obj.ModelID} {bankID.ToString("X")} {Hex((obj.geolayoutOffset >> 16) And &HFF)} {Hex((obj.geolayoutOffset >> 8) And &HFF)} {Hex(obj.geolayoutOffset And &HFF)}"))
            Next
            lvlScript.Add(New LevelscriptCommand("07 04 00 00"))
            lvlScript.Write(data, 0)

            HexRoundUp2(data.Position)
            seg.Length = data.Position

            Return seg
        End Function

        Public Sub ReadFromSeg(rommgr As RomManager, bankID As Byte)
            ReadFromSeg(rommgr, rommgr.GetSegBank(bankID))
        End Sub
        Public Sub ReadFromSeg(rommgr As RomManager, seg As SegmentedBank)
            Dim s As Stream
            Dim data As BinaryData
            Dim lvlscript As New Levelscript

            'Read Levelscript
            lvlscript.Read(Nothing, 0, LevelscriptCommandTypes.JumpBack)

            s = seg.ReadDataIfNull(rommgr)
            data = New BinaryStreamData(s)

            'Parse Levelscript & Load Models
            For Each cmd As LevelscriptCommand In lvlscript
                Select Case cmd.CommandType
                    Case LevelscriptCommandTypes.LoadPolygonWithGeo
                        Dim obj As New CustomObject

                        'Load Model ID & Geolayout Offset
                        obj.ModelID = clLoadPolygonWithGeo.GetModelID(cmd)
                        Dim geoAddr As Integer = clLoadPolygonWithGeo.GetSegAddress(cmd)
                        obj.geolayoutOffset = geoAddr And &HFFFFFF

                        If (geoAddr >> 24) = seg.BankAddress Then
                            'Load Geolayout
                            obj.Geolayout = New Geolayout.Geolayout(Geolayout.Geolayout.NewScriptCreationMode.None)
                            obj.Geolayout.Read(rommgr, geoAddr)

                            'Load Model Offset & Length
                            data.Position = obj.geolayoutOffset - &H10
                            obj.modelOffset = data.ReadInt32
                            Dim f3d_length As Integer = data.ReadInt32
                            Dim colOffset As Integer = data.ReadInt32

                            'Load Model
                            obj.Model = New Model.ObjectModel
                            obj.Model.FromBinaryData(data, 0, seg.BankAddress, obj.modelOffset, f3d_length, obj.Geolayout.Geopointers.ToArray, colOffset Or seg.BankAddress)

                            'Add Object to list
                            Objects.Add(obj)
                        End If

                End Select
            Next
        End Sub

    End Class

    Public Class CustomObject

        Public Property Geolayout As Geolayout.Geolayout = Nothing
        Public Property Model As Model.ObjectModel = Nothing
        Public Property ModelID As Byte = 0

        Friend modelOffset As Integer = 0
        Friend geolayoutOffset As Integer = 0

        Public ReadOnly Property ModelBankOffset As Integer
            Get
                Return modelOffset
            End Get
        End Property
        Public ReadOnly Property GeolayoutBankOffset As Integer
            Get
                Return geolayoutOffset
            End Get
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
