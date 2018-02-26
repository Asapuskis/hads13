Public Class cambiar
    Inherits System.Web.UI.Page
    Private codigoConfirmacion As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        codigoConfirmacion = ViewState("codigoConf")
    End Sub

    Protected Sub btnEnviarEmail_Click(sender As Object, e As EventArgs) Handles btnEnviarEmail.Click

        Page.Validate()
        If Page.IsValid Then
            Dim gestionEmail = New gestionEmail.gestionEmail
            Dim accesoSQL = New accesoDatosSQL.accesoDatosSQL
            Dim email As String = txtEmail.Text

            codigoConfirmacion = gestionEmail.generarNumero()

            ViewState("codigoConf") = codigoConfirmacion

            If accesoSQL.verificarEmail(email) Then 'comprobar que existe el email.
                If gestionEmail.modificarPass(email, codigoConfirmacion) Then
                    rqrdCodigo.Enabled = True
                    txtRespuesta.Enabled = True
                    lblIntrod.Visible = True
                    lblCod.Visible = True
                    txtRespuesta.Visible = True
                    btnComprResp.Visible = True
                    lblError.Visible = False
                Else
                    lblError.Text = "Ha ocurrido un error al enviar el email."
                End If
            Else
                lblError.Text = "El email que ha introducido no existe."
            End If
        End If

    End Sub

    Protected Sub btnComprResp_Click(sender As Object, e As EventArgs) Handles btnComprResp.Click

        Page.Validate()
        If Page.IsValid Then
            Dim codigoTxt As String = txtRespuesta.Text
            If codigoConfirmacion = CInt(codigoTxt) Then
                lblInt.Visible = True
                lblVerif.Visible = True
                txtPass1.Visible = True
                txtPass2.Visible = True
                btnEnviarPass.Visible = True
                rqrdPass1.Enabled = True
                rqrdPass2.Enabled = True
                cmpPass.Enabled = True
            End If
        End If

    End Sub

    Protected Sub btnEnviarPass_Click(sender As Object, e As EventArgs) Handles btnEnviarPass.Click

        Page.Validate()
        If Page.IsValid Then
            Dim accesoDatosSQL = New accesoDatosSQL.accesoDatosSQL
            If accesoDatosSQL.cambiarPass(txtEmail.Text, txtPass1.Text) Then
                lblExito.Text = "Se ha modificado correctamente la contraseña."
                lblExito.Visible = True
                hprInicio.Visible = True
            Else
                lblExito.Text = "Ha habido un problema modificando la contraseña."
                lblExito.Visible = True
                hprInicio.Visible = True
            End If
        End If

    End Sub
End Class