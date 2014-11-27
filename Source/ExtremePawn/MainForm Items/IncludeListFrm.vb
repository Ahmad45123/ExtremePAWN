Public Class IncludeListFrm

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeTreeView.DoubleClick
        Dim Func As String = IncludeTreeView.SelectedNode.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = MainForm.PublicSyntax.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = MainForm.PublicSyntax.Items.Item(Index)
            MainForm.CurrentTB.InsertText(Format)
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles IncludeTreeView.AfterSelect
        Dim Func As String = IncludeTreeView.SelectedNode.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = MainForm.PublicSyntax.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = MainForm.PublicSyntax.Items.Item(Index)
            MainForm.Status.Text = Format
        End If
    End Sub
End Class