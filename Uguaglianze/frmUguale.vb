Imports System.IO

Public Class frmUguale
    Private Sub frmUguale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblRitorno.Text = ""
    End Sub

    Public Sub ImpostaImmagini(Prima As String, Seconda As String, NuovoNome As String)
        Dim fs As System.IO.FileStream
        Dim gi As New GestioneImmagini
        Dim gf As New GestioneFilesDirectory

        If File.Exists(Prima) = True Then
            fs = New System.IO.FileStream(Prima,
             IO.FileMode.Open, IO.FileAccess.Read)
            PictureBox1.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()

            lblPrima.Text = gf.TornaNomeFileDaPath(Prima) & vbCrLf & FileLen(Prima) & vbCrLf & FileDateTime(Prima) & vbCrLf & gi.RitornaDimensioneImmagine(Prima)
        Else
            lblPrima.Text = ""
            'PictureBox1.Image.Dispose()
            'PictureBox1.Image = Nothing
        End If


        If File.Exists(Seconda) = True Then
            fs = New System.IO.FileStream(Seconda,
                 IO.FileMode.Open, IO.FileAccess.Read)
            PictureBox2.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            fs = Nothing

            lblSeconda.Text = gf.TornaNomeFileDaPath(Seconda) & vbCrLf & FileLen(Seconda) & vbCrLf & FileDateTime(Seconda) & vbCrLf & gi.RitornaDimensioneImmagine(Seconda)
        Else
            lblSeconda.Text = ""
            'PictureBox2.Image.Dispose()
            'PictureBox2.Image = Nothing
        End If

        txtNuovoNome.Text = gf.TornaNomeFileDaPath(NuovoNome)

        gf = Nothing
        gi = Nothing
    End Sub

    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        lblRitorno.Text = "0"
        Me.Hide()
    End Sub

    Private Sub cmdSovrascrivi_Click(sender As Object, e As EventArgs) Handles cmdSovrascrivi.Click
        lblRitorno.Text = "1"
        Me.Hide()
    End Sub

    Private Sub cmdRinomina_Click(sender As Object, e As EventArgs) Handles cmdRinomina.Click
        lblRitorno.Text = "2"
        Me.Hide()
    End Sub
End Class