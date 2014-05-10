Public Class frmNewProjectDialog

    Private projectName As String = String.Empty


    Public Function getProjectName() As String
        Return projectName
    End Function

    Private Sub btnCancelNewProject_Click(sender As Object, e As EventArgs) Handles btnCancelNewProject.Click
        projectName = String.Empty
        TextBox1.Text = String.Empty
    End Sub

    Private Sub btnCreateNewProject_Click(sender As Object, e As EventArgs) Handles btnCreateNewProject.Click
        projectName = TextBox1.Text
        TextBox1.Text = String.Empty
    End Sub

End Class
