using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;
using System.Windows.Forms;

namespace Vistas
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        NegocioFinalizarCompra nfc = new NegocioFinalizarCompra();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

            try
            {
                nfc.realizarVenta();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ocurrió un error y no se pudo pagar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (nfc.cancelarVenta())
            {
                Response.Redirect("Inicio.aspx");
            }
                
        }
    }
}