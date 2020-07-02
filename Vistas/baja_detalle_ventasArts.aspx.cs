﻿using System;
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
using System.Linq.Expressions;

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

                try 
                {

                    DataTable dt = new DataTable();
                    dt = (DataTable)Session["detalles_seleccionados"];

                    /* recorre la tabla y dando de baja los detalles de ventas*/
                    foreach (DataRow row in dt.Rows)
                    {
                        int id_venta = Convert.ToInt32(row["ID Venta"]);
                        int id_det_venta = Convert.ToInt32(row["ID detalle venta artículo"]);
                        ndev.cancelarDetallesArts(id_venta, id_det_venta);
                        /* resta el dinero a las ventas*/
                        Decimal monto = Convert.ToDecimal(row["Total"]);
                        /* sumar 0.02 */
                        ndev.restarSaldoDeVenta(id_venta, monto);

                    }
                    MessageBox.Show("Detalles dados de baja con éxito", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
               
                catch (Exception exc) 
                {
                    MessageBox.Show("Ocurrio un error y no se pude completar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            String s_cantidad = ((System.Web.UI.WebControls.Label)grdDetVentaArt.Rows[e.NewSelectedIndex].FindControl("lbl_cantidad")).Text;
            String s_precio = ((System.Web.UI.WebControls.Label)grdDetVentaArt.Rows[e.NewSelectedIndex].FindControl("lbl_precio")).Text;
            Decimal total_dva = Convert.ToInt32(s_cantidad) * Convert.ToDecimal(s_precio);
            String s_total_dva = Convert.ToString(total_dva);
            if (Session["detalles_seleccionados"] == null)
            {
                Session["detalles_seleccionados"] = crearTabla();
            }
            if (!verificarSeleccion((DataTable)Session["detalles_seleccionados"], s_idVenta, s_IdDetalleVenta))
            {
                agregarFila((DataTable)Session["detalles_seleccionados"], s_idVenta, s_IdDetalleVenta,s_cantidad,s_precio,s_total_dva);

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

            columna = new DataColumn("Cantidad", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Precio", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Total", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarFila(DataTable tabla, String idVenta, String idDetVenta,String cantidad,String precio,String total)
        {
            DataRow dr = tabla.NewRow();
            dr["ID Venta"] = idVenta;
            dr["ID detalle venta artículo"] = idDetVenta;
            dr["Cantidad"] = cantidad;
            dr["Precio"] = precio;
            dr["Total"] = total;
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