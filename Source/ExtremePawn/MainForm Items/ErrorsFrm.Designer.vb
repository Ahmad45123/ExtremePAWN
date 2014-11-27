Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorsFrm
    Inherits DockContent

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
        Me.ErrorDataGridView = New System.Windows.Forms.DataGridView()
        Me.Type = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ErrorText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrorDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorDataGridView
        '
        Me.ErrorDataGridView.AllowUserToAddRows = False
        Me.ErrorDataGridView.AllowUserToDeleteRows = False
        Me.ErrorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ErrorDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type, Me.ErrorText, Me.File, Me.LineNum})
        Me.ErrorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErrorDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ErrorDataGridView.Name = "ErrorDataGridView"
        Me.ErrorDataGridView.ReadOnly = True
        Me.ErrorDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ErrorDataGridView.Size = New System.Drawing.Size(682, 108)
        Me.ErrorDataGridView.TabIndex = 7
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
        'ErrorsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 108)
        Me.Controls.Add(Me.ErrorDataGridView)
        Me.DockAreas = CType((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "ErrorsFrm"
        Me.Text = "Compile Errors"
        CType(Me.ErrorDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Type As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ErrorText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNum As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
