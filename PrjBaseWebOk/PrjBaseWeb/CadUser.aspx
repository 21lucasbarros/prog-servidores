<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadUser.aspx.cs" Inherits="PrjCalculadoraWeb.CadUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Cadastro Usuários</h1>

            <div style="display: flex; flex-direction: row; gap: 10px; align-items: baseline;">
                <div style="display: flex; flex-direction: column; gap: 5px;">
                    <asp:Label ID="lbNome" runat="server" Text="Nome" />
                    <asp:TextBox ID="txNome" runat="server" />
                </div>
                <div style="display: flex; flex-direction: column; gap: 5px;">
                    <asp:Label ID="lbCPF" runat="server" Text="CPF" />
                    <asp:TextBox ID="txCPF" runat="server" />
                </div>
                <div style="display: flex; flex-direction: column; gap: 5px;">
                    <asp:Label ID="lbLogin" runat="server" Text="Login" />
                    <asp:TextBox ID="txLogin" runat="server" />
                </div>
                <div style="display: flex; flex-direction: column; gap: 5px;">
                    <asp:Label ID="lbPerfil" runat="server" Text="Perfil" />
                    <div style="display: flex; flex-direction: row; gap: 3px;">
                        <div style="display: flex; flex-direction: row; gap: 3px;">
                            <asp:RadioButton ID="rbADM" runat="server" GroupName="perfil" Text="ADM" />
                            <asp:RadioButton ID="rbUSU" runat="server" GroupName="perfil" Text="Usuario"/>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btOk" runat="server" Text="Ok" OnClick="btOk_Click" />

                <div style="flex-direction: column; gap: 5px;">
                    <asp:Button ID="btBusca" runat="server" Text="Buscar" OnClick="btBusca_Click" />
                    <asp:TextBox ID="txBusca" runat="server" />
                </div>
            </div>
            <div style="display: flex; flex-direction: column; gap: 10px">
                <asp:TextBox ID="txRelatorio" runat="server" 
                    TextMode="MultiLine"
                    ReadOnly="True" 
                    Font-Size="Large" 
                    Height="100px" 
                    Width="712px" 
                    style="resize: none; margin-top: 8px"
                />

                <asp:Label ID="lbMensagem" runat="server" Text="" />

                <asp:Button ID="btLimpar" runat="server" Text="Limpar" style="width: 80px;" OnClick="btLimpar_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
