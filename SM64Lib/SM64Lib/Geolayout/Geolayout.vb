Imports System.IO
Imports SM64Lib.Geolayout.Script, SM64Lib.Geolayout.Script.Commands
Imports SM64Lib.Levels

Namespace Global.SM64Lib.Geolayout

    Public Class Geolayout

        Public Property Geolayoutscript As New Geolayoutscript
        Public Property CameraPreset As CameraPresets = CameraPresets.OpenCamera
        Public Property EnvironmentEffect As EnvironmentEffects = Nothing
        Public Property GeopointerOffsets As New List(Of Integer)
        Public Property Geopointers As New List(Of Geopointer)
        Public Property NewGeoOffset As Integer = 0
        Public Property Closed As Boolean = False
        Private IndexForGeopointers As Integer = -1

        Public ReadOnly Property Length As Integer
            Get
                Dim tLength As Integer = 0
                For Each c In Geolayoutscript
                    tLength += c.Length
                Next
                Return tLength
            End Get
        End Property

        Private Sub RemoveOldGeopointerCommands()
            Dim ToRemove As New List(Of GeolayoutCommand)

            For Each c As GeolayoutCommand In Geolayoutscript
                If c.CommandType = GeolayoutCommandTypes.LoadDisplaylist Then
                    ToRemove.Add(c)
                End If
            Next

            For Each cmd As GeolayoutCommand In ToRemove
                Geolayoutscript.Remove(cmd)
                cmd.Close()
            Next
        End Sub

        Public Sub New(mode As NewScriptCreationMode)
            Select Case mode
                Case NewScriptCreationMode.Level

                    With Geolayoutscript
                        .Add(New GeolayoutCommand({&H8, &H0, &H0, &HA, &H0, &HA0, &H0, &H78, &H0, &HA0, &H0, &H78}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&HC, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H9, &H0, &H0, &H64}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H19, &H0, &H0, &H0, &H80, &H27, &H63, &HD4}))
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&HC, &H1, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&HA, &H1, &H0, &H2D, &H0, &H64, &H75, &H30, &H80, &H29, &HAA, &H3C}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&HF, &H0, &H0, &H1, &H0, &H0, &H7, &HD0, &H17, &H70, &HC, &H0, &H0, &H0, &HEE, &H0, &H80, &H28, &H7D, &H30}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        IndexForGeopointers = 15
                        '.Add(New GeolayoutCommand({&H15, &H1, &H0, &H0, &H0, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H17, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H18, &H0, &H0, &H0, &H80, &H27, &H61, &HD0}))
                        .Add(New GeolayoutCommand({&H18, &H0, &H50, &H0, &H80, &H2D, &H10, &H4C})) 'Water
                        .Add(New GeolayoutCommand({&H18, &H0, &H50, &H1, &H80, &H2D, &H10, &H4C})) 'Toxic Haze
                        .Add(New GeolayoutCommand({&H18, &H0, &H50, &H2, &H80, &H2D, &H10, &H4C})) 'Mist
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&HC, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H4, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H18, &H0, &H0, &H0, &H80, &H2C, &HD1, &HE8}))
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H5, &H0, &H0, &H0}))
                        .Add(New GeolayoutCommand({&H1, &H0, &H0, &H0}))
                    End With

                Case NewScriptCreationMode.Object

                    '...
                    Throw New NotImplementedException

            End Select
        End Sub

        Public Sub Read(rommgr As RomManager, segAddress As Integer)
            If Not Closed Then Close()
            Closed = False

            Geolayoutscript.Clear()
            Geopointers.Clear()
            GeopointerOffsets.Clear()

            Geolayoutscript = New Geolayoutscript
            Geolayoutscript.Read(rommgr, segAddress)

            Dim ToRemove As New List(Of GeolayoutCommand)
            Dim cIndex As Integer = 0
            Dim curMdlScale As Numerics.Vector3 = Numerics.Vector3.One
            Dim curMdlOffset As Numerics.Vector3 = Numerics.Vector3.Zero

            For Each c As GeolayoutCommand In Geolayoutscript
                Select Case c.CommandType
                    Case GeolayoutCommandTypes.CameraPreset
                        CameraPreset = cgCameraPreset.GetCameraPreset(c)

                    Case GeolayoutCommandTypes.x18
                        Select Case cgx18.GetAsmPointer(c)
                            Case &H802761D0 : EnvironmentEffect = cgx18.GetParam1(c)
                        End Select

                    Case GeolayoutCommandTypes.LoadDisplaylist
                        If Geopointers.Count = 0 Then IndexForGeopointers = cIndex
                        Geopointers.Add(New Geopointer(cgLoadDisplayList.GetDrawingLayer(c),
                                                       cgLoadDisplayList.GetSegGeopointer(c),
                                                       curMdlScale,
                                                       curMdlOffset))
                        'ToRemove.Add(c) ' - Geopointers.Count

                End Select
                cIndex += 1
            Next

            'Remove Geopointercommands
            RemoveOldGeopointerCommands()
        End Sub

        Public Sub Write(s As Stream, StartOffset As Integer)
            NewGeoOffset = StartOffset

            Dim commandsToRemove As New List(Of GeolayoutCommand)
            Dim tIndexForGeoPointer As Integer = IndexForGeopointers

            'Einstellungen übernehmen
            Dim currentPosition As Integer = 0
            Dim cIndex As Integer = 0
            For Each c As GeolayoutCommand In Geolayoutscript
                Select Case c.CommandType
                    Case GeolayoutCommandTypes.CameraPreset
                        cgCameraPreset.SetCameraPreset(c, CByte(CameraPreset))

                    Case GeolayoutCommandTypes.x18
                        Select Case cgx18.GetAsmPointer(c)
                            Case GeoAsmPointer.EnvironmentEffect : cgx18.SetParam1(c, EnvironmentEffect)
                        End Select

                End Select
                currentPosition += c.Length
                'If Not IndexForGeopointersFound Then IndexForGeopointers += 1
            Next

            'Insert Geopointers
            For Each g As Geopointer In Geopointers
                Dim tcommand As New GeolayoutCommand({&H15, &H1, &H0, &H0, &H0, &H0, &H0, &H0})
                cgLoadDisplayList.SetDrawingLayer(tcommand, g.Layer)
                cgLoadDisplayList.SetSegGeopointer(tcommand, g.SegPointer)
                Geolayoutscript.Insert(tIndexForGeoPointer, tcommand)
                tIndexForGeoPointer += 1
            Next

            'Write Geolayout to ROM
            Geolayoutscript.Write(s, StartOffset)

            'Remove Geopointercommands again
            RemoveOldGeopointerCommands()
        End Sub

        Public Sub Close()
            For Each c In Geolayoutscript
                c.Close()
            Next
        End Sub

        Public Overrides Function ToString() As String
            Dim output As String = ""
            For Each cmd In Geolayoutscript
                Dim tbytelist As String = ""
                For Each b As Byte In cmd.ToArray
                    If tbytelist IsNot String.Empty Then tbytelist &= " "
                    tbytelist &= Hex(b)
                Next
                If output IsNot String.Empty Then output &= vbNewLine
                output &= tbytelist
            Next
            Return output
        End Function

        Public Overloads Function ToString(Geolayoutscript As GeolayoutCommandCollection) As String
            Dim output As String = ""
            For Each cmd In Geolayoutscript
                Dim tbytelist As String = ""
                For Each b As Byte In cmd.ToArray
                    If tbytelist IsNot String.Empty Then tbytelist &= " "
                    tbytelist &= Hex(b)
                Next
                If output IsNot String.Empty Then output &= vbNewLine
                output &= tbytelist
            Next
            Return output
        End Function

        Public Enum NewScriptCreationMode
            None
            Level
            [Object]
        End Enum

    End Class

End Namespace
