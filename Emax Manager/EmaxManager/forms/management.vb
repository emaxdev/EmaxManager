Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Net
Imports System.Text

Public Class management

    Public Shared scriptArr As String()
    Dim myScriptList As New List(Of scripts)
    Dim server As String = ""
    Dim username As String = ""
    Dim password As String = ""
    Dim database As String = ""

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpgrade.Click
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
            main.CLBDatabases.Enabled = False
            main.Panel2.Visible = True
            main.currentProcess = 2
            main.tbDeletePass.Focus()
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If
    End Sub


    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunScripts.Click
        Dim selectedDatabases As New Specialized.StringCollection
        My.Settings.checkedDatabases.Clear()
        For Each item In main.CLBDatabases.CheckedItems
            selectedDatabases.Add(item.ToString)
            My.Settings.checkedDatabases = selectedDatabases
            My.Settings.Save()
        Next
        If main.CLBDatabases.CheckedItems.Count > 0 Then
            main.Panel2.Visible = True
            main.currentProcess = 3
            main.tbDeletePass.Focus()
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If
    End Sub

    Private Sub management_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        My.Settings.Reload()
        server = My.Settings.server
        password = My.Settings.password
        username = My.Settings.username
        main.CLBDatabases.Enabled = True
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label1.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Try
            setupFolder()

            If My.Settings.dfltBackUpLocation > "" And IO.Directory.Exists(My.Settings.dfltBackUpLocation) Then
                btnBackUp.Enabled = True
                btnShowBackups.Enabled = True
                btnBackUp.Text = "Back Up Database"
            Else
                btnBackUp.Enabled = False
                btnShowBackups.Enabled = False
                btnBackUp.Text = "Back Up Database [Disabled]"
            End If
            If checkFiles() Then
                btnUpgrade.Enabled = True
                Dim objReader As New System.IO.StreamReader(My.Settings.settingsFolder & "Upgrade.txt")
                Dim versionLine As String = objReader.ReadLine() & vbNewLine
                If main.newFileName > "" Then
                    btnUpgrade.Text = "Upgrade to " & versionLine.Substring(11, 3) & " - Alt"
                Else
                    btnUpgrade.Text = "Upgrade to " & versionLine.Substring(11, 3)
                End If
                objReader.Close()
            Else
                btnUpgrade.Enabled = False
                btnUpgrade.Text = "Upgrade [Disabled]"
            End If
                If My.Settings.updateFolder > "" Then
                    Button4.Enabled = True
                    Button4.Text = "Copy Exe, DLL" & vbCrLf & "and Changes Doc"
                Else
                    Button4.Enabled = False
                    Button4.Text = "Copy Exe, DLL" & vbCrLf & "and Changes Doc [Disabled]"
                End If
                If Not Directory.Exists(My.Settings.settingsFolder) Then
                    Button3.Enabled = False
                    Button5.Visible = True
                    Button5.BringToFront()
                Else
                    Button3.Enabled = True
                    Button5.Visible = False
                End If

                main.connected = True
                'main.Button2.Visible = True

        Catch ex As Exception
            MsgBox("Please check permissions on Emax Manager Application folder!", MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Function setupFolder() As Boolean
        Try
            Dim newPath As String = ""
            Dim theFolderBrowser As New FolderBrowserDialog
            theFolderBrowser.Description = "Please select a path to store settings!"

            If My.Settings.settingsFolder > "" And Not Directory.Exists(My.Settings.settingsFolder) Then
                My.Settings.settingsFolder = ""
                MsgBox("You need to set up a folder to contain settings for Emax Manager")
            End If

            Do While Not Directory.Exists(My.Settings.settingsFolder)

                If Directory.Exists("C:\Emax Files") Or Directory.Exists("Z:\Emax Files") Then

                    If Directory.Exists("C:\Emax Files") Then
                        If MsgBox("Emax Files folder detected in C drive - Would you like to Auto Setup?", vbYesNo, "Auto Setup") = vbYes Then
                            newPath = "C:\Emax Files\Emax Manager\"
                        End If
                    ElseIf Directory.Exists("Z:\Emax Files") Then
                        If MsgBox("Emax Files folder detected in Z drive - Would you like to Auto Setup?", vbYesNo, "Auto Setup") = vbYes Then
                            newPath = "Z:\Emax Files\Emax Manager\"
                        End If
                    End If
                End If

                If Not newPath > "" Then
                    If theFolderBrowser.ShowDialog = Windows.Forms.DialogResult.OK Then
                        newPath = theFolderBrowser.SelectedPath
                    Else
                        Exit Do
                    End If
                End If



                If Not newPath.Substring(newPath.Length - 1) = "\" Then
                    newPath = newPath & "\"
                End If
                If Not Directory.Exists(newPath) Then Directory.CreateDirectory(newPath)
                Try
                    Dim theFile As FileStream = File.Create(newPath & "tester.txt")
                    theFile.Close()
                    File.Delete(newPath & "tester.txt")
                    newPath = newPath & "My Settings\"
                    Directory.CreateDirectory(newPath)
                    If Not Directory.Exists(newPath & "patches\after") Then Directory.CreateDirectory(newPath & "patches\after")
                    If Not Directory.Exists(newPath & "scripts") Then Directory.CreateDirectory(newPath & "scripts")
                    If Not Directory.Exists(newPath & "Power Setups") Then Directory.CreateDirectory(newPath & "Power Setups")
                    If Directory.Exists("C:\Emax Files") Then
                        If Directory.Exists("C:\Emax Files\backups") Then My.Settings.dfltBackUpLocation = "C:\Emax Files\backups"
                    End If
                    If Directory.Exists("C:\Emax Files") Then
                        If Directory.Exists("C:\Emax Files\shared files") Then My.Settings.updateFolder = "C:\Emax Files\shared files"
                    End If
                    My.Settings.settingsFolder = newPath
                    My.Settings.Save()

                    Dim web_client3 As WebClient = New WebClient
                    web_client3.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Buttons.exe", My.Settings.settingsFolder & "patches\after\buttons.exe")

                    Button3.Enabled = True
                    Button5.Visible = False
                Catch ex As Exception
                    MsgBox("You do not have permissions to create files in this location - Please select another.")
                    MsgBox(ex.Message)
                End Try
            Loop
        Catch ex As Exception
            Return False
            Exit Function
        End Try




        Return True
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackUp.Click
        Dim selectedDatabases As New Specialized.StringCollection
        My.Settings.checkedDatabases.Clear()
        For Each item As main.MyListBoxItem In main.CLBDatabases.CheckedItems
            selectedDatabases.Add(item.ExtraData.ToString)
            My.Settings.checkedDatabases = selectedDatabases
            My.Settings.Save()
        Next

        If main.CLBDatabases.CheckedItems.Count > 0 Then
            If My.Settings.dfltBackUpLocation > "" And IO.Directory.Exists(My.Settings.dfltBackUpLocation) Then
                main.CLBDatabases.Enabled = False
                Me.Close()
                Dim backingUp As New backingUp(2)
                backingUp.MdiParent = main
                backingUp.Show()
            End If
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(My.Settings.latest.ToString)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If main.CLBDatabases.CheckedItems.Count = 1 Then
            Me.Close()
            Dim conn As New connections
            conn.MdiParent = main
            conn.Show()
        Else
            MsgBox("Please select one database", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If main.CLBDatabases.CheckedItems.Count > 0 Then
        '    If main.CLBDatabases.CheckedItems.Count = 1 Then
        '        'Dim backingUp As New backingUp(3)
        '        'backingUp.MdiParent = main
        '        'backingUp.Show()
        '        Dim selected As String
        '        selected = ""
        '        For Each item As main.MyListBoxItem In main.CLBDatabases.CheckedItems
        '            selected = item.ExtraData
        '        Next
        '        Me.Close()
        '        main.CLBDatabases.Enabled = False
        '        Dim myrestore As New restore()
        '        myrestore.tbDatabaseName.Text = selected
        '        myrestore.MdiParent = main
        '        myrestore.Show()
        '    Else
        '        MsgBox("Please select either 0 or 1 database(s)!", MsgBoxStyle.Exclamation)
        '    End If
        'Else
        main.CLBDatabases.Enabled = False
        Me.Close()
        Dim myrestore As New restore()
        myrestore.MdiParent = main
        myrestore.Show()
        'End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        main.newFileName = ""
        Me.Close()
        Dim backingUp As New backingUp(5)
        backingUp.MdiParent = main
        backingUp.Show()
    End Sub

    'Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    '    Dim selectedDatabases As New Specialized.StringCollection
    '    Dim versionlist As String
    '    versionlist = ""
    '    My.Settings.checkedDatabases.Clear()
    '    For Each item In main.CLBDatabases.CheckedItems
    '        selectedDatabases.Add(item.ToString)
    '        My.Settings.checkedDatabases = selectedDatabases
    '        My.Settings.Save()
    '    Next
    '    If main.CLBDatabases.CheckedItems.Count > 0 Then
    '        For Each item In main.CLBDatabases.CheckedItems
    '            Dim thisDatabase As String
    '            Dim version As String
    '            thisDatabase = item.ToString
    '            version = worker.getVersion(thisDatabase).ToString
    '            versionlist = versionlist & "Database: " & thisDatabase & " - " & "Version: " & version & vbCrLf
    '        Next
    '        MsgBox(versionlist, MsgBoxStyle.Information, "Emax Manager")
    '    Else
    '        MsgBox("Please select at least one database", vbInformation, "Select a database")
    '    End If
    'End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim backingUp As New backingUp(9)
        backingUp.MdiParent = main
        backingUp.Show()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        setupFolder()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Dim licence As New licences
        licence.MdiParent = main
        licence.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        If main.CLBDatabases.CheckedItems.Count = 1 Then
            If MsgBox("Are you sure you wish to delete this database?", vbYesNo, "Delete Database") = vbYes Then
                main.CLBDatabases.Enabled = False
                main.Panel2.Visible = True
                main.currentProcess = 1
                main.tbDeletePass.Focus()
            End If
        Else
            MsgBox("Please select one database", vbCritical, "One Database")
        End If
    End Sub


    'Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    '    Me.Close()
    '    Dim sched As New scheduler
    '    sched.MdiParent = main
    '    sched.Show()
    'End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Dim selectedDatabases As New Specialized.StringCollection
        My.Settings.checkedDatabases.Clear()
        For Each item In main.CLBDatabases.CheckedItems
            selectedDatabases.Add(item.ToString)
            My.Settings.checkedDatabases = selectedDatabases
            My.Settings.Save()
        Next

        If main.CLBDatabases.CheckedItems.Count > 0 Then
            If My.Settings.dfltBackUpLocation > "" And IO.Directory.Exists(My.Settings.dfltBackUpLocation) Then
                Me.Close()
                Dim backingUp As New backingUp(13)
                backingUp.MdiParent = main
                backingUp.Show()
            End If
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If

    End Sub

    Private Function checkFiles()

        If IO.File.Exists(My.Settings.settingsFolder & "Upgrade.txt") And
            IO.File.Exists(My.Settings.settingsFolder & "patches\after\buttons.mdb") And
            IO.File.Exists(My.Settings.settingsFolder & "patches\after\buttons.exe") Then
            checkFiles = True
        Else
            checkFiles = False
        End If
    End Function

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim udlString As String
        Dim databaseName As String
        If main.CLBDatabases.CheckedItems.Count > 0 Then
            Try
                For Each item As main.MyListBoxItem In main.CLBDatabases.CheckedItems
                    databaseName = item.ExtraData.ToString
                    If IO.File.Exists(My.Settings.updateFolder & "\Shared UDL\" & databaseName & ".udl") Then
                        IO.File.Delete(My.Settings.updateFolder & "\Shared UDL\" & databaseName & ".udl")
                    End If
                    udlString = "[OleDb]" & vbCrLf & "; Everything after this line is an OLE DB initstring" & vbCrLf & "Provider=SQLOLEDB.1;Password=sqllogin1;Persist Security Info=True;User ID=sa;Initial Catalog=" & databaseName & ";Data Source=" & server

                    Using outfile As New StreamWriter(My.Settings.updateFolder & "\Shared UDL\" & databaseName & ".udl", True, System.Text.Encoding.Unicode)
                        outfile.Write(udlString)
                    End Using
                Next
                MsgBox("UDL(s) Created!", vbInformation, "UDL Success")
            Catch ex As Exception
                MsgBox("Something went wrong creating UDL!", vbCritical, "UDL Error")
            End Try
            
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        If main.CLBDatabases.CheckedItems.Count = 1 Then
            Dim selectedDatabases As New Specialized.StringCollection
            My.Settings.checkedDatabases.Clear()
            For Each item As main.MyListBoxItem In main.CLBDatabases.CheckedItems
                selectedDatabases.Add(item.ExtraData.ToString)
            Next
            My.Settings.checkedDatabases = selectedDatabases
            My.Settings.Save()

            Dim backingUp As New backingUp(20)
            backingUp.MdiParent = main
            backingUp.Show()
        Else
            MsgBox("Please select one database", vbInformation, "Select a database")
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Me.Close()
        Dim backingUp As New backingUp(20)
        backingUp.MdiParent = main
        backingUp.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If main.CLBDatabases.CheckedItems.Count = 1 Then
            main.CLBDatabases.Enabled = False
            Me.Close()
            Dim backingUp As New backingUp(21)
            backingUp.MdiParent = main
            backingUp.Show()
        Else
            MsgBox("Please select one database", vbInformation, "Select a database")
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim udlString As String
        Dim databaseName As String
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Settings.updateFolder & "\Shared UDL\")
                IO.File.Delete(foundFile)
            Next
            For Each item As main.MyListBoxItem In main.CLBDatabases.Items
                databaseName = item.ExtraData.ToString
                If IO.File.Exists(My.Settings.updateFolder & "\Shared UDL\" & databaseName & ".udl") Then
                    IO.File.Delete(My.Settings.updateFolder & "\Shared UDL\" & databaseName & ".udl")
                End If
                udlString = "[OleDb]" & vbCrLf & "; Everything after this line is an OLE DB initstring" & vbCrLf & "Provider=SQLOLEDB.1;Password=sqllogin1;Persist Security Info=True;User ID=sa;Initial Catalog=" & databaseName & ";Data Source=" & server

                Using outfile As New StreamWriter(My.Settings.updateFolder & "\Shared UDL\" & databaseName & ".udl", True, System.Text.Encoding.Unicode)
                    outfile.Write(udlString)
                End Using
            Next
            MsgBox("UDL(s) Reset!", vbInformation, "UDL Success")
        Catch ex As Exception
            MsgBox("Something went wrong creating UDL!", vbCritical, "UDL Error")
        End Try

    End Sub

    Private Sub btnLoadOther_Click(sender As Object, e As EventArgs) Handles btnLoadOther.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Try
            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then

                main.newFileName = fd.FileName
               
                Me.Close()
                Dim backingUp As New backingUp(14)
                backingUp.MdiParent = main
                backingUp.Show()
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        main.CLBDatabases.Enabled = False
        Me.Close()
        Dim mySchedule As New scheduler
        mySchedule.MdiParent = main
        mySchedule.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Close()
        Dim backingUp As New backingUp(22)
        backingUp.MdiParent = main
        backingUp.Show()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnShowBackups.Click
        Process.Start("explorer.exe", My.Settings.dfltBackUpLocation)
    End Sub

  

    Private Sub btnLoadOther_DragDrop(sender As Object, e As DragEventArgs) Handles btnLoadOther.DragDrop
        Try

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            For Each path In files
                main.newFileName = path
            Next


            Me.Close()
            Dim backingUp As New backingUp(14)
            backingUp.MdiParent = main
            backingUp.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLoadOther_DragEnter(sender As Object, e As DragEventArgs) Handles btnLoadOther.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class