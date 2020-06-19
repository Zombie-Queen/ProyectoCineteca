<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="ventas_DetalleDeVenta.aspx.cs" Inherits="Vistas.ventas_DetalleDeVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link rel="stylesheet" type="text/css" href="css/DetalleDeVenta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido-dv">
       <form id="form1" runat="server">
           <div class="filtro-v">
               <div class="item"><asp:TextBox  runat="server" placeholder="Número de venta" Class="input" ID="txt_num_venta"></asp:TextBox></div>                              
             <div class="btn-item">
                 <asp:Button ID="btnBuscar" runat="server" OnClick="Buscar_Click" Text="Buscar" Class="boton" /> 
                 <asp:Button ID="Volver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />   
            </div> 
           </div> 
           <div class="content-ventas">
               <div class="dventas">
                   <asp:GridView ID="grdDetalleVentas" runat="server" class="grid" >
                    <AlternatingRowStyle CssClass="alt" />
                           
        </asp:GridView>
                   <div class="totaldv">
                   <asp:GridView ID="grdTotalDv" runat="server" class="grid" >
                    <AlternatingRowStyle CssClass="alt" />
                           
        </asp:GridView>
               </div>              
               
           </div>
               
               <div class="dventas-a">
               <asp:GridView ID="grdDetalleVentas_a" runat="server" class="grid">
                    <AlternatingRowStyle CssClass="alt" />
                             
        </asp:GridView>
                   <div class="totaldv-a">
                       <asp:GridView ID="grdTotalDva" runat="server" class="grid" >
                    <AlternatingRowStyle CssClass="alt" />
                           
        </asp:GridView>
                   </div>
       
           </div>
                             
              <div class="total-venta">
                  <asp:GridView ID="grdTotalVenta" runat="server" class="grid" >
                    <AlternatingRowStyle CssClass="alt" />
                           
        </asp:GridView>

              </div>     
           </div>
           </form>
   </div>
</asp:Content>
