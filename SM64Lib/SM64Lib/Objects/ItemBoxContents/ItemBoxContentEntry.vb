Imports System.ComponentModel

Namespace Objects

    Public Class ItemBoxContentEntry
        <DisplayName("Content ID")>
        Public Property ID As Byte
        <DisplayName("Model ID")>
        Public Property ModelID As Byte
        <DisplayName("Behavior Param 1")>
        Public Property BParam1 As Byte
        <DisplayName("Behavior Param 2")>
        Public Property BParam2 As Byte
        <DisplayName("Behavior Address")>
        Public Property BehavAddress As UInteger
    End Class

End Namespace
