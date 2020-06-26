using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace Vistas
{
    public partial class DetalledeCompra : System.Web.UI.Page
    {
        NegocioDetalleDeCompra ndc = new NegocioDetalleDeCompra();
        FuncionesxSala fs = new FuncionesxSala();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Funcion= Session["ID_Funcion"].ToString();
            string Pelicula = Session["ID_Pelicula"].ToString();
            string Sala = Session["ID_Sala"].ToString();
            string Sucursal = Session["ID_Sucursal"].ToString();
            string Fecha = Session["Fecha"].ToString();
            string Hora = Session["Horario"].ToString();
            string Precio = Session["Precio"].ToString();

            fs.Fecha1 = Fecha;
            fs.Hora_Inicio1 = Hora;
            fs.Precio1 = Convert.ToDecimal(Precio);
            fs.ID_Funcion1 = Funcion;
            fs.ID_Pelicula1 = Pelicula;
            fs.ID_Sala1 = Sala;
            fs.ID_Sucursal1 = Sucursal;
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string asiento= ddlAsiento.SelectedValue.ToString();
            ndc.seleccionarAsiento(fs.ID_Funcion1, fs.ID_Pelicula1, fs.ID_Sucursal1, fs.ID_Sala1, asiento, fs.Fecha1);
        }
    }
}