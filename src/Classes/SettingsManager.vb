Imports System.IO

Public Structure FileSetting
    Public sourceFileName As String
    Public outputFileName As String
    Public lastProcessed As DateTime
End Structure

Public Class SettingsManager

#Region "Private Properties"
    Private cwdString As String = String.Empty
    Private strCurrentSettingsFile As String = String.Empty
    Private FileSettingsArray As ArrayList = New ArrayList()
#End Region

#Region "Constructors"
    Public Sub New()
        ' initialise logfile if it isn't there.
        cwdString = Directory.GetCurrentDirectory
        Console.WriteLine("cwd = " + cwdString)

        CheckSettingsFile()
        LoadSettingsFile()
    End Sub
#End Region

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

        'Dim a As FileSetting

        'a = New FileSetting
        'a.sourceFileName = "source 1"
        'a.outputFileName = "output 1"

        'For i As Int32 = 1 To 20
        '    FileSettingsArray.Add(a)
        'Next

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

    Public Sub AddSourceFile(filePath As String)
        Console.WriteLine("filepath = " + filePath)

        If File.Exists(filePath) Then
            Dim newFile As FileSetting
            Dim lFile As New FileInfo(filePath)
            newFile.sourceFileName = filePath
            newFile.outputFileName = _
                lFile.DirectoryName + "\" + _
                lFile.Name.Substring(0, lFile.Name.Length - lFile.Extension.Length) + _
                ".min" + lFile.Extension
            FileSettingsArray.Add(newFile)
        Else
            Console.Write("File does not exist: " + filePath)
        End If
    End Sub

    Public Sub AddFileSetting(sText As String)

    End Sub

    Public Sub SaveSettings(sText As String)

    End Sub

    Public Function GetSettings() As ArrayList
        Return FileSettingsArray
    End Function


    ' archive the settings file
    ' also perform maintenance - delete old settings files (over 1 week old)
    Private Sub ArchiveSettings()

    End Sub
#End Region




End Class
