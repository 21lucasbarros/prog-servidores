<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="index.aspx.cs" 
    Inherits="PrjCalculadoraWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculadora</title>
    <style type="text/css">
        .auto-style1 {
            width: 365px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:70%; border:solid;">
                <tr>
                    <td>
                        &nbsp;
                    </td>               
                    <td colspan="2" style="text-align:center;">
                        <h1>Calculadora Da Moléstia</h1>
                    </td>                   
                
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lbParcelaA" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000"  />                        
                    </td>
                     <td style="text-align:center;">
                        <asp:TextBox ID="txtParcelaA" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000"  width="200px"/>
                     </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lbParcelaB" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000"  />                        
                    </td>
                     <td style="text-align:center;">
                        <asp:TextBox ID="txtParcelaB" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" width="200px"  />
                     </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                 <tr>
                    <td colspan="4" style="text-align:center;">
                         <table style="width:100%">
                             <tr>
                                 <td>
                                     &nbsp;
                                 </td>

                                 <td>
                                     <asp:Button ID="btMais" runat="server" Text="+" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000"  Width="50px"/>
                                 </td>

                                 <td>
                                     <asp:Button ID="btMenos" runat="server" Text="-" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" Width="50px"/>
                                 </td>

                                 <td>
                                     <asp:Button ID="btVezes" runat="server" Text="*" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" Width="50px"/>
                                 </td>

                                 <td>
                                     <asp:Button ID="btDividido" runat="server" Text="+" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" Width="50px"/>
                                 </td>

                                 <td>
                                     <asp:Button ID="brRaiz" runat="server" Text="SQT" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" Width="70px"/>
                                 </td>
                                 <td>
                                     <asp:Button ID="btCls" runat="server" Text="C" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" Width="50px" OnClick="btCls_Click"/>
                                 </td>
                                 <td>
                                     &nbsp;
                                 </td>
                             </tr>
                         </table>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
