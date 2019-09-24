Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json.Linq

Namespace Model.Fast3D

    Public Class TextureFormatSettings

        Public ReadOnly Property Entries As New List(Of Entry)

        Public Async Function Load(fileName As String) As Task
            If File.Exists(fileName) Then
                Dim success As Boolean = False
                Dim streamReader As New StreamReader(fileName)
                Dim content As String = Await streamReader.ReadToEndAsync

                streamReader.Close()
                Entries.Clear()

                Try
                    Entries.AddRange(JArray.Parse(content).ToObject(Of Entry()))
                    success = True
                Catch ex As Exception
                End Try

                If Not success Then
                    Dim sr As New StringReader(content)

                    Do While sr.Peek > -1
#Disable Warning BC40008 ' Der Typ oder Member ist veraltet.
                        Dim e As Entry = Entry.FromString(Await sr.ReadLineAsync)
#Enable Warning BC40008 ' Der Typ oder Member ist veraltet.
                        Entries.Add(e)
                    Loop

                    sr.Close()
                    sr.Dispose()
                End If
            End If
        End Function

        Public Async Function Save(fileName As String) As Task
            Dim sw As New StreamWriter(fileName)

            Await sw.WriteAsync(JArray.FromObject(Entries).ToString)

            sw.Flush()
            sw.Close()
        End Function

        Public Function GetEntry(matName As String) As Entry
            For Each e As Entry In Entries
                If e.MaterialName = matName Then
                    Return e
                End If
            Next

            Dim ne As New Entry
            ne.MaterialName = matName
            Entries.Add(ne)
            Return ne
        End Function

        Public Class Entry

            Public Property MaterialName As String = ""
            Public Property TextureFormat As String = ""
            Public Property IsScrollingTexture As Boolean = False
            Public Property SelectDisplaylistMode As SByte = -1
            Public Property FaceCullingMode As FaceCullingMode = FaceCullingMode.Back
            Public Property EnableMirror As Boolean = False
            Public Property EnableClamp As Boolean = False
            Public Property EnableCrystalEffect As Boolean = False
            Public Property RotateFlip As RotateFlipType = RotateFlipType.RotateNoneFlipNone

            <Obsolete>
            Public Shared Function FromString(str As String) As Entry
                Dim newEntry As New Entry

                Dim parts As String() = str.Split(";")
                newEntry.MaterialName = parts(0)
                newEntry.TextureFormat = parts(1)
                If parts.Length > 2 Then newEntry.IsScrollingTexture = Convert.ToBoolean(parts(2))
                If parts.Length > 3 Then
                    newEntry.SelectDisplaylistMode = Convert.ToSByte(parts(3))
                    If newEntry.SelectDisplaylistMode = 0 Then newEntry.SelectDisplaylistMode = -1
                End If
                If parts.Length > 4 Then newEntry.FaceCullingMode = Convert.ToByte(parts(4))
                If parts.Length > 5 Then
                    newEntry.EnableMirror = Convert.ToBoolean(parts(5))
                    newEntry.EnableClamp = Convert.ToBoolean(parts(6))
                End If
                If parts.Length > 7 Then newEntry.EnableCrystalEffect = Convert.ToBoolean(parts(7))
                If parts.Length > 8 Then newEntry.RotateFlip = Convert.ToInt32(parts(8))

                Return newEntry
            End Function

        End Class

        Public Enum FaceCullingMode
            None
            Front
            Back
            FrontAndBack = Front Or Back
        End Enum

    End Class

End Namespace

