Imports System.IO
Imports SM64Lib.Data
Imports SM64Lib.Text.Profiles

Namespace Text

    Public Class TextArrayGroup
        Inherits TextGroup

        Default Public Overloads ReadOnly Property Item(index As Integer) As TextArrayItem
            Get
                Return MyBase.Item(index)
            End Get
        End Property

        Public Overloads ReadOnly Property TextGroupInfo As TextArrayGroupInfo
            Get
                Return MyBase.TextGroupInfo
            End Get
        End Property

        Public Sub New(groupInfo As TextArrayGroupInfo)
            MyBase.New(groupInfo)
        End Sub

        Public Overrides Sub Read(data As BinaryData)
            For Each info As TextArrayItemInfo In TextGroupInfo.Texts
                Add(GetTextItem(data, info))
            Next
        End Sub

        Private Function GetTextItem(data As BinaryData, info As TextArrayItemInfo) As TextArrayItem
            Dim tempByte As Byte = 0
            Dim byteBuffer As New List(Of Byte)
            Dim ende As Boolean = False

            data.Position = info.RomAddress

            Do Until ende
                tempByte = data.ReadByte
                byteBuffer.Add(tempByte)

                If byteBuffer.Count >= info.MaxLength OrElse
                    (TextGroupInfo.Encoding Is M64TextEncoding.M64Text AndAlso tempByte = &HFF) Then
                    ende = True
                End If
            Loop

            Dim newItem As New TextArrayItem(byteBuffer.ToArray, TextGroupInfo, info)
            byteBuffer.Clear()

            Return newItem
        End Function

        Public Overrides Sub Save(data As BinaryData)
            For Each item As TextArrayItem In Me
                data.Position = item.ItemInfo.RomAddress
                WriteTextItem(data, item)
            Next
        End Sub

        Private Sub WriteTextItem(data As BinaryData, item As TextArrayItem)
            data.Position = item.ItemInfo.RomAddress

            For i As Integer = 0 To Math.Min(item.Data.Length, item.ItemInfo.MaxLength) - 1
                Dim b As Byte = item.Data(i)
                data.WriteByte(b)
            Next

            If item.TextGroupInfo.Encoding Is System.Text.Encoding.ASCII Then
                For i As Integer = data.Position To item.ItemInfo.RomAddress + item.ItemInfo.MaxLength
                    data.WriteByte(20)
                Next
            End If
        End Sub

    End Class

End Namespace
