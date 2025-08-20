<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PrjCalculadoraWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculadora Mil Grau</title>
</head>
<body>
    <section class="container">
        <div class="calculadora">
            <h1>Calculadora</h1>
            <form id="form1" runat="server">
                <div class="calculadora_div">
                    <asp:Label CssClass="calculadora_label" ID="lbParcelaA" runat="server"/>
                    <asp:TextBox ID="parcelaAInput" runat="server"></asp:TextBox>
                </div>
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
                    <asp:TextBox ID="areaResultado" runat="server"/>
                    <div></div>
                </div>
            </form>
        </div>
    </section>
</body>
</html>"
<style>
    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background: linear-gradient(160deg,rgba(27, 60, 83, 1) 16%, rgba(249, 243, 239, 1) 84%);
    }

    .container {
        display: flex;
        height: 100vh;
        width: 100%;
        justify-content: center;
        align-items: center;
        padding: 20px;
    }

    .calculadora {
        background: #ffffff;
        border-radius: 12px;
        padding: 32px;
        width: 100%;
        max-width: 400px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
        border: 1px solid #e0e0e0;
    }

    .calculadora h1 {
        color: #2c3e50;
        font-size: 24px;
        font-weight: 600;
        text-align: center;
        margin-bottom: 24px;
        letter-spacing: -0.5px;
    }

    .calculadora form {
        display: flex;
        flex-direction: column;
        gap: 16px;
    }

    .calculadora_div {
        display: flex;
        flex-direction: column;
        gap: 8px;
    }

    .calculadora_div label,
    .calculadora_label {
        color: #4a5568;
        font-size: 14px;
        font-weight: 500;
        margin-bottom: 4px;
    }

    .calculadora_div input {
        width: 100%;
        padding: 12px 16px;
        border: 1px solid #d1d5db;
        border-radius: 8px;
        font-size: 16px;
        transition: border-color 0.2s ease, box-shadow 0.2s ease;
        background-color: #ffffff;
    }

    .calculadora_div input:focus {
        outline: none;
        border-color: #4f46e5;
        box-shadow: 0 0 0 3px rgba(79, 70, 229, 0.1);
    }

    .calculadora__campo_btn {
        flex-direction: row !important;
        justify-content: center;
        gap: 8px;
        flex-wrap: wrap;
        margin: 8px 0;
    }

    .calculadora_btn {
        min-width: 48px;
        height: 48px;
        padding: 8px 12px;
        border: 1px solid #d1d5db;
        border-radius: 8px;
        background-color: #ffffff;
        color: #374151;
        font-size: 16px;
        font-weight: 500;
        cursor: pointer;
        transition: all 0.2s ease;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .calculadora_btn:hover {
        background-color: #f3f4f6;
        border-color: #9ca3af;
        transform: translateY(-1px);
    }

    .calculadora_btn:active {
        transform: translateY(0);
        box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
    }

    #clear {
        background-color: #ef4444;
        color: white;
        border-color: #ef4444;
    }

    #clear:hover {
        background-color: #dc2626;
        border-color: #dc2626;
    }

    #raizQuadrada {
        background-color: #10b981;
        color: white;
        border-color: #10b981;
        font-size: 12px;
    }

    #raizQuadrada:hover {
        background-color: #059669;
        border-color: #059669;
    }
</style>

