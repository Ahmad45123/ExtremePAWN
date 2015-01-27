﻿Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Editor

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
End Class