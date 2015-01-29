Public Class ObjectExplorerSettings

    Private Sub ObjectExplorerSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObjectList.Nodes.Clear()

        Dim items = ObjectExplorerGroup.ParseObjectExplorer(SettingsHandler.GetSetting("ObjectExplorer"))
        If items Is Nothing Then Exit Sub
        For Each item As ObjectExplorerGroup In items
            Dim node As New TreeNode
            node.Text = item.Title
            node.Tag = item.TextHint
            ObjectList.Nodes.Add(node)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If AddTitle.Text = Nothing Or AddHint.Text = Nothing Then Exit Sub

        Dim node As New TreeNode(AddTitle.Text)
        node.Tag = AddHint.Text
        AddTitle.Text = Nothing
        AddHint.Text = Nothing
        ObjectList.Nodes.Add(node)
    End Sub

    Private Sub ObjectList_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles ObjectList.NodeMouseClick
        EditTitle.Text = e.Node.Text
        EditHint.Text = e.Node.Tag
        GroupBox2.Tag = e.Node.Index
        GroupBox2.Enabled = True
    End Sub

    Private Sub GroupBox2_Leave(sender As Object, e As EventArgs) Handles GroupBox2.Leave
        GroupBox2.Tag = Nothing
        EditTitle.Text = Nothing
        EditHint.Text = Nothing
        GroupBox2.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ObjectList.Nodes(Convert.ToInt16(GroupBox2.Tag)).Text = EditTitle.Text
        ObjectList.Nodes(Convert.ToInt16(GroupBox2.Tag)).Tag = EditHint.Text
        GroupBox2.Tag = Nothing
        EditTitle.Text = Nothing
        EditHint.Text = Nothing
        GroupBox2.Enabled = False
    End Sub

    Private Sub ObjectExplorerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SettingsHandler.WriteSetting("ObjectExplorer", ObjectExplorerGroup.GetObjectExplorerText(ObjectList.Nodes))
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        Me.AcceptButton = Button1
    End Sub
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter
        Me.AcceptButton = Button2
    End Sub

    Private Sub ObjectList_KeyDown(sender As Object, e As KeyEventArgs) Handles ObjectList.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ObjectList.SelectedNode IsNot Nothing Then
                ObjectList.SelectedNode.Remove()
            End If
        End If
    End Sub

    Private Sub AddHint_MouseClick(sender As Object, e As MouseEventArgs) Handles EditHint.MouseClick, AddHint.MouseClick
        ToolTip1.Show("NOTE: This uses Regex, Meaning you'll have to use \( and \) for brackets." + vbCrLf + "[FUNC] -> Will refer to the name which will be visible in list." + vbCrLf + "[*] -> Will refer to any text and/or number.", sender, e.X, e.Y, 2000)
    End Sub
End Class