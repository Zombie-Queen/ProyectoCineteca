using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoDetalleDeVenta
    {
        AccesoDatos ds = new AccesoDatos();
        /*sp detalles de ventas */ 
        /*sp detalle de venta articulos */
        public const String sp_totalDva_dni = "sp_totalDva_dni"; /*Suma total detalle de ventas de articulos por dni*/
        public const String sp_totalDva_dninv = "sp_totalDva_dninv"; /*Suma total detalle de ventas de articulos por dni y numero de venta*/
        /*sp detalle de ventas*/
        public const String sp_totalDv_dni = "sp_totalDv_dni"; /*Suma total detalle de ventas por dni*/
        public const String sp_totalDetalleVenta_nv = "sp_totalDetalleVenta_nv"; /*Suma total detalle de ventas por nro venta*/
        public const String sp_totalDv_dninv = "sp_totalDv_dninv"; /*Suma total detalle de ventas por dni y numero de venta*/

        /*sp total ventas*/
        public const String sp_totalventa_dni = "sp_totalventa_dni";
        public const String sp_totalventa_NroVenta = "sp_totalventa_NroVenta";
        public const String sp_totalventa_dninv = "sp_totalventa_dninv";

        /*sp baja logica de detalla de ventas*/
        public const String sp_BajaLogicaDetalleVentaArt = "sp_BajaLogicaDetalleVentaArt";
        public const String sp_BajaLogicaDetalleVenta = "sp_BajaLogicaDetalleVenta";

        public DataTable ObtenerTodosLosDetallesDeVenta()
        {
            return ds.ObtenerTabla("DetalleVentas", "Select * from DetalleVentas");
        }

        public DataTable ObtenerTodosLosDetallesDeVentaArts()
        {
            return ds.ObtenerTabla("DetalleVentaArticulos", "Select * from DetalleVentaArticulos");
        }

        /*Detalles de ventas por nro de venta */
        public DataTable ObtenerDetallaVenta_numVen(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);

            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula[PELICULA], s.Nombre_Sucursal[SUCURSAL] , dv.ID_Sala_DV[SALA], dv.ID_Asiento_DV[SIENTO],dv.Precio[PRECIO] " +
                "FROM DetalleVentas dv INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE dv.ID_Venta_DV = " + n_venta + "");
        }
        public DataTable ObtenerDetalleVentaArticulos_numVen(String nroVenta)
        {

            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo[ARTICULO], dva.Cantidad[CANTIDAD], dva.Precio[PRECIO]" +
                " From DetalleVentaArticulos dva INNER JOIN Articulos a on a.ID_Articulo = dva.ID_Articulo_DVA " +
                "WHERE dva.ID_Venta_DVA =" + n_venta + "");

        }

        /*Detalles de ventas por dni */
        public DataTable ObtenerDetalleVentas_dni(String dni)
        {

            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula, s.Nombre_Sucursal , dv.ID_Sala_DV, dv.ID_Asiento_DV,dv.Precio " +
                "FROM DetalleVentas dv INNER JOIN Ventas v on v.ID_Venta = dv.ID_Venta_DV " +
                "INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE dv.ID_Venta_DV = ID_Venta AND v.DNI_Cliente_Venta = " + dni + "");
        }

        public DataTable ObtenerDetalleVentasArts_dni(String dni)
        {

            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo, dva.Cantidad, dva.Precio " +
                "From DetalleVentaArticulos dva INNER JOIN Articulos a on a.ID_Articulo = dva.ID_Articulo_DVA" +
                " INNER JOIN Ventas v on v.ID_Venta = dva.ID_Venta_DVA WHERE v.DNI_Cliente_Venta = " + dni + "");

        }
        /*Detalles de ventas por nro de venta y dni */
        public DataTable ObtenerDetalleVentasArts_Dni_NumVen(String dni, String nroVenta)
        {

            int n_venta = Convert.ToInt32(nroVenta);

            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo, dva.Cantidad, dva.Precio " +
                "From DetalleVentaArticulos dva INNER JOIN Articulos a on a.ID_Articulo = dva.ID_Articulo_DVA " +
                "INNER JOIN Ventas v on v.ID_Venta = dva.ID_Venta_DVA " +
                "WHERE v.DNI_Cliente_Venta = " + dni + " AND dva.ID_Venta_DVA = " + n_venta + "");

        }

        public DataTable ObtenerDetalleVentas_Dni_NumVen(String dni, String nroVenta)
        {

            int n_venta = Convert.ToInt32(nroVenta);


            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula, s.Nombre_Sucursal , dv.ID_Sala_DV, dv.ID_Asiento_DV,dv.Precio " +
                "FROM DetalleVentas dv INNER JOIN Ventas v on v.ID_Venta = dv.ID_Venta_DV " +
                "INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE v.DNI_Cliente_Venta = " + dni + " AND dv.ID_Venta_DV = " + n_venta + "");


        }
        /* suma de los detalles de ventas */

        /* detalle de articulos */
        /* suma detalle de venta articulos por nro de venta */
        public DataTable SumaDetalleVentasArts_NumVen(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT SUM(Precio*Cantidad)as[Total]From DetalleVentaArticulos dva " +
                "WHERE dva.ID_Venta_DVA = " + n_venta + "");

        }

        /* suma detalle de venta articulos por dni */
        public DataTable SumaDetalleVentasArts_Dni(String dni)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = dni;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDva_dni, "DetalleVentaArticulo");
            return dt;


        }

        /* suma detalle de venta articulos por nro de venta y dni */
        private void parametrosSumarDetalleVentasArts(ref SqlCommand Comando, Usuario cli, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = cli.dni;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaDetalleVentasArts_Dni_NumVen(String dni, String numVenta)
        {
            Usuario cli = new Usuario();
            Ventas ven = new Ventas();
            cli.dni = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosSumarDetalleVentasArts(ref Comando, cli, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDva_dninv, "DetalleVentaArticulo");
            return dt;
        }

        /* detalle de ventas*/

        /* suma detalle de venta por dni */
        public DataTable sumaDetalleVenta_Dni(String dni)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = dni;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDv_dni, "DetalleVentas");
            return dt;


        }

        /* suma detalle de venta por nro venta */
        public DataTable SumaDetalleVenta_numVen(String nroVenta)
        {
            int id_venta = Convert.ToInt32(nroVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = id_venta;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDetalleVenta_nv, "DetalleVentas");
            return dt;


        }

        /* suma detalle de venta por nro de venta y dni */
        private void parametrosSumarDetalleVenta(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaDetalleVenta_Dni_NumVen(String dni, String numVenta)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosSumarDetalleVenta(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDv_dninv, "DetalleVentas");
            return dt;
        }


        /* suma total de la venta */

        public DataTable SumaTotalVenta_Dni(String dni)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = dni;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_dni, "Ventas");
            return dt;
        }

        /* suma total venta por nro venta */
        public DataTable SumaTotalVenta_NumVen(String nroVenta)
        {
            int id_venta = Convert.ToInt32(nroVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = id_venta;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_NroVenta, "Ventas");
            return dt;


        }

        /* suma total venta por nro de venta y dni */
        private void parametrosSumarTotalVenta(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaTotalVenta_DniNumVen(String dni, String numVenta)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosSumarTotalVenta(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_dninv, "Ventas");
            return dt;
        }


        
        /*DELETE DETALLE DE VENTAS*/
        private void armarParametrosDetalleVentas(ref SqlCommand Comando, DetalleVentas dev)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = dev.id_venta_dv;
            /*parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = dev.estado;*/


        }

        // baja detalle de venta de manera logica 
        public bool BajaDetalleVentas(DetalleVentas dev)
        {
            SqlCommand Comando = new SqlCommand();
            armarParametrosDetalleVentas(ref Comando, dev);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_BajaLogicaDetalleVenta);
            if (filas >= 1)
                return true;
            else
                return false;
        }
        private void armarParametrosDetalleVentaArticulos(ref SqlCommand Comando, DetalleVentasArticulo devArt)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = devArt.id_venta_dva;
            /*parametros = Comando.Parameters.Add("@estado", SqlDbType.VarChar, 20);
            parametros.Value = ven.estado;*/


        }

        // baja de la detalle de venta articulos de manera logica 
        public bool BajaDetalleVentaArticulos(DetalleVentasArticulo devArt)
        {
            SqlCommand Comando = new SqlCommand();
            armarParametrosDetalleVentaArticulos(ref Comando, devArt);
            AccesoDatos ad = new AccesoDatos();
            int filas = ad.sp_Ejecutar(Comando, sp_BajaLogicaDetalleVentaArt);
            if (filas >= 1)
                return true;
            else
                return false;
        }
    }
}
