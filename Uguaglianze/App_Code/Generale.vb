Imports System.Globalization
Imports System.IO

Module Generale
    Public QuanteUguali As Integer
    Public QualeVisualizzataUguale As Integer
    Public UgualiSinistra() As String
    Public UgualiDestra() As String
    Public idSinistraUguali() As Long
    Public idDestraUguali() As Long
    Public idUguali() As Integer
    Public StatoImmagine() As Integer
    Public BloccaTuttoEdEsci As Boolean
    Public dimeSinistra() As Integer
    Public xSinistra() As Integer
    Public ySinistra() As Integer
    Public dimeDestra() As Integer
    Public xDestra() As Integer
    Public yDestra() As Integer
    Public Metodo() As String

    Public Function ControllaFestivo(Datella As Date) As Boolean
        Dim Ritorno As Boolean = False
        Dim Giorno As Integer = Datella.Day
        Dim Mese As Integer = Datella.Month

        Dim DataPasqua As Date = Pasqua(Datella.Year)
        Dim DatellaDopo As Date = DataPasqua.AddDays(1)
        Dim GiornoDopo As Integer = DatellaDopo.Day
        Dim Mesedopo As Integer = DatellaDopo.Month

        If Giorno = GiornoDopo And Mese = Mesedopo Then
            Ritorno = True
        Else
            If Datella.DayOfWeek = 0 Or Datella.DayOfWeek = 6 Then
                Ritorno = True
            Else
                If Giorno = 1 And Mese = 1 Then
                    Ritorno = True
                Else
                    If Giorno = 6 And Mese = 1 Then
                        Ritorno = True
                    Else
                        If Giorno = 25 And Mese = 4 Then
                            Ritorno = True
                        Else
                            If Giorno = 1 And Mese = 5 Then
                                Ritorno = True
                            Else
                                If Giorno = 2 And Mese = 6 Then
                                    Ritorno = True
                                Else
                                    If Giorno = 15 And Mese = 8 Then
                                        Ritorno = True
                                    Else
                                        If Giorno = 1 And Mese = 11 Then
                                            Ritorno = True
                                        Else
                                            If Giorno = 8 And Mese = 12 Then
                                                Ritorno = True
                                            Else
                                                If Giorno = 25 And Mese = 12 Then
                                                    Ritorno = True
                                                Else
                                                    If Giorno = 26 And Mese = 12 Then
                                                        Ritorno = True
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return Ritorno
    End Function

    Private Function Pasqua(Anno%) As Date
        Dim A%, b%, c%, p%, q%, R%
        Dim Pasq As Date

        A = Anno% Mod 19 : b = Anno% \ 100 : c = Anno% Mod 100
        p = (19 * A + b - (b / 4) - ((b + ((b + 8) \ 25) + 1) \ 3) + 15) Mod 30
        q = (32 + 2 * ((b Mod 4) + (c \ 4)) - p - (c Mod 4)) Mod 7
        R = (p + q - 7 * ((A + 11 * p + 22 * q) \ 451) + 114)
        Pasq = DateSerial(Anno%, R \ 31, (R Mod 31) + 1)

        Return Pasqua
    End Function

    Public Function MetteMaiuscoleDopoPunto(Cosa As String) As String
        Dim Ritorno As String = Cosa.ToLower.Trim

        If Ritorno <> "" Then
            If Asc(Mid(Ritorno, 1, 1)) >= Asc("a") And Asc(Mid(Ritorno, 1, 1)) <= Asc("z") Then
                Ritorno = Chr(Asc(Mid(Ritorno, 1, 1)) - 32) & Mid(Ritorno, 2, Len(Ritorno))
            End If
            Ritorno = Ritorno.Replace("  ", " ")
            Ritorno = Ritorno.Replace(". ", ".")
            For i As Integer = 2 To Len(Ritorno)
                If Mid(Ritorno, i, 1) = "." Then
                    If i + 1 < Ritorno.Length Then
                        If Asc(Mid(Ritorno, i + 1, 1)) >= Asc("a") And Asc(Mid(Ritorno, i + 1, 1)) <= Asc("z") Then
                            Ritorno = Mid(Ritorno, 1, i) & Chr(Asc(Mid(Ritorno, i + 1, 1)) - 32) & Mid(Ritorno, i + 2, Len(Ritorno))
                        End If
                    End If
                End If
            Next
            Ritorno = Ritorno.Replace(".", ". ")
        End If

        Return Ritorno
    End Function

    Public Function MetteMaiuscole(Cosa As String) As String
        Dim Ritorno As String = Cosa.ToLower.Trim

        If Ritorno <> "" Then
            If Asc(Mid(Ritorno, 1, 1)) >= Asc("a") And Asc(Mid(Ritorno, 1, 1)) <= Asc("z") Then
                Ritorno = Chr(Asc(Mid(Ritorno, 1, 1)) - 32) & Mid(Ritorno, 2, Len(Ritorno))
            End If
            Ritorno = Ritorno.Replace("  ", " ")
            For i As Integer = 2 To Len(Ritorno)
                If Mid(Ritorno, i, 1) = " " Or Mid(Ritorno, i, 1) = "-" Or Mid(Ritorno, i, 1) = "_" Then
                    If i + 1 <= Len(Ritorno) Then
                        If Asc(Mid(Ritorno, i + 1, 1)) >= Asc("a") And Asc(Mid(Ritorno, i + 1, 1)) <= Asc("z") Then
                            Ritorno = Mid(Ritorno, 1, i) & Chr(Asc(Mid(Ritorno, i + 1, 1)) - 32) & Mid(Ritorno, i + 2, Len(Ritorno))
                        End If
                    End If
                End If
            Next
        End If

        Return Ritorno
    End Function

    Public Function FormattaNumero(Numero As Single, ConVirgola As Boolean, Optional Lunghezza As Integer = -1) As String
        Dim Ritorno As String
        Dim Formattazione As String

        Select Case ConVirgola
            Case True
                Formattazione = "0,000.00"
            Case False
                Formattazione = "0,000"
            Case Else
                Formattazione = "0"
        End Select

        Ritorno = Numero.ToString(Formattazione, CultureInfo.InvariantCulture)

        Do While Left(Ritorno, 1) = "0"
            Ritorno = Mid(Ritorno, 2, Ritorno.Length)
        Loop
        If ConVirgola = True Then
            If Left(Ritorno.Trim, 1) = "." Then
                Ritorno = "0" & Ritorno
            End If
        Else
            If Left(Ritorno.Trim, 1) = "," Then
                Ritorno = Mid(Ritorno, 2, Ritorno.Length)
                For i As Integer = 1 To Ritorno.Length
                    If Mid(Ritorno, i, 1) = "0" Then
                        Ritorno = Mid(Ritorno, 1, i - 1) & "*" & Mid(Ritorno, i + 1, Ritorno.Length)
                    Else
                        Exit For
                    End If
                Next
                Ritorno = Ritorno.Replace("*", "")
                If Ritorno = "" Then Ritorno = "0"
            End If
        End If

        Ritorno = Ritorno.Replace(",", "+")
        Ritorno = Ritorno.Replace(".", ",")
        Ritorno = Ritorno.Replace("+", ".")

        If Ritorno = ".000" Then
            Ritorno = "0"
        End If

        If Lunghezza <> -1 Then
            Dim Spazi As String = ""

            If Ritorno.Length < Lunghezza Then
                For i As Integer = 1 To Lunghezza - Ritorno.Length
                    Spazi += " "
                Next
                Ritorno = Spazi & Ritorno
            End If
        Else
            Ritorno = Ritorno.Trim
        End If

        Return Ritorno
    End Function

    Public Function Cripta(ByVal Stringa As String) As String
        Dim PassMDB As String = Trim(Stringa)
        Dim VecchiaPass As String = ""

        Randomize()
        Dim Chiave As Integer = Int(Rnd(1) * 64)
        VecchiaPass = Chr(Chiave)
        For i = 1 To Len(PassMDB)
            VecchiaPass = VecchiaPass & Chr(Asc(Mid(PassMDB, i, 1)) + Chiave)
        Next

        Return VecchiaPass
    End Function

    Public Function Decripta(ByVal Stringa As String) As String
        Dim Appoggio As String = ""
        Dim Chiave As Integer

        Try
            Chiave = Asc(Left(Trim(Stringa), 1))
            For i = 2 To Len(Stringa)
                Appoggio = Appoggio & Chr(Asc(Mid(Stringa, i, 1)) - Chiave)
            Next
            Appoggio = Trim(Appoggio)
        Catch ex As Exception
            Appoggio = ""
        End Try

        Return Appoggio
    End Function

    Public Function SistemaTestoPerDB(Cosa As String) As String
        Dim Ritorno As String = Cosa

        Ritorno = Ritorno.Replace("'", "''")

        Return Ritorno
    End Function

    Public Function ConverteData(Datella As Date) As String
        Return Datella.Year & "-" & Format(Datella.Month, "00") & "-" & Format(Datella.Day, "00") & " " & Format(Datella.Hour, "00") & ":" & Format(Datella.Minute, "00") & ":" & Format(Datella.Second, "00") & ".000"
    End Function

End Module
