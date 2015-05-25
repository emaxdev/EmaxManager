Imports Microsoft.Win32.TaskScheduler
Imports System.IO

Public Class upgrade

  

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadStuff()
    End Sub


    Private Sub loadStuff()
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        tbUpgradeFile.Text = IIf(My.Settings.upgradeFileLocation > "", My.Settings.upgradeFileLocation, My.Settings.settingsFolder & "Upgrade.txt")
        btnReset.Visible = My.Settings.upgradeFileLocation > ""
        lblUpgradeDetails.Text = Trim(worker.getTextBetweenComments(File.ReadAllText(tbUpgradeFile.Text), "--Comments Start", "--Comments End"))
        lblUpgradeDetails.Text = Replace(lblUpgradeDetails.Text, "--Comments Start", "")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        main.Panel2.Visible = False
        main.tbAction.Visible = False
        Me.Close()
        Dim backingUp As New backingUp(99999)
        backingUp.MdiParent = main
        backingUp.Show()

    End Sub


    
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        My.Settings.upgradeFileLocation = ""
        My.Settings.Save()
        loadStuff()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not My.Settings.companyName > "" Then
            main.Label2.ForeColor = Color.Red
        Else
            main.Label2.ForeColor = Color.Black
        End If

        Dim selectedDatabases As New Specialized.StringCollection
        My.Settings.checkedDatabases.Clear()
        For Each item As main.MyListBoxItem In main.CLBDatabases.CheckedItems
            If item.ExtraData = My.Settings.mainDatabase And My.Settings.mainDatabaseLocked Then
                MsgBox("You have selected your main Database and it is locked for Editing" & vbCrLf & "Please de-select or unlock", vbCritical)
                Exit Sub
            End If
            selectedDatabases.Add(item.ExtraData.ToString)
        Next
        My.Settings.checkedDatabases = selectedDatabases
        My.Settings.Save()

        If main.CLBDatabases.CheckedItems.Count > 0 Then
            main.tbAction.Text = "Upgrade?"
            main.tbAction.Visible = True
            main.CLBDatabases.Enabled = False
            main.Panel2.Visible = True
            main.currentProcess = 2
            main.tbDeletePass.Focus()
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If
    End Sub

  
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            My.Settings.upgradeFileLocation = fd.FileName
            My.Settings.Save()
            loadStuff()
        End If
    End Sub

    Private Sub tbUpgradeFile_DragDrop(sender As Object, e As DragEventArgs) Handles tbUpgradeFile.DragDrop
        Try

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each path In files
                My.Settings.upgradeFileLocation = path
            Next
            My.Settings.Save()
            loadStuff()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tbUpgradeFile_TextChanged(sender As Object, e As EventArgs) Handles tbUpgradeFile.TextChanged

    End Sub

    Private Sub Panel4_DragDrop(sender As Object, e As DragEventArgs) Handles Panel4.DragDrop
        Try

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each path In files
                My.Settings.upgradeFileLocation = path
            Next
            My.Settings.Save()
            loadStuff()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class