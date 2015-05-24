Imports System.Data.Sql

Public Class serverConnect
    Dim server As String = ""
    Dim username As String = ""
    Dim password As String = ""

    Private Sub buttons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadColours()
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        Try
            server = My.Settings.server
            username = My.Settings.username
            password = My.Settings.password
            cbRemeberPassword.Checked = My.Settings.remember
            serverCombo.Text = My.Settings.server

            If server Is Nothing Then
                serverCombo.Text = Environment.MachineName
            Else
                serverCombo.Text = server
            End If

            If cbRemeberPassword.Checked Then
                txtPassword.Text = password
            Else
                txtPassword.Text = ""
            End If

            If username Is Nothing Then
                txtUsername.Text = ""
            Else
                txtUsername.Text = username
            End If

            For Each item In My.Settings.serverList
                serverCombo.Items.Add(item)
            Next
           

        Catch ex As Exception
        End Try

    End Sub

    Private Sub loadColours()
        Panel1.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Panel2.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Panel3.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label1.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'txtPassword.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'txtUsername.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'serverCombo.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
    End Sub

    Public Function LoadDatabases()
        Try
            Me.Close()

            Dim backingUp As New backingUp(8)
            backingUp.MdiParent = main
            backingUp.Show()

        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        My.Settings.serverList.Clear()
        serverCombo.Items.Clear()
        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim otable As System.Data.DataTable = instance.GetDataSources()

        For Each oRow As DataRow In otable.Rows
            If oRow("InstanceName").ToString = "" Then
                serverCombo.Items.Add(oRow("ServerName"))
                My.Settings.serverList.Add(oRow("ServerName"))
            Else
                serverCombo.Items.Add(oRow("ServerName").ToString & "\" & oRow("InstanceName").ToString)
                My.Settings.serverList.Add(oRow("ServerName").ToString & "\" & oRow("InstanceName").ToString)
            End If
        Next oRow
        My.Settings.Save()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        My.Settings.serverList.Clear()
        serverCombo.Items.Clear()
        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim otable As System.Data.DataTable = instance.GetDataSources()

        For Each oRow As DataRow In otable.Rows
            If oRow("InstanceName").ToString = "" Then
                serverCombo.Items.Add(oRow("ServerName"))
                My.Settings.serverList.Add(oRow("ServerName"))
            Else
                serverCombo.Items.Add(oRow("ServerName").ToString & "\" & oRow("InstanceName").ToString)
                My.Settings.serverList.Add(oRow("ServerName").ToString & "\" & oRow("InstanceName").ToString)
            End If
        Next oRow
        My.Settings.Save()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If ((serverCombo.Text > "") And (txtUsername.Text > "") And (txtPassword.Text > "")) Then
            My.Settings.server = serverCombo.Text
            My.Settings.username = txtUsername.Text
            My.Settings.password = txtPassword.Text
            My.Settings.remember = cbRemeberPassword.Checked
            My.Settings.Save()

            If LoadDatabases() Then

                Me.Hide()
                main.PictureBox6.Visible = True
                'Dim loading As New Loading
                'loading.MdiParent = main
                'loading.Show()
            Else
                My.Settings.server = ""
                My.Settings.username = ""
                My.Settings.password = ""
                My.Settings.remember = cbRemeberPassword.Checked
                My.Settings.Save()
            End If
        Else
            MsgBox("Please complete all fields", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class