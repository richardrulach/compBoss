Imports System.IO

Public Structure FileSetting
    Public sourceFileName As String
    Public outputFileName As String
End Structure

Public Class SettingsManager

#Region "Private Properties"
    Private cwdString As String = String.Empty
    Private strCurrentSettingsFile As String = String.Empty
    Private FileSettingsArray As ArrayList = New ArrayList()
    Private ProjectsHash As Hashtable = New Hashtable()

    Private currentProjectName As String = String.Empty

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

        If File.Exists(filePath) Then
            Dim newFile As FileSetting
            Dim lFile As New FileInfo(filePath)
            newFile.sourceFileName = filePath
            newFile.outputFileName = _
                lFile.DirectoryName + "\" + _
                lFile.Name.Substring(0, lFile.Name.Length - lFile.Extension.Length) + _
                ".min" + lFile.Extension

            CheckCurrentProject()

            ProjectsHash(currentProjectName).add(newFile)
        Else
            Console.Write("File does not exist: " + filePath)
        End If

    End Sub

    Public Sub AddFileSetting(sText As String)

    End Sub

    Public Function GetProjectNames() As String()
        Return ProjectsHash.Keys
    End Function

    Public Sub SaveSettings(sText As String)
        Dim csvText As String = String.Empty
        For Each s As String In ProjectsHash.Keys
            For Each fs As FileSetting In ProjectsHash(s)
                csvText += s + "," + fs.sourceFileName + "," + fs.outputFileName + vbCrLf
            Next
        Next

        File.Delete(strCurrentSettingsFile)
        File.WriteAllText(strCurrentSettingsFile, csvText)
    End Sub

    ' Checks the current project has a name and has an arraylist allocated to it.
    Private Sub CheckCurrentProject()
        If currentProjectName.Length = 0 Then
            currentProjectName = "<NEW PROJECT>"
        End If

        If IsNothing(ProjectsHash(currentProjectName)) Then
            ProjectsHash(currentProjectName) = New ArrayList()
        End If
    End Sub


    Public Sub Delete(sSourceFile As String, sOutputFile As String)
        CheckCurrentProject()

        ' Remove if it matches the input and output parameters of the current project
        For i = 0 To CType(ProjectsHash(currentProjectName), ArrayList).Count - 1
            If CType(CType(ProjectsHash(currentProjectName), ArrayList)(i), FileSetting).sourceFileName = sSourceFile _
               And CType(CType(ProjectsHash(currentProjectName), ArrayList)(i), FileSetting).outputFileName = sOutputFile _
                Then
                CType(ProjectsHash(currentProjectName), ArrayList).RemoveAt(i)
                Exit For
            End If
        Next

    End Sub

    Public Function GetSettings() As ArrayList
        CheckCurrentProject()

        Return ProjectsHash(currentProjectName)
    End Function


    ' archive the settings file
    ' also perform maintenance - delete old settings files (over 1 week old)
    Private Sub ArchiveSettings()

    End Sub
#End Region




End Class
