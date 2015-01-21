Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Editor

    Private Sub Editor_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MainForm.CurrentTB = SplitEditorCode
        MainForm.CurrentOpenedTab = Me

        Dim text As String = MainForm.CurrentTB.Text
        ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                         MainForm.ReBuildObjectExplorerAndHelpMenu(text)
                                     End Sub)
        'DocumentMapFrm.DocumentMap.Target = MainForm.CurrentTB
    End Sub

    Private Sub Editor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialogResult As DialogResult = MessageBox.Show("Do you want save " + Me.TabText + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
        If dialogResult <> dialogResult.Cancel Then
            If dialogResult = dialogResult.Yes Then
                GC.Collect()
                GC.GetTotalMemory(True)
                If Not Functions.Save(Me) Then
                    e.Cancel = True
                End If
            End If
            MainForm.CurrentTB = Nothing
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SplitEditorCode_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.TextCountLabel.Text = "Count : " + SplitEditorCode.Selection.Length.ToString
    End Sub
End Class