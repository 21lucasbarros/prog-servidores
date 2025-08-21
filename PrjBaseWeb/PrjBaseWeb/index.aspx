<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="index.aspx.cs" 
    Inherits="PrjBaseWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clinica de Emagrecimento</title>
</head>
<body>
    <link href="estilo.css" rel="stylesheet" />
    <form runat="server">
        <div style="width: 600px;">
            <h1>Clinica Emagrecimento</h1>
            <div/>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Label ID="lbNome" runat="server" Text="Nome"></asp:Label>
                <asp:TextBox ID="txNome" runat="server"></asp:TextBox>
                <asp:Label ID="lbErro" runat="server" ForeColor="Red" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Label ID="lbCPF" runat="server" Text="CPF"></asp:Label>
                <asp:TextBox ID="txCPF" runat="server"></asp:TextBox>
                <asp:Label ID="lbErroCPF" runat="server" ForeColor="Red" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Label ID="lbDAtaNascimento" runat="server" Text="Nascimento"></asp:Label>
                <asp:TextBox ID="txDataNascimento" runat="server"></asp:TextBox>
                <asp:Label ID="lbErroDataN" runat="server" ForeColor="Red" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; text-align: center">
                <asp:Label ID="lbSexo" runat="server" Text="Sexo"></asp:Label>
                <span>
                    <asp:RadioButton ID="rbFeminino" runat="server" GroupName="sex" Text="Feminino"/>
                </span>
                <span>
                    <asp:RadioButton ID="rbMasculino" runat="server" GroupName="sex" Text="Masculino"/>
                </span>
                <span>
                    <asp:RadioButton ID="rbOutro" runat="server" GroupName="sex" Text="Outro"/>
                </span>
                <asp:Label ID="lbErroSexo" runat="server" ForeColor="Red" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Label ID="lbPeso" runat="server" Text="Peso"></asp:Label>
                <asp:TextBox ID="txPeso" runat="server"></asp:TextBox>
                <asp:Label ID="lbErroPeso" runat="server" ForeColor="Red" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Label ID="lbAltura" runat="server" Text="Altura"></asp:Label>
                <asp:TextBox ID="txAltura" runat="server"></asp:TextBox>
                <asp:Label ID="lbErroAltura" runat="server" ForeColor="Red" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Limpar" OnClick="Button2_Click" />
            </div>

            <div style="display: flex; flex-direction: row; gap: 10px; align-self: baseline">
                <asp:Label ID="lbResultado" runat="server" Text="Resultado:" />
                <asp:TextBox ID="txResultado" ReadOnly="true" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
