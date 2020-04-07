Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Drawing.Image
Imports System.Security.Cryptography
Imports System.Text

Public Class GestioneImmagini
    Private NomeBNRid As String = Application.StartupPath & "\Thumbs\AppoggioBN.Jpg"
    Private NomeRid As String = Application.StartupPath & "\Thumbs\Appoggio.Jpg"
    Private Const qX As Integer = 50
    Private Const qY As Integer = 50
    Private Const quadrettoX As Integer = 3
    Private Const quadrettoY As Integer = 3
    Private Const Divisore As Integer = 32
    Private C(2) As Integer
    Private Colore As Color
    Private r As Integer
    Private g As Integer
    Private b As Integer

    Public Sub CreaValoreUnivocoImmagine(idImmagine As Long, Db As GestioneDB, Conn As Object, Immagine As String, gf As GestioneFilesDirectory)
        If File.Exists(Immagine) = False Then
            Exit Sub
        End If

        Dim imgImmagine As Image
        Dim Stringona As String

        If Ridimensiona(Immagine, NomeRid, qX, qY) = True Then
            ConverteImmaginInBN(NomeRid, NomeBNRid)

            Try
                Kill(NomeRid)
            Catch ex As Exception

            End Try

            imgImmagine = New Bitmap(NomeBNRid)

            Stringona = ""

            Dim Valore As String

            For I As Integer = 1 To qX Step quadrettoX
                For k As Integer = 1 To qY Step quadrettoY
                    Colore = DirectCast(imgImmagine, Bitmap).GetPixel(k, I)

                    r = Colore.R '* 0.49999999999999994
                    g = Colore.G '* 0.49000000000000005
                    b = Colore.B '* 0.49999999999999595

                    'r = CInt((r \ Divisore)) * Divisore
                    'b = CInt((b \ Divisore)) * Divisore
                    'g = CInt((g \ Divisore)) * Divisore

                    If r > 128 Then r = 65 Else r = 32
                    If g > 128 Then g = 65 Else g = 32
                    If b > 128 Then b = 65 Else b = 32

                    'C(0) = r
                    'C(1) = b
                    'C(2) = g
                    'For Z = 0 To 2
                    '    For L = Z + 1 To 2
                    '        If C(Z) < C(L) Then
                    '            A = C(Z)
                    '            C(Z) = C(L)
                    '            C(L) = A
                    '        End If
                    '    Next L
                    'Next Z
                    'r = C(0)

                    Select Case Chr(r) & Chr(g) & Chr(b)
                        Case "A  "
                            Valore = "1"
                        Case " A "
                            Valore = "2"
                        Case "  A"
                            Valore = "3"
                        Case "AA "
                            Valore = "4"
                        Case "A A"
                            Valore = "5"
                        Case " AA"
                            Valore = "6"
                        Case "AAA"
                            Valore = "7"
                        Case "   "
                            Valore = "8"
                        Case Else
                            Valore = "9"
                    End Select
                    Stringona += Valore
                Next k
            Next I

            Stringona = Stringona.Replace(" '", "''")
            Stringona = Stringona.Replace(Chr(0), "0")

            'Dim Numerone As Long = 0

            'For i As Integer = 0 To Stringona.Length - 1
            '    Numerone += (Val(Stringona.Substring(i, 1))) * (i + 1)
            'Next

            imgImmagine.Dispose()
            imgImmagine = Nothing

            Try
                Kill(NomeBNRid)
            Catch ex As Exception

            End Try

            Dim Sql As String

            Sql = "Delete * From CRC Where idImmagine=" & idImmagine
            Db.EsegueSql(Conn, Sql)

            Sql = "Insert Into CRC Values (" & idImmagine & ", '" & Stringona & "')"
            Db.EsegueSql(Conn, Sql)
        Else
            Try
                File.Delete(Immagine)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub SalvaImmagineDaPictureBox(filename As String, image As Image, Optional dimeX As Integer = -1, Optional dimeY As Integer = -1)
        If image Is Nothing Then
            Exit Sub
        End If

        If dimeX = -1 Or dimeY = -1 Then
            dimeX = image.Width
            dimeY = image.Height
        End If

        Dim bmp As Bitmap = image
        Dim bmpt As New Bitmap(dimeX, dimeY)
        Using g As Graphics = Graphics.FromImage(bmpt)
            g.DrawImage(bmp, 0, 0, _
                        bmpt.Width + 1, _
                        bmpt.Height + 1)
        End Using
        bmpt.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Public Function RitornaDimensioneImmagine(Immagine As String) As String
        Dim bt As Bitmap

        Try
            bt = Image.FromFile(Immagine)
            Dim w As Integer = bt.Width
            Dim h As Integer = bt.Height

            bt.Dispose()
            bt = Nothing

            Return w & "x" & h
        Catch ex As Exception
            Return "ERRORE: " & ex.Message
        End Try
    End Function

    Public Sub ConverteImmaginInBN(Path As String, Path2 As String)
        Dim img As Bitmap
        Dim ImmaginePiccola As Image
        'Dim ImmaginePiccola2 As Image
        Dim jgpEncoder As Imaging.ImageCodecInfo
        Dim myEncoder As System.Drawing.Imaging.Encoder
        Dim myEncoderParameters As New Imaging.EncoderParameters(1)

        img = New Bitmap(Path)

        ImmaginePiccola = New Bitmap(img)

        img.Dispose()
        img = Nothing

        ImmaginePiccola = Converte(ImmaginePiccola)

        jgpEncoder = GetEncoder(Imaging.ImageFormat.Jpeg)
        myEncoder = System.Drawing.Imaging.Encoder.Quality
        Dim myEncoderParameter As New Imaging.EncoderParameter(myEncoder, 99)
        myEncoderParameters.Param(0) = myEncoderParameter

        ImmaginePiccola.Save(Path2, jgpEncoder, myEncoderParameters)

        ImmaginePiccola.Dispose()

        ImmaginePiccola = Nothing
        'ImmaginePiccola2 = Nothing
        jgpEncoder = Nothing
        myEncoderParameter = Nothing
    End Sub

    Public Function Ridimensiona(Path As String, Path2 As String, Larghezza As Integer, Altezza As Integer) As Boolean
        Dim myEncoder As System.Drawing.Imaging.Encoder
        Dim myEncoderParameters As New Imaging.EncoderParameters(1)
        Dim img2 As Bitmap
        Dim ImmaginePiccola22 As Image
        Dim jgpEncoder2 As Imaging.ImageCodecInfo
        Dim myEncoder2 As System.Drawing.Imaging.Encoder
        Dim myEncoderParameters2 As New Imaging.EncoderParameters(1)

        Try
            img2 = New Bitmap(Path)
            ImmaginePiccola22 = New Bitmap(img2, Val(Larghezza), Val(Altezza))
            img2.Dispose()
            img2 = Nothing

            myEncoder = System.Drawing.Imaging.Encoder.Quality
            jgpEncoder2 = GetEncoder(Imaging.ImageFormat.Jpeg)
            myEncoder2 = System.Drawing.Imaging.Encoder.Quality
            Dim myEncoderParameter2 As New Imaging.EncoderParameter(myEncoder, 97)
            myEncoderParameters2.Param(0) = myEncoderParameter2
            ImmaginePiccola22.Save(Path2, jgpEncoder2, myEncoderParameters2)

            ImmaginePiccola22.Dispose()

            ImmaginePiccola22 = Nothing
            jgpEncoder2 = Nothing
            myEncoderParameter2 = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Converte(ByVal inputImage As Image) As Image
        Dim outputBitmap As Bitmap = New Bitmap(inputImage.Width, inputImage.Height)
        Dim X As Long
        Dim Y As Long
        Dim currentBWColor As Color

        For X = 0 To outputBitmap.Width - 1
            For Y = 0 To outputBitmap.Height - 1
                currentBWColor = ConverteColore(DirectCast(inputImage, Bitmap).GetPixel(X, Y))
                outputBitmap.SetPixel(X, Y, currentBWColor)
            Next
        Next

        inputImage = Nothing
        Return outputBitmap
    End Function

    Private Function ConverteColore(ByVal InputColor As Color)
        'Dim eyeGrayScale As Integer = (InputColor.R * 0.3 + InputColor.G * 0.59 + InputColor.B * 0.11)
        Dim Rosso As Single = InputColor.R * 0.3
        Dim Verde As Single = InputColor.G * 0.59
        Dim Blu As Single = InputColor.B * 0.41
        Dim eyeGrayScale As Integer = (Rosso + Verde + Blu) ' * 1.7
        If eyeGrayScale > 255 Then eyeGrayScale = 255
        Dim outputColor As Color = Color.FromArgb(eyeGrayScale, eyeGrayScale, eyeGrayScale)

        Return outputColor
    End Function

    Private Function ConverteChiara(ByVal inputImage As Image) As Image
        Dim outputBitmap As Bitmap = New Bitmap(inputImage.Width, inputImage.Height)
        Dim X As Long
        Dim Y As Long
        Dim currentBWColor As Color

        For X = 0 To outputBitmap.Width - 1
            For Y = 0 To outputBitmap.Height - 1
                currentBWColor = ConverteColoreChiaro(DirectCast(inputImage, Bitmap).GetPixel(X, Y))
                outputBitmap.SetPixel(X, Y, currentBWColor)
            Next
        Next

        inputImage = Nothing
        Return outputBitmap
    End Function

    Private Function ConverteColoreChiaro(ByVal InputColor As Color)
        'Dim eyeGrayScale As Integer = (InputColor.R * 0.3 + InputColor.G * 0.59 + InputColor.B * 0.11)
        Dim Rosso As Single = InputColor.R * 0.49999999999999994
        Dim Verde As Single = InputColor.G * 0.49000000000000005
        Dim Blu As Single = InputColor.B * 0.49999999999999595
        Dim eyeGrayScale As Integer = (Rosso + Verde + Blu) '* 4.1000000000000005
        If eyeGrayScale > 250 Then eyeGrayScale = 250
        If eyeGrayScale < 185 Then eyeGrayScale = 185
        Dim outputColor As Color = Color.FromArgb(eyeGrayScale, eyeGrayScale, eyeGrayScale)

        Return outputColor
    End Function

    Private Function GetEncoder(ByVal format As Imaging.ImageFormat) As Imaging.ImageCodecInfo

        Dim codecs As Imaging.ImageCodecInfo() = Imaging.ImageCodecInfo.GetImageDecoders()

        Dim codec As Imaging.ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function

    Public Sub RidimensionaEArrotondaIcona(ByVal PercorsoImmagine As String)
        Dim bm As Bitmap
        Dim originalX As Integer
        Dim originalY As Integer

        'carica immagine originale
        bm = New Bitmap(PercorsoImmagine)

        originalX = bm.Width
        originalY = bm.Height

        Dim thumb As New Bitmap(originalX, originalY)
        Dim g As Graphics = Graphics.FromImage(thumb)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, originalX, originalY), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)

        Dim r As System.Drawing.Rectangle
        Dim s As System.Drawing.Size
        Dim coloreRosso As Pen = New Pen(Color.Red)
        coloreRosso.Width = 3

        For dimeX = originalX - 15 To originalX * 2
            r.X = (originalX / 2) - (dimeX / 2)
            r.Y = (originalY / 2) - (dimeX / 2)
            s.Width = dimeX
            s.Height = dimeX
            r.Size = s
            g.DrawEllipse(coloreRosso, r)
        Next

        Dim InizioY As Integer = -1
        Dim InizioX As Integer = -1
        Dim FineY As Integer = -1
        Dim FineX As Integer = -1
        Dim pixelColor As Color

        For i As Integer = 1 To originalX - 1
            For k As Integer = 1 To originalY - 1
                pixelColor = thumb.GetPixel(i, k)
                If pixelColor.ToArgb <> Color.Red.ToArgb Then
                    InizioX = i
                    'g.DrawLine(Pens.Black, i, 0, i, originalY)
                    Exit For
                End If
            Next
            If InizioX <> -1 Then
                Exit For
            End If
        Next

        For i As Integer = originalX - 1 To 1 Step -1
            For k As Integer = originalY - 1 To 1 Step -1
                pixelColor = thumb.GetPixel(i, k)
                If pixelColor.ToArgb <> Color.Red.ToArgb Then
                    FineX = i
                    'g.DrawLine(Pens.Black, i, 0, i, originalY)
                    Exit For
                End If
            Next
            If FineX <> -1 Then
                Exit For
            End If
        Next

        For i As Integer = 1 To originalY - 1
            For k As Integer = 1 To originalX - 1
                pixelColor = thumb.GetPixel(k, i)
                If pixelColor.ToArgb <> Color.Red.ToArgb Then
                    InizioY = i
                    'g.DrawLine(Pens.Black, 0, i, originalX, i)
                    Exit For
                End If
            Next
            If InizioY <> -1 Then
                Exit For
            End If
        Next

        For i As Integer = originalY - 1 To 1 Step -1
            For k As Integer = originalX - 1 To 1 Step -1
                pixelColor = thumb.GetPixel(k, i)
                If pixelColor.ToArgb <> Color.Red.ToArgb Then
                    FineY = i
                    'g.DrawLine(Pens.Black, 0, i, originalX, i)
                    Exit For
                End If
            Next
            If FineY <> -1 Then
                Exit For
            End If
        Next

        Dim nDimeX As Integer = FineX - InizioX
        Dim nDimeY As Integer = FineY - InizioY

        r.X = InizioX - 1
        r.Y = InizioY - 1
        r.Width = nDimeX + 1
        r.Height = nDimeY + 1

        Dim bmpAppoggio As Bitmap = New Bitmap(nDimeX, nDimeY)
        Dim g2 As Graphics = Graphics.FromImage(bmpAppoggio)

        g2.DrawImage(thumb, 0, 0, r, GraphicsUnit.Pixel)

        thumb = bmpAppoggio
        g2.Dispose()

        g.Dispose()

        thumb.MakeTransparent(Color.Red)

        thumb.Save(PercorsoImmagine & ".tsz", System.Drawing.Imaging.ImageFormat.Png)
        bm.Dispose()
        thumb.Dispose()

        Try
            Kill(PercorsoImmagine)
        Catch ex As Exception

        End Try

        Rename(PercorsoImmagine & ".tsz", PercorsoImmagine)
    End Sub

    Public Function RuotaFoto(Nome As String, Angolo As Single) As String
        Dim r As RotateFlipType

        Select Case Angolo
            Case 1
                r = RotateFlipType.RotateNoneFlipX
            Case 2
                r = RotateFlipType.RotateNoneFlipY
            Case 90
                r = RotateFlipType.Rotate90FlipNone
            Case -90
                r = RotateFlipType.Rotate270FlipNone
        End Select

        Dim bitmap1 As Bitmap = CType(Bitmap.FromFile(Nome), Bitmap)

        bitmap1.RotateFlip(r)
        bitmap1.Save(Nome & ".ruo", System.Drawing.Imaging.ImageFormat.Jpeg)
        bitmap1.Dispose()
        bitmap1 = Nothing

        Try
            Kill(Nome)

            Rename(Nome & ".ruo", Nome)

            Return "OK"
        Catch ex As Exception
            Return "ERRORE: " & ex.Message
        End Try
    End Function
End Class
