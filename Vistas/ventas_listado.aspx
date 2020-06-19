<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="ventas_listado.aspx.cs" Inherits="Vistas.ventas_listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="contenido">
    <form id="form1" runat="server">
         
        <div class="filtros">

             
             <div class="item"><asp:TextBox  runat="server" placeholder="Dni" Class="input" ID="txt_dni"></asp:TextBox></div>           
             <div class="item"><asp:TextBox runat="server" placeholder="Número de venta" class="input" ID="txt_venta"></asp:TextBox></div> 
            <div class="item"><asp:TextBox  runat="server" type="date" class="input" ID="txt_fecha">    </asp:TextBox></div>
             <div class="btn-item">
                 <asp:Button ID="btnFiltrar" runat="server" OnClick="Filtrar_Click" Text="Filtrar" Class="boton" />
                 <asp:Button ID="btnQuitarFiltro" runat="server" OnClick="Reset_Click" Text="Mostrar todas" Class="boton" />
            </div> 
                
            
        </div>

            <div class="listado">
                <asp:GridView ID="grdVentas" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdVentas_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="ID_Venta" DataNavigateUrlFormatString="#" Text="Ver detalle"/>
                    </Columns>          
        </asp:GridView>
            </div>
            
        
    </form>
    </div>

</asp:Content>
