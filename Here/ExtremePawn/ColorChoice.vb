Public Class ColorChoice

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Hex As String
        Hex = String.Format("0x{0:X2}{1:X2}{2:X2}{3:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B, ColorDialog1.Color.A)
        TextBox2.Text = "#define " + TextBox1.Text + " " + Hex
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Hex As String
        Dim all As String
        Hex = String.Format("0x{0:X2}{1:X2}{2:X2}{3:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B, ColorDialog1.Color.A)
        all = "#define " + TextBox1.Text + " " + Hex

        Form1.CurrentTB.InsertText(all + vbCrLf)
    End Sub
End Class