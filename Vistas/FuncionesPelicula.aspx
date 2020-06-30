<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FuncionesPelicula.aspx.cs" Inherits="Vistas.FuncionesPelicula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
    <link rel="stylesheet" href="css/inicio.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="ddls justify-content-center">
        <asp:DropDownList CssClass="ddlsc mr-5" runat="server" ID="ddlSucs" AutoPostBack="true" OnSelectedIndexChanged="ddlSucs_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList CssClass="ddlsc" runat="server" ID="ddlSala" AutoPostBack="true"></asp:DropDownList>
    </div>
        <asp:GridView runat="server" ID="gvSuc" DataSourceID="sqldsFunciones" CssClass="grid" AutoGenerateColumns="False" AutoGenerateSelectButton="True">
            <Columns>                          
                <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Hora_Inicio_FuncionxSala" HeaderText="Hora de Inicio" SortExpression="Hora_Inicio_FuncionxSala"></asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Fecha_FuncionxSala" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha_FuncionxSala" DataFormatString="{0:d}"></asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio_FuncionxSala" HeaderText="Precio" SortExpression="Precio_FuncionxSala"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sqldsFunciones" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spSucursalesFuncion" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter SessionField="ID_Funcion" Name="ID_Pelicula" Type="String"></asp:SessionParameter>
                <asp:SessionParameter SessionField="ID_Suc" Name="ID_Sucursal" Type="String"></asp:SessionParameter>
                <asp:SessionParameter SessionField="ID_t_Sala" Name="ID_TipoSala" Type="Int32"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>    
    <!--<asp:Label runat="server" ID="lbl"></asp:Label>-->
</asp:Content>
