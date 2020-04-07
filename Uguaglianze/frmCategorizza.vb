Imports System.IO

Public Class frmCategorizza
    Dim DimeBox As Integer = 120
    Dim Quale As Integer = 0
    Dim Selezionate() As Boolean
    Dim totImmagini As Integer
    Dim NomeImm() As String

    Private Sub frmCategorizza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNumImmagini.Text = ""

        CaricaCategorie()
        CaricaDate()

        cmbDate.Text = GetSetting("Uguaglianze", "Impostazioni", "DataCateg", "")
    End Sub

    Private Sub CaricaCategorie()
        Dim gf As New GestioneFilesDirectory
        Dim Cartella As String
        Dim Percorso As String = GetSetting("Uguaglianze", "Impostazioni", "Percorso", Application.StartupPath)

        cmbCategoria.Items.Clear()
        cmbCategoria.Items.Add("")
        gf.ScansionaDirectorySingola(Percorso & "\Categorie")

        Dim Direct() As String = gf.RitornaDirectoryRilevate
        Dim qD As Integer = gf.RitornaQuanteDirectoryRilevate

        If qD > 0 Then
            For i As Integer = 1 To qD
                Cartella = Direct(i).Replace(Percorso & "\Categorie", "")

                If Cartella <> "" Then
                    If Mid(Cartella, 1, 1) = "\" Then
                        Cartella = Mid(Cartella, 2, Cartella.Length)
                    End If
                    If Cartella.IndexOf("\") = -1 Then
                        cmbCategoria.Items.Add(Cartella)
                    End If
                End If
            Next
        End If

        gf = Nothing
    End Sub

    Private Sub CaricaDate()
        Me.Cursor = Cursors.WaitCursor

        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        Dim rec As Object = CreateObject("ADODB.Recordset")
        conn = db.ApreDB()
        Dim sql As String
        Dim Quante As Integer = 0
        Dim Datelle() As String = {}
        Dim qDatelle As Integer = 0
        Dim Ok As Boolean

        sql = "Select * From DateControllate"
        rec = db.LeggeQuery(conn, sql)
        Do Until rec.Eof
            qDatelle += 1
            ReDim Preserve Datelle(qDatelle)

            Datelle(qDatelle) = rec("Datella").Value

            rec.MoveNext
        Loop
        rec.Close

        sql = "SELECT Format(A.DataOra,'dd/mm/yyyy') AS DataOra, Count(*) AS Quanti " &
            "FROM Dati AS A LEFT JOIN Cartelle AS B ON A.idCartella=B.idCartella " &
            "WHERE Ucase(B.Descrizione) Not Like '%\CATEGORIE%' And Ucase(B.Descrizione) Not Like '%\SITERIPS%' " &
            "GROUP BY Format(A.DataOra,'dd/mm/yyyy') " &
            "ORDER BY 2 DESC;"
        cmbDate.Items.Clear()
        cmbDate.Items.Add("")
        rec = db.LeggeQuery(conn, sql)
        Do Until rec.Eof
            Ok = True
            For i As Integer = 1 To qDatelle
                If Datelle(i) = rec("DataOra").Value Then
                    Ok = False
                    Exit For
                End If
            Next
            If Ok = True Then
                cmbDate.Items.Add(rec("DataOra").Value & ": " & rec("Quanti").Value)
            End If

            rec.MoveNext()
        Loop
        rec.Close()

        conn.Close()
        db = Nothing

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LeggeImmaginiDaDB()
        Me.Cursor = Cursors.WaitCursor

        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        Dim rec As Object = CreateObject("ADODB.Recordset")
        conn = db.ApreDB()
        Dim sql As String
        Dim Quante As Integer = 0

        PictureBox1.Image = Nothing

        Quante = 0
        Quale = 0
        cmbCategoria.Text = ""

        If cmbDate.Text <> "" Then
            Dim Datella As Date = Mid(cmbDate.Text, 1, cmbDate.Text.IndexOf(":"))
            Dim sDatella As String = Datella.Year & Format(Datella.Month, "00") & Format(Datella.Day, "00")

            sql = "SELECT Cartelle.Descrizione & '\' & Dati.NomeFile AS Nome, Dati.DataOra " & _
                "FROM Dati LEFT JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella " & _
                "WHERE (((Format([DataOra],'yyyymmdd')) Between '" & sDatella & "' And '" & sDatella & "') " & _
                "AND ((UCase([Cartelle].[Descrizione])) Not Like '%\CATEGORIE%' And (UCase([Cartelle].[Descrizione])) Not Like '%\SITERIPS%')) " & _
                "ORDER BY Dati.DataOra;"
        Else
            sql = "SELECT Cartelle.Descrizione & '\' & Dati.NomeFile AS Nome, Dati.DataOra " & _
                "FROM Dati LEFT JOIN Cartelle ON Dati.idCartella = Cartelle.idCartella " & _
                "WHERE NomeFile Like '%" & txtRicerca.Text & "%' " & _
                "AND UCase([Cartelle].[Descrizione]) Not Like '%\CATEGORIE%' And UCase([Cartelle].[Descrizione]) Not Like '%\SITERIPS%' " & _
                "ORDER BY Dati.DataOra;"
        End If
        rec = db.LeggeQuery(conn, sql)
        Do Until rec.Eof
            Quante += 1
            AggiungePictureBox(rec("Nome").Value)

            ReDim Preserve NomeImm(Quante)
            NomeImm(Quante) = rec("Nome").Value

            rec.MoveNext()
        Loop
        rec.Close()

        conn.Close()
        db = Nothing

        ReDim Selezionate(Quante)

        lblNumImmagini.Text = FormattaNumero(Quante, False)

        totImmagini = Quante

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AggiungePictureBox(NomeFile As String)
        Quale += 1

        Dim gf As New GestioneFilesDirectory
        Dim pannelletto As New Panel

        pannelletto.Height = DimeBox + 30
        pannelletto.Width = DimeBox + 10
        pannelletto.BackColor = Color.Beige
        pannelletto.Name = "pnl" & Quale.ToString.Trim
        pannelletto.BorderStyle = BorderStyle.FixedSingle

        Dim pb As New PictureBox

        pb.Width = DimeBox
        pb.Height = DimeBox
        pb.Top = 5
        pb.Left = 5
        pb.BorderStyle = BorderStyle.FixedSingle
        pb.SizeMode = PictureBoxSizeMode.StretchImage
        pb.ImageLocation = NomeFile
        pb.Name = "picBox" & Quale.ToString.Trim
        AddHandler pb.Click, AddressOf pic_Click

        Dim chk As New CheckBox

        chk.Text = gf.TornaNomeFileDaPath(NomeFile)
        chk.Checked = False
        chk.Top = DimeBox + 5 + 2
        chk.Left = 5
        chk.Name = "chk" & Quale.ToString.Trim
        AddHandler chk.Click, AddressOf picCHK_Click

        pannelletto.Controls.Add(pb)
        pannelletto.Controls.Add(chk)

        FlowLayoutPanel1.Controls.Add(pannelletto)

        gf = Nothing
    End Sub

    Private Sub pic_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim pic As PictureBox = DirectCast(sender, PictureBox)

        PictureBox1.Image = pic.Image
    End Sub

    Private Sub picCHK_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim Quale As Integer = chk.Name.Replace("chk", "")

        If chk.Checked = True Then
            Selezionate(Quale) = True
        Else
            Selezionate(Quale) = False
        End If
    End Sub

    Private Sub cmdSelezionaTutti_Click(sender As Object, e As EventArgs) Handles cmdSelezionaTutti.Click
        For Each cntrl As Control In FlowLayoutPanel1.Controls
            If cntrl.Name.StartsWith("pnl") Then
                For Each cntrl2 As Control In cntrl.Controls
                    If cntrl2.Name.StartsWith("chk") Then
                        Dim Quale As Integer = cntrl2.Name.Replace("chk", "")

                        CType(cntrl2, CheckBox).Checked = True
                        Selezionate(Quale) = True
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub cmdDeSelezTutti_Click(sender As Object, e As EventArgs) Handles cmdDeSelezTutti.Click
        For Each cntrl As Control In FlowLayoutPanel1.Controls
            If cntrl.Name.StartsWith("pnl") Then
                For Each cntrl2 As Control In cntrl.Controls
                    If cntrl2.Name.StartsWith("chk") Then
                        Dim Quale As Integer = cntrl2.Name.Replace("chk", "")

                        CType(cntrl2, CheckBox).Checked = False
                        Selezionate(Quale) = False
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub cmbDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDate.SelectedIndexChanged
        If cmbDate.Text <> "" Then
            txtRicerca.Text = ""

            FlowLayoutPanel1.Controls.Clear()

            LeggeImmaginiDaDB()
        End If
    End Sub

    Private Sub cmdSposta_Click(sender As Object, e As EventArgs) Handles cmdSposta.Click
        If cmbCategoria.Text = "" Then
            MsgBox("Selezionare una categoria")
        Else
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

            For i As Integer = 1 To totImmagini
                If Selezionate(i) = True Then
                    Dim Picture As PictureBox = Nothing
                    Dim Checketto As CheckBox = Nothing

                    For Each ctr As Control In FlowLayoutPanel1.Controls
                        If ctr.Name = "pnl" & i.ToString.Trim Then
                            For Each ctr2 As Control In ctr.Controls
                                If ctr2.Name = "picBox" & i.ToString.Trim Then
                                    Picture = ctr2
                                End If
                                If ctr2.Name = "chk" & i.ToString.Trim Then
                                    Checketto = ctr2
                                End If
                                If Picture Is Nothing = False And Checketto Is Nothing = False Then
                                    Exit for
                                End If
                            Next
                            Exit For
                        End If
                    Next

                    CartellaOrig = gf.TornaNomeDirectoryDaPath(NomeImm(i))
                    NomeFile = gf.TornaNomeFileDaPath(NomeImm(i))
                    CartellaDest = Percorso & "\Categorie\" & cmbCategoria.Text & "\"

                    If NomeImm(i).ToUpper.IndexOf("\V\") > -1 Then
                        CartellaDest += "V\"
                    Else
                        CartellaDest += "N\"
                    End If

                    Dim NomeFileDestinazione As String = CartellaDest & NomeFile
                    Dim Continua As Boolean = True

                    gf.CreaDirectoryDaPercorso(CartellaDest)
                    If File.Exists(NomeFileDestinazione) = True Then
                        Dim NomeNuovo As String = gf.NomeFileEsistente(NomeFileDestinazione)

                        Dim f As New frmUguale
                        f.ImpostaImmagini(NomeImm(i), NomeFileDestinazione, NomeNuovo)
                        f.ShowDialog()
                        Dim Ritorno As String = f.lblRitorno.Text
                        f.Dispose()
                        f = Nothing
                        Select Case Ritorno
                            Case "0"
                                ' Annulla
                                Continua = False
                            Case "1"
                                ' Sovrascrivi
                                Kill(NomeFileDestinazione)
                                gf.CopiaFileFisico(NomeImm(i), NomeFileDestinazione, True)
                            Case "2"
                                ' Rinomina
                                NomeFileDestinazione = NomeNuovo
                                gf.CopiaFileFisico(NomeImm(i), NomeFileDestinazione, True)
                        End Select
                    Else
                        gf.CopiaFileFisico(NomeImm(i), NomeFileDestinazione, True)
                    End If

                    If File.Exists(NomeFileDestinazione) = True And Continua = True Then
                        gf.EliminaFileFisico(NomeImm(i))

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

                        Picture.Image.Dispose()
                        Picture.Image = Nothing
                        Selezionate(i) = False

                        Checketto.Visible = False
                    End If
                End If
            Next

            gf = Nothing

            'FlowLayoutPanel1.Controls.Clear()

            ''CaricaDate()
            'LeggeImmaginiDaDB()
        End If
    End Sub

    Private Sub cmdChiude_Click(sender As Object, e As EventArgs) Handles cmdChiude.Click
        Me.Close()
        Me.Dispose()
        frmMain.Show()
    End Sub

    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        Dim gf As New GestioneFilesDirectory
        Dim CartellaOrig As String
        Dim NomeFile As String
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim sql As String
        Dim idCartella As Integer

        For i As Integer = 1 To totImmagini
            If Selezionate(i) = True Then
                Dim Picture As PictureBox = Nothing
                Dim Checketto As CheckBox = Nothing

                For Each ctr As Control In FlowLayoutPanel1.Controls
                    If ctr.Name = "pnl" & i.ToString.Trim Then
                        For Each ctr2 As Control In ctr.Controls
                            If ctr2.Name = "picBox" & i.ToString.Trim Then
                                Picture = ctr2
                            End If
                            If ctr2.Name = "chk" & i.ToString.Trim Then
                                Checketto = ctr2
                            End If
                            If Picture Is Nothing = False And Checketto Is Nothing = False Then
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next

                CartellaOrig = gf.TornaNomeDirectoryDaPath(NomeImm(i))
                NomeFile = gf.TornaNomeFileDaPath(NomeImm(i))

                gf.EliminaFileFisico(NomeImm(i))

                sql = "Select * From Cartelle Where Descrizione='" & SistemaTestoPerDB(CartellaOrig) & "'"
                rec = db.LeggeQuery(conn, sql)
                idCartella = rec("idCartella").Value
                rec.Close()

                sql = "Delete * From Dati Where idCartella=" & idCartella & " And NomeFile='" & SistemaTestoPerDB(NomeFile) & "'"
                db.EsegueSql(conn, sql)

                Picture.Image.Dispose()
                Picture.Image = Nothing
                Selezionate(i) = False

                Checketto.Visible = False
            End If
        Next

        gf = Nothing

        'FlowLayoutPanel1.Controls.Clear()

        ''CaricaDate()
        'LeggeImmaginiDaDB()
    End Sub

    Private Sub cmdNuovaCategoria_Click(sender As Object, e As EventArgs) Handles cmdNuovaCategoria.Click
        Dim Ritorno As String = InputBox("Nome Nuova Categoria")

        If Ritorno <> "" Then
            Dim Percorso As String = GetSetting("Uguaglianze", "Impostazioni", "Percorso", Application.StartupPath)

            Try
                MkDir(Percorso & "\Categorie\" & Ritorno.ToUpper.Trim)
            Catch ex As Exception

            End Try

            CaricaCategorie()
        End If
    End Sub

    Private Sub cmdCarica_Click(sender As Object, e As EventArgs) Handles cmdCarica.Click
        If txtRicerca.Text <> "" Then
            cmbDate.Text = ""

            FlowLayoutPanel1.Controls.Clear()

            LeggeImmaginiDaDB()
        End If
    End Sub

    Private Sub cmdAvantiData_Click(sender As Object, e As EventArgs) Handles cmdAvantiData.Click
        If cmbDate.Text = "" Then
            Exit Sub
        End If

        Dim Datella As Date
        If cmbDate.Text.IndexOf(":") > -1 Then
            Datella = Mid(cmbDate.Text, 1, cmbDate.Text.IndexOf(":"))
        Else
            Datella = cmbDate.Text
        End If
        Dim Ok As Boolean

        Ok = False
        Do While Ok = False
            Datella = Datella.AddDays(1)
            Dim sDatella As String = Format(Datella.Day, "00") & "/" & Format(Datella.Month, "00") & "/" & Datella.Year
            For i As Integer = 0 To cmbDate.Items.Count - 1
                If cmbDate.Items(i).ToString.IndexOf(sDatella) > -1 Then
                    cmbDate.Text = cmbDate.Items(i).ToString
                    Ok = True
                    Exit For
                End If
            Next
        Loop

        If Ok = True Then
            SaveSetting("Uguaglianze", "Impostazioni", "DataCateg", Mid(cmbDate.Text, 1, cmbDate.Text.IndexOf(":")))

            'FlowLayoutPanel1.Controls.Clear()

            'LeggeImmaginiDaDB()
        End If
    End Sub

    Private Sub cmdIndietroData_Click(sender As Object, e As EventArgs) Handles cmdIndietroData.Click
        If cmbDate.Text = "" Then
            Exit Sub
        End If

        Dim Datella As Date
        If cmbDate.Text.IndexOf(":") > -1 Then
            Datella = Mid(cmbDate.Text, 1, cmbDate.Text.IndexOf(":"))
        Else
            Datella = cmbDate.Text
        End If
        Dim Ok As Boolean

        Ok = False
        Do While Ok = False
            Datella = Datella.AddDays(-1)
            Dim sDatella As String = Format(Datella.Day, "00") & "/" & Format(Datella.Month, "00") & "/" & Datella.Year
            For i As Integer = 0 To cmbDate.Items.Count - 1
                If cmbDate.Items(i).ToString.IndexOf(sDatella) > -1 Then
                    cmbDate.Text = cmbDate.Items(i).ToString
                    Ok = True
                    Exit For
                End If
            Next
        Loop

        If Ok = True Then
            SaveSetting("Uguaglianze", "Impostazioni", "DataCateg", Mid(cmbDate.Text, 1, cmbDate.Text.IndexOf(":")))

            'FlowLayoutPanel1.Controls.Clear()

            'LeggeImmaginiDaDB()
        End If
    End Sub

    Private Sub cmdMarchia_Click(sender As Object, e As EventArgs) Handles cmdMarchia.Click
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String

        sql = "Insert Into DateControllate Values ('" & Mid(cmbDate.Text, 1, cmbDate.Text.IndexOf(":")).Trim & "')"
        db.EsegueSql(conn, sql)

        conn.Close
        db = Nothing

        'CaricaDate()
        'PictureBox1.Image.Dispose()
        PictureBox1.Image = Nothing

        FlowLayoutPanel1.Controls.Clear()

        'cmbDate.Text = ""
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        CaricaDate()
    End Sub
End Class