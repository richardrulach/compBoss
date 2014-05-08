Public Class frmCompressionBoss

    Private settingsManager As SettingsManager
    Private logManager As LogManager

    Private Sub btnAddFolder_Click(sender As Object, e As EventArgs) Handles btnAddFolder.Click
        '        MessageBox.Show(System.IO.Directory.GetCurrentDirectory)


        Dim yui As New YUICompressor()
        yui.CompressFile("C:\websites\YUI Compressor\test\MyFunction.js", "C:\websites\YUI Compressor\test\MyFunction.min.js")
    End Sub

    Private Sub frmCompressionBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        settingsManager = New SettingsManager()
        logManager = New LogManager()

    End Sub
End Class
