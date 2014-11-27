<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Me.SplitEditorCode = New FastColoredTextBoxNS.FastColoredTextBox()
        CType(Me.SplitEditorCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitEditorCode
        '
        Me.SplitEditorCode.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.SplitEditorCode.AutoScrollMinSize = New System.Drawing.Size(27, 15)
        Me.SplitEditorCode.BackBrush = Nothing
        Me.SplitEditorCode.BookmarkColor = System.Drawing.Color.Red
        Me.SplitEditorCode.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2
        Me.SplitEditorCode.CharHeight = 15
        Me.SplitEditorCode.CharWidth = 8
        Me.SplitEditorCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SplitEditorCode.DelayedTextChangedInterval = 1000
        Me.SplitEditorCode.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.SplitEditorCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitEditorCode.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2
        Me.SplitEditorCode.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.SplitEditorCode.IsReplaceMode = False
        Me.SplitEditorCode.LeftBracket = Global.Microsoft.VisualBasic.ChrW(40)
        Me.SplitEditorCode.LeftBracket2 = Global.Microsoft.VisualBasic.ChrW(123)
        Me.SplitEditorCode.Location = New System.Drawing.Point(0, 0)
        Me.SplitEditorCode.Name = "SplitEditorCode"
        Me.SplitEditorCode.Paddings = New System.Windows.Forms.Padding(0)
        Me.SplitEditorCode.RightBracket = Global.Microsoft.VisualBasic.ChrW(41)
        Me.SplitEditorCode.RightBracket2 = Global.Microsoft.VisualBasic.ChrW(125)
        Me.SplitEditorCode.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitEditorCode.Size = New System.Drawing.Size(690, 466)
        Me.SplitEditorCode.TabIndex = 1
        Me.SplitEditorCode.Zoom = 100
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 466)
        Me.Controls.Add(Me.SplitEditorCode)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "Editor"
        Me.Text = "Editor"
        CType(Me.SplitEditorCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitEditorCode As FastColoredTextBoxNS.FastColoredTextBox
End Class
