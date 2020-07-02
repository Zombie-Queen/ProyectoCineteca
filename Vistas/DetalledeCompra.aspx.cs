using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
using System.Data;
using System.Windows.Forms;

namespace Vistas
{
    public partial class DetalledeCompra : System.Web.UI.Page
    {
        NegocioDetalleDeCompra ndc = new NegocioDetalleDeCompra();
        Articulos art = new Articulos();
        FuncionesxSala fs = new FuncionesxSala();
        FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
        DetalleVentasArticulo dva = new DetalleVentasArticulo();
        private String numero;
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
                Session["Articulos_Seleccionados"] = null;
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

        protected void gvArticulos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlStock");
            String valor_hf = ((HiddenField)e.Item.FindControl("hfStock")).Value;
            numero = valor_hf;
            ddl.DataBind();
        }

        protected void ODS_ddlStock_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["Stock"] = numero;

        }

        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoAgregar")
            {
                dva.id_articulo_dva = e.CommandArgument.ToString();
            }
        }

        protected void cargargvArticulos (DataTable dt)
        {
            gvArticulos.DataSource = dt;
            gvArticulos.DataBind();
        }

        protected void lvArticulos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlStock");
            dva.cantidad = Convert.ToInt32(ddl.SelectedItem.Text.ToString());

            System.Web.UI.WebControls.Label lblPrecio = ((System.Web.UI.WebControls.Label)e.Item.FindControl("PrecioLabel"));
            dva.precio = Convert.ToDecimal(lblPrecio.Text.ToString());
            System.Web.UI.WebControls.Label lblNombre = ((System.Web.UI.WebControls.Label)e.Item.FindControl("Nombre_ArticuloLabel"));
            art.nombre_articulo = lblNombre.Text.ToString();
            System.Web.UI.WebControls.Label lblDescripcion = ((System.Web.UI.WebControls.Label)e.Item.FindControl("Descripción_ArticuloLabel"));
            art.descripcion_articulo = lblDescripcion.Text.ToString();

            

            if (Session["Articulos_Seleccionados"] == null)
            {
                Session["Articulos_Seleccionados"] = crearTabla();
            }
            if (!verificarSeleccion((DataTable) Session["Articulos_Seleccionados"], dva))
            {
                agregarFila((DataTable) Session["Articulos_Seleccionados"], dva, art);

                cargargvArticulos((DataTable)Session["Articulos_Seleccionados"]);
            }
            else { MessageBox.Show("El artículo ya fue seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Articulo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");

            return dt;
        }

        public void agregarFila(DataTable dt, DetalleVentasArticulo dva, Articulos art)
        {
            DataRow dr = dt.NewRow();
            dr["ID_Articulo"] = dva.id_articulo_dva;
            dr["Nombre"] = art.nombre_articulo;
            dr["Descripcion"] = art.descripcion_articulo;
            dr["Cantidad"] = dva.cantidad;
            dr["Precio"] = dva.precio;
            dt.Rows.Add(dr);
        }

        public bool verificarSeleccion(DataTable dt, DetalleVentasArticulo dva)
        {

            foreach (DataRow row in dt.Rows)
            {
                if (string.Equals(row["ID_Articulo"], dva.id_articulo_dva))
                {
                    return true;
                }
            }
            return false;
        }

    }
}