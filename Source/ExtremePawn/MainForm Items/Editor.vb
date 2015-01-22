Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Editor

    Private Sub Editor_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MainForm.CurrentTB = SplitEditorCode
        MainForm.CurrentOpenedTab = Me

        Dim text As String = MainForm.CurrentTB.Text
        'DocumentMapFrm.DocumentMap.Target = MainForm.CurrentTB
    End Sub

    Private Sub Editor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialogResult As DialogResult = MessageBox.Show("Do you want to save " + Me.TabText + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
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

    Private Sub SplitEditorCode_CharAdded(ByVal sender As System.Object, ByVal e As ScintillaNET.CharAddedEventArgs) Handles SplitEditorCode.CharAdded
        'Ensure the list of autocomplete words contains something
        If SplitEditorCode.AutoComplete.List.Count < 0 Or SplitEditorCode.CallTip.IsActive = True Then
            Exit Sub
        End If

        'Logic to ensure it's shown correctly
        Dim pos As Integer = SplitEditorCode.NativeInterface.GetCurrentPos()
        Dim length As Integer = pos - SplitEditorCode.NativeInterface.WordStartPosition(pos, True)

        'Cancel if the length is zero
        If length = 0 Then
            Exit Sub
        End If

        'Show the modal
        SplitEditorCode.AutoComplete.Show()
    End Sub

    Private Sub SplitEditorCode_AutoCompleteAccepted(ByVal sender As System.Object, ByVal e As ScintillaNET.AutoCompleteAcceptedEventArgs) Handles SplitEditorCode.AutoCompleteAccepted
        Dim Func As String = e.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = MainForm.PublicSyntax.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = MainForm.PublicSyntax.Items.Item(Index)
            MainForm.Status.Text = Format
        End If
    End Sub
End Class