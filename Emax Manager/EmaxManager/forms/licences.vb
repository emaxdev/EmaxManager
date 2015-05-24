Imports System.IO

Public Class licences

    Dim folder As String
    Dim fileToDelete As String

    Private Function Decrypt(ByVal StringIn As String) As String
        StringIn = Replace(StringIn, "!", "a")
        StringIn = Replace(StringIn, "$", "b")
        StringIn = Replace(StringIn, ")", "c")
        StringIn = Replace(StringIn, "(", "d")
        StringIn = Replace(StringIn, "^", "e")
        StringIn = Replace(StringIn, "£", "f")
        StringIn = Replace(StringIn, "'", "g")
        StringIn = Replace(StringIn, "%", "h")
        StringIn = Replace(StringIn, "O", "i")
        StringIn = Replace(StringIn, "=", "j")
        StringIn = Replace(StringIn, "+", "k")
        StringIn = Replace(StringIn, "G", "l")
        StringIn = Replace(StringIn, "K", "m")
        StringIn = Replace(StringIn, ";", "n")
        StringIn = Replace(StringIn, "{", "o")
        StringIn = Replace(StringIn, "}", "p")
        StringIn = Replace(StringIn, "[", "q")
        StringIn = Replace(StringIn, "]", "r")
        StringIn = Replace(StringIn, "R", "s")
        StringIn = Replace(StringIn, "B", "t")
        StringIn = Replace(StringIn, "J", "u")
        StringIn = Replace(StringIn, "@", "v")
        StringIn = Replace(StringIn, "~", "w")
        StringIn = Replace(StringIn, "T", "x")
        StringIn = Replace(StringIn, "`", "y")
        StringIn = Replace(StringIn, "&", "z")
        StringIn = Replace(StringIn, "W", "1")
        StringIn = Replace(StringIn, "Z", "2")
        StringIn = Replace(StringIn, "X", "3")
        StringIn = Replace(StringIn, "N", "4")
        StringIn = Replace(StringIn, "Q", "5")
        StringIn = Replace(StringIn, "P", "6")
        StringIn = Replace(StringIn, "A", "7")
        StringIn = Replace(StringIn, "C", "8")
        StringIn = Replace(StringIn, "U", "9")
        StringIn = Replace(StringIn, "E", "0")
        StringIn = Replace(StringIn, "I", ":")
        StringIn = Replace(StringIn, "Y", "-")
        StringIn = Replace(StringIn, "H", "_")
        StringIn = Replace(StringIn, "#", "")
        Decrypt = StringIn
    End Function

    Private Sub loadColours()
        Panel1.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Panel4.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        headerPanel.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        Label9.ForeColor = worker.darkLight(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'lblLicenceDir.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
        'TextBox1.BackColor = Color.FromArgb(IIf(My.Settings.R > "", My.Settings.R, 0), IIf(My.Settings.B > "", My.Settings.B, 0), IIf(My.Settings.G > "", My.Settings.G, 0))
    End Sub

    Private Sub licences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadColours()
        Me.Left = main.screenLeft
        Me.Top = main.screensTop
        If System.IO.File.Exists(My.Settings.licenceFolder & "\License.eli") Then
            folder = My.Settings.licenceFolder
            setUpGrid()
            DataGridView1.Columns("Delete").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            readFile()
            enableLabels()
        Else
            DataGridView1.Height = DataGridView1.Height - 50
            DataGridView1.Top = DataGridView1.Top + 50
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 2 Then
            If MsgBox("Are you sure you want to delete this license?", MsgBoxStyle.YesNo, "Delete Licence") = MsgBoxResult.Yes Then
                If System.IO.File.Exists(folder & "\" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value) Then
                    fileToDelete = folder & "\" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value
                    Panel4.Visible = True
                    Button3.Visible =
                    tbLicencePass.Focus
                End If
            End If
        End If
    End Sub

    Private Sub readFile()
        Dim textLine As String
        textLine = (ReadSpecifiedLine(folder & "\License.eli", 0))
        textLine = Decrypt(textLine)
        If textLine.Contains(":") Then
            textLine = textLine.Substring(textLine.IndexOf(":"), textLine.Length - textLine.IndexOf(":"))
            textLine = textLine.Substring(1, textLine.Length - 1)
        End If
        lblCompany.Text = textLine

        textLine = (ReadSpecifiedLine(folder & "\License.eli", 1))
        textLine = Decrypt(textLine)
        If textLine.Contains(":") Then
            textLine = textLine.Substring(textLine.IndexOf(":"), textLine.Length - textLine.IndexOf(":"))
            textLine = textLine.Substring(1, textLine.Length - 1)
        End If
        lblLicenses.Text = textLine

        textLine = (ReadSpecifiedLine(folder & "\License.eli", 2))
        textLine = Decrypt(textLine)
        If textLine.Contains(":") Then
            textLine = textLine.Substring(textLine.IndexOf(":"), textLine.Length - textLine.IndexOf(":"))
            textLine = textLine.Substring(1, textLine.Length - 1)
        End If
        If Not textLine.Equals("false") Then
            Label3.Text = "Trial"
        End If

        textLine = (ReadSpecifiedLine(folder & "\License.eli", 3))
        textLine = Decrypt(textLine)
        If textLine.Contains(":") Then
            textLine = textLine.Substring(textLine.IndexOf(":"), textLine.Length - textLine.IndexOf(":"))
            textLine = textLine.Substring(1, textLine.Length - 1)
        End If
        If Label3.Text.Equals("Trial") Then
            Label2.Text = textLine
            Label7.Text = "Expires:"
        End If
    End Sub

    Private Sub setUpGrid()
        Dim di As New IO.DirectoryInfo(folder)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        Dim fileCount As Integer
        fileCount = 0

        For Each dra In diar1
            If (dra.Name).Substring(1, 1) = "#" Then
                Dim fileName As String
                fileName = Decrypt(dra.Name)
                fileName = fileName.Substring(0, fileName.Length - 4)
                DataGridView1.Rows.Add(fileName, dra.Name)
                fileCount = fileCount + 1
            End If
        Next
        If fileCount > 11 Then
            Dim column As DataGridViewColumn = DataGridView1.Columns(2)
            column.Width = 83
        Else
            Dim column As DataGridViewColumn = DataGridView1.Columns(2)
            column.Width = 100
        End If
        Label1.Text = fileCount
    End Sub

    Private Sub DataGridView_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        Dim o As DataGridViewButtonCell
        For index As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
            o = DataGridView1.Rows(index).Cells(2)
            o.Value = "Delete"
        Next
    End Sub

    Private Sub lblHeading_Click(sender As System.Object, e As System.EventArgs)
        My.Settings.licenceFolder = ""
    End Sub

    Public Sub enableLabels()
        lblCompany.Visible = True
        lblLicenses.Visible = True
        Label3.Visible = True
        Label1.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label2.Visible = True
        Label7.Visible = True
    End Sub

    Public Shared Function ReadSpecifiedLine(file As String, lineNum As Integer) As String
        'create a variable to hold the contents of the file
        Dim contents As String = String.Empty
        'always use a try...catch to deal
        'with any exceptions that may occur
        Try
            Using stream As New System.IO.StreamReader(file)
                contents = stream.ReadToEnd().Replace(vbCr & vbLf, vbLf).Replace(vbLf & vbCr, vbLf)
                Dim linesArray As String() = contents.Split(New Char() {ControlChars.Lf})

                'Make sure we have ana ctual array
                If linesArray.Length > 1 Then
                    'Make sure user didnt provide number greater than the number
                    'of lines in the array, and not less than 0 (zero) Thanks AdamSpeight2008
                    If Not lineNum > linesArray.Length AndAlso Not lineNum < 0 Then
                        Return linesArray(lineNum)
                    Else
                        'Failed our check so return the first line in the array
                        Return linesArray(0)
                    End If
                Else
                    'No array so return the line
                    Return contents
                End If
            End Using
        Catch ex As Exception
            Return ex.ToString()
        End Try
    End Function

    
    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim listOfFiles As String = ""
            Dim count As Integer = 0
            If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\EmaxLicences.txt") Then
                IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\EmaxLicences.txt")
            End If

            For Each row In DataGridView1.Rows
                If Not listOfFiles > "" Then
                    listOfFiles = listOfFiles & (Decrypt(row.cells(1).value)).Substring(0, (Decrypt(row.cells(1).value)).Length - 4)
                Else
                    listOfFiles = listOfFiles & vbCrLf & (Decrypt(row.cells(1).value)).Substring(0, (Decrypt(row.cells(1).value)).Length - 4)
                End If
                count = count + 1
            Next
            listOfFiles = "Licences as at: " & Today & vbCrLf & vbCrLf & listOfFiles
            listOfFiles = listOfFiles & vbCrLf & vbCrLf & "Licence Count: " & count

            Using outfile As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\EmaxLicences.txt")
                outfile.Write(listOfFiles)
            End Using
            MsgBox("List Exported to Desktop")
        Catch ex As Exception
            MsgBox("Problem exporting list.  Check if file is open or check permissions.")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Dim manage As New management
        manage.MdiParent = main
        manage.Show()
    End Sub


    Private Sub tbLicencePass_TextChanged(sender As Object, e As EventArgs) Handles tbLicencePass.TextChanged
        If tbLicencePass.Text = "EMAXADMIN" Then
            System.IO.File.Delete(fileToDelete)
            DataGridView1.Rows.Clear()
            setUpGrid()
            Button3.Visible = True
            Panel4.Visible = False
            fileToDelete = ""
            tbLicencePass.Text = ""
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel4.Visible = False
        Button3.Visible = True
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        My.Settings.licenceFolder = ""
        My.Settings.Save()
        DataGridView1.Rows.Clear()
        DataGridView1.Height = 208
        DataGridView1.Top = 117
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"
        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = MyFolderBrowser.SelectedPath
            If Directory.Exists(TextBox1.Text) Then
                My.Settings.licenceFolder = TextBox1.Text
                My.Settings.Save()
            End If
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        folder = TextBox1.Text
        If System.IO.File.Exists(folder & "\License.eli") Then
            My.Settings.licenceFolder = folder
            My.Settings.Save()
            setUpGrid()
            DataGridView1.Height = 278
            DataGridView1.Top = 67
            My.Settings.licenceFolder = folder
            readFile()
            enableLabels()
        Else
            DataGridView1.Rows.Clear()
            DataGridView1.Height = 208
            DataGridView1.Top = 117
        End If
    End Sub
End Class