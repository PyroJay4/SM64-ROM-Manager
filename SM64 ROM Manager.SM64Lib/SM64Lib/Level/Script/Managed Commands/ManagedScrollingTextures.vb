Imports System.ComponentModel
Imports SM64_ROM_Manager.SM64Lib.Levels.Script
Imports SM64_ROM_Manager.SM64Lib.Levels.Script.Commands

Namespace Levels.ScrolTex

    Public Class ManagedScrollingTexture
        Implements IManagedLevelscriptCommand

        ''' <summary>
        ''' The underlying levelscript command which provide all the properties.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Command As LevelscriptCommand = Nothing Implements IManagedLevelscriptCommand.Command

        ''' <summary>
        ''' Creates a new managed scrolling texture instance with an new levelscript command.
        ''' </summary>
        Public Sub New()
            Command = New LevelscriptCommand("24 18 1F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 40 00 00")
            SaveProperties()
        End Sub

        ''' <summary>
        ''' Creates a new managed scrolling texture instance using some data with an new levelscript command.
        ''' </summary>
        ''' <param name="facesCount">Amount of faces to count.</param>
        ''' <param name="vertexPtr">Pointer to the Vertices.</param>
        Public Sub New(facesCount As UInt16, vertexPtr As Integer)
            Me.New
            Me.FacesCount = facesCount
            Me.VertexPointer = vertexPtr
        End Sub

        ''' <summary>
        ''' Creates a new managed scrolling texture instance using an existing levelscript command.
        ''' </summary>
        ''' <param name="cmd">The levelscript command to use.</param>
        Public Sub New(cmd As LevelscriptCommand)
            Command = cmd
            LoadProperties()
        End Sub

        ''' <summary>
        ''' Indicates the cycle duration of sine wave or jumping scrolling.
        ''' </summary>
        ''' <returns></returns>
        <DisplayName("Behavior")>
        <Description("Indicates the axis and behavior.")>
        <Category("Behavior")>
        Public Property Behavior As ScrollBehavior = ScrollBehavior.ScrollUVBackAndForth

        ''' <summary>
        ''' Indicates the scroll behavior.
        ''' </summary>
        ''' <returns></returns>
        <DisplayName("Type")>
        <Description("Indicates the scroll type.")>
        <Category("Behavior")>
        Public Property Type As ScrollType = ScrollType.NormalScrolling

        ''' <summary>
        ''' The Scrolling Speed per Frame (less then 0x1000).
        ''' </summary>
        ''' <returns></returns>
        <DisplayName("Scrolling Speed")>
        <Description("The Scrolling Speed per Frame (less then 0x1000).")>
        <Category("Params")>
        Public Property ScrollingSpeed As Int16 = 60

        ''' <summary>
        ''' Indicates the duration of a cycle in frames.
        ''' </summary>
        ''' <returns></returns>
        <DisplayName("Cycle Duration")>
        <Description("Cycle duration of the sine wave or jumpy scrolling in frames.")>
        <Category("Params")>
        Public Property CycleDuration As Byte = 20

        ''' <summary>
        ''' Amount of faces to count.
        ''' </summary>
        ''' <returns></returns>
        <DisplayName("Vertex Data")>
        <Description("Amount of vertices to count.")>
        <Category("Data")>
        Public Property FacesCount As UInt16 = 0

        ''' <summary>
        ''' Pointer to the vertices.
        ''' </summary>
        ''' <returns></returns>
        <DisplayName("Vertex Data")>
        <Description("Pointer to the vertices.")>
        <Category("Data")>
        Public Property VertexPointer As Integer = 0

        <DisplayName("Act 1")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible if you select Star 1.")>
        Public Property Act1 As Boolean = True

        <DisplayName("Act 2")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible if you select Star 2.")>
        Public Property Act2 As Boolean = True

        <DisplayName("Act 3")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible if you select Star 3.")>
        Public Property Act3 As Boolean = True

        <DisplayName("Act 4")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible if you select Star 4.")>
        Public Property Act4 As Boolean = True

        <DisplayName("Act 5")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible if you select Star 5.")>
        Public Property Act5 As Boolean = True

        <DisplayName("Act 6")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible if you select Star 6.")>
        Public Property Act6 As Boolean = False

        <DisplayName("All Acts")>
        <Category("Acts")>
        <Description("If Yes, the Object will be visible always.")>
        Public Property AllActs As Boolean
            Get
                Return Act1 AndAlso Act2 AndAlso Act3 AndAlso Act4 AndAlso Act5 AndAlso Not Act6
            End Get
            Set(value As Boolean)
                Act1 = value
                Act2 = value
                Act3 = value
                Act4 = value
                Act5 = value
                Act6 = False
            End Set
        End Property

        Public Sub LoadProperties() Implements IManagedLevelscriptCommand.LoadProperties
            CycleDuration = clScrollingTexture.GetCycleDuration(Command)
            VertexPointer = clScrollingTexture.GetVertexPointer(Command)
            FacesCount = clScrollingTexture.GetCountOfFaces(Command)
            ScrollingSpeed = clScrollingTexture.GetScrollSpeed(Command)
            Type = clScrollingTexture.GetScrollType(Command)
            Behavior = clScrollingTexture.GetScrollBehavior(Command)

            Dim acts() As Boolean = Bits.ByteToBoolArray(clNormal3DObject.GetActs(Command))
            Act1 = acts(7)
            Act2 = acts(6)
            Act3 = acts(5)
            Act4 = acts(4)
            Act5 = acts(3)
            Act6 = acts(2)
        End Sub

        Public Sub SaveProperties() Implements IManagedLevelscriptCommand.SaveProperties
            SaveProperties(Command)
        End Sub

        Public Sub SaveProperties(Command As LevelscriptCommand) Implements IManagedLevelscriptCommand.SaveProperties
            clScrollingTexture.SetCycleDuration(Command, CycleDuration)
            clScrollingTexture.SetVertexPointer(Command, VertexPointer)
            clScrollingTexture.SetCountOfFaces(Command, FacesCount)
            clScrollingTexture.SetScrollSpeed(Command, ScrollingSpeed)
            clScrollingTexture.SetScrollType(Command, Type)
            clScrollingTexture.SetScrollBehavior(Command, Behavior)
            clNormal3DObject.SetSegBehaviorAddr(Command, &H400000)

            Dim acts() As Boolean = {False, False, False, False, False, False, False, False}
            acts(7) = Act1
            acts(6) = Act2
            acts(5) = Act3
            acts(4) = Act4
            acts(3) = Act5
            acts(2) = Act6
            clNormal3DObject.SetActs(Command, Bits.ArrayToByte(acts))
        End Sub

    End Class

    Public Enum ScrollBehavior
        ScrollingX = &H0
        ScrollingY = &H20
        ScrollingZ = &H40
        ScrollUVBackAndForth = &H80
        ScrollUVLeftAndRight = &HA0
    End Enum

    Public Enum ScrollType
        NormalScrolling = &H0
        SineWave = &H1
        JumpingScroll = &H2
    End Enum

End Namespace
