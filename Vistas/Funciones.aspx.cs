using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Vistas
{
    public partial class Funciones : System.Web.UI.Page
    {
        FuncionesxSala fs = new FuncionesxSala();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvFunciones.SelectedRow;

            string Fecha = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[0]);
            string Hora = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[1]);
            string Precio = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[2]);
            string Funcion = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[3]);
            string Pelicula = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[4]);
            string Sala = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[5]);
            string Sucursal = Convert.ToString(gvFunciones.DataKeys[row.RowIndex].Values[6]);

            fs.Fecha1 = Fecha;
            fs.Hora_Inicio1 = Hora;
            fs.Precio1 = Convert.ToDecimal(Precio);
            fs.ID_Funcion1 = Funcion;
            fs.ID_Pelicula1 = Pelicula;
            fs.ID_Sala1 = Sala;
            fs.ID_Sucursal1 = Sucursal;

            Session["ID_Funcion"] = fs.ID_Funcion1;
            Session["ID_Pelicula"] = fs.ID_Pelicula1;
            Session["ID_Sala"] = fs.ID_Sala1;
            Session["ID_Sucursal"] = fs.ID_Sucursal1;
            Session["Fecha"] = fs.Fecha1;
            Session["Horario"] = fs.Hora_Inicio1;
            Session["Precio"] = fs.Precio1;

            Response.Redirect("DetalledeCompra.aspx");
        }
    }
}