Public Class Setting

    Private Sub AutoBracket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoBracket.CheckedChanged
        If MainForm.CurrentTB IsNot Nothing Then Exit Sub
        If AutoBracket.Checked = True Then
            MainForm.CurrentTB.AutoCompleteBrackets = True
        Else
            MainForm.CurrentTB.AutoCompleteBrackets = False
        End If
    End Sub
    Private Sub LineNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineNumber.CheckedChanged
        If MainForm.CurrentTB IsNot Nothing Then Exit Sub
        If LineNumber.Checked = True Then
            MainForm.CurrentTB.ShowLineNumbers = True
        Else
            MainForm.CurrentTB.ShowLineNumbers = False
        End If
    End Sub
    Private Sub AutoCompletion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoCompletion.CheckedChanged
        If MainForm.CurrentTB IsNot Nothing Then Exit Sub
        If AutoCompletion.Checked = True Then
            MainForm.HelpMenu.Enabled = True
        Else
            MainForm.HelpMenu.Enabled = False
        End If
    End Sub
    Private Sub AutoSaving_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaving.CheckedChanged
        If MainForm.CurrentTB IsNot Nothing Then Exit Sub
        If AutoSaving.Checked = True Then
            MainForm.AutoSaver.Start()
        Else
            MainForm.AutoSaver.Stop()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
Dim File As New TextBox
        'Delete The Old If Exists
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "\Settings.ini") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\Settings.ini")
        'Start Adding Stuff
        File.Text = "Args=" + AgrumentsTxt.Text + vbCrLf
        File.AppendText("PawnCC=" + PawnccPath.Text + vbCrLf)
        If AutoSaving.Checked = True Then
            File.AppendText("AutoSaving=True" + vbCrLf)
        Else
            File.AppendText("AutoSaving=False" + vbCrLf)
        End If
        If AutoCompletion.Checked = True Then
            File.AppendText("AutoComplete=True" + vbCrLf)
        Else
            File.AppendText("AutoComplete=False" + vbCrLf)
        End If
        If LineNumber.Checked = True Then
            File.AppendText("LineNumber=True" + vbCrLf)
        Else
            File.AppendText("LineNumber=False" + vbCrLf)
        End If
        If AutoBracket.Checked = True Then
            File.AppendText("AutoBracket=True" + vbCrLf)
        Else
            File.AppendText("AutoBracket=False" + vbCrLf)
        End If
        'Save The File
        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\Settings.ini", File.Text, False)
        MsgBox("Successfully Saved", MsgBoxStyle.Information)
    End Sub
End Class