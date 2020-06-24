﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalledeCompra.aspx.cs" Inherits="Vistas.DetalledeCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="css/DetalleDeCompra.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 17%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
	<h1>Asientos</h1>
	<h3> 
			<asp:Image CssClass="imgasientos" ID="imgAsientos" runat="server"  ImageUrl="~/imagenes/asientos.jpg" ViewStateMode="Disabled"/>
	</h3>
    <p> 
			&nbsp;</p>
			<table class="w-100">
				<tr>
					<td style="font-family: 'Kanit', sans-serif; font-size: 14pt; text-align: left" class="auto-style1" >Seleccione su/s asiento/s: </td>
					<td><asp:DropDownList ID="ddlAsiento" runat="server" CssClass="ddla" DataSourceID="SqlDataSourceAsientosDisponibles" DataTextField="ID_Asiento" DataValueField="ID_Asiento">
			</asp:DropDownList>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="btnSeleccionar" runat="server" CssClass="btnddls" Text="Seleccionar" />
			
					</td>
				</tr>
			</table> 
	<h4>Asientos seleccionados:</h4>
	<asp:GridView ID="gvAsientos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" CssClass="gridas" DataSourceID="SqlDataSourceAsientosReservados">
					<Columns>
						<asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="ID_Asiento_FSA" HeaderText="ID Asiento" SortExpression="ID Asiento" >
<HeaderStyle CssClass="header-gv"></HeaderStyle>

<ItemStyle CssClass="item-gv"></ItemStyle>
						</asp:BoundField>
						</Columns>
				</asp:GridView>
	<br />
	<h1>Promociones</h1>
		<asp:ListView ID="lvPromociones" runat="server" DataKeyNames="ID_Promocion" DataSourceID="SqlDataSourcePromociones" GroupItemCount="5">
			<EditItemTemplate>
				<td runat="server" style="background-color:#008A8C;color: #FFFFFF;" aria-expanded="true" aria-selected="undefined">ID_Promocion:
					<asp:Label ID="ID_PromocionLabel1" runat="server" Text='<%# Eval("ID_Promocion") %>' />
					<br />Estado_Promocion:
					<asp:TextBox ID="Estado_PromocionTextBox" runat="server" Text='<%# Bind("Estado_Promocion") %>' />
					<br />Nombre_Promocion:
					<asp:TextBox ID="Nombre_PromocionTextBox" runat="server" Text='<%# Bind("Nombre_Promocion") %>' />
					<br />Descripcion_Promocion:
					<asp:TextBox ID="Descripcion_PromocionTextBox" runat="server" Text='<%# Bind("Descripcion_Promocion") %>' />
					<br />Descuento_Promocion:
					<asp:TextBox ID="Descuento_PromocionTextBox" runat="server" Text='<%# Bind("Descuento_Promocion") %>' />
					<br />Url_imagen:
					<asp:TextBox ID="Url_imagenTextBox" runat="server" Text='<%# Bind("Url_imagen") %>' />
					<br />
					<asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
					<br />
					<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
					<br /></td>
			</EditItemTemplate>
			<EmptyDataTemplate>
				<table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
					<tr>
						<td>No se han devuelto datos.</td>
					</tr>
				</table>
			</EmptyDataTemplate>
			<EmptyItemTemplate>
<td runat="server" />
			</EmptyItemTemplate>
			<GroupTemplate>
				<tr id="itemPlaceholderContainer" runat="server">
					<td id="itemPlaceholder" runat="server"></td>
				</tr>
			</GroupTemplate>
			<InsertItemTemplate>
				<td runat="server" style="">ID_Promocion:
					<asp:TextBox ID="ID_PromocionTextBox" runat="server" Text='<%# Bind("ID_Promocion") %>' />
					<br />Estado_Promocion:
					<asp:TextBox ID="Estado_PromocionTextBox0" runat="server" Text='<%# Bind("Estado_Promocion") %>' />
					<br />Nombre_Promocion:
					<asp:TextBox ID="Nombre_PromocionTextBox0" runat="server" Text='<%# Bind("Nombre_Promocion") %>' />
					<br />Descripcion_Promocion:
					<asp:TextBox ID="Descripcion_PromocionTextBox0" runat="server" Text='<%# Bind("Descripcion_Promocion") %>' />
					<br />Descuento_Promocion:
					<asp:TextBox ID="Descuento_PromocionTextBox0" runat="server" Text='<%# Bind("Descuento_Promocion") %>' />
					<br />Url_imagen:
					<asp:TextBox ID="Url_imagenTextBox0" runat="server" Text='<%# Bind("Url_imagen") %>' />
					<br />
					<asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
					<br />
					<asp:Button ID="CancelButton0" runat="server" CommandName="Cancel" Text="Borrar" />
					<br /></td>
			</InsertItemTemplate>
			<ItemTemplate>
				<td runat="server" style="background-color:#000000; color: white; text-align: center; font-size: small;">
					<asp:Label CssClass="lv-item1" ID="Nombre_PromocionLabel" runat="server" Text='<%# Eval("Nombre_Promocion") %>'/>
					<br />
					<asp:Label CssClass="lv-item2" ID="Descripcion_PromocionLabel" runat="server" Text='<%# Eval("Descripcion_Promocion") %>' />
					<br />
					<asp:Image CssClass="imgprom" ID="imgPromocion" runat="server" ImageUrl='<%# Eval("Url_imagen") %>' />
					<br />
					<br />
					<asp:TextBox ID="txtPromocion" runat="server" CssClass="txtpr"></asp:TextBox>
					<br />
					<asp:Button ID="btnValidar" runat="server" Text="Validar" CssClass="btnlvpr"/>
					<br /></td>
			</ItemTemplate>
			<LayoutTemplate>
				<table runat="server">
					<tr runat="server">
						<td runat="server">
							<table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
								<tr id="groupPlaceholder" runat="server">
								</tr>
							</table>
						</td>
					</tr>
					<tr runat="server">
						<td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
							<asp:DataPager ID="DataPager1" runat="server" PageSize="5">
								<Fields>
									<asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
									<asp:NumericPagerField />
									<asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
								</Fields>
							</asp:DataPager>
						</td>
					</tr>
				</table>
			</LayoutTemplate>
			<SelectedItemTemplate>
				<td runat="server" style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">ID_Promocion:
					<asp:Label ID="ID_PromocionLabel" runat="server" Text='<%# Eval("ID_Promocion") %>' />
					<br />Estado_Promocion:
					<asp:Label ID="Estado_PromocionLabel" runat="server" Text='<%# Eval("Estado_Promocion") %>' />
					<br />Nombre_Promocion:
					<asp:Label ID="Nombre_PromocionLabel0" runat="server" Text='<%# Eval("Nombre_Promocion") %>' />
					<br />Descripcion_Promocion:
					<asp:Label ID="Descripcion_PromocionLabel0" runat="server" Text='<%# Eval("Descripcion_Promocion") %>' />
					<br />Descuento_Promocion:
					<asp:Label ID="Descuento_PromocionLabel" runat="server" Text='<%# Eval("Descuento_Promocion") %>' />
					<br />Url_imagen:
					<asp:Label ID="Url_imagenLabel" runat="server" Text='<%# Eval("Url_imagen") %>' />
					<br /></td>
			</SelectedItemTemplate>
		</asp:ListView>
	<br />
	<h1>Candy</h1>
	<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID_Articulo" DataSourceID="SqlDataSourceArticulos" GroupItemCount="7">
		<EditItemTemplate>
			<td runat="server" style="background-color:#008A8C;color: #FFFFFF;">ID_Articulo:
				<asp:Label ID="ID_ArticuloLabel1" runat="server" Text='<%# Eval("ID_Articulo") %>' />
				<br />Estado_Articulo:
				<asp:TextBox ID="Estado_ArticuloTextBox" runat="server" Text='<%# Bind("Estado_Articulo") %>' />
				<br />Nombre_Articulo:
				<asp:TextBox ID="Nombre_ArticuloTextBox" runat="server" Text='<%# Bind("Nombre_Articulo") %>' />
				<br />Descripción_Articulo:
				<asp:TextBox ID="Descripción_ArticuloTextBox" runat="server" Text='<%# Bind("Descripción_Articulo") %>' />
				<br />Precio:
				<asp:TextBox ID="PrecioTextBox" runat="server" Text='<%# Bind("Precio") %>' />
				<br />URL_Articulo:
				<asp:TextBox ID="URL_ArticuloTextBox" runat="server" Text='<%# Bind("URL_Articulo") %>' />
				<br />
				<asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
				<br />
				<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
				<br /></td>
		</EditItemTemplate>
		<EmptyDataTemplate>
			<table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
				<tr>
					<td>No se han devuelto datos.</td>
				</tr>
			</table>
		</EmptyDataTemplate>
		<EmptyItemTemplate>
<td runat="server" />
		</EmptyItemTemplate>
		<GroupTemplate>
			<tr id="itemPlaceholderContainer" runat="server">
				<td id="itemPlaceholder" runat="server"></td>
			</tr>
		</GroupTemplate>
		<InsertItemTemplate>
			<td runat="server" style="">ID_Articulo:
				<asp:TextBox ID="ID_ArticuloTextBox" runat="server" Text='<%# Bind("ID_Articulo") %>' />
				<br />Estado_Articulo:
				<asp:TextBox ID="Estado_ArticuloTextBox" runat="server" Text='<%# Bind("Estado_Articulo") %>' />
				<br />Nombre_Articulo:
				<asp:TextBox ID="Nombre_ArticuloTextBox" runat="server" Text='<%# Bind("Nombre_Articulo") %>' />
				<br />Descripción_Articulo:
				<asp:TextBox ID="Descripción_ArticuloTextBox" runat="server" Text='<%# Bind("Descripción_Articulo") %>' />
				<br />Precio:
				<asp:TextBox ID="PrecioTextBox" runat="server" Text='<%# Bind("Precio") %>' />
				<br />URL_Articulo:
				<asp:TextBox ID="URL_ArticuloTextBox" runat="server" Text='<%# Bind("URL_Articulo") %>' />
				<br />
				<asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
				<br />
				<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
				<br /></td>
		</InsertItemTemplate>
		<ItemTemplate>
			<td runat="server" style="background-color:#000000; color: white; text-align: center; font-size: small;">
				<asp:Label CssClass="lv-item1" ID="Nombre_ArticuloLabel" runat="server" Text='<%# Eval("Nombre_Articulo") %>'></asp:Label>
				<br />
				<asp:Label CssClass="lv-item2" ID="Descripción_ArticuloLabel" runat="server" Text='<%# Eval("Descripción_Articulo") %>'></asp:Label>
				<br />
				Precio: $
				<asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>'></asp:Label>
				<br />
				<asp:Image CssClass="imgart" ID="Image2" runat="server" ImageUrl='<%# Eval("URL_Articulo") %>' />
				<br />
				<br />
				<asp:DropDownList ID="ddlcantidad" runat="server" CssClass="ddlart">
					<asp:ListItem Value="1"></asp:ListItem>
					<asp:ListItem Value="2"></asp:ListItem>
				</asp:DropDownList>
				<br />
				<asp:Button ID="btnAgregar0" runat="server" CssClass="btnlvart" Text="Agregar" />
				<br /></td>
		</ItemTemplate>
		<LayoutTemplate>
			<table runat="server">
				<tr runat="server">
					<td runat="server">
						<table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
							<tr id="groupPlaceholder" runat="server">
							</tr>
						</table>
					</td>
				</tr>
				<tr runat="server">
					<td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
						<asp:DataPager ID="DataPager1" runat="server" PageSize="7">
							<Fields>
								<asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
								<asp:NumericPagerField />
								<asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
							</Fields>
						</asp:DataPager>
					</td>
				</tr>
			</table>
		</LayoutTemplate>
		<SelectedItemTemplate>
			<td runat="server" style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">ID_Articulo:
				<asp:Label ID="ID_ArticuloLabel" runat="server" Text='<%# Eval("ID_Articulo") %>' />
				<br />Estado_Articulo:
				<asp:Label ID="Estado_ArticuloLabel" runat="server" Text='<%# Eval("Estado_Articulo") %>' />
				<br />Nombre_Articulo:
				<asp:Label ID="Nombre_ArticuloLabel" runat="server" Text='<%# Eval("Nombre_Articulo") %>' />
				<br />Descripción_Articulo:
				<asp:Label ID="Descripción_ArticuloLabel" runat="server" Text='<%# Eval("Descripción_Articulo") %>' />
				<br />Precio:
				<asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>' />
				<br />URL_Articulo:
				<asp:Label ID="URL_ArticuloLabel" runat="server" Text='<%# Eval("URL_Articulo") %>' />
				<br /></td>
		</SelectedItemTemplate>
	</asp:ListView>
	<br />
	<h4>Articulos seleccionados:</h4>
				<asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" CssClass="gridpr" DataSourceID="SqlDataSourceArticulosSeleccionados">
					<Columns>
						<asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Nombre_Articulo" HeaderText="Articulo" SortExpression="Articulo" >
						</asp:BoundField>
						<asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Descripción_Articulo" HeaderText="Descripción" SortExpression="Descripción" >
						</asp:BoundField>
						<asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" >
						</asp:BoundField>
						<asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio" HeaderText="Precio" SortExpression="Precio" >
						</asp:BoundField>
					</Columns>
				</asp:GridView>
			<br />
			<h3>
				<asp:Button ID="btnFinalizar" runat="server" CssClass="btn" Text="Finalizar Compra" />
				<asp:Button ID="btnCancelar" runat="server" CssClass="btn" Text="Cancelar" />
				</h3>
		<br />
	<asp:SqlDataSource ID="SqlDataSourceAsientosDisponibles" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="SP_AsientosDisponible" SelectCommandType="StoredProcedure">
		<SelectParameters>
			<asp:Parameter DefaultValue="0001" Name="Sala" Type="String" />
			<asp:Parameter DefaultValue="0001" Name="Sucursal" Type="String" />
			<asp:Parameter DefaultValue="m1thor" Name="Funcion" Type="String" />
			<asp:Parameter DbType="Date" DefaultValue="2020-06-10" Name="Fecha" />
		</SelectParameters>
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDataSourceAsientosReservados" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="SP_AsientosReservado" SelectCommandType="StoredProcedure">
		<SelectParameters>
			<asp:Parameter DefaultValue="Reservado" Name="Estado" Type="String" />
		</SelectParameters>
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDataSourceArticulos" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="SELECT * FROM [Articulos]"></asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDataSourceArticulosSeleccionados" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="SP_ArticulosSeleccionados" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDataSourcePromociones" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="SELECT * FROM [Promociones]"></asp:SqlDataSource>
	<br />
</asp:Content>
