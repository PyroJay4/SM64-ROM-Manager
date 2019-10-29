Imports DevComponents.Editors
Imports SM64_ROM_Manager.ModelConverterGUI.My.Resources
Imports SM64_ROM_Manager.Publics
Imports SM64Lib.Geolayout
Imports SM64Lib.Model

Public Module PublicFunctions

    Public Function GetModelViaModelConverter(Optional allowCheckingVisualMap As Boolean? = Nothing, Optional allowCheckingCollision As Boolean? = Nothing, Optional loadVisualMapAsDefault As Boolean? = Nothing, Optional loadCollisionAsDefault As Boolean? = Nothing, Optional forceDisplaylist As SByte? = Nothing, Optional inputsKey As String = "") As (mdl As ObjectModel, hasVisualMap As Boolean, hasCollision As Boolean)?
        Dim frm As New MainModelConverter

        If loadVisualMapAsDefault IsNot Nothing Then
            frm.CheckBoxX_ConvertModel.Checked = loadVisualMapAsDefault
        End If

        If loadCollisionAsDefault IsNot Nothing Then
            frm.CheckBoxX_ConvertCollision.Checked = loadCollisionAsDefault
        End If

        If allowCheckingVisualMap IsNot Nothing Then
            frm.CheckBoxX_ConvertModel.Enabled = allowCheckingVisualMap
        End If

        If allowCheckingCollision IsNot Nothing Then
            frm.CheckBoxX_ConvertCollision.Enabled = allowCheckingCollision
        End If

        If forceDisplaylist IsNot Nothing Then
            frm.ForceDisplaylist = forceDisplaylist
        End If

        If frm.ShowDialog(GetObjectInputSettingsOrDefault(inputsKey)) = Windows.Forms.DialogResult.OK Then
            StoreObjectInputSettings(inputsKey, frm.GuiInputSettings)
            Return (frm.ResModel, frm.CheckBoxX_ConvertModel.Checked, frm.CheckBoxX_ConvertCollision.Checked)
        Else
            Return Nothing
        End If
    End Function

    Friend Function GetDefaultGeolayerComboItems() As ComboItem()
        Return {
            New ComboItem With {.Text = $"0 - {MainModelconverter_Resources.Layer0}", .Tag = DefaultGeolayers.SolidAntiAlias},
            New ComboItem With {.Text = $"1 - {MainModelconverter_Resources.Layer1}", .Tag = DefaultGeolayers.Solid},
            New ComboItem With {.Text = $"2 - {MainModelconverter_Resources.Layer2}", .Tag = DefaultGeolayers.SolidDecal},
            New ComboItem With {.Text = $"3 - {MainModelconverter_Resources.Layer3}", .Tag = DefaultGeolayers.TranslucentDecal},
            New ComboItem With {.Text = $"4 - {MainModelconverter_Resources.Layer4}", .Tag = DefaultGeolayers.Alpha},
            New ComboItem With {.Text = $"5 - {MainModelconverter_Resources.Layer5}", .Tag = DefaultGeolayers.Transparent},
            New ComboItem With {.Text = $"6 - {MainModelconverter_Resources.Layer6}", .Tag = DefaultGeolayers.TransparentForeground},
            New ComboItem With {.Text = $"7 - {MainModelconverter_Resources.Layer7}", .Tag = DefaultGeolayers.TranslucentDecal2}
            }
    End Function

End Module
