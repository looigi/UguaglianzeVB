<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShow))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlTasti = New System.Windows.Forms.Panel()
        Me.pnlTasti5 = New System.Windows.Forms.Panel()
        Me.cmdCentra = New System.Windows.Forms.Button()
        Me.cmdSpostaSin = New System.Windows.Forms.Button()
        Me.cmdSpostaDes = New System.Windows.Forms.Button()
        Me.cmdSpostaGiu = New System.Windows.Forms.Button()
        Me.cmdSpostaSu = New System.Windows.Forms.Button()
        Me.pnlTasti4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdFiltro = New System.Windows.Forms.Button()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.cmdFiltra = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdRuotaVer = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdRuotaHor = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdRinomina = New System.Windows.Forms.Button()
        Me.cmdSposta = New System.Windows.Forms.Button()
        Me.cmdNuovaCategoria = New System.Windows.Forms.Button()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.cmdRuotaSx = New System.Windows.Forms.Button()
        Me.cmdRuotaDx = New System.Windows.Forms.Button()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.lstExif = New System.Windows.Forms.ListBox()
        Me.pnlTasti3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optTuttoSchermo = New System.Windows.Forms.RadioButton()
        Me.optAdatta = New System.Windows.Forms.RadioButton()
        Me.pnlTasti2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optSequenziale = New System.Windows.Forms.RadioButton()
        Me.optRandom = New System.Windows.Forms.RadioButton()
        Me.cmdOperazioni = New System.Windows.Forms.Button()
        Me.pnlFiltro = New System.Windows.Forms.Panel()
        Me.lblFiltro2 = New System.Windows.Forms.Label()
        Me.cmdApplicafiltro = New System.Windows.Forms.Button()
        Me.txtTesto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbDirectory = New System.Windows.Forms.ComboBox()
        Me.cmdChiudeFiltro = New System.Windows.Forms.Button()
        Me.lblSimili = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTasti.SuspendLayout()
        Me.pnlTasti5.SuspendLayout()
        Me.pnlTasti4.SuspendLayout()
        Me.pnlTasti3.SuspendLayout()
        Me.pnlTasti2.SuspendLayout()
        Me.pnlFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Enabled = False
        Me.PictureBox1.Location = New System.Drawing.Point(31, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(227, 163)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'pnlTasti
        '
        Me.pnlTasti.AutoScroll = True
        Me.pnlTasti.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlTasti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTasti.Controls.Add(Me.pnlTasti5)
        Me.pnlTasti.Controls.Add(Me.pnlTasti4)
        Me.pnlTasti.Controls.Add(Me.lstExif)
        Me.pnlTasti.Controls.Add(Me.pnlTasti3)
        Me.pnlTasti.Controls.Add(Me.pnlTasti2)
        Me.pnlTasti.Location = New System.Drawing.Point(12, 89)
        Me.pnlTasti.Name = "pnlTasti"
        Me.pnlTasti.Size = New System.Drawing.Size(879, 105)
        Me.pnlTasti.TabIndex = 46
        '
        'pnlTasti5
        '
        Me.pnlTasti5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTasti5.Controls.Add(Me.cmdCentra)
        Me.pnlTasti5.Controls.Add(Me.cmdSpostaSin)
        Me.pnlTasti5.Controls.Add(Me.cmdSpostaDes)
        Me.pnlTasti5.Controls.Add(Me.cmdSpostaGiu)
        Me.pnlTasti5.Controls.Add(Me.cmdSpostaSu)
        Me.pnlTasti5.Location = New System.Drawing.Point(72, 2)
        Me.pnlTasti5.Name = "pnlTasti5"
        Me.pnlTasti5.Size = New System.Drawing.Size(112, 79)
        Me.pnlTasti5.TabIndex = 50
        '
        'cmdCentra
        '
        Me.cmdCentra.Location = New System.Drawing.Point(41, 28)
        Me.cmdCentra.Name = "cmdCentra"
        Me.cmdCentra.Size = New System.Drawing.Size(29, 23)
        Me.cmdCentra.TabIndex = 4
        Me.cmdCentra.Text = "X"
        Me.cmdCentra.UseVisualStyleBackColor = True
        '
        'cmdSpostaSin
        '
        Me.cmdSpostaSin.Location = New System.Drawing.Point(6, 28)
        Me.cmdSpostaSin.Name = "cmdSpostaSin"
        Me.cmdSpostaSin.Size = New System.Drawing.Size(29, 23)
        Me.cmdSpostaSin.TabIndex = 3
        Me.cmdSpostaSin.Text = "<"
        Me.cmdSpostaSin.UseVisualStyleBackColor = True
        '
        'cmdSpostaDes
        '
        Me.cmdSpostaDes.Location = New System.Drawing.Point(76, 28)
        Me.cmdSpostaDes.Name = "cmdSpostaDes"
        Me.cmdSpostaDes.Size = New System.Drawing.Size(29, 23)
        Me.cmdSpostaDes.TabIndex = 2
        Me.cmdSpostaDes.Text = ">"
        Me.cmdSpostaDes.UseVisualStyleBackColor = True
        '
        'cmdSpostaGiu
        '
        Me.cmdSpostaGiu.Location = New System.Drawing.Point(41, 52)
        Me.cmdSpostaGiu.Name = "cmdSpostaGiu"
        Me.cmdSpostaGiu.Size = New System.Drawing.Size(29, 23)
        Me.cmdSpostaGiu.TabIndex = 1
        Me.cmdSpostaGiu.Text = "\/"
        Me.cmdSpostaGiu.UseVisualStyleBackColor = True
        '
        'cmdSpostaSu
        '
        Me.cmdSpostaSu.Location = New System.Drawing.Point(41, 4)
        Me.cmdSpostaSu.Name = "cmdSpostaSu"
        Me.cmdSpostaSu.Size = New System.Drawing.Size(29, 23)
        Me.cmdSpostaSu.TabIndex = 0
        Me.cmdSpostaSu.Text = "/\"
        Me.cmdSpostaSu.UseVisualStyleBackColor = True
        '
        'pnlTasti4
        '
        Me.pnlTasti4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTasti4.Controls.Add(Me.Label9)
        Me.pnlTasti4.Controls.Add(Me.cmdFiltro)
        Me.pnlTasti4.Controls.Add(Me.lblFiltro)
        Me.pnlTasti4.Controls.Add(Me.cmdFiltra)
        Me.pnlTasti4.Controls.Add(Me.Label8)
        Me.pnlTasti4.Controls.Add(Me.cmdRuotaVer)
        Me.pnlTasti4.Controls.Add(Me.Label7)
        Me.pnlTasti4.Controls.Add(Me.cmdRuotaHor)
        Me.pnlTasti4.Controls.Add(Me.Label6)
        Me.pnlTasti4.Controls.Add(Me.Label5)
        Me.pnlTasti4.Controls.Add(Me.Label4)
        Me.pnlTasti4.Controls.Add(Me.Label3)
        Me.pnlTasti4.Controls.Add(Me.cmdRinomina)
        Me.pnlTasti4.Controls.Add(Me.cmdSposta)
        Me.pnlTasti4.Controls.Add(Me.cmdNuovaCategoria)
        Me.pnlTasti4.Controls.Add(Me.lblCategoria)
        Me.pnlTasti4.Controls.Add(Me.cmbCategoria)
        Me.pnlTasti4.Controls.Add(Me.cmdRuotaSx)
        Me.pnlTasti4.Controls.Add(Me.cmdRuotaDx)
        Me.pnlTasti4.Controls.Add(Me.cmdElimina)
        Me.pnlTasti4.Location = New System.Drawing.Point(231, 3)
        Me.pnlTasti4.Name = "pnlTasti4"
        Me.pnlTasti4.Size = New System.Drawing.Size(560, 79)
        Me.pnlTasti4.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(319, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 15)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Filtro"
        '
        'cmdFiltro
        '
        Me.cmdFiltro.Image = CType(resources.GetObject("cmdFiltro.Image"), System.Drawing.Image)
        Me.cmdFiltro.Location = New System.Drawing.Point(317, 6)
        Me.cmdFiltro.Name = "cmdFiltro"
        Me.cmdFiltro.Size = New System.Drawing.Size(47, 53)
        Me.cmdFiltro.TabIndex = 60
        Me.cmdFiltro.UseVisualStyleBackColor = True
        '
        'lblFiltro
        '
        Me.lblFiltro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltro.ForeColor = System.Drawing.Color.Olive
        Me.lblFiltro.Location = New System.Drawing.Point(367, 6)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(116, 20)
        Me.lblFiltro.TabIndex = 59
        Me.lblFiltro.Text = "Categoria"
        '
        'cmdFiltra
        '
        Me.cmdFiltra.Image = CType(resources.GetObject("cmdFiltra.Image"), System.Drawing.Image)
        Me.cmdFiltra.Location = New System.Drawing.Point(489, 6)
        Me.cmdFiltra.Name = "cmdFiltra"
        Me.cmdFiltra.Size = New System.Drawing.Size(37, 40)
        Me.cmdFiltra.TabIndex = 58
        Me.cmdFiltra.Text = "*"
        Me.cmdFiltra.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(268, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "R. Ver."
        '
        'cmdRuotaVer
        '
        Me.cmdRuotaVer.Image = CType(resources.GetObject("cmdRuotaVer.Image"), System.Drawing.Image)
        Me.cmdRuotaVer.Location = New System.Drawing.Point(268, 6)
        Me.cmdRuotaVer.Name = "cmdRuotaVer"
        Me.cmdRuotaVer.Size = New System.Drawing.Size(47, 53)
        Me.cmdRuotaVer.TabIndex = 56
        Me.cmdRuotaVer.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(215, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "R. Hor."
        '
        'cmdRuotaHor
        '
        Me.cmdRuotaHor.Image = CType(resources.GetObject("cmdRuotaHor.Image"), System.Drawing.Image)
        Me.cmdRuotaHor.Location = New System.Drawing.Point(215, 6)
        Me.cmdRuotaHor.Name = "cmdRuotaHor"
        Me.cmdRuotaHor.Size = New System.Drawing.Size(47, 53)
        Me.cmdRuotaHor.TabIndex = 54
        Me.cmdRuotaHor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(166, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "R. DX"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(113, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 15)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "R. SX"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(56, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Rinom."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(1, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Elimina"
        '
        'cmdRinomina
        '
        Me.cmdRinomina.Image = CType(resources.GetObject("cmdRinomina.Image"), System.Drawing.Image)
        Me.cmdRinomina.Location = New System.Drawing.Point(56, 6)
        Me.cmdRinomina.Name = "cmdRinomina"
        Me.cmdRinomina.Size = New System.Drawing.Size(47, 53)
        Me.cmdRinomina.TabIndex = 48
        Me.cmdRinomina.UseVisualStyleBackColor = True
        '
        'cmdSposta
        '
        Me.cmdSposta.Location = New System.Drawing.Point(535, 50)
        Me.cmdSposta.Name = "cmdSposta"
        Me.cmdSposta.Size = New System.Drawing.Size(20, 23)
        Me.cmdSposta.TabIndex = 47
        Me.cmdSposta.Text = ">"
        Me.cmdSposta.UseVisualStyleBackColor = True
        '
        'cmdNuovaCategoria
        '
        Me.cmdNuovaCategoria.Location = New System.Drawing.Point(535, 27)
        Me.cmdNuovaCategoria.Name = "cmdNuovaCategoria"
        Me.cmdNuovaCategoria.Size = New System.Drawing.Size(20, 23)
        Me.cmdNuovaCategoria.TabIndex = 46
        Me.cmdNuovaCategoria.Text = "*"
        Me.cmdNuovaCategoria.UseVisualStyleBackColor = True
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblCategoria.Location = New System.Drawing.Point(367, 30)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(72, 16)
        Me.lblCategoria.TabIndex = 45
        Me.lblCategoria.Text = "Categoria"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(370, 50)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(156, 24)
        Me.cmbCategoria.TabIndex = 44
        '
        'cmdRuotaSx
        '
        Me.cmdRuotaSx.Image = CType(resources.GetObject("cmdRuotaSx.Image"), System.Drawing.Image)
        Me.cmdRuotaSx.Location = New System.Drawing.Point(109, 6)
        Me.cmdRuotaSx.Name = "cmdRuotaSx"
        Me.cmdRuotaSx.Size = New System.Drawing.Size(47, 53)
        Me.cmdRuotaSx.TabIndex = 43
        Me.cmdRuotaSx.UseVisualStyleBackColor = True
        '
        'cmdRuotaDx
        '
        Me.cmdRuotaDx.Image = CType(resources.GetObject("cmdRuotaDx.Image"), System.Drawing.Image)
        Me.cmdRuotaDx.Location = New System.Drawing.Point(162, 6)
        Me.cmdRuotaDx.Name = "cmdRuotaDx"
        Me.cmdRuotaDx.Size = New System.Drawing.Size(47, 53)
        Me.cmdRuotaDx.TabIndex = 42
        Me.cmdRuotaDx.UseVisualStyleBackColor = True
        '
        'cmdElimina
        '
        Me.cmdElimina.Image = CType(resources.GetObject("cmdElimina.Image"), System.Drawing.Image)
        Me.cmdElimina.Location = New System.Drawing.Point(3, 6)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.Size = New System.Drawing.Size(47, 53)
        Me.cmdElimina.TabIndex = 41
        Me.cmdElimina.UseVisualStyleBackColor = True
        '
        'lstExif
        '
        Me.lstExif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstExif.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstExif.FormattingEnabled = True
        Me.lstExif.ItemHeight = 16
        Me.lstExif.Location = New System.Drawing.Point(793, 2)
        Me.lstExif.Name = "lstExif"
        Me.lstExif.Size = New System.Drawing.Size(150, 82)
        Me.lstExif.TabIndex = 49
        '
        'pnlTasti3
        '
        Me.pnlTasti3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTasti3.Controls.Add(Me.Label2)
        Me.pnlTasti3.Controls.Add(Me.optTuttoSchermo)
        Me.pnlTasti3.Controls.Add(Me.optAdatta)
        Me.pnlTasti3.Location = New System.Drawing.Point(117, 3)
        Me.pnlTasti3.Name = "pnlTasti3"
        Me.pnlTasti3.Size = New System.Drawing.Size(108, 79)
        Me.pnlTasti3.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Formato"
        '
        'optTuttoSchermo
        '
        Me.optTuttoSchermo.AutoSize = True
        Me.optTuttoSchermo.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTuttoSchermo.Location = New System.Drawing.Point(4, 39)
        Me.optTuttoSchermo.Name = "optTuttoSchermo"
        Me.optTuttoSchermo.Size = New System.Drawing.Size(52, 20)
        Me.optTuttoSchermo.TabIndex = 48
        Me.optTuttoSchermo.TabStop = True
        Me.optTuttoSchermo.Text = "Adatta"
        Me.optTuttoSchermo.UseVisualStyleBackColor = True
        '
        'optAdatta
        '
        Me.optAdatta.AutoSize = True
        Me.optAdatta.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optAdatta.Location = New System.Drawing.Point(4, 16)
        Me.optAdatta.Name = "optAdatta"
        Me.optAdatta.Size = New System.Drawing.Size(62, 20)
        Me.optAdatta.TabIndex = 47
        Me.optAdatta.TabStop = True
        Me.optAdatta.Text = "Normale"
        Me.optAdatta.UseVisualStyleBackColor = True
        '
        'pnlTasti2
        '
        Me.pnlTasti2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTasti2.Controls.Add(Me.lblSimili)
        Me.pnlTasti2.Controls.Add(Me.Label1)
        Me.pnlTasti2.Controls.Add(Me.optSequenziale)
        Me.pnlTasti2.Controls.Add(Me.optRandom)
        Me.pnlTasti2.Location = New System.Drawing.Point(3, 3)
        Me.pnlTasti2.Name = "pnlTasti2"
        Me.pnlTasti2.Size = New System.Drawing.Size(108, 79)
        Me.pnlTasti2.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Visualizzazione"
        '
        'optSequenziale
        '
        Me.optSequenziale.AutoSize = True
        Me.optSequenziale.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSequenziale.Location = New System.Drawing.Point(4, 32)
        Me.optSequenziale.Name = "optSequenziale"
        Me.optSequenziale.Size = New System.Drawing.Size(77, 20)
        Me.optSequenziale.TabIndex = 1
        Me.optSequenziale.TabStop = True
        Me.optSequenziale.Text = "Sequenziale"
        Me.optSequenziale.UseVisualStyleBackColor = True
        '
        'optRandom
        '
        Me.optRandom.AutoSize = True
        Me.optRandom.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRandom.Location = New System.Drawing.Point(4, 16)
        Me.optRandom.Name = "optRandom"
        Me.optRandom.Size = New System.Drawing.Size(61, 20)
        Me.optRandom.TabIndex = 0
        Me.optRandom.TabStop = True
        Me.optRandom.Text = "Random"
        Me.optRandom.UseVisualStyleBackColor = True
        '
        'cmdOperazioni
        '
        Me.cmdOperazioni.Location = New System.Drawing.Point(87, 13)
        Me.cmdOperazioni.Name = "cmdOperazioni"
        Me.cmdOperazioni.Size = New System.Drawing.Size(17, 23)
        Me.cmdOperazioni.TabIndex = 47
        Me.cmdOperazioni.Text = "-"
        Me.cmdOperazioni.UseVisualStyleBackColor = True
        '
        'pnlFiltro
        '
        Me.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltro.Controls.Add(Me.lblFiltro2)
        Me.pnlFiltro.Controls.Add(Me.cmdApplicafiltro)
        Me.pnlFiltro.Controls.Add(Me.txtTesto)
        Me.pnlFiltro.Controls.Add(Me.Label11)
        Me.pnlFiltro.Controls.Add(Me.Label10)
        Me.pnlFiltro.Controls.Add(Me.cmbDirectory)
        Me.pnlFiltro.Controls.Add(Me.cmdChiudeFiltro)
        Me.pnlFiltro.Location = New System.Drawing.Point(301, 49)
        Me.pnlFiltro.Name = "pnlFiltro"
        Me.pnlFiltro.Size = New System.Drawing.Size(297, 157)
        Me.pnlFiltro.TabIndex = 50
        '
        'lblFiltro2
        '
        Me.lblFiltro2.AutoSize = True
        Me.lblFiltro2.Location = New System.Drawing.Point(3, 3)
        Me.lblFiltro2.Name = "lblFiltro2"
        Me.lblFiltro2.Size = New System.Drawing.Size(45, 13)
        Me.lblFiltro2.TabIndex = 50
        Me.lblFiltro2.Text = "Label12"
        Me.lblFiltro2.Visible = False
        '
        'cmdApplicafiltro
        '
        Me.cmdApplicafiltro.Image = CType(resources.GetObject("cmdApplicafiltro.Image"), System.Drawing.Image)
        Me.cmdApplicafiltro.Location = New System.Drawing.Point(248, 108)
        Me.cmdApplicafiltro.Name = "cmdApplicafiltro"
        Me.cmdApplicafiltro.Size = New System.Drawing.Size(42, 39)
        Me.cmdApplicafiltro.TabIndex = 49
        Me.cmdApplicafiltro.UseVisualStyleBackColor = True
        '
        'txtTesto
        '
        Me.txtTesto.Location = New System.Drawing.Point(81, 79)
        Me.txtTesto.Name = "txtTesto"
        Me.txtTesto.Size = New System.Drawing.Size(209, 20)
        Me.txtTesto.TabIndex = 48
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(3, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Testo"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(3, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 21)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Directory"
        '
        'cmbDirectory
        '
        Me.cmbDirectory.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDirectory.FormattingEnabled = True
        Me.cmbDirectory.Location = New System.Drawing.Point(79, 49)
        Me.cmbDirectory.Name = "cmbDirectory"
        Me.cmbDirectory.Size = New System.Drawing.Size(211, 24)
        Me.cmbDirectory.TabIndex = 45
        '
        'cmdChiudeFiltro
        '
        Me.cmdChiudeFiltro.Image = CType(resources.GetObject("cmdChiudeFiltro.Image"), System.Drawing.Image)
        Me.cmdChiudeFiltro.Location = New System.Drawing.Point(248, 3)
        Me.cmdChiudeFiltro.Name = "cmdChiudeFiltro"
        Me.cmdChiudeFiltro.Size = New System.Drawing.Size(42, 39)
        Me.cmdChiudeFiltro.TabIndex = 42
        Me.cmdChiudeFiltro.UseVisualStyleBackColor = True
        '
        'lblSimili
        '
        Me.lblSimili.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSimili.ForeColor = System.Drawing.Color.Olive
        Me.lblSimili.Location = New System.Drawing.Point(3, 54)
        Me.lblSimili.Name = "lblSimili"
        Me.lblSimili.Size = New System.Drawing.Size(116, 20)
        Me.lblSimili.TabIndex = 60
        Me.lblSimili.Text = "Categoria"
        '
        'frmShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(903, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlFiltro)
        Me.Controls.Add(Me.cmdOperazioni)
        Me.Controls.Add(Me.pnlTasti)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmShow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTasti.ResumeLayout(False)
        Me.pnlTasti5.ResumeLayout(False)
        Me.pnlTasti4.ResumeLayout(False)
        Me.pnlTasti4.PerformLayout()
        Me.pnlTasti3.ResumeLayout(False)
        Me.pnlTasti3.PerformLayout()
        Me.pnlTasti2.ResumeLayout(False)
        Me.pnlTasti2.PerformLayout()
        Me.pnlFiltro.ResumeLayout(False)
        Me.pnlFiltro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlTasti As System.Windows.Forms.Panel
    Friend WithEvents pnlTasti2 As System.Windows.Forms.Panel
    Friend WithEvents optSequenziale As System.Windows.Forms.RadioButton
    Friend WithEvents optRandom As System.Windows.Forms.RadioButton
    Friend WithEvents cmdOperazioni As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optTuttoSchermo As System.Windows.Forms.RadioButton
    Friend WithEvents optAdatta As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTasti3 As System.Windows.Forms.Panel
    Friend WithEvents pnlTasti4 As System.Windows.Forms.Panel
    Friend WithEvents cmdElimina As System.Windows.Forms.Button
    Friend WithEvents cmdRuotaDx As System.Windows.Forms.Button
    Friend WithEvents cmdRuotaSx As System.Windows.Forms.Button
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents cmdNuovaCategoria As System.Windows.Forms.Button
    Friend WithEvents cmdSposta As System.Windows.Forms.Button
    Friend WithEvents lstExif As System.Windows.Forms.ListBox
    Friend WithEvents cmdRinomina As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlTasti5 As System.Windows.Forms.Panel
    Friend WithEvents cmdSpostaSin As System.Windows.Forms.Button
    Friend WithEvents cmdSpostaDes As System.Windows.Forms.Button
    Friend WithEvents cmdSpostaGiu As System.Windows.Forms.Button
    Friend WithEvents cmdSpostaSu As System.Windows.Forms.Button
    Friend WithEvents cmdCentra As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdRuotaVer As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdRuotaHor As System.Windows.Forms.Button
    Friend WithEvents cmdFiltra As System.Windows.Forms.Button
    Friend WithEvents lblFiltro As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdFiltro As System.Windows.Forms.Button
    Friend WithEvents pnlFiltro As System.Windows.Forms.Panel
    Friend WithEvents cmdChiudeFiltro As System.Windows.Forms.Button
    Friend WithEvents cmdApplicafiltro As System.Windows.Forms.Button
    Friend WithEvents txtTesto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbDirectory As System.Windows.Forms.ComboBox
    Friend WithEvents lblFiltro2 As System.Windows.Forms.Label
    Friend WithEvents lblSimili As System.Windows.Forms.Label
End Class
