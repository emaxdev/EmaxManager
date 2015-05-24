Imports System.IO

Public Class restore


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim theFolderBrowser As New OpenFileDialog

        If IO.Directory.Exists(My.Settings.dfltRestoreFileLoc) Then
            theFolderBrowser.InitialDirectory = My.Settings.dfltRestoreFileLoc
        End If

        If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then

            tbRstrFileLoc.Text = theFolderBrowser.FileName

        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim theFolderBrowser As New FolderBrowserDialog
        theFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        If IO.Directory.Exists(My.Settings.dfltRestoreDir) Then
            theFolderBrowser.SelectedPath = My.Settings.dfltRestoreDir

        End If


        ' If the user clicks theFolderBrowser's OK button..

        If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Set the FolderChoiceTextBox's Text to theFolderBrowserDialog's

            '    SelectedPath property.

            tbRstrLoc.Text = theFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim exists As Boolean
        exists = False
        If (IO.Directory.Exists(tbRstrLoc.Text)) And (IO.File.Exists(tbRstrFileLoc.Text)) And (tbDatabaseName.Text <> "") Then
            For Each item In My.Settings.databaseList
                If item.Equals(tbDatabaseName.Text) Then exists = True
            Next
            If exists Then MsgBox("Database " & tbDatabaseName.Text & " already exists!  Sorry you can't restore over existing databases with Emax Manager. Delete first to continue or use another name.", MsgBoxStyle.Information, "Database Exists") : Exit Sub
            Dim backingUp As New backingUp(3, tbRstrFileLoc.Text, tbRstrLoc.Text, tbDatabaseName.Text)
            backingUp.MdiParent = main
            backingUp.Show()
            Me.Close()
        Else
            MsgBox("Please ensure you fill in all fields including Database Name.", vbCritical, "Misssing Info")
        End If


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.Close()
        Dim manage As New management
        manage.MdiParent = main
        manage.Show()
    End Sub

    Private Sub tbRstrFileLoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IO.File.Exists(tbRstrFileLoc.Text) Then
            My.Settings.dfltRestoreFileLoc = tbRstrFileLoc.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub loadColours()
        Panel1.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Panel2.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Panel3.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Panel4.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label1.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'tbRstrFileLoc.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'tbDatabaseName.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'tbRstrLoc.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'cbPowerSetups.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
    End Sub

    Private Sub restore_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tbDatabaseName.Focus()
    End Sub

    Private Sub restore_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadColours()
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        If IO.File.Exists(My.Settings.dfltRestoreFileLoc) Then
            tbRstrFileLoc.Text = My.Settings.dfltRestoreFileLoc
        End If
        If IO.Directory.Exists(My.Settings.dfltRestoreDir) Then
            tbRstrLoc.Text = My.Settings.dfltRestoreDir
        End If
        If Directory.Exists(My.Settings.settingsFolder & "Power Setups") Then
            If IO.File.Exists(My.Settings.settingsFolder & "Power Setups\Emilio.bak") Then
                cbPowerSetups.Items.Add("Emilio")
                cbPowerSetups.Visible = True
                lblPower.Visible = True
                btnGetPowers.Visible = False
            End If
            If IO.File.Exists(My.Settings.settingsFolder & "Power Setups\Heather.bak") Then
                cbPowerSetups.Items.Add("Heather")
                cbPowerSetups.Visible = True
                lblPower.Visible = True
                btnGetPowers.Visible = False
            End If
            If IO.File.Exists(My.Settings.settingsFolder & "Power Setups\Chris.bak") Then
                cbPowerSetups.Items.Add("Chris")
                cbPowerSetups.Visible = True
                lblPower.Visible = True
                btnGetPowers.Visible = False
            End If
        End If
    End Sub

    Private Sub tbRstrLoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IO.Directory.Exists(tbRstrLoc.Text) Then
            My.Settings.dfltRestoreDir = tbRstrLoc.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub cbPowerSetups_SelectedIndexChanged(sender As Object, e As EventArgs)
     
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim backing As New backingUp(12)
        backing.MdiParent = main
        backing.Show()
    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        Dim theFolderBrowser As New FolderBrowserDialog
        theFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        If IO.Directory.Exists(My.Settings.dfltRestoreDir) Then
            theFolderBrowser.SelectedPath = My.Settings.dfltRestoreDir

        End If


        ' If the user clicks theFolderBrowser's OK button..

        If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Set the FolderChoiceTextBox's Text to theFolderBrowserDialog's

            '    SelectedPath property.

            tbRstrLoc.Text = theFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click


        Dim theFolderBrowser As New OpenFileDialog

        If IO.Directory.Exists(My.Settings.dfltRestoreFileLoc) Then
            theFolderBrowser.InitialDirectory = My.Settings.dfltRestoreFileLoc
        End If

        If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then

            tbRstrFileLoc.Text = theFolderBrowser.FileName

        End If
    End Sub

    Private Sub btnGetPowers_Click(sender As Object, e As EventArgs) Handles btnGetPowers.Click
        Dim backing As New backingUp(12)
        backing.MdiParent = main
        backing.Show()
    End Sub

    Private Sub cbPowerSetups_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbPowerSetups.SelectedIndexChanged
        If cbPowerSetups.SelectedItem.Equals("Emilio") Then
            tbRstrFileLoc.Text = My.Settings.settingsFolder & "Power Setups\Emilio.bak"
        End If
        If cbPowerSetups.SelectedItem.Equals("Heather") Then
            tbRstrFileLoc.Text = My.Settings.settingsFolder & "Power Setups\Heather.bak"
        End If
        If cbPowerSetups.SelectedItem.Equals("Chris") Then
            tbRstrFileLoc.Text = My.Settings.settingsFolder & "Power Setups\Chris.bak"
        End If
    End Sub

    Private Sub tbRstrLoc_TextChanged1(sender As Object, e As EventArgs) Handles tbRstrLoc.TextChanged
        If IO.Directory.Exists(tbRstrLoc.Text) Then
            My.Settings.dfltRestoreDir = tbRstrLoc.Text
            My.Settings.Save()
        End If
    End Sub
End Class