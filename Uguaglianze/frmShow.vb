Imports System.IO

Public Class frmShow
    Dim Quante As Long = 0
    Dim recImmagini As Object = "ADODB.Recordset"
    Dim db As New GestioneDB
    Dim conn As Object = "ADODB.Connection"
    Dim immVisualizzata As Long
    Dim FormatoImmagine As Integer
    Dim Visualizzate() As Long = {}
    Dim qVisualizzate As Integer = 0
    Dim PosizionePannelloAperto As Integer = -2
    Dim PosizionePannelloChiuso As Integer = 0

    Private Sub Operazione(Tasto As Integer)
        Select Case Tasto
            Case Asc("N"), Asc("n") ' Vai a numero immagine
                Dim Quale As String = InputBox("Numero immagine (0/" & FormattaNumero(Quante, False) & "): ")

                If Quale <> "" Then
                    If IsNumeric(Quale) = True And Val(Quale) >= 0 And Val(Quale) <= Quante Then
                        CaricaImmagine(True, Quale, True)
                    End If
                End If
            Case Asc("S"), Asc("s") ' Immagini simili
                ImmaginiSimili()
            Case Asc("F"), Asc("f") ' Filtro
                If pnlFiltro.Visible = True Then
                    pnlFiltro.Visible = False
                Else
                    pnlFiltro.Visible = True
                End If
            Case 8 ' Indietro
                If qVisualizzate > 0 Then
                    qVisualizzate -= 1
                    Dim Quale As Long = Visualizzate(qVisualizzate)

                    CaricaImmagine(True, Quale, True)
                End If
            Case Asc("+")
                PictureBox1.Width *= 2
                PictureBox1.Height *= 2

                PictureBox1.Left = (Me.Width / 2) - (PictureBox1.Width / 2)
                PictureBox1.Top = (Me.Height / 2) - (PictureBox1.Height / 2)
            Case Asc("-")
                PictureBox1.Width /= 2
                PictureBox1.Height /= 2

                PictureBox1.Left = (Me.Width / 2) - (PictureBox1.Width / 2)
                PictureBox1.Top = (Me.Height / 2) - (PictureBox1.Height / 2)
            Case 32 ' Cambio immagine
                CaricaImmagine(True)
            Case 27 ' ESC
                recImmagini.Close()
                conn.Close()
                db = Nothing

                Me.Dispose()
                Me.Close()
                frmMain.Show()
        End Select
    End Sub

    Private Sub CaricaDirectory()
        Dim gf As New GestioneFilesDirectory
        Dim Cartella As String
        Dim Percorso As String = GetSetting("Uguaglianze", "Impostazioni", "Percorso", Application.StartupPath)

        cmbDirectory.Items.Clear()
        cmbDirectory.Items.Add("")

        cmbCategoria.Items.Clear()
        cmbCategoria.Items.Add("")

        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim sql As String

        sql = "Select * From Cartelle Order By Descrizione"
        rec = db.LeggeQuery(conn, sql)
        Do Until rec.Eof
            If rec("Descrizione").Value.ToString.IndexOf("\Categorie") > -1 Then
                Dim Cartella2 As String

                Cartella2 = rec("Descrizione").Value.ToString.Replace(Percorso & "\Categorie", "")

                If Cartella2 <> "" Then
                    If Mid(Cartella2, 1, 1) = "\" Then
                        Cartella2 = Mid(Cartella2, 2, Cartella2.Length)
                    End If
                    Cartella2 = Cartella2.Replace("\N", "")
                    Cartella2 = Cartella2.Replace("\V", "")
                    If Cartella2.IndexOf("\") = -1 Then
                        Dim ok As Boolean = True

                        For i As Integer = 0 To cmbCategoria.Items.Count - 1
                            If cmbCategoria.Items(i) = Cartella2 Then
                                ok = False
                                Exit For
                            End If
                        Next
                        If ok = True Then
                            cmbCategoria.Items.Add(Cartella2)
                        End If
                    End If
                End If
            End If

            Cartella = rec("Descrizione").Value.ToString.Replace(Percorso, "")

            If Cartella <> "" Then
                If Mid(Cartella, 1, 1) = "\" Then
                    Cartella = Mid(Cartella, 2, Cartella.Length)
                End If
                Cartella = Cartella.Replace("Categorie\", "")
                Cartella = Cartella.Replace("\N", "")
                Cartella = Cartella.Replace("\V", "")
                If Cartella.IndexOf("\") = -1 Then
                    Dim ok As Boolean = True

                    For i As Integer = 0 To cmbDirectory.Items.Count - 1
                        If cmbDirectory.Items(i) = Cartella Then
                            ok = False
                            Exit For
                        End If
                    Next
                    If ok = True Then
                        cmbDirectory.Items.Add(Cartella)
                    End If
                End If
            End If

            rec.MoveNext()
        Loop
        rec.Close()

        gf = Nothing
    End Sub

    Private Sub frmShow_Click(sender As Object, e As EventArgs) Handles Me.Click
        pnlTasti.Top = PosizionePannelloChiuso

        cmdOperazioni.Focus()
    End Sub

    Private Sub frmShow_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        cmdOperazioni.Focus()
    End Sub

    Private Sub frmShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PosizionePannelloChiuso = -(pnlTasti.Height - 2)

        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"

        conn = db.ApreDB()
        sql = "Select Count(*) From Dati"
        rec = db.LeggeQuery(conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            Quante = 0
        Else
            Quante = rec(0).Value
        End If
        rec.Close()

        sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From Dati A Left Join Cartelle B On A.idCartella=B.idCartella"
        recImmagini = db.LeggeQuery(conn, sql)

        Dim t As String = GetSetting("Uguaglianze", "Impostazioni", "TipoVisualizzazione", 1)

        If t = 1 Then
            optRandom.Checked = True
            optSequenziale.Checked = False
        Else
            optRandom.Checked = False
            optSequenziale.Checked = True
        End If

        t = GetSetting("Uguaglianze", "Impostazioni", "TipoFormato", 1)

        If t = 1 Then
            optTuttoSchermo.Checked = True
            optAdatta.Checked = False
            FormatoImmagine = 1
        Else
            optTuttoSchermo.Checked = False
            optAdatta.Checked = True
            FormatoImmagine = 2
        End If

        pnlTasti.Left = -5
        pnlTasti.Top = PosizionePannelloChiuso
        pnlTasti.Width = Me.Width + 10

        cmdOperazioni.Top = -50
        cmdOperazioni.Left = 0

        lblFiltro.Text = ""
        lblFiltro2.Text = ""
        lblSimili.Text = ""

        lstExif.Left = 7
        lstExif.Width = 300
        pnlTasti2.Left = lstExif.Width + lstExif.Left + 2
        pnlTasti3.Left = pnlTasti2.Width + pnlTasti2.Left + 2
        pnlTasti4.Left = pnlTasti3.Width + pnlTasti3.Left + 2
        pnlTasti5.Left = pnlTasti4.Width + pnlTasti4.Left + 2

        pnlFiltro.Top = (Me.Height / 2) - (pnlFiltro.Height / 2)
        pnlFiltro.Left = 0
        pnlFiltro.Visible = False

        Dim Quale As Long = GetSetting("Uguaglianze", "Impostazioni", "QualeImmVisua", -1)

        CaricaImmagine(True, Quale)

        CaricaDirectory()
    End Sub

    Private Sub CaricaImmagine(CaricaNuova As Boolean, Optional PrimaImm As Long = -1, Optional Indietro As Boolean = False)
        Dim QualeImm As Long
        Dim posX As Integer
        Dim posY As Integer

        If CaricaNuova = False Then
            QualeImm = immVisualizzata

            recImmagini.MoveFirst()
            recImmagini.Move(QualeImm)
        Else
            If PrimaImm > -1 Then
                QualeImm = PrimaImm
            End If

            If optRandom.Checked = True Then
                If PrimaImm = -1 Then
                    Randomize()
                    QualeImm = Int(Rnd(1) * Quante)
                    If QualeImm > Quante Then QualeImm = Quante
                End If

                recImmagini.MoveFirst()
                recImmagini.Move(QualeImm)
                If recImmagini.Eof = True Then
                    recImmagini.MoveFirst()
                    QualeImm = 0
                End If
            Else
                If Indietro = False Then
                    QualeImm = GetSetting("Uguaglianze", "Impostazioni", "QualeImmVisua", -1)

                    If PrimaImm = -1 Then
                        QualeImm += 1
                    End If

                    recImmagini.MoveNext()
                    If recImmagini.Eof = True Then
                        QualeImm = 0
                        recImmagini.MoveFirst()
                    End If
                Else
                    QualeImm = PrimaImm

                    recImmagini.MoveFirst()
                    recImmagini.Move(QualeImm)
                End If
            End If
            SaveSetting("Uguaglianze", "Impostazioni", "QualeImmVisua", QualeImm)
            immVisualizzata = QualeImm

            If Indietro = False Then
                qVisualizzate += 1
                If Visualizzate Is Nothing = False AndAlso qVisualizzate > UBound(Visualizzate) Then
                    ReDim Preserve Visualizzate(qVisualizzate)
                End If
                Visualizzate(qVisualizzate) = QualeImm
            End If
        End If

        Dim Immagine As String = ""
        Dim Esci As Boolean = False

        If recImmagini.Eof = False Then
            Immagine = recImmagini("Descrizione").Value & "\" & recImmagini("NomeFile").Value
            If File.Exists(Immagine) = False Then
                Esci = True
            End If
        Else
            Esci = True
        End If
        If Esci = True Then
            PictureBox1.Image = Nothing
            lstExif.Items.Clear()
            Exit Sub
        End If

        cmbCategoria.Visible = True
        lblCategoria.Visible = True
        cmdNuovaCategoria.Visible = True
        cmdSposta.Visible = True
        cmbCategoria.Text = ""

        Dim Categoria As String = ""

        If recImmagini("Descrizione").Value.ToString.ToUpper.IndexOf("\CATEGORIE\") > -1 Then
            Dim NomeCat As String = recImmagini("Descrizione").Value.ToString.ToUpper.Trim

            NomeCat = Mid(NomeCat, NomeCat.IndexOf("\CATEGORIE\") + 12, NomeCat.Length)
            If NomeCat.IndexOf("\") > -1 Then
                NomeCat = Mid(NomeCat, 1, NomeCat.IndexOf("\"))
            End If
            cmbCategoria.Text = NomeCat

            Categoria = NomeCat.ToUpper.Trim
        End If

        If recImmagini("Descrizione").Value.ToString.ToUpper.IndexOf("\SITERIPS\") > -1 Then
            cmbCategoria.Visible = False
            lblCategoria.Visible = False
            cmdNuovaCategoria.Visible = False
            cmdSposta.Visible = False
            Categoria = "SITERIPS"
        End If

        Dim sql As String = "SELECT DescrizioniEXIF.Descrizione, DescrizioniTestoEXIF.DescrizioneTesto " & _
            "FROM (DatiEXIF LEFT JOIN DescrizioniEXIF ON DatiEXIF.idDescrizione = DescrizioniEXIF.idDescrizione) " & _
            "LEFT JOIN DescrizioniTestoEXIF ON DatiEXIF.idDescrizioneTesto = DescrizioniTestoEXIF.idDescrizioneTesto " & _
            "WHERE DatiEXIF.idImmagine = " & recImmagini("id").Value & " " & _
            "ORDER BY DatiEXIF.Progressivo"
        Dim rec As Object = CreateObject("ADODB.Recordset")
        rec = db.LeggeQuery(conn, sql)
        lstExif.Items.Clear()
        lstExif.Items.Add("Num. Immagine: " & FormattaNumero(QualeImm, False) & "/" & FormattaNumero(Quante, False))
        lstExif.Items.Add("Nome File: " & recImmagini("NomeFile").Value)
        lstExif.Items.Add("Cartella: " & recImmagini("Descrizione").Value)
        lstExif.Items.Add("Dimensione: Kb. " & FormattaNumero(recImmagini("Dimensione").Value / 1024, False))
        lstExif.Items.Add("Grandezza: " & recImmagini("DimeX").Value & "x" & recImmagini("DimeY").Value)
        lstExif.Items.Add("Categoria: " & Categoria)
        lstExif.Items.Add("-------EXIF-------")
        Do Until rec.Eof
            lstExif.Items.Add(rec("Descrizione").Value & ": " & rec("DescrizioneTesto").Value)

            rec.MoveNext()
        Loop
        rec.Close()

        Dim fs As System.IO.FileStream
        fs = New System.IO.FileStream(Immagine,
             IO.FileMode.Open, IO.FileAccess.Read)
        PictureBox1.Image = System.Drawing.Image.FromStream(fs)
        fs.Close()
        fs = Nothing

        Dim gi As New GestioneImmagini

        Dim Dime() As String = gi.RitornaDimensioneImmagine(Immagine).Split("x")
        Dim dX As Integer = Val(Dime(0))
        Dim dY As Integer = Val(Dime(1))

        Dim Quanto As Integer

        If pnlTasti.Top = PosizionePannelloAperto Then
            Quanto = pnlTasti.Height + 4
        Else
            Quanto = 5
        End If

        If FormatoImmagine = 1 Then
            If dX > Me.Width - 10 Or dY > (Me.Height - 10) - Quanto Then
                Dim odX As Integer = dX
                Dim odY As Integer = dY

                gi = Nothing

                Dim sX As Integer = Me.Width - 10
                Dim sY As Integer = (Me.Height - 10) - Quanto

                Dim d1 As Single = dX / (sX)
                Dim d2 As Single = dY / (sY)
                Dim PercentualeResize As Single

                If d1 > d2 Then
                    PercentualeResize = d1
                Else
                    PercentualeResize = d2
                End If

                dX /= PercentualeResize
                dY /= PercentualeResize
            Else
                Quanto = 0
            End If
        End If

        PictureBox1.Width = dX
        PictureBox1.Height = dY - (Quanto)

        posX = (Me.Width / 2) - (PictureBox1.Width / 2)
        posY = (Me.Height / 2) - (PictureBox1.Height / 2)

        PictureBox1.Left = posX
        PictureBox1.Top = (posY + (Quanto / 2)) - 4

        cmdOperazioni.Focus()
    End Sub

    Private Sub pnlTasti_Click(sender As Object, e As EventArgs) Handles pnlTasti.Click
        If pnlTasti.Top = PosizionePannelloAperto Then
            pnlTasti.Top = PosizionePannelloChiuso
        Else
            pnlTasti.Top = PosizionePannelloAperto
        End If

        CaricaImmagine(False)
    End Sub

    Private Sub optRandom_Click(sender As Object, e As EventArgs) Handles optRandom.Click
        optSequenziale.Checked = False
        SaveSetting("Uguaglianze", "Impostazioni", "TipoVisualizzazione", 1)

        cmdOperazioni.Focus()
    End Sub

    Private Sub optSequenziale_Click(sender As Object, e As EventArgs) Handles optSequenziale.Click
        optRandom.Checked = False
        SaveSetting("Uguaglianze", "Impostazioni", "TipoVisualizzazione", 2)

        cmdOperazioni.Focus()
    End Sub

    Private Sub optAdatta_Click(sender As Object, e As EventArgs) Handles optAdatta.Click
        optTuttoSchermo.Checked = False
        FormatoImmagine = 2
        SaveSetting("Uguaglianze", "Impostazioni", "TipoFormato", 2)

        CaricaImmagine(False)
    End Sub

    Private Sub optTuttoSchermo_Click(sender As Object, e As EventArgs) Handles optTuttoSchermo.Click
        optAdatta.Checked = False
        FormatoImmagine = 1
        SaveSetting("Uguaglianze", "Impostazioni", "TipoFormato", 1)

        CaricaImmagine(False)
    End Sub

    Private Sub cmdOperazioni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmdOperazioni.KeyPress
        Dim tasto As Integer = AscW(e.KeyChar)

        Operazione(tasto)
    End Sub

    Private Sub cmdNuovaCategoria_Click(sender As Object, e As EventArgs) Handles cmdNuovaCategoria.Click
        Dim Ritorno As String = InputBox("Nome Nuova Categoria")

        If Ritorno <> "" Then
            Dim Percorso As String = GetSetting("Uguaglianze", "Impostazioni", "Percorso", Application.StartupPath)

            Try
                MkDir(Percorso & "\Categorie\" & Ritorno.ToUpper.Trim)
            Catch ex As Exception

            End Try

            CaricaDirectory()
        End If
    End Sub

    Private Sub cmdSposta_Click(sender As Object, e As EventArgs) Handles cmdSposta.Click
        Dim gf As New GestioneFilesDirectory
        Dim CartellaOrig As String
        Dim NomeFile As String
        Dim CartellaDest As String
        Dim Percorso As String = GetSetting("Uguaglianze", "Impostazioni", "Percorso", Application.StartupPath)
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim sql As String
        Dim idCartella As Integer
        Dim idCartellaNuova As Integer

        CartellaOrig = recImmagini("Descrizione").Value & "\"
        NomeFile = recImmagini("NomeFile").Value
        CartellaDest = Percorso & "\Categorie\" & cmbCategoria.Text & "\"

        If CartellaOrig.ToUpper.IndexOf("\V\") > -1 Then
            CartellaDest += "V\"
        Else
            CartellaDest += "N\"
        End If
        CartellaOrig = Mid(CartellaOrig, 1, CartellaOrig.Length - 1)
        gf.CreaDirectoryDaPercorso(CartellaDest)
        gf.CopiaFileFisico(CartellaOrig & "\" & NomeFile, CartellaDest & NomeFile, False)
        If File.Exists(CartellaDest & NomeFile) = True Then
            gf.EliminaFileFisico(CartellaOrig & "\" & NomeFile)

            sql = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(CartellaOrig) & "'"
            rec = db.LeggeQuery(conn, sql)
            idCartella = rec("idCartella").Value
            rec.Close()

            sql = "Select * From Cartelle Where Descrizione='" & Mid(CartellaDest, 1, CartellaDest.Length - 1) & "'"
            rec = db.LeggeQuery(conn, sql)
            If rec.Eof = False Then
                idCartellaNuova = rec("idCartella").Value
            Else
                idCartellaNuova = -1
            End If
            rec.Close()

            If idCartellaNuova = -1 Then
                sql = "Select Max(idCartella) From Cartelle"
                rec = db.LeggeQuery(conn, sql)
                If rec(0).value Is DBNull.Value = True Then
                    idCartellaNuova = 1
                Else
                    idCartellaNuova = rec(0).Value + 1
                End If
                rec.Close()

                sql = "Insert Into Cartelle Values (" & idCartellaNuova & ", '" & SistemaTestoPerDB(Mid(CartellaDest, 1, CartellaDest.Length - 1)) & "')"
                db.EsegueSql(conn, sql)
            End If

            sql = "Update Dati Set idCartella=" & idCartellaNuova & " Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(NomeFile) & "'"
            db.EsegueSql(conn, sql)
        End If

        gf = Nothing

        Dim Quale As Long = Visualizzate(qVisualizzate)

        CaricaImmagine(True, Quale, True)

        MsgBox("Operazione effettuata")
    End Sub

    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        If MsgBox("Si vuole eliminare l'immagine?", vbYesNo + vbDefaultButton2 + vbInformation) = vbYes Then
            Dim db As New GestioneDB
            Dim conn As Object = "ADODB.Connection"
            conn = db.ApreDB()
            Dim sql As String
            Dim CartellaOrig As String
            Dim NomeFile As String
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim idCartella As Integer
            Dim idImmagine As Long

            CartellaOrig = recImmagini("Descrizione").Value
            NomeFile = recImmagini("NomeFile").Value

            sql = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(CartellaOrig) & "'"
            rec = db.LeggeQuery(conn, sql)
            idCartella = rec("idCartella").Value
            rec.Close()

            sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(NomeFile) & "'"
            rec = db.LeggeQuery(conn, sql)
            idImmagine = rec("id").Value
            rec.Close()

            sql = "Delete * From Dati Where id=" & idImmagine
            db.EsegueSql(conn, sql)

            sql = "Delete * From CRC Where idImmagine=" & idImmagine
            db.EsegueSql(conn, sql)

            sql = "Delete * From DatiEXIF Where idImmagine=" & idImmagine
            db.EsegueSql(conn, sql)

            sql = "Delete * From Uguali Where idPrimo=" & idImmagine & " Or idSecondo=" & idImmagine
            db.EsegueSql(conn, sql)

            conn.Close()
            db = Nothing

            CaricaImmagine(False)

            MsgBox("Immagine eliminata")
        End If
    End Sub

    Private Sub cmdRuota_Click(sender As Object, e As EventArgs) Handles cmdRuotaDx.Click
        Dim gi As New GestioneImmagini
        Dim Nome As String = recImmagini("Descrizione").Value & "\" & recImmagini("NomeFile").Value
        gi.RuotaFoto(Nome, 90)
        gi = Nothing

        Dim sql As String = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(recImmagini("Descrizione").Value) & "'"
        Dim rec As Object = CreateObject("ADODB.Recordset")

        rec = db.LeggeQuery(conn, sql)
        Dim idCartella As Integer = rec("idCartella").Value
        rec.Close()

        sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(recImmagini("NomeFile").Value) & "'"
        rec = db.LeggeQuery(conn, sql)
        Dim idImmagine As Long = rec("id").Value
        rec.Close()

        sql = "Delete * From CRC Where idImmagine=" & idImmagine
        db.EsegueSql(conn, sql)

        Dim Quale As Long = Visualizzate(qVisualizzate)

        CaricaImmagine(True, Quale, True)
    End Sub

    Private Sub cmdRuotaSx_Click(sender As Object, e As EventArgs) Handles cmdRuotaSx.Click
        Dim gi As New GestioneImmagini
        Dim Nome As String = recImmagini("Descrizione").Value & "\" & recImmagini("NomeFile").Value
        gi.RuotaFoto(Nome, -90)
        gi = Nothing

        Dim sql As String = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(recImmagini("Descrizione").Value) & "'"
        Dim rec As Object = CreateObject("ADODB.Recordset")

        rec = db.LeggeQuery(conn, sql)
        Dim idCartella As Integer = rec("idCartella").Value
        rec.Close()

        sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(recImmagini("NomeFile").Value) & "'"
        rec = db.LeggeQuery(conn, sql)
        Dim idImmagine As Long = rec("id").Value
        rec.Close()

        sql = "Delete * From CRC Where idImmagine=" & idImmagine
        db.EsegueSql(conn, sql)

        Dim Quale As Long = Visualizzate(qVisualizzate)

        CaricaImmagine(True, Quale, True)
    End Sub

    Private Sub cmdRinomina_Click(sender As Object, e As EventArgs) Handles cmdRinomina.Click
        Dim NuovoNome As String = InputBox("Nuovo nome immagine", , recImmagini("NomeFile").Value)

        If NuovoNome <> "" Then
            Dim db As New GestioneDB
            Dim conn As Object = "ADODB.Connection"
            conn = db.ApreDB()
            Dim sql As String
            Dim CartellaOrig As String
            Dim NomeFile As String
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim idCartella As Integer
            Dim idImmagine As Long

            CartellaOrig = recImmagini("Descrizione").Value
            NomeFile = recImmagini("NomeFile").Value

            sql = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(CartellaOrig) & "'"
            rec = db.LeggeQuery(conn, sql)
            idCartella = rec("idCartella").Value
            rec.Close()

            sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(NomeFile) & "'"
            rec = db.LeggeQuery(conn, sql)
            idImmagine = rec("id").Value
            rec.Close()

            Rename(CartellaOrig & "\" & NomeFile, CartellaOrig & "\" & NuovoNome)

            sql = "Update Dati Set NomeFile='" & SistemaTestoPerDB(NuovoNome) & "' Where id=" & idImmagine
            db.EsegueSql(conn, sql)

            conn.Close()
            db = Nothing

            Dim Quale As Long = Visualizzate(qVisualizzate)

            CaricaImmagine(True, Quale, True)

            MsgBox("Immagine rinominata")
        End If
    End Sub

    Private Sub cmdSpostaSu_Click(sender As Object, e As EventArgs) Handles cmdSpostaSu.Click
        PictureBox1.Top -= 25

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdSpostaGiu_Click(sender As Object, e As EventArgs) Handles cmdSpostaGiu.Click
        PictureBox1.Top += 25

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdSpostaSin_Click(sender As Object, e As EventArgs) Handles cmdSpostaSin.Click
        PictureBox1.Left -= 25

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdSpostaDes_Click(sender As Object, e As EventArgs) Handles cmdSpostaDes.Click
        PictureBox1.Left += 25

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdCentra_Click(sender As Object, e As EventArgs) Handles cmdCentra.Click
        PictureBox1.Top = (Me.Height / 2) - (PictureBox1.Height / 2)
        PictureBox1.Left = (Me.Width / 2) - (PictureBox1.Width / 2)

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdRuotaHor_Click(sender As Object, e As EventArgs) Handles cmdRuotaHor.Click
        Dim gi As New GestioneImmagini
        Dim Nome As String = recImmagini("Descrizione").Value & "\" & recImmagini("NomeFile").Value
        gi.RuotaFoto(Nome, 1)
        gi = Nothing

        Dim sql As String = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(recImmagini("Descrizione").Value) & "'"
        Dim rec As Object = CreateObject("ADODB.Recordset")

        rec = db.LeggeQuery(conn, sql)
        Dim idCartella As Integer = rec("idCartella").Value
        rec.Close()

        sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(recImmagini("NomeFile").Value) & "'"
        rec = db.LeggeQuery(conn, sql)
        Dim idImmagine As Long = rec("id").Value
        rec.Close()

        sql = "Delete * From CRC Where idImmagine=" & idImmagine
        db.EsegueSql(conn, sql)

        Dim Quale As Long = Visualizzate(qVisualizzate)

        CaricaImmagine(True, Quale, True)
    End Sub

    Private Sub cmdRuotaVer_Click(sender As Object, e As EventArgs) Handles cmdRuotaVer.Click
        Dim gi As New GestioneImmagini
        Dim Nome As String = recImmagini("Descrizione").Value & "\" & recImmagini("NomeFile").Value
        gi.RuotaFoto(Nome, 2)
        gi = Nothing

        Dim sql As String = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(recImmagini("Descrizione").Value) & "'"
        Dim rec As Object = CreateObject("ADODB.Recordset")

        rec = db.LeggeQuery(conn, sql)
        Dim idCartella As Integer = rec("idCartella").Value
        rec.Close()

        sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(recImmagini("NomeFile").Value) & "'"
        rec = db.LeggeQuery(conn, sql)
        Dim idImmagine As Long = rec("id").Value
        rec.Close()

        sql = "Delete * From CRC Where idImmagine=" & idImmagine
        db.EsegueSql(conn, sql)

        Dim Quale As Long = Visualizzate(qVisualizzate)

        CaricaImmagine(True, Quale, True)
    End Sub

    Private Sub cmdFiltra_Click(sender As Object, e As EventArgs) Handles cmdFiltra.Click
        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.Recordset")

        If lblFiltro.Text = "" Then
            If cmbCategoria.Text = "" Then
                MsgBox("Selezionare una categoria")
                Exit Sub
            End If

            Dim Categoria As String = cmbCategoria.Text

            Sql = "Select Count(*) From Dati A " & _
                 "Left Join Cartelle B On A.idCartella=B.idCartella " & _
                 "Where B.Descrizione Like '%" & Categoria & "%'"
            rec = db.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Quante = 0
            Else
                Quante = rec(0).Value
            End If
            rec.Close()

            Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From Dati A " & _
                 "Left Join Cartelle B On A.idCartella=B.idCartella " & _
                 "Where B.Descrizione Like '%" & Categoria & "%'"
            recImmagini = db.LeggeQuery(conn, Sql)

            lblFiltro.Text = "FILTRATI"

            CaricaImmagine(True, 0)
        Else
            lblFiltro.Text = ""

            Sql = "Select Count(*) From Dati"
            rec = db.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Quante = 0
            Else
                Quante = rec(0).Value
            End If
            rec.Close()

            Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From Dati A Left Join Cartelle B On A.idCartella=B.idCartella"
            recImmagini = db.LeggeQuery(conn, Sql)

            Dim Quale As Long = GetSetting("Uguaglianze", "Impostazioni", "QualeImmVisua", -1)

            CaricaImmagine(True, Quale)
        End If
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        pnlFiltro.Visible = True

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdChiudeFiltro_Click(sender As Object, e As EventArgs) Handles cmdChiudeFiltro.Click
        pnlFiltro.Visible = False

        cmdOperazioni.Focus()
    End Sub

    Private Sub cmdApplicafiltro_Click(sender As Object, e As EventArgs) Handles cmdApplicafiltro.Click
        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.Recordset")

        If lblFiltro2.Text = "" Then
            Dim Direct As String = cmbDirectory.Text
            Dim Altro As String = ""

            If Direct <> "" Then
                Altro = "B.Descrizione Like '%" & Direct & "%' "
            End If
            If txtTesto.Text <> "" Then
                If Altro <> "" Then
                    Altro = Altro & " And "
                End If
                Altro = Altro & "A.NomeFile Like '%" & txtTesto.Text & "%' "
            End If

            If Altro <> "" Then
                Altro = "Where " & Altro
            End If
            Sql = "Select Count(*) From Dati A " & _
                 "Left Join Cartelle B On A.idCartella=B.idCartella " & _
                 " " & Altro
            rec = db.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Quante = 0
            Else
                Quante = rec(0).Value
            End If
            rec.Close()

            Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From Dati A " & _
                 "Left Join Cartelle B On A.idCartella=B.idCartella " & _
                 " " & Altro
            recImmagini = db.LeggeQuery(conn, Sql)

            lblFiltro2.Text = "FILTRATI PER DIRECTORY"

            CaricaImmagine(True, 0)
        Else
            lblFiltro2.Text = ""

            Sql = "Select Count(*) From Dati"
            rec = db.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Quante = 0
            Else
                Quante = rec(0).Value
            End If
            rec.Close()

            Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From Dati A Left Join Cartelle B On A.idCartella=B.idCartella"
            recImmagini = db.LeggeQuery(conn, Sql)

            Dim Quale As Long = GetSetting("Uguaglianze", "Impostazioni", "QualeImmVisua", -1)

            CaricaImmagine(True, Quale)
        End If
    End Sub

    Private Sub ImmaginiSimili()
        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.Recordset")

        If lblSimili.Text = "" Then
            Me.Cursor = Cursors.WaitCursor

            Dim Parte As String = ""

            Sql = "Select CRC From CRC Where idImmagine=" & recImmagini("id").Value
            rec = db.LeggeQuery(conn, Sql)
            If rec.Eof = False Then
                Parte = rec("CRC").Value
            End If
            rec.Close()

            If Parte = "" Then
                Dim gi As New GestioneImmagini
                Dim gf As New GestioneFilesDirectory

                gi.CreaValoreUnivocoImmagine(recImmagini("id").Value, db, conn, recImmagini("Descrizione").Value & "\" & recImmagini("NomeFile").Value, gf)

                Sql = "Select CRC From CRC Where idImmagine=" & recImmagini("id").Value
                rec = db.LeggeQuery(conn, Sql)
                If rec.Eof = False Then
                    Parte = rec("CRC").Value
                End If
                rec.Close()

                gi = Nothing
                gf = Nothing
            End If

            Dim Parte2 As String
            Dim Quanti As Integer
            Dim Trovati As String = ""
            Dim QuanteTrovate As Integer = 0

            Sql = "Select * From CRC"
            rec = db.LeggeQuery(conn, Sql)
            Do Until rec.Eof
                Parte2 = rec("Crc").Value.ToString

                Quanti = 0
                For i As Integer = 1 To Parte2.Length
                    If Mid(Parte2, i, 1) = Mid(Parte, i, 1) Then
                        Quanti += 1
                    End If
                Next

                If Quanti > 245 Then
                    Trovati += rec("idImmagine").Value & ","
                    QuanteTrovate += 1
                End If

                rec.MoveNext()
            Loop
            rec.Close()

            Trovati = Mid(Trovati, 1, Trovati.Length - 1)

            'Dim lungh As Integer = (Parte.Length * 65) / 100

            'Parte = Mid(Parte, 136, 68)

            'Sql = "Select Count(*) From (Dati A " & _
            '     "Left Join Cartelle B On A.idCartella=B.idCartella) " & _
            '     "Left Join CRC C On A.id=C.idImmagine " & _
            '     "Where CRC Like '%" & Parte & "%' " ' Or Dimensione=" & recImmagini("Dimensione").Value & " " & _
            '' "Or (DimeX=" & recImmagini("DimeX").Value & " And DimeY=" & recImmagini("DimeY").Value & ")"
            'rec = db.LeggeQuery(conn, Sql)
            'If rec(0).Value Is DBNull.Value = True Then
            '    Quante = 0
            'Else
            '    Quante = rec(0).Value
            'End If
            'rec.Close()

            Quante = QuanteTrovate

            'Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From (Dati A " & _
            '     "Left Join Cartelle B On A.idCartella=B.idCartella) " & _
            '     "Left Join CRC C On A.id=C.idImmagine " & _
            '     "Where CRC Like '%" & Parte & "%' " ' Or Dimensione=" & recImmagini("Dimensione").Value & " " & _
            ''"Or (DimeX=" & recImmagini("DimeX").Value & " And DimeY=" & recImmagini("DimeY").Value & ")"
            Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From (Dati A " & _
                 "Left Join Cartelle B On A.idCartella=B.idCartella) " & _
                 "Where A.id In (" & Trovati & ")"
            recImmagini = db.LeggeQuery(conn, Sql)

            lblSimili.Text = "SIMILI"

            CaricaImmagine(True, 0)

            Me.Cursor = Cursors.Arrow

            MsgBox("Simili impostati")
        Else
            lblSimili.Text = ""

            Sql = "Select Count(*) From Dati"
            rec = db.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value = True Then
                Quante = 0
            Else
                Quante = rec(0).Value
            End If
            rec.Close()

            Sql = "Select A.id, B.Descrizione, A.NomeFile, A.Dimensione, A.DimeX, A.DimeY From Dati A Left Join Cartelle B On A.idCartella=B.idCartella"
            recImmagini = db.LeggeQuery(conn, Sql)

            Dim Quale As Long = GetSetting("Uguaglianze", "Impostazioni", "QualeImmVisua", -1)

            CaricaImmagine(True, Quale)

            MsgBox("Simili De-impostati")
        End If
    End Sub
End Class