<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vistas.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/registro.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="form w-50">
        <h2 class="subt">REGISTRARSE</h2>
        <div class="form-row mb-4">
            <div class="col d-flex">
                <asp:TextBox runat="server" ID="nombre" placeholder="Nombre" CssClass="form-control mr-2"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="red-text msgerror" ID="rfNombre" ControlToValidate="nombre" Text="*" ValidationGroup="reg"></asp:RequiredFieldValidator>
            </div>
            <div class="col d-flex">
                <asp:TextBox runat="server" CssClass="form-control mr-2" placeholder="Apellido" ID="ape"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfApe" ControlToValidate="ape" CssClass="red-text msgerror" Text="*" ValidationGroup="reg"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="d-flex mb-4">
            <asp:TextBox placeholder="DNI" runat="server" CssClass="form-control mr-2" ID="dni"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfdni" CssClass="red-text msgerror" Text="*" ValidationGroup="reg" ControlToValidate="dni"></asp:RequiredFieldValidator>
        </div>
        <div class="d-flex mb-4">
            <asp:TextBox placeholder="Contraseña" runat="server" ID="contra" TextMode="Password" CssClass="form-control mr-2"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfContraseñareg" ControlToValidate="contra" ValidationGroup="reg" CssClass="red-text msgerror" Text="*"></asp:RequiredFieldValidator>
        </div>
        <div class="d-flex">
            <asp:TextBox placeholder="Repita Contraseña" runat="server" ID="contrarepeat" TextMode="Password" CssClass="form-control mr-2"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcontrasiguales" CssClass="red-text msgerror" ControlToValidate="contrarepeat" Text="*" ValidationGroup="reg"></asp:RequiredFieldValidator>
        </div>
        <asp:CompareValidator runat="server" ID="contrasiguales" CssClass="red-text" ValidationGroup="reg" Text="Las contraseñas deben coincidir." ControlToCompare="contra" ControlToValidate="contrarepeat"></asp:CompareValidator>
        <div class="d-flex">
            <asp:TextBox placeholder="Correo Electrónico" runat="server" ID="email" CssClass="form-control mr-2"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcorreoReg" ControlToValidate="email" CssClass="red-text msgerror" ValidationGroup="reg" Text="*"></asp:RequiredFieldValidator>
        </div>
        <asp:RegularExpressionValidator runat="server" CssClass="red-text" ID="recorreoReg" ValidationGroup="reg" ControlToValidate="email" Text="Ingrese un correo válido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <div class="d-flex mb-3">
            <asp:TextBox placeholder="Fecha de Nacimiento" runat="server" ID="fecha" CssClass="form-control mr-2" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfFecha" CssClass="red-text msgerror" ValidationGroup="reg" ControlToValidate="fecha" Text="*"></asp:RequiredFieldValidator>
        </div>
        <asp:ValidationSummary runat="server" ID="vsReg" HeaderText="Complete los campos requeridos (*)" CssClass="red-text" ValidationGroup="reg" />
        <div class="d-flex justify-content-center align-items-center">
            <asp:Button runat="server" ID="btnregistro" class="btn purple-gradient" data-toggle="modal" data-target="#centralModalSuccess, #centralModalDanger, #centralModalWarning" Text="Registrarse" ValidationGroup="reg" OnClick="btnregistro_Click" />
            <!--<asp:Label runat="server" ID="lblReg"></asp:Label>-->
        </div>
    </div>
    <asp:Panel runat="server" ID="panel1" Visible="False">
        <div class="modal fade" id="centralModalSuccess" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-notify modal-success" role="document">
                <!--Content-->
                <div class="modal-content">
                    <!--Header-->
                    <div class="modal-header">
                        <p class="heading lead">Éxito</p>

                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" class="white-text">&times;</span>
                        </button>
                    </div>

                    <!--Body-->
                    <div class="modal-body">
                        <div class="text-center">
                            <i class="fas fa-check fa-4x mb-3 animated rotateIn"></i>
                            <p>
                                Usuario registrado.
                            </p>
                        </div>
                    </div>

                    <!--Footer-->
                    <div class="modal-footer justify-content-center">
                        <asp:Button CssClass="btn btn-success" ID="btnAceptarsuc" runat="server" />
                    </div>
                </div>
                <!--/.Content-->
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panel2" Visible="false">
        <div class="modal fade" id="centralModalDanger" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-notify modal-danger" role="document">
                <!--Content-->
                <div class="modal-content">
                    <!--Header-->
                    <div class="modal-header">
                        <p class="heading lead">Error</p>

                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" class="white-text">&times;</span>
                        </button>
                    </div>

                    <!--Body-->
                    <div class="modal-body">
                        <div class="text-center">
                            <i class="fas fa-ban fa-4x mb-3 animated flip"></i>
                            <p>
                                Este usuario ya está registrado.
                            </p>
                        </div>
                    </div>

                    <!--Footer-->
                    <div class="modal-footer justify-content-center">
                        <asp:Button CssClass="btn btn-danger" ID="btnAceptarDan" runat="server" Text="Aceptar" />
                    </div>
                </div>
                <!--/.Content-->
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panel3" Visible="false">
        <div class="modal fade" id="centralModalWarning" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-notify modal-warning" role="document">
                <!--Content-->
                <div class="modal-content">
                    <!--Header-->
                    <div class="modal-header">
                        <p class="heading lead">Error</p>

                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" class="white-text">&times;</span>
                        </button>
                    </div>

                    <!--Body-->
                    <div class="modal-body">
                        <div class="text-center">
                            <i class="fas fa-exclamation fa-4x mb-3 animated bounceIn"></i>
                            <p>
                                No ha ingresado datos.
                            </p>
                        </div>
                    </div>

                    <!--Footer-->
                    <div class="modal-footer justify-content-center">
                        <asp:Button CssClass="btn btn-warning" ID="btnWarning" runat="server" Text="Aceptar" />
                    </div>
                </div>
                <!--/.Content-->
            </div>
        </div>
    </asp:Panel>
</asp:Content>
