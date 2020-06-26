<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Precios.aspx.cs" Inherits="Vistas.Precios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div>
        <h2>PRECIOS DE SALAS</h2>
        <asp:ListView runat="server" ID="lvSalas" DataSourceID="sqldssalas" GroupItemCount="2">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" style="">
                    <asp:Label Text='<%# Eval("Descripcion_TipoSala") %>' runat="server" ID="Descripcion_TipoSalaLabel" /><br />
                    <asp:Label Text='<%# Eval("Precio_FuncionxSala") %>' runat="server" ID="Precio_FuncionxSalaLabel" /><br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="groupPlaceholderContainer" style="" border="0">
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
        <asp:SqlDataSource runat="server" ID="sqldssalas" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spSalas" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
    <div>
        <h2>PRECIOS DE ARTÍCULOS</h2>
        <asp:ListView runat="server" ID="lvArticulos" DataSourceID="sqldsArticulos" GroupItemCount="3">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" style="">
                    <asp:Label Text='<%# Eval("Nombre_Articulo") %>' runat="server" ID="Nombre_ArticuloLabel" /><br />
                    <asp:ImageButton runat="server" ID="ibArt" ImageUrl='<%# Eval("URL_Articulo") %>' />
                    <asp:Label Text='<%# Eval("Descripción_Articulo") %>' runat="server" ID="Descripción_ArticuloLabel" /><br />
                    <asp:Label Text='<%# Eval("Precio") %>' runat="server" ID="PrecioLabel" /><br />
                       
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="groupPlaceholderContainer" style="" border="0">
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
        <asp:SqlDataSource runat="server" ID="sqldsArticulos" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spArticulos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
</asp:Content>
