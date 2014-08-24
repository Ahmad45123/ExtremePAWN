Public Class ResizeableControl

    Private WithEvents mControl As Control
    Private mMouseDown As Boolean = False
    Private mWidth As Integer = 4

    Public Sub New(ByVal Control As Control)
        mControl = Control
    End Sub

    Private Sub mControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mMouseDown = True
        End If
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseUp
        mMouseDown = False
    End Sub

    Private Sub mControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mControl.MouseMove
        Dim c As Control = CType(sender, Control)
        If mMouseDown = True Then
            If e.Y <= mWidth Then
                MsgBox("Yes")
            End If
        End If
    End Sub

    Private Sub mControl_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles mControl.MouseLeave


    End Sub

End Class