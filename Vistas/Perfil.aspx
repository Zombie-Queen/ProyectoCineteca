<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vistas.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/perfil.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="cont-perfil">
        <asp:Label ID="lbluser" runat="server"></asp:Label>
        <asp:Label ID="lblpass" runat="server"></asp:Label>
        <h2>TUS DATOS</h2>
        <asp:ListView ID="lvDatosCliente" runat="server" DataSourceID="sqldsDatosCliente" DataKeyNames="DNI_Cliente" GroupItemCount="1">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" class="items">Nombre:
                <asp:Label Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" /><br />
                    Apellido:
                <asp:Label Text='<%# Eval("Apellido") %>' runat="server" ID="ApellidoLabel" /><br />
                    Fecha Nacimiento:
                <asp:Label Text='<%# Eval("Fecha_Nac","{0:d}") %>' runat="server" ID="Fecha_NacLabel"/><br />
                    Correo:
                <asp:Label Text='<%# Eval("Correo") %>' runat="server" ID="CorreoLabel" /><br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="groupPlaceholderContainer" border="0">
                                <tr runat="server" id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource runat="server" ID="sqldsDatosCliente" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spVerificarUsuario" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter SessionField="Correo" DefaultValue="" Name="Correo" Type="String"></asp:SessionParameter>
                <asp:SessionParameter SessionField="Contrase&#241;a" Name="Contrase&#241;a" Type="String"></asp:SessionParameter>


            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button runat="server" ID="btnCambiarCorreo" Text="Cambiar Correo" CssClass="btn purple-gradient mt-5" />
        <asp:Button runat="server" ID="btnCambiarContraseña" Text="Cambiar Contraseña" CssClass="btn purple-gradient mt-5" />
    </div>
</asp:Content>
