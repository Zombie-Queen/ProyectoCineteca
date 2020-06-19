<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vistas.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <asp:ListView ID="lvDatosCliente" runat="server" DataSourceID="sqldsDatosCliente" DataKeyNames="DNI_Cliente" GroupItemCount="3">
        <GroupTemplate>
            <tr runat="server" id="itemPlaceholderContainer">
                <td runat="server" id="itemPlaceholder"></td>
            </tr>
        </GroupTemplate>
        
        <ItemTemplate>
            <td runat="server">                
                Nombre:
                <asp:Label Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" /><br />
                Apellido:
                <asp:Label Text='<%# Eval("Apellido") %>' runat="server" ID="ApellidoLabel" /><br />                
                Fecha Nacimiento:
                <asp:Label Text='<%# Eval("Fecha_Nac") %>' runat="server" ID="Fecha_NacLabel" DataFormatString="{0:d}" /><br />
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
            <asp:SessionParameter SessionField="Contraseña" Name="Contraseña" Type="String"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
