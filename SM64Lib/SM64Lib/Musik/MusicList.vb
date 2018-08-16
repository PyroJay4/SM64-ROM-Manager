Imports System.IO

Namespace Global.SM64Lib.Music

    Public Class MusicList
        Inherits List(Of MusicSequence)

        Public Property EnableMusicHack As Boolean = False

        Public Property NeedToSaveNInsts As Boolean = False
        Public Property NeedToSaveSequenceNames As Boolean = False
        Public Property NeedToSaveSequences As Boolean = False
        Public Property NeedToSaveMusicHackSettings As Boolean = False

        Public Const addrMusicStart As Integer = &H1210000

        Public ReadOnly Property NeedToSave As Boolean
            Get
                Return NeedToSaveNInsts OrElse
                    NeedToSaveMusicHackSettings OrElse
                    NeedToSaveSequenceNames OrElse
                    NeedToSaveSequences
            End Get
        End Property

        Public Sub Read(Romfile As String)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.Read)
            Read(fs)
            fs.Close()
        End Sub
        Public Sub Read(s As Stream)
            Dim br As New BinaryReader(s)

            s.Position = &H1210002
            Dim musicCount As Int16 = SwapInts.SwapInt16(br.ReadInt16)

            'Read NInsts
            Dim tNInstList() As InstrumentSetList = ReadNInsts(s, &H7F0000, musicCount)

            'Read Sequence Names
            Dim tNames() As String = ReadSequenceNames(s, &H7F1000, musicCount)

            'Read Sequences
            Me.AddRange(ReadSequences(s, addrMusicStart, musicCount, tNInstList, tNames))

            'Check for Music Hack
            Dim needUpdateChecksum As Boolean = False
            s.Position = &HD213A
            Dim t001 = SwapInts.SwapUInt16(br.ReadUInt16)
            s.Position = &HD213E
            Dim t002 = SwapInts.SwapUInt16(br.ReadUInt16)
            EnableMusicHack = t001 = &H807C And t002 = &H0
        End Sub

        Private Shared Function ReadNInsts(s As Stream, TableStart As Integer, Count As Int16) As InstrumentSetList()
            Dim br As New BinaryReader(s)

            Dim tNInstList As New List(Of InstrumentSetList)
            s.Position = TableStart
            For i As Integer = 0 To Count - 1
                Dim startoff As UShort = SwapInts.SwapUInt16(br.ReadUInt16())

                Dim n As New InstrumentSetList
                tNInstList.Add(n)

                Dim offBefore As Integer = s.Position
                n.ReadNInst(s, TableStart + startoff)
                s.Position = offBefore
            Next

            Return tNInstList.ToArray
        End Function
        Private Shared Function ReadSequenceNames(s As Stream, RomAddress As Integer, Count As Integer) As String()
            Dim br As New BinaryReader(s)

            s.Position = RomAddress
            Dim tNames As New List(Of String)
            For i As Integer = 0 To Count - 1
                If br.ReadByte() = &HFF Then
                    s.Position -= 1
                Else
                    s.Position -= 1
                    tNames.Add(br.ReadString)
                End If
            Next

            Return tNames.ToArray
        End Function
        Private Shared Function ReadSequences(s As Stream, TableStart As Integer, Count As Integer, tNInstList As InstrumentSetList(), tNames As String()) As MusicSequence()
            Dim br As New BinaryReader(s)

            s.Position = TableStart + 4
            Dim tSequences As New List(Of MusicSequence)
            For i As Integer = 0 To Count - 1
                Dim startoff As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)
                Dim len As UInteger = SwapInts.SwapUInt32(br.ReadUInt32)

                Dim ms As New MusicSequence
                tSequences.Add(ms)

                If tNames.Length > i Then ms.Name = tNames(i)
                If tNInstList.Length > i Then ms.InstrumentSets = tNInstList(i)

                Dim offBefore As Integer = s.Position
                ms.ReadData(s, TableStart + startoff, len)
                s.Position = offBefore
            Next

            Return tSequences.ToArray
        End Function

        Public Shared Sub Prepaire(Romfile As String)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.ReadWrite)
            Prepaire(fs)
            fs.Close()
        End Sub
        Public Shared Sub Prepaire(s As Stream)
            Dim bw As New BinaryWriter(s)
            Dim br As New BinaryReader(s)

            s.Position = &H7B0863
            Dim musicCount As Byte = br.ReadByte

            'Set original Names
            Dim tNames As String() = {
            "No Music",
            "High Score",
            "Title Screen",
            "Bob-omb's Battlefield",
            "Inside Castle",
            "Dire, Dire Docks",
            "Lethal Lava Land",
            "Bowser Battle",
            "Snow",
            "Slide",
            "Haunted House",
            "Piranha Plant Lullaby",
            "Hazy Maze Cave",
            "Star Select",
            "Wing Cap",
            "Metal Cap",
            "Bowser Message",
            "Bowser Course",
            "Star Catch",
            "Ghost Merry-Go-Round",
            "Start and End Race with Koopa the Quick",
            "Star Appears",
            "Boss Fight",
            "Take a Key",
            "Endless Stairs",
            "Final Boss",
            "Staff Credits",
            "Puzzle Solved",
            "Toad Message",
            "Peach Message",
            "Introduction Scene",
            "Last Star Fanfare",
            "Ending Scene",
            "File Select",
            "Lakitu Appears"}

            'Read original sequences
            Dim tSequences As MusicSequence() = ReadSequences(s, &H7B0860, musicCount, {}, tNames)

            s.Position = &HDC0B8
            bw.Write(SwapInts.SwapUInt32(0))

            'Write sequences to the new Position
            WriteSequences(s, addrMusicStart, tSequences, True)

            'Write new sequence names
            WriteSequenceNames(s, &H7F1000, tSequences)

            'Write NInsts
            WriteNInst(s, &H7F0000, tSequences)

            'Edit ASM-Code to load from the new location
            s.Position = &H7B085F
            bw.Write(17)
            s.Position = &HD4714
            bw.Write(SwapInts.SwapUInt32(&H3C040121))
            s.Position = &HD471C
            bw.Write(SwapInts.SwapUInt32(&H24840000))
            s.Position = &HD4768
            bw.Write(SwapInts.SwapUInt32(&H3C040121))
            s.Position = &HD4770
            bw.Write(SwapInts.SwapUInt32(&H24840000))
            s.Position = &HD4784
            bw.Write(SwapInts.SwapUInt32(&H3C050121))
            s.Position = &HD4788
            bw.Write(SwapInts.SwapUInt32(&H24A50000))
            s.Position = &HD48B4
            bw.Write(SwapInts.SwapUInt32(&H3C02807C))
            s.Position = &HD48B8
            bw.Write(SwapInts.SwapUInt32(&H34420000))

            'Edit ASM-Code to load from new location
            s.Position = &HD48C6
            bw.Write(SwapInts.SwapInt16(&H7F))
            s.Position = &HD48CC
            bw.Write(SwapInts.SwapUInt32(&H34840000))
            s.Position = &HD48DA
            bw.Write(SwapInts.SwapInt16(&H200))

            'Check for Music Hack
            s.Position = &HD213A
            Dim t001 = SwapInts.SwapUInt16(br.ReadUInt16)
            s.Position = &HD213E
            Dim t002 = SwapInts.SwapUInt16(br.ReadUInt16)

            If t001 = &H805D And t002 = &HC000 Then
                s.Position = &HD213A
                bw.Write(SwapInts.SwapUInt16(&H807C))
                s.Position = &HD213E
                bw.Write(SwapInts.SwapUInt16(&H0))
                s.Position = &HD215A
                bw.Write(SwapInts.SwapUInt16(&H807C))
                s.Position = &HD215E
                bw.Write(SwapInts.SwapUInt16(&H0))
                s.Position = &HD459A
                bw.Write(SwapInts.SwapUInt16(&H807C))
                s.Position = &HD459E
                bw.Write(SwapInts.SwapUInt16(&H0))
                s.Position = &HEE2B0
                bw.Write(SwapInts.SwapUInt32(&HBD00))
            End If

        End Sub

        Public Sub Write(Romfile As String, ByRef lastPosition As Integer)
            Dim fs As New FileStream(Romfile, FileMode.Open, FileAccess.ReadWrite)
            Write(fs, lastPosition)
            fs.Close()
        End Sub
        Public Sub Write(s As Stream, ByRef lastPosition As Integer)
            Dim bw As New BinaryWriter(s)

            'Enable/Disable Music Hack
            If NeedToSaveMusicHackSettings Then
                s.Position = &HD213A
                bw.Write(SwapInts.SwapUInt16(If(EnableMusicHack, &H807C, &H801D)))
                s.Position = &HD213E
                bw.Write(SwapInts.SwapUInt16(If(EnableMusicHack, &H0, &HE000)))
                s.Position = &HD215A
                bw.Write(SwapInts.SwapUInt16(If(EnableMusicHack, &H807C, &H801D)))
                s.Position = &HD215E
                bw.Write(SwapInts.SwapUInt16(If(EnableMusicHack, &H0, &HE000)))
                s.Position = &HD459A
                bw.Write(SwapInts.SwapUInt16(If(EnableMusicHack, &H807C, &H801D)))
                s.Position = &HD459E
                bw.Write(SwapInts.SwapUInt16(If(EnableMusicHack, &H0, &HE000)))
                s.Position = &HEE2B0
                bw.Write(SwapInts.SwapUInt32(If(EnableMusicHack, &HBD00, &H6D00)))
                s.Position = &HD48B4
                bw.Write(SwapInts.SwapUInt32(If(EnableMusicHack, &H3C02803D, &H3C02807C)))
                s.Position = &HD48B8
                bw.Write(SwapInts.SwapUInt32(If(EnableMusicHack, &H34420000, &H34420000)))
            End If

            Dim arrMe() As MusicSequence = Me.ToArray

            'Write Music Names
            If NeedToSaveSequenceNames Then
                WriteSequenceNames(s, &H7F1000, arrMe)
            End If

            'Write NInsts
            If NeedToSaveNInsts Then
                WriteNInst(s, &H7F0000, arrMe)
            End If

            'Write Music Sequences
            lastPosition = WriteSequences(s, addrMusicStart, arrMe, NeedToSaveSequences)

            'Reset NeedToSave Properties
            NeedToSaveSequences = False
            NeedToSaveNInsts = False
            NeedToSaveSequenceNames = False
            NeedToSaveMusicHackSettings = False
        End Sub

        Private Shared Sub WriteSequenceNames(s As Stream, TableStart As Integer, sequences As MusicSequence())
            Dim bw As New BinaryWriter(s)

            s.Position = TableStart
            For Each ms As MusicSequence In sequences
                bw.Write(ms.Name)
            Next
        End Sub

        Private Shared Sub WriteNInst(s As Stream, TableStart As Integer, sequences As MusicSequence())
            Dim bw As New BinaryWriter(s)

            s.Position = TableStart
            Dim lastNInstDataOffset As Integer = TableStart + sequences.Length * 2

            For Each ms As MusicSequence In sequences
                bw.Write(SwapInts.SwapUInt16(lastNInstDataOffset - TableStart))

                Dim lastOff As Integer = s.Position
                ms.InstrumentSets.WriteNInst(s, lastNInstDataOffset)
                lastNInstDataOffset += ms.InstrumentSets.NInstLength
                s.Position = lastOff
            Next
        End Sub

        Private Shared Function WriteSequences(s As Stream, TableStart As Integer, sequences As MusicSequence(), WriteData As Boolean) As Integer
            Dim bw As New BinaryWriter(s)

            s.Position = TableStart
            bw.Write(SwapInts.SwapInt16(3))
            bw.Write(SwapInts.SwapInt16(sequences.Length))

            'Write sequences to the new Position
            Dim curMsDataOff As Integer = HexRoundUp1(TableStart + 4 + sequences.Length * &H8)
            For Each ms As MusicSequence In sequences
                If WriteData Then
                    bw.Write(SwapInts.SwapUInt32(curMsDataOff - TableStart))
                    bw.Write(SwapInts.SwapUInt32(ms.Lenght))

                    Dim lastOff As Integer = s.Position
                    ms.WriteData(s, curMsDataOff)
                    s.Position = lastOff
                End If

                curMsDataOff += HexRoundUp1(ms.Lenght)
            Next

            Return curMsDataOff
        End Function

    End Class

End Namespace
