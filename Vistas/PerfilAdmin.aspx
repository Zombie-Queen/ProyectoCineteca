﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="PerfilAdmin.aspx.cs" Inherits="Vistas.PerfilAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
        <asp:Label runat="server" ID="lblcorreo"></asp:Label>
        <asp:ListView runat="server" ID="lvPerfilAdmin" DataSourceID="sqldspAdmin" GroupItemCount="1">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" style="">
                    <asp:ImageButton runat="server" ID="imgPerfil" ImageUrl='<%# Eval("URL_fotoPerfil") %>' />
                    Nombre:
                <asp:Label Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" /><br />
                    Apellido:
                <asp:Label Text='<%# Eval("Apellido") %>' runat="server" ID="ApellidoLabel" /><br />
                    Fecha_Nac:
                <asp:Label Text='<%# Eval("Fecha_Nac") %>' runat="server" ID="Fecha_NacLabel" /><br />
                    Correo:
                <asp:Label Text='<%# Eval("Correo") %>' runat="server" ID="CorreoLabel" /><br />
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
        <asp:SqlDataSource runat="server" ID="sqldspAdmin" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spTraerAdmin" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter SessionField="Correo" Name="Correo" Type="String"></asp:SessionParameter>
                <asp:SessionParameter SessionField="Contrase&#241;a" Name="Contrase&#241;a" Type="String"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>