Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncludeListFrm
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
        Me.IncludeTreeView = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'IncludeTreeView
        '
        Me.IncludeTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IncludeTreeView.Location = New System.Drawing.Point(0, 0)
        Me.IncludeTreeView.Name = "IncludeTreeView"
        Me.IncludeTreeView.Size = New System.Drawing.Size(284, 261)
        Me.IncludeTreeView.TabIndex = 6
        '
        'IncludeListFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.IncludeTreeView)
        Me.DockAreas = CType((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "IncludeListFrm"
        Me.Text = "Include List"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IncludeTreeView As System.Windows.Forms.TreeView
End Class
