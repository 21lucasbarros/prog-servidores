<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PrjCalculadoraWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>O projeto</title>
</head>
<body>
    <section class="container">
        <div class="calculadora">
            <h1>Calculadora</h1>
            <form id="form1" runat="server">
                <div class="calculadora_div">
                    <asp:Label CssClass="calculadora_label" ID="lbParcelaA" runat="server"/>
                    <asp:TextBox ID="parcelaAInput" runat="server"></asp:TextBox>
                </div class="calculadora_div">
                <div class="calculadora_div">
                    <asp:Label CssClass="calculadora_label" ID="lbParcelaB" runat="server"/>
                    <asp:TextBox ID="parcelaBInput" runat="server"></asp:TextBox>
                </div>
                <div class="calculadora_div calculadora__campo_btn">
                    <asp:Button CssClass="calculadora_btn" ID="adicao" runat="server" Text="+" OnClick="btnClick" />
                    <asp:Button CssClass="calculadora_btn" ID="subtracao" runat="server" Text="-" OnClick="btnClick"/>
                    <asp:Button CssClass="calculadora_btn" ID="multiplicacao" runat="server" Text="*" OnClick="btnClick"/>
                    <asp:Button CssClass="calculadora_btn" ID="divisao" runat="server" Text="/" OnClick="btnClick"/>
                    <asp:Button CssClass="calculadora_btn" ID="raizQuadrada" runat="server" Text="SQR" OnClick="btnSqrtClick"/>
                    <asp:Button CssClass="calculadora_btn" ID="clear" runat="server" Text="clear" OnClick="btnClick"/>
                </div>
                <div class="calculadora_div">
                    <label>Resultado:</label>
                    <asp:TextBox ID="areaResultado" runat="server"/></asp:TextBox>
                    <div></div>
                </div>
            </form>
        </div>
    </section>
</body>
</html>"
<style>
    h1,
    p,
    label,
    div {
        color: #fff;
    }

    .container {
        display: flex;
        height: 100vh;
        width: 100%;
        justify-content: center;
        align-items: center;
        background: linear-gradient(to right, #fff, #aaa);
    }
    .calculadora {
        display: flex;
        flex-direction: column;
        padding: 1rem;
        border-radius: 20px;
        width: 65%;
        background: linear-gradient(to right, purple, cyan);
        justify-self: center;
        justify-content: center;
    }
    .container .calculadora form {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    .calculadora_div {
        display: flex;
        /* border: 1px solid #d79999;*/
        border-radius: 18px;
        padding: 1rem;
        gap: 1rem;
        align-items: center;
    }
    .calculadora_div label,
    .calculadora_div .calculadora_label {
        white-space: nowrap;
    }

    .calculadora_div.calculadora__campo_btn {
        display: flex;
        justify-content: center;
        text-align: center;
    }

    .calculadora_div .calculadora_btn {
        width: 10%;
        font-size: 12px;
        padding: 10px;
        border-radius: 20px;
        border: none;
    }
    .calculadora_div input {
        width: 100%;
        border-radius: 20px;
        border: none;
        font-size: 2rem;
    }
    .calculadora h1 {
        font-family: Arial;
        font-size: 28px;
        font-weight: 500;
        align-self: center;
    }
</style>
