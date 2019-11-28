Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports DevComponents.AdvTree
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SM64_ROM_Manager.PatchScripts.My.Resources

Public Class ObjectCatalog

    Private ReadOnly myBindingFlags As BindingFlags = BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.Public
    Private ReadOnly blackMethodNameStarts As String() = {"get_", "set_", "add_", "remove_"}
    Private ReadOnly AsmXmls As New List(Of SerializedAssemblyMember)

    Public Sub New()
        InitializeComponent()
        UpdateAmbientColors
        CreateImageList()
    End Sub

    Private Sub CreateImageList()
        ImageList_RefSymbols.Images.Clear()
        For Each kvp As DictionaryEntry In ReflectionSymbols.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, True, True)
            ImageList_RefSymbols.Images.Add(kvp.Key, kvp.Value)
        Next
    End Sub

    Private Sub LoadCatalog()
        Dim asms As New List(Of Assembly)
        Dim nodes As New List(Of Node)

        asms.Add(GetType(SM64Lib.RomManager).Assembly)

        For Each asm As Assembly In asms
            'Create Node
            Dim nasm As Node = GetNode(asm.FullName, asm)
            nodes.Add(nasm)

            'Search Types
            SearchTypes(asm.GetTypes, nasm)

            'Search XML Serialations
            AsmXmls.AddRange(LoadAsmXml(GetType(SM64Lib.RomManager).Assembly))
        Next

        For Each n As Node In nodes
            n.Expand()
        Next

        Invoke(
            Sub()
                AdvTree1.SuspendLayout()
                AdvTree1.Nodes.Clear()
                AdvTree1.Nodes.AddRange(nodes.ToArray)
                AdvTree1.ResumeLayout()
            End Sub)
    End Sub

    Private Function GetMemberInfo(mi As MemberInfo) As String
        Dim fullPath As String = String.Empty
        Dim text As String = String.Empty

        Select Case mi.MemberType
            Case MemberTypes.TypeInfo, MemberTypes.NestedType
                Dim t As Type = mi
                fullPath = t.FullName
            Case MemberTypes.Method, MemberTypes.Constructor, MemberTypes.Property, MemberTypes.Field, MemberTypes.Event
                fullPath = mi.DeclaringType.FullName & "." & mi.Name
        End Select

        If Not String.IsNullOrEmpty(fullPath) AndAlso fullPath.Contains("."c) Then
            Dim path As String = fullPath.Remove(fullPath.LastIndexOf("."c))
            Dim name As String = fullPath.Substring(fullPath.LastIndexOf("."c) + 1)
            Dim foundSam As SerializedAssemblyMember = Nothing

            For Each sam As SerializedAssemblyMember In AsmXmls
                If foundSam Is Nothing AndAlso sam.Name = name AndAlso sam.Path = path Then
                    foundSam = sam
                End If
            Next

            If foundSam IsNot Nothing Then
                text =
$"{name} : {foundSam.Type}
in {path}

{foundSam.Description}"
            Else
                text =
$"{name}
in {path}"
            End If
        End If

        Return text
    End Function

    Private Function GetNode(text As String, tag As Object) As Node
        Dim n As New Node With {
            .Text = text,
            .Tag = tag
        }

        If TypeOf tag Is MethodInfo Then
            n.ImageKey = NameOf(ReflectionSymbols.Methode)
        ElseIf TypeOf tag Is Type Then
            Dim t As Type = tag
            Select Case True
                Case t.IsEnum
                    n.ImageKey = NameOf(ReflectionSymbols._Enum)
                Case t.IsClass
                    n.ImageKey = NameOf(ReflectionSymbols._Class)
                Case t.IsInterface
                    n.ImageKey = NameOf(ReflectionSymbols._Interface)
            End Select
        ElseIf TypeOf tag Is PropertyInfo Then
            n.ImageKey = NameOf(ReflectionSymbols._Property)
        ElseIf TypeOf tag Is FieldInfo Then
            n.ImageKey = NameOf(ReflectionSymbols.Field)
        ElseIf TypeOf tag Is EventInfo Then
            n.ImageKey = NameOf(ReflectionSymbols._Event)
        ElseIf tag Is Nothing Then
            n.ImageKey = NameOf(ReflectionSymbols._Namespace)
        End If

        Return n
    End Function

    Private Sub SearchTypes(types As IEnumerable(Of Type), parent As Node)
        Static knownNamespaces As New Dictionary(Of String, Node)
        Static knownTypes As New Dictionary(Of Type, Node)

        For Each t As Type In types
            If (t.IsPublic OrElse t.IsNestedPublic) AndAlso Not knownTypes.ContainsKey(t) Then
                Dim nns As Node

                If String.IsNullOrEmpty(t.Namespace) OrElse (t.IsNested AndAlso t.ReflectedType IsNot Nothing AndAlso t.ReflectedType Is parent.Tag) Then
                    nns = parent
                ElseIf knownNamespaces.ContainsKey(t.Namespace) Then
                    nns = knownNamespaces(t.Namespace)
                Else
                    nns = GetNode(t.Namespace, Nothing)
                    parent.Nodes.Add(nns)
                    knownNamespaces.Add(t.Namespace, nns)
                End If

                Dim nt As Node = GetNode(t.Name, t)
                nns.Nodes.Add(nt)
                knownTypes.Add(t, nt)

                SearchTypes(t.GetNestedTypes, nt)

                For Each f As FieldInfo In t.GetFields(myBindingFlags)
                    Dim np As Node = GetNode(f.Name & " : " & f.FieldType.ToString, f)
                    nt.Nodes.Add(np)
                Next

                For Each p As PropertyInfo In t.GetProperties(myBindingFlags)
                    Dim np As Node = GetNode(p.Name & " : " & p.PropertyType.ToString, p)
                    nt.Nodes.Add(np)
                Next

                For Each m As MethodInfo In t.GetMethods(myBindingFlags)
                    If IsMethodeValue(m.Name) Then
                        Dim params As String = ""
                        Array.ForEach(m.GetParameters, Sub(n) params &= n.ParameterType.ToString & ", ")
                        Dim nm As Node = GetNode(m.Name & "(" & params.TrimEnd(","c, " "c) & ") : " & m.ReturnType.ToString, m)
                        nt.Nodes.Add(nm)
                    End If
                Next

                For Each e As EventInfo In t.GetEvents(myBindingFlags)
                    Dim np As Node = GetNode(e.ToString, e)
                    nt.Nodes.Add(np)
                Next
            End If
        Next
    End Sub

    Private Function IsMethodeValue(methodName As String) As Boolean
        For Each blackName As String In blackMethodNameStarts
            If methodName.StartsWith(blackName) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Async Sub ObjectCatalog_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CircularProgress1.Start()
        Await Task.Run(AddressOf LoadCatalog)
        CircularProgress1.Stop()
        TableLayoutPanel_1.Visible = True
    End Sub

    Private Sub AdvTree1_AfterNodeSelect(sender As Object, e As AdvTreeNodeEventArgs) Handles AdvTree1.AfterNodeSelect
        If e.Node?.Tag IsNot Nothing Then
            LabelX_MemberInfo.Text = GetMemberInfo(e.Node.Tag)
        Else
            LabelX_MemberInfo.Text = String.Empty
        End If
    End Sub

End Class
