Imports System.Text.RegularExpressions

Public Class Object_Explorer
    Private Sub EditMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditMenuToolStripMenuItem.Click
        ObjectExplorerSettings.ShowDialog()
    End Sub

    Private lstObjectExplorer As New List(Of ObjectExplorerGroup)
    Private ParentNodes As New List(Of String)
    Private objectText As String = Nothing
    Private Sub AddListNode(ByVal node As TreeNode)
        If TreeList.InvokeRequired Then
            TreeList.Invoke(New Action(Of TreeNode)(AddressOf AddListNode), node)
        Else
            TreeList.Nodes.Add(node)
        End If
    End Sub
    Private Sub RemoveNodes()
        If TreeList.InvokeRequired Then
            TreeList.Invoke(New Action(AddressOf RemoveNodes))
        Else
            TreeList.Nodes.Clear()
        End If
    End Sub
    Private Sub ReBuildWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ReBuildWorker.DoWork
        RemoveNodes()
        If ParentNodes IsNot Nothing Then ParentNodes.Clear()

        For Each item As ObjectExplorerGroup In lstObjectExplorer
            'Replacing symbols with there others.
            Dim pattern As String = item.TextHint
            pattern = pattern.Replace("[FUNC]", "[a-zA-z]*")
            pattern = pattern.Replace("[*]", "[a-zA-z0-9]*")

            Dim treeItem As New TreeNode(item.Title)
            ParentNodes.Add(item.Title)

            Dim match As Match = Regex.Match(objectText, pattern)
            Do While match.Success
                Dim matchStr As String = match.Value.Replace(item.TextHint.Remove(item.TextHint.IndexOf("[FUNC]")), "")
                Dim childNode As New TreeNode(matchStr)
                childNode.Tag = match.Index 'This will store only the char pos and not line num.
                treeItem.Nodes.Add(childNode)
                match = match.NextMatch()
            Loop

            AddListNode(treeItem)
        Next
    End Sub

    Private Sub RebuildMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RebuildMenuToolStripMenuItem.Click
        If MainForm.CurrentTB Is Nothing Then Exit Sub

        lstObjectExplorer = ObjectExplorerGroup.ParseObjectExplorer(SettingsHandler.GetSetting("ObjectExplorer"))
        objectText = MainForm.CurrentTB.Text.Clone
        If ReBuildWorker.IsBusy = False Then
            ReBuildWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub TreeList_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeList.AfterSelect
        If Not ParentNodes.Contains(e.Node.Text) Then
            ToolTip1.Show(MainForm.CurrentTB.Lines.FromPosition(e.Node.Tag).Text, TreeList, e.Node.Bounds.Location.X + (e.Node.Text.Count * 7), e.Node.Bounds.Y, 1000)
        End If
    End Sub

    Private Sub TreeList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeList.MouseDoubleClick
        Dim node = TreeList.SelectedNode
        If node Is Nothing Then Exit Sub

        If Not ParentNodes.Contains(node.Text) And MainForm.CurrentTB IsNot Nothing Then
            MainForm.CurrentTB.Caret.Goto(node.Tag)
            MainForm.CurrentTB.Focus()
            MainForm.CurrentTB.Caret.EnsureVisible()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            If ReBuildWorker.IsBusy = False Then ReBuildWorker.RunWorkerAsync()
            Exit Sub
        End If

        Dim RemovalList As New List(Of TreeNode)
        For Each ment As TreeNode In TreeList.Nodes
            For Each childNode As TreeNode In ment.Nodes
                If childNode Is Nothing Then Continue For

                If Not childNode.Text.StartsWith(TextBox1.Text) Then
                    RemovalList.Add(childNode)
                End If
            Next
        Next

        For Each node As TreeNode In RemovalList
            TreeList.Nodes.Remove(node)
        Next
        TreeList.ExpandAll()
    End Sub
End Class

Public Class ObjectExplorerGroup
    Public Property TextHint As String
    Public Property Title As String

    Public Sub New(titlevar As String, textHintvar As String)
        Title = titlevar
        TextHint = textHintvar
    End Sub

    Public Shared Function ParseObjectExplorer(text As String)
        If text = Nothing Then Return Nothing
        Dim list As New List(Of ObjectExplorerGroup)
        Dim groups As String() = text.Split("|")
        If groups.Count = 0 Then Return Nothing
        For Each grp As String In groups
            Dim lst As String() = grp.Split(",")
            If Not lst.Count = 2 Then Continue For
            list.Add(New ObjectExplorerGroup(lst(0), lst(1)))
        Next
        Return list
    End Function
    Public Shared Function GetObjectExplorerText(list As TreeNodeCollection)
        Dim str As String = Nothing
        For Each lst As TreeNode In list
            str = str + lst.Text + "," + lst.Tag + "|"
        Next
        Return str
    End Function
End Class