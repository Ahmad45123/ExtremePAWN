Public Class KeyDetector

    Public PressedKey As Keys

    Private Sub KeyDetector_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        PressedKey = e.KeyCode
        Me.Close()
    End Sub
End Class