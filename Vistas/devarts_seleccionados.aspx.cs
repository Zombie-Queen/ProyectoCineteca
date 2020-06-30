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
    public partial class devarts_seleccionados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["detalles_seleccionados"] != null)
            {

                CargarGridSeleccion();

            }
            else
            {
              /*no hay ventas seleccionadas*/  
            }

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("baja_detalle_ventasArts.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {

        }

        protected void grdDetallesSelect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDetallesSelect.PageIndex = e.NewPageIndex;
            CargarGridSeleccion();
        }
        public void CargarGridSeleccion()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["detalles_seleccionados"];
            grdDetallesSelect.DataSource = dt;
            grdDetallesSelect.DataBind();
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Session["detalles_seleccionados"] = null;
            CargarGridSeleccion();


        }
    }
}