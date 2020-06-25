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
        int estado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (estado == 1)
                {
                    //lblReg.CssClass = "green-text msglbl";
                    //lblReg.Text = "Usuario registrado.";
                    nombre.Text = "";
                    ape.Text = "";
                    dni.Text = "";
                    email.Text = "";
                    fecha.Text = "";
                    panel1.Visible = true;
                }
                else if (estado == 0)
                {
                    //lblReg.CssClass = "red-text msglbl";
                    //lblReg.Text = "Este usuario ya está registrado.";        
                    nombre.Text = "";
                    ape.Text = "";
                    dni.Text = "";
                    email.Text = "";
                    fecha.Text = "";
                    panel2.Visible = true;
                }
                else if (estado == 2)
                {
                    panel3.Visible = true;
                }
            }
        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            Usuario cli = new Usuario();
            NegocioUsuario nc = new NegocioUsuario();
            cli.nombre = ((TextBox)nombre.FindControl("nombre")).Text;
            cli.apellido = ((TextBox)ape.FindControl("ape")).Text;
            cli.dni = ((TextBox)dni.FindControl("dni")).Text;
            cli.contraseña = ((TextBox)contra.FindControl("contra")).Text;
            cli.fecha = Convert.ToDateTime(fecha.Text);
            cli.mail = ((TextBox)email.FindControl("email")).Text;
            if (cli.dni == "")
            {
                estado = 2;
            }
            else
            {
                estado = nc.AgregarCliente(cli);
            }
            
        }
    }
}