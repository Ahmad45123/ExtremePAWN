'Developed by Amen Ayach
Public Class ClsCapture

#Region "Global Vars"

    Dim WithEvents dad As Form
    Dim WithEvents dd As Control
    Dim WithEvents Btn_exit As New Button
    Dim WithEvents Btn_Min As New Button
    Dim bCaptureMe As Boolean
    Dim pLocation As New Point

#End Region

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles dad.MouseDown, dd.MouseDown
        Try
            bCaptureMe = True
            pLocation = e.Location
            sender.BringToFront()
        Catch
        End Try
    End Sub

    Public Sub EditSize(ByVal Type As String, ByVal Value As Integer, ByVal Opr As String, ByVal Obj As Control)
        Dim ObjectSize As New Size
        ObjectSize = Obj.Size
        If Type = "width" Then
            If Opr = "+" Then
                ObjectSize.Width = ObjectSize.Width + Value
            ElseIf Opr = "-" Then
                ObjectSize.Width = ObjectSize.Width - Value
            End If
        ElseIf Type = "height" Then
            If Opr = "+" Then
                ObjectSize.Height = ObjectSize.Height + Value
            ElseIf Opr = "-" Then
                ObjectSize.Height = ObjectSize.Height - Value
            End If
        End If

        Obj.Size = ObjectSize
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles dad.MouseMove, dd.MouseMove
        Try
            If bCaptureMe Then
                If dd Is Nothing AndAlso dad.Cursor <> Cursors.SizeNESW _
                AndAlso dad.Cursor <> Cursors.SizeNWSE _
                AndAlso dad.Cursor <> Cursors.SizeNS _
                AndAlso dad.Cursor <> Cursors.SizeWE Then
                    dad.Location = New Point(dad.Location.X, dad.Location.Y - pLocation.Y + e.Y)

                ElseIf dd.Cursor <> Cursors.SizeNESW _
                AndAlso dd.Cursor <> Cursors.SizeNWSE _
                AndAlso dd.Cursor <> Cursors.SizeNS _
                AndAlso dd.Cursor <> Cursors.SizeWE Then
                    dd.Location = New Point(dd.Location.X, dd.Location.Y - pLocation.Y + e.Y)
                    EditSize("height", pLocation.Y - e.Y, "-", MainForm.TabStrip)
                    MainForm.SplitEditorCode.Top = dd.Location.Y - pLocation.Y + e.Y + 9

                    Dim Y As Integer = MainForm.SplitEditorCode.Location.Y
                    Y += MainForm.SplitEditorCode.Size.Height
                    Dim AY As Integer = MainForm.ObjectExplorer.Location.Y
                    AY += MainForm.ObjectExplorer.Size.Height

                    If Y > AY Then
                        Dim Dif As Integer = Y - AY
                        EditSize("height", Dif, "-", MainForm.SplitEditorCode)
                    Else
                        Dim Dif As Integer = AY - Y
                        EditSize("height", Dif, "+", MainForm.SplitEditorCode)
                    End If

                    End If

            End If
        Catch
        End Try
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles dad.MouseUp, dd.MouseUp
        Try
            bCaptureMe = False
        Catch
        End Try
    End Sub

    Public Sub New(ByVal Frm As Form, ByVal MakeRound As Boolean)
        dad = Frm
        If MakeRound Then
            RoundShape()
            AddHandler Btn_exit.Click, AddressOf Close_Click
            AddHandler Btn_Min.Click, AddressOf Min_Click
        End If
        AddHandler dad.MouseDown, AddressOf Form1_MouseDown
        AddHandler dad.MouseUp, AddressOf Form1_MouseUp
        AddHandler dad.MouseMove, AddressOf Form1_MouseMove
    End Sub

    Public Sub New(ByVal pnl As Control)
        dd = pnl
        AddHandler dd.MouseDown, AddressOf Form1_MouseDown
        AddHandler dd.MouseUp, AddressOf Form1_MouseUp
        AddHandler dd.MouseMove, AddressOf Form1_MouseMove
    End Sub

    Public Sub RoundShape()
        Try
            dad.FormBorderStyle = FormBorderStyle.None
            Dim gr = New System.Drawing.Drawing2D.GraphicsPath()
            gr.AddPie(0, 0, 40, 40, 180, 90)
            gr.AddPie(dad.Width - 40, 0, 40, 40, 270, 90)
            gr.AddPie(0, dad.Height - 40, 40, 40, 90, 90)
            gr.AddPie(dad.Width - 40, dad.Height - 40, 40, 40, 0, 90)

            gr.AddRectangle(New Drawing.Rectangle(20, 0, dad.Width - 40, dad.Height))
            gr.AddRectangle(New Drawing.Rectangle(0, 20, 20, dad.Height - 40))
            gr.AddRectangle(New Drawing.Rectangle(dad.Width - 20, 20, 20, dad.Height - 40))

            dad.Region = New Region(gr)


            Btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
            Btn_exit.FlatAppearance.BorderSize = 0
            Btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Btn_exit.Location = New System.Drawing.Point(dad.Width - 18, 0)
            Btn_exit.Name = "BtnClose"
            Btn_exit.Size = New System.Drawing.Size(18, 21)
            Btn_exit.TabIndex = 6
            Btn_exit.Text = "X"
            Btn_exit.UseVisualStyleBackColor = True
            Btn_exit.BringToFront()

            Btn_Min.Cursor = System.Windows.Forms.Cursors.Hand
            Btn_Min.FlatAppearance.BorderSize = 0
            Btn_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            Btn_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Btn_Min.Location = New System.Drawing.Point(dad.Width - 36, 0)
            Btn_Min.Name = "BtnClose"
            Btn_Min.Size = New System.Drawing.Size(18, 21)
            Btn_Min.TabIndex = 6
            Btn_Min.Text = "_"
            Btn_Min.UseVisualStyleBackColor = True
            Btn_Min.BringToFront()

            dad.Controls.Add(Btn_exit)
            dad.Controls.Add(Btn_Min)
        Catch
        End Try
    End Sub

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(sender, Button).FindForm.Close()
    End Sub

    Private Sub Min_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(sender, Button).FindForm.WindowState = FormWindowState.Minimized
    End Sub

    Public Shared Sub CaptureAllCtrls(ByVal fr As Control)
        For Each cnt As Control In fr.Controls
            If TypeOf cnt Is Panel Then
                CaptureAllCtrls(cnt)
            Else
                ClsCapture.CaptureMe(cnt)
            End If
        Next
    End Sub

    Public Shared Sub CaptureMe(ByVal frm As Form, Optional ByVal MakeMeRound As Boolean = False)
        Dim cc As New ClsCapture(frm, MakeMeRound)
    End Sub

    Public Shared Sub CaptureMe(ByVal pnl As Control)
        Dim cc As New ClsCapture(pnl)
    End Sub

End Class
