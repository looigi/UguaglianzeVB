Imports Goheer.EXIF
Imports System.IO

Public Class frmMain
    Private Const SPI_SETDESKWALLPAPER As Integer = &H14
    Private Const SPIF_UPDATEINIFILE As Integer = &H1
    Private Const SPIF_SENDWININICHANGE As Integer = &H2

    Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()

    Private Percorso As String
    Private A As Integer
    Private Const ValoreControlloMinimo As Integer = 1

    Private Const DimensioneMinimaBytes As Integer = 15000
    Private Const DimensioneMinimaX As Integer = 280

    Private dimSchermoX As Integer
    Private dimSchermoY As Integer

    Private Const NomeCategorie As String = "Recordset"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dimSchermoX = My.Computer.Screen.Bounds.Width
        dimSchermoY = My.Computer.Screen.Bounds.Height

        Percorso = GetSetting("Uguaglianze", "Impostazioni", "Percorso", Application.StartupPath)
        lblPosiImmagini.Text = GetSetting("Uguaglianze", "Impostazioni", "PercorsoAgg", Application.StartupPath)
        chkExif.Checked = GetSetting("Uguaglianze", "Impostazioni", "CaricaEXIF", "False")
        chkControlla.Checked = GetSetting("Uguaglianze", "Impostazioni", "Controlla", "False")
        chkLeggeImmagini.Checked = GetSetting("Uguaglianze", "Impostazioni", "Legge", "True")
        chkEliminaInes.Checked = GetSetting("Uguaglianze", "Impostazioni", "EliminaInesistenti", "True")
        chkRidimensiona.Checked = GetSetting("Uguaglianze", "Impostazioni", "Ridimensiona", "True")
        chkPulisceUguali.Checked = GetSetting("Uguaglianze", "Impostazioni", "PulisceUguali", "False")
        chkPulisceCRC.Checked = GetSetting("Uguaglianze", "Impostazioni", "PulisceCRC", "False")
        chkPulisceDati.Checked = GetSetting("Uguaglianze", "Impostazioni", "PulisceDati", "False")
        chkPulisceCategorie.Checked = GetSetting("Uguaglianze", "Impostazioni", "PulisceCategorie", "False")
        chkCartelleVuote.Checked = GetSetting("Uguaglianze", "Impostazioni", "CartelleVuote", "True")
        chkCreaCRC.Checked = GetSetting("Uguaglianze", "Impostazioni", "CreaCRC", "True")
        chkNomiLunghi.Checked = GetSetting("Uguaglianze", "Impostazioni", "PathLunghi", "True")

        chkPulisceUguali.Visible = False
        chkPulisceCRC.Visible = False
        chkPulisceDati.Visible = False
        chkPulisceCategorie.Visible = False

        If chkControlla.Checked = False Then
            chkPerCRC.Visible = False
            chkPerData.Visible = False
            chkPerDime.Visible = False
            chkPerExif.Visible = False
            chkPerZero.Visible = False
            chkPerPiccole.Visible = False
            chkPerNonValide.Visible = False
            chkNomiLunghi.Visible = False
        Else
            chkPerCRC.Visible = True
            chkPerData.Visible = True
            chkPerDime.Visible = True
            chkPerExif.Visible = True
            chkPerZero.Visible = True
            chkPerPiccole.Visible = True
            chkPerNonValide.Visible = True
            chkNomiLunghi.Visible = True
        End If
        chkPerCRC.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerCRC", "True")
        chkPerData.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerData", "True")
        chkPerDime.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerDime", "True")
        chkPerExif.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerEXIF", "False")
        chkPerZero.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerZero", "False")
        chkPerPiccole.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerPiccole", "False")
        chkPerNonValide.Checked = GetSetting("Uguaglianze", "Impostazioni", "PerNonValide", "False")
        chkAccorpa.Checked = GetSetting("Uguaglianze", "Impostazioni", "Accorpa", "True")
        chkSistemaNomi.Checked = GetSetting("Uguaglianze", "Impostazioni", "SistemaNomi", "True")

        chkCompatta.Checked = GetSetting("Uguaglianze", "Impostazioni", "Compatta", "True")

        lblDirectory.Text = Percorso

        ContaImmagini()

        ControllaUguali()
    End Sub

    Private Sub ContaImmagini()
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"

        sql = "Select Count(*) From PrendeUguali Where Ricordato='N' And NomeDiverso <> 0"
        rec = db.LeggeQuery(conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            lblTotUguali.Text = "0"
            cmdShow.Visible = False
        Else
            lblTotUguali.Text = FormattaNumero(rec(0).Value, False, 8)
            cmdShow.Visible = True
        End If
        rec.Close()

        sql = "Select Count(*) From Dati Where Valida='S' Or Valida=''"
        rec = db.LeggeQuery(conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            lblTotImmagini.Text = "0"
        Else
            lblTotImmagini.Text = FormattaNumero(rec(0).Value, False, 8)
        End If
        rec.Close()

        db.EsegueSql(conn, "delete * from uguali where Ricordato  ='N' And idprimo in (select Dati.id from PrendeUguali where NomeDiverso = 0 and Ricordato='N') and idsecondo in (select Dati_1.id from PrendeUguali where NomeDiverso = 0 and Ricordato='N')")

        conn.Close()
        db = Nothing
    End Sub

    Private Sub ControllaUguali()
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"

        cmdUguali.Visible = False

        sql = "Select Count(*) From PrendeUguali Where Ricordato='N' And NomeDiverso <> 0"
        rec = db.LeggeQuery(conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
        Else
            If rec(0).Value > 0 Then
                'lblUguali.Text = "Uguali rilevate: " & FormattaNumero(rec(0).Value, False, 8)
                cmdUguali.Visible = True
            End If
        End If
        rec.Close()

        db.EsegueSql(conn, "delete * from uguali where Ricordato  ='N' And idprimo in (select Dati.id from PrendeUguali where NomeDiverso = 0 and Ricordato='N') and idsecondo in (select Dati_1.id from PrendeUguali where NomeDiverso = 0 and Ricordato='N')")

        conn.Close()
        db = Nothing
    End Sub

    Private Function RitornaDatiExif(Immagine As String) As String()
        Dim Campi() As String = {}

        If File.Exists(Immagine) = True Then
            Dim imm As Bitmap = Image.FromFile(Immagine)

            Try
                Dim er As EXIFextractor = New EXIFextractor(imm, "§")
                Campi = er.ToString.Split("§")
                er = Nothing
            Catch ex As Exception

            End Try

            imm.Dispose()
            imm = Nothing

        End If

        Return Campi
    End Function

    Private Sub cmdImpostaDir_Click(sender As Object, e As EventArgs) Handles cmdImpostaDir.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Percorso = FolderBrowserDialog1.SelectedPath
            lblDirectory.Text = Percorso
            SaveSetting("Uguaglianze", "Impostazioni", "Percorso", Percorso)
        End If
    End Sub

    Private Sub cmdUscita_Click(sender As Object, e As EventArgs) Handles cmdUscita.Click
        End
    End Sub

    Private Sub PulisceDati(Db As GestioneDB, Conn As Object)
        Dim Sql As String

        If chkPulisceCategorie.Checked = True Then
            Sql = "Delete * From Categorie"
            Db.EsegueSql(Conn, Sql)
        End If

        If chkPulisceDati.Checked = True Then
            Sql = "Delete * From Dati"
            Db.EsegueSql(Conn, Sql)

            Sql = "Delete * From DatiEXIF"
            Db.EsegueSql(Conn, Sql)

            Sql = "Delete * From DescrizioniEXIF"
            Db.EsegueSql(Conn, Sql)

            Sql = "Delete * From DescrizioniTestoEXIF"
            Db.EsegueSql(Conn, Sql)

            Sql = "Delete * From Cartelle"
            Db.EsegueSql(Conn, Sql)
        End If

        If chkPulisceUguali.Checked = True Then
            Sql = "Delete * From Uguali"
            Db.EsegueSql(Conn, Sql)
        End If

        If chkPulisceCRC.Checked = True Then
            Sql = "Delete * From CRC"
            Db.EsegueSql(Conn, Sql)
        End If
    End Sub

    Private Sub cmdEsegui_Click(sender As Object, e As EventArgs) Handles cmdEsegui.Click
        pnlEsecuzione.Visible = True
        pnlEsecuzione.Left = pnlComandi.Left ' (Me.Width / 2) - (pnlEsecuzione.Width / 2)
        pnlEsecuzione.Top = pnlComandi.Top ' (Me.Height / 2) - (pnlEsecuzione.Height / 2) - 20
        pnlEsecuzione.Width = pnlComandi.Width
        pnlEsecuzione.Height = pnlComandi.Height
        BloccaTuttoEdEsci = False
        lblTipoOperazione.Text = ""
        lblAvanzamento.Text = ""
        cmdImpostaDir.Enabled = False
        lblPosiImmagini.Enabled = False
        cmdImpostaAgg.Enabled = False
        Application.DoEvents()

        pnlComandi.Visible = False
        lblAvanzamento.Visible = True
        lblAvanzamento.Text = ""
        Application.DoEvents()
        Try
            MkDir(Application.StartupPath & "\Thumbs")
        Catch ex As Exception

        End Try

        Dim gi As New GestioneImmagini
        Dim gf As New GestioneFilesDirectory
        Dim QuantiFiles As Long
        Dim sQuantiFiles As String = ""

        lblTipoOperazione.Text = ""
        Application.DoEvents()

        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"

        Dim Immagini() As String = {}

        If chkLeggeImmagini.Checked = True Then
            gf.ScansionaDirectorySingola(lblDirectory.Text, "", lblAvanzamento) '
            QuantiFiles = gf.RitornaQuantiFilesRilevati
            Immagini = gf.RitornaFilesRilevati
            sQuantiFiles = FormattaNumero(QuantiFiles, False, 8)
        End If

        If chkPulisci.Checked = True Then
            PulisceDati(db, conn)
        End If

        If chkAccorpa.Checked = True And BloccaTuttoEdEsci = False Then
            AccorpaImmaginiFase1(db, conn)
        End If

        If chkLeggeImmagini.Checked = True And BloccaTuttoEdEsci = False Then
            Dim Tot As Long
            Dim Nome As String
            Dim Estensione As String
            Dim Cartella As String
            Dim Massimo As Long
            Dim dime() As String
            Dim Scrivi As Boolean
            Dim idCartella As Integer
            Dim Caricate As Long = 0
            Dim rec2 As Object = "ADODB.Recordset"
            Dim sTot As String
            Dim Ok As Boolean
            Dim Quale As Long = 0
            Dim sDime As String
            Dim DimensioneFile As Long
            Dim DataFile As String

            sql = "Select Count(*) From Dati"
            rec = db.LeggeQuery(conn, sql)
            If rec(0).Value Is DBNull.Value = True Then
                Tot = 0
            Else
                Tot = rec(0).Value
            End If
            rec.Close()

            sql = "Select Max(id) From Dati"
            rec = db.LeggeQuery(conn, sql)
            If rec(0).Value Is DBNull.Value = True Then
                Massimo = 0
            Else
                Massimo = rec(0).Value
            End If
            rec.Close()

            lblTipoOperazione.Text = "Lettura immagini"

            For Quale = 1 To QuantiFiles
                sTot = FormattaNumero(Tot, False)

                If Quale / 100 = Int(Quale / 100) Then
                    lblAvanzamento.Text = "Elaborazione: " & FormattaNumero(Quale, False) & "/" & sQuantiFiles & " - Caricate: " & FormattaNumero(Caricate, False) & " - In archivio: " & sTot
                    Application.DoEvents()
                End If

                If BloccaTuttoEdEsci = True Then
                    Exit For
                End If

                Nome = gf.TornaNomeFileDaPath(Immagini(Quale))
                Cartella = gf.TornaNomeDirectoryDaPath(Immagini(Quale))
                Estensione = gf.TornaEstensioneFileDaPath(Nome).ToUpper.Trim

                If File.Exists(Immagini(Quale)) = True Then
                    If Estensione = ".JPG" Or Estensione = ".JPEG" Or Estensione = ".BMP" Or Estensione = ".PNG" Or Estensione = ".GIF" Then
                        Ok = True
                        If Estensione = ".BMP" Then
                            Dim PicImmagine As PictureBox = New PictureBox
                            Dim fs As System.IO.FileStream
                            fs = New System.IO.FileStream(Cartella & "\" & Nome,
                             IO.FileMode.Open, IO.FileAccess.Read)
                            PicImmagine.Image = System.Drawing.Image.FromStream(fs)
                            fs.Close()
                            fs = Nothing

                            Dim VecchioNome As String = Nome
                            Dim Est As String = gf.TornaEstensioneFileDaPath(Nome)
                            Nome = Nome.Replace(Est, "") & ".Jpg"

                            gi.SalvaImmagineDaPictureBox(Cartella & "\" & Nome, PicImmagine.Image)

                            If File.Exists(Cartella & "\" & Nome) = True Then
                                Try
                                    Kill(Cartella & "\" & VecchioNome)
                                Catch ex As Exception

                                End Try
                            End If
                        End If
                    Else
                        Ok = False

                        If Nome.ToUpper.Trim = "THUMBS.DB" Then
                            gf.EliminaFileFisico(Cartella & "\" & Nome)
                        End If

                        If Estensione = "" Then
                            Rename(Cartella & "\" & Nome, Cartella & "\" & Nome & ".Jpg")
                            Nome += ".Jpg"
                        End If
                    End If

                    If Ok = True Then
                        sql = "Select idCartella From Cartelle Where Descrizione='" & Cartella.Replace("'", "''").Trim & "'"
                        rec = db.LeggeQuery(conn, sql)
                        If rec.Eof = True Then
                            idCartella = -1
                        Else
                            idCartella = rec(0).Value
                        End If
                        rec.Close()

                        sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & Nome.Replace("'", "''") & "' And (Valida='S' Or Valida='')"
                        rec = db.LeggeQuery(conn, sql)
                        Scrivi = False
                        If rec.Eof = True Then
                            Caricate += 1
                            Tot += 1
                            Massimo += 1

                            If chkCreaCRC.Checked = True Then
                                sDime = gi.RitornaDimensioneImmagine(Cartella & "\" & Nome)
                            Else
                                sDime = "0x0"
                            End If

                            If sDime.IndexOf("ERRORE:") > -1 Then
                                ReDim Preserve dime(1)
                                dime(0) = 0
                                dime(1) = 0
                            Else
                                dime = sDime.Split("x")
                            End If

                            Scrivi = True

                            If idCartella = -1 Then
                                sql = "Select Max(idCartella)+1 From Cartelle"
                                rec2 = db.LeggeQuery(conn, sql)
                                If rec2(0).Value Is DBNull.Value = True Then
                                    idCartella = 1
                                Else
                                    idCartella = rec2(0).Value
                                End If
                                rec2.Close()

                                sql = "Insert Into Cartelle Values (" & idCartella & ", '" & Cartella.Replace("'", "''").Trim & "')"
                                db.EsegueSql(conn, sql)
                            End If

                            If chkCreaCRC.Checked = True Then
                                DimensioneFile = gf.TornaDimensioneFile(Cartella & "\" & Nome).ToString.Replace(",", ".")
                                DataFile = FileDateTime(Cartella & "\" & Nome)
                            Else
                                DimensioneFile = 0
                                DataFile = "01/01/1900 00:00:00"
                            End If

                            sql = "Insert Into Dati Values (" &
                                " " & Massimo & ", " &
                                "'" & idCartella & "', " &
                                "'" & Nome.Replace("'", "''") & "', " &
                                "'" & DataFile & "', " &
                                " " & DimensioneFile & ", " &
                                " " & dime(0) & ", " &
                                " " & dime(1) & ", " &
                                "'N', " &
                                "'N', " &
                                "'' " &
                                ")"
                        End If
                        rec.Close()

                        If Scrivi = True Then
                            db.EsegueSql(conn, sql)

                            If chkCreaCRC.Checked = True Then
                                gi.CreaValoreUnivocoImmagine(Massimo, db, conn, Cartella & "\" & Nome, gf)
                            End If
                        End If
                    Else
                        Try
                            Kill(Cartella & "\" & Nome)
                        Catch ex As Exception

                        End Try
                    End If
                End If
            Next
        End If

        If chkEliminaInes.Checked = True And BloccaTuttoEdEsci = False Then
            EliminaInesistenti(db, conn)
        End If

        If chkLeggeImmagini.Checked = True And BloccaTuttoEdEsci = False Then
            LeggeCRCEliminati(db, conn)
        End If

        If chkRidimensiona.Checked = True And BloccaTuttoEdEsci = False Then
            Ridimensiona(db, conn)
        End If

        If chkExif.Checked = True And BloccaTuttoEdEsci = False Then
            LeggeExif(db, conn)
        End If

        If chkSistemaNomi.Checked = True And BloccaTuttoEdEsci = False Then
            SistemaNomi(db, conn)
        End If

        If chkAccorpa.Checked = True And BloccaTuttoEdEsci = False Then
            AccorpaImmaginiFase2(db, conn)
        End If

        If chkControlla.Checked = True And BloccaTuttoEdEsci = False Then
            EffettuaControlli(db, conn)
        End If

        'If chkCartelleVuote.Checked = True And BloccaTuttoEdEsci = False Then
        '    EliminaCartelleVuote(db, conn)
        'End If

        Try
            conn.Close()
        Catch ex As Exception

        End Try

        db = Nothing

        If chkNomiLunghi.Checked Then
            lblAvanzamento.Text = ""
            lblTipoOperazione.Text = "Controllo lunghezza directory e vuote"
            Application.DoEvents()
            ControllaNomiDirectoryTroppoLunghe(gf, lblDirectory.Text)
        End If

        gf = Nothing
        gi = Nothing

        If chkCompatta.Checked = True And BloccaTuttoEdEsci = False Then
            lblAvanzamento.Text = ""
            lblTipoOperazione.Text = "Compattazione DB"
            Application.DoEvents()

            Dim db2 As New GestioneDB

            db2.Compactdb()

            db2 = Nothing
        End If

        lblAvanzamento.Visible = False

        ContaImmagini()

        ControllaUguali()

        cmdImpostaDir.Enabled = True

        lblPosiImmagini.Enabled = True
        cmdImpostaAgg.Enabled = True
        pnlEsecuzione.Visible = False
        pnlComandi.Visible = True

        MsgBox("Elaborazione completata")
    End Sub

    Private Sub ControllaNomiDirectoryTroppoLunghe(gf As GestioneFilesDirectory, Path As String)
        gf.ScansionaDirectorySingola(Path)
        Dim dire() As String = gf.RitornaDirectoryRilevate
        Dim qDire As Integer = gf.RitornaQuanteDirectoryRilevate
        'Dim Zero() As String = Nothing
        'Dim qZero As Integer = 0
        Dim Lunghe() As String = Nothing
        Dim qLunghe As Integer = 0
        Dim sFiles() As String
        Dim sDir() As String
        Dim NumeroFiles As Integer = -1
        Dim NumeroDir As Integer = -1
        Dim Eliminate As Integer = 0

        For i As Integer = 1 To qDire
            For k As Integer = i + 1 To qDire
                If dire(i).Length < dire(k).Length Then
                    Dim appo As String = dire(i)
                    dire(i) = dire(k)
                    dire(k) = appo
                End If
            Next
        Next

        For i As Integer = 1 To qDire
            Try
                Kill(dire(i) & "\Thumbs.db")
            Catch ex As Exception

            End Try
            Try
                sFiles = Directory.GetFiles(dire(i))
                NumeroFiles = sFiles.Count
                sDir = Directory.GetDirectories(dire(i))
                NumeroDir = sDir.Count
            Catch ex As Exception
                NumeroFiles = 0
                NumeroDir = 0
            End Try

            If NumeroDir = 0 And NumeroFiles = 0 Then
                Try
                    RmDir(dire(i))

                    Eliminate += 1
                Catch ex As Exception

                End Try
            End If

            If i / 100 = Int(i / 100) Then
                lblAvanzamento.Text = "Directory eliminate: " & Eliminate & " - " & i & "/" & qDire
                Application.DoEvents()
            End If

            If dire(i).Length > 210 Then
                qLunghe += 1
                ReDim Preserve Lunghe(qLunghe)
                Lunghe(qLunghe) = dire(i)
            End If
        Next
        If qLunghe > 0 Then
            Dim Cosa As String = ""
            For i As Integer = 1 To qLunghe
                Cosa += Lunghe(i) & vbCrLf
            Next
            gf.CreaAggiornaFile(Application.StartupPath & "\Lunghe.Dat", Cosa)

            Shell("Notepad " & Application.StartupPath & "\Lunghe.Dat", AppWinStyle.NormalFocus)
        End If
    End Sub

    'Private Sub EliminaCartelleVuote(db As GestioneDB, conn As Object)
    '    Dim oCartelle() As String = {}
    '    Dim QuanteCartelle As Long = 0
    '    Dim Appoggio As String
    '    Dim Sql As String
    '    Dim Ok As Boolean
    '    Dim rec As Object = CreateObject("ADODB.Recordset")
    '    Dim Eliminate As Long = 0

    '    Sql = "Select Distinct Descrizione From Cartelle"
    '    rec = db.LeggeQuery(conn, Sql)
    '    Do Until rec.eof
    '        ReDim Preserve oCartelle(QuanteCartelle)
    '        oCartelle(QuanteCartelle) = rec("Descrizione").Value
    '        QuanteCartelle += 1

    '        rec.movenext()
    '    Loop
    '    rec.Close()

    '    lblAvanzamento.Text = ""
    '    lblTipoOperazione.Text = "Eliminazione cartelle vuote"
    '    Application.DoEvents()

    '    For i As Long = 0 To QuanteCartelle - 1
    '        For k As Long = i + 1 To QuanteCartelle - 1
    '            If oCartelle(i) < oCartelle(k) Then
    '                Appoggio = oCartelle(i)
    '                oCartelle(i) = oCartelle(k)
    '                oCartelle(k) = Appoggio
    '            End If
    '        Next
    '    Next
    '    For i As Long = 0 To QuanteCartelle - 1
    '        oCartelle(i) += "\"
    '    Next

    '    For i As Long = 0 To QuanteCartelle - 1
    '        If BloccaTuttoEdEsci = True Then
    '            Exit For
    '        End If

    '        If oCartelle(i).IndexOf("\V\") = -1 And oCartelle(i).IndexOf("\N\") = -1 Then
    '            Appoggio = Mid(oCartelle(i), 1, oCartelle(i).Length - 1)
    '            Ok = True
    '            Try
    '                Directory.Delete(Appoggio)

    '                Eliminate += 1
    '            Catch ex As Exception
    '                Ok = False
    '            End Try

    '            If Ok = True Then
    '                Sql = "Delete From Cartelle Where Descrizione='" & Appoggio & "'"
    '                db.EsegueSql(conn, Sql)
    '            End If

    '            lblAvanzamento.Text = "Controllo " & i & "/" & QuanteCartelle - 1 & " - Eliminate: " & Eliminate
    '            Application.DoEvents()
    '        End If
    '    Next
    'End Sub

    Private Sub LeggeCRCEliminati(Db As GestioneDB, Conn As Object)
        If chkCreaCRC.Checked = False Then
            Exit Sub
        End If

        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.RecordSet")
        Dim gi As New GestioneImmagini
        Dim gf As New GestioneFilesDirectory
        Dim Tot As Long
        Dim sTot As String
        Dim Quale As Long
        Dim id As Long
        Dim Cartella As String
        Dim Nome As String

        Sql = "DELETE * FROM CRC WHERE idImmagine Not In (Select id From Dati);"
        Db.EsegueSql(Conn, Sql)

        Sql = "SELECT Count(*) FROM Dati Where id Not In (Select idImmagine From CRC)"
        rec = Db.LeggeQuery(Conn, Sql)
        If rec(0).Value Is DBNull.Value = True Then
            Tot = 0
        Else
            Tot = rec(0).Value
        End If
        rec.Close()
        sTot = FormattaNumero(Tot, False)

        lblTipoOperazione.Text = "Aggiornamento CRC"
        Application.DoEvents()

        Sql = "SELECT A.*, B.Descrizione FROM Dati A " &
            "Left Join Cartelle B On A.idCartella = B.idCartella " &
            "Where id Not In (Select idImmagine From CRC)"
        rec = Db.LeggeQuery(Conn, Sql)
        Quale = 0
        Do Until rec.Eof
            Quale += 1

            If BloccaTuttoEdEsci = True Then
                Exit Do
            End If

            lblAvanzamento.Text = "Elaborazione: " & FormattaNumero(Quale, False) & "/" & sTot
            Application.DoEvents()

            id = rec("id").Value
            Cartella = rec("Descrizione").Value
            Nome = rec("NomeFile").Value

            gi.CreaValoreUnivocoImmagine(id, Db, Conn, Cartella & "\" & Nome, gf)

            rec.MoveNext()
        Loop
        rec.Close()

        gi = Nothing
        gf = Nothing
    End Sub

    Private Sub LeggeExif(Db As GestioneDB, Conn As Object)
        Dim DatiExif() As String
        Dim SottoDatiExif() As String
        Dim idExif As Long
        Dim MassimoExif As Long
        Dim idExifTesto As Long
        Dim MassimoExifTesto As Long
        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.RecordSet")
        Dim rec2 As Object = CreateObject("ADODB.RecordSet")
        Dim Tot As Long
        Dim sTot As String
        Dim Quale As Long = 0
        Dim id As String
        Dim Nome As String
        Dim Cartella As String
        Dim TestoPerDB As String

        Sql = "Select Max(idDescrizione) From DescrizioniEXIF"
        rec = Db.LeggeQuery(Conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            MassimoExif = 0
        Else
            MassimoExif = rec(0).Value
        End If
        rec.Close()

        sql = "Select Max(idDescrizioneTesto) From DescrizioniTestoEXIF"
        rec = Db.LeggeQuery(Conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            MassimoExifTesto = 0
        Else
            MassimoExifTesto = rec(0).Value
        End If
        rec.Close()

        Sql = "Select Count(*) From Dati A " &
            "Left Join Cartelle B On A.idCartella=B.idCartella " &
            "Where (LettoExif='N' Or LettoExif='' Or LettoExif Is Null) And Descrizione Not Like '%picDROP%' And (Valida='S' Or Valida='')"
        rec = Db.LeggeQuery(Conn, Sql)
        If rec(0).Value Is DBNull.Value = True Then
            Tot = 0
        Else
            Tot = rec(0).Value
        End If
        rec.Close()
        sTot = FormattaNumero(Tot, False)

        lblTipoOperazione.Text = "Lettura EXIF"
        Application.DoEvents()

        Sql = "Select A.id, A.NomeFile, B.Descrizione, A.LettoEXIF From Dati A " &
            "Left Join Cartelle B On A.idCartella=B.idCartella " &
            "Where (LettoExif='N' Or LettoExif='' Or LettoExif Is Null) And Descrizione Not Like '%picDROP%' And (Valida='S' Or Valida='')"
        rec2 = Db.LeggeQuery(Conn, Sql)
        Do Until rec2.Eof
            Quale += 1

            If BloccaTuttoEdEsci = True Then
                Exit Do
            End If

            lblAvanzamento.Text = "Elaborazione: " & FormattaNumero(Quale, False) & "/" & sTot
            Application.DoEvents()

            Nome = rec2("NomeFile").Value
            Cartella = rec2("Descrizione").Value
            id = rec2("id").Value

            Sql = "Delete From DatiEXIF Where idImmagine=" & id
            Db.EsegueSql(Conn, Sql)

            DatiExif = RitornaDatiExif(Cartella & "\" & Nome)

            For k As Integer = 0 To DatiExif.Length - 1
                If DatiExif(k) <> "" Then
                    SottoDatiExif = DatiExif(k).Split(":")

                    Sql = "Select * From DescrizioniEXIF Where Descrizione='" & SottoDatiExif(0).Replace(":", "").Replace("'", "''").Replace(Chr(0), "").Trim & "'"
                    rec = Db.LeggeQuery(Conn, Sql)
                    If rec.eof = False Then
                        idExif = rec("idDescrizione").Value
                    Else
                        idExif = -1
                    End If
                    rec.Close()

                    If idExif = -1 Then
                        MassimoExif += 1
                        idExif = MassimoExif

                        Sql = "Insert into DescrizioniEXIF Values (" & MassimoExif & ", '" & SottoDatiExif(0).Replace(":", "").Replace("'", "''").Replace(Chr(0), "").Trim & "')"
                        Db.EsegueSql(Conn, Sql)
                    End If

                    Sql = "Select * From DescrizioniTestoEXIF Where DescrizioneTesto='" & SottoDatiExif(1).Replace(":", "").Replace("'", "''").Replace(Chr(0), "").Trim & "'"
                    rec = Db.LeggeQuery(Conn, Sql)
                    If rec.eof = False Then
                        idExifTesto = rec("idDescrizioneTesto").Value
                    Else
                        idExifTesto = -1
                    End If
                    rec.Close()

                    If idExifTesto = -1 Then
                        MassimoExifTesto += 1
                        idExifTesto = MassimoExifTesto

                        TestoPerDB = SistemaTestoPerDB(SottoDatiExif(1)).Replace(":", "").Replace(Chr(0), "").Trim
                        If TestoPerDB.Length > 255 Then
                            TestoPerDB = Mid(TestoPerDB, 1, 252) & "..."
                        End If

                        Sql = "Insert into DescrizioniTestoEXIF Values (" & MassimoExifTesto & ", '" & TestoPerDB & "')"
                        Db.EsegueSql(Conn, Sql)
                    End If

                    Sql = "Insert Into DatiEXIF Values (" & id & ", " & k & ", " & idExif & ", " & idExifTesto & ")"
                    Db.EsegueSql(Conn, Sql)
                End If
            Next

            Conn.BeginTrans()
            rec2("LettoEXIF") = "S"
            rec2.Update()
            Conn.CommitTrans()

            rec2.MoveNext()
        Loop

        rec2.Close()
    End Sub

    Private Sub SistemaNomi(Db As GestioneDB, Conn As Object)
        Dim Estensione As String
        Dim NomeMod As String
        Dim Nome As String
        Dim gf As New GestioneFilesDirectory
        Dim Cartella As String
        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.RecordSet")
        Dim Tot As Long
        Dim sTot As String
        Dim Quale As Long = 0
        Dim id As String
        'Dim DataFile As Date
        'Dim DataCreazioneFile As Date

        Sql = "Select Count(*) From Dati Where NomeSistemato='N' Or NomeSistemato='' Or NomeSistemato Is Null"
        rec = Db.LeggeQuery(Conn, Sql)
        If rec(0).Value Is DBNull.Value = True Then
            Tot = 0
        Else
            Tot = rec(0).Value
        End If
        rec.Close()
        sTot = FormattaNumero(Tot, False)

        lblTipoOperazione.Text = "Sistemazione Nomi"
        Application.DoEvents()

        Sql = "Select A.id, A.NomeFile, B.Descrizione, A.NomeSistemato From Dati A " & _
            "Left Join Cartelle B On A.idCartella=B.idCartella " & _
            "Where NomeSistemato='N' Or NomeSistemato='' Or NomeSistemato Is Null"
        rec = Db.LeggeQuery(Conn, Sql)
        Do Until rec.Eof
            Quale += 1

            If BloccaTuttoEdEsci = True Then
                Exit Do
            End If

            lblAvanzamento.Text = "Elaborazione: " & FormattaNumero(Quale, False) & "/" & sTot
            Application.DoEvents()

            Nome = rec("NomeFile").Value
            Cartella = rec("Descrizione").Value
            id = rec("id").Value

            Estensione = gf.TornaEstensioneFileDaPath(Nome)
            If Estensione = "" Then
                NomeMod = Nome
            Else
                NomeMod = Nome.Replace(Estensione, "")
            End If

            Dim Prima As String
            Dim Numero As String
            Dim C As Char
            Dim Valore As Integer
            Dim Dopo As String

            Do While NomeMod.IndexOf("%") > -1
                Prima = Mid(NomeMod, 1, NomeMod.IndexOf("%"))
                Numero = Mid(NomeMod, NomeMod.IndexOf("%") + 1, 3)
                Dopo = Mid(NomeMod, NomeMod.IndexOf("%") + 4, NomeMod.Length)

                Valore = Val("&H" & Mid(Numero, 2, Numero.Length) & "&")
                If IsNumeric(Valore) = True Then
                    C = Chr(Valore)
                Else
                    C = ""
                End If
                NomeMod = NomeMod.Replace(Numero, C)
            Loop
            NomeMod = NomeMod.Replace(":", "_")
            NomeMod = NomeMod.Replace("/", "_")
            NomeMod = NomeMod.Replace("+", " ")
            NomeMod = NomeMod.Trim

            NomeMod = NomeMod.Replace(". J Pg", "")
            If Mid(NomeMod, 2, 1) = " " Then
                NomeMod = Mid(NomeMod, 1, 1) & Mid(NomeMod, 3, NomeMod.Length)
            End If

            If NomeMod.IndexOf("(^)") > -1 Then
                Do While NomeMod.IndexOf("(^)") > -1
                    NomeMod = NomeMod.Replace("(^)", "")
                Loop
            End If
            Do While NomeMod.IndexOf("%B") > -1
                NomeMod = NomeMod.Replace("%B", " ")
            Loop
            NomeMod = NomeMod.Replace("-font", "")
            NomeMod = NomeMod.Replace("#", "")
            If Mid(NomeMod, 5, NomeMod.Length).IndexOf("-") > -1 Then
                NomeMod = Mid(NomeMod, 1, 5) & Mid(NomeMod, 6, NomeMod.Length).Replace("-", " ")
            End If
            If Mid(NomeMod, 5, NomeMod.Length).IndexOf("_") > -1 Then
                NomeMod = Mid(NomeMod, 1, 5) & Mid(NomeMod, 6, NomeMod.Length).Replace("_", " ")
            End If
            Do While NomeMod.IndexOf("00000") > -1
                NomeMod = NomeMod.Replace("00000", "")
            Loop
            If NomeMod.Length > 35 Then
                NomeMod = Mid(NomeMod, 1, 17) & Mid(NomeMod, NomeMod.Length - 17, NomeMod.Length)
            End If
            Do While NomeMod.IndexOf("+") > -1
                NomeMod = NomeMod.Replace("+", " ")
            Loop
            Do While NomeMod.IndexOf("&") > -1
                NomeMod = NomeMod.Replace("&", " ")
            Loop

            Do While NomeMod.IndexOf("  ") > -1
                NomeMod = NomeMod.Replace("  ", " ")
            Loop

            NomeMod = Mid(NomeMod, 1, 5).Replace("_", "-") & Mid(NomeMod, 6, NomeMod.Length)

            Dim Ancora As Boolean = IIf(IsNumeric(Mid(NomeMod, 1, 1)) = True, True, False)
            Dim Ik As Integer = 0

            Do While Ik <= NomeMod.Length And Ancora = True
                Ik += 1
                If IsNumeric(Mid(NomeMod, Ik, 1)) = True Then
                    Ancora = True
                Else
                    Exit Do
                End If
            Loop
            If Ik > 0 Then
                If Mid(NomeMod, Ik, 1) <> "-" Then
                    NomeMod = Mid(NomeMod, 1, Ik - 1) & "-" & Mid(NomeMod, Ik, NomeMod.Length).Trim
                End If
            End If
            Do While NomeMod.IndexOf("--") > -1
                NomeMod = NomeMod.Replace("--", "-")
            Loop

            NomeMod = NomeMod.Trim.ToLower
            NomeMod = MetteMaiuscole(NomeMod)
            NomeMod = Mid(NomeMod, 1, 1).ToUpper & Mid(NomeMod, 2, NomeMod.Length)

            'Dim Fine As Integer = NomeMod.Length - 2
            'Dim II As Integer = 1

            'Do While II <= Fine
            '    If Asc(Mid(NomeMod, II, 1)) >= Asc("A") And Asc(Mid(NomeMod, II, 1)) <= Asc("Z") And
            '        Mid(NomeMod, II + 1, 1) = " " And
            '        Asc(Mid(NomeMod, II + 2, 1)) >= Asc("A") And Asc(Mid(NomeMod, II + 2, 1)) <= Asc("Z") Then
            '        NomeMod = Mid(NomeMod, 1, II) & Mid(NomeMod, II + 2, NomeMod.Length)
            '        Fine -= 1
            '    End If
            '    II += 1
            'Loop

            If (NomeMod & Estensione).Trim <> Nome.Trim Then
                NomeMod = gf.CopiaFileFisico(Cartella & "\" & Nome, Cartella & "\" & NomeMod & Estensione, False)
                If File.Exists(Cartella & "\" & NomeMod) = True Then
                    gf.EliminaFileFisico(Cartella & "\" & Nome)

                    Nome = NomeMod
                End If
            End If

            Conn.BeginTrans()
            rec("NomeFile").Value = Nome
            rec("NomeSistemato").Value = "S"
            rec.Update()
            Conn.CommitTrans()

            rec.MoveNext()
        Loop
        rec.Close()
    End Sub

    Private Sub Ridimensiona(Db As GestioneDB, Conn As Object)
        Dim Nome As String
        Dim gf As New GestioneFilesDirectory
        Dim gi As New GestioneImmagini
        Dim Cartella As String
        Dim Sql As String
        Dim rec As Object = CreateObject("ADODB.RecordSet")
        Dim Tot As Long
        Dim sTot As String
        Dim Quale As Long = 0
        Dim id As String
        Dim sDimeX As String
        Dim sDime() As String
        Dim dx As Integer
        Dim dy As Integer
        Dim d1 As Single
        Dim d2 As Single
        Dim PercentualeResize As Single
        Dim dimeFilesOriginali As Single
        Dim dimeFilesRidimensionati As Single

        Sql = "Select Count(*) From Dati Where (DimeX>1700 Or DimeY>1300) And (Valida='S' Or Valida='')"
        rec = Db.LeggeQuery(Conn, Sql)
        If rec(0).Value Is DBNull.Value = True Then
            Tot = 0
        Else
            Tot = rec(0).Value
        End If
        rec.Close()
        sTot = FormattaNumero(Tot, False)

        lblTipoOperazione.Text = "Ridimensionamento"
        Application.DoEvents()

        Sql = "Select A.id, A.NomeFile, B.Descrizione, A.NomeSistemato, A.DimeX, A.DimeY, A.Dimensione From Dati A " &
            "Left Join Cartelle B On A.idCartella=B.idCartella " &
            "Where (DimeX>1700 Or DimeY>1300) And (Valida='S' Or Valida='')"
        rec = Db.LeggeQuery(Conn, Sql)
        Do Until rec.Eof
            Quale += 1

            If BloccaTuttoEdEsci = True Then
                Exit Do
            End If

            Nome = rec("NomeFile").Value
            Cartella = rec("Descrizione").Value
            id = rec("id").Value
            dimeFilesOriginali += rec("Dimensione").Value

            sDimeX = gi.RitornaDimensioneImmagine(Cartella & "\" & Nome)
            sDime = sDimeX.Split("x")
            If sDime(0).IndexOf("ERRORE") = -1 Then
                dx = Val(sDime(0))
                dy = Val(sDime(1))

                d1 = dx / (1366)
                d2 = dy / (1024)

                If d1 > d2 Then
                    PercentualeResize = d1
                Else
                    PercentualeResize = d2
                End If

                dx /= PercentualeResize
                dy /= PercentualeResize

                gi.Ridimensiona(Cartella & "\" & Nome, Cartella & "\" & Nome & ".rsz", dx, dy)
                If File.Exists(Cartella & "\" & Nome & ".rsz") = True Then
                    gf.EliminaFileFisico(Cartella & "\" & Nome)
                    Rename(Cartella & "\" & Nome & ".rsz", Cartella & "\" & Nome)

                    Conn.BeginTrans()
                    rec("Dimensione").Value = FileLen(Cartella & "\" & Nome)
                    rec("DimeX").Value = dx
                    rec("DimeY").Value = dy
                    rec.Update()
                    Conn.CommitTrans()

                    gi.CreaValoreUnivocoImmagine(id, Db, Conn, Cartella & "\" & Nome, gf)

                    dimeFilesRidimensionati += FileLen(Cartella & "\" & Nome)
                Else
                    dimeFilesRidimensionati += dimeFilesOriginali
                End If
            End If

            lblAvanzamento.Text = "Elaborazione: " & FormattaNumero(Quale, False) & "/" & sTot & " - Guadagno in Bytes: " & FormattaNumero(dimeFilesOriginali - dimeFilesRidimensionati, False)
            Application.DoEvents()

            rec.MoveNext()
        Loop
        rec.Close()

        gf = Nothing
        gi = Nothing
    End Sub

    Private Sub EliminaInesistenti(Db As GestioneDB, Conn As Object)
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"
        Dim daEliminare() As Integer = {}
        Dim Quanti As Integer = 0
        Dim Tot As Long
        Dim sQuantiTot As String
        Dim Quale As Long = 0

        sql = "Select Count(*) From Dati"
        rec = Db.LeggeQuery(Conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            Tot = 0
        Else
            Tot = rec(0).Value
        End If
        rec.Close()
        sQuantiTot = FormattaNumero(Tot, False)

        lblTipoOperazione.Text = "Controllo per immagine inesistente"

        sql = "Select A.id, A.NomeFile, B.Descrizione From Dati A Left Join Cartelle B On A.idCartella=B.idCartella"
        rec = Db.LeggeQuery(Conn, sql)
        Do Until rec.Eof
            Quale += 1
            If Quale / 10 = Int(Quale / 10) Then
                lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot & " - Da eliminare " & FormattaNumero(Quanti, False)
                Application.DoEvents()
            End If

            If BloccaTuttoEdEsci = True Then
                Exit Do
            End If

            If File.Exists(rec("Descrizione").Value & "\" & rec("NomeFile").Value) = False Then
                Quanti += 1
                ReDim Preserve daEliminare(Quanti)
                daEliminare(Quanti) = rec("id").Value
            End If

            rec.MoveNext()
        Loop
        rec.Close()

        If Quanti > 0 Then
            lblTipoOperazione.Text = "Eliminazine immagine inesistente"

            sQuantiTot = FormattaNumero(Quanti, False)
            For i As Integer = 1 To Quanti
                lblAvanzamento.Text = "Immagine " & FormattaNumero(i, False) & "/" & sQuantiTot
                Application.DoEvents()

                sql = "Delete * From Dati Where id=" & daEliminare(i)
                Db.EsegueSql(Conn, sql)

                sql = "Delete * From DatiEXIF Where idImmagine=" & daEliminare(i)
                Db.EsegueSql(Conn, sql)

                sql = "Delete * From CRC Where idImmagine=" & daEliminare(i)
                Db.EsegueSql(Conn, sql)
            Next
        End If
    End Sub

    Private Sub EffettuaControlli(Db As GestioneDB, Conn As Object)
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"
        Dim nonUguali As Integer
        Dim QuantiUguali As Long = 0
        Dim idPrimo As String
        Dim idSecondo As String
        Dim Quale As Long
        Dim QuantiTot As Long = 0
        Dim sQuantiTot As String

        sql = "Select Count(*) From Dati"
        rec = Db.LeggeQuery(Conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            QuantiTot = 0
        Else
            QuantiTot = rec(0).Value
        End If
        rec.Close()
        sQuantiTot = FormattaNumero(QuantiTot, False)

        sql = "Select Count(*) From Uguali Where Ricordato='N'"
        rec = Db.LeggeQuery(Conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            QuantiUguali = 0
        Else
            QuantiUguali = rec(0).Value
        End If
        rec.Close()

        ' Controllo per CRC
        If chkPerCRC.Checked = True Then
            Dim primo As String
            Dim secondo As String

            lblTipoOperazione.Text = "Controllo per CRC"
            Application.DoEvents()

            sql = "Select * From [CRC] Order By [CRC]"
            rec = Db.LeggeQuery(Conn, sql)
            If rec.Eof = False Then
                primo = rec("CRC").Value
                idPrimo = rec("idImmagine").Value

                rec.MoveNext()
            End If
            Quale = 0
            Do Until rec.Eof
                Quale += 1
                If Quale / 10 = Int(Quale / 10) Then
                    lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(QuantiUguali, False)
                    Application.DoEvents()
                End If

                If BloccaTuttoEdEsci = True Then
                    Exit Do
                End If

                secondo = rec("CRC").Value
                idSecondo = rec("idImmagine").Value

                nonUguali = 0
                For i As Integer = 1 To secondo.Length
                    If Mid(primo, i, 1) <> Mid(secondo, i, 1) Then
                        nonUguali += 1
                        If nonUguali > ValoreControlloMinimo Then
                            Exit For
                        End If
                    End If
                Next

                If nonUguali < ValoreControlloMinimo Then
                    QuantiUguali += InserisceInTabellaUguali(Db, Conn, idPrimo, idSecondo, nonUguali, "PerCRC")
                End If

                primo = secondo
                idPrimo = idSecondo

                rec.MoveNext()
            Loop
            rec.Close()
        End If

        ' Controllo per dimensioni / data uguali
        If chkPerDime.Checked = True And BloccaTuttoEdEsci = False Then
            'Dim Dimensione1 As Long
            'Dim DimeX1 As Integer
            'Dim DimeY1 As Integer
            'Dim Dimensione2 As Long
            'Dim DimeX2 As Integer
            'Dim DimeY2 As Integer

            lblTipoOperazione.Text = "Controllo per Dimensioni/Data"

            sql = "SELECT DISTINCT Cartelle.Descrizione+'\'+Dati.NomeFile AS File1, Cartelle_1.Descrizione+'\'+Dati_1.NomeFile AS File2, Dati.Dimensione, Dati.DataOra, Dati.DimeX, Dati.DimeY, Dati.id As id1, Dati_1.id As id2 " &
                "FROM ((Dati INNER JOIN Dati AS Dati_1 ON (Dati.Dimensione = Dati_1.Dimensione) AND (Dati.DimeX = Dati_1.DimeX) AND (Dati.DimeY = Dati_1.DimeY) AND (Dati.DataOra = Dati_1.DataOra)) INNER JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella) INNER JOIN Cartelle AS Cartelle_1 ON Dati_1.idCartella = Cartelle_1.idCartella " &
                "WHERE (((Dati.idCartella)<>[Dati_1].[idCartella])) And (Dati.Valida='S' Or Dati.Valida='') And ([Dati_1].Valida='S' Or [Dati_1].Valida='')"
            rec = Db.LeggeQuery(Conn, sql)
            Quale = 0
            Do Until rec.Eof
                Quale += 1
                If Quale / 10 = Int(Quale / 10) Then
                    lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(QuantiUguali, False)
                    Application.DoEvents()
                End If

                If BloccaTuttoEdEsci = True Then
                    Exit Do
                End If

                idPrimo = rec("id1").Value
                idSecondo = rec("id2").Value

                QuantiUguali += InserisceInTabellaUguali(Db, Conn, idPrimo, idSecondo, nonUguali, "PerDime")

                rec.MoveNext()
            Loop
            rec.Close()
        End If

        ' Controllo per dimensioni
        'If chkPerDime.Checked = True And BloccaTuttoEdEsci = False Then
        '    Dim Dimensione1 As Long
        '    Dim DimeX1 As Integer
        '    Dim DimeY1 As Integer
        '    Dim Dimensione2 As Long
        '    Dim DimeX2 As Integer
        '    Dim DimeY2 As Integer

        '    lblTipoOperazione.Text = "Controllo per Dimensioni"

        '    sql = "Select * From Dati Order By Dimensione, DimeX, DimeY"
        '    rec = Db.LeggeQuery(Conn, sql)
        '    If rec.Eof = False Then
        '        Dimensione1 = rec("Dimensione").Value
        '        DimeX1 = rec("DimeX").Value
        '        DimeY1 = rec("DimeY").Value
        '        idPrimo = rec("id").Value

        '        rec.MoveNext()
        '    End If
        '    Quale = 0
        '    Do Until rec.Eof
        '        Quale += 1
        '        If Quale / 10 = Int(Quale / 10) Then
        '            lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(QuantiUguali, False)
        '            Application.DoEvents()
        '        End If

        '        If BloccaTuttoEdEsci = True Then
        '            Exit Do
        '        End If

        '        Dimensione2 = rec("Dimensione").Value
        '        DimeX2 = rec("DimeX").Value
        '        DimeY2 = rec("DimeY").Value
        '        idSecondo = rec("id").Value

        '        If Dimensione1 = Dimensione2 And DimeX1 = DimeX2 And DimeY1 = DimeY2 Then
        '            QuantiUguali += InserisceInTabellaUguali(Db, Conn, idPrimo, idSecondo, nonUguali, "PerDime")
        '        End If

        '        Dimensione1 = Dimensione2
        '        DimeX1 = DimeX2
        '        DimeY1 = DimeY2
        '        idPrimo = idSecondo

        '        rec.MoveNext()
        '    Loop
        '    rec.Close()
        'End If

        '' Controllo per data
        'If chkPerDime.Checked = True And BloccaTuttoEdEsci = False Then
        '    Dim DataOra1 As String
        '    Dim DataOra2 As String
        '    Dim Dimensione1 As Long
        '    Dim Dimensione2 As Long

        '    lblTipoOperazione.Text = "Controllo per Data"
        '    Application.DoEvents()

        '    sql = "Select * From Dati Order By DataOra"
        '    rec = Db.LeggeQuery(Conn, sql)
        '    If rec.Eof = False Then
        '        DataOra1 = rec("DataOra").Value
        '        Dimensione1 = rec("Dimensione").Value
        '        idPrimo = rec("id").Value

        '        rec.MoveNext()
        '    End If
        '    Quale = 0
        '    Do Until rec.Eof
        '        Quale += 1
        '        If Quale / 10 = Int(Quale / 10) Then
        '            lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(QuantiUguali, False)
        '            Application.DoEvents()
        '        End If

        '        If BloccaTuttoEdEsci = True Then
        '            Exit Do
        '        End If

        '        DataOra2 = rec("DataOra").Value
        '        Dimensione2 = rec("Dimensione").Value
        '        idSecondo = rec("id").Value

        '        If DataOra1 = DataOra2 And Dimensione1 = Dimensione2 Then
        '            QuantiUguali += InserisceInTabellaUguali(Db, Conn, idPrimo, idSecondo, nonUguali, "PerData")
        '        End If

        '        DataOra1 = DataOra2
        '        Dimensione1 = Dimensione2
        '        idPrimo = idSecondo

        '        rec.MoveNext()
        '    Loop
        '    rec.Close()
        'End If

        ' Controllo per lunghezza 0
        If chkPerZero.Checked = True And BloccaTuttoEdEsci = False Then
            Dim NomeFile As String
            Dim Ok As Boolean

            lblTipoOperazione.Text = "Controllo per lunghezza 0"
            Application.DoEvents()

            sql = "Select A.*, B.Descrizione As Cartella From Dati A " &
                 "Left Join Cartelle B On A.idCartella=B.idCartella " &
                 "Where Dimensione=0 And (Valida='S' Or Valida='')"
            rec = Db.LeggeQuery(Conn, sql)
            Do Until rec.Eof
                If BloccaTuttoEdEsci = True Then
                    Exit Do
                End If

                Ok = True
                Try
                    NomeFile = rec("Cartella").Value & "\" & rec("NomeFile").Value
                    Kill(NomeFile)
                Catch ex As Exception
                    'Ok = False
                End Try

                If Ok = True Then
                    sql = "Delete From CRC Where idImmagine=" & rec("id").Value
                    Db.EsegueSql(Conn, sql)

                    sql = "Delete From DatiEXIF Where idImmagine=" & rec("id").Value
                    Db.EsegueSql(Conn, sql)

                    Conn.BeginTrans()
                    rec.Delete()
                    Conn.CommitTrans()
                End If

                rec.MoveNext()
            Loop
            rec.Close()
        End If

        ' Controllo per piccole
        If chkPerPiccole.Checked = True And BloccaTuttoEdEsci = False Then
            Dim NomeFile As String
            Dim Cartella As String
            Dim gf As New GestioneFilesDirectory
            Dim rec3 As Object = CreateObject("ADODB.Recordset")
            Dim idCartellaNuova As Integer
            Dim Dime As Long = -1
            Dim dx As Integer = -1
            Dim dy As Integer = -1
            Dim Ok As Boolean = False
            Dim Quante As Long = 0

            Try
                MkDir(lblDirectory.Text & "\" & NomeCategorie & "\PICCOLE")
            Catch ex As Exception

            End Try

            lblTipoOperazione.Text = "Controllo per Piccole"
            Application.DoEvents()

            Dim totale As Long = 0

            ' Dimensione<" & DimensioneMinimaBytes & " " & _
            sql = "Select A.*, B.Descrizione As Cartella From Dati A " &
                "Left Join Cartelle B On A.idCartella=B.idCartella " &
                "Where " &
                "B.Descrizione Not Like '%\PICCOLE%' And (A.Dimensione<" & DimensioneMinimaBytes & " Or (" &
                "DimeX<" & DimensioneMinimaX & " And DimeY<" & DimensioneMinimaX & ") " &
                ")  And (Valida='S' Or Valida='')"
            rec = Db.LeggeQuery(Conn, sql)
            Do Until rec.Eof
                totale += 1

                rec.MoveNext()
            Loop
            If totale > 0 Then
                rec.Movefirst()
            End If
            Do Until rec.Eof
                If BloccaTuttoEdEsci = True Then
                    Exit Do
                End If

                Cartella = rec("Cartella").Value & "\"
                NomeFile = rec("NomeFile").Value
                'Dime = rec("Dimensione").Value

                'Ok = False
                'If Dime < DimensioneMinimaBytes Then
                '    Ok = True
                'Else
                '    dx = rec("DimeX").Value
                '    dy = rec("DimeY").Value
                '    If dx < DimensioneMinimaX And dy < DimensioneMinimaX Then
                '        Ok = True
                '    Else
                '        If dy < DimensioneMinimaX And dx < DimensioneMinimaX Then
                '            Ok = True
                '        End If
                '    End If
                'End If

                'If Ok = True Then
                Quante += 1

                lblAvanzamento.Text = "Piccole eliminate " & FormattaNumero(Quante, False) & "/" & FormattaNumero(totale, False)
                Application.DoEvents()

                gf.CopiaFileFisico(Cartella & "\" & NomeFile, lblDirectory.Text & "\" & NomeCategorie & "\PICCOLE\" & NomeFile, False)
                Try
                    Kill(Cartella & "\" & NomeFile)
                Catch ex As Exception

                End Try

                sql = "Select * From Cartelle Where Descrizione='" & lblDirectory.Text & "\" & NomeCategorie & "\PICCOLE'"
                rec3 = Db.LeggeQuery(Conn, sql)
                If rec3.Eof = False Then
                    idCartellaNuova = rec3("idCartella").Value
                Else
                    idCartellaNuova = -1
                End If
                rec3.Close()

                If idCartellaNuova = -1 Then
                    sql = "Select Max(idCartella) From Cartelle"
                    rec3 = Db.LeggeQuery(Conn, sql)
                    If rec3(0).value Is DBNull.Value = True Then
                        idCartellaNuova = 1
                    Else
                        idCartellaNuova = rec3(0).Value + 1
                    End If
                    rec3.Close()

                    sql = "Insert Into Cartelle Values (" & idCartellaNuova & ", '" & SistemaTestoPerDB(lblDirectory.Text & "\" & NomeCategorie & "\PICCOLE") & "')"
                    Db.EsegueSql(Conn, sql)
                End If

                sql = "Update Dati Set idCartella=" & idCartellaNuova & " Where id=" & rec("id").Value
                Db.EsegueSql(Conn, sql)
                'End If

                rec.MoveNext()
            Loop
            rec.Close()

            gf = Nothing
        End If

        ' Controllo per non valide
        If chkPerNonValide.Checked = True And BloccaTuttoEdEsci = False Then
            Dim NomeFile As String
            Dim Cartella As String
            Dim bt As Bitmap
            Dim Ok As Boolean
            Dim gf As New GestioneFilesDirectory

            Try
                MkDir("NonValide")
            Catch ex As Exception

            End Try

            lblTipoOperazione.Text = "Controllo per non valide"
            Application.DoEvents()

            sql = "Select A.*, B.Descrizione As Cartella From Dati A " &
                 "Left Join Cartelle B On A.idCartella=B.idCartella " &
                 "Where Valida Is Null Or Valida = ''"
            rec = Db.LeggeQuery(Conn, sql)
            Quale = 0
            Do Until rec.Eof
                Quale += 1
                If Quale / 10 = Int(Quale / 10) Then
                    lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot
                    Application.DoEvents()
                End If

                If BloccaTuttoEdEsci = True Then
                    Exit Do
                End If

                Cartella = rec("Cartella").Value & "\"
                NomeFile = rec("NomeFile").Value

                Ok = True
                Try
                    bt = Image.FromFile(Cartella & "\" & NomeFile)

                    bt.Dispose()
                    bt = Nothing
                Catch ex As Exception
                    Ok = False
                End Try

                If Ok = False Then
                    gf.CopiaFileFisico(Cartella & "\" & NomeFile, "NonValide\" & NomeFile, False)

                    Try
                        Kill(Cartella & "\" & NomeFile)
                    Catch ex As Exception

                    End Try

                    sql = "Delete From CRC Where idImmagine=" & rec("id").Value
                    Db.EsegueSql(Conn, sql)

                    sql = "Delete From DatiEXIF Where idImmagine=" & rec("id").Value
                    Db.EsegueSql(Conn, sql)

                    sql = "Delete From Dati Where id=" & rec("id").Value
                    Db.EsegueSql(Conn, sql)
                End If

                rec.MoveNext()
            Loop
            rec.Close()

            gf = Nothing
        End If

        ' Controllo per exif
        If chkPerExif.Checked = True And BloccaTuttoEdEsci = False Then
            Dim gf As New GestioneFilesDirectory
            Dim descDatoEXIF1 As String = ""
            Dim descDatoEXIF2 As String = ""
            Dim DatoEXIF1 As String = ""
            Dim DatoEXIF2 As String = ""
            Dim rec2 As Object = CreateObject("ADODB.RecordSet")
            Dim Quanti As Long

            lblTipoOperazione.Text = "Controllo per EXIF"
            Application.DoEvents()

            Dim idd As New ArrayList

            sql = "Select id From PrendeEXIF Where Len(DescrizioneTesto)>10 And Len(DescrizioneTesto)<50 Group By id"
            rec = Db.LeggeQuery(Conn, sql)
            If rec(0).Value Is DBNull.Value = True Then
                Quanti = 0
            Else
                Quanti = 0
                Do Until rec.eof
                    Quanti += 1
                    idd.Add(rec("id").Value)

                    rec.movenext
                Loop
            End If
            rec.Close()
            sQuantiTot = FormattaNumero(Quanti, False)

            For i As Integer = 1 To idd.Count - 1
                If i / 10 = Int(i / 10) Then
                    lblAvanzamento.Text = "Immagine " & FormattaNumero(i, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(QuantiUguali, False)
                    Application.DoEvents()
                End If

                If BloccaTuttoEdEsci = True Then
                    Exit For
                End If

                idPrimo = idd.Item(i)
                sql = "Select * from PrendeEXIF Where id=" & idd.Item(i)
                rec = Db.LeggeQuery(Conn, sql)
                Dim Ok As Boolean = True
                Dim r As String = ""
                Do Until rec.eof
                    r &= rec("DescrizioneTesto").value.replAce(";", ",") & ";"
                    rec.movenext
                Loop
                rec.close

                Dim q As String = ""
                Dim t As Integer = 0
                Dim c() As String = r.Split(";")

                For Each cc As String In c
                    If cc <> "" Then
                        q &= "DescrizioneTesto = '" & cc & "' Or "
                        t += 1
                    End If
                Next
                q = Mid(q, 1, q.Length - 4)

                Ok = True
                sql = "Select * from PrendeEXIF where (" & q & ") And id<>" & idd.Item(i)
                rec = Db.LeggeQuery(Conn, sql)
                If not rec Is Nothing Then
                    Dim primo As String
                    If Not rec.eof Then
                        primo = rec("id").value

                        Dim t2 As Integer = 0

                        Do Until rec.eof
                            t2 += 1
                            If primo <> rec("id").value Then
                                Ok = False
                                Exit Do
                            End If

                            rec.movenext
                        Loop

                        If Ok Then
                            QuantiUguali += InserisceInTabellaUguali(Db, Conn, idd.Item(i), primo, nonUguali, "PerEXIF")
                        End If
                    End If
                    rec.close
                End If
            Next

            'sql = "Select Count(*) From PrendeEXIF"
            'rec = Db.LeggeQuery(Conn, sql)
            'If rec(0).Value Is DBNull.Value = True Then
            '    Quanti = 0
            'Else
            '    Quanti = rec(0).Value
            'End If
            'rec.Close()
            'sQuantiTot = FormattaNumero(Quanti, False)

            'sql = "Select * From PrendeEXIF"
            'rec = Db.LeggeQuery(Conn, sql)
            'If rec.Eof = False Then
            '    idPrimo = rec("id").Value
            '    descDatoEXIF1 = rec("Descrizione").Value
            '    DatoEXIF1 = rec("DescrizioneTesto").Value

            '    rec.MoveNext()
            'End If
            'Quale = 0
            'Do Until rec.Eof
            '    Quale += 1
            '    If Quale / 10 = Int(Quale / 10) Then
            '        lblAvanzamento.Text = "Immagine " & FormattaNumero(Quale, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(QuantiUguali, False)
            '        Application.DoEvents()
            '    End If

            '    If BloccaTuttoEdEsci = True Then
            '        Exit Do
            '    End If

            '    idSecondo = rec("id").Value
            '    descDatoEXIF2 = rec("Descrizione").Value
            '    DatoEXIF2 = rec("DescrizioneTesto").Value

            '    If descDatoEXIF1 = descDatoEXIF2 And DatoEXIF1.Trim.ToUpper = DatoEXIF2.Trim.ToUpper Then
            '        Dim Dimensione1 As Integer = -1
            '        Dim Dimensione2 As Integer = -1

            '        sql = "Select * From Dati Where id=" & idPrimo
            '        rec2 = Db.LeggeQuery(Conn, sql)
            '        If rec2.Eof = False Then
            '            Dimensione1 = rec2("Dimensione").Value
            '        End If
            '        rec2.Close()

            '        sql = "Select * From Dati Where id=" & idSecondo
            '        rec2 = Db.LeggeQuery(Conn, sql)
            '        If rec2.Eof = False Then
            '            Dimensione2 = rec2("Dimensione").Value
            '        End If
            '        rec2.Close()

            '        If Dimensione1 = Dimensione2 And Dimensione1 <> -1 Then
            '            QuantiUguali += InserisceInTabellaUguali(Db, Conn, idPrimo, idSecondo, nonUguali, "PerEXIF")
            '        End If
            '    End If

            '    idPrimo = idSecondo
            '    descDatoEXIF1 = descDatoEXIF2
            '    DatoEXIF1 = DatoEXIF2

            '    rec.MoveNext()
            'Loop
            'rec.Close()

            gf = Nothing
        End If

    End Sub

    Private Function InserisceInTabellaUguali(Db As GestioneDB, Conn As Object, idPrimo As Long, idSecondo As Long, nonUguali As Long, Modalita As String) As Integer
        Dim rec2 As Object = "ADODB.Recordset"
        Dim Sql As String
        Dim Ok As Boolean

        Sql = "Select * From Uguali Where (idPrimo=" & idPrimo & " And idSecondo=" & idSecondo & ") Or (idPrimo=" & idSecondo & " And idSecondo=" & idPrimo & ")"
        rec2 = Db.LeggeQuery(Conn, Sql)
        If rec2.Eof = True Then
            Ok = True
        Else
            Ok = False
        End If
        rec2.Close()

        If Ok = True Then
            Sql = "Insert Into Uguali (idPrimo, idSecondo, Differenza, Ricordato, Modalita) Values (" & idPrimo & ", " & idSecondo & ", " & nonUguali & ", 'N', '" & Modalita & "')"
            Db.EsegueSql(Conn, Sql)
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub chkExif_Click(sender As Object, e As EventArgs) Handles chkExif.Click
        Dim Cosa As String

        If chkExif.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "CaricaEXIF", Cosa)
    End Sub

    Private Sub chkCreaCRC_Click(sender As Object, e As EventArgs) Handles chkCreaCRC.Click
        Dim Cosa As String

        If chkCreaCRC.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "CreaCRC", Cosa)
    End Sub

    Private Sub chkCartelleVuote_Click(sender As Object, e As EventArgs) Handles chkCartelleVuote.Click
        Dim Cosa As String

        If chkCartelleVuote.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "CartelleVuote", Cosa)
    End Sub

    Private Sub chkControlla_Click(sender As Object, e As EventArgs) Handles chkControlla.Click
        Dim Cosa As String

        If chkControlla.Checked = True Then
            Cosa = "True"

            chkPerCRC.Visible = True
            chkPerData.Visible = True
            chkPerDime.Visible = True
            chkPerExif.Visible = True
            chkPerZero.Visible = True
            chkPerPiccole.Visible = True
            chkPerNonValide.Visible = True
            chkNomiLunghi.Visible = True
        Else
            Cosa = "False"

            chkPerCRC.Visible = False
            chkPerData.Visible = False
            chkPerDime.Visible = False
            chkPerExif.Visible = False
            chkPerZero.Visible = False
            chkPerPiccole.Visible = False
            chkPerNonValide.Visible = False
            chkNomiLunghi.Visible = False
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "Controlla", Cosa)
    End Sub

    Private Sub chkLeggeImmagini_Click(sender As Object, e As EventArgs) Handles chkLeggeImmagini.Click
        Dim Cosa As String

        If chkLeggeImmagini.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "Legge", Cosa)
    End Sub

    Private Sub chkSistemaNomi_Click(sender As Object, e As EventArgs) Handles chkSistemaNomi.Click
        Dim Cosa As String

        If chkSistemaNomi.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "SistemaNomi", Cosa)
    End Sub

    Private Sub chkEliminaInes_Click(sender As Object, e As EventArgs) Handles chkEliminaInes.Click
        Dim Cosa As String

        If chkEliminaInes.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "EliminaInesistenti", Cosa)
    End Sub

    Private Sub cmdUguali_Click(sender As Object, e As EventArgs) Handles cmdUguali.Click
        frmUguali.Show()
        Me.Hide()
    End Sub

    Private Sub cmdBlocca_Click_1(sender As Object, e As EventArgs) Handles cmdBlocca.Click
        BloccaTuttoEdEsci = True
    End Sub

    Private Sub chkPerDime_Click(sender As Object, e As EventArgs) Handles chkPerDime.Click
        Dim Cosa As String

        If chkPerDime.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerDime", Cosa)
    End Sub

    Private Sub chkPerData_Click(sender As Object, e As EventArgs) Handles chkPerData.Click
        Dim Cosa As String

        If chkPerData.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerData", Cosa)
    End Sub

    Private Sub chkPerCRC_Click(sender As Object, e As EventArgs) Handles chkPerCRC.Click
        Dim Cosa As String

        If chkPerCRC.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerCRC", Cosa)
    End Sub

    Private Sub chkPerEXIF_Click(sender As Object, e As EventArgs) Handles chkPerExif.Click
        Dim Cosa As String

        If chkPerDime.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerEXIF", Cosa)
    End Sub

    Private Sub chkPerZERO_Click(sender As Object, e As EventArgs) Handles chkPerZero.Click
        Dim Cosa As String

        If chkPerZero.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerZero", Cosa)
    End Sub

    Private Sub chkPerPiccole_Click(sender As Object, e As EventArgs) Handles chkPerPiccole.Click
        Dim Cosa As String

        If chkPerPiccole.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerPiccole", Cosa)
    End Sub

    Private Sub chkPerNonValide_Click(sender As Object, e As EventArgs) Handles chkPerNonValide.Click
        Dim Cosa As String

        If chkPerNonValide.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PerNonValide", Cosa)
    End Sub

    Private Sub chkRidimensiona_Click(sender As Object, e As EventArgs) Handles chkRidimensiona.Click
        Dim Cosa As String

        If chkRidimensiona.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "Ridimensiona", Cosa)
    End Sub

    Private Sub chkCompatta_Click(sender As Object, e As EventArgs) Handles chkCompatta.Click
        Dim Cosa As String

        If chkCompatta.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "Compatta", Cosa)
    End Sub

    Private Sub chkPulisceCategorie_Click(sender As Object, e As EventArgs) Handles chkPulisceCategorie.Click
        Dim Cosa As String

        If chkPulisceCategorie.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PulisceCategorie", Cosa)
    End Sub

    Private Sub chkAccorpa_Click(sender As Object, e As EventArgs) Handles chkAccorpa.Click
        Dim Cosa As String

        If chkAccorpa.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "Accorpa", Cosa)
    End Sub

    Private Sub chkPulisceUguali_Click(sender As Object, e As EventArgs) Handles chkPulisceUguali.Click
        Dim Cosa As String

        If chkPulisceUguali.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PulisceUguali", Cosa)
    End Sub

    Private Sub chkPulisceCRC_Click(sender As Object, e As EventArgs) Handles chkPulisceCRC.Click
        Dim Cosa As String

        If chkPulisceCRC.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PulisceCRC", Cosa)
    End Sub

    Private Sub chkPulisceDati_Click(sender As Object, e As EventArgs) Handles chkPulisceDati.Click
        Dim Cosa As String

        If chkPulisceDati.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PulisceDati", Cosa)
    End Sub

    Private Sub AccorpaImmaginiFase1(Db As GestioneDB, Conn As Object)
        Dim sql As String
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim rec2 As Object = CreateObject("ADODB.Recordset")
        Dim rec3 As Object = CreateObject("ADODB.Recordset")
        Dim gf As New GestioneFilesDirectory
        Dim qVari As Long = 0
        Dim QualeImm As Long = 0
        Dim Cartella As String
        Dim sCartella As String
        Dim Tipologia As String
        Dim idCartellaNuova As Long
        Dim Ritorno As String
        Dim vCartella As String

        ' Aggiorna le categorie già presenti
        lblTipoOperazione.Text = "Accorpamento - Aggiornamento"
        Application.DoEvents()

        gf.ScansionaDirectorySingola(lblDirectory.Text & "\" & NomeCategorie & "")
        Dim Direct() As String = gf.RitornaDirectoryRilevate
        Dim qD As Integer = gf.RitornaQuanteDirectoryRilevate
        If qD > 0 Then
            For i As Integer = 1 To qD
                Cartella = Direct(i).Replace(lblDirectory.Text & "\" & NomeCategorie & "", "")

                If Cartella <> "" Then
                    If Mid(Cartella, 1, 1) = "\" Then
                        Cartella = Mid(Cartella, 2, Cartella.Length)
                    End If
                    vCartella = Cartella & "*"
                    If vCartella.IndexOf("\V*") = -1 And vCartella.IndexOf("\N*") = -1 Then
                        vCartella = ""
                        For k As Integer = Len(Cartella) To 1 Step -1
                            If Mid(Cartella, k, 1) = "\" Then
                                vCartella = Mid(Cartella, k + 1, Cartella.Length)
                                Exit For
                            End If
                        Next
                        If vCartella = "" Then
                            vCartella = Cartella
                        End If
                        If vCartella.Length < 5 Then vCartella = " " & vCartella

                        Dim Ricerca As String = ""
                        Dim RicercaNot As String = ""
                        Dim Aliasini() As String = vCartella.Split(";")

                        For z As Integer = 0 To Aliasini.Length - 1
                            If Aliasini(z).Trim <> "" Then
                                If IsNumeric(Aliasini(z)) = False Then
                                    If Mid(Aliasini(z), 1, 1) = "!" Then
                                        RicercaNot += "(Dati.NomeFile) Not Like '%" & (Mid(Aliasini(z), 2, Aliasini(z).Length)).Trim & "%' And "
                                    Else
                                        Ricerca += "(Dati.NomeFile) Like '%" & Aliasini(z).Trim & "%' Or "
                                    End If
                                End If
                            End If
                        Next
                        If Ricerca <> "" Then
                            Ricerca = "(" & Mid(Ricerca, 1, Ricerca.Length - 4) & ")"
                            If RicercaNot <> "" Then
                                RicercaNot = "(" & Mid(RicercaNot, 1, RicercaNot.Length - 5) & ")"

                                Ricerca = Ricerca & " And " & RicercaNot
                            End If

                            lblAvanzamento.Text = "Categoria " & i & "/" & qD & ": " & vCartella
                            Application.DoEvents()

                            Dim quanti As Long = 0
                            Dim totali As Long = 0

                            sql = "SELECT Cartelle.Descrizione, Dati.NomeFile, Dati.idCartella " & _
                                "FROM Dati INNER JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella " & _
                                "WHERE (" & Ricerca & ") And " & _
                                "Descrizione Not Like '%\" & NomeCategorie & "%' And " & _
                                "Descrizione Not Like '%\picDrop%' And " & _
                                "Descrizione Not Like '%\SiteRips%'"
                            rec2 = Db.LeggeQuery(Conn, sql)
                            Do Until rec2.Eof
                                totali += 1

                                rec2.MoveNext()
                            Loop
                            If totali > 0 Then
                                rec2.MoveFirst()
                            End If
                            Do Until rec2.Eof
                                quanti += 1
                                lblAvanzamento.Text = "Categoria " & i & "/" & qD & ": " & vCartella & " -> " & quanti & "/" & totali & " (" & rec2("NomeFile").Value & ")"
                                Application.DoEvents()

                                If File.Exists(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value) = True Then
                                    Tipologia = rec2("Descrizione").Value.ToString.ToUpper & "\"
                                    Tipologia = IIf(Tipologia.IndexOf("\N\") > -1, "N\", "V\")
                                    sCartella = lblDirectory.Text & "\" & NomeCategorie & "\" & Cartella & "\" & Tipologia
                                    gf.CreaDirectoryDaPercorso(sCartella)
                                    Ritorno = gf.CopiaFileFisico(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value, sCartella & rec2("NomeFile").Value, False)
                                    If File.Exists(sCartella & Ritorno) = True Then
                                        gf.EliminaFileFisico(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value)

                                        sql = "Select * From Cartelle Where Descrizione='" & Mid(sCartella, 1, sCartella.Length - 1) & "'"
                                        rec3 = Db.LeggeQuery(Conn, sql)
                                        If rec3.Eof = False Then
                                            idCartellaNuova = rec3("idCartella").Value
                                        Else
                                            idCartellaNuova = -1
                                        End If
                                        rec3.Close()

                                        If idCartellaNuova = -1 Then
                                            sql = "Select Max(idCartella) From Cartelle"
                                            rec3 = Db.LeggeQuery(Conn, sql)
                                            If rec3(0).value Is DBNull.Value = True Then
                                                idCartellaNuova = 1
                                            Else
                                                idCartellaNuova = rec3(0).Value + 1
                                            End If
                                            rec3.Close()

                                            sql = "Insert Into Cartelle Values (" & idCartellaNuova & ", '" & SistemaTestoPerDB(Mid(Cartella, 1, Cartella.Length - 1)) & "')"
                                            Db.EsegueSql(Conn, sql)
                                        End If

                                        Try
                                            Conn.BeginTrans()
                                            rec2("idCartella").Value = idCartellaNuova
                                            rec2("NomeFile").Value = Ritorno
                                            rec2.Update()
                                            Conn.CommitTrans()
                                        Catch ex As Exception

                                        End Try
                                    End If
                                End If

                                If BloccaTuttoEdEsci = True Then
                                    Exit Do
                                End If

                                rec2.MoveNext()
                            Loop
                            rec2.Close()
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub AccorpaImmaginiFase2(Db As GestioneDB, Conn As Object)
        Dim sql As String
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim rec2 As Object = CreateObject("ADODB.Recordset")
        Dim rec3 As Object = CreateObject("ADODB.Recordset")
        Dim Nome As String
        Dim Est As String
        Dim gf As New GestioneFilesDirectory
        Dim qVari As Long = 0
        Dim TotaleImm As Long
        Dim QualeImm As Long = 0
        Dim Appoggio As String
        Dim Car As Integer
        Dim sQuantiTot As String
        Dim Cartella As String
        Dim idCartellaNuova As Integer
        Dim Taggone As String
        Dim Ritorno As String

        lblTipoOperazione.Text = "Accorpamento - picDROP"
        Application.DoEvents()
        Dim codPicDrop As Integer = -1
        sql = "SELECT DescrizioniTestoEXIF.idDescrizioneTesto " &
            "FROM((DescrizioniTestoEXIF INNER JOIN DatiEXIF ON " &
            "DescrizioniTestoEXIF.idDescrizioneTesto = DatiEXIF.idDescrizioneTesto) " &
            "INNER JOIN Dati On DatiEXIF.idImmagine = Dati.id) INNER JOIN Cartelle On Dati.idCartella = Cartelle.idCartella " &
            "WHERE(((UCASE(Cartelle.Descrizione)) Not Like '%PICDROP%') AND ((UCASE(DescrizioniTestoEXIF.DescrizioneTesto)) Like '%PICDROP%'));"
        rec = Db.LeggeQuery(Conn, sql)
        If rec.Eof = False Then
            codPicDrop = rec("idDescrizioneTesto").Value
        End If
        rec.Close()
        If codPicDrop <> -1 Then
            sql = "SELECT Dati.id " &
                "FROM ((Dati INNER JOIN (DatiEXIF INNER JOIN DescrizioniEXIF ON DatiEXIF.idDescrizione = DescrizioniEXIF.idDescrizione) ON Dati.id = DatiEXIF.idImmagine) INNER JOIN DescrizioniTestoEXIF ON DatiEXIF.idDescrizioneTesto = DescrizioniTestoEXIF.idDescrizioneTesto) INNER JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella " &
                "WHERE DescrizioniTestoEXIF.idDescrizioneTesto=" & codPicDrop & " And " &
                "Cartelle.Descrizione Not Like '%\picDrop%' And " &
                "Cartelle.Descrizione Not Like '%\SiteRips%'"
            '"Cartelle.Descrizione Not Like '%\Categorie%' And " &
            rec = Db.LeggeQuery(Conn, sql)
            Do Until rec.Eof
                Application.DoEvents()

                sql = "SELECT Dati.id, Cartelle.Descrizione, Dati.NomeFile, Cartelle.idCartella, DescrizioniEXIF.Descrizione As Tagghetto, DescrizioniTestoEXIF.DescrizioneTesto " &
                    "FROM ((Dati INNER JOIN (DatiEXIF INNER JOIN DescrizioniEXIF ON DatiEXIF.idDescrizione = DescrizioniEXIF.idDescrizione) ON Dati.id = DatiEXIF.idImmagine) INNER JOIN DescrizioniTestoEXIF ON DatiEXIF.idDescrizioneTesto = DescrizioniTestoEXIF.idDescrizioneTesto) INNER JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella " &
                    "WHERE Dati.id=" & rec("id").Value
                rec2 = Db.LeggeQuery(Conn, sql)
                Taggone = ""
                Do Until rec2.Eof
                    If rec2("Tagghetto").Value.ToString.ToUpper.IndexOf("COMMENT") > -1 Or rec2("Tagghetto").Value.ToString.ToUpper.IndexOf("IMAGE DESCRIPTION") > -1 Then
                        Taggone = rec2("DescrizioneTesto").Value
                        If Taggone.Length > 10 Then
                            ' LH3.GOOGLEUSERCONTENT.COM;-0XzfEYB3QHw;VpZErcXNIUI;AAAAAAABcT8;FYG1Rpb9eVA;w426-h638;
                            If File.Exists(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value) = True Then
                                Dim LetteraIniziale As String = Mid(Taggone, 1, 1).ToUpper

                                Taggone = Taggone.Replace(";", "\")
                                Taggone = lblDirectory.Text & "\picDrop\" & LetteraIniziale & "\" & Taggone
                                Taggone += "\"
                                Taggone = Taggone.Replace("?", "")
                                Taggone = Taggone.Replace(">", "_")
                                Taggone = Taggone.Replace("<", "_")
                                Taggone = Taggone.Replace("|", "_")
                                Taggone = Taggone.Replace(",", "_")
                                Taggone = Taggone.Replace("&", "_")
                                Taggone = Taggone.Replace("+", "_")
                                Taggone = Taggone.Replace("%", "")
                                Taggone = Taggone.Replace("+", "_")
                                Do While Taggone.IndexOf("\\") > -1
                                    Taggone = Taggone.Replace("\\", "\")
                                Loop
                                gf.CreaDirectoryDaPercorso(Taggone)

                                Ritorno = gf.CopiaFileFisico(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value, Taggone & rec2("NomeFile").Value, False)
                                If File.Exists(Taggone & Ritorno) = True Then
                                    lblAvanzamento.Text = "Spostamento " & rec2("NomeFile").Value
                                    Application.DoEvents()

                                    gf.EliminaFileFisico(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value)

                                    sql = "Select * From Cartelle Where Descrizione='" & Mid(Taggone, 1, Taggone.Length - 1) & "'"
                                    rec3 = Db.LeggeQuery(Conn, sql)
                                    If rec3.Eof = False Then
                                        idCartellaNuova = rec3("idCartella").Value
                                    Else
                                        idCartellaNuova = -1
                                    End If
                                    rec3.Close()

                                    If idCartellaNuova = -1 Then
                                        sql = "Select Max(idCartella) From Cartelle"
                                        rec3 = Db.LeggeQuery(Conn, sql)
                                        If rec3(0).value Is DBNull.Value = True Then
                                            idCartellaNuova = 1
                                        Else
                                            idCartellaNuova = rec3(0).Value + 1
                                        End If
                                        rec3.Close()

                                        sql = "Insert Into Cartelle Values (" & idCartellaNuova & ", '" & SistemaTestoPerDB(Mid(Taggone, 1, Taggone.Length - 1)) & "')"
                                        Db.EsegueSql(Conn, sql)
                                    End If

                                    'Dim maxID As Long
                                    'sql = "Select Max(id)+1 From Dati"
                                    'rec3 = Db.LeggeQuery(Conn, sql)
                                    'maxID = rec3(0).Value
                                    'rec3.Close()

                                    'Try
                                    '    Conn.BeginTrans()
                                    '    'rec2("id") = maxID
                                    '    rec2("idCartella").Value = idCartellaNuova
                                    '    rec2("NomeFile").Value = Ritorno
                                    '    rec2.Update()
                                    '    Conn.CommitTrans()
                                    'Catch ex As Exception

                                    'End Try
                                End If
                            End If
                        End If
                    End If

                    rec2.MoveNext()
                Loop
                rec2.Close()

                rec.MoveNext()
            Loop
            rec.Close()
        End If

        lblTipoOperazione.Text = "Accorpamento - Lettura"
        Application.DoEvents()

        sql = "Select Count(*) From Dati A Left Join Cartelle B On A.idCartella=B.idCartella Where B.Descrizione Not Like '%\SiteRips\%' And B.Descrizione Not Like '%\" & NomeCategorie & "%' "
        rec = Db.LeggeQuery(Conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            TotaleImm = 0
        Else
            TotaleImm = rec(0).Value
        End If
        rec.Close()
        sQuantiTot = FormattaNumero(TotaleImm, False)

        sql = "Delete From Categorie"
        Db.EsegueSql(Conn, sql)

        sql = "Select A.NomeFile From Dati A Left Join Cartelle B On A.idCartella=B.idCartella Where B.Descrizione Not Like '%\SiteRips\%' And B.Descrizione Not Like '%\" & NomeCategorie & "%' "
        rec = Db.LeggeQuery(Conn, sql)
        Do Until rec.Eof
            QualeImm += 1
            If QualeImm / 100 = Int(QualeImm / 100) Then
                lblAvanzamento.Text = "Immagine " & FormattaNumero(QualeImm, False) & "/" & sQuantiTot & " - Rilevate: " & FormattaNumero(qVari, False)
                Application.DoEvents()
            End If

            Nome = rec("NomeFile").Value
            Est = gf.TornaEstensioneFileDaPath(Nome)

            If Est <> "" Then
                Nome = Nome.Replace(Est, "")
            End If

            Nome = Nome.ToUpper

            Appoggio = ""
            For i As Integer = 1 To Nome.Length
                Car = Asc(Mid(Nome, i, 1))
                If Car >= Asc("A") And Car <= Asc("Z") Then
                    Appoggio += Mid(Nome, i, 1)
                Else
                    Appoggio += " "
                End If
            Next
            Nome = Appoggio
            Nome = Nome.Trim

            If Nome <> "" Then
                Do While Nome.IndexOf(" ") > -1
                    If Mid(Nome, 1, Nome.IndexOf(" ")).Trim.Length > 4 And Nome.Length <= 50 Then
                        qVari += 1

                        'If Mid(Nome, 1, Nome.IndexOf(" ")).Trim.ToUpper.IndexOf("ALLERY") > -1 Then Stop

                        sql = "Insert Into Categorie Values ('" & SistemaTestoPerDB(Mid(Nome, 1, Nome.IndexOf(" ")).Trim.ToUpper) & "')"
                        Db.EsegueSql(Conn, sql)
                    End If

                    Nome = Mid(Nome, Nome.IndexOf(" ") + 1, Nome.Length).Trim
                Loop
                If Nome.Trim <> "" And Nome.Length > 4 And Nome.Length <= 50 Then
                    qVari += 1

                    'If Nome.Trim.ToUpper.IndexOf("ALLERY") > -1 Then Stop

                    sql = "Insert Into Categorie Values ('" & SistemaTestoPerDB(Nome.Trim.ToUpper) & "')"
                    Db.EsegueSql(Conn, sql)
                End If
            End If

            If BloccaTuttoEdEsci = True Then
                Exit Do
            End If

            rec.MoveNext()
        Loop
        rec.Close()

        If BloccaTuttoEdEsci = False Then
            Dim Messa As Boolean
            Dim Tipologia As String
            'Dim Ritorno As String

            lblTipoOperazione.Text = "Accorpamento - Spostamento"
            Application.DoEvents()

            sql = "Select * From PrendeCategorie"
            rec = Db.LeggeQuery(Conn, sql)
            TotaleImm = 0
            Do Until rec.Eof
                TotaleImm += 1

                rec.MoveNext()
            Loop
            sQuantiTot = FormattaNumero(TotaleImm, False)
            If TotaleImm > 0 Then
                rec.Movefirst()
            End If
            QualeImm = 0
            Do Until rec.Eof
                QualeImm += 1
                lblAvanzamento.Text = "Categoria " & FormattaNumero(QualeImm, False) & "/" & sQuantiTot ' & ": " & rec("Categoria").Value
                Application.DoEvents()

                Messa = False
                sql = "SELECT Dati.idCartella, Cartelle.Descrizione, Dati.NomeFile " & _
                    "FROM Dati INNER JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella " & _
                    "WHERE (((Dati.NomeFile) Like '%" & rec("Categoria").Value & "%')) And " & _
                    "Descrizione Not Like '%\" & NomeCategorie & "%' And " & _
                    "Descrizione Not Like '%\picDrop%' And " & _
                    "Descrizione Not Like '%\SiteRips%'"
                rec2 = Db.LeggeQuery(Conn, sql)
                Do Until rec2.Eof
                    Application.DoEvents()

                    If File.Exists(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value) = True Then
                        Messa = True

                        Tipologia = rec2("Descrizione").Value.ToString.ToUpper & "\"
                        Tipologia = IIf(Tipologia.IndexOf("\N\") > -1, "N\", "V\")

                        Cartella = rec2("Descrizione").Value
                        Cartella = lblDirectory.Text & "\" & NomeCategorie & "\" & rec("Categoria").Value & "\" & Tipologia

                        gf.CreaDirectoryDaPercorso(Cartella)

                        Ritorno = gf.CopiaFileFisico(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value, Cartella & rec2("NomeFile").Value, False)
                        If File.Exists(Cartella & Ritorno) = True Then
                            gf.EliminaFileFisico(rec2("Descrizione").Value & "\" & rec2("NomeFile").Value)

                            sql = "Select * From Cartelle Where Descrizione='" & Mid(Cartella, 1, Cartella.Length - 1) & "'"
                            rec3 = Db.LeggeQuery(Conn, sql)
                            If rec3.Eof = False Then
                                idCartellaNuova = rec3("idCartella").Value
                            Else
                                idCartellaNuova = -1
                            End If
                            rec3.Close()

                            If idCartellaNuova = -1 Then
                                sql = "Select Max(idCartella) From Cartelle"
                                rec3 = Db.LeggeQuery(Conn, sql)
                                If rec3(0).value Is DBNull.Value = True Then
                                    idCartellaNuova = 1
                                Else
                                    idCartellaNuova = rec3(0).Value + 1
                                End If
                                rec3.Close

                                sql = "Insert Into Cartelle Values (" & idCartellaNuova & ", '" & SistemaTestoPerDB(Mid(Cartella, 1, Cartella.Length - 1)) & "')"
                                Db.EsegueSql(Conn, sql)
                            End If

                            Try
                                Conn.BeginTrans()
                                rec2("idCartella").Value = idCartellaNuova
                                rec2("NomeFile").Value = Ritorno
                                rec2.Update()
                                Conn.CommitTrans()
                            Catch ex As Exception

                            End Try
                        End If
                    End If

                    If BloccaTuttoEdEsci = True Then
                        Exit Do
                    End If

                    rec2.MoveNext()
                Loop
                rec2.Close()

                If Messa = False Then
                    Try
                        RmDir(lblDirectory.Text & "\" & NomeCategorie & "\" & rec("Categoria").Value)
                    Catch ex As Exception

                    End Try
                End If

                If BloccaTuttoEdEsci = True Then
                    Exit Do
                End If

                rec.MoveNext()
            Loop
            rec.Close()
        End If
    End Sub

    Private Sub cmdCategorizza_Click(sender As Object, e As EventArgs) Handles cmdCategorizza.Click
        frmCategorizza.Show()
        Me.Hide()
    End Sub

    Private Sub cmdImpostaAgg_Click(sender As Object, e As EventArgs) Handles cmdImpostaAgg.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            lblPosiImmagini.Text = FolderBrowserDialog1.SelectedPath
            SaveSetting("Uguaglianze", "Impostazioni", "PercorsoAgg", lblPosiImmagini.Text)
        End If
    End Sub

    Private Sub cmdAggiunge_Click(sender As Object, e As EventArgs) Handles cmdAggiunge.Click
        Dim QuantiFiles As Integer
        Dim Immagini() As String
        Dim tipoCartella() As String = {"AV", "AN"}
        Dim tipoCartella2() As String = {"V", "N"}
        Dim Cartella As String
        Dim NumeroCartella As Integer
        Dim di As IO.DirectoryInfo
        Dim fiar1 As IO.FileInfo()
        Dim QuantiFilesPresenti As Integer
        Dim i As Integer
        Dim gi As New GestioneImmagini
        Dim sDime As String
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"
        Dim rec2 As Object = "ADODB.Recordset"
        Dim Massimo As Long
        Dim idCartella As Integer
        Dim Scrivi As Boolean
        Dim Dime() As String
        Dim Nome As String
        Dim sTot As String

        sql = "Select Max(id) From Dati"
        rec = db.LeggeQuery(conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            Massimo = 0
        Else
            Massimo = rec(0).Value
        End If
        rec.Close()

        pnlEsecuzione.Visible = True
        pnlEsecuzione.Left = pnlComandi.Left ' (Me.Width / 2) - (pnlEsecuzione.Width / 2)
        pnlEsecuzione.Top = pnlComandi.Top ' (Me.Height / 2) - (pnlEsecuzione.Height / 2) - 20
        BloccaTuttoEdEsci = False
        lblTipoOperazione.Text = ""
        lblAvanzamento.Text = ""
        cmdImpostaDir.Enabled = False
        lblPosiImmagini.Enabled = False
        cmdImpostaAgg.Enabled = False
        Application.DoEvents()

        pnlComandi.Visible = False
        lblAvanzamento.Visible = True
        lblAvanzamento.Text = ""
        Application.DoEvents()

        For QualeCartella = 0 To 1
            Dim gf As New GestioneFilesDirectory

            lblTipoOperazione.Text = "Aggiunta cartella  -" & tipoCartella2(QualeCartella) & "-"
            Application.DoEvents()

            gf.ScansionaDirectorySingola(lblPosiImmagini.Text & "\" & tipoCartella(QualeCartella), "", lblAvanzamento) '
            QuantiFiles = gf.RitornaQuantiFilesRilevati
            Immagini = gf.RitornaFilesRilevati

            sTot = FormattaNumero(QuantiFiles, False)

            NumeroCartella = 0
            i = 0
            Do While i < QuantiFiles
                Cartella = lblDirectory.Text & "\Storage\" & Format(NumeroCartella, "0000") & "\" & tipoCartella2(QualeCartella)

                If Not Directory.Exists(Cartella) Then
                    gf.CreaDirectoryDaPercorso(Cartella & "\")
                End If

                di = New IO.DirectoryInfo(Cartella)
                fiar1 = di.GetFiles
                QuantiFilesPresenti = fiar1.Count
                Do While QuantiFilesPresenti <= 1500 And i < QuantiFiles
                    lblAvanzamento.Text = "Aggiunta: " & FormattaNumero(i, False) & "/" & sTot
                    Application.DoEvents()

                    QuantiFilesPresenti += 1
                    i += 1
                    Nome = gf.TornaNomeFileDaPath(Immagini(i))
                    If Nome.ToUpper.Trim = "THUMBS.DB" Then
                        gf.EliminaFileFisico(Immagini(i))
                    Else
                        gf.CopiaFileFisico(Immagini(i), Cartella & "\" & Nome, False)
                        If File.Exists(Cartella & "\" & gf.TornaNomeFileDaPath(Immagini(i))) = True Then
                            gf.EliminaFileFisico(Immagini(i))

                            sql = "Select idCartella From Cartelle Where Descrizione='" & Cartella.Replace("'", "''").Trim & "'"
                            rec = db.LeggeQuery(conn, sql)
                            If rec.Eof = True Then
                                idCartella = -1
                            Else
                                idCartella = rec(0).Value
                            End If
                            rec.Close()

                            sql = "Select * From Dati Where idCartella=" & idCartella & " And NomeFile='" & Nome.Replace("'", "''") & "'"
                            rec = db.LeggeQuery(conn, sql)
                            Scrivi = False
                            If rec.Eof = True Then
                                Massimo += 1

                                sDime = gi.RitornaDimensioneImmagine(Cartella & "\" & Nome)

                                If sDime.IndexOf("ERRORE:") > -1 Then
                                    ReDim Preserve Dime(1)
                                    Dime(0) = 0
                                    Dime(1) = 0
                                Else
                                    Dime = sDime.Split("x")
                                End If

                                Scrivi = True

                                If idCartella = -1 Then
                                    sql = "Select Max(idCartella)+1 From Cartelle"
                                    rec2 = db.LeggeQuery(conn, sql)
                                    If rec2(0).Value Is DBNull.Value = True Then
                                        idCartella = 1
                                    Else
                                        idCartella = rec2(0).Value
                                    End If
                                    rec2.Close()

                                    sql = "Insert Into Cartelle Values (" & idCartella & ", '" & Cartella.Replace("'", "''").Trim & "')"
                                    db.EsegueSql(conn, sql)
                                End If

                                sql = "Insert Into Dati Values (" &
                                    " " & Massimo & ", " &
                                    "'" & idCartella & "', " &
                                    "'" & Nome.Replace("'", "''") & "', " &
                                    "'" & FileDateTime(Cartella & "\" & Nome) & "', " &
                                    " " & gf.TornaDimensioneFile(Cartella & "\" & Nome).ToString.Replace(",", ".") & ", " &
                                    " " & Dime(0) & ", " &
                                    " " & Dime(1) & ", " &
                                    "'N', " &
                                    "'N', " &
                                    "'' " &
                                    ")"
                            End If
                            rec.Close()

                            If Scrivi = True Then
                                db.EsegueSql(conn, sql)

                                gi.CreaValoreUnivocoImmagine(Massimo, db, conn, Cartella & "\" & Nome, gf)
                            End If

                        End If
                    End If
                Loop

                NumeroCartella += 1
            Loop

            gf = Nothing
        Next

        cmdImpostaDir.Enabled = True

        lblPosiImmagini.Enabled = True
        cmdImpostaAgg.Enabled = True
        pnlEsecuzione.Visible = False
        pnlComandi.Visible = True

        conn.Close
        db = Nothing

        ContaImmagini()

        MsgBox("Elaborazione completata")
    End Sub

    Private Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click
        frmShow.Show()
        Me.Hide()
    End Sub

    Private Sub chkPulisci_Click(sender As Object, e As EventArgs) Handles chkPulisci.Click
        If chkPulisci.Checked = True Then
            chkPulisceUguali.Visible = True
            chkPulisceCRC.Visible = True
            chkPulisceDati.Visible = True
            chkPulisceCategorie.Visible = True
        Else
            chkPulisceUguali.Visible = False
            chkPulisceCRC.Visible = False
            chkPulisceDati.Visible = False
            chkPulisceCategorie.Visible = False
        End If
    End Sub

    Private Sub chkNomiLunghi_Click(sender As Object, e As EventArgs) Handles chkNomiLunghi.Click
        Dim Cosa As String

        If chkNomiLunghi.Checked = True Then
            Cosa = "True"
        Else
            Cosa = "False"
        End If

        SaveSetting("Uguaglianze", "Impostazioni", "PathLunghi", Cosa)
    End Sub

    Private Sub chkControlla_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlla.CheckedChanged

    End Sub
End Class
