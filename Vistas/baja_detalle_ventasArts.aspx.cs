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
    public partial class baja_detalle_ventasArts : System.Web.UI.Page
    {

        NegociosDetalleDeVenta ndev = new NegociosDetalleDeVenta();
        DetalleVentasArticulo dva = new DetalleVentasArticulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["numeroVenta"] = null;
                CargarGridDetalleDeVentaArts();
            }
        }
        public void CargarGridDetalleDeVentaArts()
        {
            DataTable tablaVentas = ndev.getTablaDetalleDeVentaArticulos();
            grdDetVentaArt.DataSource = tablaVentas;
            grdDetVentaArt.DataBind();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            String nro_venta = txt_num_venta.Text;

            if (nro_venta != "")
            {
                dva.id_venta_dva = Convert.ToInt32(nro_venta);
                DataTable tabla_de_ventas = ndev.getDetalleArt_porNroVenta(dva);
                grdDetVentaArt.DataSource = tabla_de_ventas;
                grdDetVentaArt.DataBind();

            }
            else
            {
                /*no ingreso nada */
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdDetVentaArt.PageIndex = 0;
            CargarGridDetalleDeVentaArts();
            txt_num_venta.Text = "";
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea dar de baja los detalles seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


            }
            else
            {
                grdDetVentaArt.PageIndex = 0;
                CargarGridDetalleDeVentaArts();
                txt_num_venta.Text = "";

            }
        }

        protected void grdDetVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDetVentaArt.PageIndex = e.NewPageIndex;
            CargarGridDetalleDeVentaArts();
        }

        protected void grdDetVentaArt_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            String s_idVenta = ((System.Web.UI.WebControls.Label)grdDetVentaArt.Rows[e.NewSelectedIndex].FindControl("lbl_venta")).Text;
            String s_IdDetalleVenta = ((System.Web.UI.WebControls.Label)grdDetVentaArt.Rows[e.NewSelectedIndex].FindControl("lbl_detalle_venta")).Text;
            if (Session["detalles_seleccionados"] == null)
            {
                Session["detalles_seleccionados"] = crearTabla();
            }
            if (!verificarSeleccion((DataTable)Session["detalles_seleccionados"], s_idVenta, s_IdDetalleVenta))
            {
                agregarFila((DataTable)Session["detalles_seleccionados"], s_idVenta, s_IdDetalleVenta);

            }
            else { MessageBox.Show("El detalle ya fue seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        public DataTable crearTabla()
        {

            // se crea columna por columna 
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("ID Venta", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("ID detalle venta artículo", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            

            return dt;
        }

        public void agregarFila(DataTable tabla, String idVenta, String idDetVenta)
        {
            DataRow dr = tabla.NewRow();
            dr["ID Venta"] = idVenta;
            dr["ID detalle venta artículo"] = idDetVenta;
            tabla.Rows.Add(dr);

        }

        public bool verificarSeleccion(DataTable tabla, String id,String idDet)
        {

            foreach (DataRow row in tabla.Rows)
            {

                if (string.Equals(row["ID Venta"], id) && string.Equals(row["ID detalle venta artículo"], idDet))
                {
                    return true;
                }


            }


            return false;
        }

        protected void Seleccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("devarts_seleccionados.aspx");
        }
    }
}