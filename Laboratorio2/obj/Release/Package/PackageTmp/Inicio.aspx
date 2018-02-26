<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="Laboratorio2.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
    
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUsu" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsu" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsu" ErrorMessage="Formato de email incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        Contraseña:
        <asp:TextBox ID="txtContr" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContr" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" Text="Email o contraseña incorrecta." Visible="False"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/registro.aspx">Registrarse</asp:HyperLink>
&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/cambiar.aspx">Modificar contraseña</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
