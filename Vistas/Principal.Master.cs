using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
using Negocios;
using System.Diagnostics;

namespace Vistas
{
    public partial class Principal : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Correo"] != null && Session["Contraseña"] != null)
                {
                    ddm.CssClass = "d-none";
                    logueado.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center";
                }
                else
                {
                    logueado.CssClass = "d-none";
                    ddm.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center";
                }
            }

        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            Usuario cli = new Usuario();
            NegocioUsuario nc = new NegocioUsuario();
            Boolean estado = false;
            cli.nombre = ((TextBox)nombre.FindControl("nombre")).Text;
            cli.apellido = ((TextBox)ape.FindControl("ape")).Text;
            cli.dni = ((TextBox)dni.FindControl("dni")).Text;
            cli.contraseña = ((TextBox)contra.FindControl("contra")).Text;
            cli.fecha = Convert.ToDateTime(fecha.Text);
            cli.mail = ((TextBox)email.FindControl("email")).Text;
            estado = nc.AgregarCliente(cli);
            if (estado)
            {
                //MENSAJE EXITOSO
            }
            else
            {
                //ERROR 
                nombre.Text = "";
                ape.Text = "";
                dni.Text = "";
                email.Text = "";
                fecha.Text = "";
            }

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            NegocioUsuario nc = new NegocioUsuario();
            DataTable dt = nc.getRegistroUsuario(correo.Text, contraseña.Text);
            if (dt.Rows.Count > 0)
            {
                lblerror.Text = "";
                Session["Correo"] = correo.Text;
                Session["Contraseña"] = contraseña.Text;
                if (Convert.ToInt32(dt.Rows[0][7]) == 1)
                {
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    Server.Transfer("Inicio_admin.aspx");
                }
            }
            else
            {
                lblerror.Text = "Correo o contraseña inválido";
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Correo"] = null;
            Session["Contraseña"] = null;
            Server.Transfer("Inicio.aspx");
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void CVreg_ServerValidate(object source, ServerValidateEventArgs args)
        {
            NegocioUsuario nc = new NegocioUsuario();
            if (nc.existeUsuario(args.Value.ToString()))

                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}


