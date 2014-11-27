Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS
Imports System.Threading

Public Class Editor

    Public Sub Code_TextChanged(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles SplitEditorCode.TextChanged
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

    Private Sub Editor_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MainForm.CurrentTB = SplitEditorCode
        MainForm.CurrentOpenedTab = Me

        Dim text As String = MainForm.CurrentTB.Text
        ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                         MainForm.ReBuildObjectExplorerAndHelpMenu(text)
                                     End Sub)
        MainForm.DocumentMap.Target = MainForm.CurrentTB
    End Sub

    Private Sub Editor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If SplitEditorCode.IsChanged Then
            Dim dialogResult As DialogResult = MessageBox.Show("Do you want save " + Me.TabText + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
            If dialogResult <> dialogResult.Cancel Then
                If dialogResult = dialogResult.Yes Then
                    If Not Functions.Save(Me) Then
                        e.Cancel = True
                    End If
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class