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
        FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Pelicula = Session["ID_Pelicula"].ToString();
            string Sucursal = Session["ID_Sucursal"].ToString();
            string Fecha = Session["Fecha"].ToString();
            string Hora = Session["Horario"].ToString();
            string Precio = Session["Precio"].ToString();

            fs.Fecha1 = Fecha;
            fs.Hora_Inicio1 = Hora;
            fs.Precio1 = Convert.ToDecimal(Precio);
            fs.ID_Pelicula1 = Pelicula;
            fs.ID_Sucursal1 = Sucursal;

            if (!IsPostBack)
            {
                cargarddlAsiento();
            }
        }

        protected void cargarddlAsiento()
        {
            ddlAsiento.Items.Clear();
            ddlAsiento.DataSource = ndc.obtenerAsientosDisponibles(fs);
            ddlAsiento.DataValueField = "ID_Asiento";
            ddlAsiento.DataTextField = "ID_Asiento";
            ddlAsiento.DataBind();


        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
            ndc.seleccionarAsiento(fs, ddlAsiento.SelectedValue.ToString());

            cargarddlAsiento();
            cargargvAsientos();
        }

        protected void cargargvAsientos()
        {
            gvAsientos.DataSource = ndc.obtenerAsientosReservados();
            gvAsientos.DataBind();
        }

        protected void gvAsientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvAsientos.Rows[e.RowIndex];
            ndc.quitarAsientoSeleccionado(gvAsientos.DataKeys[e.RowIndex].Value.ToString());
            cargarddlAsiento();
            cargargvAsientos();

        }
    }
}