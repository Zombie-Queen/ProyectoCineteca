using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
//using Negocios;

namespace Vistas
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*            if (!IsPostBack)
            {
                cargar_ddl_suc();
                cargar_ddl_func();
            }*/
        }

        /*protected void cargar_ddl_suc()
        {
            ddlSuc.DataSource = suc.cargar_sucursal();
            ddlSuc.DataTextField = "Nombre_Sucursal";
            ddlSuc.DataValueField = "Id_Sucursal";
            ddlSuc.DataBind();
            ddlSuc.Items.Insert(0, new ListItem("--Seleccione Sucursal--", "0000"));
            ddlSuc.SelectedValue = "0000";
        }

        protected void cargar_ddl_func()
        {
            ddlFunc.DataSource = func.cargar_funcion();
            ddlFunc.DataTextField = "Título_Pelicula";
            ddlFunc.DataValueField = "ID_Pelicula";
            ddlFunc.DataBind();
            ddlFunc.Items.Insert(0, new ListItem("--Seleccione Película--", "0000"));
            ddlFunc.SelectedValue = "0000";
        }*/

        protected void ddlSuc_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*
            if (ddlFunc.SelectedItem.Value == "0000")
            {
                ddlSuc.SelectedValue = ddlSuc.SelectedItem.Value;
                ddlFunc.DataSource = func.cargar_funcion_sucursal(ddlSuc.SelectedItem.Value);
                ddlFunc.DataTextField = "Título_Pelicula";
                ddlFunc.DataValueField = "ID_Pelicula";
                ddlFunc.DataBind();                
                ddlSuc.DataSource = suc.cargar_sucursal_funcion(ddlFunc.SelectedItem.Value);
                ddlSuc.DataTextField = "Nombre_Sucursal";
                ddlSuc.DataValueField = "Id_Sucursal";
                ddlSuc.DataBind();
            }
        */
        }

        protected void ddlFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (ddlSuc.SelectedItem.Value == "0000")
            {
                ddlFunc.SelectedValue = ddlFunc.SelectedItem.Value;
                ddlSuc.DataSource = suc.cargar_sucursal_funcion(ddlFunc.SelectedItem.Value);
                ddlSuc.DataTextField = "Nombre_Sucursal";
                ddlSuc.DataValueField = "Id_Sucursal";
                ddlSuc.DataBind();
                ddlFunc.DataSource = func.cargar_funcion_sucursal(ddlSuc.SelectedItem.Value);
                ddlFunc.DataTextField = "Título_Pelicula";
                ddlFunc.DataValueField = "ID_Pelicula";
                ddlFunc.DataBind();
            }*/
        }
    }
}