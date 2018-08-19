Imports System.IO
Imports System.Numerics
Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64Lib
Imports SM64Lib.Trajectorys

Public Class TrajectoryEditor

    Private rommgr As RomManager = Nothing
    Private trajectories As New Trajectories
    Private loadingNodeData As Boolean = False

    Public ReadOnly Property SelectedTrajectory As Trajectory
        Get
            Dim ci As ComboItem = ComboBoxEx1.SelectedItem
            If ci IsNot Nothing Then
                Return ci.Tag
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub New(rommgr As RomManager)
        InitializeComponent()

        For Each c As ColumnHeader In ListViewEx1.Columns
            c.TextAlign = HorizontalAlignment.Center
        Next

        Me.rommgr = rommgr
    End Sub

    Private Sub TrajectoryEditor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.Read)
        trajectories.ReadTrajectories(fs)
        fs.Close()
        LoadTrajectoriesList()
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        Dim fs As New FileStream(rommgr.RomFile, FileMode.Open, FileAccess.ReadWrite)
        trajectories.WriteTrajectories(fs)
        fs.Close()
    End Sub

    Private Sub LoadTrajectoriesList()
        ComboBoxEx1.SuspendLayout()
        ButtonX8.SuspendLayout()

        ComboBoxEx1.Items.Clear()
        ButtonX8.SubItems.Clear()

        Dim namesWeHad As New List(Of TrajectoryName) From {TrajectoryName.None}

        For Each trac As Trajectory In trajectories
            Dim ci As New ComboItem
            ci.Tag = trac
            ci.Text = GetTextOfTrajectoryName(trac.Name)
            If ci.Text = "" Then ci.Text = $"Trajectory with {trac.Points.Count} Nodes"
            ComboBoxEx1.Items.Add(ci)
            If Not namesWeHad.Contains(trac.Name) Then namesWeHad.Add(trac.Name)
        Next

        For Each name As TrajectoryName In [Enum].GetValues(GetType(TrajectoryName))
            If Not namesWeHad.Contains(name) Then
                Dim bi As New ButtonItem
                bi.Text = GetTextOfTrajectoryName(name)
                bi.Tag = name
                AddHandler bi.Click, AddressOf ButtonItem_AddNewTrajectory_Click
                ButtonX8.SubItems.Add(bi)
            End If
        Next

        If ComboBoxEx1.Items.Count > 0 Then ComboBoxEx1.SelectedIndex = 0
        ButtonX8.Enabled = ButtonX8.SubItems.Count > 0

        ComboBoxEx1.ResumeLayout()
        ButtonX8.ResumeLayout()
    End Sub

    Private Function GetTextOfTrajectoryName(name As TrajectoryName) As String
        Select Case name
            Case TrajectoryName.KoopaTheQuick1
                Return "Koopa The Quick 1"
            Case TrajectoryName.KoopaTheQuick2
                Return "Koopa The Quick 2"
            Case TrajectoryName.RacingPenguin
                Return "Racing Penguin"
            Case TrajectoryName.SnowmansBottom
                Return "Snowmans Bottom"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_00
                Return "Plattform On Tracks Behavior (B. Param 00)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_01
                Return "Plattform On Tracks Behavior (B. Param 01)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_02
                Return "Plattform On Tracks Behavior (B. Param 02)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_03
                Return "Plattform On Tracks Behavior (B. Param 03)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_04
                Return "Plattform On Tracks Behavior (B. Param 04)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_05
                Return "Plattform On Tracks Behavior (B. Param 05)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_06
                Return "Plattform On Tracks Behavior (B. Param 06)"
            Case TrajectoryName.PlatformOnTracksBehavior_BParam2_07
                Return "Plattform On Tracks Behavior (B. Param 07)"
            Case TrajectoryName.MetalBallsGenerators_BParam2_00
                Return "Metal Ball Generator (B. Param 00)"
            Case TrajectoryName.MetalBallsGenerators_BParam2_01
                Return "Metal Ball Generator (B. Param 01)"
            Case TrajectoryName.MetalBallsGenerators_BParam2_02
                Return "Metal Ball Generator (B. Param 02)"
            Case TrajectoryName.MiniMetalBallGenerator_BParam2_03
                Return "Mini Metal Ball Generator (B. Param 03)"
            Case TrajectoryName.MiniMetalBallGenerator_BParam2_04
                Return "Mini Metal Ball Generator (B. Param 04)"
            Case Else
                Return ""
        End Select
    End Function

    Private Sub ButtonItem_AddNewTrajectory_Click(sender As Object, e As EventArgs)
        MessageBoxEx.Show("Because not all trajectories were tested enought.<br/>Please be carfully and make a backup of your ROM in case that you will get an error when loading or saving the trajectories.<br/>If you get an error, please tell the developer.", "Not well tested Beta-Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Dim name As String = sender.Tag
        Dim trac As New Trajectory

        trac.Name = name
        trajectories.Add(trac)

        LoadTrajectoriesList()
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        If ComboBoxEx1.SelectedIndex > -1 Then
            LoadTrajectory(SelectedTrajectory)
        End If
    End Sub

    Private Sub LoadTrajectory(trac As Trajectory)
        ListViewEx1.SuspendLayout()
        ListViewEx1.Items.Clear()

        For Each v As Vector3 In trac.Points
            Dim lvi As New ListViewItem({"", v.X, v.Y, v.Z})
            lvi.Tag = v
            ListViewEx1.Items.Add(lvi)
        Next

        If ListViewEx1.Items.Count > 0 Then
            ListViewEx1.Items(0).Selected = True
        End If

        ListViewEx1.ResumeLayout()
    End Sub

    Private Sub LoadNodeData(v As Vector3)
        loadingNodeData = True
        IntegerInput1.Value = v.X
        IntegerInput2.Value = v.Y
        IntegerInput3.Value = v.Z
        loadingNodeData = False
    End Sub

    Private Sub IntegerInput1_ValueChanged(sender As Object, e As EventArgs) Handles IntegerInput1.ValueChanged, IntegerInput2.ValueChanged, IntegerInput3.ValueChanged
        If Not loadingNodeData Then
            Dim v As New Vector3(IntegerInput1.Value, IntegerInput2.Value, IntegerInput3.Value)
            For Each item As ListViewItem In ListViewEx1.SelectedItems
                SelectedTrajectory.Points(item.Index) = v
                item.Tag = v
                item.SubItems(1).Text = v.X
                item.SubItems(2).Text = v.Y
                item.SubItems(3).Text = v.Z
            Next
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If SelectedTrajectory IsNot Nothing Then
            Dim v As Vector3 = Vector3.Zero
            SelectedTrajectory.Points.Add(v)
            Dim lvi As New ListViewItem({"", v.X, v.Y, v.Z})
            lvi.Tag = v
            ListViewEx1.Items.Add(lvi)
            lvi.EnsureVisible()
            lvi.Selected = True
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If SelectedTrajectory IsNot Nothing Then
            Dim indicies As Integer() = New Integer(ListViewEx1.SelectedItems.Count - 1) {}
            ListViewEx1.SelectedIndices.CopyTo(indicies, 0)
            For Each index As Integer In indicies.OrderByDescending(Function(n) n)
                SelectedTrajectory.Points.RemoveAt(index)
                ListViewEx1.Items.RemoveAt(index)
            Next
        End If
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        MoveNode(-1)
    End Sub
    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        MoveNode(1)
    End Sub

    Private Sub MoveNode(additor As Integer)
        If additor <> 0 AndAlso SelectedTrajectory IsNot Nothing Then
            ListViewEx1.SuspendLayout()
            Dim indicies As Integer() = New Integer(ListViewEx1.SelectedIndices.Count - 1) {}
            ListViewEx1.SelectedIndices.CopyTo(indicies, 0)
            For Each index As Integer In If(additor < 0, indicies.OrderByDescending(Function(n) n), indicies.OrderBy(Function(n) n))
                Dim newIndex As Integer = index + additor
                If newIndex >= 0 AndAlso newIndex < ListViewEx1.Items.Count Then
                    Dim item As ListViewItem = ListViewEx1.Items(index)
                    ListViewEx1.Items.RemoveAt(index)
                    SelectedTrajectory.Points.RemoveAt(index)
                    ListViewEx1.Items.Insert(newIndex, item)
                    SelectedTrajectory.Points.Insert(newIndex, item.Tag)
                End If
            Next
            ListViewEx1.ResumeLayout()
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If SelectedTrajectory IsNot Nothing Then
            Dim sfd As New SaveFileDialog With {
                .Filter = "Textfile (*.txt)|*.txt",
                .FileName = SelectedTrajectory.Name.ToString & ".txt"
            }

            If sfd.ShowDialog = DialogResult.OK Then
                Dim sw As New StreamWriter(sfd.FileName)

                For Each v As Vector3 In SelectedTrajectory.Points
                    sw.WriteLine($"{v.X.ToString}, {v.Y.ToString}, {v.Z.ToString}")
                Next

                sw.Close()
            End If
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If SelectedTrajectory IsNot Nothing Then
            Dim ofd As New OpenFileDialog With {
                .Filter = "Textfile (*.txt)|*.txt"
            }

            If ofd.ShowDialog = DialogResult.OK Then
                Dim sr As New StreamReader(ofd.FileName)

                SelectedTrajectory.Points.Clear()

                Do Until sr.EndOfStream
                    Dim curLine As String = sr.ReadLine.Trim
                    If curLine IsNot Nothing Then
                        Dim parts As String() = curLine.Split(",")
                        Dim v As New Vector3(Convert.ToSingle(parts(0).Trim),
                                             Convert.ToSingle(parts(1).Trim),
                                             Convert.ToSingle(parts(2).Trim))
                        SelectedTrajectory.Points.Add(v)
                    End If
                Loop

                sr.Close()
                LoadTrajectory(SelectedTrajectory)
            End If
        End If
    End Sub

    Private Sub ListViewEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewEx1.SelectedIndexChanged
        If ListViewEx1.SelectedIndices.Count > 0 Then
            LoadNodeData(ListViewEx1.SelectedItems(0).Tag)
        End If
    End Sub

End Class
