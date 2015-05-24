Public Class log

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        'main.Button2.Visible = True
    End Sub

    Private Sub log_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each item In main.lbLog.Items
            ListView1.Items.Add(item)
        Next
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        For Each line As ListViewItem In ListView1.Items
            If line.ToString.Contains("fail") Then
                line.ForeColor = Color.Red
            End If
        Next
        main.Button2.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListView1.Items.Clear()
    End Sub
End Class