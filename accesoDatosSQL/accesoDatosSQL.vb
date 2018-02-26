Imports System.Data.SqlClient

Public Class accesoDatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Public Shared Function conectar() As String
        Try
            'conexion.ConnectionString = “Server=tcp:practicahads.database.windows.net,1433;Initial Catalog=HADS00-TAREAS;Persist Security Info=False;User ID=Asier;Password=JAVadillo-2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.ConnectionString = "Server=tcp:hads13-2018.database.windows.net,1433;Initial Catalog=hads13;Persist Security Info=False;User ID=aaguayo001;Password=Patata123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            'conexion.ConnectionString = “Server=tcp: hads13.database.windows.net,1433;Initial Catalog=hads13;Persist Security Info=False;User ID=aassiieerr@hotmail.com@hads13;Password=Patata123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function
    Public Shared Function desconectar() As String
        Try
            conexion.Close()
        Catch ex As Exception
            Return "ERROR AL DESCONECTAR: " + ex.Message
        End Try
        Return "DESCONEXION OK"
    End Function
    Public Shared Function insertar(ByVal email As String,
                                    ByVal nombre As String,
                                    ByVal apellido1 As String,
                                    ByVal apellido2 As String,
                                    ByVal numconfir As Integer,
                                    ByVal tipo As String,
                                    ByVal pass As String) As String

        Dim apellidos As String = apellido1 + " " + apellido2
        Dim confirmado As Boolean = False

        If verificarEmail(email) Then
            Return "El email que desea introducir ya existe."
        End If

        comando = New SqlCommand("insertarUsuario", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("email", New SqlParameter).Value = email
        comando.Parameters.AddWithValue("nombre", New SqlParameter).Value = nombre
        comando.Parameters.AddWithValue("apellidos", New SqlParameter).Value = apellidos
        comando.Parameters.AddWithValue("numconfir", New SqlParameter).Value = numconfir
        comando.Parameters.AddWithValue("confirmado", New SqlParameter).Value = confirmado
        comando.Parameters.AddWithValue("tipo", New SqlParameter).Value = tipo
        comando.Parameters.AddWithValue("pass", New SqlParameter).Value = pass

        Dim numregs As Integer
        Try
            accesoDatosSQL.conectar()
            numregs = comando.ExecuteNonQuery()
            accesoDatosSQL.desconectar()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return ("El registro se ha efectuado correctamente.")
    End Function
    Public Shared Function generarNumero() As Integer
        Randomize()
        Dim NumConf As Integer = CLng(Rnd() * 9000000) + 1000000
        Return NumConf
    End Function
    Public Shared Function verificarNumero(ByVal email As String, ByVal numconf As Integer) As Boolean
        Dim numconfBD As Integer
        'comando = New SqlCommand("verificarNumero", conexion)
        'comando.CommandType = CommandType.StoredProcedure
        'comando.Parameters.AddWithValue("email", New SqlParameter).Value = email

        'comando = New SqlCommand("selectUsuarios", conexion)
        'comando.CommandType = CommandType.StoredProcedure
        Dim DR As SqlDataReader
        Try

            accesoDatosSQL.conectar()
            Dim st = "SELECT numconfir FROM [Usuarios] WHERE email = '" + email + "';"
            comando = New SqlCommand(st, conexion)
            DR = comando.ExecuteReader
            DR.Read()

            If DR.HasRows Then
                numconfBD = DR(0)
            End If

            accesoDatosSQL.desconectar()
            If numconfBD = numconf Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Shared Function confirmarUsuario(ByVal email As String) As Boolean

        accesoDatosSQL.conectar()

        Dim st = "update Usuarios set Confirmado =  1 where email = '" + email + "'"
        comando = New SqlCommand(st, conexion)

        Dim numregs As Integer
        Try
            accesoDatosSQL.conectar()
            numregs = comando.ExecuteNonQuery()
            accesoDatosSQL.desconectar()

        Catch ex As Exception
            Return 0
        End Try
        Return 1
    End Function

    Public Shared Function cambiarPass(ByVal email As String, ByVal pass As String) As Boolean

        accesoDatosSQL.conectar()

        Dim st = "update Usuarios set Pass =  '" + pass + "' where email = '" + email + "'"
        comando = New SqlCommand(st, conexion)

        Dim numregs As Integer
        Try
            accesoDatosSQL.conectar()
            numregs = comando.ExecuteNonQuery()
            accesoDatosSQL.desconectar()

        Catch ex As Exception
            Return 0
        End Try
        Return 1
    End Function

    Public Shared Function verificarEmail(ByVal email As String)

        accesoDatosSQL.conectar()

        'if rows = 0, no existe el email, devuelvo 1. else devuelvo 0

        Dim dr As SqlDataReader
        Dim st = "select * from Usuarios where email = '" + email + "'"
        comando = New SqlCommand(st, conexion)

        Try
            accesoDatosSQL.conectar()
            dr = comando.ExecuteReader()
            dr.Read()

            If dr.HasRows Then
                accesoDatosSQL.desconectar()
                Return 1
            End If

            accesoDatosSQL.desconectar()

        Catch ex As Exception
            accesoDatosSQL.desconectar()
            Return ex.Message
        End Try
        Return 0
    End Function
    Public Shared Function iniciarSesion(ByVal email As String, ByVal pass As String)

        Dim dr As SqlDataReader
        Dim st = "select * from Usuarios where email = '" + email + "' and pass = '" + pass + "'"
        comando = New SqlCommand(st, conexion)

        Try
            accesoDatosSQL.conectar()
            dr = comando.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                accesoDatosSQL.desconectar()
                Return 1
            End If
            accesoDatosSQL.desconectar()
        Catch ex As Exception
            accesoDatosSQL.desconectar()
            Return ex.Message
        End Try
        Return 0
    End Function
End Class
