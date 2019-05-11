Imports System.Drawing
Imports System.IO
Imports SM64Lib.Data

Namespace NPCs

    Public Class CoinsManager

        Public ReadOnly Property RomManager As RomManager

        Public Property CoinsForRedCoinsStar As Short = 8
        Public Property CoinsForBowserRedCoinsStar As Short = 8
        Public Property CoinsFor100CoinsStar As Byte = 0
        Public Property Enable100CoinsStar As Boolean = True
        Public Property EnableCoinCounterInHubs As Boolean = False
        Public Property CoinsRestoreHealth As Boolean = True
        Public Property EnableNewRedCoinsCounter As Boolean = False
        Public Property NewRedCoinsCounterTextForCoins As String = ""
        Public Property NewRedCoinsCounterTextForCoin As String = ""

        Public Sub New(rommgr As RomManager)
            RomManager = rommgr
        End Sub

        ''' <summary>
        ''' Loads all the properties from ROM.
        ''' </summary>
        Public Sub LoadCoinSettings()
            Dim data As BinaryData = RomManager.GetBinaryRom(IO.FileAccess.Read)

            'Coins for Red Coins Star
            data.Position = &HADDDE
            CoinsForRedCoinsStar = data.ReadInt16

            'Coins for Bowser Red Coins Star
            data.Position = &HADF82
            CoinsForBowserRedCoinsStar = data.ReadInt16

            'Coins for 100 Coins Star
            data.Position = &H8BB3
            CoinsFor100CoinsStar = data.ReadByte

            'Enable 100 Coins
            data.Position = &H8BC8
            Enable100CoinsStar = data.ReadInt32 <> 0

            'Enable Coins Counter in Hubs
            data.Position = &H61AB
            EnableCoinCounterInHubs = data.ReadByte = &HFF

            'Coins restore health
            data.Position = &H8B70
            CoinsRestoreHealth = data.ReadInt32 <> 0

            'Enable New Red Coins Counter
            data.Position = &H966E8
            EnableNewRedCoinsCounter = data.ReadInt32 = &H27BDFFE8

            'New Red Coins Counter Text For Coins
            If EnableNewRedCoinsCounter Then
                data.Position = &H69908
                NewRedCoinsCounterTextForCoins = System.Text.Encoding.ASCII.GetString(data.Read(&H10)).Trim
            Else
                NewRedCoinsCounterTextForCoins = "%d RED COINS"
            End If

            'New Red Coins Counter Text For Coins
            If EnableNewRedCoinsCounter Then
                data.Position = &H69918
                NewRedCoinsCounterTextForCoin = System.Text.Encoding.ASCII.GetString(data.Read(&H10)).Trim
            Else
                NewRedCoinsCounterTextForCoin = "%d RED COIN"
            End If

            data.Close()
        End Sub

        ''' <summary>
        ''' Saves all the properties to ROM and updates checksum.
        ''' </summary>
        Public Sub SaveCoinSettings()
            SaveCoinSettings(True)
        End Sub

        ''' <summary>
        ''' Saves all the properties to ROM and updates checksum if requested.
        ''' </summary>
        Public Sub SaveCoinSettings(updateChecksum As Boolean)
            Dim data As BinaryData = RomManager.GetBinaryRom(IO.FileAccess.ReadWrite)

            'Coins for Red Coins Star
            data.Position = &HADDDE
            data.Write(CoinsForRedCoinsStar)

            'Coins for Bowser Red Coins Star
            data.Position = &HADF82
            data.Write(CoinsForBowserRedCoinsStar)

            'Coins for 100 Coins Star
            data.Position = &H8BB3
            data.Write(CoinsFor100CoinsStar)
            data.Position = &H8BBF
            data.Write(CoinsFor100CoinsStar)
            data.Position = &H8BB4
            data.Write(&H1020S)

            'Enable 100 Coins
            data.Position = &H8BC8
            If Enable100CoinsStar Then
                data.Write(&HC0AAD56)
            Else
                data.Write(0)
            End If

            'Enable Coins Counter in Hubs
            data.Position = &H61AB
            If EnableCoinCounterInHubs Then
                data.WriteByte(&HFF)
            Else
                data.WriteByte(&HFD)
            End If

            'Coins restore health
            data.Position = &H8B70
            If CoinsRestoreHealth Then
                data.Write(&HA13800B3)
            Else
                data.Write(0)
            End If

            'Enable New Red Coins Counter
            data.Position = &H966E8
            Dim nrccCode As String
            If EnableNewRedCoinsCounter Then
                nrccCode = "27 BD FF E8 AF BF 00 14 3C 0E 80 36 81 C7 13 FE 10 E0 00 10 00 00 00 00 24 01 00 01 10 E1 00 08 00 00 00 00 24 05 00 24 3C 06 80 2A 34 C6 E9 08 0C 0B 58 B6 24 04 00 A0 10 00 00 06 00 00 00 00 24 05 00 24 3C 06 80 2A 34 C6 E9 18 0C 0B 58 B6 24 04 00 A0 8F BF 00 14 03 E0 00 08 27 BD 00 18"
            Else
                nrccCode = "27 BD FF E0 AF BF 00 14 3C 0E 80 36 81 CE 13 FE A3 A0 00 1F 19 C0 00 12 00 00 00 00 83 AF 00 1F 24 19 01 22 24 05 00 10 00 0F C0 80 03 0F C0 21 00 18 C0 80 0C 0B 6D 26 03 38 20 23 83 A8 00 1F 3C 0C 80 36 81 8C 13 FE 25 09 00 01 00 09 56 00 00 0A 5E 03 01 6C 08 2A 14 20 FF F0 A3 A9 00 1F"
            End If
            For Each b As String In nrccCode.Split(" ")
                data.Write(Convert.ToByte(b, 16))
            Next

            'New Red Coins Counter Text For Coins
            If EnableNewRedCoinsCounter Then
                data.Position = &H69908
                data.Write(System.Text.Encoding.ASCII.GetBytes(FillStrToCharCount(NewRedCoinsCounterTextForCoins, &H10, " ")))
            End If

            'New Red Coins Counter Text For Coins
            If EnableNewRedCoinsCounter Then
                data.Position = &H69918
                data.Write(System.Text.Encoding.ASCII.GetBytes(FillStrToCharCount(NewRedCoinsCounterTextForCoin, &H10, " ")))
            End If

            data.Close()

            'Update checksum (because of code changes)
            If updateChecksum Then
                PatchClass.UpdateChecksum(RomManager.RomFile)
            End If
        End Sub

        ''' <summary>
        ''' Imports Kazes 3D Coins
        ''' </summary>
        Public Sub ImportKazesCoins()
            Dim ppf As String = MyFilePaths("Apply 3D Coins.ppf")
            PatchClass.ApplyPPF(RomManager.RomFile, ppf)
            PatchClass.UpdateChecksum(RomManager.RomFile)
        End Sub

        ''' <summary>
        ''' Remove 3D Coins [Experimental]
        ''' </summary>
        Public Sub Remove3DCoins()
            Dim ppf As String = MyFilePaths("Remove 3D Coins.ppf")
            PatchClass.ApplyPPF(RomManager.RomFile, ppf)
            PatchClass.UpdateChecksum(RomManager.RomFile)
        End Sub

    End Class

End Namespace
