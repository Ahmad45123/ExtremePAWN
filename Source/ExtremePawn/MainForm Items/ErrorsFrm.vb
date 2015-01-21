Public Class ErrorsFrm
    Private Sub ErrorDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ErrorDataGridView.CellDoubleClick
        If MainForm.CurrentTB IsNot Nothing Then
            Dim LineNumber As Integer = ErrorDataGridView.Rows(e.RowIndex).Cells(3).Value
            MainForm.CurrentTB.GoTo.Line(LineNumber)
            MainForm.CurrentTB.Focus()
        End If
    End Sub
End Class