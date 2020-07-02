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
                    lbluser.Text = Session["Nombre"].ToString();
                    lbluser.CssClass = "nombreuser";
                }
                else
                {
                    logueado.CssClass = "d-none";
                    ddm.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center";
                }
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
                Session["Nombre"] = "Bienvenido/a " + Convert.ToString(dt.Rows[0][2]) + "!";
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

        protected void btnCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComprasCliente.aspx");
        }
    }
}


