Imports System.Net
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class gestionEmail
    Public Function modificarPass(ByVal email As String, ByVal numConf As Integer) As String
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("aaguayo001@ikasle.ehu.es", "Administración Laboratorio2")
            'Direccion de destino
            Dim to_address As New MailAddress(email)
            'Password de la cuenta
            Dim from_pass As String = "Darka8780"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.lg.ehu.es"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Añadimos el asunto
            message.Subject = "Modificar contraseña."
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "Para modificar la contraseña introduzca el siguiente código en la web. " + numConf.ToString + "</body></html>"
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return 0
        End Try
        Return 1
    End Function
    Public Function verificarUsuario(ByVal email As String, ByVal numConf As Integer, ByVal url As String) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("aaguayo001@ikasle.ehu.es", "Administración Laboratorio2")
            'Direccion de destino
            Dim to_address As New MailAddress(email)
            'Password de la cuenta
            Dim from_pass As String = "Darka8780"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.lg.ehu.es"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Registrar Usuario."
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>Para dar de alta el usuario, haga clic en el siguiente <a href='" + url + "'>enlace</a></body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return 0
        End Try
        Return 1
    End Function
    Public Shared Function generarNumero() As Integer
        Randomize()
        Dim NumConf As Integer = CLng(Rnd() * 900000) + 100000
        Return NumConf
    End Function
End Class
