Public Class YUICompressor

    Dim yuiCompressorLocation As String = String.Empty

    Sub New(yuiJarFile As String)
        yuiCompressorLocation = yuiJarFile
    End Sub

    Public Function CompressFile(sInput As String, sOutput As String) As Boolean
        Dim psi As ProcessStartInfo
        Dim procname As String = "java"
        Dim args As String = String.Format("-jar ""{0}"" " + _
                    "-o ""{1}"" " + _
                    """{2}""", yuiCompressorLocation, sOutput, sInput)
        psi = New ProcessStartInfo(procname, args)

        Dim proc As New Process()
        proc.StartInfo = psi
        'proc.StartInfo.CreateNoWindow = True
        psi.WindowStyle = ProcessWindowStyle.Minimized
        psi.WindowStyle = ProcessWindowStyle.Hidden
        psi.CreateNoWindow = True
        psi.UseShellExecute = False
        proc.Start()
        Return True
    End Function



End Class
