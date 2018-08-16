Imports System.IO

Public Class DataTableEx
    Inherits DataTable

    Public Overridable Overloads Sub Load(path As String)
        Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read)
        Load(fs)
        fs.Close()
    End Sub
    Public Overridable Overloads Sub Load(s As Stream)
        Dim sr As New StreamReader(s)
        Load(sr)
    End Sub
    Public Overridable Overloads Sub Load(sr As StreamReader)
        Do Until sr.EndOfStream
            Dim cells() As String = sr.ReadLine.Split(",")
            AddCollums(cells.Count)
            Me.Rows.Add(cells)
        Loop
    End Sub

    Public Overridable Sub Save(path As String)
        Dim fs As New FileStream(path, FileMode.Create, FileAccess.ReadWrite)
        Save(fs)
        fs.Close()
    End Sub
    Public Overridable Sub Save(s As Stream)
        Dim sw As New StreamWriter(s)
        Save(sw)
    End Sub
    Public Overridable Sub Save(sw As StreamWriter)
        For Each row As DataRow In Me.Rows
            Dim line As String = ""
            For Each item In row.ItemArray
                If line <> "" Then line &= ","
                line &= item
            Next
            sw.WriteLine(line)
        Next
    End Sub

    Private Sub AddCollums(maxCount As Integer)
        For i As Integer = Me.Columns.Count To maxCount - 1
            Me.Columns.Add()
        Next
    End Sub

    Public Overridable Overloads Sub NewRow(ParamArray values As Object())
        AddCollums(values.Count)
        Me.Rows.Add(values)
    End Sub

    Protected Overrides Sub OnTableNewRow(e As DataTableNewRowEventArgs)
        AddCollums(e.Row.ItemArray.Count)
        MyBase.OnTableNewRow(e)
    End Sub

    Public Overridable Sub InsertAt(row As DataRow, index As Integer)
        OnTableNewRow(New DataTableNewRowEventArgs(row))
        Rows.InsertAt(row, index)
    End Sub

End Class
