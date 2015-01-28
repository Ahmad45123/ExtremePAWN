Public Class ColorPreview
    Public Sub SetColor(clr As String)
        clr = clr.Replace(" ", Nothing)
        ColorBox.BackColor = ColorTranslator.FromHtml(clr)
    End Sub
End Class