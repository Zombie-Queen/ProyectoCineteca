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
    public class DaoDetalleDeCompra
    {
        AccesoDatos ds = new AccesoDatos();

        public int SeleccionarAsiento(FuncionesxSalasxAsiento fsa)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosSeleccionar(ref comando, fsa);
            return ds.sp_Ejecutar(comando, "SP_SeleccionarAsiento");
        }

        public int QuitarAsientoSeleccionado(FuncionesxSalasxAsiento fsa)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosQuitar (ref comando, fsa);
            return ds.sp_Ejecutar(comando, "SP_QuitarAsientoSeleccionado");
        }

        public int SeleccionarArticulo(DetalleVentasArticulo dva)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosArticulosSeleccionar(ref comando, dva);
            return ds.sp_Ejecutar(comando, "SP_SeleccionarArticulo");
        }

        public int QuitarArticuloSeleccionado(DetalleVentasArticulo dva)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosArticulosQuitar(ref comando, dva);
            return ds.sp_Ejecutar(comando, "SP_QuitarArticuloSeleccionado");
        }


        private void ArmarParametrosAsientosSeleccionar(ref SqlCommand comando, FuncionesxSalasxAsiento fsa)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Funcion", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Funcion_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Pelicula", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Pelicula_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Sucursal", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Sucursal_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Sala", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Sala_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = fsa.Estado_FSA1;
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.Date);
            SqlParametros.Value = fsa.Fecha_FuncionxSalaAsiento1;
        }

        private void ArmarParametrosAsientosQuitar(ref SqlCommand comando, FuncionesxSalasxAsiento fsa)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = fsa.Estado_FSA1;
        }

        private void ArmarParametrosArticulosSeleccionar(ref SqlCommand comando, DetalleVentasArticulo dva)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Venta", SqlDbType.Int);
            SqlParametros.Value = dva.id_venta_dva;
            SqlParametros = comando.Parameters.Add("@ID_DVA", SqlDbType.Int);
            SqlParametros.Value = dva.id_dv_articulo;
            SqlParametros = comando.Parameters.Add("@ID_Articulo", SqlDbType.Char);
            SqlParametros.Value = dva.id_articulo_dva;
            SqlParametros = comando.Parameters.Add("@Estado", SqlDbType.VarChar);
            SqlParametros.Value = dva.estado;
            SqlParametros = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = dva.cantidad;
            SqlParametros = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            SqlParametros.Value = dva.precio;
        }

        private void ArmarParametrosArticulosQuitar(ref SqlCommand comando, DetalleVentasArticulo dva)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Venta", SqlDbType.Int);
            SqlParametros.Value = dva.id_venta_dva;
            SqlParametros = comando.Parameters.Add("@ID_DVA", SqlDbType.Int);
            SqlParametros.Value = dva.id_dv_articulo;
            SqlParametros = comando.Parameters.Add("@ID_Articulo", SqlDbType.Char);
            SqlParametros.Value = dva.id_articulo_dva;
        }
    }
    }
