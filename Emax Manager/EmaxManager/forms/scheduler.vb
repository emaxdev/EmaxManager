Imports Microsoft.Win32.TaskScheduler
Imports System.IO

Public Class scheduler

    Public Shared Function ScheduleTaskInWin_TaskScheduler(
                                                          ByRef sunday As String, _
                                                          ByRef monday As String, _
                                                          ByRef tues As String, _
                                                          ByRef wedn As String, _
                                                          ByRef thursday As String, _
                                                          ByRef friday As String, _
                                                          ByRef saturday As String, _
                                                          ByRef Hours As String, _
                                                          ByRef mins As String
                                                          )

        Using ts As New TaskService()
            ' Create a new task definition and assign properties
            Dim td As TaskDefinition = ts.NewTask

            td.RegistrationInfo.Description = "Emax "
            ' use below mentioned code for WeeklyTrigger 
            Dim wt As New WeeklyTrigger()
            Dim wt2 As New WeeklyTrigger()
            Dim wt3 As New WeeklyTrigger()
            Dim wt4 As New WeeklyTrigger()
            Dim wt5 As New WeeklyTrigger()
            Dim wt6 As New WeeklyTrigger()
            Dim wt7 As New WeeklyTrigger()

            If sunday > "" Then
                wt.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt.DaysOfWeek = sunday
                wt.Repetition.Duration = TimeSpan.FromHours(24)
                wt.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt)
            End If

            If monday > "" Then
                wt2.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt2.DaysOfWeek = monday
                wt2.Repetition.Duration = TimeSpan.FromHours(24)
                wt2.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt2)
            End If

            If tues > "" Then
                wt3.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt3.DaysOfWeek = tues
                wt3.Repetition.Duration = TimeSpan.FromHours(24)
                wt3.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt3)
            End If

            If wedn > "" Then
                wt4.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt4.DaysOfWeek = wedn
                wt4.Repetition.Duration = TimeSpan.FromHours(24)
                wt4.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt4)
            End If

            If thursday > "" Then
                wt5.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt5.DaysOfWeek = thursday
                wt5.Repetition.Duration = TimeSpan.FromHours(24)
                wt5.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt5)
            End If

            If friday > "" Then
                wt6.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt6.DaysOfWeek = friday
                wt6.Repetition.Duration = TimeSpan.FromHours(24)
                wt6.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt6)
            End If

            If saturday > "" Then
                wt7.StartBoundary = DateTime.Today.AddHours(Hours).AddMinutes(mins).AddDays(-1)
                wt7.DaysOfWeek = saturday
                wt7.Repetition.Duration = TimeSpan.FromHours(24)
                wt7.Repetition.Interval = TimeSpan.FromDays(1)
                td.Triggers.Add(wt7)
            End If


            Dim FolderPath As String = "C:\Users\alan_000\Desktop\BackUp"
            Dim ExeLocation As String = Path.Combine(FolderPath, "backup.bat")
            'ExeLocation = ExeLocation.Replace("\"c, "/"c)
            ' Add an action (shorthand) that runs Notepad
            td.Actions.Add(New ExecAction(ExeLocation))
            ' Register the task in the root folder
            ts.RootFolder.RegisterTaskDefinition("Emax Backup", td)
        End Using

        Return ""
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.CustomFormat = "HH:mm"
        loadStuff()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sunday As String = IIf(CheckBox7.Checked, DaysOfTheWeek.Sunday, "")
        Dim monday As String = IIf(CheckBox1.Checked, DaysOfTheWeek.Monday, "")
        Dim tuesday As String = IIf(CheckBox2.Checked, DaysOfTheWeek.Tuesday, "")
        Dim Wednesday As String = IIf(CheckBox3.Checked, DaysOfTheWeek.Wednesday, "")
        Dim Thursday As String = IIf(CheckBox4.Checked, DaysOfTheWeek.Thursday, "")
        Dim Friday As String = IIf(CheckBox5.Checked, DaysOfTheWeek.Friday, "")
        Dim Saturday As String = IIf(CheckBox6.Checked, DaysOfTheWeek.Saturday, "")

        ScheduleTaskInWin_TaskScheduler(sunday, monday, _
                 tuesday, Wednesday, Thursday, Friday, Saturday, Mid(DateTimePicker1.Text, 1, 2), Mid(DateTimePicker1.Text, 4, 2))
        loadStuff()
    End Sub

    Private Sub loadStuff()
        Try
            Using ts As New TaskService()
                Dim et As Task = ts.FindTask("Emax Backup", True)
                Dim etd As TaskDefinition = et.Definition
                For Each wt As WeeklyTrigger In etd.Triggers
                    If wt.DaysOfWeek = DaysOfTheWeek.Monday Then CheckBox1.Checked = True
                    If wt.DaysOfWeek = DaysOfTheWeek.Tuesday Then CheckBox2.Checked = True
                    If wt.DaysOfWeek = DaysOfTheWeek.Wednesday Then CheckBox3.Checked = True
                    If wt.DaysOfWeek = DaysOfTheWeek.Thursday Then CheckBox4.Checked = True
                    If wt.DaysOfWeek = DaysOfTheWeek.Friday Then CheckBox5.Checked = True
                    If wt.DaysOfWeek = DaysOfTheWeek.Saturday Then CheckBox6.Checked = True
                    If wt.DaysOfWeek = DaysOfTheWeek.Sunday Then CheckBox7.Checked = True
                Next
            End Using


        Catch ex As Exception

        End Try
    End Sub

End Class