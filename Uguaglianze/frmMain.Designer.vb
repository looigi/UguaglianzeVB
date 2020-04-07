<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblDirectory = New System.Windows.Forms.Label()
        Me.cmdImpostaDir = New System.Windows.Forms.Button()
        Me.pnlComandi = New System.Windows.Forms.Panel()
        Me.chkNomiLunghi = New System.Windows.Forms.CheckBox()
        Me.chkCreaCRC = New System.Windows.Forms.CheckBox()
        Me.chkCartelleVuote = New System.Windows.Forms.CheckBox()
        Me.chkPulisceCategorie = New System.Windows.Forms.CheckBox()
        Me.chkPulisceDati = New System.Windows.Forms.CheckBox()
        Me.chkPulisceCRC = New System.Windows.Forms.CheckBox()
        Me.chkPulisceUguali = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdImpostaAgg = New System.Windows.Forms.Button()
        Me.cmdAggiunge = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPosiImmagini = New System.Windows.Forms.Label()
        Me.cmdShow = New System.Windows.Forms.Button()
        Me.cmdCategorizza = New System.Windows.Forms.Button()
        Me.chkRidimensiona = New System.Windows.Forms.CheckBox()
        Me.chkSistemaNomi = New System.Windows.Forms.CheckBox()
        Me.chkAccorpa = New System.Windows.Forms.CheckBox()
        Me.chkCompatta = New System.Windows.Forms.CheckBox()
        Me.chkPerNonValide = New System.Windows.Forms.CheckBox()
        Me.chkPerPiccole = New System.Windows.Forms.CheckBox()
        Me.chkPerZero = New System.Windows.Forms.CheckBox()
        Me.lblTotUguali = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotImmagini = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkPerExif = New System.Windows.Forms.CheckBox()
        Me.chkPerDime = New System.Windows.Forms.CheckBox()
        Me.chkPerCRC = New System.Windows.Forms.CheckBox()
        Me.chkPerData = New System.Windows.Forms.CheckBox()
        Me.cmdUguali = New System.Windows.Forms.Button()
        Me.chkEliminaInes = New System.Windows.Forms.CheckBox()
        Me.chkLeggeImmagini = New System.Windows.Forms.CheckBox()
        Me.chkControlla = New System.Windows.Forms.CheckBox()
        Me.chkPulisci = New System.Windows.Forms.CheckBox()
        Me.chkExif = New System.Windows.Forms.CheckBox()
        Me.cmdUscita = New System.Windows.Forms.Button()
        Me.cmdEsegui = New System.Windows.Forms.Button()
        Me.pnlEsecuzione = New System.Windows.Forms.Panel()
        Me.cmdBlocca = New System.Windows.Forms.Button()
        Me.lblTipoOperazione = New System.Windows.Forms.Label()
        Me.lblAvanzamento = New System.Windows.Forms.Label()
        Me.pnlComandi.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlEsecuzione.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDirectory
        '
        Me.lblDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDirectory.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblDirectory.Location = New System.Drawing.Point(12, 9)
        Me.lblDirectory.Name = "lblDirectory"
        Me.lblDirectory.Size = New System.Drawing.Size(722, 23)
        Me.lblDirectory.TabIndex = 6
        Me.lblDirectory.Text = "Label1"
        '
        'cmdImpostaDir
        '
        Me.cmdImpostaDir.Location = New System.Drawing.Point(740, 9)
        Me.cmdImpostaDir.Name = "cmdImpostaDir"
        Me.cmdImpostaDir.Size = New System.Drawing.Size(32, 23)
        Me.cmdImpostaDir.TabIndex = 5
        Me.cmdImpostaDir.Text = "..."
        Me.cmdImpostaDir.UseVisualStyleBackColor = True
        '
        'pnlComandi
        '
        Me.pnlComandi.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlComandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlComandi.Controls.Add(Me.chkNomiLunghi)
        Me.pnlComandi.Controls.Add(Me.chkCreaCRC)
        Me.pnlComandi.Controls.Add(Me.chkCartelleVuote)
        Me.pnlComandi.Controls.Add(Me.chkPulisceCategorie)
        Me.pnlComandi.Controls.Add(Me.chkPulisceDati)
        Me.pnlComandi.Controls.Add(Me.chkPulisceCRC)
        Me.pnlComandi.Controls.Add(Me.chkPulisceUguali)
        Me.pnlComandi.Controls.Add(Me.Panel1)
        Me.pnlComandi.Controls.Add(Me.cmdShow)
        Me.pnlComandi.Controls.Add(Me.cmdCategorizza)
        Me.pnlComandi.Controls.Add(Me.chkRidimensiona)
        Me.pnlComandi.Controls.Add(Me.chkSistemaNomi)
        Me.pnlComandi.Controls.Add(Me.chkAccorpa)
        Me.pnlComandi.Controls.Add(Me.chkCompatta)
        Me.pnlComandi.Controls.Add(Me.chkPerNonValide)
        Me.pnlComandi.Controls.Add(Me.chkPerPiccole)
        Me.pnlComandi.Controls.Add(Me.chkPerZero)
        Me.pnlComandi.Controls.Add(Me.lblTotUguali)
        Me.pnlComandi.Controls.Add(Me.Label3)
        Me.pnlComandi.Controls.Add(Me.lblTotImmagini)
        Me.pnlComandi.Controls.Add(Me.Label1)
        Me.pnlComandi.Controls.Add(Me.chkPerExif)
        Me.pnlComandi.Controls.Add(Me.chkPerDime)
        Me.pnlComandi.Controls.Add(Me.chkPerCRC)
        Me.pnlComandi.Controls.Add(Me.chkPerData)
        Me.pnlComandi.Controls.Add(Me.cmdUguali)
        Me.pnlComandi.Controls.Add(Me.chkEliminaInes)
        Me.pnlComandi.Controls.Add(Me.chkLeggeImmagini)
        Me.pnlComandi.Controls.Add(Me.chkControlla)
        Me.pnlComandi.Controls.Add(Me.chkPulisci)
        Me.pnlComandi.Controls.Add(Me.chkExif)
        Me.pnlComandi.Controls.Add(Me.cmdUscita)
        Me.pnlComandi.Controls.Add(Me.cmdEsegui)
        Me.pnlComandi.Location = New System.Drawing.Point(12, 38)
        Me.pnlComandi.Name = "pnlComandi"
        Me.pnlComandi.Size = New System.Drawing.Size(760, 164)
        Me.pnlComandi.TabIndex = 16
        '
        'chkNomiLunghi
        '
        Me.chkNomiLunghi.AutoSize = True
        Me.chkNomiLunghi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNomiLunghi.Location = New System.Drawing.Point(138, 140)
        Me.chkNomiLunghi.Name = "chkNomiLunghi"
        Me.chkNomiLunghi.Size = New System.Drawing.Size(88, 19)
        Me.chkNomiLunghi.TabIndex = 53
        Me.chkNomiLunghi.Text = "Path lunghi"
        Me.chkNomiLunghi.UseVisualStyleBackColor = True
        '
        'chkCreaCRC
        '
        Me.chkCreaCRC.AutoSize = True
        Me.chkCreaCRC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCreaCRC.Location = New System.Drawing.Point(4, 38)
        Me.chkCreaCRC.Name = "chkCreaCRC"
        Me.chkCreaCRC.Size = New System.Drawing.Size(119, 19)
        Me.chkCreaCRC.TabIndex = 52
        Me.chkCreaCRC.Text = "Crea valori confr."
        Me.chkCreaCRC.UseVisualStyleBackColor = True
        '
        'chkCartelleVuote
        '
        Me.chkCartelleVuote.AutoSize = True
        Me.chkCartelleVuote.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCartelleVuote.Location = New System.Drawing.Point(3, 124)
        Me.chkCartelleVuote.Name = "chkCartelleVuote"
        Me.chkCartelleVuote.Size = New System.Drawing.Size(111, 19)
        Me.chkCartelleVuote.TabIndex = 51
        Me.chkCartelleVuote.Text = "Pul. Cart. Vuote"
        Me.chkCartelleVuote.UseVisualStyleBackColor = True
        '
        'chkPulisceCategorie
        '
        Me.chkPulisceCategorie.AutoSize = True
        Me.chkPulisceCategorie.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPulisceCategorie.Location = New System.Drawing.Point(255, 73)
        Me.chkPulisceCategorie.Name = "chkPulisceCategorie"
        Me.chkPulisceCategorie.Size = New System.Drawing.Size(123, 19)
        Me.chkPulisceCategorie.TabIndex = 50
        Me.chkPulisceCategorie.Text = "Pulisce Categorie"
        Me.chkPulisceCategorie.UseVisualStyleBackColor = True
        '
        'chkPulisceDati
        '
        Me.chkPulisceDati.AutoSize = True
        Me.chkPulisceDati.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPulisceDati.Location = New System.Drawing.Point(255, 21)
        Me.chkPulisceDati.Name = "chkPulisceDati"
        Me.chkPulisceDati.Size = New System.Drawing.Size(127, 19)
        Me.chkPulisceDati.TabIndex = 49
        Me.chkPulisceDati.Text = "Pulisce Dati / EXIF"
        Me.chkPulisceDati.UseVisualStyleBackColor = True
        '
        'chkPulisceCRC
        '
        Me.chkPulisceCRC.AutoSize = True
        Me.chkPulisceCRC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPulisceCRC.Location = New System.Drawing.Point(255, 55)
        Me.chkPulisceCRC.Name = "chkPulisceCRC"
        Me.chkPulisceCRC.Size = New System.Drawing.Size(96, 19)
        Me.chkPulisceCRC.TabIndex = 48
        Me.chkPulisceCRC.Text = "Pulisce CRC"
        Me.chkPulisceCRC.UseVisualStyleBackColor = True
        '
        'chkPulisceUguali
        '
        Me.chkPulisceUguali.AutoSize = True
        Me.chkPulisceUguali.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPulisceUguali.Location = New System.Drawing.Point(255, 38)
        Me.chkPulisceUguali.Name = "chkPulisceUguali"
        Me.chkPulisceUguali.Size = New System.Drawing.Size(103, 19)
        Me.chkPulisceUguali.TabIndex = 47
        Me.chkPulisceUguali.Text = "Pulisce uguali"
        Me.chkPulisceUguali.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdImpostaAgg)
        Me.Panel1.Controls.Add(Me.cmdAggiunge)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblPosiImmagini)
        Me.Panel1.Location = New System.Drawing.Point(255, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 59)
        Me.Panel1.TabIndex = 46
        '
        'cmdImpostaAgg
        '
        Me.cmdImpostaAgg.Location = New System.Drawing.Point(303, 3)
        Me.cmdImpostaAgg.Name = "cmdImpostaAgg"
        Me.cmdImpostaAgg.Size = New System.Drawing.Size(28, 23)
        Me.cmdImpostaAgg.TabIndex = 42
        Me.cmdImpostaAgg.Text = "..."
        Me.cmdImpostaAgg.UseVisualStyleBackColor = True
        '
        'cmdAggiunge
        '
        Me.cmdAggiunge.Image = CType(resources.GetObject("cmdAggiunge.Image"), System.Drawing.Image)
        Me.cmdAggiunge.Location = New System.Drawing.Point(335, 3)
        Me.cmdAggiunge.Name = "cmdAggiunge"
        Me.cmdAggiunge.Size = New System.Drawing.Size(53, 53)
        Me.cmdAggiunge.TabIndex = 41
        Me.cmdAggiunge.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(0, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Aggiungi:"
        '
        'lblPosiImmagini
        '
        Me.lblPosiImmagini.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPosiImmagini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosiImmagini.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblPosiImmagini.Location = New System.Drawing.Point(3, 31)
        Me.lblPosiImmagini.Name = "lblPosiImmagini"
        Me.lblPosiImmagini.Size = New System.Drawing.Size(328, 23)
        Me.lblPosiImmagini.TabIndex = 43
        Me.lblPosiImmagini.Text = "Label1"
        '
        'cmdShow
        '
        Me.cmdShow.Image = CType(resources.GetObject("cmdShow.Image"), System.Drawing.Image)
        Me.cmdShow.Location = New System.Drawing.Point(707, 4)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(48, 48)
        Me.cmdShow.TabIndex = 45
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmdCategorizza
        '
        Me.cmdCategorizza.Image = CType(resources.GetObject("cmdCategorizza.Image"), System.Drawing.Image)
        Me.cmdCategorizza.Location = New System.Drawing.Point(657, 53)
        Me.cmdCategorizza.Name = "cmdCategorizza"
        Me.cmdCategorizza.Size = New System.Drawing.Size(48, 48)
        Me.cmdCategorizza.TabIndex = 40
        Me.cmdCategorizza.UseVisualStyleBackColor = True
        '
        'chkRidimensiona
        '
        Me.chkRidimensiona.AutoSize = True
        Me.chkRidimensiona.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRidimensiona.Location = New System.Drawing.Point(3, 73)
        Me.chkRidimensiona.Name = "chkRidimensiona"
        Me.chkRidimensiona.Size = New System.Drawing.Size(103, 19)
        Me.chkRidimensiona.TabIndex = 39
        Me.chkRidimensiona.Text = "Ridimensiona"
        Me.chkRidimensiona.UseVisualStyleBackColor = True
        '
        'chkSistemaNomi
        '
        Me.chkSistemaNomi.AutoSize = True
        Me.chkSistemaNomi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSistemaNomi.Location = New System.Drawing.Point(4, 107)
        Me.chkSistemaNomi.Name = "chkSistemaNomi"
        Me.chkSistemaNomi.Size = New System.Drawing.Size(104, 19)
        Me.chkSistemaNomi.TabIndex = 38
        Me.chkSistemaNomi.Text = "Sistema Nomi"
        Me.chkSistemaNomi.UseVisualStyleBackColor = True
        '
        'chkAccorpa
        '
        Me.chkAccorpa.AutoSize = True
        Me.chkAccorpa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAccorpa.Location = New System.Drawing.Point(4, 91)
        Me.chkAccorpa.Name = "chkAccorpa"
        Me.chkAccorpa.Size = New System.Drawing.Size(71, 19)
        Me.chkAccorpa.TabIndex = 37
        Me.chkAccorpa.Text = "Accorpa"
        Me.chkAccorpa.UseVisualStyleBackColor = True
        '
        'chkCompatta
        '
        Me.chkCompatta.AutoSize = True
        Me.chkCompatta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompatta.ForeColor = System.Drawing.Color.Green
        Me.chkCompatta.Location = New System.Drawing.Point(3, 144)
        Me.chkCompatta.Name = "chkCompatta"
        Me.chkCompatta.Size = New System.Drawing.Size(100, 19)
        Me.chkCompatta.TabIndex = 35
        Me.chkCompatta.Text = "Compatta DB"
        Me.chkCompatta.UseVisualStyleBackColor = True
        '
        'chkPerNonValide
        '
        Me.chkPerNonValide.AutoSize = True
        Me.chkPerNonValide.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerNonValide.Location = New System.Drawing.Point(138, 124)
        Me.chkPerNonValide.Name = "chkPerNonValide"
        Me.chkPerNonValide.Size = New System.Drawing.Size(75, 19)
        Me.chkPerNonValide.TabIndex = 34
        Me.chkPerNonValide.Text = "Rovinate"
        Me.chkPerNonValide.UseVisualStyleBackColor = True
        '
        'chkPerPiccole
        '
        Me.chkPerPiccole.AutoSize = True
        Me.chkPerPiccole.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerPiccole.Location = New System.Drawing.Point(138, 107)
        Me.chkPerPiccole.Name = "chkPerPiccole"
        Me.chkPerPiccole.Size = New System.Drawing.Size(66, 19)
        Me.chkPerPiccole.TabIndex = 33
        Me.chkPerPiccole.Text = "Piccole"
        Me.chkPerPiccole.UseVisualStyleBackColor = True
        '
        'chkPerZero
        '
        Me.chkPerZero.AutoSize = True
        Me.chkPerZero.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerZero.Location = New System.Drawing.Point(138, 90)
        Me.chkPerZero.Name = "chkPerZero"
        Me.chkPerZero.Size = New System.Drawing.Size(99, 19)
        Me.chkPerZero.TabIndex = 32
        Me.chkPerZero.Text = "Lunghezza 0"
        Me.chkPerZero.UseVisualStyleBackColor = True
        '
        'lblTotUguali
        '
        Me.lblTotUguali.AutoSize = True
        Me.lblTotUguali.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotUguali.ForeColor = System.Drawing.Color.DimGray
        Me.lblTotUguali.Location = New System.Drawing.Point(571, 28)
        Me.lblTotUguali.Name = "lblTotUguali"
        Me.lblTotUguali.Size = New System.Drawing.Size(80, 17)
        Me.lblTotUguali.TabIndex = 31
        Me.lblTotUguali.Text = "Immagini:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(480, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Uguali:"
        '
        'lblTotImmagini
        '
        Me.lblTotImmagini.AutoSize = True
        Me.lblTotImmagini.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotImmagini.ForeColor = System.Drawing.Color.DimGray
        Me.lblTotImmagini.Location = New System.Drawing.Point(571, 8)
        Me.lblTotImmagini.Name = "lblTotImmagini"
        Me.lblTotImmagini.Size = New System.Drawing.Size(80, 17)
        Me.lblTotImmagini.TabIndex = 29
        Me.lblTotImmagini.Text = "Immagini:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(480, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Immagini:"
        '
        'chkPerExif
        '
        Me.chkPerExif.AutoSize = True
        Me.chkPerExif.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerExif.Location = New System.Drawing.Point(138, 73)
        Me.chkPerExif.Name = "chkPerExif"
        Me.chkPerExif.Size = New System.Drawing.Size(75, 19)
        Me.chkPerExif.TabIndex = 27
        Me.chkPerExif.Text = "Per EXIF"
        Me.chkPerExif.UseVisualStyleBackColor = True
        '
        'chkPerDime
        '
        Me.chkPerDime.AutoSize = True
        Me.chkPerDime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerDime.Location = New System.Drawing.Point(138, 20)
        Me.chkPerDime.Name = "chkPerDime"
        Me.chkPerDime.Size = New System.Drawing.Size(111, 19)
        Me.chkPerDime.TabIndex = 26
        Me.chkPerDime.Text = "Per Dimensioni"
        Me.chkPerDime.UseVisualStyleBackColor = True
        '
        'chkPerCRC
        '
        Me.chkPerCRC.AutoSize = True
        Me.chkPerCRC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerCRC.Location = New System.Drawing.Point(138, 56)
        Me.chkPerCRC.Name = "chkPerCRC"
        Me.chkPerCRC.Size = New System.Drawing.Size(75, 19)
        Me.chkPerCRC.TabIndex = 25
        Me.chkPerCRC.Text = "Per CRC"
        Me.chkPerCRC.UseVisualStyleBackColor = True
        '
        'chkPerData
        '
        Me.chkPerData.AutoSize = True
        Me.chkPerData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPerData.Location = New System.Drawing.Point(138, 38)
        Me.chkPerData.Name = "chkPerData"
        Me.chkPerData.Size = New System.Drawing.Size(72, 19)
        Me.chkPerData.TabIndex = 24
        Me.chkPerData.Text = "Per data"
        Me.chkPerData.UseVisualStyleBackColor = True
        '
        'cmdUguali
        '
        Me.cmdUguali.Image = CType(resources.GetObject("cmdUguali.Image"), System.Drawing.Image)
        Me.cmdUguali.Location = New System.Drawing.Point(707, 53)
        Me.cmdUguali.Name = "cmdUguali"
        Me.cmdUguali.Size = New System.Drawing.Size(48, 48)
        Me.cmdUguali.TabIndex = 23
        Me.cmdUguali.UseVisualStyleBackColor = True
        '
        'chkEliminaInes
        '
        Me.chkEliminaInes.AutoSize = True
        Me.chkEliminaInes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEliminaInes.Location = New System.Drawing.Point(3, 55)
        Me.chkEliminaInes.Name = "chkEliminaInes"
        Me.chkEliminaInes.Size = New System.Drawing.Size(127, 19)
        Me.chkEliminaInes.TabIndex = 22
        Me.chkEliminaInes.Text = "Elimina Inesistenti"
        Me.chkEliminaInes.UseVisualStyleBackColor = True
        '
        'chkLeggeImmagini
        '
        Me.chkLeggeImmagini.AutoSize = True
        Me.chkLeggeImmagini.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLeggeImmagini.Location = New System.Drawing.Point(4, 4)
        Me.chkLeggeImmagini.Name = "chkLeggeImmagini"
        Me.chkLeggeImmagini.Size = New System.Drawing.Size(117, 19)
        Me.chkLeggeImmagini.TabIndex = 21
        Me.chkLeggeImmagini.Text = "Legge Immagini"
        Me.chkLeggeImmagini.UseVisualStyleBackColor = True
        '
        'chkControlla
        '
        Me.chkControlla.AutoSize = True
        Me.chkControlla.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkControlla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkControlla.Location = New System.Drawing.Point(138, 3)
        Me.chkControlla.Name = "chkControlla"
        Me.chkControlla.Size = New System.Drawing.Size(113, 19)
        Me.chkControlla.TabIndex = 20
        Me.chkControlla.Text = "Effettua controlli"
        Me.chkControlla.UseVisualStyleBackColor = True
        '
        'chkPulisci
        '
        Me.chkPulisci.AutoSize = True
        Me.chkPulisci.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPulisci.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkPulisci.Location = New System.Drawing.Point(255, 3)
        Me.chkPulisci.Name = "chkPulisci"
        Me.chkPulisci.Size = New System.Drawing.Size(82, 19)
        Me.chkPulisci.TabIndex = 19
        Me.chkPulisci.Text = "Pulisci DB"
        Me.chkPulisci.UseVisualStyleBackColor = True
        '
        'chkExif
        '
        Me.chkExif.AutoSize = True
        Me.chkExif.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExif.Location = New System.Drawing.Point(4, 21)
        Me.chkExif.Name = "chkExif"
        Me.chkExif.Size = New System.Drawing.Size(112, 19)
        Me.chkExif.TabIndex = 18
        Me.chkExif.Text = "Carica tag EXIF"
        Me.chkExif.UseVisualStyleBackColor = True
        '
        'cmdUscita
        '
        Me.cmdUscita.Image = CType(resources.GetObject("cmdUscita.Image"), System.Drawing.Image)
        Me.cmdUscita.Location = New System.Drawing.Point(707, 105)
        Me.cmdUscita.Name = "cmdUscita"
        Me.cmdUscita.Size = New System.Drawing.Size(48, 48)
        Me.cmdUscita.TabIndex = 16
        Me.cmdUscita.UseVisualStyleBackColor = True
        '
        'cmdEsegui
        '
        Me.cmdEsegui.Image = CType(resources.GetObject("cmdEsegui.Image"), System.Drawing.Image)
        Me.cmdEsegui.Location = New System.Drawing.Point(657, 4)
        Me.cmdEsegui.Name = "cmdEsegui"
        Me.cmdEsegui.Size = New System.Drawing.Size(48, 48)
        Me.cmdEsegui.TabIndex = 15
        Me.cmdEsegui.UseVisualStyleBackColor = True
        '
        'pnlEsecuzione
        '
        Me.pnlEsecuzione.BackColor = System.Drawing.Color.Green
        Me.pnlEsecuzione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEsecuzione.Controls.Add(Me.cmdBlocca)
        Me.pnlEsecuzione.Controls.Add(Me.lblTipoOperazione)
        Me.pnlEsecuzione.Controls.Add(Me.lblAvanzamento)
        Me.pnlEsecuzione.Location = New System.Drawing.Point(12, 208)
        Me.pnlEsecuzione.Name = "pnlEsecuzione"
        Me.pnlEsecuzione.Size = New System.Drawing.Size(760, 154)
        Me.pnlEsecuzione.TabIndex = 23
        Me.pnlEsecuzione.Visible = False
        '
        'cmdBlocca
        '
        Me.cmdBlocca.Image = CType(resources.GetObject("cmdBlocca.Image"), System.Drawing.Image)
        Me.cmdBlocca.Location = New System.Drawing.Point(701, 3)
        Me.cmdBlocca.Name = "cmdBlocca"
        Me.cmdBlocca.Size = New System.Drawing.Size(54, 46)
        Me.cmdBlocca.TabIndex = 20
        Me.cmdBlocca.UseVisualStyleBackColor = True
        '
        'lblTipoOperazione
        '
        Me.lblTipoOperazione.AutoSize = True
        Me.lblTipoOperazione.Font = New System.Drawing.Font("Courier New", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoOperazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTipoOperazione.Location = New System.Drawing.Point(7, 47)
        Me.lblTipoOperazione.Name = "lblTipoOperazione"
        Me.lblTipoOperazione.Size = New System.Drawing.Size(88, 23)
        Me.lblTipoOperazione.TabIndex = 19
        Me.lblTipoOperazione.Text = "Label2"
        '
        'lblAvanzamento
        '
        Me.lblAvanzamento.AutoSize = True
        Me.lblAvanzamento.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvanzamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAvanzamento.Location = New System.Drawing.Point(8, 81)
        Me.lblAvanzamento.Name = "lblAvanzamento"
        Me.lblAvanzamento.Size = New System.Drawing.Size(56, 17)
        Me.lblAvanzamento.TabIndex = 18
        Me.lblAvanzamento.Text = "Label1"
        Me.lblAvanzamento.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(781, 208)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlComandi)
        Me.Controls.Add(Me.pnlEsecuzione)
        Me.Controls.Add(Me.lblDirectory)
        Me.Controls.Add(Me.cmdImpostaDir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uguaglianze"
        Me.pnlComandi.ResumeLayout(False)
        Me.pnlComandi.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlEsecuzione.ResumeLayout(False)
        Me.pnlEsecuzione.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDirectory As System.Windows.Forms.Label
    Friend WithEvents cmdImpostaDir As System.Windows.Forms.Button
    Friend WithEvents pnlComandi As System.Windows.Forms.Panel
    Friend WithEvents chkEliminaInes As System.Windows.Forms.CheckBox
    Friend WithEvents chkLeggeImmagini As System.Windows.Forms.CheckBox
    Friend WithEvents chkControlla As System.Windows.Forms.CheckBox
    Friend WithEvents chkPulisci As System.Windows.Forms.CheckBox
    Friend WithEvents chkExif As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUscita As System.Windows.Forms.Button
    Friend WithEvents cmdEsegui As System.Windows.Forms.Button
    Friend WithEvents cmdUguali As System.Windows.Forms.Button
    Friend WithEvents chkPerExif As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerDime As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerCRC As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerData As System.Windows.Forms.CheckBox
    Friend WithEvents pnlEsecuzione As System.Windows.Forms.Panel
    Friend WithEvents cmdBlocca As System.Windows.Forms.Button
    Friend WithEvents lblTipoOperazione As System.Windows.Forms.Label
    Friend WithEvents lblAvanzamento As System.Windows.Forms.Label
    Friend WithEvents lblTotUguali As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotImmagini As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkPerZero As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerPiccole As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerNonValide As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompatta As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccorpa As System.Windows.Forms.CheckBox
    Friend WithEvents chkSistemaNomi As System.Windows.Forms.CheckBox
    Friend WithEvents chkRidimensiona As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCategorizza As System.Windows.Forms.Button
    Friend WithEvents lblPosiImmagini As Label
    Friend WithEvents cmdImpostaAgg As Button
    Friend WithEvents cmdAggiunge As Button
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkPulisceUguali As System.Windows.Forms.CheckBox
    Friend WithEvents chkPulisceCRC As System.Windows.Forms.CheckBox
    Friend WithEvents chkPulisceDati As System.Windows.Forms.CheckBox
    Friend WithEvents chkPulisceCategorie As System.Windows.Forms.CheckBox
    Friend WithEvents chkCartelleVuote As System.Windows.Forms.CheckBox
    Friend WithEvents chkCreaCRC As System.Windows.Forms.CheckBox
    Friend WithEvents chkNomiLunghi As CheckBox
End Class
