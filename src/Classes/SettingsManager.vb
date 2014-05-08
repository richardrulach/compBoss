Imports System.IO


Public Class SettingsManager

    Private cwdString As String = String.Empty
    Private strCurrentSettingsFile As String = String.Empty

    Public Sub New()
        ' initialise logfile if it isn't there.
        cwdString = Directory.GetCurrentDirectory
        Console.WriteLine(cwdString)

        CheckSettingsFile()
        LoadSettingsFile()
    End Sub

#Region "Private Subs/Functions"

#Region "Settings file manipulation"

    ' If settings directory and file do not exist, create them
    Private Sub CheckSettingsFile()

        If Not Directory.Exists(cwdString + "\Settings") Then
            Directory.CreateDirectory(cwdString + "\Settings")
        End If

        If Not File.Exists(cwdString + "\Settings\CompressionBoss.settings") Then
            File.CreateText(cwdString + "\Settings\CompressionBoss.settings")
        End If

        strCurrentSettingsFile = cwdString + "\Settings\CompressionBoss.settings"
    End Sub

    '  Load the settings from the file
    '  Validate files - if they do not exist remove them from the settings file
    Private Sub LoadSettingsFile()

    End Sub

    Private Sub SaveSettingsFile()

    End Sub


#End Region

#End Region


#Region "Public Subs/Functions"
    ' write the text to the log file
    Public Sub AddFileSetting(sText As String)

    End Sub

    Public Sub SaveSettings(sText As String)

    End Sub

    ' archive the settings file
    ' also perform maintenance - delete old settings files (over 1 week old)
    Private Sub ArchiveSettings()

    End Sub
#End Region




End Class
