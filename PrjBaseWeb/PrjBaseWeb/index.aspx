<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs"
Inherits="PrjBaseWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Clinica de Emagrecimento</title>
    <link href="estilo.css" rel="stylesheet" />
  </head>
  <body>
    <form runat="server">
      <div class="container">
        <h1>Clinica Emagrecimento</h1>

        <div class="form-group">
          <asp:Label
            ID="lbNome"
            runat="server"
            Text="Nome"
            AssociatedControlID="txNome"
          />
          <asp:TextBox ID="txNome" runat="server" />
          <asp:Label ID="lbErro" runat="server" ForeColor="Red" />
        </div>

        <div class="form-group">
          <asp:Label
            ID="lbCPF"
            runat="server"
            Text="CPF"
            AssociatedControlID="txCPF"
          />
          <asp:TextBox ID="txCPF" runat="server" />
          <asp:Label ID="lbErroCPF" runat="server" ForeColor="Red" />
        </div>

        <div class="form-group">
          <asp:Label
            ID="lbDAtaNascimento"
            runat="server"
            Text="Nascimento"
            AssociatedControlID="txDataNascimento"
          />
          <asp:TextBox ID="txDataNascimento" runat="server" />
          <asp:Label ID="lbErroDataN" runat="server" ForeColor="Red" />
        </div>

        <div class="form-group">
          <asp:Label ID="lbSexo" runat="server" Text="Sexo" />
          <span>
            <asp:RadioButton
              ID="rbFeminino"
              runat="server"
              GroupName="sex"
              Text="Feminino"
            />
          </span>
          <span>
            <asp:RadioButton
              ID="rbMasculino"
              runat="server"
              GroupName="sex"
              Text="Masculino"
            />
          </span>
          <span>
            <asp:RadioButton
              ID="rbOutro"
              runat="server"
              GroupName="sex"
              Text="Outro"
            />
          </span>
          <asp:Label ID="lbErroSexo" runat="server" ForeColor="Red" />
        </div>

        <div class="form-group">
          <asp:Label
            ID="lbPeso"
            runat="server"
            Text="Peso"
            AssociatedControlID="txPeso"
          />
          <asp:TextBox ID="txPeso" runat="server" />
          <asp:Label ID="lbErroPeso" runat="server" ForeColor="Red" />
        </div>

        <div class="form-group">
          <asp:Label
            ID="lbAltura"
            runat="server"
            Text="Altura"
            AssociatedControlID="txAltura"
          />
          <asp:TextBox ID="txAltura" runat="server" />
          <asp:Label ID="lbErroAltura" runat="server" ForeColor="Red" />
        </div>

        <div class="form-group-botoes">
          <asp:Button
            ID="Button1"
            runat="server"
            Text="Ok"
            OnClick="Button1_Click"
          />
          <asp:Button
            ID="Button2"
            runat="server"
            Text="Limpar"
            OnClick="Button2_Click"
            CausesValidation="false"
          />
        </div>

        <div class="form-group">
          <asp:Label
            ID="lbResultado"
            runat="server"
            Text="Resultado:"
            AssociatedControlID="txResultado"
          />
          <asp:TextBox ID="txResultado" ReadOnly="true" runat="server" />
        </div>
      </div>
    </form>
  </body>
</html>
