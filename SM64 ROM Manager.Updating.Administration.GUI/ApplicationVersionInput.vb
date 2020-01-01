Imports DevComponents.Editors
Imports SM64_ROM_Manager.Updating.Administration.GUI.My.Resources.UpdatingAdministrationLangRes

Public Class ApplicationVersionInput

    'C o n s t r u c t o r s

    Public Sub New()
        InitializeComponent()

        'Init Channel-ComboBox
        ComboBoxEx_Channel.Items.Add(New ComboItem With {.Text = Channel_Stable, .Tag = Channels.Stable})
        ComboBoxEx_Channel.Items.Add(New ComboItem With {.Text = Channel_PreRelease, .Tag = Channels.PreRelease})
        ComboBoxEx_Channel.Items.Add(New ComboItem With {.Text = Channel_Beta, .Tag = Channels.Beta})
        ComboBoxEx_Channel.Items.Add(New ComboItem With {.Text = Channel_Alpha, .Tag = Channels.Alpha})
        ComboBoxEx_Channel.SelectedIndex = 0
    End Sub

    'P r o p e r t i e s

    Public Property VersionName As String
        Get
            Return TextBoxX_VersionName.Text
        End Get
        Set
            TextBoxX_VersionName.Text = Value
        End Set
    End Property

    Public Property Version As Version
        Get
            Return New Version(TextBoxX_Version.Text.Trim)
        End Get
        Set
            TextBoxX_Version.Text = Value.ToString
        End Set
    End Property

    Public Property Channel As Channels
        Get
            Return CType(ComboBoxEx_Channel.SelectedItem, ComboItem).Tag
        End Get
        Set
            For Each ci As ComboItem In ComboBoxEx_Channel.Items
                If ci.Tag = Value Then
                    ComboBoxEx_Channel.SelectedItem = ci
                End If
            Next
        End Set
    End Property

    Public Property Build As UInteger
        Get
            Return IntegerInput_Build.Value
        End Get
        Set
            IntegerInput_Build.Value = Value
        End Set
    End Property

End Class