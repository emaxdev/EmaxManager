﻿Imports System.Data.SqlClient
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
            Dim profileSqlText = "UPDATE    System SET Version = " & (version / 100)
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
        Dim upgradeFile As String = ""

        'Clear variables
        'log.Clear()
        connstr = ""
        'Location of main upgrade folder is set in system settings

        If My.Settings.upgradeFileLocation > "" Then
            If IO.File.Exists(My.Settings.upgradeFileLocation) Then
                upgradeFile = My.Settings.upgradeFileLocation
            End If
        Else
            If IO.File.Exists(My.Settings.settingsFolder & "Upgrade.txt") Then
                upgradeFile = My.Settings.settingsFolder & "Upgrade.txt"
            End If
        End If
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

                Catch ex As Exception

                End Try
                scriptDetails = File.ReadAllText(upgradeFile)
                Dim stringToFind As String = ""
                Dim position As Integer

                buttonDetails = getTextBetweenComments(scriptDetails, "--Buttons Start", "--Buttons End", False)
                integrityDetails = getTextBetweenComments(scriptDetails, "--Integrity Start", "--Integrity End", False)
                scriptDetails = getTextBetweenComments(scriptDetails, "--Version " & currentVersion + 1, "--Scripts End", True)

                If Not scriptDetails > "" Then
                    MsgBox("Problem  with upgrade file.")
                    success = False
                    GoTo UpdateError
                End If

                scriptDetails = Replace(scriptDetails, "--", ";")
                versionArr = scriptDetails.Split(";")
                Try

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
                    Try
                        worker.setVersion(99999)
                    Catch ex As Exception

                    End Try

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

            Dim integrityResult As String = ""
            main.integrityResult = ""
            integrityResult = checkIntegrity(database)
            If Not integrityResult.Contains("Critical") Then
                log.Add(database & " - integrity successfull")
            Else
                log.Add(database & " - intrgrity failed")
                main.integrityResult = integrityResult
                GoTo updateError
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

    Public Shared Function getTextBetweenComments(searchText As String, startText As String, endText As String, includeStart As Boolean) As String
        Dim startPos As Integer
        Dim endPos As Integer
        If includeStart Then startPos = InStr(searchText, startText) Else startPos = InStr(searchText, startText) + Len(startText)
        endPos = InStr(searchText, endText)
        If startPos > 0 And endPos > 0 Then
            getTextBetweenComments = searchText.Substring(startPos, endPos - startPos - 4)
        Else
            getTextBetweenComments = ""
        End If

        Do While getTextBetweenComments.StartsWith(" ") Or getTextBetweenComments.StartsWith(vbCr) Or getTextBetweenComments.StartsWith(vbLf)
            getTextBetweenComments = getTextBetweenComments.Substring(1)
            getTextBetweenComments = Trim(getTextBetweenComments)
        Loop

        Do While getTextBetweenComments.EndsWith(" ") Or getTextBetweenComments.EndsWith(vbCr) Or getTextBetweenComments.EndsWith(vbLf)
            getTextBetweenComments = getTextBetweenComments.Substring(0, Len(getTextBetweenComments) - 1)
            getTextBetweenComments = Trim(getTextBetweenComments)
        Loop

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
        Dim integrityInfo As String
        If My.Settings.upgradeFileLocation > "" Then
            integrityInfo = File.ReadAllText(My.Settings.upgradeFileLocation)
        Else
            integrityInfo = File.ReadAllText(My.Settings.settingsFolder & "Upgrade.txt")
        End If

        integrityInfo = worker.getTextBetweenComments(integrityInfo, "--Integrity Start", "--Integrity End", False)
        If Not integrityInfo > "" Then checkIntegrity = "No integrity info available" : Exit Function
        integrityInfo = Replace(integrityInfo, "--Integrity Start", "")
        

        'Dim filename As String
        Dim lineArray As String()
        checkIntegrity = "Integrity Check Results for " & database & vbCr & vbCr
        Dim sConnectionString As String
        sConnectionString = "Password= " & password & ";User ID=" & username & ";" & _
                            "Initial Catalog= " & database & ";" & _
                            "Data Source=" & server & ""

        'Try
        '    Dim web_client2 As WebClient = New WebClient
        '    web_client2.DownloadFile("http://software.emax-systems.co.uk/downloads/Manager/Emax-Integrity" & version & ".csv", filename)
        'Catch ex As Exception
        '    checkIntegrity = "Integrity check currently unavailable!"
        '    Exit Function
        'End Try


        Dim objConn As New SqlConnection(sConnectionString)
        objConn.Open()

        Dim da As New SqlDataAdapter("SELECT      c.TABLE_NAME,c.COLUMN_NAME FROM        INFORMATION_SCHEMA.COLUMNS AS c INNER JOIN  INFORMATION_SCHEMA.TABLES AS t ON t.TABLE_CATALOG = c.TABLE_CATALOG AND t.TABLE_SCHEMA = c.TABLE_SCHEMA AND t.TABLE_NAME = c.TABLE_NAME AND t.TABLE_TYPE = 'BASE TABLE' order by c.TABLE_NAME,c.ORDINAL_POSITION", objConn)
        Dim dr As DataRow
        Dim dataset As New DataSet()
        Dim datatable As DataTable
        da.Fill(dataset)
        datatable = dataset.Tables(0)
        Dim sr As New StringReader(integrityInfo)
        Dim lineCount As Integer = 0

        'Dim FILE_NAME As String = My.Settings.settingsFolder & "patches\" & "Integrity.csv"

        Dim mainDBTables As New Dictionary(Of String, String)
        Dim thisDBTables As New Dictionary(Of String, String)
        Dim mainDBTableFields As New Dictionary(Of String, String)
        Dim thisDBTableFields As New Dictionary(Of String, String)

        For Each dr In datatable.Rows
            If Not thisDBTables.ContainsValue(dr(0).ToString) Then thisDBTables.Add(dr(0).ToString, dr(0).ToString)
        Next

        Do While sr.Peek > 0
            lineArray = sr.ReadLine().Split(","c)
            If lineArray(0).Trim() > "" Then If Not mainDBTables.ContainsValue(lineArray(0).Trim()) Then mainDBTables.Add(lineArray(0).Trim(), lineArray(0).Trim())
        Loop

        For Each pair In mainDBTables
            If Not thisDBTables.ContainsKey(pair.Key) Then
                checkIntegrity += "Critical - Table exists in main but is missing from local - " & pair.Key & vbCrLf
            Else
                mainDBTableFields.Clear()
                thisDBTableFields.Clear()
                For Each dr In datatable.Rows
                    If dr(0).Equals(pair.Key) Then thisDBTableFields.Add(dr(1), dr(1))
                Next
                Dim sr2 As New StringReader(integrityInfo)
                Do While sr2.Peek > 0
                    lineArray = sr2.ReadLine().Split(","c)
                    If lineArray(0).Equals(pair.Key) Then mainDBTableFields.Add(lineArray(1), lineArray(1))
                Loop

                For Each pair2 In mainDBTableFields
                    Dim found As Boolean = False
                    For Each pair3 In thisDBTableFields
                        If pair2.Value = pair3.Value Then found = True : Exit For
                    Next
                    If Not found Then
                        checkIntegrity += "Critical - Field exists in main but is missing from local - " & pair.Value & " - " & pair2.Value & vbCrLf
                    End If

                Next

                For Each pair4 In thisDBTableFields
                    Dim found As Boolean = False
                    For Each pair5 In mainDBTableFields
                        If pair4.Value = pair5.Value Then found = True : Exit For
                    Next
                    If Not found Then
                        checkIntegrity += "Critical - Field exists in local but is missing from main - " & pair.Value & " - " & pair4.Value & vbCrLf
                    End If

                Next

            End If
        Next

        For Each pair In thisDBTables
            If Not mainDBTables.ContainsKey(pair.Key) Then checkIntegrity += "Table exists in this DB but is missing from this main DB - " & pair.Key & vbCrLf
        Next

        



        If Not InStr(checkIntegrity, "Critical") > 0 Then
            checkIntegrity += vbCrLf & "Table Integrity OK."
        End If
        'checkIntegrity += vbCrLf
        'checkIntegrity += "Crashed PO Lines: " & getCount(database, "SELECT  COUNT(dbo.Po_Lines.Po_Lines_ID) AS Count FROM dbo.Po_Lines INNER JOIN dbo.Purchase_Order ON dbo.Po_Lines.Po__PO_ID = dbo.Purchase_Order.Purchase_Order_ID GROUP BY dbo.Purchase_Order.Po_No HAVING        (dbo.Purchase_Order.Po_No IS NULL)")


exitNow:

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

End Class
