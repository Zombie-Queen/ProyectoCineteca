<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="peliculas_alta.aspx.cs" Inherits="Vistas.peliculas_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Alta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
    <form id="form1" runat="server">


        
        <section class="registro">
            <h4>Agregar película</h4>
            <asp:TextBox Class="controles" runat="server" name="id" placeholder="Título"  ID="txt_id_peli"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="estado" placeholder="Estado"  ID="txt_estado_peli"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="titulo" placeholder="Título"  ID="txt_titulo_peli"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="duracion" placeholder="Duración"  ID="txt_duracion_peli"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="clasif" placeholder="Calsificaci+on"  ID="txt_clasif_peli"></asp:TextBox>
            <asp:TextBox Class="controles" runat="server" name="url" placeholder="imagenes/peliculas/titulo.jpg" ID="txt_url_peli"></asp:TextBox>
            <asp:Button  ID="btnAgregar" runat="server" Text="Agregar" Class="botons" />
        </section>
        <div class="listaPelis">
                <asp:GridView ID="grdPelis" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdPelis_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="ID_Pelicula"/>
                    </Columns>          
        </asp:GridView>
            </div>
        


    </form>
    </div>
        
</asp:Content>
