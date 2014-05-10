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
        Using MyReader As New Microsoft.VisualBasic.
                        FileIO.TextFieldParser(
                          cwdString + "\Settings\CompressionBoss.settings")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()

                    If Not ProjectsHash.ContainsKey(currentRow(0)) Then
                        ProjectsHash(currentRow(0)) = New ArrayList()
                    End If

                    Dim fs As FileSetting
                    fs.sourceFileName = currentRow(1)
                    fs.outputFileName = currentRow(2)

                    CType(ProjectsHash(currentRow(0)), ArrayList).Add(fs)

                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    Console.WriteLine("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub



#End Region

#End Region


#Region "Public Subs/Functions"
    ' write the text to the log file

    Public Sub AddNewProject(ProjectName As String)
        If Not ProjectsHash.ContainsKey(ProjectName) Then
            ProjectsHash.Add(ProjectName, New ArrayList())
        End If
        currentProjectName = ProjectName
    End Sub

    Public Sub ChangeProject(ProjectName As String)
        AddNewProject(ProjectName)
    End Sub

    Public Sub UpdateOutput(source As String, output As String)
        Dim aList As New ArrayList()
        Dim updated As Boolean = False
        For Each fs As FileSetting In ProjectsHash(currentProjectName)
            If fs.sourceFileName = source And Not updated Then
                fs.outputFileName = output
                updated = True
            End If
            aList.Add(fs)
        Next
        ProjectsHash(currentProjectName) = aList
        SaveSettings()
    End Sub


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

        SaveSettings()
    End Sub


    Public Function GetProjectNames() As ICollection
        Return ProjectsHash.Keys
    End Function

    Public Sub SaveSettings()
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

        SaveSettings()
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
