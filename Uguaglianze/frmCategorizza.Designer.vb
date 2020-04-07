<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategorizza
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
        Me.cmbDate = New System.Windows.Forms.ComboBox()
        Me.lblMetodo = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdSelezionaTutti = New System.Windows.Forms.Button()
        Me.cmdDeSelezTutti = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNumImmagini = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.cmdSposta = New System.Windows.Forms.Button()
        Me.cmdNuovaCategoria = New System.Windows.Forms.Button()
        Me.cmdChiude = New System.Windows.Forms.Button()
        Me.txtRicerca = New System.Windows.Forms.TextBox()
        Me.cmdCarica = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdAvantiData = New System.Windows.Forms.Button()
        Me.cmdIndietroData = New System.Windows.Forms.Button()
        Me.cmdMarchia = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbDate
        '
        Me.cmbDate.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDate.FormattingEnabled = True
        Me.cmbDate.Location = New System.Drawing.Point(47, 10)
        Me.cmbDate.Name = "cmbDate"
        Me.cmbDate.Size = New System.Drawing.Size(156, 24)
        Me.cmbDate.TabIndex = 0
        '
        'lblMetodo
        '
        Me.lblMetodo.AutoSize = True
        Me.lblMetodo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMetodo.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMetodo.Location = New System.Drawing.Point(12, 13)
        Me.lblMetodo.Name = "lblMetodo"
        Me.lblMetodo.Size = New System.Drawing.Size(35, 16)
        Me.lblMetodo.TabIndex = 26
        Me.lblMetodo.Text = "Data"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(13, 44)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(413, 505)
        Me.FlowLayoutPanel1.TabIndex = 27
        '
        'cmdSelezionaTutti
        '
        Me.cmdSelezionaTutti.Location = New System.Drawing.Point(12, 559)
        Me.cmdSelezionaTutti.Name = "cmdSelezionaTutti"
        Me.cmdSelezionaTutti.Size = New System.Drawing.Size(85, 23)
        Me.cmdSelezionaTutti.TabIndex = 28
        Me.cmdSelezionaTutti.Text = "Selez. Tutti"
        Me.cmdSelezionaTutti.UseVisualStyleBackColor = True
        '
        'cmdDeSelezTutti
        '
        Me.cmdDeSelezTutti.Location = New System.Drawing.Point(103, 559)
        Me.cmdDeSelezTutti.Name = "cmdDeSelezTutti"
        Me.cmdDeSelezTutti.Size = New System.Drawing.Size(86, 23)
        Me.cmdDeSelezTutti.TabIndex = 29
        Me.cmdDeSelezTutti.Text = "Deselez. Tutti"
        Me.cmdDeSelezTutti.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(435, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(417, 503)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(587, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Immagini"
        '
        'lblNumImmagini
        '
        Me.lblNumImmagini.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumImmagini.ForeColor = System.Drawing.Color.Blue
        Me.lblNumImmagini.Location = New System.Drawing.Point(656, 15)
        Me.lblNumImmagini.Name = "lblNumImmagini"
        Me.lblNumImmagini.Size = New System.Drawing.Size(72, 16)
        Me.lblNumImmagini.TabIndex = 32
        Me.lblNumImmagini.Text = "Immagini"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label2.Location = New System.Drawing.Point(592, 562)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Categoria"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(670, 558)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(156, 24)
        Me.cmbCategoria.TabIndex = 33
        '
        'cmdElimina
        '
        Me.cmdElimina.Location = New System.Drawing.Point(340, 559)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.Size = New System.Drawing.Size(86, 23)
        Me.cmdElimina.TabIndex = 35
        Me.cmdElimina.Text = "Elimina"
        Me.cmdElimina.UseVisualStyleBackColor = True
        '
        'cmdSposta
        '
        Me.cmdSposta.Location = New System.Drawing.Point(500, 559)
        Me.cmdSposta.Name = "cmdSposta"
        Me.cmdSposta.Size = New System.Drawing.Size(86, 23)
        Me.cmdSposta.TabIndex = 36
        Me.cmdSposta.Text = "Sposta"
        Me.cmdSposta.UseVisualStyleBackColor = True
        '
        'cmdNuovaCategoria
        '
        Me.cmdNuovaCategoria.Location = New System.Drawing.Point(832, 558)
        Me.cmdNuovaCategoria.Name = "cmdNuovaCategoria"
        Me.cmdNuovaCategoria.Size = New System.Drawing.Size(20, 23)
        Me.cmdNuovaCategoria.TabIndex = 37
        Me.cmdNuovaCategoria.Text = "*"
        Me.cmdNuovaCategoria.UseVisualStyleBackColor = True
        '
        'cmdChiude
        '
        Me.cmdChiude.Location = New System.Drawing.Point(766, 12)
        Me.cmdChiude.Name = "cmdChiude"
        Me.cmdChiude.Size = New System.Drawing.Size(86, 23)
        Me.cmdChiude.TabIndex = 38
        Me.cmdChiude.Text = "Chiude"
        Me.cmdChiude.UseVisualStyleBackColor = True
        '
        'txtRicerca
        '
        Me.txtRicerca.Location = New System.Drawing.Point(396, 10)
        Me.txtRicerca.Name = "txtRicerca"
        Me.txtRicerca.Size = New System.Drawing.Size(137, 20)
        Me.txtRicerca.TabIndex = 39
        '
        'cmdCarica
        '
        Me.cmdCarica.Location = New System.Drawing.Point(539, 8)
        Me.cmdCarica.Name = "cmdCarica"
        Me.cmdCarica.Size = New System.Drawing.Size(20, 23)
        Me.cmdCarica.TabIndex = 40
        Me.cmdCarica.Text = ">"
        Me.cmdCarica.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label3.Location = New System.Drawing.Point(348, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Testo"
        '
        'cmdAvantiData
        '
        Me.cmdAvantiData.Location = New System.Drawing.Point(261, 10)
        Me.cmdAvantiData.Name = "cmdAvantiData"
        Me.cmdAvantiData.Size = New System.Drawing.Size(20, 23)
        Me.cmdAvantiData.TabIndex = 42
        Me.cmdAvantiData.Text = ">"
        Me.cmdAvantiData.UseVisualStyleBackColor = True
        '
        'cmdIndietroData
        '
        Me.cmdIndietroData.Location = New System.Drawing.Point(209, 10)
        Me.cmdIndietroData.Name = "cmdIndietroData"
        Me.cmdIndietroData.Size = New System.Drawing.Size(20, 23)
        Me.cmdIndietroData.TabIndex = 43
        Me.cmdIndietroData.Text = "<"
        Me.cmdIndietroData.UseVisualStyleBackColor = True
        '
        'cmdMarchia
        '
        Me.cmdMarchia.Location = New System.Drawing.Point(235, 10)
        Me.cmdMarchia.Name = "cmdMarchia"
        Me.cmdMarchia.Size = New System.Drawing.Size(20, 23)
        Me.cmdMarchia.TabIndex = 44
        Me.cmdMarchia.Text = "D"
        Me.cmdMarchia.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(297, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(20, 23)
        Me.cmdRefresh.TabIndex = 45
        Me.cmdRefresh.Text = "R"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'frmCategorizza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 594)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdMarchia)
        Me.Controls.Add(Me.cmdIndietroData)
        Me.Controls.Add(Me.cmdAvantiData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCarica)
        Me.Controls.Add(Me.txtRicerca)
        Me.Controls.Add(Me.cmdChiude)
        Me.Controls.Add(Me.cmdNuovaCategoria)
        Me.Controls.Add(Me.cmdSposta)
        Me.Controls.Add(Me.cmdElimina)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.lblNumImmagini)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdDeSelezTutti)
        Me.Controls.Add(Me.cmdSelezionaTutti)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.lblMetodo)
        Me.Controls.Add(Me.cmbDate)
        Me.Name = "frmCategorizza"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Categorizza per date"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDate As System.Windows.Forms.ComboBox
    Friend WithEvents lblMetodo As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmdSelezionaTutti As System.Windows.Forms.Button
    Friend WithEvents cmdDeSelezTutti As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNumImmagini As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmdElimina As System.Windows.Forms.Button
    Friend WithEvents cmdSposta As System.Windows.Forms.Button
    Friend WithEvents cmdNuovaCategoria As System.Windows.Forms.Button
    Friend WithEvents cmdChiude As System.Windows.Forms.Button
    Friend WithEvents txtRicerca As System.Windows.Forms.TextBox
    Friend WithEvents cmdCarica As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAvantiData As Button
    Friend WithEvents cmdIndietroData As Button
    Friend WithEvents cmdMarchia As Button
    Friend WithEvents cmdRefresh As Button
End Class
