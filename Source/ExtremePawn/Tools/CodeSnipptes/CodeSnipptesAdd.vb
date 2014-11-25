Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

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

    Public Sub Code_TextChanged(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles SnippetCode.TextChanged
        Dim range As Range = TryCast(sender, FastColoredTextBox).VisibleRange
        range.ClearStyle(MulinLineGreenStyle)
        range.SetStyle(MulinLineGreenStyle, "(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline)
        range.SetStyle(MulinLineGreenStyle, "(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline + RegexOptions.RightToLeft)

        e.ChangedRange.SetFoldingMarkers("{", "}") 'Bracket Folding
        e.ChangedRange.SetFoldingMarkers("///StartFold", "///EndFold") 'Custom Folding

        e.ChangedRange.ClearStyle({BlueItalicStyle, BoldStyle, BlueStyle, TextStyle, GreenStyle, NumberStyle, DefineStyle, FuncStyle})

        e.ChangedRange.SetStyle(GreenStyle, "//.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(GreenStyle, "\/\*[\s\S]*?\*\/", RegexOptions.Multiline) 'For multiline comments in one line :P
        e.ChangedRange.SetStyle(BlueItalicStyle, "#.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(BoldStyle, "\b(public|stock|enum)\s+(?<range>[\w_]+?)\b")
        e.ChangedRange.SetStyle(BlueStyle, "\b(public|stock|new|enum|return|if|else|for|break|continue|native|bool|int|true|false|switch|case|forward)\b", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(TextStyle, Chr(34) + ".*" + Chr(34), RegexOptions.Multiline)
        e.ChangedRange.SetStyle(NumberStyle, "([0-9])", RegexOptions.Multiline)

        'Function/Defines colors
        e.ChangedRange.SetStyle(DefineStyle, "\b(" + MainForm.SyntaxHyDefinesList + ")\b", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(FuncStyle, "\b(" + MainForm.SyntaxHyFuncsList + ")\b", RegexOptions.Multiline)
    End Sub
End Class