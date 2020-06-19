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
    public partial class peliculas_alta : System.Web.UI.Page
    {
        NegociosPeliculas np = new NegociosPeliculas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarGrid();
            }    
        }

        
        public void CargarGrid()
        {
            DataTable tablaPeliculas = np.getTabla();
            grdPelis.DataSource = tablaPeliculas;
            grdPelis.DataBind();

        }

        protected void grdPelis_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdPelis.PageIndex = e.NewPageIndex;
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