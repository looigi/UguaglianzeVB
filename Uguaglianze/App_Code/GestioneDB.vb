Public Class GestioneDB

    Private NomeDB As String = "Db\Uguaglianze.mdb"
    Private ConnessioneSQL As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & NomeDB & ";Persist Security Info=False;"

    Public Sub Compactdb()
        ' RICORDARSI DI INCLUDERE LE JRO... 
        ' Microsoft Jet and Replication Objects 2.6 Library
        ' per la compattazione e...
        ' RICORDARSI CHE LA LIBRERIA FUNZIONA SOLO X86

        Dim JRO As JRO.JetEngine
        JRO = New JRO.JetEngine

        Dim source As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & NomeDB
        Dim compact As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB\Compactdb.mdb"

        Try
            JRO.CompactDatabase(source, compact)

            System.IO.File.Delete(NomeDB)

            System.IO.File.Move("DB\Compactdb.mdb", NomeDB)
        Catch ex As Exception

        End Try
    End Sub

    Public Function ProvaConnessione(Connessione As String) As String
        Dim Conn As Object = CreateObject("ADODB.Connection")

        Try
            Conn.Open(Connessione)
            Conn.Close()

            Conn = Nothing
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ApreDB() As Object
        ' Routine che apre il DB e vede se ci sono errori
        Dim Conn As Object = CreateObject("ADODB.Connection")

        Try
            Conn.Open(ConnessioneSQL)
            Conn.CommandTimeout = 0
        Catch ex As Exception
        End Try

        Return Conn
    End Function

    Private Function ControllaAperturaConnessione(ByRef Conn As Object) As Boolean
        Dim Ritorno As Boolean = False

        If Conn Is Nothing Then
            Ritorno = True
            Conn = ApreDB(ConnessioneSQL)
        End If

        Return Ritorno
    End Function

    Public Function EsegueSql(ByVal Conn As Object, ByVal Sql As String) As String
        Dim AperturaManuale As Boolean = ControllaAperturaConnessione(Conn)
        Dim Ritorno As String = ""

        ' Routine che esegue una query sul db
        Try
            Conn.Execute(Sql)
        Catch ex As Exception
            ' Stop
        End Try

        ChiudeDB(AperturaManuale, Conn)

        Return Ritorno
    End Function

    Public Function EsegueSqlSenzaTRY(ByVal Conn As Object, ByVal Sql As String) As String
        Dim AperturaManuale As Boolean = ControllaAperturaConnessione(Conn)
        Dim Ritorno As String = ""

        Conn.Execute(Sql)

        ChiudeDB(AperturaManuale, Conn)

        Return Ritorno
    End Function

    Private Sub ChiudeDB(ByVal TipoApertura As Boolean, ByRef Conn As Object)
        If TipoApertura = True Then
            Conn.Close()
        End If
    End Sub

    Public Function LeggeQuery(ByVal Conn As Object, ByVal Sql As String) As Object
        Dim AperturaManuale As Boolean = ControllaAperturaConnessione(Conn)
        Dim Rec As Object = CreateObject("ADODB.Recordset")

        Try
            Rec.Open(Sql, Conn, 1, 3, 1)
        Catch ex As Exception
        End Try

        ChiudeDB(AperturaManuale, Conn)

        Return Rec
    End Function
End Class
