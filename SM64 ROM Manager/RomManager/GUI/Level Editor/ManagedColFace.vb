Imports System.ComponentModel
Imports Pilz.S3DFileParser

Namespace LevelEditor

    Public Class ManagedColFace

        <Browsable(False)>
        Public ReadOnly Face As Face

        Public Sub New(face As Face)
            Me.Face = face
        End Sub

        <Category("")>
        <DisplayName("Collision Type")>
        Public Property CollisionType As Byte
            Get
                Return Face.Tag
            End Get
            Set(value As Byte)
                Face.Tag = value
            End Set
        End Property

    End Class

End Namespace
