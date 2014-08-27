Imports FastColoredTextBoxNS
Imports FarsiLibrary.Win
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Functions
    Inherits Form

    'Used In Bookmark Navigating.
    Private lastNavigatedDateTime As DateTime = DateTime.Now

    'Start of Bookmark functions.
    Public Function NavigateBackward() As Boolean
        Dim max As DateTime = Nothing
        Dim iLine As Integer = -1
        Dim tb As FastColoredTextBox = Nothing
        For iTab As Integer = 0 To MainForm.TabStrip.Items.Count - 1
            Dim t As FastColoredTextBox = TryCast(MainForm.TabStrip.Items(iTab).Controls(0), FastColoredTextBox)
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
            MainForm.TabStrip.SelectedItem = TryCast(tb.Parent, FATabStripItem)
            tb.Navigate(iLine)
            lastNavigatedDateTime = tb(iLine).LastVisit
            Console.WriteLine("Backward: " + lastNavigatedDateTime)
            tb.Focus()
            tb.Invalidate()
            result = True
        Else
            result = False
        End If
        Return result
    End Function
    Public Function NavigateForward() As Boolean
        Dim min As DateTime = DateTime.Now
        Dim iLine As Integer = -1
        Dim tb As FastColoredTextBox = Nothing
        For iTab As Integer = 0 To MainForm.TabStrip.Items.Count - 1
            Dim t As FastColoredTextBox = TryCast(MainForm.TabStrip.Items(iTab).Controls(0), FastColoredTextBox)
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
            MainForm.TabStrip.SelectedItem = TryCast(tb.Parent, FATabStripItem)
            tb.Navigate(iLine)
            lastNavigatedDateTime = tb(iLine).LastVisit
            Console.WriteLine("Forward: " + lastNavigatedDateTime)
            tb.Focus()
            tb.Invalidate()
            result = True
        Else
            result = False
        End If
        Return result
    End Function
    'End of bookmark functions.

    'Functions Save to Save the file.
    Public Function Save(ByVal tab As FATabStripItem) As Boolean
        'CurrentTB.Text.Replace("ï»¿", "") 'This characters are added for same reason somewhere in the script, So we are deleting them [THEY ARE INVISIBLE]
        Dim tb As FastColoredTextBox = TryCast(tab.Controls(0), FastColoredTextBox)
        Dim result As Boolean
        If tab.Tag Is Nothing Then
            If MainForm.SaveFileDialog.ShowDialog() <> DialogResult.OK Then
                result = False
                Return result
            End If
            tab.Title = Path.GetFileName(MainForm.SaveFileDialog.FileName)
            tab.Tag = MainForm.SaveFileDialog.FileName
        End If
        Try
            Dim Encoding As New System.Text.UTF8Encoding(False)
            MainForm.CurrentTB.SaveToFile(TryCast(tab.Tag, String), Encoding)
            tb.IsChanged = False
        Catch ex As Exception
            If MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) = DialogResult.Retry Then
                result = Save(tab)
                Return result
            End If
            result = False
            Return result
        End Try
        tb.Invalidate()
        result = True
        Return result
    End Function

    'Function Compile, Self explantory, To compile the file.
    Public Sub Compile(ByVal CurrentTB As FastColoredTextBox)
        Dim NumOfErrors As Integer
        Dim NumOfWarns As Integer

        If CurrentTB.IsChanged = True Then
            MainForm.ToolStripButton4.PerformClick()
            CurrentTB.IsChanged = False
        End If

        MainForm.Status.Text = "Compiling"

        Dim FileName As String = System.IO.Path.GetFileName(MainForm.TabStrip.SelectedItem.Tag.ToString)
        Dim path As String = System.IO.Path.GetDirectoryName(MainForm.TabStrip.SelectedItem.Tag.ToString)

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

        MainForm.ErrorDataGridView.Rows.Clear()

        For Each s As String In errs
            Dim Type As Image = Nothing
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
                MainForm.ErrorDataGridView.Rows.Add(Row)

                MainForm.ErrorDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            Catch ex As Exception
                'Do nothing on exption.
            End Try

        Next
        If NumOfErrors = 0 Then
            MainForm.Status.Text = "Successfully Compiled With 0 Errors And " + NumOfWarns.ToString + " Warnings"
            MainForm.IdleMaker.Start()
        Else
            MainForm.Status.Text = "Compiling Failed With " + NumOfErrors.ToString + " Errors And " + NumOfWarns.ToString + " Warnings"
            MainForm.IdleMaker.Start()
        End If

        If CurrentTB IsNot Nothing Then
            CurrentTB.OnTextChanged() 'Fix for the text being black.
        End If
    End Sub

    'Functions LoadSettings to load the settings.
    Public Sub LoadSettings()
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
                ElseIf Parts(0) = "CompileKey" Then
                    Dim Cnv As New KeysConverter
                    Setting.KEY_COMPILE = Cnv.ConvertFromString(Parts(1))
                    Setting.Label4.Text = Parts(1)
                End If
            Loop
        End If
    End Sub

    'Function CreateTab to create a new file and add it to the TabStrip.
    Public Function CreateTab(ByVal fileName As String, Optional ByVal IsBind As Boolean = False)
        Try
            Dim tb As FastColoredTextBox = New FastColoredTextBox()
            tb.Dock = DockStyle.Fill
            tb.LeftPadding = 17
            tb.Language = Language.CSharp
            tb.ContextMenuStrip = MainForm.RightClickMenu
            tb.BookmarkColor = Color.Red
            Dim tab As FATabStripItem = New FATabStripItem(If(fileName IsNot Nothing, Path.GetFileName(fileName), "[new]"), tb)
            tab.Tag = fileName
            If fileName <> Nothing Then
                If IsBind = True Then
                    Dim Encoding As New System.Text.UTF8Encoding(False)
                    tb.OpenBindingFile(fileName, Encoding)
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
            MainForm.TabStrip.AddTab(tab)
            MainForm.TabStrip.SelectedItem = tab
            tb.Focus()
            tb.DelayedTextChangedInterval = 1000
            tb.DelayedEventsInterval = 1000
            MainForm.HelpMenu.SetAutocompleteMenu(tb, MainForm.HelpMenu)
            AddHandler tb.TextChangedDelayed, New EventHandler(Of TextChangedEventArgs)(AddressOf MainForm.Code_TextD)
            AddHandler tb.TextChanged, New EventHandler(Of TextChangedEventArgs)(AddressOf MainForm.Code_TextChanged)
            tb.OnTextChanged(tb.Range)
            Return tb
        Catch ex As Exception
            If MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand) = DialogResult.Retry Then
                CreateTab(fileName)
            End If
        End Try
        Return 1
    End Function

    'Includes List Loading
    Dim PathsOfInc As New List(Of String) 'Used while loading the inc.
    Public Sub LoadIncs()
        MainForm.IncludeTreeView.Nodes.Clear()
        Dim di As New IO.DirectoryInfo(Application.StartupPath + "\include")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        For Each dra In diar1
            If dra.FullName.Contains(".inc") Then
                PathsOfInc.Add(dra.ToString)
            End If
        Next
        Dim Num As Integer = 0

        For Each FILE_NAME As String In PathsOfInc
            MainForm.IncludeTreeView.Nodes.Add(FILE_NAME)

            Dim objReader As New System.IO.StreamReader(Application.StartupPath + "/include/" + FILE_NAME)

            Do While objReader.Peek() <> -1
                Dim Line As String
                Line = objReader.ReadLine()
                Try
                    Dim tmp As String = Line
                    If Line.Contains("native ") And Line.Length > 8 Then
                        Line = Line.Replace("native ", "").Trim()
                        MainForm.SyntaxOfInc.Add(Line)
                        Line = Line.Remove(Line.IndexOf("("))
                        MainForm.Includes.Add(Line)
                        If Line.Contains(":") Then
                            Line = Line.Remove(0, Line.IndexOf(":") + 1)
                        End If
                        MainForm.IncludeTreeView.Nodes.Item(Num).Nodes.Add(Line)
                    End If
                Catch ex As Exception

                End Try
            Loop
            Num += 1
        Next
    End Sub

    'CreateProject Sub
    Public Sub CreateProject()
        MainForm.FolderBrowser.ShowNewFolderButton = True
        If MainForm.FolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not My.Computer.FileSystem.DirectoryExists(MainForm.FolderBrowser.SelectedPath) Then
                My.Computer.FileSystem.CreateDirectory(MainForm.FolderBrowser.SelectedPath)
            End If
            My.Computer.FileSystem.CreateDirectory(MainForm.FolderBrowser.SelectedPath + "/Scripts")
            My.Computer.FileSystem.WriteAllText(MainForm.FolderBrowser.SelectedPath + "/Main.pwn", "/*" + vbCrLf + "    This page has been generated by ExtremePAWN" + vbCrLf + "*/" + vbCrLf + vbCrLf + "//Includes" + vbCrLf + "#include <a_samp>" + vbCrLf + vbCrLf + "//Scripts", False)
            MainForm.CurrentProjectPath = MainForm.FolderBrowser.SelectedPath
            CreateTab(MainForm.FolderBrowser.SelectedPath + "/Main.pwn")
        End If
    End Sub

    Public Sub LoadProject()
        MainForm.FolderBrowser.ShowNewFolderButton = False
        If MainForm.FolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(MainForm.FolderBrowser.SelectedPath + "/Main.pwn") And My.Computer.FileSystem.DirectoryExists(MainForm.FolderBrowser.SelectedPath + "/Scripts") Then
                MainForm.CurrentProjectPath = MainForm.FolderBrowser.SelectedPath
                For Each File As String In My.Computer.FileSystem.GetFiles(MainForm.CurrentProjectPath + "/Scripts")
                    Dim FileName As String = Path.GetFileNameWithoutExtension(File)
                    MainForm.ProjectExplorer.Nodes(1).Nodes.Add(FileName)
                Next
                CreateTab(MainForm.CurrentProjectPath + "/Main.pwn")
            Else
                MsgBox("This folder isn't a vaild ExtremePAWN project folder.")
            End If
        End If
    End Sub

    Public Sub CreateFile(ByVal Name As String)
        If Not MainForm.CurrentProjectPath = Nothing Then
            My.Computer.FileSystem.CopyFile(Application.StartupPath + "/gamemodes/new.pwn", MainForm.CurrentProjectPath + "/Scripts/" + Name + ".pwn")
            MainForm.ProjectExplorer.Nodes(1).Nodes.Add(Name)
            MainForm.CurrentTB.InsertText("#include " + Chr(34) + "Scripts/" + Name + ".pwn" + Chr(34))
        Else
            MsgBox("You don't have a project loaded to add a new file.")
        End If
    End Sub
End Class
