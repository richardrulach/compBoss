Public Class frmCompressionBoss

    Private settingsManager As SettingsManager
    Private logManager As LogManager
    Private yuiCompressor As YUICompressor


#Region "LOAD FORM"

    Private Sub frmCompressionBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        settingsManager = New SettingsManager()
        logManager = New LogManager()
        yuiCompressor = New YUICompressor( _
            System.IO.Directory.GetCurrentDirectory + "\yuicompressor-2.4.7.jar")

        ' Configure the DataGridView
        DataGridView1.Columns.Add("Source", "Source")
        DataGridView1.Columns.Add("Output", "Output")

        Dim btnChangeOutputColumn As New DataGridViewButtonColumn()
        btnChangeOutputColumn.HeaderText = ""
        btnChangeOutputColumn.Text = "Update Output"
        btnChangeOutputColumn.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(btnChangeOutputColumn)

        Dim btnDeleteColumn As New DataGridViewButtonColumn()
        btnDeleteColumn.HeaderText = ""
        btnDeleteColumn.Text = "Delete"
        btnDeleteColumn.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(btnDeleteColumn)

        DataGridView1.Columns(0).Width = 262
        DataGridView1.Columns(1).Width = 262
        DataGridView1.Columns(2).Width = 90
        DataGridView1.Columns(3).Width = 90

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


    Private Sub btnRunCompression_Click(sender As Object, e As EventArgs) Handles btnRunCompression.Click
        Dim data As ArrayList = settingsManager.GetSettings()

        Me.Enabled = False
        DataGridView1.Enabled = False
        btnRunCompression.Enabled = False
        btnAddFiles.Enabled = False
        btnHelp.Enabled = False

        For Each dataItem As FileSetting In data
            yuiCompressor.CompressFile(dataItem.sourceFileName, dataItem.outputFileName)
        Next
        Me.Enabled = True
        DataGridView1.Enabled = True
        btnRunCompression.Enabled = True
        btnAddFiles.Enabled = True
        btnHelp.Enabled = True

    End Sub

#End Region



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        MessageBox.Show(e.RowIndex.ToString + " " + e.ColumnIndex.ToString)
    End Sub
End Class
