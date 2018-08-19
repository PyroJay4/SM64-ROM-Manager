Imports System.IO

Namespace Global.SM64Lib.Model.Fast3D

    Public Class TextureFormatSettings

        Public ReadOnly Property Entries As New List(Of Entry)

        Public Async Function Load(fileName As String) As Task
            If File.Exists(fileName) Then

                Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
                Dim sr As New StreamReader(fs)

                Entries.Clear()

                Do Until sr.EndOfStream
                    Dim e As New Entry
                    e.FromString(Await sr.ReadLineAsync)
                    Entries.Add(e)
                Loop

                fs.Close()

            End If
        End Function

        Public Async Function Save(fileName As String) As Task
            Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)
            Dim sw As New StreamWriter(fs)

            For Each e As Entry In Entries
                Await sw.WriteLineAsync(e.ToString)
            Next
            Await sw.FlushAsync()

            fs.Close()
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
            Public Property SelectDisplaylistMode As SelectDisplaylistMode = SelectDisplaylistMode.Automatic

            Public Overloads Function ToString() As String
                Return $"{MaterialName};{TextureFormat};{IsScrollingTexture.ToString};{CByte(SelectDisplaylistMode)}"
            End Function

            Public Sub FromString(str As String)
                Dim parts As String() = str.Split(";")
                MaterialName = parts(0)
                TextureFormat = parts(1)
                If parts.Length > 2 Then IsScrollingTexture = Convert.ToBoolean(parts(2))
                If parts.Length > 3 Then SelectDisplaylistMode = Convert.ToByte(parts(3))
            End Sub

        End Class

        Public Enum SelectDisplaylistMode As Byte
            Automatic
            Solid
            Alpha
            Transparent
        End Enum

    End Class

End Namespace

