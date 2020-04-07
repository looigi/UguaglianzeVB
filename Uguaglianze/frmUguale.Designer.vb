<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUguale
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblPrima = New System.Windows.Forms.Label()
        Me.lblSeconda = New System.Windows.Forms.Label()
        Me.txtNuovoNome = New System.Windows.Forms.TextBox()
        Me.lblRitorno = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdRinomina = New System.Windows.Forms.Button()
        Me.cmdSovrascrivi = New System.Windows.Forms.Button()
        Me.cmdAnnulla = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(208, 218)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(242, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(208, 218)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'lblPrima
        '
        Me.lblPrima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrima.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrima.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPrima.Location = New System.Drawing.Point(12, 234)
        Me.lblPrima.Name = "lblPrima"
        Me.lblPrima.Size = New System.Drawing.Size(209, 88)
        Me.lblPrima.TabIndex = 2
        Me.lblPrima.Text = "Label1"
        '
        'lblSeconda
        '
        Me.lblSeconda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSeconda.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeconda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSeconda.Location = New System.Drawing.Point(242, 234)
        Me.lblSeconda.Name = "lblSeconda"
        Me.lblSeconda.Size = New System.Drawing.Size(209, 88)
        Me.lblSeconda.TabIndex = 3
        Me.lblSeconda.Text = "Label1"
        '
        'txtNuovoNome
        '
        Me.txtNuovoNome.Location = New System.Drawing.Point(242, 326)
        Me.txtNuovoNome.Name = "txtNuovoNome"
        Me.txtNuovoNome.Size = New System.Drawing.Size(208, 20)
        Me.txtNuovoNome.TabIndex = 4
        '
        'lblRitorno
        '
        Me.lblRitorno.AutoSize = True
        Me.lblRitorno.Location = New System.Drawing.Point(210, 9)
        Me.lblRitorno.Name = "lblRitorno"
        Me.lblRitorno.Size = New System.Drawing.Size(39, 13)
        Me.lblRitorno.TabIndex = 5
        Me.lblRitorno.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label2.Location = New System.Drawing.Point(145, 327)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 19)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Nuovo Nome"
        '
        'cmdRinomina
        '
        Me.cmdRinomina.Location = New System.Drawing.Point(116, 358)
        Me.cmdRinomina.Name = "cmdRinomina"
        Me.cmdRinomina.Size = New System.Drawing.Size(75, 23)
        Me.cmdRinomina.TabIndex = 36
        Me.cmdRinomina.Text = "Rinomina"
        Me.cmdRinomina.UseVisualStyleBackColor = True
        '
        'cmdSovrascrivi
        '
        Me.cmdSovrascrivi.Location = New System.Drawing.Point(255, 358)
        Me.cmdSovrascrivi.Name = "cmdSovrascrivi"
        Me.cmdSovrascrivi.Size = New System.Drawing.Size(75, 23)
        Me.cmdSovrascrivi.TabIndex = 37
        Me.cmdSovrascrivi.Text = "Sovrascrivi"
        Me.cmdSovrascrivi.UseVisualStyleBackColor = True
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(375, 358)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(75, 23)
        Me.cmdAnnulla.TabIndex = 38
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.UseVisualStyleBackColor = True
        '
        'frmUguale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 393)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdAnnulla)
        Me.Controls.Add(Me.cmdSovrascrivi)
        Me.Controls.Add(Me.cmdRinomina)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRitorno)
        Me.Controls.Add(Me.txtNuovoNome)
        Me.Controls.Add(Me.lblSeconda)
        Me.Controls.Add(Me.lblPrima)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmUguale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Immagine uguale"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblPrima As Label
    Friend WithEvents lblSeconda As Label
    Friend WithEvents txtNuovoNome As TextBox
    Friend WithEvents lblRitorno As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdRinomina As Button
    Friend WithEvents cmdSovrascrivi As Button
    Friend WithEvents cmdAnnulla As Button
End Class
