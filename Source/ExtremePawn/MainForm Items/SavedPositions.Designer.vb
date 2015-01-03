Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SavedPositions
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
        Me.ItemsListBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ItemsListBox
        '
        Me.ItemsListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsListBox.FormattingEnabled = True
        Me.ItemsListBox.Location = New System.Drawing.Point(0, 0)
        Me.ItemsListBox.Name = "ItemsListBox"
        Me.ItemsListBox.Size = New System.Drawing.Size(289, 289)
        Me.ItemsListBox.TabIndex = 0
        '
        'SavedPositions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 289)
        Me.Controls.Add(Me.ItemsListBox)
        Me.DockAreas = CType((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
                    Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "SavedPositions"
        Me.Text = "Saved Positions"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItemsListBox As System.Windows.Forms.ListBox
End Class
