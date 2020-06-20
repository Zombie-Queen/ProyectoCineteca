<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="Vistas.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 283px;
            display:block;
            margin: 0 auto;
        }
        .auto-style5 {
            font-size: small;
        }
        .auto-style6 {
            font-size: x-small;
        }
        .auto-style7 {
            height: 47px;
        }
        .auto-style8 {
            width: 632px;
            display: block;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
            <br />
        <table class="auto-style8" >
            <tr>
                <td style="font-size: large">Tipo de tarjeta:</td>
                <td style="font-size: large">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="141px">
                        <asp:ListItem>Credito</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: large">Número</td>
                <td style="font-size: large">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="offset-sm-0" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: large">Código de seguridad:</td>
                <td style="font-size: large">
                    <asp:TextBox ID="TextBox5" runat="server" Width="121px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: large" class="auto-style7">Vencimiento:</td>
                <td style="font-size: large; vertical-align: super;" class="auto-style7">Mes:
                    <asp:DropDownList ID="DropDownList6" runat="server" Height="36px" Width="93px">
                        <asp:ListItem>01</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp; Año:
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="36px" Width="93px">
                        <asp:ListItem>2021</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: large">Nombre:</td>
                <td style="font-size: large">
                    <asp:TextBox ID="TextBox3" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-size: large">&nbsp;</td>
                <td style="font-size: large">&nbsp;</td>
            </tr>
            </table>
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="text-center">
                        <asp:Button ID="btnPagar" runat="server" CssClass="auto-style5" Text="Pagar" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" CssClass="auto-style5" Text="Cancelar" />
                    </td>
                </tr>
            </table>
            <br />
</asp:Content>
