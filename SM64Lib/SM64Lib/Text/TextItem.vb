Imports System.IO
Imports System.Windows.Forms

Namespace Global.SM64Lib.Text

    Public Class TextItem
        Private TextBytes() As Byte = {}
        Private DialogParams As Boolean = False
        Public ReadOnly Property DialogParametersEnabled As Boolean
            Get
                Return DialogParams
            End Get
        End Property
        Private Lines As Integer = 4
        Public Property LinesPerSite As Integer
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return Lines
            End Get
            Set(value As Integer)
                If Not DialogParams Then Throw New NotADialogItem
                Lines = value
            End Set
        End Property
        Private VPosition As Int16 = 0
        Public Property VerticalPosition As VPos
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return VPosition
            End Get
            Set(value As VPos)
                If Not DialogParams Then Throw New NotADialogItem
                VPosition = value
            End Set
        End Property
        Private HPosition As Int16 = 0
        Public Property HorizontalPosition As HPos
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return HPosition
            End Get
            Set(value As HPos)
                If Not DialogParams Then Throw New NotADialogItem
                HPosition = value
            End Set
        End Property
        Private _UnknownValue As Byte = 0
        Public Property UnknownValue As Byte
            Get
                If Not DialogParams Then Throw New NotADialogItem
                Return _UnknownValue
            End Get
            Set(value As Byte)
                If Not DialogParams Then Throw New NotADialogItem
                _UnknownValue = value
            End Set
        End Property

        Public Sub New(TextBytes As Byte(), Optional EnableDialogParameters As Boolean = False)
            Me.TextBytes = TextBytes
            DialogParams = EnableDialogParameters
        End Sub

        Public Sub New(Text As String, Optional EnableDialogParameters As Boolean = False)
            Me.Text = Text
            DialogParams = EnableDialogParameters
        End Sub

        Public Property Text As String
            Get
                Return Encoding.GetString(TextBytes)
            End Get
            Set(value As String)
                TextBytes = Encoding.GetBytes(value)
            End Set
        End Property

        Public Function ToByteArray() As Byte()
            Return TextBytes
        End Function

        Public ReadOnly Property DataLenght As Integer
            Get
                Return TextBytes.Count
            End Get
        End Property

        Public Class NotADialogItem
            Inherits Exception
            Public Sub New()
                MyBase.New("This Text Item is not a dialog item. Some parameter are not aviable.")
            End Sub
        End Class

        Public Enum VPos As Int16
            Left = &H1E
            Centred = &H5F
            Right = &H96
        End Enum
        Public Enum HPos As Int16
            Middle = &H96
            Top = &HC8
        End Enum
    End Class

End Namespace
