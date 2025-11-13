<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPedido.aspx.cs" Inherits="PrjCalculadoraWeb.FrmPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section style="display:flex; flex-direction:column; gap:12px; width:350px">
                <asp:Label ID="lbTitulo" runat="server" Text="Pedidos de Depósito de Bebidas XPTO" Font-Bold="true" />

                <div style="display:flex; flex-direction:row; gap:8px">
                    <asp:Label ID="lbCliente" runat="server" Text="Cliente" />
                    <asp:DropDownList ID="comboCliente" runat="server" Width="220px" AutoPostBack="true" OnSelectedIndexChanged="comboCliente_SelectedIndexChanged" />
                </div>

                <div style="display:flex; flex-direction:row; gap:8px">
                    <asp:Label ID="lbFornecedor" runat="server" Text="Fornecedor" />
                    <asp:DropDownList ID="comboFornecedor" runat="server" Width="220px"
                        AutoPostBack="true" OnSelectedIndexChanged="comboFornecedor_SelectedIndexChanged" Enabled="false"/>
                </div>

                <div style="display:flex; flex-direction:row; gap:8px">
                    <asp:Label ID="lbProduto" runat="server" Text="Produto" />
                    <asp:DropDownList ID="comboProduto" runat="server" Width="220px" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="comboProduto_SelectedIndexChanged"/>
                </div>

                <div runat="server" id="divQuantidade" style="display: flex; flex-direction: column;" visible="false">
                    <asp:Label ID="lbQuantidade" runat="server" Text="Quantidade" />
                    <asp:TextBox ID="txQuantidade" runat="server" Width="200px" />
                    <asp:Button ID="btOk" runat="server" Text="OK" OnClick="btOk_Click" />
                </div>

                <div style="display: flex; flex-direction: row; gap: 35px">
                    <asp:Label ID="lbData" runat="server" Text="Data" />
                    <asp:Label ID="lbContato" runat="server" Text="Contato: " />
                    <asp:Label ID="lbSaldo" runat="server" Text="Saldo: " />
                </div>

                <div style="margin-top: 15px;">
                    <asp:TextBox 
                        ID="txtRelatorio" 
                        runat="server" 
                        TextMode="MultiLine" 
                        Rows="12" 
                        Columns="90"
                        ReadOnly="true"
                        Style="font-family: Consolas; font-size:14px; white-space:pre; width:100%;"
                        />
                </div>
            </section>
        </div>
    </form>
</body>
</html>
