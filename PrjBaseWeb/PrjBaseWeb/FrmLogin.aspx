<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="PrjCalculadoraWeb.FrmLogin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="inputs">
                    <asp:Label ID="lbLogin" runat="server" Text="Login" />
                    <asp:TextBox ID="txLogin" runat="server" />
                </div>
                <div class="inputs">
                    <asp:Label ID="lbSenha" runat="server" Text="Senha" />
                    <asp:TextBox ID="txSenha" runat="server" TextMode="Password" />
                </div>
                <asp:Button runat="server" Text="Ok" OnClick="Unnamed1_Click" />
                <asp:Label ID="lbMensage" runat="server" Text="" />
            </div>
        </div>
    </form>
</body>
</html>
