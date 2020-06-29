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
    public partial class Funciones : System.Web.UI.Page
    {
        FuncionesxSala fs = new FuncionesxSala();
        NegocioFuncionxSala nfs = new NegocioFuncionxSala();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void gvFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvFunciones.SelectedRow;

            string Fecha = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[0]);
            string Hora = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[1]);
            string Precio = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[2]);

            fs.Fecha1 = Fecha;
            fs.Hora_Inicio1 = Hora;
            fs.Precio1 = Convert.ToDecimal(Precio);

            Session["Fecha"] = fs.Fecha1;
            Session["Horario"] = fs.Hora_Inicio1;
            Session["Precio"] = fs.Precio1;

            nfs.vaciarReservasAnteriores();
            Response.Redirect("DetalledeCompra.aspx");
        }
    }
}