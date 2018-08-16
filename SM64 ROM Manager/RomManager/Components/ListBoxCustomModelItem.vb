Public Class ListBoxCustomModelItem
    Inherits DevComponents.DotNetBar.ListBoxItem

    Public EnableCollision As Boolean = False
    Public Colpointer As UInteger = 0
    Public ReadOnly Geopointer As New List(Of SM64Lib.Geolayout.Geopointer)
    Public RomOffset As UInteger = 0
    Public RamOffset As UInteger = 0
    Public MaxRomOffset As UInteger = 0
    Public ExtraData As String = ""
End Class
