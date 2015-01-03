Public Class SavedPositions

    Private Sub ItemsListBox_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ItemsListBox.MouseDoubleClick
        If MainForm.CurrentTB IsNot Nothing Then MainForm.CurrentTB.InsertText(ItemsListBox.SelectedItem.ToString)
        SavedPositions_Load(Me, New System.EventArgs)
    End Sub

    Private Sub SavedPositions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ItemsListBox.Items.Clear()

        Try
            Dim objReader As New System.IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\savedpositions.txt") 'Read the settings
            Do While objReader.Peek() <> -1
                Dim Line As String
                Line = objReader.ReadLine()
                ItemsListBox.Items.Add(Line)
            Loop
            objReader.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class