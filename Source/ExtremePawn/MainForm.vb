'Copyright (C) 2014  Ahmad45123

'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.

'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License
'along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports WeifenLuo.WinFormsUI.Docking
Imports ScintillaNET

Public Class MainForm

    'Used for populating a TreeView from another thread
    Public Delegate Sub Add(ByVal i As Integer)

    'Project System
    Public CurrentProjectPath As String = Nothing 'Will be nothing if there is no project loaded.

    Public CurrentTB As Scintilla 'Returns the current opened object of FastColoredTextBox
    Public CurrentOpenedTab As Editor 'Returns the current opened window which contains the TB.

    Dim m_deserlise As DeserializeDockContent
    Private Function GetContentFromPersistString(ByVal persistString As String) As IDockContent
        'If persistString = GetType(DocumentMapFrm).ToString Then
        'Return DocumentMapFrm
        If persistString = GetType(ErrorsFrm).ToString Then
            Return ErrorsFrm
        ElseIf persistString = GetType(IncludeListFrm).ToString Then
            Return IncludeListFrm
        ElseIf persistString = GetType(ProjectExplorerFrm).ToString Then
            Return ProjectExplorerFrm
        ElseIf persistString = GetType(SavedPositions).ToString Then
            Return SavedPositions
        End If
        Return Nothing
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load Settings
        Functions.LoadIncs()
        Functions.LoadSettings()

        'Load all files in the args.
        For Each Arg As String In My.Application.CommandLineArgs
            If Arg IsNot Nothing Then
                Functions.CreateTab(Arg)
            End If
        Next

        'Load Saved Docks
        Try
            m_deserlise = New DeserializeDockContent(AddressOf GetContentFromPersistString)
            MainDockPanel.LoadFromXml(Application.StartupPath + "/SavedDocks.xml", m_deserlise)
        Catch ex As Exception
        End Try

        GC.Collect()
        GC.GetTotalMemory(False)
    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True And e.KeyValue = Keys.S Then
            ToolStripButton4.PerformClick() 'Save
        ElseIf e.KeyCode = Setting.KEY_COMPILE Then
            ToolStripButton7.PerformClick() 'Compile
        ElseIf e.Control And e.KeyValue = Keys.R Then
            Status.Text = "Forcing refresh."
            IdleMaker.Start()
            ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                             ReBuildAutoComplete(CurrentOpenedTab)
                                         End Sub)
        End If
    End Sub

    Private Sub IdleMaker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdleMaker.Tick
        IdleMaker.Stop()
        Status.Text = "Idle"
    End Sub

    Private Sub AutoSaver_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaver.Tick
        ToolStripButton4.PerformClick()
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        ColorChoice.Show()
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        If CurrentTB IsNot Nothing Then CurrentTB.Clipboard.Paste()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        If CurrentTB IsNot Nothing Then CurrentTB.Clipboard.Cut()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        If CurrentTB IsNot Nothing Then CurrentTB.Clipboard.Copy()
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        If CurrentTB IsNot Nothing Then CurrentTB.UndoRedo.Redo()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If CurrentTB IsNot Nothing Then CurrentTB.UndoRedo.Undo()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If CurrentTB IsNot Nothing Then CurrentTB.FindReplace.ShowFind()

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If CurrentTB IsNot Nothing Then CurrentTB.FindReplace.ShowReplace()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Functions.CreateTab(Nothing)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If CurrentTB IsNot Nothing Then
            Functions.Save(CurrentOpenedTab)
        End If
        Status.Text = "Saved"
        IdleMaker.Start()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        OpenToolStripMenuItem.PerformClick()

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If CurrentTB IsNot Nothing Then
            Functions.Compile(CurrentTB)
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If (CurrentTB IsNot Nothing) And (Not CurrentProjectPath = Nothing) Then
            If CurrentOpenedTab.Tag.contains("Main.pwn") Then
                Functions.CreateFile(InputBox("Please enter a name for the new file." + vbCrLf + "NOTE: Pressing cancel willn't cancel the operation."))
            Else
                MsgBox("Make sure you have Main.pwn file open." + vbCrLf + "And also make sure you placed your cursor you want to place the include.")
            End If
        Else
            MsgBox("You don't have any project loaded.")
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Functions.CreateTab(OpenFileDialog.FileName)
        End If
        IdleMaker.Start()
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

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("ExtremePAWN " + Application.ProductVersion + vbCrLf + vbCrLf + "Developed By Ahmad45123 AKA Johny Mac" + vbCrLf + "For any suggestions or bug reports, Dont hesitate in emailing me at ahmad.gasser@gmail.com" + vbCrLf + vbCrLf + "Thanks for using this editor.")
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        If CodeFont.ShowDialog = DialogResult.OK Then
            Editor.Font = CodeFont.Font
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        CurrentTB.UndoRedo.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        CurrentTB.UndoRedo.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        CurrentTB.Clipboard.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        CurrentTB.Clipboard.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        CurrentTB.Clipboard.Paste()
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        CurrentTB.FindReplace.ShowFind()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        CurrentTB.FindReplace.ShowReplace()
    End Sub

    Private Sub GoToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToToolStripMenuItem.Click
        CurrentTB.GoTo.ShowGoToDialog()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        CurrentTB.Selection.SelectAll()
    End Sub

    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        'CurrentTB.IncreaseIndent()
    End Sub

    Private Sub ToolStripButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton15.Click
        'CurrentTB.DecreaseIndent()
    End Sub

    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click
        'CurrentTB.DoAutoIndent()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        CurrentTB.Clipboard.Copy()
    End Sub

    Private Sub CutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem1.Click
        CurrentTB.Clipboard.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        CurrentTB.Clipboard.Paste()
    End Sub

    'Function ReBuildObjectExplorer to rebuild the object explorer contents.
    Public PublicSyntax As New ListBox
    Public SyntaxOfInc As New List(Of String)
    Public Includes As New List(Of String)
    Dim IsRebuildFinished As Boolean = True
    Public Sub ReBuildAutoComplete(ByVal openedTab As Editor)
        If openedTab.AutoComplete.Visible = True Then Exit Sub
        IsRebuildFinished = False

        Dim text As String = openedTab.SplitEditorCode.Text.Clone
        Dim textLines As String() = text.Split(vbCrLf)

        Try
            'Clearing
            openedTab.AutoComplete.SetAutocompleteItems(New List(Of String))
            PublicSyntax.Items.Clear()

            'Place stocks/publics/defines
            For Each Line As String In textLines
                Dim lineText As String = Regex.Replace(Line, "^\s+|\s+$|\s+(?=\s)", "") 'Remove whitespaces.

                If lineText.StartsWith("#define") Then 'Define
                    If lineText.IndexOf(" ") = -1 Then Continue For
                    Dim tempdefineName As String = lineText.Substring(lineText.IndexOf(" ")).Trim()
                    Dim define As String() = tempdefineName.Split(" ")
                    openedTab.AutoComplete.AddItem(New AutocompleteMenuNS.AutocompleteItem(define(0), 0))
                ElseIf lineText.StartsWith("public") Or lineText.StartsWith("stock") Then
                    If lineText.IndexOf(" ") = -1 Then Continue For
                    Dim tempFunc As String = lineText.Substring(lineText.IndexOf(" ")).Trim()
                    Dim syntax As String = tempFunc
                    If tempFunc.IndexOf("(") = -1 Then Continue For
                    tempFunc = tempFunc.Remove(tempFunc.IndexOf("("))
                    openedTab.AutoComplete.AddItem(New AutocompleteMenuNS.AutocompleteItem(tempFunc, 1, tempFunc, "Usage: ", syntax))
                    PublicSyntax.Items.Add(syntax)
                End If
            Next

            'Place includes.
            For i As Integer = 0 To Includes.Count - 1
                openedTab.AutoComplete.AddItem(New AutocompleteMenuNS.AutocompleteItem(Includes(i), 1, Includes(i), "Usage: ", SyntaxOfInc(i)))
            Next

            For Each Str As String In SyntaxOfInc
                PublicSyntax.Items.Add(Str)
            Next

            GC.Collect()
            GC.GetTotalMemory(True)

        Catch ex As Exception
            Beep()
        End Try
        IsRebuildFinished = True
    End Sub

    Private Sub FindToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem1.Click
        CurrentTB.FindReplace.ShowFind()
    End Sub

    Private Sub ReplaceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem1.Click
        CurrentTB.FindReplace.ShowReplace()
    End Sub

    Private Sub GotoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoToolStripMenuItem1.Click
        CurrentTB.GoTo.ShowGoToDialog()
    End Sub

    Private Sub AddBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBookmarkToolStripMenuItem.Click
        If Me.CurrentTB IsNot Nothing Then
            CurrentTB.Markers.AddInstanceSet(CurrentTB.Lines.Current, 1)
        End If
    End Sub

    Private Sub RemoveBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveBookmarkToolStripMenuItem.Click
        If Me.CurrentTB IsNot Nothing Then
            CurrentTB.Lines.Current.DeleteMarker(0)
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Functions.CreateTab(OpenFileDialog.FileName)
        End If
        IdleMaker.Start()
    End Sub

    Private Sub CommentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentToolStripMenuItem.Click
        If CurrentTB IsNot Nothing Then
            CurrentTB.Lexing.ToggleLineComment()
        End If
    End Sub

    Private Sub UnCommentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnCommentToolStripMenuItem.Click
        If CurrentTB IsNot Nothing Then
            CurrentTB.Lexing.StreamComment()
        End If
    End Sub

    Private Sub CreateProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateProjectToolStripMenuItem.Click
        Functions.CreateProject()
    End Sub

    Private Sub LoadProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadProjectToolStripMenuItem.Click
        Functions.LoadProject()
    End Sub

    Private Sub ToolStripMenuItem8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        For Each tab As Editor In OwnedForms
            tab.Close()
        Next
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        If CurrentProjectPath = Nothing Then
            MsgBox("You don't have any project opened to close.")
        Else
            CurrentProjectPath = Nothing
            ProjectExplorerFrm.ProjectExplorer.Nodes(0).Nodes.Clear()
            ProjectExplorerFrm.ProjectExplorer.Nodes(1).Nodes.Clear()

            'Saving before closing.
            ToolStripMenuItem8_Click_1(Me, New EventArgs) 'just to save space :D, This is the Save All function.
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Functions.CreateTab(Nothing)
    End Sub

    Dim CurrentSelectedProjectExplorer As TreeNode

    Private Sub ProjectExplorer_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        CurrentSelectedProjectExplorer = e.Node
    End Sub

    Private Sub ProjectExplorer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            If Not CurrentProjectPath = Nothing Then
                If MsgBox("Are you sure you want to delete this file ?") = MsgBoxResult.Yes Then
                    If My.Computer.FileSystem.FileExists(CurrentProjectPath + "/Scripts/" + CurrentSelectedProjectExplorer.Text + ".pwn") Then
                        Try
                            ProjectExplorerFrm.ProjectExplorer.Nodes.Remove(CurrentSelectedProjectExplorer)
                            My.Computer.FileSystem.DeleteFile(CurrentProjectPath + "/Scripts/" + CurrentSelectedProjectExplorer.Text + ".pwn")
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ColorPickerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickerToolStripMenuItem.Click
        ColorChoice.Show()

    End Sub

    Private Sub DialogMakerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DialogMakerToolStripMenuItem.Click
        Dim Dlg As New DialogCreator
        Dlg.Show()

    End Sub

    Private Sub ToolStripButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton18.Click
        Dim Dlg As New DialogCreator
        Dlg.Show()
    End Sub

    Private Sub ToolStripButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton19.Click
        CreateProjectToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton20.Click
        Functions.LoadProject()
    End Sub

    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click
        NewToolStripMenuItem.PerformClick()

    End Sub

    Private Sub ToolStripButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton22.Click
        SaveToolStripMenuItem.PerformClick()

    End Sub

    Private Sub ToolStripButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton23.Click
        ToolStripMenuItem8.PerformClick()

    End Sub

    Private Sub ToolStripButton24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton24.Click
        ToolStripMenuItem11.PerformClick()

    End Sub

    Private Sub CodeSnipptesToolStripItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeSnipptesToolStripItem.Click
        CodeSnipptes.Show()

    End Sub

    Private Sub CloneInAnotherTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloneInAnotherTabToolStripMenuItem.Click
        If CurrentTB IsNot Nothing Then
            Functions.CreateTab(CurrentTB.Tag, CurrentTB)
        End If
    End Sub

    Dim IsProjectExplorerShowen As Boolean = False
    Private Sub ProjectExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectExplorerToolStripMenuItem.Click
        If IsProjectExplorerShowen = True Then
            ProjectExplorerFrm.Close()
            IsProjectExplorerShowen = False
        Else
            ProjectExplorerFrm.Show(MainDockPanel)
            IsProjectExplorerShowen = True
        End If
    End Sub

    Dim IsIncludeListShowen As Boolean = False
    Private Sub IncludeListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeListToolStripMenuItem.Click
        If IsIncludeListShowen = True Then
            IncludeListFrm.Close()
            IsIncludeListShowen = False
        Else
            IncludeListFrm.Show(MainDockPanel)
            IsIncludeListShowen = True
        End If
    End Sub

    'Dim IsDocumentMapShown As Boolean = False
    'Private Sub DocumentMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentMapToolStripMenuItem.Click
    '    If IsDocumentMapShown = True Then
    '        DocumentMapFrm.Close()
    '        IsDocumentMapShown = False
    '    Else
    '        DocumentMapFrm.Show(MainDockPanel)
    '        IsDocumentMapShown = True
    '    End If
    'End Sub

    Dim IsErrorListSHowen As Boolean = False
    Private Sub ErrorListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorListToolStripMenuItem.Click
        If IsErrorListSHowen = True Then
            ErrorsFrm.Close()
            IsErrorListSHowen = False
        Else
            ErrorsFrm.Show(MainDockPanel)
            IsErrorListSHowen = True
        End If
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MainDockPanel.SaveAsXml(Application.StartupPath + "/SavedDocks.xml")
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        If CurrentOpenedTab IsNot Nothing Then
            If MsgBox("Are you sure ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Setting.TextBox1.Text = "None" Or Setting.TextBox2.Text = "None" Then
                    MsgBox("Please head to settings and set SAMP server's path and SAMP client's.")
                Else
                    'Prepare
                    Dim ServerPort As Integer = 0 'Server Port
                    Dim AMXFile As String = Path.ChangeExtension(CurrentOpenedTab.Tag, ".amx")
                    Dim SAMPSrvr As String
                    If Setting.TextBox1.Text.EndsWith("\") Or Setting.TextBox1.Text.EndsWith("/") Then
                        SAMPSrvr = Setting.TextBox1.Text.Remove(Setting.TextBox1.Text.Count - 1, 1)
                    Else
                        SAMPSrvr = Setting.TextBox1.Text
                    End If

                    Dim objReader As New System.IO.StreamReader(SAMPSrvr + "\server.cfg") 'Read the settings
                    Do While objReader.Peek() <> -1
                        Dim Line As String
                        Line = objReader.ReadLine()

                        If Line.Contains("port") Then
                            Line = Line.Remove(0, 5)
                            ServerPort = Convert.ToInt16(Line)
                            Exit Do
                        End If
                    Loop
                    objReader.Close()

                    ToolStripButton7.PerformClick() 'Compile

                    Try
                        My.Computer.FileSystem.CopyFile(AMXFile, SAMPSrvr + "/gamemodes/" + Path.GetFileName(AMXFile), True) 'Copy the amx file.
                        Dim server As New Process 'Run the server.
                        With server
                            .StartInfo.UseShellExecute = False
                            .StartInfo.FileName = SAMPSrvr + "/samp-server.exe"
                            .StartInfo.WorkingDirectory = SAMPSrvr
                            .Start()
                        End With

                        Dim game As New Process 'Run the game.
                        With game
                            .StartInfo.UseShellExecute = False
                            .StartInfo.FileName = Setting.TextBox2.Text
                            .StartInfo.Arguments = "localhost:" + ServerPort.ToString
                            .Start()
                            .WaitForExit()
                        End With

                        If MsgBox("Do you wish to close the server ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            server.CloseMainWindow() 'Dont KILL...
                        End If
                    Catch ex As Exception
                        MsgBox("An error has occured, Check for any compile errors.")
                    End Try

                End If
            End If
        End If
    End Sub

    Dim IsSavedPositionsSaved As Boolean = False
    Private Sub SavedPositionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavedPositionsToolStripMenuItem.Click
        If IsSavedPositionsSaved = True Then
            SavedPositions.Close()
            IsSavedPositionsSaved = False
        Else
            SavedPositions.Show(MainDockPanel)
            IsSavedPositionsSaved = True
        End If
    End Sub

    Private Sub MainForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        GC.Collect()
        GC.GetTotalMemory(False)
    End Sub

    Private Sub GotoNextToolstripItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoNextToolstripItem.Click
        Dim line As Line = CurrentTB.Markers.FindNextMarker()
        If line IsNot Nothing Then
            CurrentTB.GoTo.Line(line.Number)
        End If
    End Sub

    Private Sub GotoPrevToolstripItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoPrevToolstripItem.Click
        Dim line As Line = CurrentTB.Markers.FindPreviousMarker()
        If line IsNot Nothing Then
            CurrentTB.GoTo.Line(line.Number)
        End If
    End Sub

    Private Sub AutoRebuildTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoRebuildTimer.Tick
        If CurrentTB IsNot Nothing Then
            If IsRebuildFinished = False Then Exit Sub

            ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                             ReBuildAutoComplete(CurrentOpenedTab)
                                         End Sub)
        End If
    End Sub

    Private Sub ScrollBarTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScrollBarTimer.Tick
        If CurrentTB Is Nothing Then Exit Sub
        Try
            CurrentTB.Margins(0).Width = CurrentTB.Lines.VisibleLines(CurrentTB.Lines.VisibleCount).Number.ToString.Count * 10
        Catch ex As Exception
        End Try
    End Sub
End Class
