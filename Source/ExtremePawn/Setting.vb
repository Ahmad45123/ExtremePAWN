Public Class Setting

    Private Sub AutoBracket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoBracket.CheckedChanged
        If AutoBracket.Checked = True Then
            Form1.Code.AutoCompleteBrackets = True
        Else
            Form1.Code.AutoCompleteBrackets = False
        End If
    End Sub
    Private Sub LineNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineNumber.CheckedChanged
        If LineNumber.Checked = True Then
            Form1.Code.ShowLineNumbers = True
        Else
            Form1.Code.ShowLineNumbers = False
        End If
    End Sub
    Private Sub AutoCompletion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoCompletion.CheckedChanged
        If AutoCompletion.Checked = True Then
            Form1.HelpMenu.Enabled = True
        Else
            Form1.HelpMenu.Enabled = False
        End If
    End Sub
    Private Sub AutoSaving_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaving.CheckedChanged
        If AutoSaving.Checked = True Then
            Form1.AutoSaver.Start()
        Else
            Form1.AutoSaver.Stop()
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