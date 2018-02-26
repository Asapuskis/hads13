<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registro.aspx.vb" Inherits="Laboratorio2.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Registro de nuevo usuario:<br />
        Correo electrónico:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" EnableClientScript="False"></asp:RegularExpressionValidator>
        <br />
        Nombre: <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" EnableClientScript="False"></asp:RequiredFieldValidator>
        <br />
        Apellido1:
        <asp:TextBox ID="txtApe1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtApe1" ErrorMessage="*" EnableClientScript="False"></asp:RequiredFieldValidator>
        <br />
        Apellido2:
        <asp:TextBox ID="txtApe2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtApe2" ErrorMessage="*" EnableClientScript="False"></asp:RequiredFieldValidator>
        <br />
        Contraseña:
        <asp:TextBox ID="txtContr1" runat="server" TextMode="Password">asd</asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtContr1" EnableClientScript="False" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        Confirmar contraseña:
        <asp:TextBox ID="txtContr2" runat="server" TextMode="Password">asd</asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtContr2" ErrorMessage="*" EnableClientScript="False"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContr1" ControlToValidate="txtContr2" ErrorMessage="Las contraseñas no coinciden" EnableClientScript="False"></asp:CompareValidator>
        <br />
        Rol:
        <asp:RadioButton ID="rdbAlumno" runat="server" GroupName="grpRol" Text="Alumno" Checked="True" />
        <asp:RadioButton ID="rdbProfesor" runat="server" GroupName="grpRol" Text="Profesor" />
        <br />
        <br />
        <asp:Button ID="btnCrearUsu" runat="server" Text="Crear usuario" />
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblValidar" runat="server" Text="Se le enviará un correo para validar el usuario." Visible="False"></asp:Label>
        &nbsp;<br />
        <asp:HyperLink ID="hprInicio" runat="server" NavigateUrl="~/Inicio.aspx" Visible="False">Haga clic para volver a inicio</asp:HyperLink>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
