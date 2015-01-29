Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Editor

    Private Sub Editor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialogResult As DialogResult = MessageBox.Show("Do you want to save " + Me.TabText + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
        If dialogResult <> dialogResult.Cancel Then
            If dialogResult = dialogResult.Yes Then
                GC.Collect()
                GC.GetTotalMemory(True)
                MainForm.CurrentTB = Nothing
                MainForm.CurrentOpenedTab = Nothing
                Dispose(True)
                If Not Functions.Save(Me) Then
                    e.Cancel = True
                End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SplitEditorCode_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitEditorCode.SelectionChanged
        MainForm.TextCountLabel.Text = "Count : " + SplitEditorCode.Selection.Length.ToString
    End Sub

    Private Sub AutoComplete_Selected(ByVal sender As System.Object, ByVal e As AutocompleteMenuNS.SelectedEventArgs) Handles AutoComplete.Selected
        If e.Item.ToolTipText IsNot Nothing Then SplitEditorCode.CallTip.Show(e.Item.ToolTipText)
    End Sub

    Private Sub Editor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AutoComplete.SetAutocompleteMenu(SplitEditorCode, AutoComplete)
    End Sub

    Private Sub Editor_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        MainForm.CurrentTB = SplitEditorCode
        MainForm.CurrentOpenedTab = Me
    End Sub

    Private Sub AutoComplete_Hovered(sender As Object, e As AutocompleteMenuNS.HoveredEventArgs) Handles AutoComplete.Hovered
        If e.Item Is Nothing Then Exit Sub

        If e.Item.ToolTipText.StartsWith("0x") Then
            Dim str As String = e.Item.ToolTipText.Remove(e.Item.ToolTipText.Count - 2, 2)
            ColorPreview.SetColor(Str)
        ElseIf e.Item.ToolTipText.StartsWith(Chr(34) + "{") Then
            Dim str As String = e.Item.ToolTipText.Replace(Chr(34), "")
            str = str.Replace("{", "")
            str = str.Replace("}", "")
            str = "#" + str
            ColorPreview.SetColor(Str)
        End If
    End Sub
End Class