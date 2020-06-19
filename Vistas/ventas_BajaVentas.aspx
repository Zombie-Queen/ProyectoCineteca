﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="ventas_BajaVentas.aspx.cs" Inherits="Vistas.ventas_modif_Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link rel="stylesheet" type="text/css" href="css/DetalleDeVenta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
    <form id="form1" runat="server">
         
                <div class="filtro-v">
               <div class="item"><asp:TextBox  runat="server" placeholder="Número de venta" Class="input" ID="txt_num_venta"></asp:TextBox></div>                              
             <div class="btn-item">
                 <asp:Button ID="btnBuscar" runat="server" OnClick="Buscar_Click" Text="Buscar" Class="boton" /> 
                 <asp:Button ID="btbVolver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />
                 <asp:Button ID="btnBorrar" runat="server" OnClick="Borrar_Click" Text="Cancelar venta" Class="boton" />   
            </div> 
           </div> 
            <div class="listado">
                <asp:GridView ID="grdVentas" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdVentas_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="ID_Venta"/>
                    </Columns>          
        </asp:GridView>
            </div>
            
        
    </form>
    </div>

</asp:Content>
