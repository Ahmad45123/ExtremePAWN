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
Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions
Imports FarsiLibrary.Win
Imports System.Threading

Public Class MainForm

    'Used for populating a TreeView from another thread
    Public Delegate Sub Add(ByVal i As Integer)

    'Project System
    Public CurrentProjectPath As String 'Will be nothing if there is no project loaded.

    Public Property CurrentTB() As FastColoredTextBox 'Returns the current opened object of FastColoredTextBox
        Get
            Dim result As FastColoredTextBox
            If TabStrip.SelectedItem Is Nothing Then
                result = Nothing
            Else
                result = TryCast(TabStrip.SelectedItem.Controls(0), FastColoredTextBox)
            End If
            Return result
        End Get
        Set(ByVal value As FastColoredTextBox)
            TabStrip.SelectedItem = TryCast(value.Parent, FATabStripItem)
            value.Focus()
        End Set
    End Property

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

        'Add the resizer
        ClsCapture.CaptureMe(TextBox1)
    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True And e.KeyValue = Keys.S Then
            ToolStripButton4.PerformClick() 'Save
        ElseIf e.KeyCode = Setting.KEY_COMPILE Then
            ToolStripButton7.PerformClick() 'Compile
        End If
    End Sub

    Private Sub IdleMaker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdleMaker.Tick
        IdleMaker.Stop()
        Status.Text = "Idle"

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Saving before closing.
        Dim list As List(Of FATabStripItem) = New List(Of FATabStripItem)()
        For Each tab As FATabStripItem In TabStrip.Items
            list.Add(tab)
        Next
        For Each tab As FATabStripItem In list
            Dim args As TabStripItemClosingEventArgs = New TabStripItemClosingEventArgs(tab)
            Me.FaTabStrip1_TabStripItemClosing(args)
            If args.Cancel Then
                e.Cancel = True
                Exit For
            End If
            TabStrip.RemoveTab(tab)
        Next
    End Sub

    Public Sub Code_TextD(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) 'Text delayed event. Handled on any Instance of FastColoredTextbox created by CreateTab.
        If CurrentTB IsNot Nothing Then
            If ObjectExplorer.Visible = True Then 'If its not visible, Why bothering in filling it ?...
                ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                                 ReBuildObjectExplorerAndHelpMenu(CurrentTB.Text)
                                             End Sub)
            End If
        End If
    End Sub

    Public MulinLineGreenStyle As Style = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Public Sub Code_TextChanged(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles SplitEditorCode.TextChanged
        Dim range As Range = TryCast(sender, FastColoredTextBox).VisibleRange
        range.ClearStyle(MulinLineGreenStyle)
        range.SetStyle(MulinLineGreenStyle, "(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline)
        range.SetStyle(MulinLineGreenStyle, "(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline + RegexOptions.RightToLeft)

        e.ChangedRange.SetFoldingMarkers("{", "}") 'Bracket Folding
        e.ChangedRange.ClearStyle({BlueItalicStyle, BoldStyle, BlueStyle, TextStyle, GreenStyle, NumberStyle})
        e.ChangedRange.SetStyle(GreenStyle, "//.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(GreenStyle, "\/\*[\s\S]*?\*\/", RegexOptions.Multiline) 'For multiline comments in one line :P
        e.ChangedRange.SetStyle(BlueItalicStyle, "#.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(BoldStyle, "\b(public|stock|enum)\s+(?<range>[\w_]+?)\b")
        e.ChangedRange.SetStyle(BlueStyle, "\b(public|stock|new|enum|return|if|else|for|break|continue|native|bool|int|true|false|switch|case)\b", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(TextStyle, Chr(34) + ".*" + Chr(34), RegexOptions.Multiline)
        e.ChangedRange.SetStyle(NumberStyle, "([0-9])", RegexOptions.Multiline)
    End Sub

    Private Sub AutoSaver_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaver.Tick
        ToolStripButton4.PerformClick()

    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeTreeView.DoubleClick
        Dim Func As String = IncludeTreeView.SelectedNode.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = PublicSyntax.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = PublicSyntax.Items.Item(Index)
            CurrentTB.InsertText(Format)
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles IncludeTreeView.AfterSelect
        Dim Func As String = IncludeTreeView.SelectedNode.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = PublicSyntax.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = PublicSyntax.Items.Item(Index)
            Status.Text = Format
        End If

    End Sub

    Private Sub HelpMenu_Selected(ByVal sender As System.Object, ByVal e As AutocompleteMenuNS.SelectedEventArgs) Handles HelpMenu.Selected
        Dim Func As String = e.Item.Text
        Func = Func.Replace("      ", "")
        Dim Index As Integer = PublicSyntax.FindString(Func, -1)
        If Not Index = -1 Then
            Dim Format As String = PublicSyntax.Items.Item(Index)
            Status.Text = Format
        End If
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        ColorChoice.Show()

    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        CurrentTB.Paste()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        CurrentTB.Cut()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        CurrentTB.Copy()
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        CurrentTB.Redo()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        CurrentTB.Undo()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        CurrentTB.ShowFindDialog()

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        CurrentTB.ShowReplaceDialog()

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        CreateProjectToolStripMenuItem.PerformClick()

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If Me.TabStrip.SelectedItem IsNot Nothing Then
            Functions.Save(Me.TabStrip.SelectedItem)
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

    Private Sub ToolsBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim OldSize As Size
        If ToolStrip.Visible = True Then
            ToolStrip.Visible = False

            OldSize = CurrentTB.Size
            OldSize.Height += 28
            CurrentTB.Size = OldSize
            CurrentTB.Top -= 30

            OldSize = IncludeTreeView.Size
            OldSize.Height += 28
            IncludeTreeView.Size = OldSize
            IncludeTreeView.Top -= 30
        Else
            ToolStrip.Visible = True

            OldSize = CurrentTB.Size
            OldSize.Height -= 28
            CurrentTB.Size = OldSize
            CurrentTB.Top += 30

            OldSize = IncludeTreeView.Size
            OldSize.Height -= 28
            IncludeTreeView.Size = OldSize
            IncludeTreeView.Top += 30
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If TabStrip.SelectedItem.Title = "Main.pwn" Then
            Functions.CreateFile(InputBox("Please enter a name for the new file." + vbCrLf + "NOTE: Pressing cancel willn't cancel the operation."))
        Else
            MsgBox("Make sure you have Main.pwn file open." + vbCrLf + "And also make sure you placed your cursor you want to place the include.")
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
        MsgBox("Developed By Ahmad45123 AKA Johny Mac" + vbCrLf + vbCrLf + "For any suggestions or bug reports, Dont hesitate in emailing me at ahmad.gasser@gmail.com" + vbCrLf + vbCrLf + "Thanks for using this editor.")
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        If CodeFont.ShowDialog = DialogResult.OK Then
            CurrentTB.Font = CodeFont.Font
            SplitEditorCode.Font = CodeFont.Font

        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        CurrentTB.Undo()

    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        CurrentTB.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        CurrentTB.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        CurrentTB.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        CurrentTB.Paste()
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        CurrentTB.ShowFindDialog()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        CurrentTB.ShowReplaceDialog()

    End Sub

    Private Sub GoToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToToolStripMenuItem.Click
        CurrentTB.ShowGoToDialog()

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        CurrentTB.SelectAll()

    End Sub

    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        CurrentTB.IncreaseIndent()

    End Sub

    Private Sub ToolStripButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton15.Click
        CurrentTB.DecreaseIndent()

    End Sub

    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click
        CurrentTB.DoAutoIndent()

    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        CurrentTB.Copy()

    End Sub

    Private Sub CutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem1.Click
        CurrentTB.Cut()

    End Sub


    Private Sub PasteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        CurrentTB.Paste()

    End Sub

    'Function ReBuildObjectExplorer to rebuild the object explorer contents.
    Public PublicSyntax As New ListBox
    Public SyntaxOfInc As New List(Of String)
    Public Includes As New List(Of String)
    Public Sub ReBuildObjectExplorerAndHelpMenu(ByVal text As String)
        Dim DeleteProjectExplorer As Action = Sub() ProjectExplorer.Nodes(0).Nodes.Clear()
        Try
            PublicSyntax.Items.Clear()
            ProjectExplorer.Invoke(DeleteProjectExplorer)
        Catch ex As Exception
        End Try
        Dim IsAdd As Boolean = True
        Dim HelpMenuItems = New List(Of String)()
        Try
            text = text.Replace("#", "")
            Dim list As List(Of ObjectExplorerClass.ExplorerItem) = New List(Of ObjectExplorerClass.ExplorerItem)()
            Dim lastClassIndex As Integer = -1
            Dim regex As Regex = New Regex("^\s*(public|stock|define|include)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline)
            For Each r As Match In regex.Matches(text)
                Try
                    Dim s As String = r.Value
                    Dim i As Integer = s.IndexOfAny(New Char() {"=", "{", ";"})
                    If i >= 0 Then
                        s = s.Substring(0, i)
                    End If
                    s = s.Trim()
                    Dim item As ObjectExplorerClass.ExplorerItem = New ObjectExplorerClass.ExplorerItem() With {.title = s, .position = r.Index}
                    If regex.IsMatch(item.title, "\b(public|stock)\b") Then
                        item.title = item.title.Substring(item.title.IndexOf(" ")).Trim()
                        PublicSyntax.Items.Add(item.title)
                        item.title = item.title.Remove(item.title.IndexOf("("))
                        HelpMenuItems.Add(item.title)
                        item.type = ObjectExplorerClass.ExplorerItemType.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ObjectExplorerClass.ExplorerItemComparer())
                        lastClassIndex = list.Count
                    ElseIf regex.IsMatch(item.title, "\b(define)\b") Then
                        item.title = item.title.Substring(item.title.IndexOf(" ")).Trim()
                        Dim tst As String() = item.title.Split(" ")
                        item.title = tst(0)
                        HelpMenuItems.Add(item.title)
                        item.type = ObjectExplorerClass.ExplorerItemType.Property
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ObjectExplorerClass.ExplorerItemComparer())
                        lastClassIndex = list.Count
                    ElseIf regex.IsMatch(item.title, "\b(include)\b") Then
                        If item.title.Contains(Chr(34)) Then Continue For
                        item.title = item.title.Replace("<", "")
                        item.title = item.title.Replace(">", "")
                        item.title = item.title.Substring(item.title.IndexOf(" "))
                        item.title = item.title.Replace(" ", "")
                        Dim action As Action = Sub() ProjectExplorer.Nodes(0).Nodes.Add(item.title)
                        ProjectExplorer.Invoke(action)
                        IsAdd = False
                    End If
                    If IsAdd = True Then list.Add(item) Else IsAdd = True
                Catch ex_2BF As Exception
                    Console.WriteLine(ex_2BF)
                End Try
            Next
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ObjectExplorerClass.ExplorerItemComparer())
            MyBase.BeginInvoke(Sub()
                                   ObjectExplorerClass.explorerList = list
                                   ObjectExplorer.RowCount = ObjectExplorerClass.explorerList.Count
                                   ObjectExplorer.Invalidate()
                               End Sub)
        Catch ex_332 As Exception
            Console.WriteLine(ex_332)
        End Try
        For Each Str As String In Includes
            HelpMenuItems.Add(Str)
        Next
        For Each Str As String In SyntaxOfInc
            PublicSyntax.Items.Add(Str)
        Next
        HelpMenu.SetAutocompleteItems(HelpMenuItems)
    End Sub

    Private Sub ObjectExplorer_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) Handles ObjectExplorer.CellValueNeeded
        Try
            Dim item As ObjectExplorerClass.ExplorerItem = ObjectExplorerClass.explorerList(e.RowIndex)
            If e.ColumnIndex = 1 Then
                e.Value = item.title
            Else
                Select Case item.type
                    Case ObjectExplorerClass.ExplorerItemType.[Class]
                        e.Value = My.Resources.class_libraries
                    Case ObjectExplorerClass.ExplorerItemType.[Property]
                        e.Value = My.Resources._property
                End Select
            End If
        Catch ex_8D As Exception
        End Try
    End Sub

    Private Sub ObjectExplorer_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles ObjectExplorer.CellMouseDoubleClick
        If Me.CurrentTB IsNot Nothing Then
            Dim item As ObjectExplorerClass.ExplorerItem = ObjectExplorerClass.explorerList(e.RowIndex)
            Me.CurrentTB.GoEnd()
            Me.CurrentTB.SelectionStart = item.position
            Me.CurrentTB.DoSelectionVisible()
            Me.CurrentTB.Focus()
        End If
    End Sub

    Private Sub FaTabStrip1_TabStripItemClosing(ByVal e As FarsiLibrary.Win.TabStripItemClosingEventArgs) Handles TabStrip.TabStripItemClosing
        If CurrentTB IsNot Nothing Then
            CurrentTB.CloseBindingFile()

        End If
        If TryCast(e.Item.Controls(0), FastColoredTextBox).IsChanged Then
            Dim dialogResult As DialogResult = MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
            If dialogResult <> dialogResult.Cancel Then
                If dialogResult = dialogResult.Yes Then
                    If Not Functions.Save(e.Item) Then
                        e.Cancel = True
                    End If
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        If SplitEditorCode.Visible = False Then
            SplitEditorCode.Visible = True
            TextBox1.Visible = True
            Dim Y As Integer = TabStrip.Location.Y
            Y += TabStrip.Size.Height
            Dim AY As Integer = TextBox1.Location.Y
            AY += TextBox1.Size.Height - 5
            If Y > AY Then
                Dim Dif As Integer = Y - AY
                EditSize("height", Dif, "-", TabStrip)
            Else
                Dim Dif As Integer = AY - Y
                EditSize("height", Dif, "+", TabStrip)
            End If
            SplitEditorCode.SourceTextBox = CurrentTB
        Else
            SplitEditorCode.Visible = False
            TextBox1.Visible = False
            Dim Y As Integer = TabStrip.Location.Y
            Y += TabStrip.Size.Height
            Dim AY As Integer = ObjectExplorer.Location.Y
            AY += ObjectExplorer.Size.Height
            If Y > AY Then
                Dim Dif As Integer = Y - AY
                EditSize("height", Dif, "-", TabStrip)
            Else
                Dim Dif As Integer = AY - Y
                EditSize("height", Dif, "+", TabStrip)
            End If
        End If
    End Sub

    Private Sub FaTabStrip1_TabStripItemSelectionChanged(ByVal e As FarsiLibrary.Win.TabStripItemChangedEventArgs) Handles TabStrip.TabStripItemSelectionChanged
        If SplitEditorCode.Visible = True Then
            SplitEditorCode.SourceTextBox = CurrentTB
        End If

        If Me.CurrentTB IsNot Nothing Then
            Me.CurrentTB.Focus()
            Dim text As String = Me.CurrentTB.Text
            ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                             ReBuildObjectExplorerAndHelpMenu(text)
                                         End Sub)
            DocumentMap.Target = CurrentTB
        End If
    End Sub

    Private Sub FindToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem1.Click
        CurrentTB.ShowFindDialog()

    End Sub

    Private Sub ReplaceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem1.Click
        CurrentTB.ShowReplaceDialog()

    End Sub

    Private Sub GotoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoToolStripMenuItem1.Click
        CurrentTB.ShowGoToDialog()

    End Sub

    Private Sub GotoBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoBookmarkToolStripMenuItem.Click
        Functions.NavigateForward()
    End Sub

    Private Sub AddBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBookmarkToolStripMenuItem.Click
        If Me.CurrentTB IsNot Nothing Then
            Dim id As Integer = Me.CurrentTB(Me.CurrentTB.Selection.Start.iLine).UniqueId
            CurrentTB.Bookmarks.Add(id)
        End If
    End Sub

    Private Sub RemoveBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveBookmarkToolStripMenuItem.Click
        If Me.CurrentTB IsNot Nothing Then
            Dim id As Integer = Me.CurrentTB(Me.CurrentTB.Selection.Start.iLine).UniqueId
            CurrentTB.Bookmarks.Remove(id)
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Functions.NavigateBackward()

    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Functions.CreateTab(OpenFileDialog.FileName, True)
        End If
        IdleMaker.Start()
    End Sub

    Private Sub CommentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentToolStripMenuItem.Click
        If CurrentTB IsNot Nothing Then
            CurrentTB.InsertLinePrefix("//")
        End If
    End Sub

    Private Sub UnCommentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnCommentToolStripMenuItem.Click
        If CurrentTB IsNot Nothing Then
            CurrentTB.RemoveLinePrefix("//")
        End If
    End Sub

    Private Sub ObjectExplToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjectExplToolStripMenuItem.Click
        ViewManager.TogObjectExplorer()

    End Sub

    Private Sub IncludeListDocumentMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeListDocumentMapToolStripMenuItem.Click
        ViewManager.TogListAndMap()

    End Sub

    Private Sub ErrorListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorListToolStripMenuItem.Click
        ViewManager.TogErrorList()

    End Sub

    Private Sub CreateProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateProjectToolStripMenuItem.Click
        Functions.CreateProject()

    End Sub

    Private Sub ProjectExplorer_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ProjectExplorer.NodeMouseDoubleClick
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "/include/" + e.Node.Text + ".inc") Then
            Functions.CreateTab(Application.StartupPath + "/include/" + e.Node.Text + ".inc")
        ElseIf e.Node.Index = 2 And Not CurrentProjectPath = Nothing Then
            Functions.CreateTab(CurrentProjectPath + "/Main.pwn")
        ElseIf My.Computer.FileSystem.FileExists(CurrentProjectPath + "/Scripts/" + e.Node.Text + ".pwn") And Not CurrentProjectPath = Nothing Then
            Functions.CreateTab(CurrentProjectPath + "/Scripts/" + e.Node.Text + ".pwn")
        End If
    End Sub

    Private Sub LoadProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadProjectToolStripMenuItem.Click
        Functions.LoadProject()
    End Sub

    Private Sub ToolStripMenuItem8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Dim list As List(Of FATabStripItem) = New List(Of FATabStripItem)()
        For Each tab As FATabStripItem In TabStrip.Items
            list.Add(tab)
        Next
        For Each tab As FATabStripItem In list
            Dim args As TabStripItemClosingEventArgs = New TabStripItemClosingEventArgs(tab)
            Me.FaTabStrip1_TabStripItemClosing(args)
            If args.Cancel Then
                Exit For
            End If
        Next
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        CurrentProjectPath = Nothing
        ProjectExplorer.Nodes(0).Nodes.Clear()
        ProjectExplorer.Nodes(1).Nodes.Clear()

        'Saving before closing.
        Dim list As List(Of FATabStripItem) = New List(Of FATabStripItem)()
        For Each tab As FATabStripItem In TabStrip.Items
            list.Add(tab)
        Next
        For Each tab As FATabStripItem In list
            Dim args As TabStripItemClosingEventArgs = New TabStripItemClosingEventArgs(tab)
            Me.FaTabStrip1_TabStripItemClosing(args)
            If args.Cancel Then
                Exit For
            End If
            TabStrip.RemoveTab(tab)
        Next
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Functions.CreateTab(Nothing)
    End Sub

    Dim CurrentSelectedProjectExplorer As TreeNode

    Private Sub ProjectExplorer_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles ProjectExplorer.NodeMouseClick
        CurrentSelectedProjectExplorer = e.Node
    End Sub

    Private Sub ProjectExplorer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProjectExplorer.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Not CurrentProjectPath = Nothing Then
                If MsgBox("Are you sure you want to delete this file ?") = MsgBoxResult.Yes Then
                    If My.Computer.FileSystem.FileExists(CurrentProjectPath + "/Scripts/" + CurrentSelectedProjectExplorer.Text + ".pwn") Then
                        Try
                            ProjectExplorer.Nodes.Remove(CurrentSelectedProjectExplorer)
                            My.Computer.FileSystem.DeleteFile(CurrentProjectPath + "/Scripts/" + CurrentSelectedProjectExplorer.Text + ".pwn")
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ProjectExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectExplorerToolStripMenuItem.Click
        TogProjectExplorer()
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

    Private Sub ErrorDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ErrorDataGridView.CellDoubleClick
        If Me.CurrentTB IsNot Nothing Then
            Dim RowNumber As Integer = ErrorDataGridView.Rows(e.RowIndex).Cells(3).Value
            Me.CurrentTB.GoEnd()
            Me.CurrentTB.SelectionStart = CurrentTB.Text.IndexOf(CurrentTB.GetLineText(RowNumber)) - 1
            Me.CurrentTB.DoSelectionVisible()
            Me.CurrentTB.Focus()
        End If
    End Sub
End Class
