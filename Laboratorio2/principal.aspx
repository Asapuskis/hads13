<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="principal.aspx.vb" Inherits="Laboratorio2.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Ha iniciado sesión como: "></asp:Label>
        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        <br />
        <asp:HyperLink ID="hprLink" runat="server" NavigateUrl="~/Inicio.aspx">Volver a la página de inicio</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
