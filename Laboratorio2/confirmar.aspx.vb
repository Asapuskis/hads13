Imports System.Data.SqlClient

Public Class confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim accesoDatosSQL = New accesoDatosSQL.accesoDatosSQL
        Dim dataReader As SqlDataReader
        Dim email As String = Request.QueryString("mbr")
        Dim numconfstr As String = Request.QueryString("numconf")
        Dim numconf As Integer = CInt(numconfstr)
        'comprobacion verificacion correcta: El registro se ha efectuado con éxito

        If accesoDatosSQL.verificarNumero(email, numconf) Then 'Comprobar que el email y numero es correcto accesoDatosSQL.verificarNumero(email, numconf)
            accesoDatosSQL.confirmarUsuario(email)
            lblConf.Text = "El registro se ha efectuado con éxito."
        Else
            lblConf.Text = "Ha habido un error al verificar la cuenta."
        End If

    End Sub

End Class