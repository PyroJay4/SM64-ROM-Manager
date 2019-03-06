Imports System.Drawing
Imports System.Runtime.InteropServices

Public Module IconExtractor

    Private Const SHGFI_ICON As UInteger = &H100
    Private Const SHGFI_LARGEICON As UInteger = &H0
    Private Const SHGFI_SMALLICON As UInteger = &H1

    Private Declare Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbSizeFileInfo As UInteger, ByVal uFlags As UInteger) As IntPtr

    ''' <summary>
    ''' Extrahiert das Icon aus einer Datei oder aus einem Ordner.
    ''' </summary>
    ''' <param name="filePath">Hier übergeben Sie den Pfad der Datei von dem das Icon extrahiert werden soll.</param>
    ''' <param name="Small">Bei übergabe von true wird ein kleines und bei false ein großes Icon zurück gegeben.</param>
    Public Function ExtractIcon(filePath As String, small As Boolean) As Icon
        Dim shinfo As New SHFILEINFO

        SHGetFileInfo(filePath, 0, shinfo, Math.Truncate(Marshal.SizeOf(shinfo)), SHGFI_ICON Or If(small, SHGFI_SMALLICON, SHGFI_LARGEICON))

        Return Icon.FromHandle(shinfo.hIcon)
    End Function

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

End Module
