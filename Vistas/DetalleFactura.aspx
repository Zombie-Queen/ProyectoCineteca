<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="Vistas.DetalleFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <asp:GridView runat="server" ID="gvDetalleFactura" AutoGenerateColumns="False" DataKeyNames="ID Venta,ID Detalle" DataSourceID="sqldsDetalleFactura">
        <Columns>            
            <asp:BoundField DataField="ID Detalle" HeaderText="ID Detalle" ReadOnly="True" InsertVisible="False" SortExpression="ID Detalle"></asp:BoundField>
            <asp:BoundField DataField="Funci&#243;n" HeaderText="Funci&#243;n" SortExpression="Funci&#243;n"></asp:BoundField>
            <asp:BoundField DataField="Pel&#237;cula" HeaderText="Pel&#237;cula" SortExpression="Pel&#237;cula"></asp:BoundField>
            <asp:BoundField DataField="Sala" HeaderText="Sala" SortExpression="Sala"></asp:BoundField>
            <asp:BoundField DataField="Asiento" HeaderText="Asiento" SortExpression="Asiento"></asp:BoundField>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha"></asp:BoundField>
            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsDetalleFactura" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="sp_detalleVenta_nv" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter SessionField="ID_Venta" Name="id" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
