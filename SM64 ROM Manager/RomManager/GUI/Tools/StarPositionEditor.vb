Imports DevComponents.DotNetBar
Imports DevComponents.Editors
Imports SM64Lib
Imports SM64_ROM_Manager.My.Resources
Imports SM64Lib.Objects

Public Class StarPositionEditor

    Private curStar As StarPosition
    Private rommgr As RomManager

    Public Sub New(rommgr As RomManager)
        InitializeComponent()
        UpdateAmbientColors
        Me.rommgr = rommgr
    End Sub

    Private Sub StarPositionEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadList()
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        Dim item As ComboItem = ComboBoxEx1.SelectedItem
        curStar = New StarPosition(item.Tag)
        curStar.Position = GetPosition()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        curStar.Position = GetPosition()
        curStar.SavePosition(rommgr)
        PatchClass.UpdateChecksum(rommgr.RomFile)
        MessageBoxEx.Show(Star_Position_Editor_Ressources.MsgBox_Done, Star_Position_Editor_Ressources.MsgBox_Done_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#Region "Funktionen"

    Private Function GetPosition() As Numerics.Vector3
        Return New Numerics.Vector3(IntegerInput_X.Value, IntegerInput_Y.Value, IntegerInput_z.Value)
    End Function

    Private Sub LoadList()
        For Each value As StarNames In [Enum].GetValues(GetType(StarNames))
            ComboBoxEx1.Items.Add(New ComboItem With {.Text = GetTextOfStarName(value), .Tag = value})
        Next
        ComboBoxEx1.SelectedIndex = 0
    End Sub

    Private Function GetTextOfStarName(value As StarNames)
        Select Case value
            Case StarNames.KoopaTheQuick1 : Return "Koopa-The-Quick #1"
            Case StarNames.KoopaTheQuick2 : Return "Koopa-The-Quick #2"
            Case StarNames.KingBobOmbBoss : Return "Big Bob-Omb Boss"
            Case StarNames.WhompBoss : Return "Whomp Boss"
            Case StarNames.EyerockBoss : Return "Eyerock Boss"
            Case StarNames.BigBullyBoss : Return "Big Bully Boss"
            Case StarNames.ChillBullyBoss : Return "Chill Bully Boss"
            Case StarNames.GiantPiranhaPlants : Return "Giant Piranha Plants"
            Case StarNames.PenguinMother : Return "Penguin Mother and Race"
            Case StarNames.WigglerBoss : Return "Wiggler Boss"
            Case StarNames.PeachSlideStar : Return "Slide Star (Collision 33/34)"
            Case StarNames.BigPenguinRace : Return "Penguin Mother and Race"
            Case StarNames.TreasureChests : Return "4 Treasure Chests"
            Case StarNames.BooInHauntedHouse : Return "First Big Boo"
            Case StarNames.Klepto : Return "Klepto"
            Case StarNames.MerryGoRoundboss : Return "Merry-Go-Round Boo"
            Case StarNames.MrIboss : Return "Mr. I. Boss"
            Case StarNames.RooftopBoo : Return "Rooftop Boo"
            Case StarNames.SecondactBigBully : Return "Second Big Bully in LLL"
            Case Else : Return ""
        End Select
    End Function

#End Region

End Class