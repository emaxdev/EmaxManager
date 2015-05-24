<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class licences
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.LicenceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLicenses = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.tbLicencePass = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLicenceDir = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.headerPanel = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LicenceName, Me.Column1, Me.Delete})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 67)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(567, 258)
        Me.DataGridView1.TabIndex = 2
        '
        'LicenceName
        '
        Me.LicenceName.HeaderText = "Licence Name"
        Me.LicenceName.Name = "LicenceName"
        Me.LicenceName.Width = 460
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Delete
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(1)
        Me.Delete.DefaultCellStyle = DataGridViewCellStyle1
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 399)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Used:"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 23)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Licenses:"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 353)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Company:"
        Me.Label4.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(109, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'lblLicenses
        '
        Me.lblLicenses.AutoSize = True
        Me.lblLicenses.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenses.Location = New System.Drawing.Point(109, 379)
        Me.lblLicenses.Name = "lblLicenses"
        Me.lblLicenses.Size = New System.Drawing.Size(52, 19)
        Me.lblLicenses.TabIndex = 16
        Me.lblLicenses.Text = "Label2"
        Me.lblLicenses.Visible = False
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(109, 356)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(52, 19)
        Me.lblCompany.TabIndex = 15
        Me.lblCompany.Text = "Label1"
        Me.lblCompany.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(295, 402)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 19)
        Me.Label2.TabIndex = 22
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(295, 356)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 19)
        Me.Label3.TabIndex = 21
        Me.Label3.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(295, 379)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 19)
        Me.Label7.TabIndex = 23
        Me.Label7.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(11, 328)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(568, 22)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Export List"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(21, 428)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(453, 22)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "Back"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightGray
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Button6)
        Me.Panel4.Controls.Add(Me.tbLicencePass)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Location = New System.Drawing.Point(11, 424)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(568, 27)
        Me.Panel4.TabIndex = 30
        Me.Panel4.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(491, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(49, 20)
        Me.Button6.TabIndex = 29
        Me.Button6.Text = "Cancel"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'tbLicencePass
        '
        Me.tbLicencePass.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLicencePass.Location = New System.Drawing.Point(364, 4)
        Me.tbLicencePass.Name = "tbLicencePass"
        Me.tbLicencePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbLicencePass.Size = New System.Drawing.Size(121, 18)
        Me.tbLicencePass.TabIndex = 28
        Me.tbLicencePass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(236, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Please Enter Password"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(480, 428)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 22)
        Me.Button4.TabIndex = 31
        Me.Button4.Text = "Reset Folder"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblLicenceDir)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(11, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 37)
        Me.Panel1.TabIndex = 32
        '
        'lblLicenceDir
        '
        Me.lblLicenceDir.AutoSize = True
        Me.lblLicenceDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenceDir.Location = New System.Drawing.Point(8, 6)
        Me.lblLicenceDir.Name = "lblLicenceDir"
        Me.lblLicenceDir.Size = New System.Drawing.Size(192, 24)
        Me.lblLicenceDir.TabIndex = 27
        Me.lblLicenceDir.Text = "Licence Share Folder"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(218, 7)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(296, 22)
        Me.TextBox1.TabIndex = 28
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(526, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 24)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.headerPanel)
        Me.Panel5.Controls.Add(Me.PictureBox4)
        Me.Panel5.Location = New System.Drawing.Point(3, 11)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(579, 46)
        Me.Panel5.TabIndex = 37
        '
        'headerPanel
        '
        Me.headerPanel.BackColor = System.Drawing.Color.DarkRed
        Me.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.headerPanel.Controls.Add(Me.Label9)
        Me.headerPanel.Location = New System.Drawing.Point(8, 3)
        Me.headerPanel.Name = "headerPanel"
        Me.headerPanel.Size = New System.Drawing.Size(515, 40)
        Me.headerPanel.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Gadugi", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(223, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 22)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Licences"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.EmaxManager.My.Resources.Resources.logo
        Me.PictureBox4.Location = New System.Drawing.Point(529, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 35
        Me.PictureBox4.TabStop = False
        '
        'licences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(588, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblLicenses)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(229, 8)
        Me.MaximumSize = New System.Drawing.Size(590, 464)
        Me.MinimumSize = New System.Drawing.Size(391, 464)
        Me.Name = "licences"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.headerPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLicenses As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents tbLicencePass As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLicenceDir As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LicenceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents headerPanel As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
End Class
