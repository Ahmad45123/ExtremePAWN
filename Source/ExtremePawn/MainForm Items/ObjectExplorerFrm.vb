Public Class ObjectExplorerFrm

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles DataGridView1.CellValueNeeded
        Try
            Dim item As ObjectExplorerClass.ExplorerItem = ObjectExplorerClass.explorerList(e.RowIndex)
            If e.ColumnIndex = 1 Then
                e.Value = item.title
            Else
                Select Case item.type
                    Case ObjectExplorerClass.ExplorerItemType.[Class]
                        e.Value = My.Resources.class_libraries
                    Case ObjectExplorerClass.ExplorerItemType.[Property]
                        e.Value = My.Resources._property
                End Select
            End If
        Catch ex_8D As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If MainForm.CurrentTB IsNot Nothing Then
            Dim item As ObjectExplorerClass.ExplorerItem = ObjectExplorerClass.explorerList(e.RowIndex)
            MainForm.CurrentTB.GoTo.Line(item.position)
            MainForm.CurrentTB.Focus()
        End If
    End Sub
End Class