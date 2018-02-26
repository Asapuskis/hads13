Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Page.Validate()
        If Page.IsValid Then
            Dim accesoDatosSQL = New accesoDatosSQL.accesoDatosSQL
            If accesoDatosSQL.iniciarSesion(txtUsu.Text, txtContr.Text) Then
                Session("usuario") = txtUsu.Text
                Response.Redirect("principal.aspx", True)
                lblError.Visible = False
            Else
                lblError.Visible = True
            End If
        End If

    End Sub
End Class