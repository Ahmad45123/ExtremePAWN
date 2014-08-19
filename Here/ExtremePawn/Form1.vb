Imports System.IO
Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions
Imports FarsiLibrary.Win
Imports System.Threading

Public Class Form1

    Inherits Form

    Private explorerList As List(Of ExplorerItem) = New List(Of ExplorerItem)()

    Private Enum ExplorerItemType
        [Class]
        Method
        [Property]
        [Event]
    End Enum

    Private Class ExplorerItem
        Public type As ExplorerItemType

        Public title As String

        Public position As Integer
    End Class

    Private Class ExplorerItemComparer
        Implements IComparer(Of ExplorerItem)

        Public Function Compare(ByVal x As ExplorerItem, ByVal y As ExplorerItem) As Integer Implements IComparer(Of ExplorerItem).Compare
            Return x.title.CompareTo(y.title)
        End Function
    End Class

    Private Class DeclarationSnippet
        Inherits SnippetAutocompleteItem

        Public Sub New(ByVal snippet As String)
            MyBase.New(snippet)
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim pattern As String = Regex.Escape(fragmentText)
            Dim result As CompareResult
            If Regex.IsMatch(Me.Text, "\b" + pattern, RegexOptions.IgnoreCase) Then
                result = CompareResult.Visible
            Else
                result = CompareResult.Hidden
            End If
            Return result
        End Function
    End Class

    Private Class InsertSpaceSnippet
        Inherits AutocompleteItem

        Private pattern As String

        Public Overrides Property ToolTipTitle() As String
            Get
                Return Me.Text
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Public Sub New(ByVal pattern As String)
            MyBase.New("")
            Me.pattern = pattern
        End Sub

        Public Sub New()
            Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim result As CompareResult
            If Regex.IsMatch(fragmentText, Me.pattern) Then
                Me.Text = Me.InsertSpaces(fragmentText)
                If Me.Text <> fragmentText Then
                    result = CompareResult.Visible
                    Return result
                End If
            End If
            result = CompareResult.Hidden
            Return result
        End Function

        Public Function InsertSpaces(ByVal fragment As String) As String
            Dim i As Match = Regex.Match(fragment, Me.pattern)
            Dim result As String
            If i Is Nothing Then
                result = fragment
            Else
                If i.Groups(1).Value = "" AndAlso i.Groups(3).Value = "" Then
                    result = fragment
                Else
                    result = String.Concat(New String() {i.Groups(1).Value, " ", i.Groups(2).Value, " ", i.Groups(3).Value}).Trim()
                End If
            End If
            Return result
        End Function
    End Class

    Public Class TBInfo
        Public bookmarksLineId As HashSet(Of Integer) = New HashSet(Of Integer)()

        Public bookmarks As List(Of Integer) = New List(Of Integer)()

        Public popupMenu As AutocompleteMenu
    End Class

    Private lastNavigatedDateTime As DateTime = DateTime.Now
    Dim Paths As New ListBox
    Dim org As New ListBox

    'Styles :
    Dim BlueItalicStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Italic)
    Dim BlueStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Dim GreenStyle As Style = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Dim BoldStyle As Style = New TextStyle(Brushes.Black, Nothing, FontStyle.Bold + FontStyle.Underline)
    Dim TextStyle As Style = New TextStyle(Brushes.Indigo, Nothing, FontStyle.Regular)
    Dim NumberStyle As Style = New TextStyle(Brushes.Fuchsia, Nothing, FontStyle.Regular)

    Private Sub LoadIncs()
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
                Try
                    Dim tmp As String = Line
                    If Line.Contains("native ") And Line.Length > 8 Then
                        Line = Line.Replace("native ", "").Trim()
                        org.Items.Add(Line)
                        Line = Line.Remove(Line.IndexOf("("))
                        If Line.Contains(":") Then
                            Line = Line.Remove(0, Line.IndexOf(":") + 1)
                        End If
                        TreeView1.Nodes.Item(Num).Nodes.Add(Line)
                    End If
                Catch ex As Exception

                End Try
            Loop
            Num += 1
        Next
    End Sub

    Public Property CurrentTB() As FastColoredTextBox
        Get
            Dim result As FastColoredTextBox
            If FaTabStrip1.SelectedItem Is Nothing Then
                result = Nothing
            Else
                result = TryCast(FaTabStrip1.SelectedItem.Controls(0), FastColoredTextBox)
            End If
            Return result
        End Get
        Set(ByVal value As FastColoredTextBox)
            FaTabStrip1.SelectedItem = TryCast(value.Parent, FATabStripItem)
            value.Focus()
        End Set
    End Property

    Private Sub CreateTab(ByVal fileName As String, Optional ByVal IsBind As Boolean = False)
        Try
            Dim tb As FastColoredTextBox = New FastColoredTextBox()
            tb.Dock = DockStyle.Fill
            tb.LeftPadding = 17
            tb.Language = Language.CSharp
            tb.ContextMenuStrip = ContextMenuStrip1
            tb.BookmarkColor = Color.Red
            Dim tab As FATabStripItem = New FATabStripItem(If(fileName IsNot Nothing, Path.GetFileName(fileName), "[new]"), tb)
            tab.Tag = fileName
            If fileName <> Nothing Then
                If IsBind = True Then
                    tb.OpenBindingFile(fileName, System.Text.Encoding.UTF8)
                    tb.IsChanged = False
                    tb.ClearUndo()
                    GC.Collect()
                    GC.GetTotalMemory(True)
                Else
                    tb.OpenFile(fileName)
                End If
            Else
                tb.OpenFile(Application.StartupPath + "\gamemodes\new.pwn")
                tb.IsChanged = False
            End If
            tb.ClearUndo()
            tb.IsChanged = False
            FaTabStrip1.AddTab(tab)
            FaTabStrip1.SelectedItem = tab
            tb.Focus()
            tb.DelayedTextChangedInterval = 1000
            tb.DelayedEventsInterval = 1000
            AddHandler tb.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.Code_TextD)
            AddHandler tb.TextChanged, New EventHandler(Of TextChangedEventArgs)(AddressOf Me.Code_TextChanged)
            tb.OnTextChanged(tb.Range)
        Catch ex As Exception
            If MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) = DialogResult.Retry Then
                Me.CreateTab(fileName)
            End If
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateTab(Nothing)
        LoadIncs()
        LoadSettings()
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
        Dim list As List(Of FATabStripItem) = New List(Of FATabStripItem)()
        For Each tab As FATabStripItem In FaTabStrip1.Items
            list.Add(tab)
        Next
        For Each tab As FATabStripItem In list
            Dim args As TabStripItemClosingEventArgs = New TabStripItemClosingEventArgs(tab)
            Me.FaTabStrip1_TabStripItemClosing(args)
            If args.Cancel Then
                e.Cancel = True
                Exit For
            End If
            FaTabStrip1.RemoveTab(tab)
        Next
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

    Private Sub Code_TextD(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs)
        If CurrentTB IsNot Nothing Then
            'ThreadPool.QueueUserWorkItem(Sub(o As Object)
            'Me.ReBuildObjectExplorer(CurrentTB.Text)
            'End Sub)
        End If
    End Sub

    Private Sub Code_TextChanged(ByVal sender As System.Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles FastColoredTextBox1.TextChanged
        Dim range As Range = TryCast(sender, FastColoredTextBox).VisibleRange
        range.ClearStyle(GreenStyle)
        range.SetStyle(GreenStyle, "(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline)
        range.SetStyle(GreenStyle, "(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline And RegexOptions.RightToLeft)

        'Start syntax highliting code :
        e.ChangedRange.ClearStyle({BlueStyle, BlueItalicStyle, BoldStyle, GreenStyle})
        e.ChangedRange.SetStyle(GreenStyle, "//.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(BlueItalicStyle, "#.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(BlueStyle, "\b(public|stock|new|enum|return|if|else|for|break|continue)\b", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(BoldStyle, "\b(public|stock|enum)\s+(?<range>[\w_]+?)\b")
        e.ChangedRange.SetStyle(TextStyle, Chr(34) + ".*" + Chr(34), RegexOptions.Multiline)
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
            CurrentTB.InsertText(Format)
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
        CreateTab(Nothing)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If Me.FaTabStrip1.SelectedItem IsNot Nothing Then
            Me.Save(Me.FaTabStrip1.SelectedItem)
        End If
        Status.Text = "Saved"
        IdleMaker.Start()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CreateTab(OpenFileDialog1.FileName, True)
        End If
        IdleMaker.Start()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim NumOfErrors As Integer
        Dim NumOfWarns As Integer

        If CurrentTB.IsChanged = True Then
            ToolStripButton4.PerformClick()
            CurrentTB.IsChanged = False
        End If

        Status.Text = "Compiling"

        Dim FileName As String = System.IO.Path.GetFileName(FaTabStrip1.SelectedItem.Tag.ToString)
        Dim path As String = System.IO.Path.GetDirectoryName(FaTabStrip1.SelectedItem.Tag.ToString)

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
            ElseIf s.Contains("warn") Then
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

    Private Sub ToolsBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim OldSize As Size
        If ToolStrip1.Visible = True Then
            ToolStrip1.Visible = False

            OldSize = CurrentTB.Size
            OldSize.Height += 28
            CurrentTB.Size = OldSize
            CurrentTB.Top -= 30

            OldSize = TreeView1.Size
            OldSize.Height += 28
            TreeView1.Size = OldSize
            TreeView1.Top -= 30
        Else
            ToolStrip1.Visible = True

            OldSize = CurrentTB.Size
            OldSize.Height -= 28
            CurrentTB.Size = OldSize
            CurrentTB.Top += 30

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
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CreateTab(OpenFileDialog1.FileName)
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

    Private Sub KeyboardShortcutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyboardShortcutsToolStripMenuItem.Click


    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Developed By Ahmad45123" + vbCrLf + vbCrLf + "For any suggestions or bug reports, Dont hesitate in emailing me at ahmad.gasser@gamil.com" + vbCrLf + vbCrLf + "Thanks for using this editor.")
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        If FontDialog1.ShowDialog = DialogResult.OK Then
            CurrentTB.Font = FontDialog1.Font
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

    Private Sub ReBuildHelpMenu(ByVal Text As String)
        Array.Clear(HelpMenu.Items, 0, HelpMenu.Items.Length)

    End Sub

    Private Sub ReBuildObjectExplorer(ByVal text As String)
        Try
            text = text.Replace("#", "")
            Dim list As List(Of ExplorerItem) = New List(Of ExplorerItem)()
            Dim lastClassIndex As Integer = -1
            Dim regex As Regex = New Regex("^\s*(public|stock|define)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline)
            For Each r As Match In regex.Matches(text)
                Try
                    Dim s As String = r.Value
                    Dim i As Integer = s.IndexOfAny(New Char() {"=", "{", ";"})
                    If i >= 0 Then
                        s = s.Substring(0, i)
                    End If
                    s = s.Trim()
                    Dim item As ExplorerItem = New ExplorerItem() With {.title = s, .position = r.Index}
                    If regex.IsMatch(item.title, "\b(public|stock)\b") Then
                        item.title = item.title.Substring(item.title.IndexOf(" ")).Trim()
                        item.type = ExplorerItemType.[Class]
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
                        lastClassIndex = list.Count
                    ElseIf regex.IsMatch(item.title, "\b(define)\b") Then
                        item.title = item.title.Substring(item.title.IndexOf(" ")).Trim()
                        Dim tst As String() = item.title.Split(" ")
                        item.title = tst(0)
                        item.type = ExplorerItemType.Property
                        list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
                        lastClassIndex = list.Count
                    End If
                    list.Add(item)
                Catch ex_2BF As Exception
                    Console.WriteLine(ex_2BF)
                End Try
            Next
            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), New ExplorerItemComparer())
            MyBase.BeginInvoke(Sub()
                                   Me.explorerList = list
                                   Me.dgvObjectExplorer.RowCount = Me.explorerList.Count
                                   Me.dgvObjectExplorer.Invalidate()
                               End Sub)
        Catch ex_332 As Exception
            Console.WriteLine(ex_332)
        End Try
    End Sub

    Private Sub dgvObjectExplorer_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) Handles dgvObjectExplorer.CellValueNeeded
        Try
            Dim item As ExplorerItem = Me.explorerList(e.RowIndex)
            If e.ColumnIndex = 1 Then
                e.Value = item.title
            Else
                Select Case item.type
                    Case ExplorerItemType.[Class]
                        e.Value = My.Resources.class_libraries
                    Case ExplorerItemType.Method
                        e.Value = My.Resources.box
                    Case ExplorerItemType.[Property]
                        e.Value = My.Resources._property
                    Case ExplorerItemType.[Event]
                        e.Value = My.Resources.lightning
                End Select
            End If
        Catch ex_8D As Exception
        End Try
    End Sub

    Private Sub dgvObjectExplorer_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvObjectExplorer.CellMouseClick
        If Me.CurrentTB IsNot Nothing Then
            Dim item As ExplorerItem = Me.explorerList(e.RowIndex)
            Me.CurrentTB.GoEnd()
            Me.CurrentTB.SelectionStart = item.position
            Me.CurrentTB.DoSelectionVisible()
            Me.CurrentTB.Focus()
        End If
    End Sub

    Private Function Save(ByVal tab As FATabStripItem) As Boolean
        Dim tb As FastColoredTextBox = TryCast(tab.Controls(0), FastColoredTextBox)
        Dim result As Boolean
        If tab.Tag Is Nothing Then
            If Me.SaveFileDialog1.ShowDialog() <> DialogResult.OK Then
                result = False
                Return result
            End If
            tab.Title = Path.GetFileName(Me.SaveFileDialog1.FileName)
            tab.Tag = Me.SaveFileDialog1.FileName
        End If
        Try
            CurrentTB.SaveToFile(TryCast(tab.Tag, String), System.Text.Encoding.UTF8)
            tb.IsChanged = False
        Catch ex As Exception
            If MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) = DialogResult.Retry Then
                result = Me.Save(tab)
                Return result
            End If
            result = False
            Return result
        End Try
        tb.Invalidate()
        result = True
        Return result
    End Function

    Private Sub FaTabStrip1_TabStripItemClosing(ByVal e As FarsiLibrary.Win.TabStripItemClosingEventArgs) Handles FaTabStrip1.TabStripItemClosing
        If CurrentTB IsNot Nothing Then
            CurrentTB.CloseBindingFile()

        End If
        If TryCast(e.Item.Controls(0), FastColoredTextBox).IsChanged Then
            Dim dialogResult As DialogResult = MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk)
            If dialogResult <> dialogResult.Cancel Then
                If dialogResult = dialogResult.Yes Then
                    If Not Me.Save(e.Item) Then
                        e.Cancel = True
                    End If
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        If FastColoredTextBox1.Visible = False Then
            FastColoredTextBox1.Visible = True
            Dim Size As Size = FaTabStrip1.Size
            Size.Height = Size.Height - 250
            FaTabStrip1.Size = Size
            FastColoredTextBox1.SourceTextBox = CurrentTB
        Else
            FastColoredTextBox1.Visible = False
            Dim Size As Size = FaTabStrip1.Size
            Size.Height = Size.Height + 250
            FaTabStrip1.Size = Size
        End If
    End Sub

    Private Sub FaTabStrip1_TabStripItemSelectionChanged(ByVal e As FarsiLibrary.Win.TabStripItemChangedEventArgs) Handles FaTabStrip1.TabStripItemSelectionChanged
        If FastColoredTextBox1.Visible = True Then
            FastColoredTextBox1.SourceTextBox = CurrentTB
        End If

        If Me.CurrentTB IsNot Nothing Then
            Me.CurrentTB.Focus()
            Dim text As String = Me.CurrentTB.Text
            '   ThreadPool.QueueUserWorkItem(Sub(o As Object)
            '   Me.ReBuildObjectExplorer(text)
            'End Sub)
        End If
    End Sub

    Private Sub FindToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem1.Click
        CurrentTB.ShowFindDialog()

    End Sub

    Private Sub ReplaceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem1.Click
        CurrentTB.ShowReplaceDialog()

    End Sub

    Private Function NavigateBackward() As Boolean
        Dim max As DateTime = Nothing
        Dim iLine As Integer = -1
        Dim tb As FastColoredTextBox = Nothing
        For iTab As Integer = 0 To FaTabStrip1.Items.Count - 1
            Dim t As FastColoredTextBox = TryCast(FaTabStrip1.Items(iTab).Controls(0), FastColoredTextBox)
            For i As Integer = 0 To t.LinesCount - 1
                If t(i).LastVisit < Me.lastNavigatedDateTime AndAlso t(i).LastVisit > max Then
                    max = t(i).LastVisit
                    iLine = i
                    tb = t
                End If
            Next
        Next
        Dim result As Boolean
        If iLine >= 0 Then
            FaTabStrip1.SelectedItem = TryCast(tb.Parent, FATabStripItem)
            tb.Navigate(iLine)
            Me.lastNavigatedDateTime = tb(iLine).LastVisit
            Console.WriteLine("Backward: " + Me.lastNavigatedDateTime)
            tb.Focus()
            tb.Invalidate()
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Private Function NavigateForward() As Boolean
        Dim min As DateTime = DateTime.Now
        Dim iLine As Integer = -1
        Dim tb As FastColoredTextBox = Nothing
        For iTab As Integer = 0 To FaTabStrip1.Items.Count - 1
            Dim t As FastColoredTextBox = TryCast(FaTabStrip1.Items(iTab).Controls(0), FastColoredTextBox)
            For i As Integer = 0 To t.LinesCount - 1
                If t(i).LastVisit > Me.lastNavigatedDateTime AndAlso t(i).LastVisit < min Then
                    min = t(i).LastVisit
                    iLine = i
                    tb = t
                End If
            Next
        Next
        Dim result As Boolean
        If iLine >= 0 Then
            FaTabStrip1.SelectedItem = TryCast(tb.Parent, FATabStripItem)
            tb.Navigate(iLine)
            Me.lastNavigatedDateTime = tb(iLine).LastVisit
            Console.WriteLine("Forward: " + Me.lastNavigatedDateTime)
            tb.Focus()
            tb.Invalidate()
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Private Sub GotoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoToolStripMenuItem1.Click
        CurrentTB.ShowGoToDialog()

    End Sub

    Private Sub GotoBookmarkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoBookmarkToolStripMenuItem.Click
        NavigateForward()
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
        NavigateBackward()

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If CurrentTB IsNot Nothing Then
            CurrentTB.GoEnd()
            CurrentTB.SelectionStart = Convert.ToInt16(DataGridView1.Rows(e.RowIndex).Cells(3).Value)
            CurrentTB.DoSelectionVisible()
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CreateTab(OpenFileDialog1.FileName, True)
        End If
        IdleMaker.Start()
    End Sub
End Class
