Imports System.Text.RegularExpressions

Public Class CodeSnipptes
    Public Path As String = Application.StartupPath + "/CodeSnipptes/"

    Public Sub CodeSnipptes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ListBox1.Items.Clear()
        Catch ex As Exception
        End Try

        If Not My.Computer.FileSystem.DirectoryExists(Path) Then
            My.Computer.FileSystem.CreateDirectory(Path)
        End If

        Dim di As New IO.DirectoryInfo(Path)
        Dim diar1 As IO.FileInfo() = di.GetFiles()

        For Each dra As IO.FileInfo In diar1
            If dra.Extension = ".snip" Then
                ListBox1.Items.Add(dra.Name.Remove(dra.Name.LastIndexOf(".")))
            End If
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            SnippetCode.Text = My.Computer.FileSystem.ReadAllText(Path + ListBox1.SelectedItem + ".snip")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If MainForm.CurrentTB IsNot Nothing Then
            MainForm.CurrentTB.InsertText(SnippetCode.Text)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ListBox1.SelectedIndex = ListBox1.FindString(TextBox1.Text)
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Dim codesnip As New CodeSnipptesAdd
        codesnip.Text = "Add Code Snippet"
        codesnip.ShowDialog()

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If Not ListBox1.SelectedIndex = -1 Then
            Dim codesnip As New CodeSnipptesAdd
            codesnip.Text = "Edit Code Snippet"
            codesnip.TextBox1.Text = ListBox1.SelectedItem.ToString
            codesnip.SnippetCode.Text = My.Computer.FileSystem.ReadAllText(Path + ListBox1.SelectedItem + ".snip")
            codesnip.ShowDialog()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not ListBox1.SelectedIndex = -1 Then
            If MsgBox("Are you sure you want to delete this code snippet ?", MsgBoxStyle.YesNo, "Are you sure ?") = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(Path + ListBox1.SelectedItem + ".snip")
                CodeSnipptes_Load(Me, e)
            End If
        End If
    End Sub
End Class