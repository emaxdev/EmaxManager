Public Class mysettings

    Private R As String
    Private B As String
    Private G As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        main.PictureBox6.Enabled = True
        My.Settings.R = R
        My.Settings.G = G
        My.Settings.B = B
        My.Settings.dfltBackUpLocation = TextBox1.Text
        My.Settings.updateFolder = TextBox2.Text
        My.Settings.mainDatabase = drpMainDatabase.Text
        My.Settings.mainDatabaseLocked = cbLocked.CheckState
        My.Settings.autoBackUp = cbBackUp.CheckState
        My.Settings.dontRunViews = cbViews.CheckState
        My.Settings.hideDisclaimer = IIf(chkShowDisclaimer.CheckState = 1, False, True)
        My.Settings.autoCheckForUpdate = IIf(chkAutoCheckForUpdate.CheckState = 1, True, False)
        My.Settings.openBackupFolder = IIf(openBackupFolder.CheckState = 1, True, False)
        My.Settings.companyName = tbCompany.Text
        My.Settings.autoBackUpOnDelete = IIf(cbBackupDelete.CheckState = 1, True, False)
        My.Settings.Save()

        Dim manage As New management
        manage.MdiParent = main
        manage.Show()

        Me.Close()
    End Sub

    Private Sub mysettings_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TextBox1.Focus()
    End Sub

    Private Sub mysettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TrackBar1.Value = IIf(My.Settings.R > "", My.Settings.R, 0)
        TrackBar2.Value = IIf(My.Settings.B > "", My.Settings.B, 0)
        TrackBar3.Value = IIf(My.Settings.G > "", My.Settings.G, 0)
        Panel1.BackColor = Color.FromArgb(R, B, G)
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label5.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        If My.Settings.dfltBackUpLocation > "" Then
            TextBox1.Text = My.Settings.dfltBackUpLocation
        End If
        If My.Settings.updateFolder > "" Then
            TextBox2.Text = My.Settings.updateFolder
        End If
        TextBox3.Text = My.Settings.settingsFolder
        drpMainDatabase.Text = My.Settings.mainDatabase
        cbLocked.Checked = My.Settings.mainDatabaseLocked
        cbBackUp.Checked = My.Settings.autoBackUp
        cbViews.Checked = My.Settings.dontRunViews
        chkShowDisclaimer.CheckState = IIf(My.Settings.hideDisclaimer, 0, 1)
        chkAutoCheckForUpdate.CheckState = IIf(My.Settings.autoCheckForUpdate, 1, 0)
        openBackupFolder.CheckState = IIf(My.Settings.openBackupFolder, 1, 0)
        cbBackupDelete.CheckState = IIf(My.Settings.autoBackUpOnDelete, 1, 0)
        tbCompany.Text = My.Settings.companyName
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main.PictureBox6.Enabled = True
        Dim manage As New management
        manage.MdiParent = main
        manage.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As System.EventArgs)
        My.Settings.Reload()
        Dim server = My.Settings.server
        Dim password = My.Settings.password
        Dim username = My.Settings.username
        drpMainDatabase.Items.Clear()
        Try

            Dim mySQLConnection As New mySQLConnection

            If mySQLConnection.OpenConnection("Server=" & server & ";Database=Master;UID=" & username & ";PWD=" & password) = False Then
                MsgBox("Error connection to SQL Server", MsgBoxStyle.Exclamation, "Load Databases")
                Exit Sub
            End If

            Dim strSQL = "SELECT [name] FROM master.dbo.sysdatabases WHERE (dbid > 4) ORDER BY [name]"

            If mySQLConnection.ReadData(strSQL) = True Then
                While mySQLConnection.myDataReader.Read
                    drpMainDatabase.Items.Add(mySQLConnection.myDataReader(0))
                End While
            End If

            mySQLConnection.CloseConnection()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        My.Settings.settingsFolder = ""
        My.Settings.Save()
        TextBox3.Text = ""
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        tbG.Text = TrackBar3.Value
        Panel1.BackColor = Color.FromArgb(R, B, G)
    End Sub

    Private Sub tbR_TextChanged(sender As Object, e As EventArgs) Handles tbR.TextChanged
        R = tbR.Text
        setColours()
    End Sub

    Private Sub tbB_TextChanged(sender As Object, e As EventArgs) Handles tbB.TextChanged
        B = tbB.Text
        setColours()
    End Sub

    Private Sub tbG_TextChanged(sender As Object, e As EventArgs) Handles tbG.TextChanged
        G = tbG.Text
        setColours()
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        tbR.Text = TrackBar1.Value
    End Sub

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        tbB.Text = TrackBar2.Value
    End Sub

   
    Private Sub TrackBar3_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar3.ValueChanged
        tbG.Text = TrackBar3.Value
    End Sub

    Private Sub setColours()
        Panel1.BackColor = Color.FromArgb(R, B, G)
        main.Panel4.BackColor = Color.FromArgb(R, B, G)
        'Label4.BackColor = Color.FromArgb(R, B, G)
        'tbCompany.BackColor = Color.FromArgb(R, B, G)
        Panel2.BackColor = Color.FromArgb(R, B, G)
        Panel3.BackColor = Color.FromArgb(R, B, G)
        Panel4.BackColor = Color.FromArgb(R, B, G)
        Panel5.BackColor = Color.FromArgb(R, B, G)
        Label14.BackColor = Color.FromArgb(R, B, G)
        'TextBox1.BackColor = Color.FromArgb(R, B, G)
        'TextBox2.BackColor = Color.FromArgb(R, B, G)
        'TextBox3.BackColor = Color.FromArgb(R, B, G)
        Label1.BackColor = Color.FromArgb(R, B, G)
        Label2.BackColor = Color.FromArgb(R, B, G)
        Label3.BackColor = Color.FromArgb(R, B, G)
        Label4.BackColor = Color.FromArgb(R, B, G)
        'drpMainDatabase.BackColor = Color.FromArgb(R, B, G)
        Panel6.BackColor = Color.FromArgb(166, 216, 129)
        Panel7.BackColor = Color.FromArgb(207, 39, 34)
        Panel8.BackColor = Color.FromArgb(200, 200, 200)
        Panel9.BackColor = Color.FromArgb(100, 100, 100)
        Panel10.BackColor = Color.FromArgb(37, 172, 211)
        headerPanel.BackColor = Color.FromArgb(R, B, G)
        Label5.ForeColor = worker.darkLight(R, B, G)
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        tbCompany.Enabled = Not tbCompany.Enabled
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim theFolderBrowser As New FolderBrowserDialog

        If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = theFolderBrowser.SelectedPath
            If Not TextBox2.Text.Substring(TextBox2.Text.Length - 1) = "\" Then
                TextBox2.Text = TextBox2.Text & "\"
            End If
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        My.Settings.settingsFolder = ""
        My.Settings.Save()
        TextBox3.Text = ""
    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim theFolderBrowser As New FolderBrowserDialog

        If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = theFolderBrowser.SelectedPath
            If Not TextBox1.Text.Substring(TextBox1.Text.Length - 1) = "\" Then
                TextBox1.Text = TextBox1.Text & "\"
            End If
        End If
    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        TrackBar1.Value = 166
        TrackBar2.Value = 216
        TrackBar3.Value = 129
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        TrackBar1.Value = 207
        TrackBar2.Value = 39
        TrackBar3.Value = 34
    End Sub

    Private Sub Panel8_Click(sender As Object, e As EventArgs) Handles Panel8.Click
        TrackBar1.Value = 200
        TrackBar2.Value = 200
        TrackBar3.Value = 200
    End Sub

    Private Sub Panel9_Click(sender As Object, e As EventArgs) Handles Panel9.Click
        TrackBar1.Value = 100
        TrackBar2.Value = 100
        TrackBar3.Value = 100
    End Sub

    Private Sub Panel10_Click(sender As Object, e As EventArgs) Handles Panel10.Click
        TrackBar1.Value = 37
        TrackBar2.Value = 172
        TrackBar3.Value = 211
    End Sub

    Private Sub drpMainDatabase_DropDown(sender As Object, e As EventArgs) Handles drpMainDatabase.DropDown
        My.Settings.Reload()
        Dim server = My.Settings.server
        Dim password = My.Settings.password
        Dim username = My.Settings.username
        drpMainDatabase.Items.Clear()
        Try

            Dim mySQLConnection As New mySQLConnection

            If mySQLConnection.OpenConnection("Server=" & server & ";Database=Master;UID=" & username & ";PWD=" & password) = False Then
                MsgBox("Error connection to SQL Server", MsgBoxStyle.Exclamation, "Load Databases")
                Exit Sub
            End If

            Dim strSQL = "SELECT [name] FROM master.dbo.sysdatabases WHERE (dbid > 4) ORDER BY [name]"

            If mySQLConnection.ReadData(strSQL) = True Then
                While mySQLConnection.myDataReader.Read
                    drpMainDatabase.Items.Add(mySQLConnection.myDataReader(0))
                End While
            End If

            mySQLConnection.CloseConnection()
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll

    End Sub

   
   

  
    Private Sub cbBackUp_CheckedChanged(sender As Object, e As EventArgs) Handles cbBackUp.CheckedChanged

    End Sub
    Private Sub cbViews_CheckedChanged(sender As Object, e As EventArgs) Handles cbViews.CheckedChanged

    End Sub
End Class