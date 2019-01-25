Imports System.IO
Imports System.Reflection

Namespace Plugins

    Public Class Plugin

        Public ReadOnly Property MainMethods As IReadOnlyList(Of PluginFunction)
        Public ReadOnly Property ImplementMethods As IReadOnlyList(Of PluginFunction)
        Public ReadOnly Property LoaderModuleMethods As IReadOnlyList(Of PluginFunction)

        Public Sub New(filePath As String)
            Dim asm As Assembly = Assembly.LoadFile(filePath)
            Dim modul As Type = asm.GetType("Plugin")

            If modul Is Nothing Then
                Throw New Exception("Plugin Modul not found!")
            End If

            Dim entryMethodType As Type = GetType(PluginCenter.Attributes.EntryMethodAttribute)
            Dim implementMethodType As Type = GetType(PluginCenter.Attributes.MenuEntryMethodAttribute)

            Dim mainMethods As New List(Of PluginFunction)
            Dim implementMethods As New List(Of PluginFunction)

            For Each mi As MethodInfo In modul.GetMethods
                Dim found As Boolean = False

                For Each attr As Attribute In Attribute.GetCustomAttributes(mi)
                    If Not found Then
                        Dim t As Type = attr.GetType

                        Select Case t
                            Case entryMethodType
                                mainMethods.Add(New PluginFunction(mi, Me))

                            Case implementMethodType
                                With CType(attr, PluginCenter.Attributes.MenuEntryMethodAttribute)
                                    implementMethods.Add(New PluginFunction(mi, Me, .Params, .MenuCode))
                                End With

                        End Select

                        found = True
                    End If
                Next
            Next

            Me.MainMethods = mainMethods
            Me.ImplementMethods = implementMethods

            Dim args As String() = {Directory.GetCurrentDirectory, filePath}

            For Each func As PluginFunction In mainMethods
                func.Invoke({args})
            Next
        End Sub

        Public Function GetImplementMethods(ParamArray menuCodes As String()) As IEnumerable(Of PluginFunction)
            Dim funcs As New List(Of PluginFunction)

            For Each func As PluginFunction In ImplementMethods
                If menuCodes.Contains(func.MenuCode) Then
                    funcs.Add(func)
                End If
            Next

            Return funcs
        End Function

        Public Function GetImplementMethod(menuCode As String) As PluginFunction
            For Each func As PluginFunction In ImplementMethods
                If func.MenuCode = menuCode Then
                    Return func
                End If
            Next

            Return Nothing
        End Function

    End Class

End Namespace