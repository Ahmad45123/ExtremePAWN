Public Class ProjectExplorerFrm

    Private Sub ProjectExplorer_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ProjectExplorer.NodeMouseDoubleClick
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "/include/" + e.Node.Text + ".inc") Then
            Functions.CreateTab(Application.StartupPath + "/include/" + e.Node.Text + ".inc")
        ElseIf e.Node.Index = 2 And Not MainForm.CurrentProjectPath = Nothing Then
            Functions.CreateTab(MainForm.CurrentProjectPath + "/Main.pwn")
        ElseIf My.Computer.FileSystem.FileExists(MainForm.CurrentProjectPath + "/Scripts/" + e.Node.Text + ".pwn") And Not MainForm.CurrentProjectPath = Nothing Then
            Functions.CreateTab(MainForm.CurrentProjectPath + "/Scripts/" + e.Node.Text + ".pwn")
        End If
    End Sub
End Class