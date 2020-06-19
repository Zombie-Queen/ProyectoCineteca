<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Sucursalunicenter.aspx.cs" Inherits="Vistas.Sucursalunicenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/diseñosucursales.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div id="contenedor-suc">
        <h1>Cineteca Unicenter</h1>
        <p id="direc">
            <strong>Dirección:</strong>&nbsp Paraná 3745, B1640FRB Martínez, Provincia de Buenos Aires
            <br />
            <br />
            Actualmente posee 8 salas con sonido y  proyección digital  en 2D, y 3D distribuidas en  dos edificios.
            Siempre apuesta a brindar a su público lo mejor del cine.
        </p>
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3287.3598089563984!2d-58.47521698505522!3d-34.51911096053271!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bcb1ba595d8d71%3A0x5c0b0664e1a59839!2sDOT!5e0!3m2!1ses-419!2sar!4v1592089130688!5m2!1ses-419!2sar" frameborder="0" style="border: 0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
    </div>
</asp:Content>
