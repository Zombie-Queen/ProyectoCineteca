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
    public partial class articulos_alta : System.Web.UI.Page
    {
        NegociosArticulos na = new NegociosArticulos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarGrid();
            }
        }
        public void CargarGrid()
        {
            DataTable tablaArticulos = na.getTabla();
            grdArticulos.DataSource = tablaArticulos;
            grdArticulos.DataBind();

        }
        protected void grdArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdArticulos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {

        }

        protected void Volver_Click(object sender, EventArgs e)
        {

        }
    }
}