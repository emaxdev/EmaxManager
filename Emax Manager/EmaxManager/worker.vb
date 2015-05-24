Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports EmaxManager.main
Imports System.Net
Imports System.IO.Compression

Public Class worker
    Public Shared server As String = ""
    Public Shared username As String = ""
    Public Shared password As String = ""
    Public Shared database As String = ""
    Public Shared myVersion As Double
    Public Shared myScriptList As New List(Of scripts)
    Public Shared scriptArr As String()
    Public Shared versionArr As String()
    Public Shared log As New List(Of String)
    Public Shared backUpFileName As String
    Public Shared latestVersion As Double
    Public Shared integrity As String
    Delegate Sub SetTextCallback(ByVal [text] As String)
    'Public Shared currentVersion As Double = ((worker.getVersion("Emax") * 100) + 1)

    Public Shared Sub refreshSettings()
        My.Settings.Reload()
        server = My.Settings.server
        username = My.Settings.username
        password = My.Settings.password
    End Sub

    Public Shared Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If main.CLBDatabases.CheckedItems.Count > 0 Then
            refreshSettings()
            For Each item As main.MyListBoxItem In main.CLBDatabases.CheckedItems
                database = item.ExtraData.ToString
                If MessageBox.Show("Are you sure you want to execute this script on " & database & "?" & vbCrLf & vbCrLf & "If so please ensure you have taken a backup of your database first.", "Confirm Execute", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    Dim sqlText As String() = CType(CType(sender, System.Windows.Forms.Button).Tag, String())
                    Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
                    Dim conn = New SqlConnection(connStr)


                    Try
                        conn.Open()
                        Dim i As Integer
                        Try
                            For i = 0 To sqlText.Length - 1
                                Dim sqlCmd = New SqlCommand()
                                sqlCmd.Connection = conn
                                sqlCmd.CommandText = sqlText.GetValue(i)
                                sqlCmd.ExecuteNonQuery()
                            Next
                        Finally
                        End Try
                        MsgBox("Script Executed Successfully!!")
                    Catch ex As Exception
                        MsgBox("Something went wrong: " & ex.Message)
                    Finally
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Try
                End If
            Next
        Else
            MsgBox("Please select at least one database", vbInformation, "Select a database")
        End If
    End Sub

    Public Shared Function getVersion(ByVal thisDataBase As String)
        refreshSettings()
        Dim myVersion As Double
        database = thisDataBase
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try


            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim profileSqlText = "SELECT     Version FROM  dbo.System"
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)

            myVersion = CType(sqlCmd5.ExecuteScalar(), Double)

        Catch ex As Exception
            myVersion = 0
        End Try
        Return myVersion
    End Function

    Public Shared Function getSage(ByVal thisDataBase As String)
        refreshSettings()
        Dim mySage As String
        mySage = ""
        database = thisDataBase
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try


            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim profileSqlText = "SELECT     Sage_Username FROM  dbo.System"
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)

            mySage = sqlCmd5.ExecuteScalar().ToString

        Catch ex As Exception
            mySage = ""
        End Try
        Return mySage
    End Function

    Public Shared Function getSQLVersion(ByVal thisDataBase As String)
        refreshSettings()
        Dim myVersion As Double
        database = thisDataBase
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try


            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim profileSqlText = "SELECT SERVERPROPERTY('productversion')"
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)

            myVersion = CType(sqlCmd5.ExecuteScalar(), Double)

        Catch ex As Exception
            MsgBox("Problem getting database version number!")
        End Try
        Return myVersion
    End Function

    Public Shared Function restore(ByVal rstrFile As String, ByVal rstrLoc As String, ByVal databaseName As String)
        refreshSettings()
        Dim sqlString As String
        Dim copyFrom As String = rstrFile
        Dim copyTo As String = rstrLoc
        Dim dataFile As String
        Dim logFile As String
        Dim exists As Boolean
        dataFile = ""
        logFile = ""
        exists = False
        For Each item In My.Settings.databaseList
            If item.Equals(databaseName) Then exists = True
        Next
        If exists Then
            sqlString = "ALTER DATABASE [" & databaseName & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE FILELISTONLY FROM  DISK = N'" & copyFrom & "'"
        Else
            sqlString = "RESTORE FILELISTONLY FROM  DISK = N'" & copyFrom & "'"
        End If
        ' RESTORE DATABASE [" & databaseName & "] FROM  DISK = N'" & copyFrom & "'  WITH  FILE = 1,   MOVE N'Emax-Data' TO N'" & copyTo & "\" & databaseName & ".mdf',   MOVE N'Emax-Data_Log' TO N'" & copyTo & "\" & databaseName & "_1.ldf',  NOUNLOAD,  STATS = 10 "
        'sqlString = "RESTORE DATABASE " & databaseName & " FROM disk='" & rstrFile & "'"
        Dim connStr = "Server=" & server & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Dim sqlCmd = New SqlCommand(sqlString, conn)
        sqlCmd.CommandTimeout = 480   ' number of seconds
        Try
            conn.Open()
            Dim tblInfo As New DataTable()
            Dim dap = New SqlDataAdapter(sqlCmd)

            dap.Fill(tblInfo)
            Dim rowCount As Integer
            For Each row In tblInfo.Rows
                rowCount = rowCount + 1
                If rowCount = 1 Then dataFile = (row(0))
                If rowCount = 2 Then logFile = (row(0))
            Next row
            sqlString = "RESTORE FILELISTONLY FROM  DISK = N'" & copyFrom & "' RESTORE DATABASE [" & databaseName & "] FROM  DISK = N'" & copyFrom & "'  WITH  FILE = 1,   MOVE N'" & dataFile & "' TO N'" & copyTo & "\" & databaseName & ".mdf',   MOVE N'" & logFile & "' TO N'" & copyTo & "\" & databaseName & "_1.ldf',  NOUNLOAD,  STATS = 10 "
            Dim sqlCmd2 = New SqlCommand(sqlString, conn)
            sqlCmd2.CommandTimeout = 48000   ' number of seconds
            sqlCmd2.ExecuteNonQuery()
            database = databaseName
        Catch ex As Exception
            MsgBox("Something went wrong: " & ex.ToString)
            Return False
            Exit Function
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return True
    End Function

    Public Shared Function delete(ByVal databaseName As String)
        refreshSettings()
        Dim sqlString As String

        sqlString = "ALTER DATABASE [" & databaseName & "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; drop database [" & databaseName & "]"
        Dim connStr = "Server=" & server & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Dim sqlCmd = New SqlCommand(sqlString, conn)
        sqlCmd.CommandTimeout = 480   ' number of seconds
        Try
            conn.Open()


            sqlCmd.CommandTimeout = 48000   ' number of seconds
            sqlCmd.ExecuteNonQuery()
            database = databaseName
        Catch ex As Exception
            MsgBox("Something went wrong: Check if database in use!")
            Return False
            Exit Function
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return True
    End Function

    Public Shared Function backUp(ByVal databaseName As String, ByVal location As String, Optional SendToFTP As Boolean = False)
        Dim success As Boolean = False
        refreshSettings()
        Dim sqlString As String
        Dim sqlCheckString As String
        Dim myDate As String
        myDate = Now
        myDate = myDate.Replace("/", "-")
        myDate = myDate.Replace(":", "-")
        backUpFileName = location & "\" & databaseName & " " & myDate & ".bak"
        sqlString = "backup database [" & databaseName & "] to disk='" & backUpFileName & "' with init, checksum;"
        sqlCheckString = "RESTORE VERIFYONLY FROM DISK ='" & location & "\" & databaseName & " " & myDate & ".bak'"
        Dim connStr = "Server=" & server & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Dim sqlCmd = New SqlCommand(sqlString, conn)
        sqlCmd.CommandTimeout = 480   ' number of seconds
        Dim sqlCheckCmd = New SqlCommand(sqlCheckString, conn)
        sqlCheckCmd.CommandTimeout = 480
        Try
            conn.Open()
            sqlCmd.ExecuteNonQuery()
            sqlCheckCmd.ExecuteNonQuery()
            'MsgBox(databaseName & " backed up successfully!")
            success = True
            If SendToFTP Then
                Try
                    If Not Directory.Exists(My.Settings.settingsFolder & "\temp") Then Directory.CreateDirectory(My.Settings.settingsFolder & "\temp")
                    FileCopy(backUpFileName, My.Settings.settingsFolder & "\temp\temp.bak")

                    Dim directoryPath As String = My.Settings.settingsFolder & "\temp"

                    Dim directorySelected As DirectoryInfo = New DirectoryInfo(directoryPath)

                    For Each fileToCompress As FileInfo In directorySelected.GetFiles()
                        Compress(fileToCompress)
                    Next
                Catch ex As Exception
                    MsgBox("Couldn't Send to FTP - " & ex.Message)
                End Try

            End If
        Catch ex As Exception
            MsgBox(databaseName & ": Something went wrong: Check your back-up location!")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return success
    End Function

    Public Shared Function createPlay(ByVal databaseName As String, ByVal location As String)
        Dim success As Boolean = False
        refreshSettings()
        Dim sqlString As String
        Dim sqlCheckString As String
        Dim myDate As String
        myDate = Now
        myDate = myDate.Replace("/", "-")
        myDate = myDate.Replace(":", "-")
        backUpFileName = location & "\" & databaseName & " " & myDate & ".bak"
        sqlString = "backup database [" & databaseName & "] to disk='" & backUpFileName & "' with init, checksum;"
        sqlCheckString = "RESTORE VERIFYONLY FROM DISK ='" & location & "\" & databaseName & " " & myDate & ".bak'"
        Dim connStr = "Server=" & server & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Dim sqlCmd = New SqlCommand(sqlString, conn)
        sqlCmd.CommandTimeout = 480   ' number of seconds
        Dim sqlCheckCmd = New SqlCommand(sqlCheckString, conn)
        sqlCheckCmd.CommandTimeout = 480
        Try
            conn.Open()
            sqlCmd.ExecuteNonQuery()
            sqlCheckCmd.ExecuteNonQuery()
            'MsgBox(databaseName & " backed up successfully!")
            success = True
            
        Catch ex As Exception
            MsgBox(databaseName & ": Something went wrong: Check your back-up location!")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        refreshSettings()

        Dim copyFrom As String = backUpFileName
        Dim copyTo As String = ""
        Dim dataFile As String
        Dim logFile As String
        dataFile = ""
        logFile = ""
        sqlString = "RESTORE FILELISTONLY FROM  DISK = N'" & copyFrom & "'"
        ' RESTORE DATABASE [" & databaseName & "] FROM  DISK = N'" & copyFrom & "'  WITH  FILE = 1,   MOVE N'Emax-Data' TO N'" & copyTo & "\" & databaseName & ".mdf',   MOVE N'Emax-Data_Log' TO N'" & copyTo & "\" & databaseName & "_1.ldf',  NOUNLOAD,  STATS = 10 "
        'sqlString = "RESTORE DATABASE " & databaseName & " FROM disk='" & rstrFile & "'"
        Dim connStr2 = "Server=" & server & ";UID=" & username & ";PWD=" & password & ""
        Dim conn2 = New SqlConnection(connStr2)
        Dim sqlCmd2 = New SqlCommand(sqlString, conn2)
        sqlCmd2.CommandTimeout = 480   ' number of seconds
        Try
            conn2.Open()
            Dim tblInfo As New DataTable()
            Dim dap = New SqlDataAdapter(sqlCmd2)

            dap.Fill(tblInfo)
            Dim rowCount As Integer
            For Each row In tblInfo.Rows
                rowCount = rowCount + 1
                If rowCount = 1 Then
                    dataFile = (row(0))
                    copyTo = (row(1))
                    copyTo = copyTo.Substring(0, copyTo.LastIndexOf("\")) & "\" & dataFile & "-Play"
                End If
                If Not Directory.Exists(copyTo) Then Directory.CreateDirectory(copyTo)
                If rowCount = 2 Then logFile = (row(0))
            Next row
  
            sqlString = "RESTORE FILELISTONLY FROM  DISK = N'" & copyFrom & "' RESTORE DATABASE [" & databaseName & " - Play] FROM  DISK = N'" & copyFrom & "'  WITH  FILE = 1,   MOVE N'" & dataFile & "' TO N'" & copyTo & "\" & databaseName & ".mdf',   MOVE N'" & logFile & "' TO N'" & copyTo & "\" & databaseName & "_1.ldf',  NOUNLOAD,  STATS = 10 "
            Dim conn3 = New SqlConnection(connStr2)
            Dim sqlCmd3 = New SqlCommand(sqlString, conn3)
            sqlCmd3.CommandTimeout = 48000   ' number of seconds
            conn3.Open()
            sqlCmd3.ExecuteNonQuery()
            database = databaseName & " - Play"
            setPlay()
        Catch ex As Exception
            MsgBox("Something went wrong: " & ex.ToString)
            Return False
            Exit Function
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return True
    End Function

    Public Shared Function setVersion(version As Double)
        refreshSettings()
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try
            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim updateVersion = Int(version)
            Dim profileSqlText = "UPDATE    System SET Version = " & (latestVersion / 100)
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)

            myVersion = CType(sqlCmd5.ExecuteScalar(), Double)

        Catch ex As Exception
            MsgBox("Problem")
        End Try
        'Dim connStr2 = "Server= 88.208.221.143;Database= SmartTask;UID=" & username & ";PWD=" & password & ""
        'Dim conn2 = New SqlConnection(connStr2)
        'Try
        '    conn2.Open()
        '    Dim profileSqlText = "UPDATE tblUsers set Username = 'Alan2' where PK_User_ID = 5 "
        '    Dim sqlCmd5 = New SqlCommand(profileSqlText, conn2)

        '    sqlCmd5.ExecuteNonQuery()

        'Catch ex As Exception
        '    MsgBox("Problem")
        'End Try
        Return myVersion
    End Function

    Public Shared Sub rename(nameFrom As String, nameTo As String)
        refreshSettings()
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try
            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim profileSqlText = "ALTER database '" & nameFrom & "' MODIFY NAME = '" & nameTo & "'"
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)

            sqlCmd5.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Problem")
        End Try
    End Sub

    Public Shared Sub setVersionExternal(version As Double)
        refreshSettings()
        Dim connStr = "Server=AL-PC\EMAX;Database=2;UID=sa;PWD=sqllogin1"
        Dim conn = New SqlConnection(connStr)
        Try
            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim updateVersion = Int(version)
            Dim profileSqlText = "update COMPANYS set town = '" & (version / 100) & "' where Name = '" & My.Settings.companyName & "'"
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)
            sqlCmd5.ExecuteNonQuery()

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function setPlay()
        refreshSettings()
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try
            conn.Open()
            Dim profileSqlText = "UPDATE    SY_Passwords SET  Password = '|gp~'"
            Dim sqlCmd = New SqlCommand(profileSqlText, conn)
            sqlCmd.ExecuteNonQuery()

            profileSqlText = "UPDATE System SET Company_Name = 'Play Play Play'"
            Dim sqlCmd2 = New SqlCommand(profileSqlText, conn)
            sqlCmd2.ExecuteNonQuery()

            profileSqlText = "UPDATE System SET Play_Database = 'True'"
            Dim sqlCmd3 = New SqlCommand(profileSqlText, conn)
            sqlCmd3.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Problem")
        End Try
        Return myVersion
    End Function

    Public Shared Function newupgrade(ByVal database As String)
        Dim success As Boolean = False
        Dim currentVersion As Double
        Dim connstr As String
        Dim runCount As Integer = 0
        Dim upgradeFile As String

        'Clear variables
        'log.Clear()
        connstr = ""
        'Location of main upgrade folder is set in system settings
        upgradeFile = My.Settings.settingsFolder & "Upgrade.txt"

        'Get current version of database
        currentVersion = (worker.getVersion(database) * 100)

        Dim objReader As New System.IO.StreamReader(upgradeFile)
        Dim versionLine As String = objReader.ReadLine() & vbNewLine

        latestVersion = versionLine.Substring(11, 3)
        Dim buttonDetails As String = ""
        Dim integrityDetails As String = ""
        If currentVersion < latestVersion Then
            If Not IO.File.Exists(upgradeFile) Then
                MsgBox("Upgrade file not present.")
                success = False
                GoTo UpdateError
            Else
                Dim sqlFile As String = ""
                Dim scriptDescription As String = ""
                Dim scriptDetails As String = ""

                Try
                    scriptDetails = File.ReadAllText(upgradeFile)
                    Dim stringToFind As String = ""
                    Dim position As Integer
                    Dim scriptsStart As Integer = InStr(scriptDetails, "--Version " & currentVersion + 1)
                    Dim scriptsEnd As Integer = InStr(scriptDetails, "--Scripts End")
                    Dim buttonsStart As Integer = InStr(scriptDetails, "--Buttons Start")
                    Dim buttonsEnd As Integer = InStr(scriptDetails, "--Buttons End")
                    Dim integrityStart As Integer = InStr(scriptDetails, "--Integrity Start")
                    Dim integrityEnd As Integer = InStr(scriptDetails, "--Integrity End")

                    If buttonsStart > 0 Then buttonDetails = scriptDetails.Substring(buttonsStart - 2, buttonsEnd - buttonsStart - 2)
                    If integrityStart > 0 Then integrityDetails = scriptDetails.Substring(integrityStart - 2, integrityEnd - integrityStart - 2)
                    scriptDetails = scriptDetails.Substring(scriptsStart - 2, scriptsEnd - scriptsStart)





                    scriptDetails = Replace(scriptDetails, "--", ";")
                    versionArr = scriptDetails.Split(";")
                    'Dim sr As StreamReader = New StreamReader(sqlFile)

                    For Each item In versionArr
                        If item.Contains("Ver") Then
                            Dim myScript As New scripts
                            stringToFind = ".sql"
                            position = InStr(item, stringToFind)
                            myScript.scriptName = item.Substring(0, position + 3)
                            Dim restOfLine As String
                            restOfLine = item.Substring(position + 3, item.Length - (position + 3))
                            Dim temp As String = ""
                            temp = Regex.Replace(restOfLine, "\bGO\b", ";")
                            scriptArr = temp.Split(";")
                            myScript.scripts = scriptArr
                            myScriptList.Add(myScript)
                        End If
                    Next

                Catch ex As Exception
                    MsgBox("Error" & ex.ToString)
                    success = False
                    GoTo UpdateError
                Finally
                    Array.Clear(versionArr, versionArr.GetLowerBound(0), versionArr.Length)
                End Try
                Try

                    For Each script In myScriptList
                        'settext(script.scriptName)
                        If My.Settings.dontRunViews Then
                            If script.scriptName.ToUpper.Contains("VIEWS.SQL") Or script.scriptName.ToUpper.Contains("DROP_VIEWS.SQL") Then
                                MsgBox("Skipping - " & script.scriptName)
                                GoTo skipscript
                            End If
                        End If
                        runCount = 0
                        Dim sqlText As String() = script.scripts
                        connstr = "Server=" & server & ";Database=" & database.ToString & ";UID=" & username & ";PWD=" & password & ""
                        Dim conn = New SqlConnection(connstr)
                        conn.Open()
                        Dim rerunList As New List(Of String)

                        Dim i As Integer
                        For i = 0 To sqlText.Length - 1
                            Dim sqlCmd = New SqlCommand()
                            sqlCmd.Connection = conn
                            sqlCmd.CommandText = sqlText.GetValue(i)
                            Try
                                main.lblStatus.Text = script.scriptName
                                If sqlCmd.CommandText > "" Then sqlCmd.ExecuteNonQuery()
                            Catch ex As Exception
                                rerunList.Add(sqlCmd.CommandText)
                            End Try
                        Next
                        Dim rerunErrors As New List(Of String)
                        Do While rerunList.Count > 0
                            runCount = runCount + 1
                            If runCount < 11 Then
                                Dim tempRerunList As New List(Of String)
                                For Each item In rerunList
                                    Dim sqlCmd = New SqlCommand()
                                    sqlCmd.Connection = conn
                                    sqlCmd.CommandText = item
                                    Try
                                        sqlCmd.ExecuteNonQuery()
                                    Catch ex As Exception
                                        tempRerunList.Add(item)
                                        If runCount = 10 Then
                                            rerunErrors.Add(script.scriptName)
                                        End If
                                    End Try
                                Next
                                rerunList.Clear()
                                rerunList.AddRange(tempRerunList)
                                tempRerunList.Clear()
                            Else
                                log.Add(database & " - " & script.scriptDescription & " failed")
                                For Each item In rerunErrors
                                    MsgBox("Script failed " & item)
                                Next
                                success = False
                                GoTo UpdateError
                            End If
                        Loop
                        rerunList.Clear()

                        log.Add(database & " - " & script.scriptName & " successfull")
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
skipscript:
                    Next

                Catch ex As Exception
                    MsgBox(ex.ToString)
                    success = False
                Finally
                    myScriptList.Clear()
                End Try
            End If
            
            If buttonDetails > "" Then
                If fixButtons(buttonDetails) Then
                    log.Add(database & " - updating buttons successfull")
                Else
                    log.Add(database & " - updating buttons failed")
                    GoTo updateError
                End If
            Else
                Try
                    Dim DestConString As String
                    DestConString = "Provider=SQLOLEDB.1;Password=" + My.Settings.password + ";Persist Security Info=True;User ID=" + My.Settings.username + ";Initial Catalog=" + database + ";Data Source=" + My.Settings.server
                    Dim strfilename As String
                    strfilename = My.Settings.settingsFolder & "patches\after\wait.txt"
                    If Not File.Exists(strfilename) Then
                        Dim theFile As FileStream = File.Create(strfilename)
                        theFile.Close()
                    End If
                    Do While IO.File.Exists(strfilename)
                        If System.IO.File.Exists(My.Settings.settingsFolder & "patches\after\buttons.exe") Then
                            Shell(My.Settings.settingsFolder & "patches\after\buttons.exe" & " " & DestConString, vbNormalFocus)
                        Else
                            MsgBox("Cannot update buttons!")
                            GoTo updateError
                        End If
                    Loop
                    log.Add(database & " - updating buttons successfull")
                Catch ex As Exception
                    log.Add(database & " - updating buttons failed")
                    GoTo updateError
                End Try
            End If

            Try
                worker.setVersion(latestVersion)
                log.Add(database & " - updating version successfull")
            Catch ex As Exception
                log.Add(database & " - updating version failed")
                success = False
                GoTo updateError
            End Try
            'Try
            '    worker.setVersionExternal(latestVersion)
            'Catch ex As Exception

            'End Try

            'Try

            'Catch ex As Exception
            '    log.Add(database & " - view verification failed")
            '    success = False
            '    GoTo updateError
            'End Try
            log.Add(database & " upgraded successfully")
            success = True
        Else
            MsgBox(database.ToString & ": You appear to be up to date!!")
        End If
        Return success
UpdateError:
        Return success
    End Function

    Public Shared Function fixButtons(buttonDetails As String) As Boolean
        Try
            Dim connstr As String = "Server=" & server & ";Database=" & database.ToString & ";UID=" & username & ";PWD=" & password & ""
            Dim conn = New SqlConnection(connstr)
            conn.Open()
            Dim sqlCmd = New SqlCommand()
            sqlCmd.Connection = conn

            sqlCmd.CommandText = "Delete from buttons"
            sqlCmd.ExecuteNonQuery()

            Dim sr As StringReader = New StringReader(Replace(buttonDetails, "'", "''"))
            Dim button() As String
            Do While sr.Peek() >= 0
                button = Split(sr.ReadLine(), ",")
                sqlCmd.CommandText = "SET IDENTITY_INSERT buttons ON INSERT INTO Buttons (AddNew, [Button id], [Category Name], [Group], HideMe, Icon, [Order], ShortCut, Text) VALUES (" & IIf(button(0) = "FALSE", 0, 1) & "," & button(1) & ",'" & button(2) & "'," & button(3) & "," & IIf(button(4) = "FALSE", 0, 1) & ",'" & button(5) & "'," & button(6) & "," & button(7) & ",'" & button(8) & "')"
                sqlCmd.ExecuteNonQuery()

                Dim objConn As New SqlConnection(connstr)
                objConn.Open()

                Dim da As New SqlDataAdapter("SELECT User_ID from sy_passwords", objConn)
                Dim dr As DataRow
                Dim dataset As New DataSet()
                Dim datatable As DataTable
                da.Fill(dataset)
                datatable = dataset.Tables(0)

                For Each dr In datatable.Rows
                    sqlCmd.CommandText = "if not exists(select [User id] from User_Buttons where [Button Id] = " & button(1) & " and [User id] = " & dr(0) & ") insert into User_Buttons ([Button Id],[User id],visible) values (" & button(1) & "," & dr(0) & ",1)"
                    sqlCmd.ExecuteNonQuery()
                Next
            Loop

        Catch ex As Exception
            fixButtons = False
            MsgBox(ex.Message)
        End Try
      
        fixButtons = True

    End Function

    Public Shared Function copyExeEtc()
        Dim success As Boolean
        success = False
        Try
            If File.Exists(My.Settings.settingsFolder & "Emax Systems.exe") And File.Exists(My.Settings.settingsFolder & "RM6_Server.dll") Then
                If My.Settings.updateFolder & "update folder" > "" And File.Exists(My.Settings.updateFolder & "update folder\Emax Systems.exe") And File.Exists(My.Settings.updateFolder & "update folder\RM6_Server.dll") Then
                    If Not IO.Directory.Exists(My.Settings.updateFolder & "update folder\old\") Then IO.Directory.CreateDirectory(My.Settings.updateFolder & "update folder\old\")
                    File.Copy(My.Settings.updateFolder & "update folder\Emax Systems.exe", My.Settings.updateFolder & "update folder\old\Emax Systems.exe", True)
                    File.Copy(My.Settings.updateFolder & "update folder\RM6_Server.dll", My.Settings.updateFolder & "update folder\old\RM6_Server.dll", True)
                Else
                    MsgBox("Problem with update folder!")
                    Return success
                    Exit Function
                End If
                Dim myExeTime As Date = File.GetCreationTime(My.Settings.settingsFolder & "Emax Systems.exe")
                Dim myDllTime As Date = File.GetCreationTime(My.Settings.settingsFolder & "RM6_Server.dll")
                File.Copy(My.Settings.settingsFolder & "Emax Systems.exe", My.Settings.updateFolder & "update folder\Emax Systems.exe", True)
                File.Copy(My.Settings.settingsFolder & "RM6_Server.dll", My.Settings.updateFolder & "update folder\RM6_Server.dll", True)
                File.SetCreationTime(My.Settings.updateFolder & "update folder\Emax Systems.exe", myExeTime)
                File.SetCreationTime(My.Settings.updateFolder & "update folder\RM6_Server.dll", myDllTime)
            Else
                MsgBox("Files did not copy from Web!")
                Return success
                Exit Function
            End If
            success = True
        Catch ex As Exception
            MsgBox("File copy error!")
        End Try
        Try
            If File.Exists(My.Settings.settingsFolder & "changes.doc") Then
                If File.Exists(My.Settings.updateFolder & "changes.doc") Then
                    If Not IO.Directory.Exists(My.Settings.updateFolder & "Old\") Then IO.Directory.CreateDirectory(My.Settings.updateFolder & "Old\")
                    File.Copy(My.Settings.updateFolder & "changes.doc", My.Settings.updateFolder & "Old\changes.doc", True)
                End If
                File.Copy(My.Settings.settingsFolder & "changes.doc", My.Settings.updateFolder & "changes.doc", True)
            End If
        Catch ex As Exception
            MsgBox("Could not copy changes document!", vbInformation, "Changes Doc")
        End Try
        Return success
    End Function

    Public Shared Function newStyle()
        Dim success As Boolean
        success = False
        Try
            If File.Exists(My.Settings.settingsFolder & "Get_New_Version_New.exe") And File.Exists(My.Settings.settingsFolder & "NewFilelist.txt") Then
                If Not IO.Directory.Exists(My.Settings.updateFolder & "update folder") Then
                    MsgBox("Problem with update folder!")
                    Return success
                    Exit Function
                End If

                File.Copy(My.Settings.settingsFolder & "Get_New_Version_New.exe", My.Settings.updateFolder & "update folder\Get_New_Version_New.exe", True)
                File.Copy(My.Settings.settingsFolder & "NewFilelist.txt", My.Settings.updateFolder & "update folder\NewFilelist.mdb", True)
               
                Try
                    For Each item In My.Settings.databaseList
                        database = item
                        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
                        Dim conn = New SqlConnection(connStr)
                        conn.Open()
                        Dim profileSqlText = "update SY_Passwords set Style_Index = 5 where Style_Index = 0 or Style_Index is null"
                        Dim sqlCmd = New SqlCommand(profileSqlText, conn)
                        sqlCmd.ExecuteNonQuery()
                        conn.Close()
                        conn.Dispose()
                    Next
                    
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("Files did not copy from Web!")
                Return success
                Exit Function
            End If
            success = True
        Catch ex As Exception
            MsgBox("File copy error!")
        End Try
        
        Return success
    End Function

    Public Shared Sub sendFileToFTP(filePath As String, fileName As String)

        Dim bytesread As Integer = 0
        Dim buffer As Integer = 8100

        Dim fRequest As FtpWebRequest = WebRequest.Create("ftp://dataorigins.com/" & fileName)
        fRequest.Credentials = New NetworkCredential("administrator", "X5j4k1M0")
        fRequest.KeepAlive = False
        fRequest.Proxy = Nothing
        fRequest.UsePassive = True
        fRequest.UseBinary = False
        fRequest.Method = WebRequestMethods.Ftp.UploadFile
        fRequest.Timeout = 180000

        Try
            ' read in file...
            'Dim reader As New StreamReader(fileItem)
            Dim fs As FileStream = File.OpenRead(filePath)
            Dim length As Long
            length = fs.Length
            Dim bFile As Byte() = New Byte(8100) {}
            Dim fstream As Stream = fRequest.GetRequestStream
            ' upload file...
            Do
                bytesread = fs.Read(bFile, 0, buffer)
                fs.Read(bFile, 0, buffer)
                fstream.Write(bFile, 0, bFile.Length)
            Loop Until bytesread = 0
            fstream.Close()
            fstream.Dispose()

        Catch ex As Exception
           
        End Try

    End Sub

    Public Shared Sub Compress(ByVal fileToCompress As FileInfo)
        Using originalFileStream As FileStream = fileToCompress.OpenRead()
            If (File.GetAttributes(fileToCompress.FullName) And FileAttributes.Hidden) <> FileAttributes.Hidden And fileToCompress.Extension <> ".gz" Then
                Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName + ".gz")
                    Using compressionStream As GZipStream = New GZipStream(compressedFileStream, CompressionMode.Compress)
                        originalFileStream.CopyTo(compressionStream)
                        Console.WriteLine("Compressed {0} from {1} to {2} bytes.", _
                                          fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString())
                    End Using
                End Using
            End If
        End Using
    End Sub

    Public Shared Function checkIntegrity(ByVal database As String) As String
        Dim version As Double
        Dim filename As String
        Dim lineArray As String()
        integrity = "Integrity Check Results for " & database & vbCr & vbCr
        version = getVersion(database)
        filename = My.Settings.settingsFolder & "Emax-Integrity" & version & ".csv"
        Dim sConnectionString As String
        sConnectionString = "Password= " & password & ";User ID=" & username & ";" & _
                            "Initial Catalog= " & database & ";" & _
                            "Data Source=" & server & ""

        Try
            Dim web_client2 As WebClient = New WebClient
            web_client2.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Emax-Integrity" & version & ".csv", filename)
        Catch ex As Exception
            checkIntegrity = "Integrity check currently unavailable!"
            Exit Function
        End Try


        Dim objConn As New SqlConnection(sConnectionString)
        objConn.Open()

        Dim da As New SqlDataAdapter("SELECT      c.TABLE_NAME,c.COLUMN_NAME FROM        INFORMATION_SCHEMA.COLUMNS AS c INNER JOIN  INFORMATION_SCHEMA.TABLES AS t ON t.TABLE_CATALOG = c.TABLE_CATALOG AND t.TABLE_SCHEMA = c.TABLE_SCHEMA AND t.TABLE_NAME = c.TABLE_NAME AND t.TABLE_TYPE = 'BASE TABLE' order by c.TABLE_NAME,c.ORDINAL_POSITION", objConn)
        Dim dr As DataRow
        Dim dataset As New DataSet()
        Dim datatable As DataTable
        da.Fill(dataset)
        datatable = dataset.Tables(0)
        Dim sr As New StreamReader(filename)
        Dim lineCount As Integer = 0

        Dim FILE_NAME As String = My.Settings.settingsFolder & "patches\" & "Integrity.csv"



        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, False)

        For Each dr In datatable.Rows
            If Not sr.EndOfStream Then
                lineArray = sr.ReadLine().Split(","c)
                lineCount += 1
                objWriter.WriteLine(lineArray(0).Trim() & "," & lineArray(1).Trim() & "," & dr(0) & "," & dr(1))
                If Not lineArray(1).Trim().Equals(dr(1)) Then
                    If Not InStr(integrity, "Problem with table") > 0 Then integrity += "Problem with table " & " - " & lineArray(0).Trim() & vbCrLf
                End If
            End If
        Next

        objWriter.Close()


        If InStr(integrity, "Problem") > 0 Then
            integrity += "Check integrity file."
        Else
            integrity += "Table Integrity OK."
        End If
        integrity += vbCrLf & vbCrLf
        integrity += "Crashed PO Lines: " & getCount(database, "SELECT  COUNT(dbo.Po_Lines.Po_Lines_ID) AS Count FROM dbo.Po_Lines INNER JOIN dbo.Purchase_Order ON dbo.Po_Lines.Po__PO_ID = dbo.Purchase_Order.Purchase_Order_ID GROUP BY dbo.Purchase_Order.Po_No HAVING        (dbo.Purchase_Order.Po_No IS NULL)")


exitNow:
        checkIntegrity = integrity
    End Function

    Public Shared Function darkLight(r, b, g) As Color
        Dim a As Integer
        a = 1 - (0.299 * r + 0.0587 + g + 0.114 * b) / 255
        If (a < 0.05) Then darkLight = Color.Black Else darkLight = Color.White
    End Function

    Public Shared Function getCount(ByVal thisDataBase As String, query As String)
        refreshSettings()
        Dim count As Double
        database = thisDataBase
        Dim connStr = "Server=" & server & ";Database=" & database & ";UID=" & username & ";PWD=" & password & ""
        Dim conn = New SqlConnection(connStr)
        Try


            conn.Open()
            Dim dTypeIdentity As Integer = -1
            Dim profileSqlText = query
            Dim sqlCmd5 = New SqlCommand(profileSqlText, conn)

            count = CType(sqlCmd5.ExecuteScalar(), Double)

        Catch ex As Exception
            count = 0
        End Try
        Return count
    End Function

    'Commented Out 10/10/2013
    'Public Shared Sub settext(ByVal txt As String)
    '    If main.lblStatus.InvokeRequired Then
    '        Dim d As New SetTextCallback(AddressOf settext)
    '        main.Invoke(d, New Object() {txt})
    '    Else
    '        main.lblStatus.Text = txt
    '        Application.DoEvents()
    '    End If
    'End Sub
End Class
