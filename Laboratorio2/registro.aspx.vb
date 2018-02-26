Public Class registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCrearUsu_Click(sender As Object, e As EventArgs) Handles btnCrearUsu.Click

        Page.Validate()
        If Page.IsValid Then
            Dim accesoDatosSQL = New accesoDatosSQL.accesoDatosSQL
            Dim gestionEmail = New gestionEmail.gestionEmail
            Dim numConf As Integer = accesoDatosSQL.generarNumero()
            Dim tipo As String
            If rdbAlumno.Checked Then
                tipo = rdbAlumno.Text
            Else
                tipo = rdbProfesor.Text
            End If

            lblEmail.Text = accesoDatosSQL.insertar(txtEmail.Text,
                                    txtNombre.Text,
                                    txtApe1.Text,
                                    txtApe2.Text,
                                    numConf,
                                    tipo,
                                    txtContr1.Text)
            lblEmail.Visible = True
            If lblEmail.Text = "El registro se ha efectuado correctamente." Then
                lblValidar.Visible = True
                hprInicio.Visible = True

                Dim txtUrl As String = "http://hads13-18.azurewebsites.net/confirmar.aspx" + "?mbr=" + txtEmail.Text + "&numconf=" + numConf.ToString

                gestionEmail.verificarUsuario(txtEmail.Text, numConf, txtUrl)

            End If
        End If

    End Sub
End Class