<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LineNumber = New System.Windows.Forms.CheckBox()
        Me.AutoCompletion = New System.Windows.Forms.CheckBox()
        Me.AutoSaving = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.PawnccPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AgrumentsTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SAMPClient = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SAMPServerDir = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.CompileLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(332, 162)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LineNumber)
        Me.TabPage1.Controls.Add(Me.AutoCompletion)
        Me.TabPage1.Controls.Add(Me.AutoSaving)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(324, 136)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LineNumber
        '
        Me.LineNumber.AutoSize = True
        Me.LineNumber.Checked = True
        Me.LineNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LineNumber.Location = New System.Drawing.Point(8, 28)
        Me.LineNumber.Name = "LineNumber"
        Me.LineNumber.Size = New System.Drawing.Size(114, 17)
        Me.LineNumber.TabIndex = 17
        Me.LineNumber.Text = "Show Line Number"
        Me.LineNumber.UseVisualStyleBackColor = True
        '
        'AutoCompletion
        '
        Me.AutoCompletion.AutoSize = True
        Me.AutoCompletion.Checked = True
        Me.AutoCompletion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoCompletion.Location = New System.Drawing.Point(8, 50)
        Me.AutoCompletion.Name = "AutoCompletion"
        Me.AutoCompletion.Size = New System.Drawing.Size(175, 17)
        Me.AutoCompletion.TabIndex = 16
        Me.AutoCompletion.Text = "Enable Synced AutoCompletion"
        Me.AutoCompletion.UseVisualStyleBackColor = True
        '
        'AutoSaving
        '
        Me.AutoSaving.AutoSize = True
        Me.AutoSaving.Location = New System.Drawing.Point(8, 6)
        Me.AutoSaving.Name = "AutoSaving"
        Me.AutoSaving.Size = New System.Drawing.Size(119, 17)
        Me.AutoSaving.TabIndex = 15
        Me.AutoSaving.Tag = "Auto Saves Every 5 Minutes"
        Me.AutoSaving.Text = "Enable Auto Saving"
        Me.AutoSaving.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(246, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button8)
        Me.TabPage2.Controls.Add(Me.PawnccPath)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.AgrumentsTxt)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.SAMPClient)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.SAMPServerDir)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(324, 136)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Compiler Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(254, 82)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(35, 23)
        Me.Button8.TabIndex = 37
        Me.Button8.Text = "..."
        Me.Button8.UseVisualStyleBackColor = True
        '
        'PawnccPath
        '
        Me.PawnccPath.Location = New System.Drawing.Point(93, 84)
        Me.PawnccPath.Name = "PawnccPath"
        Me.PawnccPath.Size = New System.Drawing.Size(155, 20)
        Me.PawnccPath.TabIndex = 36
        Me.PawnccPath.Text = "[APP]\pawncc.exe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "PawnCC path : "
        '
        'AgrumentsTxt
        '
        Me.AgrumentsTxt.Location = New System.Drawing.Point(124, 58)
        Me.AgrumentsTxt.Name = "AgrumentsTxt"
        Me.AgrumentsTxt.Size = New System.Drawing.Size(124, 20)
        Me.AgrumentsTxt.TabIndex = 33
        Me.AgrumentsTxt.Text = "-; -( [FILE]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Compiler Agruments : "
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(254, 30)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(35, 23)
        Me.Button4.TabIndex = 31
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'SAMPClient
        '
        Me.SAMPClient.Location = New System.Drawing.Point(74, 32)
        Me.SAMPClient.Name = "SAMPClient"
        Me.SAMPClient.Size = New System.Drawing.Size(174, 20)
        Me.SAMPClient.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "SAMP Client :"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(254, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(35, 23)
        Me.Button5.TabIndex = 28
        Me.Button5.Text = "..."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'SAMPServerDir
        '
        Me.SAMPServerDir.Location = New System.Drawing.Point(103, 6)
        Me.SAMPServerDir.Name = "SAMPServerDir"
        Me.SAMPServerDir.Size = New System.Drawing.Size(145, 20)
        Me.SAMPServerDir.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "SAMP Server Dir :"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(246, 110)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button6)
        Me.TabPage3.Controls.Add(Me.CompileLabel)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(324, 136)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Hotkeys"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(113, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 23)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Edit"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'CompileLabel
        '
        Me.CompileLabel.AutoSize = True
        Me.CompileLabel.Location = New System.Drawing.Point(80, 9)
        Me.CompileLabel.Name = "CompileLabel"
        Me.CompileLabel.Size = New System.Drawing.Size(19, 13)
        Me.CompileLabel.TabIndex = 20
        Me.CompileLabel.Text = "F5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Compile Key :"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(246, 110)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "&Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "EXE File | *.exe"
        Me.OpenFileDialog1.Title = "Choose samp.exe"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "SAMP Server Folder."
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 162)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LineNumber As System.Windows.Forms.CheckBox
    Friend WithEvents AutoCompletion As System.Windows.Forms.CheckBox
    Friend WithEvents AutoSaving As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents SAMPClient As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents SAMPServerDir As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents CompileLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents PawnccPath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AgrumentsTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
