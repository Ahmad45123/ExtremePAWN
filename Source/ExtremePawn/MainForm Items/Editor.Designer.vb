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
        Me.Scintilla1 = New ScintillaNET.Scintilla()
        CType(Me.Scintilla1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Scintilla1
        '
        Me.Scintilla1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla1.Location = New System.Drawing.Point(0, 0)
        Me.Scintilla1.Name = "Scintilla1"
        Me.Scintilla1.Size = New System.Drawing.Size(690, 466)
        Me.Scintilla1.Styles.BraceBad.FontName = "Verdan"
        Me.Scintilla1.Styles.BraceLight.FontName = "Verdan"
        Me.Scintilla1.Styles.CallTip.FontName = "Segoe "
        Me.Scintilla1.Styles.ControlChar.FontName = "Verdan"
        Me.Scintilla1.Styles.Default.BackColor = System.Drawing.SystemColors.Window
        Me.Scintilla1.Styles.Default.FontName = "Verdan"
        Me.Scintilla1.Styles.IndentGuide.FontName = "Verdan"
        Me.Scintilla1.Styles.LastPredefined.FontName = "Verdan"
        Me.Scintilla1.Styles.LineNumber.FontName = "Verdan"
        Me.Scintilla1.Styles.Max.FontName = "Verdan"
        Me.Scintilla1.TabIndex = 0
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 466)
        Me.Controls.Add(Me.Scintilla1)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "Editor"
        Me.Text = "Editor"
        CType(Me.Scintilla1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Scintilla1 As ScintillaNET.Scintilla
End Class
