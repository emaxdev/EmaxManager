Imports System.IO
Imports System.Text.RegularExpressions

Public Class queries

    Private Sub queries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        Dim firstButton As Integer = 10
        Dim buttonNum As Integer = 1
        Dim scriptArr As String()
        Dim myScriptList As New List(Of scripts)
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label1.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Dim src As String = My.Settings.settingsFolder & "scripts"
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(src)
            If (IO.Path.GetExtension(foundFile) = ".sql") Or (IO.Path.GetExtension(foundFile) = ".Sql") Then
                Dim sqlFile As String = ""
                Dim scriptDescription As String = ""
                Dim scriptDetails As String = ""
                Try
                    sqlFile = System.IO.Path.GetFileName(foundFile)

                    scriptDetails = File.ReadAllText(foundFile)

                    Dim sr As StreamReader = New StreamReader(foundFile)
                    Dim temp As String = ""
                    temp = Regex.Replace(scriptDetails, "\bGO\b", ";")
                    scriptArr = temp.Split(";")

                    Do While sr.Peek() >= 0
                        Dim tempString = sr.ReadLine()
                        If tempString.Length > 1 Then
                            If tempString.Substring(0, 2) = "--" Then
                                scriptDescription = scriptDescription & tempString.Trim("-") & vbCrLf
                            End If
                        End If
                    Loop
                    If Not scriptDescription > "" Then
                        scriptDescription = "Sorry - No description available"
                    End If
                    sr.Close()

                    Dim myScript As New scripts
                    myScript.scriptName = sqlFile
                    myScript.scriptDescription = scriptDescription
                    myScript.scriptDetails = scriptDetails
                    myScript.scripts = scriptArr
                    myScriptList.Add(myScript)

                Catch ex As Exception
                    MsgBox("Error" & ex.ToString)
                End Try
            End If
        Next

        For Each script In myScriptList

            Dim la As New Label
            la.Width = 200
            la.Text = script.scriptName
            la.Top = firstButton
            la.Left = 0
            la.Font = New Font(la.Font, FontStyle.Bold)
            'add button to form
            Panel1.Controls.Add(la)

            Dim tb As New TextBox
            tb.Width = 290
            tb.Height = 50
            tb.Multiline = True
            tb.ScrollBars = ScrollBars.Vertical
            tb.BackColor = Color.Azure
            tb.Text = script.scriptDescription
            tb.Top = firstButton + 25
            tb.Left = 0

            'add button to form
            Panel1.Controls.Add(tb)
            tb.TabStop = False
            Dim btn As New Button
            btn.Width = 35
            btn.Height = 50
            btn.Text = "Go"
            btn.TextAlign = ContentAlignment.MiddleCenter
            btn.Top = firstButton + 25
            btn.Left = 305
            btn.Tag = script.scripts
            'add button to form
            Panel1.Controls.Add(btn)
            firstButton = firstButton + 90
            buttonNum = buttonNum + 1

            AddHandler btn.Click, AddressOf worker.Button_Click
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Dim manage As New management
        manage.MdiParent = main
        manage.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim backingUp As New backingUp(10)
        backingUp.MdiParent = main
        backingUp.Show()
    End Sub

End Class