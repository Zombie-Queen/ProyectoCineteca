<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="baja_detalle_ventasArts.aspx.cs" Inherits="Vistas.baja_detalle_ventasArts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link rel="stylesheet" type="text/css" href="css/DetalleDeVenta.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="contenido">
    
         
                <div class="filtro-cv">
               <div class="item"><asp:TextBox  runat="server" placeholder="Número de venta" Class="input" ID="txt_num_venta"></asp:TextBox>
                   <asp:RegularExpressionValidator ID="RegVenta" runat="server" ValidationGroup="busqueda" ControlToValidate="txt_num_venta" ValidationExpression="^[0-9]*$" Class="validator-rojo" Text="Ingrese solo números"></asp:RegularExpressionValidator>
                   <asp:RequiredFieldValidator ID="regCampos" runat="server" text="*Campo obligatorio para la busqueda." ControlToValidate="txt_num_venta" ValidationGroup="busqueda" Class="validator-rojo"></asp:RequiredFieldValidator>
               </div>
             <div class="btn-item">
                 <asp:Button ID="btnBuscar" runat="server" ValidationGroup="busqueda" OnClick="Buscar_Click" Text="Buscar" Class="boton" /> 
                 <asp:Button ID="btbVolver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />
                 <asp:Button ID="btnBorrar" runat="server" ValidationGroup="busqueda" OnClick="Borrar_Click" Text="Cancelar ventas" Class="boton" />
                 <asp:Button ID="BtnSeleccionados" runat="server" OnClick="Seleccion_Click" Text="Ver Selección" Class="boton" />
             </div>

           </div> 
            <div class="listado">
                <asp:GridView ID="grdDetVentaArt" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdDetVentas_PageIndexChanging" PageSize="5" AutoGenerateSelectButton="True" OnSelectedIndexChanging="grdDetVentaArt_SelectedIndexChanging" >
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        
                        <asp:TemplateField HeaderText="ID Venta">
                            <ItemTemplate>
                                <asp:Label ID="lbl_venta" runat="server" Text='<%# Bind("[ID Venta]") %>'></asp:Label>
                            </ItemTemplate>
                            
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Detalle">
                            <ItemTemplate>
                                <asp:Label ID="lbl_detalle_venta" runat="server" Text='<%# Bind("[ID Detalle]") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Artículo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_id_articulo" runat="server" Text='<%# Bind("[ID artículo]") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                                <asp:Label ID="lbl_cantidad" runat="server" Text='<%# Bind("[Cantidad]") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                                <asp:Label ID="lbl_precio" runat="server" Text='<%# Bind("[Precio]") %>'></asp:Label>
                            </ItemTemplate>
                            
                            
                        </asp:TemplateField>
                    
                    </Columns>

                              
        </asp:GridView>
            </div>
            
        
   
    </div>
</asp:Content>
