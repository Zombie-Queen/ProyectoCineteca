using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoFinalizarCompra
    {
        AccesoDatos ds = new AccesoDatos();

        public bool RealizarVenta()
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosRealizarVenta(ref comando);
            return ds.chequeo_sp(comando, "SP_FinalizarVenta");
        }

        public bool CancelarVenta()
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCancelarVenta(ref comando);
            return ds.chequeo_sp(comando, "SP_FinalizarVenta");
        }

        public DataTable ObtenerDatosArticulosVendidos()
        {
            DataTable dt = new DataTable();
            dt = ds.ObtenerTabla("ArticulosVendidos", "SELECT ID_Articulo_DVA, Cantidad FROM DetalleVentaArticulos WHERE ID_Venta_DVA= (SELECT MAX(ID_Venta) FROM Ventas)");
            return dt;
        }

        public bool DisminuirStock(DetalleVentasArticulo dva)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosStockDisminuir(ref comando, dva);
            return ds.chequeo_sp(comando, "SP_DisminuirStock");
        }

        public bool ActualizarEstadoAsientos()
        {
            SqlCommand comando = new SqlCommand();
            return ds.chequeo_sp(comando, "SP_ActualizarEstadoAsientos");
        }

        public bool VaciarAsientosReservados()
        {
            SqlCommand comando = new SqlCommand();
            return ds.chequeo_sp(comando, "SP_VaciarReservas");
        }

        private void ArmarParametrosRealizarVenta(ref SqlCommand comando)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = "Realizada";
        }

        private void ArmarParametrosCancelarVenta(ref SqlCommand comando)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = "Cancelada";
        }

        private void ArmarParametrosStockDisminuir(ref SqlCommand comando, DetalleVentasArticulo dva)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Articulo", SqlDbType.Char);
            SqlParametros.Value = dva.id_articulo_dva;
            SqlParametros = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = dva.cantidad;
        }
    }
}
