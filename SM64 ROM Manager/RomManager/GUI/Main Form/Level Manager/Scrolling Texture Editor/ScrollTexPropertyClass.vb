Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports SM64Lib.Levels.ScrolTex

Public Class ScrollTexPropertyClass

    <Browsable(False)>
    Public ReadOnly Property ScrollingTexture As ManagedScrollingTexture

    Public Sub New(scrollTex As ManagedScrollingTexture)
        ScrollingTexture = scrollTex
    End Sub

    <DisplayName("Group ID")>
    <Description("Indicates the group ID (by default deticted to the used texture).")>
    <Category("Grouping")>
    Public Property GroupID As Short
        Get
            Return ScrollingTexture.GroupID
        End Get
        Set(value As Short)
            ScrollingTexture.GroupID = value
        End Set
    End Property

    <DisplayName("Behavior")>
    <Description("Indicates the axis and behavior.")>
    <Category("Behavior")>
    <PropertyMultiChoiceEditor({"X-Scrolling", "Y-Scrolling", "Z-Scrolling", "UV-Scrolling Back/Forth", "UV-Scrolling Left/Right"}, {ScrollBehavior.ScrollingX, ScrollBehavior.ScrollingY, ScrollBehavior.ScrollingZ, ScrollBehavior.ScrollUVBackAndForth, ScrollBehavior.ScrollUVLeftAndRight})> '<PropertyMultiChoiceEditor("X-Scrolling,Y-Scrolling,Z-Scrolling,Scroll UV Back and Forth,Scroll UV Left and Right", True)>
    Public Property Behavior As ScrollBehavior
        Get
            Return ScrollingTexture.Behavior
        End Get
        Set(value As ScrollBehavior)
            ScrollingTexture.Behavior = value
        End Set
    End Property

    <DisplayName("Type")>
    <Description("Indicates the scroll type.")>
    <Category("Behavior")>
    <PropertyMultiChoiceEditor({"Normal Scrolling", "Jumping Scroll", "Sine Wave"}, {ScrollType.NormalScrolling, ScrollType.JumpingScroll, ScrollType.SineWave})>
    Public Property Type As ScrollType
        Get
            Return ScrollingTexture.Type
        End Get
        Set(value As ScrollType)
            ScrollingTexture.Type = value
        End Set
    End Property

    <DisplayName("Scrolling Speed")>
    <Description("The Scrolling Speed per Frame (less then 0x1000).")>
    <Category("Params")>
    Public Property ScrollingSpeed As Int16
        Get
            Return ScrollingTexture.ScrollingSpeed
        End Get
        Set(value As Int16)
            ScrollingTexture.ScrollingSpeed = value
        End Set
    End Property

    <DisplayName("Face Count")>
    <Description("Amount of vertices to count.")>
    <Category("Data")>
    Public Property FacesCount As UInt16
        Get
            Return ScrollingTexture.FacesCount
        End Get
        Set(value As UInt16)
            ScrollingTexture.FacesCount = value
        End Set
    End Property

    <DisplayName("Vertex Pointer")>
    <Description("Pointer to the vertices.")>
    <Category("Data")>
    Public Property VertexPointer As Integer
        Get
            Return ScrollingTexture.VertexPointer
        End Get
        Set(value As Integer)
            ScrollingTexture.VertexPointer = value
        End Set
    End Property

    <DisplayName("Cycle Duration")>
    <Description("Cycle duration of the sine wave or jumpy scrolling.")>
    <Category("Params")>
    Public Property CycleDuration As Byte
        Get
            Return ScrollingTexture.CycleDuration
        End Get
        Set(value As Byte)
            ScrollingTexture.CycleDuration = value
        End Set
    End Property

    <DisplayName("Act 1")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 1.")>
    Public Property Act1 As Boolean
        Get
            Return ScrollingTexture.Act1
        End Get
        Set(value As Boolean)
            ScrollingTexture.Act1 = value
        End Set
    End Property

    <DisplayName("Act 2")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 2.")>
    Public Property Act2 As Boolean
        Get
            Return ScrollingTexture.Act2
        End Get
        Set(value As Boolean)
            ScrollingTexture.Act2 = value
        End Set
    End Property

    <DisplayName("Act 3")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 3.")>
    Public Property Act3 As Boolean
        Get
            Return ScrollingTexture.Act3
        End Get
        Set(value As Boolean)
            ScrollingTexture.Act3 = value
        End Set
    End Property

    <DisplayName("Act 4")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 4.")>
    Public Property Act4 As Boolean
        Get
            Return ScrollingTexture.Act4
        End Get
        Set(value As Boolean)
            ScrollingTexture.Act4 = value
        End Set
    End Property

    <DisplayName("Act 5")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 5.")>
    Public Property Act5 As Boolean
        Get
            Return ScrollingTexture.Act5
        End Get
        Set(value As Boolean)
            ScrollingTexture.Act5 = value
        End Set
    End Property

    <DisplayName("Act 6")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible if you select Star 6.")>
    Public Property Act6 As Boolean
        Get
            Return ScrollingTexture.Act6
        End Get
        Set(value As Boolean)
            ScrollingTexture.Act6 = value
        End Set
    End Property

    <DisplayName("All Acts")>
    <Category("Acts")>
    <Description("If Yes, the Object will be visible always.")>
    Public Property AllActs As Boolean
        Get
            Return ScrollingTexture.AllActs
        End Get
        Set(value As Boolean)
            ScrollingTexture.AllActs = value
        End Set
    End Property

End Class
