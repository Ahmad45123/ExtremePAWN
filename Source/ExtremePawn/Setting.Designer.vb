<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setting))
        Me.AgrumentsTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PawnccPath = New System.Windows.Forms.TextBox()
        Me.AutoBracket = New System.Windows.Forms.CheckBox()
        Me.LineNumber = New System.Windows.Forms.CheckBox()
        Me.AutoCompletion = New System.Windows.Forms.CheckBox()
        Me.AutoSaving = New System.Windows.Forms.CheckBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AgrumentsTxt
        '
        Me.AgrumentsTxt.Location = New System.Drawing.Point(125, 12)
        Me.AgrumentsTxt.Name = "AgrumentsTxt"
        Me.AgrumentsTxt.Size = New System.Drawing.Size(100, 20)
        Me.AgrumentsTxt.TabIndex = 2
        Me.AgrumentsTxt.Tag = """[FILE]"" For The Path Of The PWN File."
        Me.AgrumentsTxt.Text = "-; -( [FILE]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Compiler :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Arguments :"
        '
        'PawnccPath
        '
        Me.PawnccPath.Location = New System.Drawing.Point(118, 35)
        Me.PawnccPath.Name = "PawnccPath"
        Me.PawnccPath.Size = New System.Drawing.Size(108, 20)
        Me.PawnccPath.TabIndex = 5
        Me.PawnccPath.Tag = """[APP]"" For The Pass Of ExtremePAWN"
        Me.PawnccPath.Text = "[APP]\pawncc.exe"
        '
        'AutoBracket
        '
        Me.AutoBracket.AutoSize = True
        Me.AutoBracket.Location = New System.Drawing.Point(12, 139)
        Me.AutoBracket.Name = "AutoBracket"
        Me.AutoBracket.Size = New System.Drawing.Size(141, 17)
        Me.AutoBracket.TabIndex = 14
        Me.AutoBracket.Text = "Auto Complete Brackets"
        Me.AutoBracket.UseVisualStyleBackColor = True
        '
        'LineNumber
        '
        Me.LineNumber.AutoSize = True
        Me.LineNumber.Checked = True
        Me.LineNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LineNumber.Location = New System.Drawing.Point(12, 94)
        Me.LineNumber.Name = "LineNumber"
        Me.LineNumber.Size = New System.Drawing.Size(114, 17)
        Me.LineNumber.TabIndex = 13
        Me.LineNumber.Text = "Show Line Number"
        Me.LineNumber.UseVisualStyleBackColor = True
        '
        'AutoCompletion
        '
        Me.AutoCompletion.AutoSize = True
        Me.AutoCompletion.Checked = True
        Me.AutoCompletion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoCompletion.Location = New System.Drawing.Point(12, 116)
        Me.AutoCompletion.Name = "AutoCompletion"
        Me.AutoCompletion.Size = New System.Drawing.Size(175, 17)
        Me.AutoCompletion.TabIndex = 12
        Me.AutoCompletion.Text = "Enable Synced AutoCompletion"
        Me.AutoCompletion.UseVisualStyleBackColor = True
        '
        'AutoSaving
        '
        Me.AutoSaving.AutoSize = True
        Me.AutoSaving.Location = New System.Drawing.Point(12, 72)
        Me.AutoSaving.Name = "AutoSaving"
        Me.AutoSaving.Size = New System.Drawing.Size(119, 17)
        Me.AutoSaving.TabIndex = 11
        Me.AutoSaving.Tag = "Auto Saves Every 5 Minutes"
        Me.AutoSaving.Text = "Enable Auto Saving"
        Me.AutoSaving.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.Location = New System.Drawing.Point(216, 127)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(74, 61)
        Me.Button9.TabIndex = 15
        Me.Button9.Text = "Save Settings"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Compile Key :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "F5"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(117, 165)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Edit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 195)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.AutoBracket)
        Me.Controls.Add(Me.LineNumber)
        Me.Controls.Add(Me.AutoCompletion)
        Me.Controls.Add(Me.AutoSaving)
        Me.Controls.Add(Me.PawnccPath)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AgrumentsTxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setting"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AgrumentsTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PawnccPath As System.Windows.Forms.TextBox
    Friend WithEvents AutoBracket As System.Windows.Forms.CheckBox
    Friend WithEvents LineNumber As System.Windows.Forms.CheckBox
    Friend WithEvents AutoCompletion As System.Windows.Forms.CheckBox
    Friend WithEvents AutoSaving As System.Windows.Forms.CheckBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
