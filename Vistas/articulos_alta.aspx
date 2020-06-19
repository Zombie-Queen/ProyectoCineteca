<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="articulos_alta.aspx.cs" Inherits="Vistas.articulos_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Alta.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
    <form id="form1" runat="server">
    <section class="registro">
            <h4>Agregar artículo</h4>
            <asp:TextBox Class="controles" runat="server" name="id" placeholder="Código"  ID="txt_id_articulo"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="estado" placeholder="Estado"  ID="txt_estado_articulo"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="nombre" placeholder="Nombre"  ID="txt_nombre_articulo"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="descripcion" placeholder="Descripción"  ID="txt_descripcion_art"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="precio" placeholder="Precio"  ID="txt_precio_art"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="url" placeholder="imagenes/articulos/nombre.jpg" ID="txt_url_articulo"></asp:TextBox>
            <asp:Button  ID="btnAgregar" runat="server" Text="Agregar" Class="botons" />
        </section>
        </form>
        </div>
</asp:Content>
