﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="Inicio_Admin.aspx.cs" Inherits="Vistas.Inicio_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/admin_inicio.css" />
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@500&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="principal">
        <a href="#" class="c-pelis">
            <div class="pelis">
                <!-- <asp:Label ID="lblMejoresPelis" runat="server">"!"</asp:Label> -->
                <h1 class="titulo">Top películas vendidas</h1>
                <asp:ListView ID="lvTopPelis" runat="server" DataSourceID="dsTopPeli">
                    <ItemTemplate>

                        <div class="labelSimple">
                            <asp:Label ID="Título_PeliculaLabel" runat="server" Text='<%# Eval("Título_Pelicula") %>' />
                        </div>
                        <!-- <div><asp:Label class="label-pelis" ID="Duración_PeliculaLabel" runat="server" Text='<%# Eval("Duración_Pelicula") %>' /> </div> -->
                        <td>
                            <asp:Image ID="peli_imagen" class="imagen-top" runat="server" ImageUrl='<%# Eval("URL_Portada") %>' />

                        </td>

                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>

                    </LayoutTemplate>

                </asp:ListView>
                <!-- <div class="detallesLink"><a href="#">Ver detalles</a></div> -->

                <asp:SqlDataSource ID="dsTopPeli" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_top3" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>
        <a href="#" class="c-pelis">
            <div class="MejorSucursal">
                <h1 class="titulo">Sucursal del mes: Junio</h1>
                <asp:ListView ID="lvSucuDelMes" runat="server" DataSourceID="dsMejorSucu">
                    <ItemTemplate>
                        <div class="labels">
                            <asp:Label ID="nombre_sucursal" runat="server" Text='<%# Eval("Nombre_Sucursal") %>' />
                        </div>
                        <div class="labels">
                            <asp:Label ID="Total_recaudacion" runat="server" Text='<%# Eval("Total") %>' />
                        </div>

                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>

                </asp:ListView>
                <asp:SqlDataSource ID="dsMejorSucu" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_mejorSucuJunio" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>

        <a href="#" class="c-pelis">
            <div class="Clientes">
                <h1 class="titulo">Clientes</h1>
                <asp:ListView ID="lvClientesActivos" runat="server" DataSourceID="dsClientes">

                    <ItemTemplate>
                        <div class="Cli">

                            <div class="labels">
                                <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("Estado") %>' />
                            </div>
                            <div class="labels">
                                <asp:Label ID="TotalLabel" runat="server" Text='<%# Eval("Total") %>' />
                            </div>

                        </div>


                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>


                </asp:ListView>
                <asp:SqlDataSource ID="dsClientes" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_ClientesActivos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <asp:ListView ID="lvClientesInsctivos" runat="server" DataSourceID="dsInactivos">

                    <ItemTemplate>
                        <div class="Cli">

                            <div class="labelsRojo">
                                <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("Estado") %>' />
                            </div>
                            <div class="labelsRojo">
                                <asp:Label ID="TotalLabel" runat="server" Text='<%# Eval("Total") %>' />
                            </div>

                        </div>


                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>


                </asp:ListView>
                <asp:SqlDataSource ID="dsInactivos" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_ClientesInactivos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>
        <a href="#" class="c-pelis">
            <div class="promo">
                <h1 class="titulo">Promoción del mes</h1>
                <asp:ListView ID="lvPromo" runat="server" DataSourceID="dsPromoDelMes">
                    <ItemTemplate>
                        <div class="labels" id="promo">
                            <asp:Label ID="promoMes" runat="server" Text='<%# Eval("[Promoción]") %>' />
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>

                </asp:ListView>
                <asp:SqlDataSource ID="dsPromoDelMes" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_mejorPromoJunio" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>
        <a href="#" class="c-pelis">
            <div class="Recaudacion">
                <h1 class="titulo">Recaudación diaria</h1>
                <asp:ListView ID="lvRecDiaria" runat="server" DataSourceID="ds_recDiaria">
                    <ItemTemplate>
                        <div class="labels" id="divRec">
                            <asp:Label ID="recDiaria" runat="server" Text='<%# Eval("[Recaudación diaria]") %>' />
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>

                </asp:ListView>
                <asp:SqlDataSource ID="ds_recDiaria" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_TotalVentaDiaria" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>
        <a href="#" class="c-pelis">
            <div class="Recaudacion">
                <h1 class="titulo">Recaudación mensual</h1>
                <asp:ListView ID="lvRecMensual" runat="server" DataSourceID="ds_recMensual">
                    <ItemTemplate>
                        <div class="labels" id="divRecM">
                            <asp:Label ID="recMensual" runat="server" Text='<%# Eval("[Recaudación mensual]") %>' />
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>

                </asp:ListView>
                <asp:SqlDataSource ID="ds_recMensual" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_TotalVentaMensual" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>
        <a href="#" class="c-pelis">
            <div class="Recaudacion">
                <h1 class="titulo">Recaudación anual</h1>
                <asp:ListView ID="lvRecAnual" runat="server" DataSourceID="ds_recAnual">
                    <ItemTemplate>
                        <div class="labels" id="divRecA">
                            <asp:Label ID="recAnual" runat="server" Text='<%# Eval("[Recaudación anual]") %>' />
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" class="item-temp">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>

                </asp:ListView>
                <asp:SqlDataSource ID="ds_recAnual" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_TotalVentaAnual" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
        </a>

    </div>

</asp:Content>
