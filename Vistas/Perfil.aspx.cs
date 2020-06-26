using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas
{
    public partial class Perfil : System.Web.UI.Page
    {
        NegocioUsuario nu = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiarCorreo_Click(object sender, EventArgs e)
        {
            lblContra.Text = "";
            bool estado = false;
            estado = nu.ModificarCorreo(Session["Correo"].ToString(), txtCorreo.Text, Session["Contraseña"].ToString());
            if (estado)
            {
                Session["Correo"] = txtCorreo.Text;
                lblCorreo.CssClass = "green-text msglbl";
                lblCorreo.Text = "Correo modificado.";
            }
            else
            {
                lblCorreo.CssClass = "red-text msglbl";
                lblCorreo.Text = "El correo no pudo ser modificado.";
            }

        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            lblCorreo.Text = "";
            bool estado = false;
            estado = nu.ModificarContra(Session["Contraseña"].ToString(), txtContra.Text, Session["Correo"].ToString());
            if (estado)
            {
                Session["Contraseña"] = txtContra.Text;
                lblContra.CssClass = "green-text msglbl";
                lblContra.Text = "Contraseña modificada.";
            }
            else
            {
                lblContra.CssClass = "red-text msglbl";
                lblContra.Text = "La contraseña no pudo ser modificada.";
            }
        }

        protected void CuvContra_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 8 || args.Value.Length > 20)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}