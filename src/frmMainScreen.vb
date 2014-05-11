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

        If settingsManager.GetProjectNames().Count = 0 Then
            If frmNewProjectDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                settingsManager.AddNewProject(frmNewProjectDialog.getProjectName)
                PopulateProjectsCombo()
                For i = 0 To cmbAvailableProjects.Items.Count
                    If cmbAvailableProjects.Items(i) = settingsManager.GetCurrentProject() Then
                        cmbAvailableProjects.SelectedIndex = i
                    End If
                Next
            End If
        End If
        PopulateDataGrid()

        PopulateProjectsCombo()
    End Sub
#End Region

#Region "Private Functions/Subs"
    Private Sub PopulateDataGrid()
        DataGridView1.Rows.Clear()
        Dim data As ArrayList = settingsManager.GetSettings()
        For Each dataItem As FileSetting In data
            DataGridView1.Rows.Add(dataItem.sourceFileName, dataItem.outputFileName)
        Next
    End Sub

    Private Sub PopulateProjectsCombo()
        Dim projects As ICollection = settingsManager.GetProjectNames()
        cmbAvailableProjects.Items.Clear()
        For Each s In projects
            cmbAvailableProjects.Items.Add(s)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Select Case e.ColumnIndex
            Case 2 ' CHANGE OUTPUT
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    settingsManager.UpdateOutput( _
                        DataGridView1.Rows(e.RowIndex).Cells(0).Value, _
                        SaveFileDialog1.FileName)
                    DataGridView1.Rows(e.RowIndex).Cells(1).Value = SaveFileDialog1.FileName
                End If
            Case 3 ' DELETE
                settingsManager.Delete(DataGridView1.Rows(e.RowIndex).Cells(0).Value,
                                       DataGridView1.Rows(e.RowIndex).Cells(1).Value)
                DataGridView1.Rows.RemoveAt(e.RowIndex)

        End Select
    End Sub

    Private Sub btnCreateNewProject_Click(sender As Object, e As EventArgs) Handles btnCreateNewProject.Click
        If frmNewProjectDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            settingsManager.AddNewProject(frmNewProjectDialog.getProjectName)
            PopulateProjectsCombo()
            cmbAvailableProjects.SelectedValue = frmNewProjectDialog.getProjectName
        End If
    End Sub

    Private Sub cmbAvailableProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAvailableProjects.SelectedIndexChanged
        If Not IsNothing(cmbAvailableProjects.SelectedItem) Then
            settingsManager.ChangeProject(cmbAvailableProjects.SelectedItem)
            PopulateDataGrid()
        End If
    End Sub

#End Region

End Class
