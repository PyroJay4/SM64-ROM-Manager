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

Namespace Model

    Public Class ObjectInputSettings

        Public Property ForceDisplaylist As SByte = -1
        Public Property Scaling As Double = 1.0F
        Public Property ReduceDupVertLevel As ReduceDuplicateVerticesLevel = ReduceDuplicateVerticesLevel.Level1
        Public Property Fog As Fog = Nothing
        Public Property ResizeTextures As Boolean = True
        Public Property CenterModel As Boolean = False
        Public ReadOnly Property Shading As New Pilz.S3DFileParser.Shading
        Public Property OptimizeTransparencyChecks As Boolean = False

        Public Enum ReduceDuplicateVerticesLevel
            ''' <summary>Don't reduce vertices.</summary>
            Level0
            ''' <summary>Reduce only, if in the same 0x4 group.</summary>
            Level1
            ''' <summary>Reduce and push up. [Buggy]</summary>
            Level2
        End Enum
    End Class

End Namespace
