<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrjCalculadoraWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="display: flex; flex-direction: column; gap: 8px">
                <div style="display: flex; flex-direction: row; gap: 5px">
                    <asp:Label ID="lbUsuario" runat="server" Text="Usuario" />
                    <asp:TextBox ID="txUsuario" runat="server" />
                </div>

                <div style="display: flex; flex-direction: row; gap: 5px">
                    <asp:Label ID="lbSenha" runat="server" Text="Senha" />
                    <asp:TextBox ID="txSenha" runat="server" TextMode="Password" />
                </div>
            </div>
            <asp:Button ID="btOk" runat="server" Text="Ok" OnClick="btOk_Click" />
            <br />
            <br />
            <br />
            <div id="tbRecadastra" runat="server" visible="false" style="display: flex; flex-direction: column; gap: 8px;">
                <div>
                    <asp:Label ID="lbAviso" runat="server" Text="Primeiro acesso, define sua senha" />
                </div>
                <div style="display: flex; flex-direction: row; gap: 5px">
                    <asp:Label ID="lbSenhaA" runat="server" Text="Senha A" />
                    <asp:TextBox ID="txSenhaA" runat="server" TextMode="Password" />
                </div>
                <div style="display: flex; flex-direction: row; gap: 5px">
                    <asp:Label ID="lbSenhaB" runat="server" Text="Senha B" />
                    <asp:TextBox ID="txSenhaB" runat="server" TextMode="Password" />
                </div>
                <div>
                    <asp:Button ID="btOk2" runat="server" Text="Ok" OnClick="btOk2_Click" />
                </div>
            </div>
            <asp:Label ID="lbMensagem" runat="server" style="font-size:x-large"/>
        </div>
    </form>
</body>
</html>
