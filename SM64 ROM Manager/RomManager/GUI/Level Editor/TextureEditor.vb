Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Validator
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports SM64_ROM_Manager.Publics.My.Resources
Imports Pilz.S3DFileParser
Imports SM64Lib
Imports SM64Lib.Data
Imports SM64_ROM_Manager.SettingsManager
Imports SM64Lib.Model.Conversion.Fast3DParsing

Namespace LevelEditor

    Public Class TextureEditor

        Public Event TextureReplaced(sender As Object, e As EventArgs)

        Private ReadOnly rommgr As RomManager = Nothing
        Private lastClickedButton As ButtonItem = Nothing
        Private lastPictureBox As PictureBox = Nothing

        Public Sub New(rommgr As RomManager, categories As TextureCategory())
            Me.rommgr = rommgr
            InitializeComponent()
            LoadCategories(categories)
            UpdateAmbientColors

            'Set dark background for light theme
            If Settings.StyleManager.IsWhiteTheme Then
                BackColor = StyleManagerSettingsStruc.VisualThemeGray.CanvasColor
            End If
        End Sub

        Private ReadOnly Property CurBlock As TextureBlock
            Get
                Return TryCast(lastClickedButton?.Tag, TextureBlock)
            End Get
        End Property

        Private ReadOnly Property CurTexture As Material
            Get
                Return TryCast(lastPictureBox?.Tag, Material)
            End Get
        End Property

        Private ReadOnly Property CurTextureInfo As TextureLoadedInfos
            Get
                Return TryCast(CurTexture?.Tag, TextureLoadedInfos)
            End Get
        End Property

        Private Sub LoadCategories(categories As TextureCategory())
            For Each cat As TextureCategory In categories
                Dim pnl As New SideBarPanelItem With {
                    .Text = cat.Name
                }

                For Each b As TextureBlock In cat.Blocks
                    Dim btn As New ButtonItem With {
                        .Tag = b,
                        .Text = b.Name,
                        .ColorTable = eButtonColor.Orange
                    }

                    AddHandler btn.Click, AddressOf ButtonItem_Clicked
                    AddHandler btn.MouseUp, AddressOf ButtonItem_MouseUp

                    pnl.SubItems.Add(btn)
                Next

                SideBar1.Panels.Add(pnl)
            Next
        End Sub

        Private Sub LoadTexturesFromCategorie()
            LoadTexturesFromCategorie(CurBlock)
        End Sub

        Private Sub LoadTexturesFromCategorie(block As TextureBlock)
            Dim controls As Control() = New Control(FlowLayoutPanel_Textures.Controls.Count - 1) {}
            FlowLayoutPanel_Textures.Controls.CopyTo(controls, 0)
            For Each c As Control In controls
                If TypeOf c Is PictureBox Then
                    Highlighter1.SetHighlightColor(c, eHighlightColor.None)
                    FlowLayoutPanel_Textures.Controls.Remove(c)
                End If
            Next

            For Each mat As Material In block.Textures
                Dim info = TryCast(mat.Tag, TextureLoadedInfos)

                Dim pb As New PictureBox With {
                    .Image = mat.Image,
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .Tag = mat,
                    .Size = New Size(70, 70)
                }

                AddHandler pb.Click, AddressOf PictureBox_Clicked
                AddHandler pb.MouseEnter, AddressOf PictureBox_MouseEnter
                AddHandler pb.MouseLeave, AddressOf PictureBox_MouseLeave
                AddHandler pb.MouseClick, AddressOf PictureBox_MouseClick

                Dim lbl As New LabelX With {
                    .Text = info.Name,
                    .Size = New Size(70, 14),
                    .Location = New Drawing.Point(1, 55),
                    .TextAlignment = StringAlignment.Center
                }
                pb.Controls.Add(lbl)

                AddHandler lbl.Click, Sub(sender, e) PictureBox_Clicked(pb, e)
                AddHandler lbl.MouseEnter, Sub(sender, e) PictureBox_MouseEnter(pb, e)
                AddHandler lbl.MouseLeave, Sub(sender, e) PictureBox_MouseLeave(pb, e)
                AddHandler lbl.MouseClick, Sub(sender, e) PictureBox_MouseClick(pb, e)

                FlowLayoutPanel_Textures.Controls.Add(pb)
            Next
        End Sub

        Private Sub ButtonItem_Clicked(sender As Object, e As EventArgs)
            If lastClickedButton IsNot Nothing Then lastClickedButton.Checked = False
            lastClickedButton = sender
            lastClickedButton.Checked = True
            LoadTexturesFromCategorie()
        End Sub

        Private Sub ButtonItem_MouseUp(sender As ButtonItem, e As MouseEventArgs)
            If sender.Checked AndAlso e.Button = MouseButtons.Right Then
                ButtonItem2.Popup(Cursor.Position)
            End If
        End Sub

        Private Sub PictureBox_Clicked(sender As Object, e As EventArgs)
            If lastPictureBox IsNot sender Then
                If lastPictureBox IsNot Nothing Then
                    Highlighter1.SetHighlightColor(lastPictureBox, eHighlightColor.None)
                End If
                lastPictureBox = sender
                Highlighter1.SetHighlightColor(lastPictureBox, eHighlightColor.Green)
                ShowTextureInfos()
            End If
        End Sub

        Private Sub PictureBox_MouseEnter(sender As Object, e As EventArgs)
            If Highlighter1.GetHighlightColor(sender) = eHighlightColor.None Then
                Highlighter1.SetHighlightColor(sender, eHighlightColor.Blue)
            End If
        End Sub

        Private Sub PictureBox_MouseLeave(sender As Object, e As EventArgs)
            If Highlighter1.GetHighlightColor(sender) = eHighlightColor.Blue Then
                Highlighter1.SetHighlightColor(sender, eHighlightColor.None)
                'FlowLayoutPanel1.Refresh()
            End If
        End Sub

        Private Sub PictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox_CurImage.MouseClick
            If TypeOf sender Is PictureBox AndAlso CType(sender, PictureBox).Image IsNot Nothing Then
                If e.Button = MouseButtons.Right Then
                    ButtonItem1.Popup(Cursor.Position)
                End If
            End If
        End Sub

        Private Sub ClearTexturesPanel()
            Dim controls As Control() = New Control(FlowLayoutPanel_Textures.Controls.Count - 1) {}
            FlowLayoutPanel_Textures.Controls.CopyTo(controls, 0)

            For Each c As Control In controls
                FlowLayoutPanel_Textures.Controls.Remove(c)
            Next
        End Sub

        Private Sub ShowTextureInfos()
            Dim info = CurTextureInfo
            Dim tex = CurTexture

            If info IsNot Nothing AndAlso tex IsNot Nothing Then
                PictureBox_CurImage.Image = tex.Image
                AdvPropertyGrid1.SelectedObject = info
            End If
        End Sub

        Private Sub ButtonItem_ExpTex_Click(sender As Object, e As EventArgs) Handles ButtonItem_ExpTex.Click
            Dim sfd As New SaveFileDialog With {
                .Filter = FileDialogFilters.FilterPictureFormats_Single,
                .FileName = CurTextureInfo.Name
            }

            If sfd.ShowDialog = DialogResult.OK Then
                ExportTexture(sfd.FileName)
            End If
        End Sub

        Private Sub ButtonItem_ImpTex_Click(sender As Object, e As EventArgs) Handles ButtonItem_ImpTex.Click
            If CurTextureInfo.IsReadOnly Then
                MessageBoxEx.Show("This texture is read-only. Probably it was loaded from a compressed MIO0-Bank.", "Import Texture", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim ofd As New OpenFileDialog With {
                    .Filter = FileDialogFilters.FilterPictureFormats_All & "|" & FileDialogFilters.FilterPictureFormats_Single
                }

                If ofd.ShowDialog = DialogResult.OK Then
                    ImportTexture(ofd.FileName, CurTexture)
                    RaiseEvent TextureReplaced(Me, New EventArgs)
                End If
            End If
        End Sub

        Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
            Dim ofd As New CommonOpenFileDialog With {
                .IsFolderPicker = True,
                .DefaultFileName = CurBlock.Name
            }

            If ofd.ShowDialog = CommonFileDialogResult.Ok Then
                Dim filterselector As New Publics.FilesFilterDialog With {
                    .Filter = FileDialogFilters.FilterPictureFormats_Single
                }

                If filterselector.ShowDialog = DialogResult.OK Then
                    ExportAllTextures(ofd.FileName, filterselector.FileExtension.Substring(1))
                End If
            End If
        End Sub

        Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
            Dim ofd As New CommonOpenFileDialog With {
                .IsFolderPicker = True,
                .DefaultFileName = CurBlock.Name
            }

            If ofd.ShowDialog = CommonFileDialogResult.Ok Then
                ImportAllTextures(ofd.FileName, FileDialogFilters.FilterPictureFormats_All.Substring(FileDialogFilters.FilterPictureFormats_All.IndexOf("|") + 1))
            End If
        End Sub

        Private Sub ExportAllTextures(outputDirectory As String, fileExtension As String)
            For Each tex In CurBlock.Textures
                Dim outFile As String = Path.Combine(outputDirectory, LegalizeFilePath(CType(tex.Tag, TextureLoadedInfos).Name) & fileExtension)
                ExportTexture(outFile, tex)
            Next
        End Sub

        Private Function LegalizeFilePath(str As String) As String
            Dim illegalChars As Char() = Path.GetInvalidFileNameChars

            For Each c As Char In illegalChars
                Dim cs As String = Char.ToString(c)
                Select Case c
                    Case """"c
                        str = str.Replace(cs, "_highcome_")
                    Case "|"c
                        str = str.Replace(cs, "_sep_")
                    Case "<"c
                        str = str.Replace(cs, "_quakauf_")
                    Case ">"c
                        str = str.Replace(cs, "_quakzu_")
                    Case ":"c
                        str = str.Replace(cs, "_dp_")
                    Case "*"c
                        str = str.Replace(cs, "_star_")
                    Case "?"c
                        str = str.Replace(cs, "_qm_")
                    Case "/"c
                        str = str.Replace(cs, "_rsep_")
                    Case "\"c
                        str = str.Replace(cs, "_lsep_")
                End Select
            Next

            Return str
        End Function

        Private Sub ImportAllTextures(inputDirecotry As String, extensionFilter As String)
            Dim files As String() = Directory.GetFiles(inputDirecotry)

            For Each tex In CurBlock.Textures
                Dim info As TextureLoadedInfos = tex.Tag
                Dim legalizedName As String = LegalizeFilePath(info.Name)
                Dim f As String = files.FirstOrDefault(Function(n) Path.GetFileNameWithoutExtension(n) = legalizedName)

                If Not String.IsNullOrEmpty(f) AndAlso Not info.IsReadOnly Then
                    ImportTexture(f, tex)
                End If

                RaiseEvent TextureReplaced(Me, New EventArgs)
            Next
        End Sub

        Private Sub ExportTexture(outputFile As String)
            ExportTexture(outputFile, CurTexture)
        End Sub

        Private Sub ExportTexture(outputFile As String, tex As Material)
            tex.Image.Save(outputFile)
        End Sub

        Private Sub ImportTexture(inputFile As String, mat As Material)
            Dim texdata As Byte() = Nothing
            Dim palette As Byte() = Nothing
            Dim info As TextureLoadedInfos = mat.Tag
            Dim fs As New FileStream(inputFile, FileMode.Open, FileAccess.Read)
            Dim img1 As Image = Image.FromFile(inputFile)
            Dim img As New Bitmap(img1)

            img1.Dispose()
            fs.Close()

            'Resize image to fit current one
            If mat.Image.Size <> img.Size Then
                img = Model.Fast3D.ResizeImage(img, mat.Image.Size)
            End If

            'Convert Image to N64 Texture
            N64Graphics.N64Graphics.Convert(texdata, palette, info.TextureFormat, img)

            'Write Texture & Palete Data to ROM
            Dim rom As BinaryRom = rommgr.GetBinaryRom(FileAccess.ReadWrite)
            rom.Position = info.TextureRomAddress
            rom.Write(texdata)
            If palette IsNot Nothing Then
                rom.Position = info.TexturePaletteRomAddress
                rom.Write(palette)
            End If
            rom.Close()

            'Set new Image to Material
            mat.Image = img

            'Set new Image to PictureBox
            Dim pb As PictureBox = SearchPictureBoxByMaterial(mat)
            If pb IsNot Nothing Then
                pb.Image = img
            End If

            'Reload Texture Info
            ShowTextureInfos()
        End Sub

        Private Function SearchPictureBoxByMaterial(mat As Material) As PictureBox
            For Each c As Control In FlowLayoutPanel_Textures.Controls
                If TypeOf c Is PictureBox AndAlso CType(c?.Tag, Material) Is mat Then
                    Return c
                End If
            Next
            Return Nothing
        End Function

        Public Class TextureBlock
            Public Property Name As String = ""
            Public ReadOnly Property Textures As New List(Of Material)
        End Class

        Public Class TextureCategory
            Public Property Name As String = ""
            Public ReadOnly Property Blocks As New List(Of TextureBlock)
        End Class

    End Class

End Namespace
