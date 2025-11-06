<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="PrjFaturamento.Default" %>

<!DOCTYPE html>
<link href="estilo.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 136px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="border: solid; border-width: 1px;">
                <tr>
                    <td>
                        <asp:Label ID="lbLogin" runat="server" Text="Login" />
                    </td>
                    <td>
                        <asp:TextBox ID="txLogin" runat="server" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbSenha" runat="server" Text="Senha" />
                    </td>
                    <td>
                        <asp:TextBox ID="txSenha"
                            runat="server" Width="100px"
                            TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btOk" runat="server" Text="Ok" Width="150px" OnClick="btOk_Click" />
                    </td>
                </tr>
            </table>
            <p />
            <p />
            <table runat="server" id="tbRecadastra" visible="false" style="border: solid; border-width: 1px;">

                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lbAviso" runat="server" Text="Primeiro Acesso, defina sua senha" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbSenhaA" runat="server" Text="Senha A" />
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txSenhaA"
                            runat="server" Width="100px"
                            TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbSenhaB" runat="server" Text="Senha B" />
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txSenhaB"
                            runat="server" Width="100px"
                            TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btOk2" runat="server" Text="Ok" Width="150px" OnClick="btOk2_Click" />
                    </td>
                </tr>

            </table>
            <p />
            <p />
            <table runat="server" id="tablePerfil" visible="false" style="border: solid; border-width: 1px;">

                <tr>
                    <th>
                        <a href="CadUser.aspx">Cadastro de Usuário</a>
                    </th>
                </tr>
                <tr>
                    <th>
                        <a href="FrmPedido.aspx">Pedido de Bebidas</a>
                    </th>
                </tr>

            </table>
            <asp:Label ID="lbMensagem" runat="server" Style="font-size: x-large" />
        </div>
    </form>
</body>
</html>
