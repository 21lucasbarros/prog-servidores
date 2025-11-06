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
                    <asp:DropDownList ID="comboCliente" runat="server" Width="220px" />
                </div>

                <div style="display:flex; flex-direction:row; gap:8px">
                    <asp:Label ID="lbFornecedor" runat="server" Text="Fornecedor" />
                    <asp:DropDownList ID="comboFornecedor" runat="server" Width="220px"
                        AutoPostBack="true" OnSelectedIndexChanged="comboFornecedor_SelectedIndexChanged" />
                </div>

                <div style="display:flex; flex-direction:row; gap:8px">
                    <asp:Label ID="lbProduto" runat="server" Text="Produto" />
                    <asp:DropDownList ID="comboProduto" runat="server" Width="220px" />
                </div>
            </section>
        </div>
    </form>
</body>
</html>
