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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Editor))
        Me.SplitEditorCode = New ScintillaNET.Scintilla()
        Me.AutoCompleteImage = New System.Windows.Forms.ImageList(Me.components)
        Me.AutoComplete = New AutocompleteMenuNS.AutocompleteMenu()
        CType(Me.SplitEditorCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitEditorCode
        '
        Me.SplitEditorCode.Caret.CurrentLineBackgroundColor = System.Drawing.Color.Gainsboro
        Me.SplitEditorCode.Caret.HighlightCurrentLine = True
        Me.SplitEditorCode.ConfigurationManager.Language = "cpp"
        Me.SplitEditorCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitEditorCode.Folding.UseCompactFolding = True
        Me.SplitEditorCode.Indentation.ShowGuides = True
        Me.SplitEditorCode.Indentation.SmartIndentType = ScintillaNET.SmartIndent.CPP2
        Me.SplitEditorCode.Indentation.TabWidth = 4
        Me.SplitEditorCode.IsBraceMatching = True
        Me.SplitEditorCode.Lexing.Lexer = ScintillaNET.Lexer.Cpp
        Me.SplitEditorCode.Lexing.LexerName = "cpp"
        Me.SplitEditorCode.Lexing.LineCommentPrefix = "//"
        Me.SplitEditorCode.Lexing.StreamCommentPrefix = "/*"
        Me.SplitEditorCode.Lexing.StreamCommentSufix = "*/"
        Me.SplitEditorCode.Location = New System.Drawing.Point(0, 0)
        Me.SplitEditorCode.Margins.Margin2.Width = 12
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
        'AutoCompleteImage
        '
        Me.AutoCompleteImage.ImageStream = CType(resources.GetObject("AutoCompleteImage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.AutoCompleteImage.TransparentColor = System.Drawing.Color.Transparent
        Me.AutoCompleteImage.Images.SetKeyName(0, "DefineIcon.ico")
        Me.AutoCompleteImage.Images.SetKeyName(1, "ObjectIcon.ico")
        '
        'AutoComplete
        '
        Me.AutoComplete.AppearInterval = 150
        Me.AutoComplete.Colors = CType(resources.GetObject("AutoComplete.Colors"), AutocompleteMenuNS.Colors)
        Me.AutoComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.AutoComplete.ImageList = Me.AutoCompleteImage
        Me.AutoComplete.Items = New String(-1) {}
        Me.AutoComplete.TargetControlWrapper = Nothing
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 466)
        Me.Controls.Add(Me.SplitEditorCode)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Editor"
        Me.Text = "Editor"
        CType(Me.SplitEditorCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitEditorCode As ScintillaNET.Scintilla
    Friend WithEvents AutoComplete As AutocompleteMenuNS.AutocompleteMenu
    Friend WithEvents AutoCompleteImage As System.Windows.Forms.ImageList
End Class
