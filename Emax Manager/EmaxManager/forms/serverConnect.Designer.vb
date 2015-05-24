<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class serverConnect
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
        Me.cbRemeberPassword = New System.Windows.Forms.CheckBox()
     
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.serverCombo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.headerPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbRemeberPassword
        '
        Me.cbRemeberPassword.AutoSize = True
        Me.cbRemeberPassword.Location = New System.Drawing.Point(234, 327)
        Me.cbRemeberPassword.Name = "cbRemeberPassword"
        Me.cbRemeberPassword.Size = New System.Drawing.Size(126, 17)
        Me.cbRemeberPassword.TabIndex = 3
        Me.cbRemeberPassword.Text = "Remember Password"
        Me.cbRemeberPassword.UseVisualStyleBackColor = True
        '
 
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.serverCombo)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Location = New System.Drawing.Point(11, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 38)
        Me.Panel1.TabIndex = 27
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.EmaxManager.My.Resources.Resources.repeat1
        Me.PictureBox1.Location = New System.Drawing.Point(530, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'serverCombo
        '
        Me.serverCombo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serverCombo.FormattingEnabled = True
        Me.serverCombo.Location = New System.Drawing.Point(118, 7)
        Me.serverCombo.Name = "serverCombo"
        Me.serverCombo.Size = New System.Drawing.Size(394, 24)
        Me.serverCombo.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 23)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "SQL Server:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtUsername)
        Me.Panel2.Location = New System.Drawing.Point(11, 174)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(568, 38)
        Me.Panel2.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 23)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(118, 8)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(438, 22)
        Me.txtUsername.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtPassword)
        Me.Panel3.Location = New System.Drawing.Point(11, 242)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(568, 38)
        Me.Panel3.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 23)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(118, 7)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(438, 22)
        Me.txtPassword.TabIndex = 5
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
        Me.Label1.Location = New System.Drawing.Point(210, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 22)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Connect To Server"
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
        Me.PictureBox5.Location = New System.Drawing.Point(277, 394)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 28)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 38
        Me.PictureBox5.TabStop = False
        '
        'serverConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(588, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbRemeberPassword)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(229, 8)
        Me.MaximumSize = New System.Drawing.Size(590, 464)
        Me.Name = "serverConnect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.headerPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbRemeberPassword As System.Windows.Forms.CheckBox
  
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents serverCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents headerPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
End Class
