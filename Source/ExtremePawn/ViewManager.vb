Module ViewManager
    Private Sub EditSize(ByVal Type As String, ByVal Value As Integer, ByVal Opr As String, ByVal Obj As Control)
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

    Public Sub TogObjectExplorer()
        If MainForm.ObjectExplorer.Visible = True Then
            MainForm.ObjectExplorer.Visible = False
            EditSize("width", 236, "+", MainForm.TabStrip)
            EditSize("width", 236, "+", MainForm.SplitEditorCode)
            MainForm.TabStrip.Left = MainForm.TabStrip.Left - 236
            MainForm.SplitEditorCode.Left = MainForm.SplitEditorCode.Left - 236
        Else
            MainForm.ObjectExplorer.Visible = True
            EditSize("width", 236, "-", MainForm.TabStrip)
            EditSize("width", 236, "-", MainForm.SplitEditorCode)
            MainForm.TabStrip.Left = MainForm.TabStrip.Left + 236
            MainForm.SplitEditorCode.Left = MainForm.SplitEditorCode.Left + 236
        End If
    End Sub

    Dim IsCodeTogged As Boolean

    Public Sub TogProjectExplorer()
        If MainForm.ProjectExplorer.Visible = True Then
            MainForm.ProjectExplorer.Visible = False
            EditSize("height", 158, "+", MainForm.TabControl1)
            MainForm.TabControl1.Top -= 158


        Else
            MainForm.ProjectExplorer.Visible = True
            EditSize("height", 158, "-", MainForm.TabControl1)
            MainForm.TabControl1.Top += 158
        End If

        If MainForm.ProjectExplorer.Visible = False And MainForm.TabControl1.Visible = False Then
            EditSize("width", 241, "+", MainForm.TabStrip)
            EditSize("width", 241, "+", MainForm.SplitEditorCode)
            EditSize("width", 241, "+", MainForm.ErrorDataGridView)

            IsCodeTogged = True

        ElseIf IsCodeTogged = True Then
            EditSize("width", 241, "-", MainForm.TabStrip)
            EditSize("width", 241, "-", MainForm.SplitEditorCode)
            EditSize("width", 241, "-", MainForm.ErrorDataGridView)
            IsCodeTogged = False
        End If
    End Sub

    Public Sub TogListAndMap()
        If MainForm.TabControl1.Visible = True Then '254
            MainForm.TabControl1.Visible = False
            EditSize("height", 465, "+", MainForm.ProjectExplorer)
        Else
            MainForm.TabControl1.Visible = True
            EditSize("height", 465, "-", MainForm.ProjectExplorer)
        End If

        If MainForm.ProjectExplorer.Visible = False And MainForm.TabControl1.Visible = False Then
            EditSize("width", 241, "+", MainForm.TabStrip)
            EditSize("width", 241, "+", MainForm.SplitEditorCode)
            IsCodeTogged = True

        ElseIf IsCodeTogged = True Then
            EditSize("width", 241, "-", MainForm.TabStrip)
            EditSize("width", 241, "-", MainForm.SplitEditorCode)
            IsCodeTogged = False

        End If
    End Sub

    Public Sub TogErrorList()
        If MainForm.ErrorDataGridView.Visible = True Then '106
            MainForm.ErrorDataGridView.Visible = False
            EditSize("height", 106, "+", MainForm.ObjectExplorer)
            EditSize("height", 106, "+", MainForm.SplitEditorCode)

        Else
            MainForm.ErrorDataGridView.Visible = True
            EditSize("height", 106, "-", MainForm.ObjectExplorer)
            EditSize("height", 106, "-", MainForm.SplitEditorCode)

        End If
    End Sub
End Module
