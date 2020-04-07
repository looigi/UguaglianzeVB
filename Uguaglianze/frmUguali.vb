Imports System.IO

Public Class frmUguali
    Private ValoreDiConfronto As Integer = 0

    Private Sub frmUguali_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VisualizzaImmaginiUguali(sender, e)
    End Sub

    Private Function CaricaImmagine(Immagine As String, PicImmagine As PictureBox, Prima As Boolean) As Boolean
        If File.Exists(Immagine) = False Then
            PicImmagine.Image = Nothing
            If Prima = True Then
                lblNomeImm1.Visible = False
            Else
                lblNomeImm2.Visible = False
            End If
            Return False
            Exit Function
        End If
        If Prima = True Then
            lblNomeImm1.Visible = True
        Else
            lblNomeImm2.Visible = True
        End If

        Dim fs As System.IO.FileStream
        fs = New System.IO.FileStream(Immagine,
             IO.FileMode.Open, IO.FileAccess.Read)
        PicImmagine.Image = System.Drawing.Image.FromStream(fs)
        fs.Close()
        fs = Nothing

        Dim gi As New GestioneImmagini

        Dim Dime() As String = gi.RitornaDimensioneImmagine(Immagine).Split("x")
        Dim dX As Integer = Val(Dime(0))
        Dim dY As Integer = Val(Dime(1))
        Dim odX As Integer = dX
        Dim odY As Integer = dY

        gi = Nothing

        Dim sX As Integer = pnlUguali.Width / 2
        Dim sY As Integer = (pnlUguali.Height - 35 - lblNomeImm1.Height)

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

        PicImmagine.Width = dX
        PicImmagine.Height = dY

        If Prima = True Then
            PicImmagine.Left = (pnlUguali.Width / 2) + ((sX / 2) - (dX / 2))
            PicImmagine.Top = 32

            lblNomeImm1.Width = (pnlUguali.Width / 2) - 2
            lblNomeImm1.Left = 0
        Else
            PicImmagine.Left = ((sX / 2) - (dX / 2))
            PicImmagine.Top = 32

            lblNomeImm2.Width = (pnlUguali.Width / 2) - 2
            lblNomeImm2.Left = (pnlUguali.Width / 2)
        End If

        PicImmagine.Visible = True

        Return True
    End Function

    Private Sub VisualizzaImmaginiUguali(sender As Object, e As EventArgs)
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"
        Dim Conta As Integer = 0

        sql = "Select Count(*) From PrendeUguali Where NomeDiverso <> 0"
        rec = db.LeggeQuery(conn, sql)
        If rec(0).Value Is DBNull.Value = True Then
            QuanteUguali = 0
        Else
            QuanteUguali = rec(0).Value
        End If
        rec.Close()

        If QuanteUguali > 0 Then
            ReDim idDestraUguali(QuanteUguali)
            ReDim UgualiDestra(QuanteUguali)
            ReDim dimeDestra(QuanteUguali)
            ReDim xDestra(QuanteUguali)
            ReDim yDestra(QuanteUguali)

            ReDim idSinistraUguali(QuanteUguali)
            ReDim UgualiSinistra(QuanteUguali)
            ReDim dimeSinistra(QuanteUguali)
            ReDim xSinistra(QuanteUguali)
            ReDim ySinistra(QuanteUguali)

            ReDim idUguali(QuanteUguali)

            ReDim StatoImmagine(QuanteUguali)
            ReDim Metodo(QuanteUguali)

            sql = "Select * From PrendeUguali Where NomeDiverso <> 0"
            rec = db.LeggeQuery(conn, sql)
            Do Until rec.Eof
                Conta += 1

                idUguali(Conta) = rec(0).Value

                idSinistraUguali(Conta) = rec(1).Value
                UgualiSinistra(Conta) = rec(2).Value & "\" & rec(3).Value
                xSinistra(Conta) = rec("X1").Value
                ySinistra(Conta) = rec("Y1").Value
                dimeSinistra(Conta) = rec("Dime1").Value

                idDestraUguali(Conta) = rec(4).Value
                UgualiDestra(Conta) = rec(5).Value & "\" & rec(6).Value
                xDestra(Conta) = rec("X2").Value
                yDestra(Conta) = rec("Y2").Value
                dimeDestra(Conta) = rec("Dime2").Value

                Metodo(Conta) = rec("Modalita").Value
                StatoImmagine(Conta) = 0

                rec.MoveNext()
            Loop
            rec.Close()
        Else
            Me.Close()
            Me.Dispose()
            frmMain.Show()
        End If

        conn.Close()
        db = Nothing

        QualeVisualizzataUguale = 1

        If QualeVisualizzataUguale <= QuanteUguali Then
            VisualizzaImmaginiUgualiInPicture(sender, e)
        End If
    End Sub

    Private Sub ControllaSeImmaginiInPictureSonoUguali(PrimaCe As Boolean, SecondaCe As Boolean)
        Dim bmControllo1 As Image = Nothing
        If PrimaCe = True Then
            bmControllo1 = New Bitmap(PictureBox1.Image, 150, 150)
        End If
        Dim bmControllo2 As Image = Nothing
        If SecondaCe = True Then
            bmControllo2 = New Bitmap(PictureBox2.Image, 150, 150)
        End If

        If bmControllo1 Is Nothing Or bmControllo2 Is Nothing Then
            ValoreDiConfronto = -1
            Exit Sub
        End If

        Dim Colore1 As Color
        Dim Colore2 As Color
        Dim Differenza As Long = 0
        Dim Rosso1 As Single
        Dim Verde1 As Single
        Dim Blu1 As Single
        Dim Rosso2 As Single
        Dim Verde2 As Single
        Dim Blu2 As Single

        For X As Integer = 0 To 149
            For Y As Integer = 0 To 149
                Colore1 = DirectCast(bmControllo1, Bitmap).GetPixel(X, Y)
                Rosso1 = Colore1.R : If Rosso1 > 128 Then Rosso1 = 255 Else Rosso1 = 0
                Verde1 = Colore1.G : If Verde1 > 128 Then Verde1 = 255 Else Verde1 = 0
                Blu1 = Colore1.B : If Blu1 > 128 Then Blu1 = 255 Else Blu1 = 0

                Colore2 = DirectCast(bmControllo2, Bitmap).GetPixel(X, Y)
                Rosso2 = Colore2.R : If Rosso2 > 128 Then Rosso2 = 255 Else Rosso2 = 0
                Verde2 = Colore2.G : If Verde2 > 128 Then Verde2 = 255 Else Verde2 = 0
                Blu2 = Colore2.B : If Blu2 > 128 Then Blu2 = 255 Else Blu2 = 0

                If Rosso1 <> Rosso2 Or Verde1 <> Verde2 Or Blu1 <> Blu2 Then
                    Differenza += 1
                End If
            Next
        Next

        bmControllo1.Dispose()
        bmControllo2.Dispose()

        ValoreDiConfronto = Differenza
    End Sub

    Private Function VisualizzaImmaginiUgualiInPicture(sender As Object, e As EventArgs) As Integer
        Dim Ritorno As Boolean = 0
        ' 0 = false
        ' 1 = true
        ' 2 = avanza

        Dim PrimaImmagineCe As Boolean = CaricaImmagine(UgualiSinistra(QualeVisualizzataUguale), PictureBox1, False)
        Dim SecondaImmagineCe As Boolean = CaricaImmagine(UgualiDestra(QualeVisualizzataUguale), PictureBox2, True)

        If PrimaImmagineCe = False Or SecondaImmagineCe = False Then
            lblUguali.Text = "Skip " & QualeVisualizzataUguale & "/" & QuanteUguali
            lblMetodo.Text = ""

            lblNomeImm1.Visible = False
            PictureBox1.Visible = False

            lblNomeImm2.Visible = False
            PictureBox2.Visible = False

            Application.DoEvents()
            cmdRicorda.Focus()
            If QualeVisualizzataUguale < QuanteUguali Then
                ' Call cmdAvanti_Click(sender, e)
                Return 2
            End If
            Return 1
            Exit Function
        End If

        ControllaSeImmaginiInPictureSonoUguali(PrimaImmagineCe, SecondaImmagineCe)

        Select Case StatoImmagine(QualeVisualizzataUguale)
            Case 1
                lblEliminata.Text = "Eliminata"
                lblEliminata.Left = PictureBox1.Left + ((PictureBox1.Width / 2) - (lblEliminata.Width / 2))
                lblEliminata.Top = PictureBox1.Top + ((PictureBox1.Height / 2) - (lblEliminata.Height / 2))
                lblEliminata.Visible = True
            Case 2
                lblEliminata.Text = "Eliminata"
                lblEliminata.Left = PictureBox2.Left + ((PictureBox2.Width / 2) - (lblEliminata.Width / 2))
                lblEliminata.Top = PictureBox2.Top + ((PictureBox2.Height / 2) - (lblEliminata.Height / 2))
                lblEliminata.Visible = True
            Case 3
                lblEliminata.Text = "Ricordate"

                lblEliminata.Left = pnlUguali.Left + ((pnlUguali.Width / 2) - (lblEliminata.Width / 2))
                lblEliminata.Top = (pnlUguali.Top + ((pnlUguali.Height / 2) - (lblEliminata.Height / 2))) - 64

                lblEliminata.Visible = True
            Case 4
                lblEliminata.Text = "Spostata"
                lblEliminata.Left = PictureBox1.Left + ((PictureBox1.Width / 2) - (lblEliminata.Width / 2))
                lblEliminata.Top = PictureBox1.Top + ((PictureBox1.Height / 2) - (lblEliminata.Height / 2))
                lblEliminata.Visible = True
            Case 5
                lblEliminata.Text = "Spostata"
                lblEliminata.Left = PictureBox2.Left + ((PictureBox2.Width / 2) - (lblEliminata.Width / 2))
                lblEliminata.Top = PictureBox2.Top + ((PictureBox2.Height / 2) - (lblEliminata.Height / 2))
                lblEliminata.Visible = True
            Case 6
                lblEliminata.Text = "Eliminate"

                lblEliminata.Left = pnlUguali.Left + ((pnlUguali.Width / 2) - (lblEliminata.Width / 2))
                lblEliminata.Top = (pnlUguali.Top + ((pnlUguali.Height / 2) - (lblEliminata.Height / 2))) - 64

                lblEliminata.Visible = True
            Case Else
                lblEliminata.Visible = False
        End Select

        If PrimaImmagineCe = True Then
            lblNomeImm1.Text = "Kb. " & FormattaNumero(dimeSinistra(QualeVisualizzataUguale), False) & "-" & xSinistra(QualeVisualizzataUguale) & "x" & ySinistra(QualeVisualizzataUguale) & vbCrLf & UgualiSinistra(QualeVisualizzataUguale)
            lblNomeImm1.Visible = True
            PictureBox1.Visible = True
        Else
            lblNomeImm1.Visible = False
            PictureBox1.Visible = False
            cmdRicorda.Focus()
        End If
        If SecondaImmagineCe = True Then
            lblNomeImm2.Text = "Kb. " & FormattaNumero(dimeDestra(QualeVisualizzataUguale), False) & "-" & xDestra(QualeVisualizzataUguale) & "x" & yDestra(QualeVisualizzataUguale) & vbCrLf & UgualiDestra(QualeVisualizzataUguale)
            lblNomeImm2.Visible = True
            PictureBox2.Visible = True
        Else
            lblNomeImm2.Text = ""
            lblNomeImm2.Visible = False
            PictureBox2.Visible = False
            cmdRicorda.Focus()
        End If

        lblUguali.Text = "Uguali rilevate: " & QuanteUguali & " - Visualizzata: " & QualeVisualizzataUguale

        lblMetodo.Text = Metodo(QualeVisualizzataUguale)

        If ValoreDiConfronto = -1 Then
            cmdRicorda.Focus()
        Else
            AbilitaTastiPerUguali()
        End If

        Return 1
    End Function

    Private Sub AbilitaTastiPerUguali()
        If ValoreDiConfronto > 700 Then
            cmdRicorda.Focus()
            Exit Sub
        End If

        If lblNomeImm1.Text.ToUpper.Trim = lblNomeImm2.Text.ToUpper.Trim Then
            cmdRicorda.Focus()
            Exit Sub
        End If

        Dim Quale As Integer = -1

        If dimeSinistra(QualeVisualizzataUguale) > dimeDestra(QualeVisualizzataUguale) Then
            Quale = 2
        Else
            If dimeSinistra(QualeVisualizzataUguale) < dimeDestra(QualeVisualizzataUguale) Then
                Quale = 1
            Else
                If xSinistra(QualeVisualizzataUguale) > xDestra(QualeVisualizzataUguale) And ySinistra(QualeVisualizzataUguale) > yDestra(QualeVisualizzataUguale) Then
                    Quale = 2
                Else
                    If xSinistra(QualeVisualizzataUguale) < xDestra(QualeVisualizzataUguale) And ySinistra(QualeVisualizzataUguale) < yDestra(QualeVisualizzataUguale) Then
                        Quale = 1
                    Else

                    End If
                End If
            End If
        End If

        If lblNomeImm1.Text.ToString.ToUpper.IndexOf("SITERIPS") > -1 Or lblNomeImm1.Text.ToString.ToUpper.IndexOf("CATEGORIE") > -1 Or lblNomeImm1.Text.ToString.ToUpper.IndexOf("PICDROP") > -1 Or
            lblNomeImm2.Text.ToString.ToUpper.IndexOf("SITERIPS") Or lblNomeImm2.Text.ToString.ToUpper.IndexOf("CATEGORIE") > -1 Or lblNomeImm2.Text.ToString.ToUpper.IndexOf("PICDROP") > -1 Then
            If lblNomeImm1.Text.ToString.ToUpper.IndexOf("SITERIPS") > -1 Or lblNomeImm1.Text.ToString.ToUpper.IndexOf("CATEGORIE") > -1 Or lblNomeImm1.Text.ToString.ToUpper.IndexOf("PICDROP") > -1 Then
                If dimeSinistra(QualeVisualizzataUguale) < dimeDestra(QualeVisualizzataUguale) Then
                    Quale = 4
                Else
                    Quale = 2
                End If
            Else
                If dimeSinistra(QualeVisualizzataUguale) > dimeDestra(QualeVisualizzataUguale) Then
                    Quale = 3
                Else
                    Quale = 1
                End If
            End If
        End If

        Select Case Quale
            Case 1
                cmdEliminaSinistra.Focus()
            Case 2
                cmdEliminaDestra.Focus()
            Case 3
                cmdCopiaADestra.Focus()
            Case 4
                cmdCopiaASinistra.Focus()
            Case Else
                If lblNomeImm1.Text.ToUpper.IndexOf("COPIA") > -1 Then
                    cmdEliminaSinistra.Focus()
                Else
                    If lblNomeImm2.Text.ToUpper.IndexOf("COPIA") > -1 Then
                        cmdCopiaADestra.Focus()
                    Else
                        If lblNomeImm1.Text.ToUpper.IndexOf("0001") > -1 Then
                            cmdEliminaSinistra.Focus()
                        Else
                            If lblNomeImm2.Text.ToUpper.IndexOf("0001") > -1 Then
                                cmdCopiaADestra.Focus()
                            Else
                                cmdEliminaSinistra.Focus()
                                'cmdAvanti.Focus()
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub cmdAvanti_Click(sender As Object, e As EventArgs) Handles cmdAvanti.Click
        Dim ancora As Boolean = True

        Do While ancora
            QualeVisualizzataUguale += 1
            If QualeVisualizzataUguale > QuanteUguali Then
                QualeVisualizzataUguale = 1
            End If

            'Do While VisualizzaImmaginiUgualiInPicture() = False
            '    QualeVisualizzataUguale += 1
            '    If QualeVisualizzataUguale > QuanteUguali Then
            '        QualeVisualizzataUguale = 1
            '        MsgBox("Fine elenco immagini")
            '        Exit Do
            '    End If
            'Loop

            Dim rit As Integer = VisualizzaImmaginiUgualiInPicture(sender, e)
            If rit < 2 Then
                ancora = False
            ElseIf rit = 2 Then
                StatoImmagine(QualeVisualizzataUguale) = 3
            End If
        Loop
    End Sub

    Private Sub cmdIndietro_Click(sender As Object, e As EventArgs) Handles cmdIndietro.Click
        Dim ancora As Boolean = True

        Do While ancora
            QualeVisualizzataUguale -= 1
            If QualeVisualizzataUguale < 1 Then
                QualeVisualizzataUguale = QuanteUguali
            End If

            'Do While VisualizzaImmaginiUgualiInPicture() = False
            '    QualeVisualizzataUguale -= 1
            '    If QualeVisualizzataUguale < 1 Then
            '        QualeVisualizzataUguale = QuanteUguali
            '        MsgBox("Fine elenco")
            '        Exit Do
            '    End If
            'Loop

            Dim rit As Integer = VisualizzaImmaginiUgualiInPicture(sender, e)
            If rit < 2 Then
                ancora = False
            ElseIf rit = 2 Then
                StatoImmagine(QualeVisualizzataUguale) = 3
            End If
        Loop
    End Sub

    Private Sub cmdEliminaSinistra_Click(sender As Object, e As EventArgs) Handles cmdEliminaSinistra.Click
        StatoImmagine(QualeVisualizzataUguale) = 1

        Call cmdAvanti_Click(sender, e)
    End Sub

    Private Sub cmdEliminaDestra_Click(sender As Object, e As EventArgs) Handles cmdEliminaDestra.Click
        StatoImmagine(QualeVisualizzataUguale) = 2

        Call cmdAvanti_Click(sender, e)
    End Sub

    Private Sub cmdCopiaADestra_Click(sender As Object, e As EventArgs) Handles cmdCopiaADestra.Click
        StatoImmagine(QualeVisualizzataUguale) = 4

        Call cmdAvanti_Click(sender, e)
    End Sub

    Private Sub cmdCopiaASinistra_Click(sender As Object, e As EventArgs) Handles cmdCopiaASinistra.Click
        StatoImmagine(QualeVisualizzataUguale) = 5

        Call cmdAvanti_Click(sender, e)
    End Sub

    Private Sub cmdElimina2_Click(sender As Object, e As EventArgs) Handles cmdElimina2.Click
        StatoImmagine(QualeVisualizzataUguale) = 6

        Call cmdAvanti_Click(sender, e)
    End Sub

    Private Sub cmdPulisceUguali_Click(sender As Object, e As EventArgs) Handles cmdPulisceUguali.Click
        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String

        sql = "Delete * From Uguali Where Ricordato='N'"
        db.EsegueSql(conn, sql)

        conn.Close()
        db = Nothing

        'ContaImmagini()

        VisualizzaImmaginiUguali(sender, e)
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim Nome As String
        Dim iD1 As Integer
        Dim iD2 As Integer
        Dim gf As New GestioneFilesDirectory
        Dim Ricorda As Boolean
        Dim SpostaADestra As Boolean
        Dim SpostaASinistra As Boolean
        Dim Elimina2 As Boolean

        Dim db As New GestioneDB
        Dim conn As Object = "ADODB.Connection"
        conn = db.ApreDB()
        Dim sql As String
        Dim rec As Object = "ADODB.Recordset"

        For i As Integer = 1 To QuanteUguali
            Nome = ""
            Ricorda = False
            SpostaADestra = False
            SpostaASinistra = False
            Elimina2 = False

            Select Case StatoImmagine(i)
                Case 1
                    Nome = UgualiSinistra(i)
                Case 2
                    Nome = UgualiDestra(i)
                Case 3
                    Ricorda = True
                Case 4
                    SpostaADestra = True
                Case 5
                    SpostaASinistra = True
                Case 6
                    Elimina2 = True
                Case Else
            End Select

            If Nome <> "" Then
                gf.EliminaFileFisico(Nome)

                iD1 = idSinistraUguali(i)
                iD2 = idDestraUguali(i)

                sql = "Delete * From Uguali Where (idPrimo=" & iD1 & " And idSecondo=" & iD2 & ") Or (idPrimo=" & iD2 & " And idSecondo=" & iD1 & ")"
                db.EsegueSql(conn, sql)

                sql = "Delete * From CRC Where idImmagine=" & iD1 & " Or idImmagine=" & iD2
                db.EsegueSql(conn, sql)

                sql = "Delete * From DatiEXIF Where idImmagine=" & iD1 & " Or idImmagine=" & iD2
                db.EsegueSql(conn, sql)
            End If

            If Elimina2 = True Then
                Nome = UgualiSinistra(i)

                gf.EliminaFileFisico(Nome)

                Nome = UgualiDestra(i)

                gf.EliminaFileFisico(Nome)

                iD1 = idSinistraUguali(i)
                iD2 = idDestraUguali(i)

                sql = "Delete * From Uguali Where (idPrimo=" & iD1 & " And idSecondo=" & iD2 & ") Or (idPrimo=" & iD2 & " And idSecondo=" & iD1 & ")"
                db.EsegueSql(conn, sql)

                sql = "Delete * From CRC Where idImmagine=" & iD1 & " Or idImmagine=" & iD2
                db.EsegueSql(conn, sql)

                sql = "Delete * From DatiEXIF Where idImmagine=" & iD1 & " Or idImmagine=" & iD2
                db.EsegueSql(conn, sql)
            End If

            If Ricorda = True Then
                sql = "Update Uguali Set Ricordato='S' Where id=" & idUguali(i)
                db.EsegueSql(conn, sql)
            End If

            If SpostaADestra = True Then
                gf.CopiaFileFisico(UgualiSinistra(i), UgualiDestra(i), True)
                gf.EliminaFileFisico(UgualiSinistra(i))

                iD1 = idSinistraUguali(i)
                iD2 = idDestraUguali(i)

                sql = "Delete * From Uguali Where (idPrimo=" & iD1 & " And idSecondo=" & iD2 & ") Or (idPrimo=" & iD2 & " And idSecondo=" & iD1 & ")"
                db.EsegueSql(conn, sql)

                sql = "Delete * From CRC Where idImmagine=" & iD2
                db.EsegueSql(conn, sql)

                sql = "Delete * From DatiEXIF Where idImmagine=" & iD2
                db.EsegueSql(conn, sql)

                sql = "Update CRC Set idImmagine=" & iD2 & " Where idImmagine=" & iD1
                db.EsegueSql(conn, sql)

                sql = "Update DatiEXIF Set idImmagine=" & iD2 & " Where idImmagine=" & iD1
                db.EsegueSql(conn, sql)
            End If

            If SpostaASinistra = True Then
                gf.CopiaFileFisico(UgualiDestra(i), UgualiSinistra(i), True)
                gf.EliminaFileFisico(UgualiDestra(i))

                iD1 = idSinistraUguali(i)
                iD2 = idDestraUguali(i)

                sql = "Delete * From Uguali Where (idPrimo=" & iD1 & " And idSecondo=" & iD2 & ") Or (idPrimo=" & iD2 & " And idSecondo=" & iD1 & ")"
                db.EsegueSql(conn, sql)

                sql = "Delete * From CRC Where idImmagine=" & iD1
                db.EsegueSql(conn, sql)

                sql = "Delete * From DatiEXIF Where idImmagine=" & iD1
                db.EsegueSql(conn, sql)

                sql = "Update CRC Set idImmagine=" & iD1 & " Where idImmagine=" & iD2
                db.EsegueSql(conn, sql)

                sql = "Update DatiEXIF Set idImmagine=" & iD1 & " Where idImmagine=" & iD2
                db.EsegueSql(conn, sql)
            End If
        Next

        conn.Close()

        gf = Nothing
        db = Nothing

        'ContaImmagini()

        VisualizzaImmaginiUguali(sender, e)

        MsgBox("Immagini aggiornate")
    End Sub

    Private Sub cmdRicorda_Click(sender As Object, e As EventArgs) Handles cmdRicorda.Click
        StatoImmagine(QualeVisualizzataUguale) = 3

        Call cmdAvanti_Click(sender, e)
    End Sub

    Private Sub cmdUscita_Click(sender As Object, e As EventArgs) Handles cmdUscita.Click
        Me.Close()
        Me.Dispose()
        frmMain.Show()
    End Sub

    Private Sub lblNomeImm1_Click(sender As Object, e As EventArgs)
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = "rundll32.exe "
        p.StartInfo.Arguments = System.IO.Path.Combine(System.Environment.SystemDirectory, "shimgvw.dll")
        p.StartInfo.Arguments &= ",ImageView_Fullscreen "
        p.StartInfo.Arguments &= UgualiSinistra(QualeVisualizzataUguale)
        p.StartInfo.UseShellExecute = False
        p.StartInfo.Verb = "open"
        p.Start()
    End Sub

    Private Sub lblNomeImm2_Click(sender As Object, e As EventArgs)
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = "rundll32.exe "
        p.StartInfo.Arguments = System.IO.Path.Combine(System.Environment.SystemDirectory, "shimgvw.dll")
        p.StartInfo.Arguments &= ",ImageView_Fullscreen "
        p.StartInfo.Arguments &= UgualiDestra(QualeVisualizzataUguale)
        p.StartInfo.UseShellExecute = False
        p.StartInfo.Verb = "open"
        p.Start()
    End Sub
End Class