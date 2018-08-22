Imports System.IO

Namespace ImporterPresets

    Public Class ImporterProfileManager

        Public Sub Save(profile As ImporterProfile, dir As String)
            Dim psmgr As New PatchScripts.PatchingManager
            Dim xml As XElement = <m64custom name=<%= profile.Name %> version=<%= profile.Version.ToString %>>
                                      <description><%= profile.Description %></description>
                                  </m64custom>

            For Each preset As ImporterPreset In profile.Presets
                Dim xpreset As XElement = <preset name=<%= preset.Name %>>
                                              <description><%= preset.Description %></description>
                                              <script></script>
                                              <max_length><%= preset.MaxLength.ToString("X") %></max_length>
                                              <rom_address><%= preset.RomAddress.ToString("X") %></rom_address>
                                              <ram_address><%= preset.RamAddress.ToString("X") %></ram_address>
                                          </preset>

                If preset.Script IsNot Nothing Then
                    Dim xscript As XElement = psmgr.ScriptToXElement(preset.Script)
                    xscript.Name = "script"
                    xpreset.Add(xscript)
                End If

                Dim xcolpointer As XElement = <collision_pointers></collision_pointers>
                For Each colpointer As Integer In preset.CollisionPointers
                    xcolpointer.Add(<ptr><%= colpointer.ToString("X") %></ptr>)
                Next
                xpreset.Add(xcolpointer)

                Dim xgeopointer As XElement = <geometry_pointers></geometry_pointers>
                For Each geopointer As Integer In preset.GeometryPointers
                    xgeopointer.Add(<ptr><%= geopointer.ToString("X") %></ptr>)
                Next
                xpreset.Add(xgeopointer)

                xml.Add(xpreset)
            Next

            If profile.FileName = "" Then
                profile.FileName = Path.Combine(dir, profile.Name & ".xml")
            End If

            xml.Save(profile.FileName)
        End Sub

        Public Function Read(fileName As String) As ImporterProfile
            Dim profile As New ImporterProfile
            Dim xml As XDocument = XDocument.Load(fileName)
            Dim mainNode As XElement = xml.Elements.FirstOrDefault(Function(n) n.Name = "m64custom")

            profile.FileName = fileName

            For Each attr As XAttribute In mainNode.Attributes
                Select Case attr.Name
                    Case "name"
                        profile.Name = attr.Value
                    Case "description"
                        profile.Name = attr.Value
                    Case "version"
                        profile.Version = New Version(attr.Value)
                End Select
            Next

            Dim mainPreset As New ImporterPreset
            Dim mainPreset_EnableCollision As Boolean = False

            For Each element As XElement In mainNode.Elements
                Select Case element.Name
                    Case "ram"
                        mainPreset.RamAddress = Convert.ToInt32(element.Value, 16)

                    Case "rom"
                        mainPreset.RomAddress = Convert.ToInt32(element.Value, 16)

                    Case "limit"
                        mainPreset.MaxLength = Convert.ToInt32(element.Value, 16) - mainPreset.RomAddress

                    Case "colpointer"
                        mainPreset.CollisionPointers.Add(Convert.ToInt32(element.Value, 16))

                    Case "collision"
                        mainPreset_EnableCollision = element.Value <> "0"

                    Case "geometry"
                        mainPreset.GeometryPointers.Add(Convert.ToInt32(element.Value, 16))

                    Case "extra"
                        Dim script As New PatchScripts.PatchScript
                        script.Name = "Extra Data"
                        script.Type = PatchScripts.ScriptType.TweakScript
                        script.Script = element.Value
                        mainPreset.Script = script

                    Case "preset"
                        mainPreset = Nothing
                        profile.Presets.Add(ParsePreset(element))

                    Case "description"
                        profile.Description = element.Value

                End Select
            Next

            If mainPreset IsNot Nothing Then
                If Not mainPreset_EnableCollision Then
                    mainPreset.CollisionPointers.Clear()
                End If
                profile.Presets.Add(mainPreset)
            End If

            If profile.Name = "" Then
                profile.Name = Path.GetFileNameWithoutExtension(fileName)
            End If

            Return profile
        End Function

        Private Function ParsePreset(xpreset As XElement) As ImporterPreset
            Dim preset As New ImporterPreset
            Dim psmgr As New PatchScripts.PatchingManager

            For Each attr As XAttribute In xpreset.Attributes
                Select Case attr.Name
                    Case "name"
                        preset.Name = attr.Value
                End Select
            Next

            For Each element As XElement In xpreset.Elements
                Select Case element.Name
                    Case "description"
                        preset.Description = element.Value

                    Case "script"
                        preset.Script = psmgr.XElementToScript(element)

                    Case "max_length"
                        preset.MaxLength = Convert.ToInt32(element.Value, 16)

                    Case "rom_address"
                        preset.RomAddress = Convert.ToInt32(element.Value, 16)

                    Case "ram_address"
                        preset.RamAddress = Convert.ToInt32(element.Value, 16)

                    Case "collision_pointers"
                        For Each xptr As XElement In element.Elements
                            preset.CollisionPointers.Add(Convert.ToInt32(xptr.Value, 16))
                        Next

                    Case "geometry_pointers"
                        For Each xptr As XElement In element.Elements
                            preset.GeometryPointers.Add(Convert.ToInt32(xptr.Value, 16))
                        Next

                End Select
            Next

            Return preset
        End Function

    End Class

End Namespace
