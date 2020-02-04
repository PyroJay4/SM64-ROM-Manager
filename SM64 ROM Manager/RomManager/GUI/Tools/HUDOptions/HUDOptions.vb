Imports System.IO
Imports Newtonsoft.Json.Linq
Imports SM64Lib

Public Class HUDOptions

    Public ReadOnly Property Block As HUDOptionsBlock = Nothing
    Public ReadOnly Property RomManager As RomManager

    Public Sub New(rommgr As RomManager)
        RomManager = rommgr
    End Sub

    Public Sub LoadBlock(p As String)
        _Block = JObject.Parse(File.ReadAllText(p)).ToObject(Of HUDOptionsBlock)
    End Sub

    Public Function GetPosition(b As HUDOptionsBlock) As Point

    End Function

    Public Sub SetPosition(b As HUDOptionsBlock, p As Point)

    End Sub

    Public Sub OpenRomRead()

    End Sub

    Public Sub OpenRomWrite()

    End Sub

    Public Sub CloseRom()

    End Sub

End Class
