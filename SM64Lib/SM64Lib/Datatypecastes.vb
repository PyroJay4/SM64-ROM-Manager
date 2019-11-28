Imports System.IO
Imports System.Text.RegularExpressions
Imports IniParser.Model
Imports SM64Lib.Patching
Imports SM64Lib.Model
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection

Module Datatypecastes

    Public Function LongToInt16(ByVal value As Long) As Int16
        Dim cast As CasterLongInt16
        cast.LongValue = value
        Return cast.Int16Value
    End Function

    <StructLayout(LayoutKind.Explicit)>
    Private Structure CasterLongInt16
        <FieldOffset(0)> Public LongValue As Long
        <FieldOffset(0)> Public Int16Value As Int16
    End Structure

    Public Function LongToByte(ByVal value As Long) As Byte
        Dim cast As CasterLongByte
        cast.LongValue = value
        Return cast.ByteValue
    End Function

    <StructLayout(LayoutKind.Explicit)>
    Private Structure CasterLongByte
        <FieldOffset(0)> Public LongValue As Long
        <FieldOffset(0)> Public ByteValue As Byte
    End Structure

End Module
