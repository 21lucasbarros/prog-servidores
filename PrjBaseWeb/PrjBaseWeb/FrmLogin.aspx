<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs"
Inherits="PrjCalculadoraWeb.FrmLogin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Login</title>
    <link href="login.css" rel="stylesheet" />
  </head>
  <body>
    <div class="grid-background">
      <div class="grid-overlay"></div>
      <div class="blur blur1"></div>
      <div class="blur blur2"></div>
    </div>

    <form id="form1" runat="server">
      <div class="container">
        <h1>Login</h1>

        <div class="form-group">
          <asp:Label
            ID="lbLogin"
            runat="server"
            Text="Login"
            AssociatedControlID="txLogin"
          />
          <asp:TextBox ID="txLogin" runat="server" />
        </div>

        <div class="form-group">
          <asp:Label
            ID="lbSenha"
            runat="server"
            Text="Senha"
            AssociatedControlID="txSenha"
          />
          <asp:TextBox ID="txSenha" runat="server" TextMode="Password" />
        </div>

        <div class="form-group-botoes">
          <asp:Button runat="server" Text="Ok" OnClick="Unnamed1_Click" />
        </div>

        <asp:Label ID="lbMensage" runat="server" Text="" ForeColor="Red" />
      </div>
    </form>
  </body>
</html>
