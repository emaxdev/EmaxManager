Imports System.Data.SqlClient

Public Class connections

    Private Sub connections_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        Dim selectedDatabases As New Specialized.StringCollection
        My.Settings.checkedDatabases.Clear()
        For Each item In main.CLBDatabases.CheckedItems
            selectedDatabases.Add(item.ToString)
            My.Settings.checkedDatabases = selectedDatabases
            My.Settings.Save()
        Next
        Dim connectionsDatabase As String
        connectionsDatabase = ""

        If main.CLBDatabases.CheckedItems.Count = 1 Then

            For Each item In main.CLBDatabases.CheckedItems
                connectionsDatabase = item.ToString
            Next
            'Dim sqlText As String() = CType(CType(sender, System.Windows.Forms.Button).Tag, String())
            Dim connStr = "Server=" & My.Settings.server & ";Database=" & connectionsDatabase & ";UID=" & My.Settings.username & ";PWD=" & My.Settings.password & ""
            Dim conn = New SqlConnection(connStr)


            Try
                conn.Open()
                Try
                    Dim sqlCmd = New SqlCommand()
                    sqlCmd.Connection = conn
                    sqlCmd.CommandText = "SELECT hostname from master.dbo.sysprocesses p join master.dbo.sysdatabases d on p.dbID = d.dbID where d.name = '" & connectionsDatabase & "'and hostname > CURRENT_USER"
                    Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
                    While reader.Read()
                        If Not Trim(reader(0)) = My.Computer.Name Then
                            ListBox1.Items.Add(reader(0))
                        End If
                    End While
                    If ListBox1.Items.Count = 0 Then
                        ListBox1.Items.Add("No Connections")
                    End If
                Finally
                End Try
            Catch ex As Exception
                MsgBox("Something went wrong: " & ex.Message)
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Else
            MsgBox("Please select one database")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Me.Close()
        Dim manage As New management
        manage.MdiParent = main
        manage.Show()
    End Sub
End Class