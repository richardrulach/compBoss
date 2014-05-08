Public Class frmCompressionBoss

    Private Sub btnAddFolder_Click(sender As Object, e As EventArgs) Handles btnAddFolder.Click
        '        MessageBox.Show(System.IO.Directory.GetCurrentDirectory)


        Dim yui As New YUICompressor()
        yui.CompressFile("C:\websites\YUI Compressor\test\MyFunction.js", "C:\websites\YUI Compressor\test\MyFunction.min.js")
    End Sub
End Class
