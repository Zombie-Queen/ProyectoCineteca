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
        FuncionesxSala fs = new FuncionesxSala();
        NegocioFuncionxSala nfs = new NegocioFuncionxSala();


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
            ddlSucs.DataSource = ns.getSucursalPelicula(Session["ID_Pelicula"].ToString());
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
            ddlSala.DataSource = nts.getTSala(Session["ID_Pelicula"].ToString(), ddlSucs.SelectedItem.Value);
            ddlSala.DataTextField = "Descripcion_TipoSala";
            ddlSala.DataValueField = "ID_TipoSala";
            ddlSala.DataBind();
            if (ddlSucs.SelectedItem.Value != "0000" && ddlSala.SelectedItem.Value != "0000")
            {
                Session["ID_Sucursal"] = ddlSucs.SelectedItem.Value;
                Session["ID_t_Sala"] = ddlSala.SelectedItem.Value;
            }
        }

        protected void gvSuc_SelectedIndexChanged(object sender, EventArgs e)
        {            
            GridViewRow row = gvSuc.SelectedRow;
            string Fecha = Convert.ToString(gvSuc.DataKeys[row.RowIndex].Values[0]);
            string Hora = Convert.ToString(gvSuc.DataKeys[row.RowIndex].Values[1]);
            string Precio = Convert.ToString(gvSuc.DataKeys[row.RowIndex].Values[2]);

            fs.Fecha1 = Fecha;
            fs.Hora_Inicio1 = Hora;
            fs.Precio1 = Convert.ToDecimal(Precio);

            Session["Fecha"] = fs.Fecha1;
            Session["Horario"] = fs.Hora_Inicio1;
            Session["Precio"] = fs.Precio1;

            nfs.vaciarReservasAnteriores();
            Response.Redirect("DetalledeCompra.aspx");
        }
    }
}