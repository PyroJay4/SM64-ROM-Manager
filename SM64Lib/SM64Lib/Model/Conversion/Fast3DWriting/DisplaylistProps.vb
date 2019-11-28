Imports SM64Lib.Geolayout

Namespace Model.Conversion.Fast3DWriting

    Public Class DisplaylistProps

        Public Property ID As Integer
        Public Property Layer As DefaultGeolayers = DefaultGeolayers.Solid

        Public Sub New(ID As Integer)
            Me.ID = ID
        End Sub

    End Class

End Namespace
