<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Funciones.aspx.cs" Inherits="Vistas.Funciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h2>FUNCIONES</h2>
    <asp:GridView ID="gvFunciones" runat="server" DataSourceID="sqldsfunciones" AutoGenerateColumns="False" CssClass="grid" OnSelectedIndexChanged="gvFunciones_SelectedIndexChanged" DataKeyNames="Fecha_FuncionxSala,Hora_Inicio_FuncionxSala,Precio_FuncionxSala,ID_Funcion_FuncionxSala,ID_Pelicula_FuncionxSala,ID_Sucursal_FuncionxSala,ID_Sala_FuncionxSala">
        <columns>
            <asp:TemplateField HeaderText="" >
                <ItemStyle CssClass="item-gv" />
                    <ItemTemplate>
                        <asp:Button Id="btnFunciones" runat="server" Text="Seleccionar" CssClass="btnfun" CommandName="Select" CommandArgument="<% ((GriViewRow)Container).RowIndex %>"/>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Fecha_FuncionxSala" HeaderText="Fecha" SortExpression="Fecha_FuncionxSala" DataFormatString="{0:d}">
<HeaderStyle CssClass="header-gv"></HeaderStyle>

<ItemStyle CssClass="item-gv"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Hora_Inicio_FuncionxSala" HeaderText="Horario" SortExpression="Hora_Inicio_FuncionxSala">
<HeaderStyle CssClass="header-gv"></HeaderStyle>

<ItemStyle CssClass="item-gv"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio_FuncionxSala" HeaderText="Precio" SortExpression="Precio_FuncionxSala" >
<HeaderStyle CssClass="header-gv"></HeaderStyle>

<ItemStyle CssClass="item-gv"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ID_Funcion_FuncionxSala" HeaderText="ID_Funcion" ReadOnly="True" SortExpression="ID_Funcion_FuncionxSala" Visible="False" />
            <asp:BoundField DataField="ID_Pelicula_FuncionxSala" HeaderText="ID_Pelicula" ReadOnly="True" SortExpression="ID_Pelicula_FuncionxSala" Visible="False" />
            <asp:BoundField DataField="ID_Sucursal_FuncionxSala" HeaderText="ID_Sucursal" ReadOnly="True" SortExpression="ID_Sucursal_FuncionxSala" Visible="False" />
            <asp:BoundField DataField="ID_Sala_FuncionxSala" HeaderText="ID_Sala" ReadOnly="True" SortExpression="ID_Sala_FuncionxSala" Visible="False" />
        </columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsfunciones" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="sp_Horarios_Fechas" SelectCommandType="StoredProcedure">
        <selectparameters>
            <asp:SessionParameter SessionField="ID_Sucursal" Name="ID_Sucursal" Type="String"></asp:SessionParameter>
            <asp:SessionParameter SessionField="ID_Pelicula" Name="ID_Pelicula" Type="String"></asp:SessionParameter>
        </selectparameters>
    </asp:SqlDataSource>
</asp:Content>
