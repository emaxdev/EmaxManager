Imports System.Data.SqlClient

Public Class mySQLConnection

    Private Shared myConnection As SQLConnection

    Public Shared Function OpenConnection(ByVal Connection As String) As Boolean
        Try
            myConnection = New SqlConnection(Connection)
            myConnection.Open()
            Return True
        Catch ex As Exception
            MsgBox("Problem opening connection.  Please check connection details and firewall settings!", MsgBoxStyle.Exclamation, "Error Opening Connection")
            Return False
        End Try
    End Function

    Public Shared Sub CloseConnection()
        If myConnection.State = System.Data.ConnectionState.Open Then
            myConnection.Close()
        End If
    End Sub

    Public Shared myDataReader As SqlDataReader

    Public Shared Function ReadData(ByVal SQLString As String) As Boolean
        Try
            Dim myCommand As New SqlCommand(SQLString, myConnection)
            myCommand.CommandTimeout = 5000
            myDataReader = myCommand.ExecuteReader()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Reading Data")
            Return False
        End Try
    End Function

    Public Shared Sub ExecuteSQLCommand(ByVal SQLString As String)
        Try
            Dim sqlComm As New SqlCommand(SQLString, myConnection)
            sqlComm.CommandTimeout = 0
            sqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Executing Command")
        End Try
    End Sub

End Class