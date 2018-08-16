Imports System.IO
Imports System.Numerics
Imports SM64Lib.Script

Namespace Global.SM64Lib.Geolayout.Script

    'Public Class GeolayoutCommand
    '    Inherits MemoryStream
    '    Implements ICommand

    '    Public Property CommandType As GeolayoutCommandTypes = Nothing

    '    Public Property Address As Integer = 0 Implements ICommand.Address

    '    Public Sub New(bytes() As Byte)
    '        CommandType = bytes(0)

    '        Me.SetLength(bytes.Count)
    '        For Each b As Byte In bytes
    '            Me.WriteByte(b)
    '        Next
    '        Me.Position = 0
    '    End Sub

    '    Public Overrides Function ToString() As String
    '        ToString = $"{Address.ToString("X")}:"
    '        For Each b As Byte In Me.ToArray
    '            ToString &= " " & b.ToString("X2")
    '        Next
    '    End Function
    'End Class

    Public Class GeolayoutCommand
        Inherits BaseCommand(Of GeolayoutCommandTypes)

        Public Sub New(bytes() As Byte)
            MyBase.New(bytes)
        End Sub
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(bytes As String, Optional enabledHex As Boolean = True)
            MyBase.New(bytes, enabledHex)
        End Sub

        Public Overrides Property CommandType As GeolayoutCommandTypes
            Get
                Position = 0
                Dim t As GeolayoutCommandTypes = ReadByte()
                Position = 0
                Return t
            End Get
            Set(value As GeolayoutCommandTypes)
                Position = 0
                WriteByte(value)
                Position = 0
            End Set
        End Property
    End Class

    'Public Class GeolayoutCommandCollection
    '    Inherits List(Of GeolayoutCommand)

    '    Public Overrides Function ToString() As String
    '        Dim Lines As New List(Of String)
    '        For Each c In Me
    '            Dim casstring As String = ""
    '            For Each b As Byte In c.ToArray
    '                If casstring IsNot "" Then casstring &= " "
    '                casstring &= Hex(b)
    '            Next
    '        Next
    '        Return Microsoft.VisualBasic.Join(Lines.ToArray, vbNewLine)
    '    End Function
    'End Class

    Public Class GeolayoutCommandCollection
        Inherits BaseCommandCollection(Of GeolayoutCommand, GeolayoutCommandTypes)

        Public Function IndexOfFirst(cmdType As GeolayoutCommandTypes) As Integer
            For index As Integer = 0 To Me.Count - 1
                If Me(index).CommandType = cmdType Then Return index
            Next
            Return -1
        End Function

    End Class

    Public Enum GeolayoutCommandTypes
        BranchAndStore = &H0
        EndOfGeolayout = &H1
        JumpToSegAddr = &H2
        JumpBack = &H3
        StartOfNode = &H4
        EndOfNode = &H5
        SetScreenRenderArea = &H8
        Scale1 = &H9
        x0A = &HA
        x0B = &HB
        x0C = &HC
        x0D = &HD
        x0E = &HE
        CameraPreset = &HF
        x10 = &H10
        x11 = &H11
        LoadDisplaylistWithOffset = &H13
        BillboardModel = &H14
        LoadDisplaylist = &H15
        ObjectShadown = &H16
        x17 = &H17
        x18 = &H18
        Background = &H19
        x1A = &H1A
        x1C = &H1C
        Scale2 = &H1D
        x1E = &HE
        x1f = &HF
        DrawingDistance = &H20
    End Enum

End Namespace