using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Vistas
{
    public partial class FuncionesPelicula : System.Web.UI.Page
    {
        NegocioSucursal ns = new NegocioSucursal();
        NegocioTSala nts = new NegocioTSala();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*lbl.Text = Session["ID_Funcion"].ToString();*/
                cargar_ddl_suc();
                cargar_ddl_sala();
            }
        }

        protected void cargar_ddl_suc()
        {
            ddlSucs.DataSource = ns.getSucursalPelicula(Session["ID_Funcion"].ToString());
            ddlSucs.DataTextField = "Nombre_Sucursal";
            ddlSucs.DataValueField = "Id_Sucursal";
            ddlSucs.DataBind();
            ddlSucs.Items.Insert(0, new ListItem("--Seleccione Sucursal--", "0000"));
            ddlSucs.SelectedValue = "0000";
        }

        protected void cargar_ddl_sala()
        {
            ddlSala.Items.Insert(0, new ListItem("--Seleccione Tipo de Sala--", "0000"));
            ddlSala.SelectedValue = "0000";
        }

        protected void ddlSucs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSala.DataSource = nts.getTSala(Session["ID_Funcion"].ToString(), ddlSucs.SelectedItem.Value);
            ddlSala.DataTextField = "Descripcion_TipoSala";
            ddlSala.DataValueField = "ID_TipoSala";
            ddlSala.DataBind();
            if (ddlSucs.SelectedItem.Value != "0000" && ddlSala.SelectedItem.Value != "0000")
            {
                Session["ID_Suc"] = ddlSucs.SelectedItem.Value;
                Session["ID_t_Sala"] = ddlSala.SelectedItem.Value;
            }
        }
    }
}