Imports System.Text.RegularExpressions

Public Class CodeSnipptesAdd

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.WriteAllText(CodeSnipptes.Path + TextBox1.Text + ".snip", SnippetCode.Text, False)
            MsgBox("Saved Successfully !", MsgBoxStyle.Information)
            CodeSnipptes.CodeSnipptes_Load(CodeSnipptes, e)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub
End Class