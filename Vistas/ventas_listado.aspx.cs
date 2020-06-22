﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.Data.SqlClient;

namespace Vistas
{
    public partial class ventas_listado : System.Web.UI.Page
    {
        NegociosVentas nv = new NegociosVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                CargarGrid();

            }
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            grdVentas.PageIndex = 0;
            CargarGrid();
            txt_dni.Text = "";
            txt_fecha.Text = "dd/mm/aaaa";
            txt_venta.Text = "";

        }

        protected void Filtrar_Click(object sender, EventArgs e)
        {
            String dni = txt_dni.Text;
            String nro_venta = txt_venta.Text;
            String Fecha = txt_fecha.Text;
            
            /*ingresan solo dni*/
            if (dni != "" && nro_venta == "" && Fecha == "")
            {
                DataTable tabla_de_ventas = nv.getTablaVentaPorDni(dni);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*ingresan solo numero de venta*/
            if (nro_venta != "" && dni == "" && Fecha == "")
            {
                DataTable tabla_de_ventas = nv.getTablaVentaPorNumVen(nro_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*ingresan solo fecha*/
            if (Fecha != "" && dni == "" && nro_venta == "")
            {
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPorFecha(fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*AHORA SI INGRESAN CAMPOS COMBINADOS*/
            /*INGRESAN DNI Y NRO DE VENTA*/
            if (dni != "" && nro_venta!=""&&Fecha=="")
            {
                DataTable tabla_de_ventas = nv.getTablaVentaPorDniNroVenta(dni, nro_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*INGRESAN DNI Y FECHA*/
            if (dni != "" && Fecha != "" && nro_venta == "")
            {
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPor_DniFecha(dni,fecha_venta );
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*INGRESAN NRO DE VENTA Y FECHA*/
            if (dni == "" && Fecha != "" && nro_venta != "")
            {
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPor_NroVenta_Fecha(nro_venta, fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*INGRESAN TODOS*/
  
            if (dni != "" && Fecha != "" && nro_venta != "")
            {
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPor_Dni_NroVenta_Fecha(dni,nro_venta, fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }






        }
        protected void grdVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

           
            String dni = txt_dni.Text;
            String nro_venta = txt_venta.Text;          
            String Fecha = txt_fecha.Text;
            
            /*Cambio de pagina cuando no hay nada cargado*/
            if  (nro_venta == "" && dni == "" && Fecha == "")
            {
                grdVentas.PageIndex = e.NewPageIndex;
                CargarGrid();

            }

            /* cambio de pagina solo fecha */
            if (Fecha != "" && dni == "" && nro_venta == "")
            {
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                grdVentas.PageIndex = e.NewPageIndex;
                DataTable tabla_de_ventas = nv.getTablaVentaPorFecha(fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();
            }
            /*Cambio de pagina solo dni*/
            if (dni != "" && nro_venta == "" && Fecha == "")
            {
                grdVentas.PageIndex = e.NewPageIndex;
                DataTable tabla_de_ventas = nv.getTablaVentaPorDni(dni);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*Cambio de pagina solo nro venta*/
            if (nro_venta != "" && dni == "" && Fecha == "")
            {
                grdVentas.PageIndex = e.NewPageIndex;
                DataTable tabla_de_ventas = nv.getTablaVentaPorNumVen(nro_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }
            /*Cambio de pagina dni nro venta*/
            if (dni != "" && nro_venta != "" && Fecha == "")
            {
                grdVentas.PageIndex = e.NewPageIndex;
                DataTable tabla_de_ventas = nv.getTablaVentaPorDniNroVenta(dni, nro_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }

            /*Cambio de pagina dni fecha*/
            if (dni != "" && Fecha != "" && nro_venta == "")
            {
                grdVentas.PageIndex = e.NewPageIndex;
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPor_DniFecha(dni, fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }

            /*Cambio de pagina nro de venta fecha*/
            if (dni == "" && Fecha != "" && nro_venta != "")
            {
                grdVentas.PageIndex = e.NewPageIndex;
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPor_NroVenta_Fecha(nro_venta, fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }

            /*Cambio de pagina si ingresan todos*/
            if (dni != "" && Fecha != "" && nro_venta != "")
            {

                grdVentas.PageIndex = e.NewPageIndex;
                DateTime fecha_venta = Convert.ToDateTime(Fecha);
                DataTable tabla_de_ventas = nv.getTablaVentaPor_Dni_NroVenta_Fecha(dni, nro_venta, fecha_venta);
                grdVentas.DataSource = tabla_de_ventas;
                grdVentas.DataBind();

            }


        }
        public void CargarGrid()
        {
            DataTable tablaVentas = nv.getTabla();
            grdVentas.DataSource = tablaVentas;
            grdVentas.DataBind();

        }
    }
}