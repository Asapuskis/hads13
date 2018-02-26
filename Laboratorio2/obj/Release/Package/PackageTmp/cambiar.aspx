<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cambiar.aspx.vb" Inherits="Laboratorio2.cambiar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        ¿Olvidó su contraseña?<br />
        Introduzca su email para reestablecer la contraseña:
        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" EnableClientScript="False"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" EnableClientScript="False" ErrorMessage="Email incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btnEnviarEmail" runat="server" Text="Solicitud cambio contraseña" style="height: 26px" />
    
        <br />
        <br />
        <asp:Label ID="lblIntrod" runat="server" Text="Introduzca el código de 6 dígitos enviado al email introducido: " Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblCod" runat="server" Text="Código: " Visible="False"></asp:Label>
        <asp:TextBox ID="txtRespuesta" runat="server" Enabled="False" Visible="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqrdCodigo" runat="server" ControlToValidate="txtRespuesta" EnableClientScript="False" ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnComprResp" runat="server" Text="Comprobar Respuesta" Visible="False" />
        &nbsp;<asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblInt" runat="server" Text="Introduzca nueva contraseña:" Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="txtPass1" runat="server" TextMode="Password" Visible="False" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqrdPass1" runat="server" ControlToValidate="txtPass1" Enabled="False" ErrorMessage="*" EnableClientScript="False"></asp:RequiredFieldValidator>
        <br />
        <br />
&nbsp;<asp:Label ID="lblVerif" runat="server" Text="Verificar nueva contraseña:" Visible="False"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txtPass2" runat="server" TextMode="Password" Visible="False" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rqrdPass2" runat="server" ControlToValidate="txtPass2" Enabled="False" ErrorMessage="*" EnableClientScript="False"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmpPass" runat="server" ControlToCompare="txtPass1" ControlToValidate="txtPass2" Enabled="False" ErrorMessage="Las contraseñas no coinciden" EnableClientScript="False"></asp:CompareValidator>
        <br />
        <br />
        <asp:Button ID="btnEnviarPass" runat="server" Text="Modificar Contraseña" Visible="False" />
        <br />
        <br />
        <asp:Label ID="lblExito" runat="server" Visible="False"></asp:Label>
        <asp:HyperLink ID="hprInicio" runat="server" NavigateUrl="~/Inicio.aspx" Visible="False">Pulse aquí para volver al inicio.</asp:HyperLink>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
