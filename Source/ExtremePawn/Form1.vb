Imports System.IO
Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions


Public Class Form1
    Dim Paths As New ListBox
    Dim org As New ListBox

    Dim save As String

    Dim edit As Boolean = False

    Dim IsLoad As Boolean = True 'This to fix the loading bug.

    Dim BlueStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Italic)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Loading Includes List
        Dim di As New IO.DirectoryInfo(Application.StartupPath + "\include")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        For Each dra In diar1
            If dra.FullName.Contains(".inc") Then
                Paths.Items.Add(dra.ToString)
            End If
        Next
        Dim Num As Integer = 0

        For Each FILE_NAME As String In Paths.Items
            TreeView1.Nodes.Add(FILE_NAME)

            Dim objReader As New System.IO.StreamReader(Application.StartupPath + "/include/" + FILE_NAME)

            Do While objReader.Peek() <> -1
                Dim Line As String
                Line = objReader.ReadLine()
                Dim tmp As String = Line
                If Line.Contains("native ") And Line.Length > 8 Then
                    Line = Line.Replace("native ", "").Trim()
                    org.Items.Add(Line)
                    Line = Line.Remove(Line.IndexOf("("))
                    If Line.Contains(":") Then
                        Line = Line.Remove(0, Line.IndexOf(":") + 1)
                    End If
                    TreeView1.Nodes.Item(Num).Nodes.Add(Line)
                    HelpMenu.AddItem(Line)

                End If
            Loop
            Num += 1
        Next

        LoadSettings() 'Used a Sub to save space in this sub.

        save = Nothing
        Code.OpenFile(Application.StartupPath + "\gamemodes\new.pwn")
        IsLoad = False
    End Sub
    Sub LoadSettings()
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "\Settings.ini") Then
            Dim objReader As New System.IO.StreamReader(Application.StartupPath + "\Settings.ini")

            Do While objReader.Peek() <> -1
                Dim Line As String
                Line = objReader.ReadLine()

                Dim Parts() As String
                Parts = Line.Split("=".ToCharArray, 2)
                If Parts(0) = "Args" Then
                    Setting.AgrumentsTxt.Text = Parts(1)
                ElseIf Parts(0) = "PawnCC" Then
                    Setting.PawnccPath.Text = Parts(1)
                ElseIf Parts(0) = "AutoSaving" Then
                    If Parts(1) = "True" Then Setting.AutoSaving.Checked = True Else Setting.AutoSaving.Checked = False
                ElseIf Parts(0) = "AutoComplete" Then
                    If Parts(1) = "True" Then Setting.AutoCompletion.Checked = True Else Setting.AutoCompletion.Checked = False
                ElseIf Parts(0) = "LineNumber" Then
                    If Parts(1) = "True" Then Setting.LineNumber.Checked = True Else Setting.LineNumber.Checked = False
                ElseIf Parts(0) = "AutoBracket" Then
                    If Parts(1) = "True" Then Setting.AutoBracket.Checked = True Else Setting.AutoBracket.Checked = False
                End If
            Loop

        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True And e.KeyValue = Keys.S Then
            ToolStripButton4.PerformClick()

        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdleMaker.Tick
        IdleMaker.Stop()
        Status.Text = "Idle"
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If edit = True Then
            If MsgBox("Do you want to save this file ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ToolStripButton4.PerformClick()
            End If
        End If
    End Sub

    Function RemoveAt(Of T)(ByVal arr As T(), ByVal index As Integer) As T()
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException( _
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            Return outArr
        End If
    End Function

    Private Sub Code_TextChanged(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles Code.TextChanged
        If IsLoad = False Then
            edit = True
        End If

        e.ChangedRange.ClearStyle(BlueStyle)
        e.ChangedRange.SetStyle(BlueStyle, "#.*$", RegexOptions.Multiline)

        'If IsLoad = False Then
        '    If e.ChangedRange.Text.Contains("#define ") And e.ChangedRange.Text.Contains("0x") Then
        '        Dim Var As String = e.ChangedRange.Text.Remove(0, 7)
        '        Var = Var.Remove(Var.IndexOf("0x"))
        '        Var = Var.Replace(" ", "")

        '        Dim Exist As Boolean = False
        '        For Each s As String In HelpMenu.Items
        '            If s = Var Then
        '                Exist = True
        '                Exit For
        '            End If
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub AutoSaver_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaver.Tick
        ToolStripButton4.PerformClick()

    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        Dim Func As String = TreeView1.SelectedNode.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = org.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = org.Items.Item(Index)
            Code.InsertText(Format)
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim Func As String = TreeView1.SelectedNode.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = org.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = org.Items.Item(Index)
            Status.Text = Format
        End If
    End Sub

    Private Sub HelpMenu_Selected(ByVal sender As System.Object, ByVal e As AutocompleteMenuNS.SelectedEventArgs) Handles HelpMenu.Selected
        Dim Func As String = e.Item.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = org.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = org.Items.Item(Index)
            Status.Text = Format
        End If
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        ColorChoice.Show()

    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        Code.Paste()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Code.Cut()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Code.Copy()
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        Code.Redo()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Code.Undo()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Code.ShowFindDialog()

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Code.ShowReplaceDialog()

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If edit = True Then
            If MsgBox("Do you want to save this file ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ToolStripButton4.PerformClick()
            Else
                save = Nothing
                edit = False
                Code.OpenFile(Application.StartupPath + "\gamemodes\new.pwn")
            End If
        Else
            save = Nothing
            edit = False
            Code.OpenFile(Application.StartupPath + "\gamemodes\new.pwn")
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If save = Nothing Then
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Code.SaveToFile(SaveFileDialog1.FileName, System.Text.Encoding.Default)
                save = SaveFileDialog1.FileName
            End If
        Else
            Code.SaveToFile(save, System.Text.Encoding.Default)
        End If
        Status.Text = "Saved"
        edit = False
        IdleMaker.Start()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Code.OpenFile(OpenFileDialog1.FileName, System.Text.Encoding.Default)
            save = OpenFileDialog1.FileName
        End If
        IdleMaker.Start()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim NumOfErrors As Integer
        Dim NumOfWarns As Integer

        If Not save = Nothing Then
            ToolStripButton4.PerformClick()
        End If

        Status.Text = "Compiling"

        Dim FileName As String = System.IO.Path.GetFileName(save)
        Dim path As String = System.IO.Path.GetDirectoryName(save)

        Dim Args As String = Setting.AgrumentsTxt.Text.Replace("[FILE]", FileName)
        Dim pawncc As String = Setting.PawnccPath.Text.Replace("[APP]", Application.StartupPath)

        Dim consoleApp As New Process
        With consoleApp
            .StartInfo.UseShellExecute = False
            .StartInfo.RedirectStandardError = True
            .StartInfo.CreateNoWindow = True
            .StartInfo.FileName = pawncc
            .StartInfo.WorkingDirectory = path
            .StartInfo.Arguments = Args
            .Start()
            .WaitForExit()
        End With

        Dim output As String = consoleApp.StandardError.ReadToEnd()
        Dim errs() As String
        errs = output.Split(vbCrLf)

        DataGridView1.Rows.Clear()

        For Each s As String In errs
            Dim Type As Image
            Dim ErrorTexte As String
            Dim File As String
            Dim LineNumbers As String
            If s.Contains("error") Then
                NumOfErrors += 1
                Type = My.Resources.ErrorImage
            Else
                NumOfWarns += 1
                Type = My.Resources.WarningImage
            End If

            Try
                File = s.Remove(s.IndexOf("("))

                ErrorTexte = s.Remove(0, s.IndexOf(" : ") + 1)
                ErrorTexte = ErrorTexte.Remove(0, ErrorTexte.IndexOf(":") + 1)
                ErrorTexte = ErrorTexte.Remove(0, ErrorTexte.IndexOf(":") + 1)

                LineNumbers = s.Remove(s.IndexOf(")"))
                LineNumbers = LineNumbers.Remove(0, LineNumbers.IndexOf("(") + 1)
                Dim Row() As Object = {Type, ErrorTexte, File, LineNumbers}
                DataGridView1.Rows.Add(Row)

                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            Catch ex As Exception

            End Try

        Next
        If NumOfErrors = 0 Then
            Status.Text = "Successfully Compiled With 0 Errors And " + NumOfWarns.ToString + " Warnings"
            IdleMaker.Start()
        Else
            Status.Text = "Compiling Failed With " + NumOfErrors.ToString + " Errors And " + NumOfWarns.ToString + " Warnings"
            IdleMaker.Start()
        End If

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Code.SaveToFile(SaveFileDialog1.FileName, System.Text.Encoding.Default)
            save = SaveFileDialog1.FileName
        End If

        Status.Text = "Saved"
        edit = False
        IdleMaker.Start()
    End Sub

    Private Sub ToolsBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsBarToolStripMenuItem.Click
        Dim OldSize As Size
        If ToolStrip1.Visible = True Then
            ToolStrip1.Visible = False

            OldSize = Code.Size
            OldSize.Height += 28
            Code.Size = OldSize
            Code.Top -= 30

            OldSize = TreeView1.Size
            OldSize.Height += 28
            TreeView1.Size = OldSize
            TreeView1.Top -= 30
        Else
            ToolStrip1.Visible = True

            OldSize = Code.Size
            OldSize.Height -= 28
            Code.Size = OldSize
            Code.Top += 30

            OldSize = TreeView1.Size
            OldSize.Height -= 28
            TreeView1.Size = OldSize
            TreeView1.Top += 30
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        ToolStripButton2.PerformClick()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        ToolStripButton3.PerformClick()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        ToolStripButton4.PerformClick()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Setting.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Me.Close()
    End Sub

    Private Sub KeyboardShortcutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyboardShortcutsToolStripMenuItem.Click
        Help.Show()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Developed By Ahmad45123" + vbCrLf + vbCrLf + "For any suggestions or bug reports, Dont hesitate in emailing me at ahmad.gasser@gamil.com" + vbCrLf + vbCrLf + "Thanks for using this editor.")
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        If FontDialog1.ShowDialog = DialogResult.OK Then
            Code.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        Code.Undo()

    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        Code.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Code.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Code.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Code.Paste()
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        Code.ShowFindDialog()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        Code.ShowReplaceDialog()

    End Sub

    Private Sub GoToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToToolStripMenuItem.Click
        Code.ShowGoToDialog()

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Code.SelectAll()

    End Sub

    Private Sub FunctionListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunctionListToolStripMenuItem.Click
        Dim OldSize As Size
        If TreeView1.Visible = True Then
            TreeView1.Visible = False

            OldSize = Code.Size
            OldSize.Width += 214
            Code.Size = OldSize

            OldSize = DataGridView1.Size
            OldSize.Width += 214
            DataGridView1.Size = OldSize
        Else
            TreeView1.Visible = True

            OldSize = Code.Size
            OldSize.Width -= 214
            Code.Size = OldSize

            OldSize = DataGridView1.Size
            OldSize.Width -= 214
            DataGridView1.Size = OldSize
        End If
    End Sub

    Private Sub ErrorListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorListToolStripMenuItem.Click
        Dim OldSize As Size
        If DataGridView1.Visible = True Then
            DataGridView1.Visible = False

            OldSize = Code.Size
            OldSize.Height += 106
            Code.Size = OldSize
        Else
            DataGridView1.Visible = True

            OldSize = Code.Size
            OldSize.Height -= 106
            Code.Size = OldSize
        End If
    End Sub

    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        Code.DoAutoIndent()

    End Sub
End Class
