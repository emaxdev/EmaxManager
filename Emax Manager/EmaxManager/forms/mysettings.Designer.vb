<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mysettings
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
      
        Me.cbBackUp = New System.Windows.Forms.CheckBox()
        Me.cbViews = New System.Windows.Forms.CheckBox()
        Me.chkShowDisclaimer = New System.Windows.Forms.CheckBox()
        Me.chkAutoCheckForUpdate = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbCompany = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        Me.tbR = New System.Windows.Forms.TextBox()
        Me.tbB = New System.Windows.Forms.TextBox()
        Me.tbG = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cbLocked = New System.Windows.Forms.CheckBox()
        Me.drpMainDatabase = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.headerPanel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.openBackupFolder = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(308, 430)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(260, 24)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(23, 430)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(279, 24)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '

        '
     
        '
        'cbBackUp
        '
        Me.cbBackUp.AutoSize = True
        Me.cbBackUp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbBackUp.Location = New System.Drawing.Point(416, 348)
        Me.cbBackUp.Name = "cbBackUp"
        Me.cbBackUp.Size = New System.Drawing.Size(152, 17)
        Me.cbBackUp.TabIndex = 9
        Me.cbBackUp.Text = "Auto Back Up on Upgrade"
        Me.cbBackUp.UseVisualStyleBackColor = True
        '
        'cbViews
        '
        Me.cbViews.AutoSize = True
        Me.cbViews.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbViews.Location = New System.Drawing.Point(412, 330)
        Me.cbViews.Name = "cbViews"
        Me.cbViews.Size = New System.Drawing.Size(156, 17)
        Me.cbViews.TabIndex = 8
        Me.cbViews.Text = "Skip Drop Views and Views"
        Me.cbViews.UseVisualStyleBackColor = True
        '
        'chkShowDisclaimer
        '
        Me.chkShowDisclaimer.AutoSize = True
        Me.chkShowDisclaimer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShowDisclaimer.Location = New System.Drawing.Point(464, 366)
        Me.chkShowDisclaimer.Name = "chkShowDisclaimer"
        Me.chkShowDisclaimer.Size = New System.Drawing.Size(104, 17)
        Me.chkShowDisclaimer.TabIndex = 10
        Me.chkShowDisclaimer.Text = "Show Disclaimer"
        Me.chkShowDisclaimer.UseVisualStyleBackColor = True
        '
        'chkAutoCheckForUpdate
        '
        Me.chkAutoCheckForUpdate.AutoSize = True
        Me.chkAutoCheckForUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoCheckForUpdate.Location = New System.Drawing.Point(391, 383)
        Me.chkAutoCheckForUpdate.Name = "chkAutoCheckForUpdate"
        Me.chkAutoCheckForUpdate.Size = New System.Drawing.Size(177, 17)
        Me.chkAutoCheckForUpdate.TabIndex = 11
        Me.chkAutoCheckForUpdate.Text = "Auto Check for Update on Load"
        Me.chkAutoCheckForUpdate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tbCompany)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(11, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 38)
        Me.Panel1.TabIndex = 31
        '
        'tbCompany
        '
        Me.tbCompany.BackColor = System.Drawing.Color.White
        Me.tbCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCompany.Enabled = False
        Me.tbCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCompany.Location = New System.Drawing.Point(172, 8)
        Me.tbCompany.Name = "tbCompany"
        Me.tbCompany.Size = New System.Drawing.Size(382, 22)
        Me.tbCompany.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 23)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Company Name:"
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(30, 329)
        Me.TrackBar1.Maximum = 255
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(199, 45)
        Me.TrackBar1.TabIndex = 33
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBar2
        '
        Me.TrackBar2.Location = New System.Drawing.Point(30, 352)
        Me.TrackBar2.Maximum = 255
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(201, 45)
        Me.TrackBar2.TabIndex = 34
        Me.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBar3
        '
        Me.TrackBar3.Location = New System.Drawing.Point(30, 377)
        Me.TrackBar3.Maximum = 255
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(201, 45)
        Me.TrackBar3.TabIndex = 35
        Me.TrackBar3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbR
        '
        Me.tbR.Location = New System.Drawing.Point(237, 331)
        Me.tbR.Name = "tbR"
        Me.tbR.Size = New System.Drawing.Size(36, 20)
        Me.tbR.TabIndex = 36
        '
        'tbB
        '
        Me.tbB.Location = New System.Drawing.Point(237, 354)
        Me.tbB.Name = "tbB"
        Me.tbB.Size = New System.Drawing.Size(36, 20)
        Me.tbB.TabIndex = 37
        '
        'tbG
        '
        Me.tbG.Location = New System.Drawing.Point(237, 377)
        Me.tbG.Name = "tbG"
        Me.tbG.Size = New System.Drawing.Size(36, 20)
        Me.tbG.TabIndex = 38
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Location = New System.Drawing.Point(11, 121)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(568, 38)
        Me.Panel2.TabIndex = 55
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 23)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Back Up Location:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(517, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 20)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(172, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(326, 22)
        Me.TextBox1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cbLocked)
        Me.Panel3.Controls.Add(Me.drpMainDatabase)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(11, 173)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(568, 38)
        Me.Panel3.TabIndex = 56
        '
        'cbLocked
        '
        Me.cbLocked.AutoSize = True
        Me.cbLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLocked.Location = New System.Drawing.Point(506, 10)
        Me.cbLocked.Name = "cbLocked"
        Me.cbLocked.Size = New System.Drawing.Size(50, 17)
        Me.cbLocked.TabIndex = 3
        Me.cbLocked.Text = "Lock"
        Me.cbLocked.UseVisualStyleBackColor = True
        '
        'drpMainDatabase
        '
        Me.drpMainDatabase.BackColor = System.Drawing.Color.White
        Me.drpMainDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpMainDatabase.FormattingEnabled = True
        Me.drpMainDatabase.ItemHeight = 16
        Me.drpMainDatabase.Location = New System.Drawing.Point(172, 6)
        Me.drpMainDatabase.Margin = New System.Windows.Forms.Padding(0)
        Me.drpMainDatabase.Name = "drpMainDatabase"
        Me.drpMainDatabase.Size = New System.Drawing.Size(326, 24)
        Me.drpMainDatabase.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 23)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Main Database:"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Location = New System.Drawing.Point(11, 225)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(568, 38)
        Me.Panel4.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 23)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Shared Folder:"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(172, 7)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(326, 22)
        Me.TextBox2.TabIndex = 4
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(517, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(39, 22)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Button5)
        Me.Panel5.Controls.Add(Me.TextBox3)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(11, 277)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(568, 38)
        Me.Panel5.TabIndex = 58
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(517, 8)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(39, 22)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Clear"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(172, 7)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(326, 22)
        Me.TextBox3.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 23)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Settings Folder:"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Location = New System.Drawing.Point(80, 403)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(19, 13)
        Me.Panel6.TabIndex = 59
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(105, 403)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(19, 13)
        Me.Panel7.TabIndex = 60
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(130, 403)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(19, 13)
        Me.Panel8.TabIndex = 61
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Location = New System.Drawing.Point(155, 403)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(19, 13)
        Me.Panel9.TabIndex = 62
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Location = New System.Drawing.Point(180, 403)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(19, 13)
        Me.Panel10.TabIndex = 63
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.headerPanel)
        Me.Panel11.Controls.Add(Me.PictureBox4)
        Me.Panel11.Location = New System.Drawing.Point(3, 11)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(579, 46)
        Me.Panel11.TabIndex = 64
        '
        'headerPanel
        '
        Me.headerPanel.BackColor = System.Drawing.Color.DarkRed
        Me.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.headerPanel.Controls.Add(Me.Label5)
        Me.headerPanel.Location = New System.Drawing.Point(8, 3)
        Me.headerPanel.Name = "headerPanel"
        Me.headerPanel.Size = New System.Drawing.Size(515, 40)
        Me.headerPanel.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Gadugi", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(223, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 22)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Settings"
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
        'openBackupFolder
        '
        Me.openBackupFolder.AutoSize = True
        Me.openBackupFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.openBackupFolder.Location = New System.Drawing.Point(419, 402)
        Me.openBackupFolder.Name = "openBackupFolder"
        Me.openBackupFolder.Size = New System.Drawing.Size(149, 17)
        Me.openBackupFolder.TabIndex = 65
        Me.openBackupFolder.Text = "Auto Open Backup Folder"
        Me.openBackupFolder.UseVisualStyleBackColor = True
        '
        'mysettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(588, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.openBackupFolder)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tbG)
        Me.Controls.Add(Me.tbB)
        Me.Controls.Add(Me.tbR)
        Me.Controls.Add(Me.TrackBar3)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkAutoCheckForUpdate)
        Me.Controls.Add(Me.chkShowDisclaimer)
        Me.Controls.Add(Me.cbViews)
        Me.Controls.Add(Me.cbBackUp)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(229, 6)
        Me.MaximumSize = New System.Drawing.Size(590, 464)
        Me.Name = "mysettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.headerPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbBackUp As System.Windows.Forms.CheckBox
    Friend WithEvents cbViews As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowDisclaimer As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoCheckForUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar3 As System.Windows.Forms.TrackBar
    Friend WithEvents tbR As System.Windows.Forms.TextBox
    Friend WithEvents tbB As System.Windows.Forms.TextBox
    Friend WithEvents tbG As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbLocked As System.Windows.Forms.CheckBox
    Friend WithEvents drpMainDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents headerPanel As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents openBackupFolder As System.Windows.Forms.CheckBox
End Class
