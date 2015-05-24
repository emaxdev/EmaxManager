<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.tbDeletePass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lbLog = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panelWelcome2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.chkHide = New System.Windows.Forms.CheckBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CLBDatabases = New System.Windows.Forms.CheckedListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.headerPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelWelcome2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlWelcome.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.lblStatus)
        Me.Panel3.Controls.Add(Me.lbLog)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Location = New System.Drawing.Point(6, 479)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(812, 31)
        Me.Panel3.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.tbDeletePass)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(514, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(294, 21)
        Me.Panel2.TabIndex = 27
        Me.Panel2.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(243, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(49, 20)
        Me.Button5.TabIndex = 29
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'tbDeletePass
        '
        Me.tbDeletePass.Location = New System.Drawing.Point(120, 0)
        Me.tbDeletePass.Name = "tbDeletePass"
        Me.tbDeletePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbDeletePass.Size = New System.Drawing.Size(121, 20)
        Me.tbDeletePass.TabIndex = 28
        Me.tbDeletePass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Please Enter Password"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(112, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 23)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Log"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(37, 8)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblStatus.TabIndex = 16
        '
        'lbLog
        '
        Me.lbLog.FormattingEnabled = True
        Me.lbLog.Location = New System.Drawing.Point(11, 8)
        Me.lbLog.Name = "lbLog"
        Me.lbLog.Size = New System.Drawing.Size(45, 17)
        Me.lbLog.TabIndex = 23
        Me.lbLog.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.panelWelcome2)
        Me.Panel1.Controls.Add(Me.PictureBox7)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.CLBDatabases)
        Me.Panel1.Location = New System.Drawing.Point(6, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 464)
        Me.Panel1.TabIndex = 16
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkRed
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.PictureBox6)
        Me.Panel4.Controls.Add(Me.PictureBox3)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Location = New System.Drawing.Point(10, 14)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(197, 40)
        Me.Panel4.TabIndex = 34
        '
        'PictureBox6
        '
        Me.PictureBox6.Enabled = False
        Me.PictureBox6.Image = Global.EmaxManager.My.Resources.Resources.process1
        Me.PictureBox6.Location = New System.Drawing.Point(150, 5)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 24
        Me.PictureBox6.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.EmaxManager.My.Resources.Resources.repeat1
        Me.PictureBox3.Location = New System.Drawing.Point(103, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.EmaxManager.My.Resources.Resources.delete1
        Me.PictureBox2.Location = New System.Drawing.Point(56, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.EmaxManager.My.Resources.Resources.checkmark1
        Me.PictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'panelWelcome2
        '
        Me.panelWelcome2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelWelcome2.Controls.Add(Me.TextBox1)
        Me.panelWelcome2.Controls.Add(Me.Button11)
        Me.panelWelcome2.Controls.Add(Me.chkHide)
        Me.panelWelcome2.Location = New System.Drawing.Point(12, 64)
        Me.panelWelcome2.Name = "panelWelcome2"
        Me.panelWelcome2.Size = New System.Drawing.Size(195, 353)
        Me.panelWelcome2.TabIndex = 33
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(26, 86)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(149, 99)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "Please refer to instructions before attempting any upgrades as any risk or issues" & _
    " incurred are held at your own liability."
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(55, 206)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(88, 19)
        Me.Button11.TabIndex = 1
        Me.Button11.Text = "OK"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'chkHide
        '
        Me.chkHide.AutoSize = True
        Me.chkHide.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHide.Location = New System.Drawing.Point(42, 325)
        Me.chkHide.Name = "chkHide"
        Me.chkHide.Size = New System.Drawing.Size(111, 17)
        Me.chkHide.TabIndex = 0
        Me.chkHide.Text = "Don't Show Again"
        Me.chkHide.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.EmaxManager.My.Resources.Resources.martyn
        Me.PictureBox7.Location = New System.Drawing.Point(15, 326)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(192, 91)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 22
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 427)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 24)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Select All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CLBDatabases
        '
        Me.CLBDatabases.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CLBDatabases.CheckOnClick = True
        Me.CLBDatabases.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLBDatabases.FormattingEnabled = True
        Me.CLBDatabases.Location = New System.Drawing.Point(11, 65)
        Me.CLBDatabases.Name = "CLBDatabases"
        Me.CLBDatabases.Size = New System.Drawing.Size(196, 352)
        Me.CLBDatabases.TabIndex = 17
        Me.CLBDatabases.ThreeDCheckBoxes = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 102)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(16, 19)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Check For Update"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(288, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "connect."
        '
        'pnlWelcome
        '
        Me.pnlWelcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWelcome.Controls.Add(Me.Panel5)
        Me.pnlWelcome.Controls.Add(Me.Label3)
        Me.pnlWelcome.Controls.Add(Me.PictureBox5)
        Me.pnlWelcome.Location = New System.Drawing.Point(229, 8)
        Me.pnlWelcome.Name = "pnlWelcome"
        Me.pnlWelcome.Size = New System.Drawing.Size(590, 464)
        Me.pnlWelcome.TabIndex = 17
        Me.pnlWelcome.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.headerPanel)
        Me.Panel5.Controls.Add(Me.PictureBox4)
        Me.Panel5.Location = New System.Drawing.Point(3, 11)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(579, 46)
        Me.Panel5.TabIndex = 36
        '
        'headerPanel
        '
        Me.headerPanel.BackColor = System.Drawing.Color.DarkRed
        Me.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.headerPanel.Controls.Add(Me.Label1)
        Me.headerPanel.Location = New System.Drawing.Point(8, 3)
        Me.headerPanel.Name = "headerPanel"
        Me.headerPanel.Size = New System.Drawing.Size(515, 40)
        Me.headerPanel.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(223, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 22)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Welcome"
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
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.EmaxManager.My.Resources.Resources.checkmark1
        Me.PictureBox5.Location = New System.Drawing.Point(253, 253)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 23
        Me.PictureBox5.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Location = New System.Drawing.Point(734, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(74, 22)
        Me.Panel6.TabIndex = 28
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DarkGray
        Me.Panel9.Location = New System.Drawing.Point(48, 2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(17, 18)
        Me.Panel9.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel8.Location = New System.Drawing.Point(27, 2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(17, 18)
        Me.Panel8.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Panel7.Location = New System.Drawing.Point(6, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(17, 18)
        Me.Panel7.TabIndex = 0
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(826, 518)
        Me.Controls.Add(Me.pnlWelcome)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button3)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximumSize = New System.Drawing.Size(842, 557)
        Me.MinimumSize = New System.Drawing.Size(642, 557)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-Max - Database Manager V6.0"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelWelcome2.ResumeLayout(False)
        Me.panelWelcome2.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlWelcome.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.headerPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CLBDatabases As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbLog As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    'Friend WithEvents MdiClientController1 As Slusser.Components.MdiClientController
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents pnlWelcome As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents tbDeletePass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents panelWelcome2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents chkHide As System.Windows.Forms.CheckBox
 
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents headerPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel

End Class
