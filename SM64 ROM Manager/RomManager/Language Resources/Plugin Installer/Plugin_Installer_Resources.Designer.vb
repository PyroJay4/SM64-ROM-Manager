﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:4.0.30319.42000
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    '-Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    'Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    'mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    '''<summary>
    '''  Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Plugin_Installer_Resources
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SM64_ROM_Manager.Plugin_Installer_Resources", GetType(Plugin_Installer_Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        '''  Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die Plugin will be removed on next restart of SM64 ROM Manager. ähnelt.
        '''</summary>
        Friend Shared ReadOnly Property MsgBox_PluginInstalled() As String
            Get
                Return ResourceManager.GetString("MsgBox_PluginInstalled", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die Installing Plugin ähnelt.
        '''</summary>
        Friend Shared ReadOnly Property MsgBox_PluginInstalled_Error_Titel() As String
            Get
                Return ResourceManager.GetString("MsgBox_PluginInstalled_Error_Titel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die Plugin installed ähnelt.
        '''</summary>
        Friend Shared ReadOnly Property MsgBox_PluginInstalled_Titel() As String
            Get
                Return ResourceManager.GetString("MsgBox_PluginInstalled_Titel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die Plugin installed successfully. The changes may be visible only after restart the SM64 ROM Manager. ähnelt.
        '''</summary>
        Friend Shared ReadOnly Property MsgBox_PluginRemoved() As String
            Get
                Return ResourceManager.GetString("MsgBox_PluginRemoved", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die Removing Plugin ähnelt.
        '''</summary>
        Friend Shared ReadOnly Property MsgBox_PluginRemoved_Error_Titel() As String
            Get
                Return ResourceManager.GetString("MsgBox_PluginRemoved_Error_Titel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die Plugin Removed ähnelt.
        '''</summary>
        Friend Shared ReadOnly Property MsgBox_PluginRemoved_Titel() As String
            Get
                Return ResourceManager.GetString("MsgBox_PluginRemoved_Titel", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
