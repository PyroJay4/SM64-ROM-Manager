Imports SM64_ROM_Manager.Publics
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

End Module
