Public Class Settings

    Private Sub AutoSaving_CheckedChanged(sender As Object, e As EventArgs) Handles AutoSaving.CheckedChanged
        If MainForm.CurrentTB Is Nothing Then Exit Sub
        If AutoSaving.Checked = True Then
            MainForm.AutoSaver.Start()
        Else
            MainForm.AutoSaver.Stop()
        End If
    End Sub

    Private Sub LineNumber_CheckedChanged(sender As Object, e As EventArgs) Handles LineNumber.CheckedChanged
        If MainForm.CurrentTB Is Nothing Then Exit Sub
        If LineNumber.Checked = True Then
            MainForm.ScrollBarTimer.Start()
            MainForm.CurrentTB.Margins(0).Width = 20
        Else
            MainForm.ScrollBarTimer.Stop()
            MainForm.CurrentTB.Margins(0).Width = 0
        End If
    End Sub

    Private Sub AutoCompletion_CheckedChanged(sender As Object, e As EventArgs) Handles AutoCompletion.CheckedChanged
        If MainForm.CurrentTB Is Nothing Then Exit Sub
        If AutoCompletion.Checked = True Then
            MainForm.CurrentTB.AutoComplete.CancelAtStart = True
        Else
            MainForm.CurrentTB.AutoComplete.CancelAtStart = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SAMPServerDir.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SAMPClient.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Public KEY_COMPILE As Keys
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        KeyDetector.ShowDialog()
        KEY_COMPILE = KeyDetector.PressedKey
        CompileLabel.Text = KEY_COMPILE.ToString
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PawnccPath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        SettingsHandler.WriteSetting("AutoSave", AutoSaving.Checked.ToString)
        SettingsHandler.WriteSetting("LineNumber", LineNumber.Checked.ToString)
        SettingsHandler.WriteSetting("AutoComplete", AutoCompletion.Checked.ToString)
        SettingsHandler.WriteSetting("SAMPServer", SAMPServerDir.Text)
        SettingsHandler.WriteSetting("SAMPClient", SAMPClient.Text)
        SettingsHandler.WriteSetting("CompilerArgs", AgrumentsTxt.Text)
        SettingsHandler.WriteSetting("PawnCCPath", PawnccPath.Text)
        SettingsHandler.WriteSetting("CompileKey", CompileLabel.Text)

        MsgBox("You've successfully saved your settings.", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class