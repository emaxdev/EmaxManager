<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class restore
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
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbDatabaseName = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnGetPowers = New System.Windows.Forms.Button()
        Me.lblPower = New System.Windows.Forms.Label()
        Me.cbPowerSetups = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbRstrFileLoc = New System.Windows.Forms.TextBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbRstrLoc = New System.Windows.Forms.TextBox()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.headerPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(11, 426)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(568, 27)
        Me.Button13.TabIndex = 7
        Me.Button13.Text = "Back"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(11, 390)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(568, 27)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "Restore"
        Me.Button8.UseVisualStyleBackColor = True
        '
  
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.tbDatabaseName)
        Me.Panel1.Location = New System.Drawing.Point(11, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 40)
        Me.Panel1.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 23)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "New DB Name:"
        '
        'tbDatabaseName
        '
        Me.tbDatabaseName.BackColor = System.Drawing.Color.White
        Me.tbDatabaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDatabaseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatabaseName.Location = New System.Drawing.Point(171, 9)
        Me.tbDatabaseName.Name = "tbDatabaseName"
        Me.tbDatabaseName.Size = New System.Drawing.Size(385, 22)
        Me.tbDatabaseName.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnGetPowers)
        Me.Panel2.Controls.Add(Me.lblPower)
        Me.Panel2.Controls.Add(Me.cbPowerSetups)
        Me.Panel2.Location = New System.Drawing.Point(11, 162)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(568, 40)
        Me.Panel2.TabIndex = 27
        '
        'btnGetPowers
        '
        Me.btnGetPowers.Location = New System.Drawing.Point(7, 3)
        Me.btnGetPowers.Name = "btnGetPowers"
        Me.btnGetPowers.Size = New System.Drawing.Size(552, 31)
        Me.btnGetPowers.TabIndex = 28
        Me.btnGetPowers.Text = "Get Power Setups"
        Me.btnGetPowers.UseVisualStyleBackColor = True
        '
        'lblPower
        '
        Me.lblPower.AutoSize = True
        Me.lblPower.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPower.Location = New System.Drawing.Point(8, 9)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(108, 23)
        Me.lblPower.TabIndex = 27
        Me.lblPower.Text = "Power Setup"
        Me.lblPower.Visible = False
        '
        'cbPowerSetups
        '
        Me.cbPowerSetups.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPowerSetups.FormattingEnabled = True
        Me.cbPowerSetups.Location = New System.Drawing.Point(171, 10)
        Me.cbPowerSetups.Name = "cbPowerSetups"
        Me.cbPowerSetups.Size = New System.Drawing.Size(385, 24)
        Me.cbPowerSetups.TabIndex = 26
        Me.cbPowerSetups.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.tbRstrFileLoc)
        Me.Panel3.Controls.Add(Me.Button14)
        Me.Panel3.Location = New System.Drawing.Point(11, 225)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(568, 40)
        Me.Panel3.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 23)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Back-Up File:"
        '
        'tbRstrFileLoc
        '
        Me.tbRstrFileLoc.AccessibleDescription = "1"
        Me.tbRstrFileLoc.BackColor = System.Drawing.Color.White
        Me.tbRstrFileLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbRstrFileLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRstrFileLoc.Location = New System.Drawing.Point(171, 8)
        Me.tbRstrFileLoc.Name = "tbRstrFileLoc"
        Me.tbRstrFileLoc.Size = New System.Drawing.Size(339, 22)
        Me.tbRstrFileLoc.TabIndex = 15
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(520, 7)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(36, 24)
        Me.Button14.TabIndex = 16
        Me.Button14.Text = "..."
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.tbRstrLoc)
        Me.Panel4.Controls.Add(Me.Button15)
        Me.Panel4.Location = New System.Drawing.Point(11, 290)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(568, 40)
        Me.Panel4.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 23)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Restore Location:"
        '
        'tbRstrLoc
        '
        Me.tbRstrLoc.BackColor = System.Drawing.Color.White
        Me.tbRstrLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbRstrLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRstrLoc.Location = New System.Drawing.Point(171, 8)
        Me.tbRstrLoc.Name = "tbRstrLoc"
        Me.tbRstrLoc.Size = New System.Drawing.Size(339, 22)
        Me.tbRstrLoc.TabIndex = 20
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(520, 8)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(36, 24)
        Me.Button15.TabIndex = 21
        Me.Button15.Text = "..."
        Me.Button15.UseVisualStyleBackColor = True
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
        Me.Label1.Location = New System.Drawing.Point(223, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 22)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Restore Database"
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
        'restore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(588, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(229, 8)
        Me.MaximumSize = New System.Drawing.Size(590, 464)
        Me.Name = "restore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.headerPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnGetPowers As System.Windows.Forms.Button
    Friend WithEvents lblPower As System.Windows.Forms.Label
    Friend WithEvents cbPowerSetups As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbRstrFileLoc As System.Windows.Forms.TextBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbRstrLoc As System.Windows.Forms.TextBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents headerPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
End Class
