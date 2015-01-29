<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Object_Explorer
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
        Me.TreeList = New System.Windows.Forms.TreeView()
        Me.RightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RebuildMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReBuildWorker = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RightClick.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeList
        '
        Me.TreeList.ContextMenuStrip = Me.RightClick
        Me.TreeList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TreeList.Location = New System.Drawing.Point(0, 0)
        Me.TreeList.Name = "TreeList"
        Me.TreeList.Size = New System.Drawing.Size(270, 420)
        Me.TreeList.TabIndex = 0
        '
        'RightClick
        '
        Me.RightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RebuildMenuToolStripMenuItem, Me.ToolStripMenuItem2, Me.EditMenuToolStripMenuItem})
        Me.RightClick.Name = "RightClick"
        Me.RightClick.Size = New System.Drawing.Size(197, 54)
        '
        'RebuildMenuToolStripMenuItem
        '
        Me.RebuildMenuToolStripMenuItem.Name = "RebuildMenuToolStripMenuItem"
        Me.RebuildMenuToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.RebuildMenuToolStripMenuItem.Text = "Rebuild Menu"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(193, 6)
        '
        'EditMenuToolStripMenuItem
        '
        Me.EditMenuToolStripMenuItem.Name = "EditMenuToolStripMenuItem"
        Me.EditMenuToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.EditMenuToolStripMenuItem.Text = "ObjectExplorer Settings"
        '
        'ReBuildWorker
        '
        '
        'Object_Explorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 420)
        Me.Controls.Add(Me.TreeList)
        Me.DockAreas = CType((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Object_Explorer"
        Me.Text = "Object Explorer"
        Me.RightClick.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeList As System.Windows.Forms.TreeView
    Friend WithEvents RightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RebuildMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReBuildWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
