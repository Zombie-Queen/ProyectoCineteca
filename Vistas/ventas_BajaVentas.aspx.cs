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
using System.Windows.Forms;

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
                Session["numeroVenta"] = null;
                CargarGrid();
                ddlVentas.Items.Add("Ventas");
                ddlVentas.Items.Add("Detalles de venta");
                ddlVentas.Items.Add("Detalles de venta artículos");
                ddlVentas.DataBind();
                
            }
            if (ddlVentas.SelectedValue == "Ventas"){CargarGrid();}
            if (ddlVentas.SelectedValue == "Detalles de venta") {  CargarGridDetalleDeVenta(); }
            if (ddlVentas.SelectedValue == "Detalles de venta artículos") {  CargarGridDetalleDeVentaArts();}
            
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
            String nro_venta = txt_num_venta.Text;
            if (ddlVentas.SelectedValue == "Ventas") 
            {
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


            if(ddlVentas.SelectedValue == "Detalles de venta") 
            {
                if (nro_venta != "")
                {
                    
                    dev.id_venta_dv = Convert.ToInt32(nro_venta);
                    DataTable tabla_de_ventas = ndev.getDetalleVenta_porNroVenta(dev);
                    grdVentas.DataSource = tabla_de_ventas;
                    grdVentas.DataBind();
                }
                else
                {
                    /*no ingreso nada */
                }

            }
            if (ddlVentas.SelectedValue == "Detalles de venta artículos") 
            {
                if (nro_venta != "")
                {
                    devArt.id_venta_dva = Convert.ToInt32(nro_venta);
                    DataTable tabla_de_ventas = ndev.getDetalleArt_porNroVenta(devArt);
                    grdVentas.DataSource = tabla_de_ventas;
                    grdVentas.DataBind();
                }
                else
                {
                    /*no ingreso nada */
                }
            }
                

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdVentas.PageIndex = 0;
            CargarGrid();
            txt_num_venta.Text = "";
        }

        public void CargarGrid()
        {
            DataTable tablaVentas = nv.getTabla();
            grdVentas.DataSource = tablaVentas;
            grdVentas.DataBind();

        }
        public void CargarGridDetalleDeVenta() 
        {
            DataTable tablaVentas = ndev.getTablaDetalleDeVenta();
            grdVentas.DataSource = tablaVentas;
            grdVentas.DataBind();
        }
        public void CargarGridDetalleDeVentaArts()
        {
            DataTable tablaVentas = ndev.getTablaDetalleDeVentaArticulos();
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
            /*si selecciono la tabla ventas*/
            if (ddlVentas.SelectedValue=="Ventas") 
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

            /*si selecciono la tabla detalle de ventas*/
            if (ddlVentas.SelectedValue=="Detalles de venta") { }
            /*si selecciono la tabla detalle de ventas artículos*/
            if (ddlVentas.SelectedValue == "Detalles de venta artículos") { }
            
            
              
            
            
        }

            
    }
}