Public Class ColorPreview
    Public Sub SetColor(clr As String)
        clr = clr.Replace(" ", Nothing)
        Try
            ColorBox.BackColor = ColorTranslator.FromHtml(clr)
        Catch ex As Exception
            MainForm.Status.Text = "Color '" + clr + "' is not valid."
            MainForm.IdleMaker.Start()
        End Try
    End Sub
End Class