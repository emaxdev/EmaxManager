Public Class Integrity

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Dim manage As New management
        manage.MdiParent = main
        manage.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Process.Start("explorer.exe", My.Settings.settingsFolder & "patches\")
    End Sub

    Private Sub Integrity_Load(sender As Object, e As EventArgs) Handles Me.Load
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label2.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
    End Sub
End Class