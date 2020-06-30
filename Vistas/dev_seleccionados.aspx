<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="dev_seleccionados.aspx.cs" Inherits="Vistas.dev_seleccionados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link rel="stylesheet" type="text/css" href="css/DetalleDeVenta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
    
         
                <div class="filtro-sv">
             <div class="btn-item">
                 <asp:Button ID="btbVolver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />
                 <asp:Button ID="btnBorrar" runat="server" OnClick="Borrar_Click" Text="Dar de baja selección" Class="boton" />
                 
             </div>

           </div> 
            <div class="listado">
                <asp:GridView ID="grdDetallesSelect" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdDetallesSelect_PageIndexChanging" PageSize="5"  >
                    <AlternatingRowStyle CssClass="alt" />
                    </asp:GridView>
            </div>
        </div>
</asp:Content>
