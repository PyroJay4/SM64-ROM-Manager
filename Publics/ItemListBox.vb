Imports DevComponents.DotNetBar

Namespace Controls

    Public Class ItemListBox
        Inherits ItemPanel

        Public Event SelectedItemChanged(sender As Object, e As EventArgs)

        Public Sub New()
            MyBase.New
        End Sub

        Private Sub UpdateCheckState() Handles Me.MouseClick
            Dim toUncheck As New List(Of ButtonItem)
            Dim toCheck As New List(Of ButtonItem)

            For Each item As BaseItem In Me.Items
                Dim bi As ButtonItem = TryCast(item, ButtonItem)
                If bi IsNot Nothing Then
                    If bi.IsMouseOver Then
                        If Not bi.Checked Then
                            toCheck.Add(bi)
                        End If
                    ElseIf bi.Checked Then
                        toUncheck.Add(bi)
                    End If
                End If
            Next

            If toCheck.Count > 0 Then
                For Each item As ButtonItem In toUncheck
                    item.Checked = False
                Next
                For Each item As ButtonItem In toCheck
                    item.Checked = True
                Next
            End If

            If toCheck.Count > 0 OrElse toUncheck.Count > 0 Then
                RaiseEvent SelectedItemChanged(Me, New EventArgs)
            End If
        End Sub

        Public Overloads Property SelectedItem As BaseItem
            Get
                For i As Integer = 0 To Items.Count - 1
                    Dim bi As ButtonItem = TryCast(Items(i), ButtonItem)
                    If bi IsNot Nothing Then
                        If bi.Checked Then Return bi
                    End If
                Next
                Return Nothing
            End Get
            Set(value As BaseItem)
                For Each item As BaseItem In Me.Items
                    Dim bi As ButtonItem = TryCast(item, ButtonItem)
                    If bi IsNot Nothing Then
                        bi.Checked = bi Is value
                    End If
                Next

                RaiseEvent SelectedItemChanged(Me, New EventArgs)
            End Set
        End Property

        Public Overloads Property SelectedIndex As Integer
            Get
                Return MyBase.SelectedIndex
            End Get
            Set(value As Integer)
                Dim wasNotDifferent As Boolean = MyBase.SelectedIndex = value

                MyBase.SelectedIndex = value

                For i As Integer = 0 To Items.Count - 1
                    Dim bi As ButtonItem = TryCast(Items(i), ButtonItem)
                    If bi IsNot Nothing Then
                        If i = value Then
                            If Not bi.Checked Then bi.Checked = True
                        Else
                            If bi.Checked Then bi.Checked = False
                        End If
                    End If
                Next

                If wasNotDifferent Then
                    RaiseEvent SelectedItemChanged(Me, New EventArgs)
                End If
            End Set
        End Property

    End Class

End Namespace
