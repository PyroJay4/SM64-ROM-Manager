Imports System.IO
Imports SM64Lib.Geolayout
Imports SM64Lib.Level.Script
Imports SM64Lib.Level.Script.Commands

Namespace Global.SM64Lib.ObjectBanks

    Public Class CustomObjectBank

        Public ReadOnly Property Objects As New List(Of CustomObject)

        Public Function WriteToSeg(bankID As Byte)
            Dim s As New MemoryStream
            Dim bw As New BinaryWriter(s)
            Dim seg As New SegmentedBank(bankID, s)
            Dim lvlScriptLength As UInteger
            Dim lvlScript As New Levelscript

            'Calculate space of Levelscript
            lvlScriptLength = HexRoundUp1(Objects.Count * 8 + 4)

            'Start Custom Objects
            s.Position = lvlScriptLength
            For Each obj As CustomObject In Objects
                'Write Object Model
                obj.modelOffset = s.Position
                Dim sr As Model.ObjectModel.SaveResult =
                    obj.Model.ToStream(s, s.Position, 0, seg.BankAddress)
                HexRoundUp2(s.Position)

                'Write Model Offset & Length & Collision Offset
                bw.Write(SwapInts.SwapInt32(obj.modelOffset))
                bw.Write(SwapInts.SwapInt32(obj.Model.Length))
                bw.Write(SwapInts.SwapInt32(sr.CollisionPointer And &HFFFFFF))

                'Copy new Geopointer(s)
                obj.Geolayout.Geopointers.Clear()
                obj.Geolayout.Geopointers.AddRange(sr.GeoPointers.ToArray)

                'Write Geolayout
                obj.geolayoutOffset = s.Position
                obj.Geolayout.Write(s, s.Position)
                s.Position = HexRoundUp1(s.Position + &H30)
            Next

            'Create Levelscript
            s.Position = 0
            For Each obj As CustomObject In Objects
                lvlScript.Add(New LevelscriptCommand($"22 08 00 {obj.ModelID} {bankID.ToString("X")} {Hex((obj.geolayoutOffset >> 16) And &HFF)} {Hex((obj.geolayoutOffset >> 8) And &HFF)} {Hex(obj.geolayoutOffset And &HFF)}"))
            Next
            lvlScript.Add(New LevelscriptCommand("07 04 00 00"))
            lvlScript.Write(s, 0)

            HexRoundUp2(s.Position)
            seg.Length = s.Position

            Return seg
        End Function

        Public Sub ReadFromSeg(rommgr As RomManager, bankID As Byte)
            ReadFromSeg(rommgr, rommgr.GetSegBank(bankID))
        End Sub
        Public Sub ReadFromSeg(rommgr As RomManager, seg As SegmentedBank)
            Dim s As Stream
            Dim br As BinaryReader
            Dim lvlscript As New Levelscript

            'Read Levelscript
            lvlscript.Read(Nothing, 0, LevelscriptCommandTypes.JumpBack)

            s = seg.Data
            br = New BinaryReader(s)

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
                            s.Position = obj.geolayoutOffset - &H10
                            obj.modelOffset = SwapInts.SwapInt32(br.ReadInt32)
                            Dim f3d_length As Integer = SwapInts.SwapInt32(br.ReadInt32)
                            Dim colOffset As Integer = SwapInts.SwapInt32(br.ReadInt32)

                            'Load Model
                            obj.Model = New Model.ObjectModel
                            obj.Model.FromStream(s, 0, seg.BankAddress, obj.modelOffset, f3d_length, obj.Geolayout.Geopointers.ToArray, colOffset Or seg.BankAddress)

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
