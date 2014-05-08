Public Class frmCompressionBoss

    Private settingsManager As SettingsManager
    Private logManager As LogManager


#Region "LOAD FORM"

    Private Sub frmCompressionBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        settingsManager = New SettingsManager()
        logManager = New LogManager()

        ' Configure the DataGridView
        DataGridView1.Columns.Add("Source", "Source")
        DataGridView1.Columns.Add("Output", "Output")
        DataGridView1.Columns.Add("Last activity", "Last activity")

        DataGridView1.Columns(0).Width = 283
        DataGridView1.Columns(1).Width = 283
        DataGridView1.Columns(2).Width = 120

        PopulateDataGrid()
    End Sub
#End Region

#Region "Private Functions/Subs"
    Private Sub PopulateDataGrid()
        DataGridView1.Rows.Clear()
        Dim data As ArrayList = settingsManager.GetSettings()
        Dim dtString As String = String.Empty
        For Each dataItem As FileSetting In data
            If dataItem.lastProcessed.Year < 2000 Then
                dtString = String.Empty
            End If
            DataGridView1.Rows.Add(dataItem.sourceFileName, dataItem.outputFileName, dtString)
        Next
    End Sub
#End Region


#Region "Form Events"

    Private Sub btnAddFiles_Click(sender As Object, e As EventArgs) Handles btnAddFiles.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            settingsManager.AddSourceFile(OpenFileDialog1.FileName)
            PopulateDataGrid()
        End If
    End Sub

#End Region

    Private Sub btnRunCompression_Click(sender As Object, e As EventArgs) Handles btnRunCompression.Click

    End Sub
End Class
