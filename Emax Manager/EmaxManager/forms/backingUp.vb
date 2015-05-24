Imports System.ComponentModel
Imports System.Threading
Imports System.Net
Imports System.IO

Public Class backingUp
    Private _worker As BackgroundWorker
    Private Action As Integer
    Public Shared listOfDB As List(Of String)
    Public status As String
    Public thisItem As String
    Public currentDB As String
    Public restoreLoc As String
    Public restoreFile As String
    Public restoreName As String
    Public lastUpdated As String
    Public server As String = My.Settings.server
    Public username As String = My.Settings.username
    Public password As String = My.Settings.password
    Public scriptsChecked As Boolean = False
    Public connectedToSql As Boolean
    Private integrity As String
    Private upgrading As Integer
    Public nameFrom As String
    Public nameTo As String


    Public Sub New(ByVal actionID As Integer, Optional ByVal thisRestoreFile As String = "", Optional ByVal thisRestoreLoc As String = "", Optional ByVal thisRestoreName As String = "")

        ' This call is required by the Windows Form Designer.   
        InitializeComponent()
        Action = actionID
        restoreFile = thisRestoreFile
        restoreLoc = thisRestoreLoc
        restoreName = thisRestoreName
        ' Add any initialization after the InitializeComponent() call.   
    End Sub


    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        MyBase.OnLoad(e)
        _worker = New BackgroundWorker()
        main.PictureBox1.Enabled = False
        main.PictureBox2.Enabled = False
        main.PictureBox3.Enabled = False
        main.PictureBox6.Enabled = False
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label1.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        main.Button1.Enabled = False
        'main.btnMainExit.Enabled = False
        AddHandler _worker.DoWork, AddressOf WorkerDoWork
        AddHandler _worker.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler _worker.RunWorkerCompleted, AddressOf WorkerCompleted
        _worker.WorkerReportsProgress = True

        _worker.WorkerSupportsCancellation = True
        _worker.RunWorkerAsync()
    End Sub


    Private Sub WorkerDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim location As String = My.Settings.dfltBackUpLocation
        Dim tempListOfLog As New ListBox
        Dim listOfFails As String = ""

        Try
            If Action = 14 Then
                If InStrRev(main.newFileName, "Upgrade.txt") Then
                    FileCopy(main.newFileName, My.Settings.settingsFolder & "Upgrade.txt")
                End If
                GoTo done
            End If

            For Each item In My.Settings.checkedDatabases
                thisItem = item
                Application.DoEvents()
                _worker.ReportProgress(6)
                If Action = 21 Then
                    If worker.createPlay(item, location) Then
                        status = "---- " & item & " backed up successfully! ----"
                    Else
                        status = "---- " & item & " back up failed! ----"
                    End If
                End If


                If Action = 2 Or Action = 13 Then
                    If (location <> "") And (item <> "") Then
                        status = item & " backing up!"
                        _worker.ReportProgress(1)
                        If worker.backUp(item, location, Action = 13) Then
                            status = "---- " & item & " backed up successfully! ----"
                            If Action = 2 And My.Settings.openBackupFolder Then
                                Process.Start("explorer.exe", My.Settings.dfltBackUpLocation)
                            End If
                        Else
                            status = "---- " & item & " back up failed! ----"
                        End If
                        lastUpdated = item
                        _worker.ReportProgress(1)
                        _worker.ReportProgress(3)
                        _worker.ReportProgress(2)
                    Else
                        MsgBox("Please select a back-up location!")
                        status = "---- " & item & " back up failed! ----"
                        Exit Sub
                    End If
                End If
                If Action = 1 Then
                    Dim backupSuccess As Boolean
                    Dim upgradeFile As String
                    Dim currentVersion As Double
                    Dim latestVersion As Double
                    If worker.getSage(item).Equals("MMS200") Then
                        MsgBox("It looks like this database is connected to Sage MMS 200 - Please check version before installing Exe and DLL")
                    End If
                    If IO.File.Exists(My.Settings.settingsFolder & "Upgrade.txt") Then
                        upgradeFile = My.Settings.settingsFolder & "Upgrade.txt"

                        'Get current version of database
                        currentVersion = (worker.getVersion(item) * 100)

                        Dim objReader As New System.IO.StreamReader(upgradeFile)
                        Dim versionLine As String = objReader.ReadLine() & vbNewLine

                        latestVersion = versionLine.Substring(11, 3)
                    End If
                    If (currentVersion < latestVersion) Then
                        If My.Settings.autoBackUp Then
                            If (location <> "") And (item <> "") Then
                                status = item & " backing up!"
                                _worker.ReportProgress(1)
                                backupSuccess = worker.backUp(item, location)
                                If backupSuccess Then
                                    status = "---- " & item & " backed up successfully! ----"
                                Else
                                    status = "---- " & item & " back up failed! ----"
                                End If
                                _worker.ReportProgress(1)
                                _worker.ReportProgress(3)
                                '_worker.ReportProgress(2)
                            Else
                                MsgBox("Please select a back-up location!")
                            End If
                        Else
                            backupSuccess = True
                        End If
                    Else
                        MsgBox("You appear to be up to date!")
                    End If
                    If item <> "" And backupSuccess Then
                        status = item & " upgrading!"
                        _worker.ReportProgress(1)
                        If worker.newupgrade(item) Then
                            'If IO.File.Exists(worker.backUpFileName) Then
                            '    IO.File.Delete(worker.backUpFileName)
                            'End If
                            lastUpdated = item
                            _worker.ReportProgress(2)
                        Else
                            status = "---- " & item & " upgrade failed! ----"
                            listOfFails = listOfFails & item & vbCrLf

                            Exit For
                        End If
                        _worker.ReportProgress(1)
                        _worker.ReportProgress(3)
                    Else
                        MsgBox(item & " upgrade cancelled!")
                    End If
                End If

                If Action = 4 Then
                    status = item & " restoring!"
                    _worker.ReportProgress(1)
                    If worker.restore("C:\Databses BackUps\PowerSetup_686 SQL2005.sql", "C:\Emax Files\DataBases", item) Then
                        status = "---- " & item & " restored successfully! ----"
                        _worker.ReportProgress(2)
                    Else
                        status = "---- " & item & " restore failed! ----"
                    End If
                    _worker.ReportProgress(1)
                    _worker.ReportProgress(3)
                End If
            Next
            If Action = 3 Then
                If restoreFile > "" And restoreLoc > "" And restoreName > "" Then
                    status = restoreName & " restoring!"
                    _worker.ReportProgress(1)
                    If worker.restore(restoreFile, restoreLoc, restoreName) Then
                        status = "---- " & restoreName & " restored successfully! ----"
                    Else
                        status = "---- " & restoreName & " restore failed! ----"
                    End If
                    _worker.ReportProgress(1)
                    _worker.ReportProgress(3)
                End If
            End If


            If Action = 5 Then
                checkForUpdate()
            End If


            If Action = 8 Then
                _worker.ReportProgress(4)
                Dim mySQLConnection As New mySQLConnection
                connectedToSql = mySQLConnection.OpenConnection("Server=" & server & ";Database=Master;UID=" & username & ";PWD=" & password & ";Connect Timeout=10")
                'MsgBox("Error connecting to SQL Server", MsgBoxStyle.Exclamation, "Load Databases")
                If connectedToSql Then
                    Dim strVersionSQL = "SELECT SERVERPROPERTY('productversion')"
                    If mySQLConnection.ReadData(strVersionSQL) = True Then
                        While mySQLConnection.myDataReader.Read
                            If mySQLConnection.myDataReader(0).ToString.Substring(0, 1) = "8" Then
                                MsgBox("Please check if running SQL2000")
                            End If
                        End While
                    End If
                    mySQLConnection.myDataReader.Close()
                End If

                Dim strSQL = "create table #t (DBName sysname not null) exec sp_msforeachdb 'use [?]; if OBJECT_ID(''dbo.System'') is not null AND OBJECT_ID(''dbo.Part'') is not null AND OBJECT_ID(''dbo.Bom'') is not null insert into #t (DBName) select ''?''' select * from #t drop table #t"
                If connectedToSql Then
                    If mySQLConnection.ReadData(strSQL) = True Then
                        My.Settings.databaseList.Clear()
                        While mySQLConnection.myDataReader.Read
                            My.Settings.databaseList.Add(mySQLConnection.myDataReader(0))
                        End While
                        My.Settings.Save()
                    End If

                    mySQLConnection.CloseConnection()
                End If
                _worker.ReportProgress(4)
            End If

            If Action = 9 Then
                Try
                    Dim web_client3 As WebClient = New WebClient
                    web_client3.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Emax Systems.exe", My.Settings.settingsFolder & "Emax Systems.exe")
                    web_client3.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/RM6_Server.dll", My.Settings.settingsFolder & "RM6_Server.dll")
                    web_client3.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Changes.doc", My.Settings.settingsFolder & "Changes.doc")
                    If worker.copyExeEtc() Then
                        'log.Add(database & " - copying Exe and Dll successfull")
                    Else
                        'log.Add(database & " - copying Exe and Dll failed")
                        MsgBox("Exe and Dll not copied - Please copy across manually.")
                    End If
                Catch ex As Exception
                    'log.Add(database & " - copying Exe and Dll failed")
                    MsgBox("Exe and Dll not copied - Please copy across manually." & Err.Description)
                End Try
            End If

            If Action = 10 Then
                scriptsChecked = False
                Try
                    Dim web_client2 As WebClient = New WebClient
                    web_client2.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/scripts/list.txt", My.Settings.settingsFolder & "list.txt")
                    Dim strContent As String()
                    strContent = System.IO.File.ReadAllLines(My.Settings.settingsFolder & "list.txt")
                    For Each item In strContent
                        Try
                            Dim itemTo As String = Replace(item, ".txt", ".sql")
                            web_client2.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/scripts/" & item, My.Settings.settingsFolder & "scripts\" & itemTo)
                        Catch ex As Exception
                        End Try
                    Next
                    scriptsChecked = True
                Catch ex As Exception
                    MsgBox("Sorry - Problem downloading scripts!", vbInformation, "Error")
                End Try
            End If

            If Action = 11 Then
                worker.delete(thisItem)
            End If

            If Action = 12 Then
                Try
                    Dim web_client1 As WebClient = New WebClient
                    web_client1.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/PowerSetups/Chris.txt", My.Settings.settingsFolder & "Power Setups\Chris.bak")
                    web_client1.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/PowerSetups/Emilio.txt", My.Settings.settingsFolder & "Power Setups\Emilio.bak")
                    web_client1.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/PowerSetups/Heather.txt", My.Settings.settingsFolder & "Power Setups\Heather.bak")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            'If Action = 13 Then
            '    'Dim bytesread As Integer = 0
            '    'Dim buffer As Integer = 8100

            '    'Dim fRequest As FtpWebRequest = WebRequest.Create("ftp://dataorigins.com/temp.zip")
            '    'fRequest.Credentials = New NetworkCredential("administrator", "X5j4k1M0")
            '    'fRequest.KeepAlive = False
            '    'fRequest.Proxy = Nothing
            '    'fRequest.UsePassive = True
            '    'fRequest.UseBinary = True
            '    'fRequest.Method = WebRequestMethods.Ftp.UploadFile
            '    'fRequest.Timeout = 180000

            '    Try
            '        ' read in file...
            '        'Dim reader As New StreamReader(fileItem)
            '        Dim clsRequest As System.Net.FtpWebRequest = _
            '  DirectCast(System.Net.WebRequest.Create("ftp://dataorigins.com/temp.bak.gz"), System.Net.FtpWebRequest)
            '        clsRequest.Credentials = New System.Net.NetworkCredential("administrator", "X5j4k1M0")
            '        clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            '        clsRequest.KeepAlive = True
            '        clsRequest.Proxy = Nothing
            '        clsRequest.UsePassive = True
            '        clsRequest.UseBinary = True
            '        clsRequest.Timeout = 150000
            '        Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Settings.settingsFolder & "temp\temp.bak.gz")

            '        ' upload file...
            '        Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()

            '        clsStream.Write(bFile, 0, bFile.Length)
            '        clsStream.Close()
            '        clsStream.Dispose()

            '        'Dim fs As FileStream = File.OpenRead(My.Settings.settingsFolder & "temp\temp.zip")
            '        'Dim length As Long
            '        'length = fs.Length
            '        'Dim complete As Long
            '        'Dim bFile As Byte() = New Byte(8100) {}
            '        'Dim fstream As Stream = fRequest.GetRequestStream
            '        '' upload file...
            '        'Do
            '        '    bytesread = fs.Read(bFile, 0, buffer)
            '        '    'fs.Read(bFile, 0, buffer)
            '        '    fstream.Write(bFile, 0, bFile.Length)
            '        '    complete = complete + 8100
            '        '    _worker.ReportProgress(complete / length * 100)
            '        'Loop Until bytesread = 0
            '        'fstream.Close()
            '        'fstream.Dispose()

            '    Catch ex As Exception
            '        MsgBox(Err.Description)
            '    End Try
            'End If

            If Action = 15 Then
                worker.rename(nameFrom, nameTo)
            End If

            If Action = 20 Then
                integrity = worker.checkIntegrity(thisItem)
            End If

            If Action = 22 Then
                Try
                    Dim web_client3 As WebClient = New WebClient
                    web_client3.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Get_New_Version_New.exe", My.Settings.settingsFolder & "Get_New_Version_New.exe")
                    web_client3.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/NewFilelist.txt", My.Settings.settingsFolder & "NewFilelist.txt")
                    If worker.newStyle() Then
                        'log.Add(database & " - copying Exe and Dll successfull")
                    Else
                        'log.Add(database & " - copying Exe and Dll failed")
                        MsgBox("New files not copied - Please copy across manually.")
                    End If
                Catch ex As Exception
                    'log.Add(database & " - copying Exe and Dll failed")
                    MsgBox("New files not copied - Please copy across manually.")
                End Try
            End If

done:
            status = "Connected to: " & My.Settings.server
            _worker.ReportProgress(1)
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox(ex.Message)
        End Try

    End Sub

    ' This is executed on the UI thread after the work is complete.  It's a good place to either
    ' close the dialog or indicate that the initialization is complete.  It's safe to work with
    ' controls from this event.
    Private Sub WorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

        Me.Close()

        main.Button1.Enabled = True


        main.CLBDatabases.Items.Clear()
        For Each item In My.Settings.databaseList
            main.CLBDatabases.Items.Add(New main.MyListBoxItem() With {.Name = item & " - " & worker.getVersion(item).ToString, .ExtraData = item})
        Next
        main.CLBDatabases.Refresh()


        main.PictureBox6.Enabled = True
        main.PictureBox2.Enabled = True
        main.PictureBox3.Enabled = True
        main.PictureBox1.Enabled = True

        'main.Button3.Width = 619
        'main.Button3.Height = 473
        'main.Button3.BringToFront()
        'main.Button3.Top = 3
        'main.Button3.Left = 3
        If Action = 8 Then If My.Settings.autoCheckForUpdate Then main.Button3.PerformClick()
        If Action = 8 And Not connectedToSql Then main.disConnect()
        If Action = 11 Or Action = 3 Or Action = 21 Then main.refreshDBList()
        If Action = 10 Then
            Dim numberOfFiles As Integer = IO.Directory.GetFiles(My.Settings.settingsFolder & "scripts").Length
            If numberOfFiles > 0 Then
                Dim queries As New queries
                queries.MdiParent = main
                queries.Show()
            End If
        End If
        If Action = 20 Then
            Me.Close()
            Dim integ As New Integrity
            integ.MdiParent = main
            integ.RichTextBox1.Text = integrity
            integ.Show()
        End If
        If Not (Action = 10 Or Action = 20) Then
            Dim manage As New management
            manage.MdiParent = main
            manage.Show()
        End If
        My.Settings.loaded = True
        My.Settings.Save()


    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Try
            If e.ProgressPercentage = 1 Then
                main.lblStatus.Text = status
            End If
            If e.ProgressPercentage = 2 Then
                main.CLBDatabases.SetItemChecked(upgrading, False)
                If main.CLBDatabases.CheckedItems.Count = 0 Then
                    main.Button1.Text = "Select All"
                End If
            End If
            If e.ProgressPercentage = 3 Then
                For Each item In worker.log
                    main.lbLog.Items.Add(item)
                Next
                worker.log.Clear()
                main.lbLog.Items.Add(status.ToString)
            End If
            If e.ProgressPercentage = 6 Then
                upgrading = main.CLBDatabases.FindStringExact(thisItem & " - " & worker.getVersion(thisItem))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub


    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    Private Sub checkForUpdate()

        Try
            ' Make a WebClient.
            Dim web_client As WebClient = New WebClient
            ' Download the file.
            web_client.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Upgrade.txt", My.Settings.settingsFolder & "Upgrade.txt")
            web_client.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Buttons.txt", My.Settings.settingsFolder & "patches\after\Buttons.mdb")
            'Dim oldFile As String
            'Dim newFile As String
            'Dim oldVersion As String
            'Dim newVersion As String
            'newFile = My.Settings.settingsFolder & "update folder\management\temp\Upgrade.txt"
            'oldFile = My.Settings.settingsFolder & "update folder\management\Upgrade.txt"

            'If IO.File.Exists(oldFile) Then
            '    If IO.File.Exists(newFile) Then
            '        Dim objReader As New System.IO.StreamReader(oldFile)
            '        Dim versionLine As String = objReader.ReadLine() & vbNewLine
            '        oldVersion = versionLine.Substring(11, 3)
            '        Dim objReader2 As New System.IO.StreamReader(newFile)
            '        Dim versionLine2 As String = objReader2.ReadLine() & vbNewLine
            '        newVersion = versionLine2.Substring(11, 3)
            '        objReader.Close()
            '        objReader.Dispose()
            '        objReader2.Close()
            '        objReader2.Dispose()
            '        IO.File.Copy(newFile, oldFile, True)
            '        If oldVersion < newVersion Then
            '            MsgBox("A new upgrade has been downloaded!", MsgBoxStyle.Information, "Emax Manager")
            '        End If
            '    Else
            '        MsgBox("Problem checking upgrade!")
            '    End If
            'Else
            '    MsgBox("Problem checking upgrade!")
            'End If
        Catch ex As Exception
            MsgBox("Problem checking upgrade!")
        End Try
    End Sub

End Class