Imports System.Drawing
Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)>
Public Structure SHFILEINFO
    Public hIcon As IntPtr
    Public iIcon As IntPtr
    Public dwAttributes As UInteger
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
    Public szDisplayName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
    Public szTypeName As String
End Structure

Public Class IconExtractor
    ''' <summary>
    ''' Extrahiert das Icon aus einer Datei oder aus einem Ordner.
    ''' </summary>
    ''' <param name="FilePath">Hier übergeben Sie den Pfad der Datei von dem das Icon extrahiert werden soll.</param>
    ''' <param name="Small">Bei übergabe von true wird ein kleines und bei false ein großes Icon zurück gegeben.</param>
    Public Shared Function ExtractIcon(ByVal FilePath As String, ByVal Small As Boolean) As Icon
        Dim hImgSmall As IntPtr
        Dim hImgLarge As IntPtr
        Dim shinfo As New SHFILEINFO()

        If Small Then
            hImgSmall = SHGetFileInfo(FilePath, 0, shinfo, CUInt(Math.Truncate(Marshal.SizeOf(shinfo))), SHGFI_ICON Or SHGFI_SMALLICON)
        Else
            hImgLarge = SHGetFileInfo(FilePath, 0, shinfo, CUInt(Math.Truncate(Marshal.SizeOf(shinfo))), SHGFI_ICON Or SHGFI_LARGEICON)
        End If

        Return (Icon.FromHandle(shinfo.hIcon))
    End Function

    Public Const SHGFI_ICON As UInteger = &H100
    Public Const SHGFI_LARGEICON As UInteger = &H0
    Public Const SHGFI_SMALLICON As UInteger = &H1

    <DllImport("shell32.dll")>
    Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbSizeFileInfo As UInteger, ByVal uFlags As UInteger) As IntPtr
    End Function
End Class