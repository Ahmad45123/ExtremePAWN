Public Class DialogCreator

    Private Sub MGenerateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MGenerateButton.Click
        Dim ContentText As String = MContentText.Text.Replace(vbCrLf, "\n")
        Dim Code As String = Nothing
        Code = "ShowPlayerDialog(" + MPlayerText.Text + ", " + MDialogText.Text + ", DIALOG_STYLE_MSGBOX, " + Chr(34) + MTitleTxt.Text + Chr(34) + ", " + Chr(34) + ContentText + Chr(34) + ", " + Chr(34) + MButton1Text.Text + Chr(34) + ", " + Chr(34) + MButton2Text.Text + Chr(34) + ");"
        If MainForm.CurrentTB IsNot Nothing Then
            MainForm.CurrentTB.InsertText(Code)
        Else
            MsgBox("You don't have any file opened.")
        End If
    End Sub

    Private Sub IGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IGenerate.Click
        Dim ContentText As String = IContentText.Text.Replace(vbCrLf, "\n")
        Dim Code As String = Nothing
        If CheckBox1.Checked Then
            Code = "ShowPlayerDialog(" + IPlayerText.Text + ", " + IDialogText.Text + ", DIALOG_STYLE_PASSWORD, " + Chr(34) + ITitleText.Text + Chr(34) + ", " + Chr(34) + ContentText + Chr(34) + ", " + Chr(34) + IButton1Text.Text + Chr(34) + ", " + Chr(34) + IButton2Text.Text + Chr(34) + ");"
        Else
            Code = "ShowPlayerDialog(" + IPlayerText.Text + ", " + IDialogText.Text + ", DIALOG_STYLE_INPUT, " + Chr(34) + ITitleText.Text + Chr(34) + ", " + Chr(34) + ContentText + Chr(34) + ", " + Chr(34) + IButton1Text.Text + Chr(34) + ", " + Chr(34) + IButton2Text.Text + Chr(34) + ");"
        End If
        If MainForm.CurrentTB IsNot Nothing Then
            MainForm.CurrentTB.InsertText(Code)
        Else
            MsgBox("You don't have any file opened.")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            LContentsList.Items.RemoveAt(LContentsList.SelectedIndex)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Content As String = InputBox("Content Text :" + vbCrLf + vbCrLf + "PRESS CANCEL TO FINISH.")
        If Not Content = Nothing Then
            LContentsList.Items.Add(Content)
            Button2_Click(sender, e)

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Content As String = InputBox("Content Text :")
        If Not Content = Nothing Then
            LContentsList.Items.Item(LContentsList.SelectedIndex) = Content
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ContentText As String = Nothing
        For Each Str As String In LContentsList.Items
            ContentText = ContentText + Str + "\n"
        Next

        Dim Code As String = Nothing
        Code = "ShowPlayerDialog(" + LPlayerText.Text + ", " + LDialogText.Text + ", DIALOG_STYLE_LIST, " + Chr(34) + LTitleText.Text + Chr(34) + ", " + Chr(34) + ContentText + Chr(34) + ", " + Chr(34) + LButton1Text.Text + Chr(34) + ", " + Chr(34) + LButton2Text.Text + Chr(34) + ");"
        If MainForm.CurrentTB IsNot Nothing Then
            MainForm.CurrentTB.InsertText(Code)
        Else
            MsgBox("You don't have any file opened.")
        End If
    End Sub
End Class