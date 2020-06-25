using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Vistas
{
    public partial class ventas_modif_Ventas : System.Web.UI.Page
    {
        NegociosVentas nv = new NegociosVentas();
        NegociosDetalleDeVenta ndev = new NegociosDetalleDeVenta();
        Ventas ven = new Ventas();
        DetalleVentas dev = new DetalleVentas();
        DetalleVentasArticulo devArt = new DetalleVentasArticulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
            String nro_venta = txt_num_venta.Text;
            if (nro_venta != "") 
            {
                DataTable tabla_de_ventas = nv.getTablaVentaPorNumVen(nro_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();
            }
            else 
            {
                /*no ingreso nada */
            }
                

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            CargarGrid();
            txt_num_venta.Text = "";
        }

        public void CargarGrid()
        {
            DataTable tablaVentas = nv.getTabla();
            grdVentas.DataSource = tablaVentas;
            grdVentas.DataBind();

        }
        protected void grdVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVentas.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            if (txt_num_venta.Text != "")   
            {

                int nro_venta = Convert.ToInt32(txt_num_venta.Text);
                ven.id_venta = nro_venta;
                dev.id_venta_dv = nro_venta;
                devArt.id_venta_dva = nro_venta;

                if (nv.existeVenta(ven))
                {

                    if (nv.BorrarVenta(ven))
                    {
                        /*se borro con exito*/
                        ndev.BorrarDetalleVenta(dev);
                        ndev.BorrarDetalleVentaArticulos(devArt);
                        CargarGrid();

                    }
                    else
                    {
                        CargarGrid();
                        /*no se borro con exito*/
                    }

                }
                else
                {
                    /*la venta no existe*/
                    CargarGrid();
                }


            }
            
              
            
            
        }
    }
}