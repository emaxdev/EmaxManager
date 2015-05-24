Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Security.AccessControl

Public Class main
    Const VERSION As Integer = 7
    Dim server As String = ""
    Dim username As String = ""
    Dim password As String = ""
    Dim database As String = ""
    Public Shared connected As Boolean
    Public force As Boolean
    Public fileToDelete As String
    Public screensTop As Integer = 6
    Public screenLeft As Integer = 227
    Public currentProcess As Integer
    Public Shared newFileName As String
    Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim response As MsgBoxResult
        'If force Then
        '    response = vbYes
        'Else
        '    response = MsgBox("Do you want to close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")
        'End If
        'If response = MsgBoxResult.Yes Then

        'ElseIf response = MsgBoxResult.No Then
        '    e.Cancel = True
        '    Exit Sub
        'End If
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim serverConnect As New serverConnect
        serverConnect.MdiParent = DirectCast(Me, main)
        serverConnect.Show()
        lblStatus.Text = ""
    End Sub

    Private Sub main_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Panel4.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not My.Settings.R > "" Then My.Settings.R = "37" : My.Settings.Save()
            If Not My.Settings.B > "" Then My.Settings.B = "172" : My.Settings.Save()
            If Not My.Settings.G > "" Then My.Settings.G = "211" : My.Settings.Save()
            Panel4.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
            headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
            Label1.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
            My.Settings.Reload()
            setupTooltips()
            Me.BackColor = Color.White
            Me.MaximizeBox = False
            If Not IsNothing(My.Settings.checkedDatabases) Then
                My.Settings.checkedDatabases.Clear()
            End If
            If Not IsNothing(My.Settings.log) Then
                My.Settings.log.Clear()
            End If
            Try
                'If My.Settings.remember Then
                '    Dim backingUp As New backingUp(8)
                '    backingUp.MdiParent = Me
                '    backingUp.Show()
                'Else
                Dim serverConnect As New serverConnect
                serverConnect.MdiParent = DirectCast(Me, main)
                serverConnect.Show()
                'End If
            Catch ex As Exception
                If Not lblStatus.Text <> "" Then
                    pnlWelcome.Visible = False
                    Dim serverConnect As New serverConnect
                    serverConnect.MdiParent = DirectCast(Me, main)
                    serverConnect.Show()
                End If
            End Try
            If UCase(My.Settings.server) = "MARTYN-PC\EMAX2012" Or UCase(My.Settings.server) = "ALAN\SQL2012" Then
                PictureBox7.Visible = True
                CLBDatabases.Height = 256
            End If
            chkHide.Checked = My.Settings.hideDisclaimer
            If My.Settings.hideDisclaimer Then
                panelWelcome2.Visible = False
            Else
                panelWelcome2.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        My.Settings.loaded = False
        My.Settings.Save()
    End Sub

    Public Sub setupTooltips()
        ToolTip1.SetToolTip(Me.PictureBox1, "Connect")
        ToolTip1.SetToolTip(Me.PictureBox2, "Disconnect")
        ToolTip1.SetToolTip(Me.PictureBox3, "Refresh Databases")
        ToolTip1.SetToolTip(Me.PictureBox6, "Settings")
    End Sub

    Public Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub disConnect()
        pnlWelcome.Visible = True
        Dim serverConnect As New serverConnect
        serverConnect.MdiParent = DirectCast(Me, main)
        serverConnect.Show()
        lblStatus.Text = ""
        CLBDatabases.Items.Clear()
        My.Settings.checkedDatabases.Clear()
        connected = False
        Button2.Visible = False
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      

    End Sub

    Public Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Public Sub refreshDBList()
        If connected Then
            Dim backingUp As New backingUp(8)
            backingUp.MdiParent = Me
            backingUp.Show()
        End If
    End Sub

    Public Sub LoadDatabases()
        CLBDatabases.Items.Clear()
        Try
            Dim mySQLConnection As New mySQLConnection

            If mySQLConnection.OpenConnection("Server=" & server & ";Database=Master;UID=" & username & ";PWD=" & password) = False Then
                MsgBox("Error connection to SQL Server", MsgBoxStyle.Exclamation, "Load Databases")
                Exit Sub
            End If

            Dim strSQL = "create table #t (DBName sysname not null) exec sp_msforeachdb 'use [?]; if OBJECT_ID(''dbo.system'') is not null AND OBJECT_ID(''dbo.part'') is not null AND OBJECT_ID(''dbo.Bom'') is not null insert into #t (DBName) select ''?''' select * from #t drop table #t"

            If mySQLConnection.ReadData(strSQL) = True Then
                While mySQLConnection.myDataReader.Read
                    'CLBDatabases.Items.Add(mySQLConnection.myDataReader(0))
                    CLBDatabases.Items.Add(New MyListBoxItem() With {.Name = mySQLConnection.myDataReader(0) & worker.getVersion(mySQLConnection.myDataReader(0)).ToString, .ExtraData = mySQLConnection.myDataReader(0)})
                End While
            End If
            mySQLConnection.CloseConnection()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CLBDatabases.CheckedItems.Count = CLBDatabases.Items.Count Then
            For i As Integer = 0 To CLBDatabases.Items.Count - 1
                CLBDatabases.SetItemChecked(i, False)
            Next
            Button1.Text = "Select All"
        Else
            For i As Integer = 0 To CLBDatabases.Items.Count - 1
                CLBDatabases.SetItemChecked(i, True)
            Next
            Button1.Text = "De-Select All"
        End If
    End Sub

    Private Sub CLBDatabases_MouseDown(sender As Object, e As MouseEventArgs) Handles CLBDatabases.MouseDown
        'Dim nameFrom As String
        'Dim nameTo As String
        'If e.Button = MouseButtons.Right Then
        '    Dim index As Integer = CLBDatabases.IndexFromPoint(New Point(e.X, e.Y))
        '    If index >= 0 Then
        '        nameFrom = CLBDatabases.Items(index).extradata
        '        nameTo = InputBox("Rename Database", "Rename", CLBDatabases.Items(index).extradata)
        '        If connected And nameFrom > "" And nameTo > "" Then
        '            Dim backingUp As New backingUp(15)
        '            backingUp.nameFrom = nameFrom
        '            backingUp.nameTo = nameTo
        '            backingUp.MdiParent = Me
        '            backingUp.Show()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub CLBDatabases_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CLBDatabases.MouseUp
        Try
            My.Settings.checkedDatabases.Clear()
            For Each item As main.MyListBoxItem In CLBDatabases.CheckedItems
                My.Settings.checkedDatabases.Add(item.ExtraData.ToString)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CLBDatabases_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLBDatabases.SelectedIndexChanged
        Try
            If CLBDatabases.CheckedItems.Count = CLBDatabases.Items.Count Then
                Button1.Text = "De-Select All"
            Else
                Button1.Text = "Select All"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim log As New log
        log.MdiParent = Me
        log.Show()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs)
        My.Settings.username = ""
        My.Settings.password = ""
        My.Settings.database = ""
        My.Settings.server = ""
        My.Settings.remember = False
        My.Settings.Save()
    End Sub

    Private Sub PictureBox5_Click_1(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click
        Try
            If Not lblStatus.Text <> "" Then
                pnlWelcome.Visible = False
                Dim serverConnect As New serverConnect
                serverConnect.MdiParent = DirectCast(Me, main)
                serverConnect.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox9_Click(sender As System.Object, e As System.EventArgs)
        PictureBox6.Visible = False
        For Each child As Form In Me.MdiChildren
            child.Close()
        Next child
        Dim settings As New mysettings
        settings.MdiParent = DirectCast(Me, main)
        settings.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Dim backingUp As New backingUp(5)
        backingUp.MdiParent = Me
        backingUp.Show()
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Button3.Visible = False
        Dim backingUp As New backingUp(5)
        backingUp.MdiParent = Me
        backingUp.Show()
    End Sub

    'Public Sub checkToolUpdate()
    '    Try
    '        Dim web_client2 As WebClient = New WebClient
    '        web_client2.DownloadFile("http://www." & website & "/downloads/Manager/version.txt", My.Settings.settingsFolder & "version.txt")
    '        Dim strContent As String()
    '        strContent = System.IO.File.ReadAllLines(My.Settings.settingsFolder & "version.txt")
    '        For Each item In strContent
    '            If VERSION < CInt(item) Then
    '                If MsgBox("There is a newer version of this tool available." & vbCrLf & "Would you like to upgrade?.", vbYesNo) = vbYes Then
    '                    web_client2.DownloadFile("http://www." & website & "/Emax Updates/Emax Manager/setup.exe", My.Settings.settingsFolder & "setup.exe")
    '                    Shell(My.Settings.settingsFolder & "setup.exe")
    '                    Application.Exit()
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception
    '    End Try
    'End Sub


   

    Private Sub connect()
        Try
            If Not lblStatus.Text <> "" Then
                pnlWelcome.Visible = False
                Dim serverConnect As New serverConnect
                serverConnect.MdiParent = DirectCast(Me, main)
                serverConnect.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub minimise_Click(sender As Object, e As EventArgs)
    '    Me.ShowInTaskbar = False
    '    Me.WindowState = FormWindowState.Minimized
    '    NotifyIcon1.Visible = True
    'End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub tbDeletePass_TextChanged(sender As Object, e As EventArgs) Handles tbDeletePass.TextChanged
        Dim password As String
        password = Replace(CStr(Today), "/", "")
        password = UCase(Mid(password, 1, 1) & Mid(MonthName(Now.Month), 1, 3))
        If UCase(tbDeletePass.Text) = password Or tbDeletePass.Text = "6313" Then
            Select Case currentProcess
                Case 1
                    Dim back As New backingUp(11)
                    back.MdiParent = Me
                    back.Show()
                Case 2
                        If My.Settings.autoBackUp = False Then
                            If MsgBox("Are you sure you wish to upgrade the selected databases without backing up first?", MsgBoxStyle.OkCancel, "Continue?") = vbOK Then
                                Dim backingUp As New backingUp(1)
                                backingUp.MdiParent = Me
                                backingUp.Show()
                            End If
                        Else
                            Dim backingUp As New backingUp(1)
                            backingUp.MdiParent = Me
                            backingUp.Show()
                        End If
                Case 3
                   
                    If Not Directory.Exists(My.Settings.settingsFolder & "scripts") Then Directory.CreateDirectory(My.Settings.settingsFolder & "scripts")
                        Dim numberOfFiles As Integer = IO.Directory.GetFiles(My.Settings.settingsFolder & "scripts").Length
                        If numberOfFiles > 0 Then
                            Dim queries As New queries
                            queries.MdiParent = Me
                            queries.Show()
                        Else
                            Dim backingUp As New backingUp(10)
                            backingUp.MdiParent = Me
                            backingUp.Show()
                    End If

            End Select
            Panel2.Visible = False
            tbDeletePass.Text = ""
            currentProcess = 0
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CLBDatabases.Enabled = True
        Panel2.Visible = False
    End Sub

   
    Private Sub main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.ShowInTaskbar = False
        'End If
    End Sub

    Private Function checkPassword() As Boolean
        Dim password As String
        password = Replace(CStr(Today), "/", "")
        password = UCase(Mid(password, 1, 1) & Mid(MonthName(Now.Month), 1, 3))
        If My.Settings.mainPassword = password Then
            checkPassword = True
        Else
            checkPassword = False
        End If
    End Function

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        panelWelcome2.Visible = False
        My.Settings.hideDisclaimer = chkHide.CheckState
        My.Settings.Save()
    End Sub

    Public Class MyListBoxItem
        Private _name As String
        Private _extraData As String


        Public Property Name As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property ExtraData As String
            Get
                Return _extraData
            End Get
            Set(ByVal value As String)
                _extraData = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Name
        End Function

    End Class

    Private Sub PictureBox6_Click_1(sender As Object, e As EventArgs) Handles PictureBox6.Click
        PictureBox6.Enabled = False
        For Each child As Form In Me.MdiChildren
            child.Hide()
        Next child
        Dim settings As New mysettings
        settings.MdiParent = DirectCast(Me, main)
        settings.Show()
    End Sub

    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs) Handles PictureBox3.Click
        refreshDBList()
        Button1.Text = "Select All"
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        disConnect()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            If Not lblStatus.Text <> "" Then
                pnlWelcome.Visible = False
                Dim serverConnect As New serverConnect
                serverConnect.MdiParent = DirectCast(Me, main)
                serverConnect.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class