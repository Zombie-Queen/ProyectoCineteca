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

        public int SeleccionarAsiento(FuncionesxSala fs, FuncionesxSalasxAsiento fsa)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosSeleccionar(ref comando, fs, fsa);
            return ds.sp_Ejecutar(comando, "SP_SeleccionarAsiento");
        }

        public int QuitarAsientoSeleccionado(FuncionesxSalasxAsiento fsa)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosQuitar(ref comando, fsa);
            return ds.sp_Ejecutar(comando, "SP_QuitarAsientoSeleccionado");
        }

        public DataTable ObtenerAsientosDisponibles(FuncionesxSala fs)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAsientosSeleccionados(ref comando, fs);
            dt = ds.EjecutarSpConParametros(comando, "SP_AsientosDisponible", "AsientosDisponibles");
            return dt;
        }

        public DataTable ObtenerAsientosReservados()
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand();
            dt = ds.EjecutarSpConParametros(comando, "SP_AsientosReservado", "AsientosReservados");
            return dt;
        }

        public DataTable ObtenerDatosDetalleVentas()
        {
            DataTable dt = new DataTable();
            dt = ds.ObtenerTabla("DetalleVentas", "SELECT * FROM FuncionesxSalasxAsiento WHERE Estado_FSA='Reservado'");
            return dt;
        }
        public bool ChequearCodigoPromocional(string Promocion, string Codigo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPromocionChequear(ref comando, Promocion, Codigo);
            return ds.chequeo_sp(comando, "SP_ChequearPromocion");
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

        public int ProcesarVenta(string correo, string promocion)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVentaProcesar(ref comando, correo, promocion);
            return ds.sp_Ejecutar(comando, "SP_ProcesarVenta");
        }

        public int ProcesarDetalleVentas(FuncionesxSalasxAsiento fsa, decimal precio)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDetalleVentasProcesar(ref comando, fsa, precio);
            return ds.sp_Ejecutar(comando, "SP_ProcesarDetalleVentas");
        }

        public int ProcesarDetalleVentaArticulos(DetalleVentasArticulo dva)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDetalleVentaArticulosProcesar(ref comando, dva);
            return ds.sp_Ejecutar(comando, "SP_ProcesarDetalleVentaArticulos");
        }

        private void ArmarParametrosAsientosSeleccionar(ref SqlCommand comando, FuncionesxSala fs, FuncionesxSalasxAsiento fsa)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Pelicula", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Pelicula_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Sucursal", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Sucursal_FSA1;
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
            SqlParametros = comando.Parameters.Add("@Horario", SqlDbType.VarChar);
            SqlParametros.Value = fs.Hora_Inicio1;
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.VarChar);
            SqlParametros.Value = fsa.Fecha_FuncionxSalaAsiento1;
        }

        private void ArmarParametrosAsientosSeleccionados(ref SqlCommand comando, FuncionesxSala fs)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Pelicula", SqlDbType.Char);
            SqlParametros.Value = fs.ID_Pelicula1;
            SqlParametros = comando.Parameters.Add("@ID_Sucursal", SqlDbType.Char);
            SqlParametros.Value = fs.ID_Sucursal1;
            SqlParametros = comando.Parameters.Add("@Horario", SqlDbType.VarChar);
            SqlParametros.Value = fs.Hora_Inicio1;
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.VarChar);
            SqlParametros.Value = fs.Fecha1;
        }



        private void ArmarParametrosAsientosQuitar(ref SqlCommand comando, FuncionesxSalasxAsiento fsa)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Asiento", SqlDbType.Char);
            SqlParametros.Value = fsa.ID_Asiento_FSA1;
        }

        private void ArmarParametrosPromocionChequear(ref SqlCommand comando, string promocion, string codigo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Promocion", SqlDbType.Char);
            SqlParametros.Value = promocion;
            SqlParametros = comando.Parameters.Add("@Codigo", SqlDbType.Char);
            SqlParametros.Value = codigo;
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

        private void ArmarParametrosVentaProcesar (ref SqlCommand comando, string correo, string promocion)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Correo_Cliente", SqlDbType.VarChar);
            SqlParametros.Value = correo;
            SqlParametros = comando.Parameters.Add("@ID_Promocion", SqlDbType.VarChar);
            SqlParametros.Value = promocion;
        }

        private void ArmarParametrosDetalleVentasProcesar (ref SqlCommand comando, FuncionesxSalasxAsiento fsa, decimal precio)
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
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.VarChar);
            SqlParametros.Value = fsa.Fecha_FuncionxSalaAsiento1;
            SqlParametros = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            SqlParametros.Value = precio;
        }

        private void ArmarParametrosDetalleVentaArticulosProcesar(ref SqlCommand comando, DetalleVentasArticulo dva)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_Articulo", SqlDbType.Char);
            SqlParametros.Value = dva.id_articulo_dva;
            SqlParametros = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = dva.cantidad;
            SqlParametros = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            SqlParametros.Value = dva.precio;
        }

    }
}
