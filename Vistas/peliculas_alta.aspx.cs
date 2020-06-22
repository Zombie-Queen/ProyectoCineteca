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
    public partial class peliculas_alta : System.Web.UI.Page
    {
        NegociosPeliculas np = new NegociosPeliculas();
        Peliculas pelicula = new Peliculas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        protected void grdPelis_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPelis.EditIndex = e.NewEditIndex; // quieren editar la grilla en esta posicion (la que trae e.NewEditIndex)
            CargarGrid();
        }

        protected void grdPelis_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPelis.EditIndex = -1;
            CargarGrid();
        }


        protected void Buscar_Click(object sender, EventArgs e)
        {

        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            grdPelis.PageIndex = 0;
            CargarGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            pelicula.id_pelicula = txt_id_peli.Text;
            pelicula.estado = txt_estado_peli.Text;
            pelicula.titulo = txt_titulo_peli.Text;
            pelicula.duracion = Convert.ToInt32(txt_duracion_peli.Text);
            pelicula.clasificacion = txt_clasif_peli.Text;
            pelicula.url_imagen = txt_url_peli.Text;
            if (np.existePelicula(pelicula))
            {
                /*la pelicula ya existe*/
            }
            else
            {
                if (np.agregarPelicula(pelicula))
                {
                    /*se agrego con exito*/

                }
                else
                {
                    /*no se agrego ni papas */
                }

            }


        }

        protected void grdPelis_RowUpdating(object sender, GridViewUpdateEventArgs e)
         {
            
             //Buscar los datos del edititemplate
             String s_id_pelicula = ((Label)grdPelis.Rows[e.RowIndex].FindControl("lbl_id_peicula")).Text;
             String s_estado = ((TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_estado_peli")).Text;
             String s_titulo = ((TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_titulo")).Text;
             String s_duracion = ((TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_duracion")).Text;
             String s_clasif = ((TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_clasificacion")).Text;
             String s_url = ((TextBox)grdPelis.Rows[e.RowIndex].FindControl("txt_imagen")).Text;

            pelicula.id_pelicula = s_id_pelicula;
            pelicula.estado = s_estado;
            pelicula.titulo = s_titulo;
             pelicula.duracion = Convert.ToInt32(s_duracion);
            pelicula.clasificacion = s_clasif;
            pelicula.url_imagen = s_url;


            np.modificarPelicula(pelicula);// se envia el objeto con los nuevos valores y se actualiza en la BD

             grdPelis.EditIndex = -1;
             CargarGrid(); // se vuelve a cargar la grilla actualizada 
        }

        protected void grdPelis_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String Id_Pelicula = ((Label)grdPelis.Rows[e.RowIndex].FindControl("lbl_id_peicula")).Text;// se toma en un string el id del producto segun la fila donde se toco el boton eliminar
            pelicula.id_pelicula = Id_Pelicula;
            /*preguntar si seguro que quiere eliminar*/
            if (np.eliminarPelicula(pelicula))
            {
                /*se elimino con exito*/
                CargarGrid();// se carga de nuevo la grilla sin el registro ya eliminado
            }
             
        }
    }
}