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
        Me.SplitEditorCode = New ScintillaNET.Scintilla()
        CType(Me.SplitEditorCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitEditorCode
        '
        Me.SplitEditorCode.AutoComplete.IsCaseSensitive = False
        Me.SplitEditorCode.AutoComplete.ListString = ""
        Me.SplitEditorCode.ConfigurationManager.Language = "cs"
        Me.SplitEditorCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitEditorCode.Lexing.Lexer = ScintillaNET.Lexer.Null
        Me.SplitEditorCode.Lexing.LexerName = "automatic"
        Me.SplitEditorCode.Lexing.LineCommentPrefix = "//"
        Me.SplitEditorCode.Lexing.StreamCommentPrefix = ""
        Me.SplitEditorCode.Lexing.StreamCommentSufix = ""
        Me.SplitEditorCode.Location = New System.Drawing.Point(0, 0)
        Me.SplitEditorCode.Name = "SplitEditorCode"
        Me.SplitEditorCode.Size = New System.Drawing.Size(690, 466)
        Me.SplitEditorCode.Styles.BraceBad.FontName = "Verdan"
        Me.SplitEditorCode.Styles.BraceLight.FontName = "Verdan"
        Me.SplitEditorCode.Styles.CallTip.FontName = "Segoe "
        Me.SplitEditorCode.Styles.ControlChar.FontName = "Verdan"
        Me.SplitEditorCode.Styles.Default.BackColor = System.Drawing.SystemColors.Window
        Me.SplitEditorCode.Styles.Default.FontName = "Verdan"
        Me.SplitEditorCode.Styles.IndentGuide.FontName = "Verdan"
        Me.SplitEditorCode.Styles.LastPredefined.FontName = "Verdan"
        Me.SplitEditorCode.Styles.LineNumber.FontName = "Verdan"
        Me.SplitEditorCode.Styles.Max.FontName = "Verdan"
        Me.SplitEditorCode.TabIndex = 0
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
    Friend WithEvents SplitEditorCode As ScintillaNET.Scintilla
End Class
