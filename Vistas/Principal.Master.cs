using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
//using Negocios;

namespace Vistas
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            /*
            Cliente cli = new Cliente();
            GestionClientes gc = new GestionClientes();
            cli.nombre = ((TextBox)nombre.FindControl("nombre")).Text;
            cli.apellido = ((TextBox)ape.FindControl("ape")).Text;
            cli.dni = ((TextBox)dni.FindControl("dni")).Text;
            cli.contraseña = ((TextBox)contra.FindControl("contra")).Text;
            cli.fecha = Convert.ToDateTime(fecha.Text);
            cli.mail = ((TextBox)email.FindControl("email")).Text;
            gc.AgregarCliente(cli);*/
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            /*GestionClientes gc = new GestionClientes();
            DataTable dt = gc.RegistroCliente(correo.Text, contraseña.Text);
            if (dt.Rows.Count > 0)
            {

                logueado.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center d-block";
                ddm.CssClass = "dropdown-menu dropdown-menu-lg-right mr-5 pl-2 pr-2 text-md-center d-none";
            }
            else
                lblprueba.Text = "No Funciona";*/
        }





    }
}