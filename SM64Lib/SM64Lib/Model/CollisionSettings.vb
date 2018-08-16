Imports System.IO

Namespace Global.SM64Lib.Model.Collision

    Public Class CollisionSettings

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
            Public Property CollisionType As Byte = 0
            Public Property CollisionParam1 As Byte = 0
            Public Property CollisionParam2 As Byte = 0
            Public Property IsNonSolid As Boolean = False

            Public Overloads Function ToString() As String
                Return $"{MaterialName};{CollisionType };{CollisionParam1 };{CollisionParam2};{IsNonSolid.ToString}"
            End Function

            Public Sub FromString(str As String)
                Dim parts As String() = str.Split(";")
                MaterialName = parts(0)
                CollisionType = parts(1)
                CollisionParam1 = parts(2)
                CollisionParam2 = parts(3)
                If parts.Count > 4 Then IsNonSolid = Convert.ToBoolean(parts(4))
            End Sub

        End Class

    End Class

End Namespace

