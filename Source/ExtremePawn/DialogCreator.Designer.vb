<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogCreator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogCreator))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MDialogText = New System.Windows.Forms.TextBox()
        Me.MPlayerText = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MGenerateButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MButton2Text = New System.Windows.Forms.TextBox()
        Me.MButton1Text = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MContentText = New System.Windows.Forms.TextBox()
        Me.MTitleTxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.IDialogText = New System.Windows.Forms.TextBox()
        Me.IPlayerText = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.IGenerate = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.IButton2Text = New System.Windows.Forms.TextBox()
        Me.IButton1Text = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.IContentText = New System.Windows.Forms.TextBox()
        Me.ITitleText = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LTitleText = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LButton2Text = New System.Windows.Forms.TextBox()
        Me.LButton1Text = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LContentsList = New System.Windows.Forms.ListBox()
        Me.LDialogText = New System.Windows.Forms.TextBox()
        Me.LPlayerText = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(418, 338)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.MDialogText)
        Me.TabPage1.Controls.Add(Me.MPlayerText)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.MGenerateButton)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.MButton2Text)
        Me.TabPage1.Controls.Add(Me.MButton1Text)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.MContentText)
        Me.TabPage1.Controls.Add(Me.MTitleTxt)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(410, 312)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Message Box"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Dialog ID :"
        '
        'MDialogText
        '
        Me.MDialogText.Location = New System.Drawing.Point(69, 197)
        Me.MDialogText.Name = "MDialogText"
        Me.MDialogText.Size = New System.Drawing.Size(333, 20)
        Me.MDialogText.TabIndex = 12
        '
        'MPlayerText
        '
        Me.MPlayerText.Location = New System.Drawing.Point(69, 171)
        Me.MPlayerText.Name = "MPlayerText"
        Me.MPlayerText.Size = New System.Drawing.Size(333, 20)
        Me.MPlayerText.TabIndex = 11
        Me.MPlayerText.Text = "playerid"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Player ID :"
        '
        'MGenerateButton
        '
        Me.MGenerateButton.Location = New System.Drawing.Point(69, 223)
        Me.MGenerateButton.Name = "MGenerateButton"
        Me.MGenerateButton.Size = New System.Drawing.Size(333, 81)
        Me.MGenerateButton.TabIndex = 9
        Me.MGenerateButton.Text = "Generate And Insert"
        Me.MGenerateButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Button 2 :"
        '
        'MButton2Text
        '
        Me.MButton2Text.Location = New System.Drawing.Point(69, 145)
        Me.MButton2Text.Name = "MButton2Text"
        Me.MButton2Text.Size = New System.Drawing.Size(333, 20)
        Me.MButton2Text.TabIndex = 7
        '
        'MButton1Text
        '
        Me.MButton1Text.Location = New System.Drawing.Point(69, 119)
        Me.MButton1Text.Name = "MButton1Text"
        Me.MButton1Text.Size = New System.Drawing.Size(333, 20)
        Me.MButton1Text.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Button 1 :"
        '
        'MContentText
        '
        Me.MContentText.Location = New System.Drawing.Point(70, 37)
        Me.MContentText.Multiline = True
        Me.MContentText.Name = "MContentText"
        Me.MContentText.Size = New System.Drawing.Size(332, 76)
        Me.MContentText.TabIndex = 3
        '
        'MTitleTxt
        '
        Me.MTitleTxt.Location = New System.Drawing.Point(51, 11)
        Me.MTitleTxt.Name = "MTitleTxt"
        Me.MTitleTxt.Size = New System.Drawing.Size(351, 20)
        Me.MTitleTxt.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Content : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Title : "
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.IDialogText)
        Me.TabPage2.Controls.Add(Me.IPlayerText)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.IGenerate)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.IButton2Text)
        Me.TabPage2.Controls.Add(Me.IButton1Text)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.IContentText)
        Me.TabPage2.Controls.Add(Me.ITitleText)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(410, 312)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Input Box"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(70, 219)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(92, 17)
        Me.CheckBox1.TabIndex = 27
        Me.CheckBox1.Text = "Is Password ?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Dialog ID :"
        '
        'IDialogText
        '
        Me.IDialogText.Location = New System.Drawing.Point(69, 193)
        Me.IDialogText.Name = "IDialogText"
        Me.IDialogText.Size = New System.Drawing.Size(333, 20)
        Me.IDialogText.TabIndex = 25
        '
        'IPlayerText
        '
        Me.IPlayerText.Location = New System.Drawing.Point(69, 167)
        Me.IPlayerText.Name = "IPlayerText"
        Me.IPlayerText.Size = New System.Drawing.Size(333, 20)
        Me.IPlayerText.TabIndex = 24
        Me.IPlayerText.Text = "playerid"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Player ID :"
        '
        'IGenerate
        '
        Me.IGenerate.Location = New System.Drawing.Point(69, 242)
        Me.IGenerate.Name = "IGenerate"
        Me.IGenerate.Size = New System.Drawing.Size(333, 58)
        Me.IGenerate.TabIndex = 22
        Me.IGenerate.Text = "Generate And Insert"
        Me.IGenerate.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Button 2 :"
        '
        'IButton2Text
        '
        Me.IButton2Text.Location = New System.Drawing.Point(69, 141)
        Me.IButton2Text.Name = "IButton2Text"
        Me.IButton2Text.Size = New System.Drawing.Size(333, 20)
        Me.IButton2Text.TabIndex = 20
        '
        'IButton1Text
        '
        Me.IButton1Text.Location = New System.Drawing.Point(69, 115)
        Me.IButton1Text.Name = "IButton1Text"
        Me.IButton1Text.Size = New System.Drawing.Size(333, 20)
        Me.IButton1Text.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Button 1 :"
        '
        'IContentText
        '
        Me.IContentText.Location = New System.Drawing.Point(70, 33)
        Me.IContentText.Multiline = True
        Me.IContentText.Name = "IContentText"
        Me.IContentText.Size = New System.Drawing.Size(332, 76)
        Me.IContentText.TabIndex = 17
        '
        'ITitleText
        '
        Me.ITitleText.Location = New System.Drawing.Point(51, 7)
        Me.ITitleText.Name = "ITitleText"
        Me.ITitleText.Size = New System.Drawing.Size(351, 20)
        Me.ITitleText.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Content : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Title : "
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.LTitleText)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.LButton2Text)
        Me.TabPage3.Controls.Add(Me.LButton1Text)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.LDialogText)
        Me.TabPage3.Controls.Add(Me.LPlayerText)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(410, 312)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "List Box"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Title : "
        '
        'LTitleText
        '
        Me.LTitleText.Location = New System.Drawing.Point(54, 58)
        Me.LTitleText.Name = "LTitleText"
        Me.LTitleText.Size = New System.Drawing.Size(348, 20)
        Me.LTitleText.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(264, 249)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 55)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Generate And Insert"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(264, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Button 2 :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(264, 84)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Button 1 :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Dialog ID :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Player ID :"
        '
        'LButton2Text
        '
        Me.LButton2Text.Location = New System.Drawing.Point(264, 154)
        Me.LButton2Text.Name = "LButton2Text"
        Me.LButton2Text.Size = New System.Drawing.Size(138, 20)
        Me.LButton2Text.TabIndex = 4
        '
        'LButton1Text
        '
        Me.LButton1Text.Location = New System.Drawing.Point(264, 100)
        Me.LButton1Text.Name = "LButton1Text"
        Me.LButton1Text.Size = New System.Drawing.Size(138, 20)
        Me.LButton1Text.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.LContentsList)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 227)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Content"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(132, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(107, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Edit Selected"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(132, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(107, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Delete Selected"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(132, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Add New"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LContentsList
        '
        Me.LContentsList.FormattingEnabled = True
        Me.LContentsList.Location = New System.Drawing.Point(6, 19)
        Me.LContentsList.Name = "LContentsList"
        Me.LContentsList.ScrollAlwaysVisible = True
        Me.LContentsList.Size = New System.Drawing.Size(120, 199)
        Me.LContentsList.TabIndex = 0
        '
        'LDialogText
        '
        Me.LDialogText.Location = New System.Drawing.Point(70, 32)
        Me.LDialogText.Name = "LDialogText"
        Me.LDialogText.Size = New System.Drawing.Size(332, 20)
        Me.LDialogText.TabIndex = 1
        '
        'LPlayerText
        '
        Me.LPlayerText.Location = New System.Drawing.Point(70, 6)
        Me.LPlayerText.Name = "LPlayerText"
        Me.LPlayerText.Size = New System.Drawing.Size(332, 20)
        Me.LPlayerText.TabIndex = 0
        Me.LPlayerText.Text = "playerid"
        '
        'DialogCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 338)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DialogCreator"
        Me.Text = "Dialog Creator"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents MContentText As System.Windows.Forms.TextBox
    Friend WithEvents MTitleTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MButton2Text As System.Windows.Forms.TextBox
    Friend WithEvents MButton1Text As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MGenerateButton As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MDialogText As System.Windows.Forms.TextBox
    Friend WithEvents MPlayerText As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents IDialogText As System.Windows.Forms.TextBox
    Friend WithEvents IPlayerText As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents IGenerate As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents IButton2Text As System.Windows.Forms.TextBox
    Friend WithEvents IButton1Text As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents IContentText As System.Windows.Forms.TextBox
    Friend WithEvents ITitleText As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents LButton2Text As System.Windows.Forms.TextBox
    Friend WithEvents LButton1Text As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LDialogText As System.Windows.Forms.TextBox
    Friend WithEvents LPlayerText As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LContentsList As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LTitleText As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
