Public Class Setting

    Public KEY_COMPILE As Keys

    Private Sub AutoBracket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoBracket.CheckedChanged
        'If MainForm.CurrentTB Is Nothing Then Exit Sub
        'If AutoBracket.Checked = True Then
        '    MainForm.CurrentTB.AutoCompleteBrackets = True
        'Else
        '    MainForm.CurrentTB.AutoCompleteBrackets = False
        'End If
    End Sub
    Private Sub LineNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineNumber.CheckedChanged
        If MainForm.CurrentTB Is Nothing Then Exit Sub
        If LineNumber.Checked = True Then
            MainForm.CurrentTB.Margins(0).Width = 20
        Else
            MainForm.CurrentTB.Margins(0).Width = 0
        End If
    End Sub
    Private Sub AutoCompletion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoCompletion.CheckedChanged
        If MainForm.CurrentTB Is Nothing Then Exit Sub
        If AutoCompletion.Checked = True Then
            MainForm.CurrentTB.AutoComplete.CancelAtStart = True
        Else
            MainForm.CurrentTB.AutoComplete.CancelAtStart = False
        End If
    End Sub
    Private Sub AutoSaving_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaving.CheckedChanged
        If MainForm.CurrentTB Is Nothing Then Exit Sub
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
        File.AppendText("SAMPSrvrFldr=" + TextBox1.Text + vbCrLf)
        File.AppendText("SAMPClient=" + TextBox2.Text + vbCrLf)
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
        File.AppendText("CompileKey=" + KEY_COMPILE.ToString + vbCrLf)
        'Save The File
        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "\Settings.ini", File.Text, False)
        MsgBox("Successfully Saved", MsgBoxStyle.Information)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        KeyDetector.ShowDialog()
        KEY_COMPILE = KeyDetector.PressedKey
        Label4.Text = KEY_COMPILE.ToString
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class