<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Funciones.aspx.cs" Inherits="Vistas.Funciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h2>FUNCIONES</h2>
    <asp:GridView ID="gvFunciones" runat="server" DataSourceID="sqldsfunciones" AutoGenerateColumns="False" CssClass="grid" AutoGenerateSelectButton="True">
        <columns>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Fecha_FuncionxSala" HeaderText="Fecha" SortExpression="Fecha_FuncionxSala" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Hora_Inicio_FuncionxSala" HeaderText="Horario" SortExpression="Hora_Inicio_FuncionxSala"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio_FuncionxSala" HeaderText="Precio" SortExpression="Precio_FuncionxSala" />
        </columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsfunciones" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="sp_Horarios_Fechas" SelectCommandType="StoredProcedure">
        <selectparameters>
            <asp:SessionParameter SessionField="ID_Sucursal" Name="ID_Sucursal" Type="String"></asp:SessionParameter>
            <asp:SessionParameter SessionField="ID_Pelicula" Name="ID_Pelicula" Type="String"></asp:SessionParameter>
        </selectparameters>
    </asp:SqlDataSource>
</asp:Content>
