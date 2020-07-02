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
using System.Configuration;

namespace Vistas
{
    public partial class articulos_alta : System.Web.UI.Page
    {
        NegociosArticulos na = new NegociosArticulos();
        Articulos art = new Articulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["dev_seleccionados"] = null;
                Session["numeroVenta"] = null;
                Session["detalles_seleccionados"] = null;
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

        protected void grdArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdArticulos.EditIndex = e.NewEditIndex; // quieren editar la grilla en esta posicion (la que trae e.NewEditIndex)
            CargarGrid();
        }

        protected void grdArticulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdArticulos.EditIndex = -1;
            CargarGrid();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdArticulos.PageIndex = 0;
            CargarGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try 
            {
                art.id_articulo = txt_id_articulo.Text;
                art.estado_articulo = txt_estado_articulo.Text;
                art.nombre_articulo = txt_nombre_articulo.Text;
                art.descripcion_articulo = txt_descripcion_art.Text;
                art.precio = Convert.ToDecimal(txt_precio_art.Text);
                art.imagen_articulo = txt_url_articulo.Text;
                if (na.existeArticulo(art))
                {
                    /*el articulo ya existe*/
                }
                else
                {
                    if (na.agregarArticulo(art))
                    {
                        /*se agrego con exito*/

                    }
                    else
                    {
                        /*no se agrego ni papas */
                    }

                }




            }
            catch(Exception exc) 
            {
                /*mensaje de error por excepcion grave*/
            }

            

        }
        protected void grdArticulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Buscar los datos del edititemplate
            String s_id_articulo = ((System.Web.UI.WebControls.Label)grdArticulos.Rows[e.RowIndex].FindControl("lbl_id_articulo")).Text;
            String s_estado = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_estado_art")).Text;
            String s_nombre = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_nombre")).Text;
            String s_descripcion = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_descripcion")).Text;
            String s_precio = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_precio")).Text;
            String s_url = ((System.Web.UI.WebControls.TextBox)grdArticulos.Rows[e.RowIndex].FindControl("txt_imagen")).Text;

            art.id_articulo = s_id_articulo;
            art.estado_articulo = s_estado;
            art.nombre_articulo = s_nombre;
            art.descripcion_articulo = s_descripcion;
            art.precio = Convert.ToDecimal(s_precio);
            art.imagen_articulo = s_url;


            na.modificarArticulo(art);// se envia el objeto con los nuevos valores y se actualiza en la BD

            grdArticulos.EditIndex = -1;
            CargarGrid(); // se vuelve a cargar la grilla actualizada 
        }

        protected void grdArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String idArticulo = ((System.Web.UI.WebControls.Label)grdArticulos.Rows[e.RowIndex].FindControl("lbl_id_articulo")).Text;// se toma en un string el id del producto segun la fila donde se toco el boton eliminar
            art.id_articulo = idArticulo;
            String nombreArt = ((System.Web.UI.WebControls.Label)grdArticulos.Rows[e.RowIndex].FindControl("lbl_nombre")).Text;// se toma en un string el id del producto segun la fila donde se toco el boton eliminar
            
            try 
            {
                if(MessageBox.Show("Seguro que desea eliminar el artículo "+nombreArt+"?", "Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)            
                {
                    if (na.eliminarArticulo(art))
                    {
                        /*se elimino con exito*/
                        grdArticulos.PageIndex = 0; /* va a la pagina 1 */
                        CargarGrid();// se carga de nuevo la grilla sin el registro ya eliminado
                    }

                }
                else
                {   
                    grdArticulos.PageIndex = 0; /* va a la pagina 1 */
                    CargarGrid();// se carga de nuevo la grilla sin el registro ya eliminado
                }
                
            }
            catch(Exception exc)
            {
                
                MessageBox.Show("No se pueden eliminar datos relacionados con otras tablas.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                
            }
            

        }


    }
}