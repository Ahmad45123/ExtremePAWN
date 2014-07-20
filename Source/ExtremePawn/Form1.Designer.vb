<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Code = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.IdleMaker = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.AutoSaver = New System.Windows.Forms.Timer(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.HelpMenu = New AutocompleteMenuNS.AutocompleteMenu()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Type = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ErrorText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunctionListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeyboardShortcutsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.Code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Code
        '
        Me.Code.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Code.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.HelpMenu.SetAutocompleteMenu(Me.Code, Me.HelpMenu)
        Me.Code.AutoScrollMinSize = New System.Drawing.Size(27, 14)
        Me.Code.BackBrush = Nothing
        Me.Code.BookmarkColor = System.Drawing.Color.Red
        Me.Code.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.Code.CharHeight = 14
        Me.Code.CharWidth = 8
        Me.Code.CurrentLineColor = System.Drawing.Color.Silver
        Me.Code.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Code.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Code.IsReplaceMode = False
        Me.Code.Language = FastColoredTextBoxNS.Language.CSharp
        Me.Code.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.Code.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.Code.Location = New System.Drawing.Point(0, 52)
        Me.Code.Name = "Code"
        Me.Code.Paddings = New System.Windows.Forms.Padding(0)
        Me.Code.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.Code.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.Code.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Code.Size = New System.Drawing.Size(575, 332)
        Me.Code.TabIndex = 0
        Me.Code.Zoom = 100
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 493)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(793, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(26, 17)
        Me.Status.Text = "Idle"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "PAWN File | *.pwn"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "PAWN File | *.pwn"
        '
        'IdleMaker
        '
        Me.IdleMaker.Interval = 10000
        '
        'AutoSaver
        '
        Me.AutoSaver.Interval = 300000
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Location = New System.Drawing.Point(581, 52)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(208, 438)
        Me.TreeView1.TabIndex = 5
        '
        'HelpMenu
        '
        Me.HelpMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.HelpMenu.ImageList = Nothing
        Me.HelpMenu.Items = New String(-1) {}
        Me.HelpMenu.TargetControlWrapper = Nothing
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type, Me.ErrorText, Me.File, Me.LineNum})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 390)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(575, 100)
        Me.DataGridView1.TabIndex = 6
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'ErrorText
        '
        Me.ErrorText.HeaderText = "Error"
        Me.ErrorText.Name = "ErrorText"
        Me.ErrorText.ReadOnly = True
        '
        'File
        '
        Me.File.HeaderText = "File"
        Me.File.Name = "File"
        Me.File.ReadOnly = True
        '
        'LineNum
        '
        Me.LineNum.HeaderText = "Line Number"
        Me.LineNum.Name = "LineNum"
        Me.LineNum.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator2, Me.ToolStripButton7, Me.ToolStripSeparator3, Me.ToolStripButton8, Me.ToolStripButton9, Me.ToolStripSeparator4, Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator5, Me.ToolStripButton13, Me.ToolStripButton14})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(793, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.FormatToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(793, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ExitToolStripMenuItem2})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(113, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem1.Text = "Options"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(113, 6)
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripMenuItem1, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem2, Me.FindToolStripMenuItem, Me.ReplaceToolStripMenuItem, Me.GoToToolStripMenuItem, Me.ToolStripMenuItem3, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(119, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(119, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'ReplaceToolStripMenuItem
        '
        Me.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem"
        Me.ReplaceToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.ReplaceToolStripMenuItem.Text = "Replace"
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.GoToToolStripMenuItem.Text = "GoTo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(119, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'FormatToolStripMenuItem
        '
        Me.FormatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontToolStripMenuItem})
        Me.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem"
        Me.FormatToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.FormatToolStripMenuItem.Text = "Format"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.FontToolStripMenuItem.Text = "Font"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsBarToolStripMenuItem, Me.FunctionListToolStripMenuItem, Me.ErrorListToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ToolsBarToolStripMenuItem
        '
        Me.ToolsBarToolStripMenuItem.Name = "ToolsBarToolStripMenuItem"
        Me.ToolsBarToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ToolsBarToolStripMenuItem.Text = "Toolbar"
        '
        'FunctionListToolStripMenuItem
        '
        Me.FunctionListToolStripMenuItem.Name = "FunctionListToolStripMenuItem"
        Me.FunctionListToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.FunctionListToolStripMenuItem.Text = "Function List"
        '
        'ErrorListToolStripMenuItem
        '
        Me.ErrorListToolStripMenuItem.Name = "ErrorListToolStripMenuItem"
        Me.ErrorListToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ErrorListToolStripMenuItem.Text = "Error List"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeyboardShortcutsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'KeyboardShortcutsToolStripMenuItem
        '
        Me.KeyboardShortcutsToolStripMenuItem.Name = "KeyboardShortcutsToolStripMenuItem"
        Me.KeyboardShortcutsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.KeyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "New"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Open"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Save"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Search"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Replace"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Compile"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = Global.ExtremePawn.My.Resources.Resources.Undo
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Undo"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = Global.ExtremePawn.My.Resources.Resources.Redo
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Redo"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = Global.ExtremePawn.My.Resources.Resources.Copy
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Copy"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = Global.ExtremePawn.My.Resources.Resources.Cut
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Cut"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = Global.ExtremePawn.My.Resources.Resources.Paste
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Paste"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = Global.ExtremePawn.My.Resources.Resources.ColorPicker
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.Text = "Colour Picker"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = Global.ExtremePawn.My.Resources.Resources.Indent
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton14.Text = "Auto Indent (Selected Text)"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 515)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Code)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "ExtremePAWN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Code As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents IdleMaker As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents AutoSaver As System.Windows.Forms.Timer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents HelpMenu As AutocompleteMenuNS.AutocompleteMenu
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Type As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ErrorText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeyboardShortcutsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents FunctionListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton

End Class
