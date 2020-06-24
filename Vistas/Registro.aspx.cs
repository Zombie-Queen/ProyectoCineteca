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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                lblReg.CssClass = "green-text msglbl";
                lblReg.Text = "Usuario registrado.";
            }
            else
            {
                lblReg.CssClass = "red-text msglbl";
                lblReg.Text = "Este usuario ya está registrado.";
                nombre.Text = "";
                ape.Text = "";
                dni.Text = "";
                email.Text = "";
                fecha.Text = "";
            }
        }
    }
}