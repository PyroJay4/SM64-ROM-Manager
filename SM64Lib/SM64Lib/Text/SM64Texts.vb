Imports System.IO
Imports System.Windows.Forms

Namespace Global.SM64Lib.Text
    Public Class Encoding

        Public Shared Function GetString(bytes() As Byte) As String
            Dim txt As String = ""

            For Each b As Byte In bytes
                Select Case b
                    Case &H0 : txt &= "0"
                    Case &H1 : txt &= "1"
                    Case &H2 : txt &= "2"
                    Case &H3 : txt &= "3"
                    Case &H4 : txt &= "4"
                    Case &H5 : txt &= "5"
                    Case &H6 : txt &= "6"
                    Case &H7 : txt &= "7"
                    Case &H8 : txt &= "8"
                    Case &H9 : txt &= "9"

                    Case &HA : txt &= "A"
                    Case &HB : txt &= "B"
                    Case &HC : txt &= "C"
                    Case &HD : txt &= "D"
                    Case &HE : txt &= "E"
                    Case &HF : txt &= "F"
                    Case &H10 : txt &= "G"
                    Case &H11 : txt &= "H"
                    Case &H12 : txt &= "I"
                    Case &H13 : txt &= "J"
                    Case &H14 : txt &= "K"
                    Case &H15 : txt &= "L"
                    Case &H16 : txt &= "M"
                    Case &H17 : txt &= "N"
                    Case &H18 : txt &= "O"
                    Case &H19 : txt &= "P"
                    Case &H1A : txt &= "Q"
                    Case &H1B : txt &= "R"
                    Case &H1C : txt &= "S"
                    Case &H1D : txt &= "T"
                    Case &H1E : txt &= "U"
                    Case &H1F : txt &= "V"
                    Case &H20 : txt &= "W"
                    Case &H21 : txt &= "X"
                    Case &H22 : txt &= "Y"
                    Case &H23 : txt &= "Z"

                    Case &H24 : txt &= "a"
                    Case &H25 : txt &= "b"
                    Case &H26 : txt &= "c"
                    Case &H27 : txt &= "d"
                    Case &H28 : txt &= "e"
                    Case &H29 : txt &= "f"
                    Case &H2A : txt &= "g"
                    Case &H2B : txt &= "h"
                    Case &H2C : txt &= "i"
                    Case &H2D : txt &= "j"
                    Case &H2E : txt &= "k"
                    Case &H2F : txt &= "l"
                    Case &H30 : txt &= "m"
                    Case &H31 : txt &= "n"
                    Case &H32 : txt &= "o"
                    Case &H33 : txt &= "p"
                    Case &H34 : txt &= "q"
                    Case &H35 : txt &= "r"
                    Case &H36 : txt &= "s"
                    Case &H37 : txt &= "t"
                    Case &H38 : txt &= "u"
                    Case &H39 : txt &= "v"
                    Case &H3A : txt &= "w"
                    Case &H3B : txt &= "x"
                    Case &H3C : txt &= "y"
                    Case &H3D : txt &= "z"

                    Case &H3E : txt &= "'"
                    Case &H3F : txt &= "."

                    Case &H50 : txt &= "↑" '[Up]
                    Case &H51 : txt &= "↓" '[Down]
                    Case &H52 : txt &= "←" '[Left]
                    Case &H53 : txt &= "→" '[Right]
                    Case &H54 : txt &= "[A]"
                    Case &H55 : txt &= "[B]"
                    Case &H56 : txt &= "[C]"
                    Case &H57 : txt &= "[Z]"
                    Case &H58 : txt &= "[R]"

                    Case &H6F : txt &= ","
                    Case &HD0 : txt &= "/"

                    Case &HD1 : txt &= "the"
                    Case &HD2 : txt &= "you"

                    Case &H9E : txt &= " "
                    Case &H9F : txt &= "-"

                    Case &HE0 : txt &= "{starsleft}"

                    Case &HE1 : txt &= "("
                    Case &HE2 : txt &= ")("
                    Case &HE3 : txt &= ")"
                    Case &HE4 : txt &= "+"
                    Case &HE5 : txt &= "&"
                    Case &HE6 : txt &= ":"

                    Case &HF2 : txt &= "!"
                    Case &HF4 : txt &= "?"
                    Case &HF5 : txt &= """"
                    Case &HF6 : txt &= """"
                    Case &HF7 : txt &= "~"
                    Case &HF9 : txt &= "$"

                    Case &HFA : txt &= "★" '[star]
                    Case &HFB : txt &= "[x]"
                    Case &HFC : txt &= "•" '[•]
                    Case &HFD : txt &= "☆" '[emptystar]

                    Case &HFE : txt &= vbNewLine
                    Case &HFF : Exit For
                    Case Else : GoTo skip
                End Select
skip:
            Next

            Return txt
        End Function

        Public Shared Function GetBytes(s As String) As Byte()
            Dim isFirst As Boolean = True
            Dim bytes As New List(Of Byte)

            s = Replace(s, "{starsleft}", "€")
            s = Replace(s, "you", "²")
            s = Replace(s, "the", "³")
            s = Replace(s, "[A]", "\")
            s = Replace(s, "[B]", "°")
            s = Replace(s, "[C]", "#")
            s = Replace(s, "[Z]", "*")
            s = Replace(s, "[R]", ";")
            s = Replace(s, ")(", "}")
            s = Replace(s, "[x]", "{")
            s = Replace(s, vbNewLine, "§")

            If s IsNot Nothing Then
                For Each cb As String In s
                    Select Case cb
                        Case "0" : bytes.Add(&H0)
                        Case "1" : bytes.Add(&H1)
                        Case "2" : bytes.Add(&H2)
                        Case "3" : bytes.Add(&H3)
                        Case "4" : bytes.Add(&H4)
                        Case "5" : bytes.Add(&H5)
                        Case "6" : bytes.Add(&H6)
                        Case "7" : bytes.Add(&H7)
                        Case "8" : bytes.Add(&H8)
                        Case "9" : bytes.Add(&H9)

                        Case "A" : bytes.Add(&HA)
                        Case "B" : bytes.Add(&HB)
                        Case "C" : bytes.Add(&HC)
                        Case "D" : bytes.Add(&HD)
                        Case "E" : bytes.Add(&HE)
                        Case "F" : bytes.Add(&HF)
                        Case "G" : bytes.Add(&H10)
                        Case "H" : bytes.Add(&H11)
                        Case "I" : bytes.Add(&H12)
                        Case "J" : bytes.Add(&H13)
                        Case "K" : bytes.Add(&H14)
                        Case "L" : bytes.Add(&H15)
                        Case "M" : bytes.Add(&H16)
                        Case "N" : bytes.Add(&H17)
                        Case "O" : bytes.Add(&H18)
                        Case "P" : bytes.Add(&H19)
                        Case "Q" : bytes.Add(&H1A)
                        Case "R" : bytes.Add(&H1B)
                        Case "S" : bytes.Add(&H1C)
                        Case "T" : bytes.Add(&H1D)
                        Case "U" : bytes.Add(&H1E)
                        Case "V" : bytes.Add(&H1F)
                        Case "W" : bytes.Add(&H20)
                        Case "X" : bytes.Add(&H21)
                        Case "Y" : bytes.Add(&H22)
                        Case "Z" : bytes.Add(&H23)

                        Case "a" : bytes.Add(&H24)
                        Case "b" : bytes.Add(&H25)
                        Case "c" : bytes.Add(&H26)
                        Case "d" : bytes.Add(&H27)
                        Case "e" : bytes.Add(&H28)
                        Case "f" : bytes.Add(&H29)
                        Case "g" : bytes.Add(&H2A)
                        Case "h" : bytes.Add(&H2B)
                        Case "i" : bytes.Add(&H2C)
                        Case "j" : bytes.Add(&H2D)
                        Case "k" : bytes.Add(&H2E)
                        Case "l" : bytes.Add(&H2F)
                        Case "m" : bytes.Add(&H30)
                        Case "n" : bytes.Add(&H31)
                        Case "o" : bytes.Add(&H32)
                        Case "p" : bytes.Add(&H33)
                        Case "q" : bytes.Add(&H34)
                        Case "r" : bytes.Add(&H35)
                        Case "s" : bytes.Add(&H36)
                        Case "t" : bytes.Add(&H37)
                        Case "u" : bytes.Add(&H38)
                        Case "v" : bytes.Add(&H39)
                        Case "w" : bytes.Add(&H3A)
                        Case "x" : bytes.Add(&H3B)
                        Case "y" : bytes.Add(&H3C)
                        Case "z" : bytes.Add(&H3D)

                        Case "'" : bytes.Add(&H3E)
                        Case "." : bytes.Add(&H3F)

                        Case "↑" : bytes.Add(&H50)
                        Case "↓" : bytes.Add(&H51)
                        Case "←" : bytes.Add(&H52)
                        Case "→" : bytes.Add(&H53)
                        Case "\" : bytes.Add(&H54)
                        Case "°" : bytes.Add(&H55)
                        Case "#" : bytes.Add(&H56)
                        Case "*" : bytes.Add(&H57)
                        Case ";" : bytes.Add(&H58)

                        Case "," : bytes.Add(&H6F)
                        Case "/" : bytes.Add(&HD0)

                        Case "³" : bytes.Add(&HD1)
                        Case "²" : bytes.Add(&HD2)

                        Case " " : bytes.Add(&H9E)
                        Case "-" : bytes.Add(&H9F)

                        Case "€" : bytes.Add(&HE0)

                        Case "(" : bytes.Add(&HE1)
                        Case "}" : bytes.Add(&HE2)
                        Case ")" : bytes.Add(&HE3)
                        Case "+" : bytes.Add(&HE4)
                        Case "&" : bytes.Add(&HE5)
                        Case ":" : bytes.Add(&HE6)

                        Case "!" : bytes.Add(&HF2)
                        Case "?" : bytes.Add(&HF4)

                        Case """"
                            Select Case isFirst
                                Case True
                                    bytes.Add(&HF5)
                                    isFirst = False
                                Case False
                                    isFirst = True
                                    bytes.Add(&HF6)
                            End Select

                        Case "~" : bytes.Add(&HF7)
                        Case "$" : bytes.Add(&HF9)

                        Case "★" : bytes.Add(&HFA)
                        Case "{" : bytes.Add(&HFB)
                        Case "•" : bytes.Add(&HFC)
                        Case "☆" : bytes.Add(&HFD)

                        Case "§" : bytes.Add(&HFE)
                    End Select
                Next
            End If

            bytes.Add(&HFF)

            Return bytes.ToArray
        End Function

        Public Shared Function GetByteCount(s As String) As Integer
            Return GetBytes(s).Count
        End Function
    End Class

    Public Class TextTable
        Inherits List(Of TextItem)

        Public Property NeedToSave As Boolean = False
        Public ReadOnly Property Type As TableType = TableType.Dialogs
        Public ReadOnly Property MaxTextDataSize As Integer = 0
        Public ReadOnly Property MaxTextItems As Integer = 0

        Public Sub New(Type As TableType, MaxDataSize As Integer, MaxEntries As Integer)
            Me.Type = Type
            MaxTextDataSize = MaxDataSize
            MaxTextItems = MaxEntries
        End Sub

        Public ReadOnly Property BytesCount As Integer
            Get
                Dim count As Integer = 0
                For Each item As TextItem In Me
                    count += item.DataLenght
                Next
                Return count
            End Get
        End Property

        Public Sub FromStream(s As Stream, BankRamStart As Integer, BankRomStart As Integer, TableRomStart As Integer)
            Dim br As New BinaryReader(s)

            If Type = TableType.Dialogs Then
                s.Position = TableRomStart

                For i As Integer = 1 To MaxTextItems
                    Dim entryPointer As Integer = SwapInts.SwapInt32(br.ReadInt32) - BankRamStart + BankRomStart
                    Dim lastPos As Integer = s.Position
                    s.Position = entryPointer

                    s.Position = entryPointer + 12

                    Dim newItem As TextItem = GetTextItem(s, SwapInts.SwapInt32(br.ReadInt32) - BankRamStart + BankRomStart, True)

                    s.Position = entryPointer + &H3
                    newItem.UnknownValue = br.ReadByte
                    newItem.LinesPerSite = br.ReadByte

                    s.Position += 1
                    newItem.VerticalPosition = SwapInts.SwapInt16(br.ReadInt16)
                    newItem.HorizontalPosition = SwapInts.SwapInt16(br.ReadInt16)

                    s.Position += 6

                    Me.Add(newItem)
                    s.Position = lastPos
                    Application.DoEvents()
                Next

            Else
                s.Position = TableRomStart
                For i As Integer = 1 To MaxTextItems
                    Me.Add(GetTextItem(s, SwapInts.SwapInt32(br.ReadInt32) - BankRamStart + BankRomStart))
                    Application.DoEvents()
                Next

            End If
        End Sub

        Private Function GetTextItem(s As Stream, RomAddress As Integer, Optional EnableDialogParameters As Boolean = False) As TextItem
            Dim br As New BinaryReader(s)
            Dim lastPos As Integer = 0
            Dim tempByte As Byte = 0
            Dim byteBuffer As New List(Of Byte)

            lastPos = s.Position
            s.Position = RomAddress

            Do
                tempByte = br.ReadByte
                byteBuffer.Add(tempByte)
                If tempByte = &HFF Then Exit Do
                Application.DoEvents()
            Loop

            s.Position = lastPos
            Dim newItem As TextItem = New TextItem(byteBuffer.ToArray, EnableDialogParameters)
            byteBuffer.Clear()

            Return newItem
        End Function

        Public Sub ToStream(s As Stream, BankRomStart As Integer, BankRamStart As Integer, ByVal TableRomOffset As Integer, ByVal DataRomOffset As Integer, Optional TableRomOffset2 As Integer = 0)
            Dim bw As New BinaryWriter(s)

            Dim lastTableOffset As Integer = TableRomOffset
            Dim lastTable2Offset As Integer = TableRomOffset2

            If Type = TableType.Dialogs Then
                For Each textitem As TextItem In Me
                    'Table 1
                    s.Position = lastTableOffset
                    bw.Write(SwapInts.SwapInt32(lastTable2Offset - BankRomStart + BankRamStart))
                    lastTableOffset += 4

                    'Table 2 (including Dialog Params)
                    s.Position = lastTable2Offset
                    bw.Write(SwapInts.SwapInt16(0))
                    s.WriteByte(0)
                    s.WriteByte(textitem.UnknownValue)
                    s.WriteByte(textitem.LinesPerSite)
                    s.WriteByte(0)
                    bw.Write(SwapInts.SwapInt16(textitem.VerticalPosition))
                    bw.Write(SwapInts.SwapInt16(textitem.HorizontalPosition))
                    bw.Write(SwapInts.SwapInt16(0))
                    bw.Write(SwapInts.SwapInt32(DataRomOffset - BankRomStart + BankRamStart))
                    lastTable2Offset += &H10

                    'Text Data
                    s.Position = DataRomOffset
                    WriteTextItem(s, DataRomOffset, textitem.ToByteArray)
                    DataRomOffset += textitem.DataLenght

                    Application.DoEvents()
                Next

            Else
                For Each textitem As TextItem In Me
                    'Table
                    s.Position = lastTableOffset
                    bw.Write(SwapInts.SwapInt32(DataRomOffset - BankRomStart + BankRamStart))
                    lastTableOffset += 4

                    'Text Data
                    s.Position = DataRomOffset
                    WriteTextItem(s, DataRomOffset, textitem.ToByteArray)
                    DataRomOffset += textitem.DataLenght

                    Application.DoEvents()
                Next

            End If
        End Sub

        Private Sub WriteTextItem(s As Stream, RomAddress As Integer, Bytes() As Byte)
            s.Position = RomAddress
            For Each b In Bytes
                s.WriteByte(b)
                Application.DoEvents()
            Next
        End Sub

        Public Enum TableType
            Dialogs
            Levels
            Acts
        End Enum
    End Class

    Public Class TextItem
        Private TextBytes() As Byte = {}
        Private DialogParams As Boolean = False
        Public ReadOnly Property DialogParametersEnabled As Boolean
            Get
                Return DialogParams
            End Get
        End Property
        Private Lines As Integer = 4
        Public Property LinesPerSite As Integer
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return Lines
            End Get
            Set(value As Integer)
                If Not DialogParams Then Throw New NotADialogItem
                Lines = value
            End Set
        End Property
        Private VPosition As Int16 = 0
        Public Property VerticalPosition As VPos
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return VPosition
            End Get
            Set(value As VPos)
                If Not DialogParams Then Throw New NotADialogItem
                VPosition = value
            End Set
        End Property
        Private HPosition As Int16 = 0
        Public Property HorizontalPosition As HPos
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return HPosition
            End Get
            Set(value As HPos)
                If Not DialogParams Then Throw New NotADialogItem
                HPosition = value
            End Set
        End Property
        Private _UnknownValue As Byte = 0
        Public Property UnknownValue As Byte
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return _UnknownValue
            End Get
            Set(value As Byte)
                If Not DialogParams Then Throw New NotADialogItem
                _UnknownValue = value
            End Set
        End Property

        Public Sub New(TextBytes As Byte(), Optional EnableDialogParameters As Boolean = False)
            Me.TextBytes = TextBytes
            DialogParams = EnableDialogParameters
        End Sub

        Public Sub New(Text As String, Optional EnableDialogParameters As Boolean = False)
            Me.Text = Text
            DialogParams = EnableDialogParameters
        End Sub

        Public Property Text As String
            Get
                Return Encoding.GetString(TextBytes)
            End Get
            Set(value As String)
                TextBytes = Encoding.GetBytes(value)
            End Set
        End Property

        Public Function ToByteArray() As Byte()
            Return TextBytes
        End Function

        Public ReadOnly Property DataLenght As Integer
            Get
                Return TextBytes.Count
            End Get
        End Property

        Public Class NotADialogItem
            Inherits Exception
            Public Sub New()
                MyBase.New("This Text Item is not a dialog item. Some parameter are not aviable.")
            End Sub
        End Class

        Public Enum VPos As Int16
            Left = &H1E
            Centred = &H5F
            Right = &H96
        End Enum
        Public Enum HPos As Int16
            Middle = &H96
            Top = &HC8
        End Enum
    End Class

    Public Class TextSettings
        Public Const defaultDialogsTabelStart As UInteger = &H81311E
        Public Const defaultDialogsTabelItems As UInteger = 170
        Public Const defaultDialogsMaxDataLen As UInteger = 33428 '32997
        Public Const defaultLevelNamesTabelStart As UInteger = &H8140BE
        Public Const defaultLevelNamesTabelItems As UInteger = 26
        Public Const defaultLevelNamesMaxDataLen As UInteger = 595 '536
        Public Const defaultActNamesTabelStart As UInteger = &H814A82
        Public Const defaultActNamesTabelItems As UInteger = 97
        Public Const defaultActNamesMaxDataLen As UInteger = 2389 '2138
    End Class
End Namespace
