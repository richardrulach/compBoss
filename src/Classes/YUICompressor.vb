Public Class YUICompressor


    Public Function CompressFile(sInput As String, sOutput As String) As Boolean

        Dim psi As ProcessStartInfo
        Dim procname As String = "java"
        Dim args As String = String.Format("-jar ""C:\websites\YUI Compressor\yuicompressor-2.4.7.jar"" " + _
                    "-o ""{0}"" " + _
                    """{1}""", sOutput, sInput)
        psi = New ProcessStartInfo(procname, args)
        Dim proc As New Process()
        proc.StartInfo = psi
        proc.Start()

        Return True
    End Function



End Class
