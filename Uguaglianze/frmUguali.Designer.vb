<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUguali
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlUguali = New System.Windows.Forms.Panel()
        Me.cmdCopiaASinistra = New System.Windows.Forms.Button()
        Me.cmdCopiaADestra = New System.Windows.Forms.Button()
        Me.lblEliminata = New System.Windows.Forms.Label()
        Me.cmdEliminaSinistra = New System.Windows.Forms.Button()
        Me.cmdIndietro = New System.Windows.Forms.Button()
        Me.cmdEliminaDestra = New System.Windows.Forms.Button()
        Me.cmdAvanti = New System.Windows.Forms.Button()
        Me.lblNomeImm2 = New System.Windows.Forms.Label()
        Me.lblNomeImm1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMetodo = New System.Windows.Forms.Label()
        Me.lblUguali = New System.Windows.Forms.Label()
        Me.cmdElimina2 = New System.Windows.Forms.Button()
        Me.cmdPulisceUguali = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdRicorda = New System.Windows.Forms.Button()
        Me.cmdUscita = New System.Windows.Forms.Button()
        Me.pnlUguali.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlUguali
        '
        Me.pnlUguali.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlUguali.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUguali.Controls.Add(Me.cmdCopiaASinistra)
        Me.pnlUguali.Controls.Add(Me.cmdCopiaADestra)
        Me.pnlUguali.Controls.Add(Me.lblEliminata)
        Me.pnlUguali.Controls.Add(Me.cmdEliminaSinistra)
        Me.pnlUguali.Controls.Add(Me.cmdIndietro)
        Me.pnlUguali.Controls.Add(Me.cmdEliminaDestra)
        Me.pnlUguali.Controls.Add(Me.cmdAvanti)
        Me.pnlUguali.Controls.Add(Me.lblNomeImm2)
        Me.pnlUguali.Controls.Add(Me.lblNomeImm1)
        Me.pnlUguali.Controls.Add(Me.PictureBox2)
        Me.pnlUguali.Controls.Add(Me.PictureBox1)
        Me.pnlUguali.Location = New System.Drawing.Point(12, 34)
        Me.pnlUguali.Name = "pnlUguali"
        Me.pnlUguali.Size = New System.Drawing.Size(794, 486)
        Me.pnlUguali.TabIndex = 16
        '
        'cmdCopiaASinistra
        '
        Me.cmdCopiaASinistra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopiaASinistra.Location = New System.Drawing.Point(547, 3)
        Me.cmdCopiaASinistra.Name = "cmdCopiaASinistra"
        Me.cmdCopiaASinistra.Size = New System.Drawing.Size(44, 23)
        Me.cmdCopiaASinistra.TabIndex = 27
        Me.cmdCopiaASinistra.Text = "<-"
        Me.cmdCopiaASinistra.UseVisualStyleBackColor = True
        '
        'cmdCopiaADestra
        '
        Me.cmdCopiaADestra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopiaADestra.Location = New System.Drawing.Point(186, 3)
        Me.cmdCopiaADestra.Name = "cmdCopiaADestra"
        Me.cmdCopiaADestra.Size = New System.Drawing.Size(44, 23)
        Me.cmdCopiaADestra.TabIndex = 26
        Me.cmdCopiaADestra.Text = "->"
        Me.cmdCopiaADestra.UseVisualStyleBackColor = True
        '
        'lblEliminata
        '
        Me.lblEliminata.AutoSize = True
        Me.lblEliminata.BackColor = System.Drawing.Color.White
        Me.lblEliminata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEliminata.Font = New System.Drawing.Font("Arial", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEliminata.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblEliminata.Location = New System.Drawing.Point(94, 114)
        Me.lblEliminata.Name = "lblEliminata"
        Me.lblEliminata.Size = New System.Drawing.Size(171, 42)
        Me.lblEliminata.TabIndex = 20
        Me.lblEliminata.Text = "Eliminata"
        '
        'cmdEliminaSinistra
        '
        Me.cmdEliminaSinistra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminaSinistra.Location = New System.Drawing.Point(91, 3)
        Me.cmdEliminaSinistra.Name = "cmdEliminaSinistra"
        Me.cmdEliminaSinistra.Size = New System.Drawing.Size(63, 23)
        Me.cmdEliminaSinistra.TabIndex = 19
        Me.cmdEliminaSinistra.Text = "Elimina"
        Me.cmdEliminaSinistra.UseVisualStyleBackColor = True
        '
        'cmdIndietro
        '
        Me.cmdIndietro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIndietro.Location = New System.Drawing.Point(3, 3)
        Me.cmdIndietro.Name = "cmdIndietro"
        Me.cmdIndietro.Size = New System.Drawing.Size(32, 23)
        Me.cmdIndietro.TabIndex = 18
        Me.cmdIndietro.Text = "<<"
        Me.cmdIndietro.UseVisualStyleBackColor = True
        '
        'cmdEliminaDestra
        '
        Me.cmdEliminaDestra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminaDestra.Location = New System.Drawing.Point(638, 3)
        Me.cmdEliminaDestra.Name = "cmdEliminaDestra"
        Me.cmdEliminaDestra.Size = New System.Drawing.Size(63, 23)
        Me.cmdEliminaDestra.TabIndex = 16
        Me.cmdEliminaDestra.Text = "Elimina"
        Me.cmdEliminaDestra.UseVisualStyleBackColor = True
        '
        'cmdAvanti
        '
        Me.cmdAvanti.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAvanti.Location = New System.Drawing.Point(757, 3)
        Me.cmdAvanti.Name = "cmdAvanti"
        Me.cmdAvanti.Size = New System.Drawing.Size(32, 23)
        Me.cmdAvanti.TabIndex = 15
        Me.cmdAvanti.Text = ">>"
        Me.cmdAvanti.UseVisualStyleBackColor = True
        '
        'lblNomeImm2
        '
        Me.lblNomeImm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNomeImm2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeImm2.ForeColor = System.Drawing.Color.Green
        Me.lblNomeImm2.Location = New System.Drawing.Point(413, 417)
        Me.lblNomeImm2.Name = "lblNomeImm2"
        Me.lblNomeImm2.Size = New System.Drawing.Size(227, 64)
        Me.lblNomeImm2.TabIndex = 14
        Me.lblNomeImm2.Text = "Label1"
        '
        'lblNomeImm1
        '
        Me.lblNomeImm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNomeImm1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeImm1.ForeColor = System.Drawing.Color.Green
        Me.lblNomeImm1.Location = New System.Drawing.Point(3, 417)
        Me.lblNomeImm1.Name = "lblNomeImm1"
        Me.lblNomeImm1.Size = New System.Drawing.Size(227, 64)
        Me.lblNomeImm1.TabIndex = 13
        Me.lblNomeImm1.Text = "Label1"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(413, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(227, 163)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(3, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(227, 163)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'lblMetodo
        '
        Me.lblMetodo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMetodo.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMetodo.Location = New System.Drawing.Point(532, 15)
        Me.lblMetodo.Name = "lblMetodo"
        Me.lblMetodo.Size = New System.Drawing.Size(72, 16)
        Me.lblMetodo.TabIndex = 25
        Me.lblMetodo.Text = "Label1"
        '
        'lblUguali
        '
        Me.lblUguali.AutoSize = True
        Me.lblUguali.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUguali.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblUguali.Location = New System.Drawing.Point(13, 15)
        Me.lblUguali.Name = "lblUguali"
        Me.lblUguali.Size = New System.Drawing.Size(47, 16)
        Me.lblUguali.TabIndex = 10
        Me.lblUguali.Text = "Label1"
        '
        'cmdElimina2
        '
        Me.cmdElimina2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdElimina2.Location = New System.Drawing.Point(812, 99)
        Me.cmdElimina2.Name = "cmdElimina2"
        Me.cmdElimina2.Size = New System.Drawing.Size(116, 23)
        Me.cmdElimina2.TabIndex = 28
        Me.cmdElimina2.Text = "Elimina Entrambe"
        Me.cmdElimina2.UseVisualStyleBackColor = True
        '
        'cmdPulisceUguali
        '
        Me.cmdPulisceUguali.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPulisceUguali.Location = New System.Drawing.Point(812, 180)
        Me.cmdPulisceUguali.Name = "cmdPulisceUguali"
        Me.cmdPulisceUguali.Size = New System.Drawing.Size(116, 23)
        Me.cmdPulisceUguali.TabIndex = 24
        Me.cmdPulisceUguali.Text = "Pulisce Tutto"
        Me.cmdPulisceUguali.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(812, 12)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(116, 23)
        Me.cmdUpdate.TabIndex = 21
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdRicorda
        '
        Me.cmdRicorda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRicorda.Location = New System.Drawing.Point(812, 56)
        Me.cmdRicorda.Name = "cmdRicorda"
        Me.cmdRicorda.Size = New System.Drawing.Size(116, 23)
        Me.cmdRicorda.TabIndex = 17
        Me.cmdRicorda.Text = "Ricorda"
        Me.cmdRicorda.UseVisualStyleBackColor = True
        '
        'cmdUscita
        '
        Me.cmdUscita.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUscita.Location = New System.Drawing.Point(812, 261)
        Me.cmdUscita.Name = "cmdUscita"
        Me.cmdUscita.Size = New System.Drawing.Size(116, 23)
        Me.cmdUscita.TabIndex = 29
        Me.cmdUscita.Text = "Uscita"
        Me.cmdUscita.UseVisualStyleBackColor = True
        '
        'frmUguali
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdUscita)
        Me.Controls.Add(Me.cmdElimina2)
        Me.Controls.Add(Me.lblMetodo)
        Me.Controls.Add(Me.pnlUguali)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdRicorda)
        Me.Controls.Add(Me.cmdPulisceUguali)
        Me.Controls.Add(Me.lblUguali)
        Me.Name = "frmUguali"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uguali"
        Me.pnlUguali.ResumeLayout(False)
        Me.pnlUguali.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlUguali As System.Windows.Forms.Panel
    Friend WithEvents cmdElimina2 As System.Windows.Forms.Button
    Friend WithEvents cmdCopiaASinistra As System.Windows.Forms.Button
    Friend WithEvents cmdCopiaADestra As System.Windows.Forms.Button
    Friend WithEvents lblMetodo As System.Windows.Forms.Label
    Friend WithEvents cmdPulisceUguali As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents lblEliminata As System.Windows.Forms.Label
    Friend WithEvents cmdEliminaSinistra As System.Windows.Forms.Button
    Friend WithEvents cmdIndietro As System.Windows.Forms.Button
    Friend WithEvents cmdRicorda As System.Windows.Forms.Button
    Friend WithEvents cmdEliminaDestra As System.Windows.Forms.Button
    Friend WithEvents cmdAvanti As System.Windows.Forms.Button
    Friend WithEvents lblNomeImm2 As System.Windows.Forms.Label
    Friend WithEvents lblNomeImm1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblUguali As System.Windows.Forms.Label
    Friend WithEvents cmdUscita As System.Windows.Forms.Button
End Class
