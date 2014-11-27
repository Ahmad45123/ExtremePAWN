Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectExplorerFrm
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Includes")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Scripts")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Main.pwn")
        Me.ProjectExplorer = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'ProjectExplorer
        '
        Me.ProjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjectExplorer.Location = New System.Drawing.Point(0, 0)
        Me.ProjectExplorer.Name = "ProjectExplorer"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Includes"
        TreeNode2.Name = "Node1"
        TreeNode2.Text = "Scripts"
        TreeNode3.Name = "Node2"
        TreeNode3.Text = "Main.pwn"
        Me.ProjectExplorer.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.ProjectExplorer.Size = New System.Drawing.Size(234, 213)
        Me.ProjectExplorer.TabIndex = 14
        '
        'ProjectExplorerFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 213)
        Me.Controls.Add(Me.ProjectExplorer)
        Me.DockAreas = CType((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "ProjectExplorerFrm"
        Me.Text = "Project Explorer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProjectExplorer As System.Windows.Forms.TreeView
End Class
