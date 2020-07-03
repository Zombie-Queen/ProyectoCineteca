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
    }
}
