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
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {

        }
    }
}