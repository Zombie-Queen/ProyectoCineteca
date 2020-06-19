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
    public class DaoVentas
    {
        AccesoDatos ds = new AccesoDatos();
        /*sp ventas*/
        public const String sp_ventas_Fecha = "sp_ventas_Fecha";
        public const String sp_ventas_DniNroVenta = "sp_ventas_DniNroVenta";
        public const String sp_ventas_DniFecha = "sp_ventas_DniFecha";
        public const String sp_ventas_NroVentaFecha = "sp_ventas_NroVentaFecha";

        public const String sp_ventas_DniNroVentaFecha = "sp_ventas_DniNroVentaFecha";

        /*sp detalle de venta articulos */
        public const String sp_totalDva_dni = "sp_totalDva_dni"; /*Suma total detalle de ventas de articulos por dni*/
        public const String sp_totalDva_dninv = "sp_totalDva_dninv"; /*Suma total detalle de ventas de articulos por dni y numero de venta*/
        /*sp detalle de ventas*/
        public const String sp_totalDv_dni = "sp_totalDv_dni"; /*Suma total detalle de ventas por dni*/
        public const String sp_totalDv_nv = "sp_totalDv_nv"; /*Suma total detalle de ventas por nro venta*/
        public const String sp_totalDv_dninv = "sp_totalDv_dninv"; /*Suma total detalle de ventas por dni y numero de venta*/

        /*sp total ventas*/
        public const String sp_totalventa_dni = "sp_totalventa_dni";
        public const String sp_totalventa_nv = "sp_totalventa_nv";
        public const String sp_totalventa_dninv = "sp_totalventa_dninv";




        public DataTable ObtenerTodasLasVentas()
        {
            return ds.ObtenerTabla("Ventas", "Select * from Ventas");
        }
        public DataTable ObtenerVentaPorDni(String Dni)
        {

            return ds.ObtenerTabla("Ventas", "Select * from Ventas WHERE DNI_Cliente_Venta=" + Dni + "");
        }

        public DataTable ObtenerVentaPorNroVenta(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("Ventas", "Select * from Ventas WHERE ID_Venta=" + n_venta + "");
        }
        public DataTable ObtenerVentasPorSucursal(String Sucursal)
        {

            return ds.ObtenerTabla("Ventas", "Select * From Ventas v INNER JOIN DetalleVentas dv on dv.ID_Venta_DV = v.ID_Venta" +
                " INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE s.ID_Sucursal = " + Sucursal + "");
        }

        public DataTable ObtenerVentasPorFecha(DateTime fecha)
        {

            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = fecha;
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_Fecha, "Ventas");
            return dt;
        }
        private void parametrosVentasDniNroVenta (ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable ObtenerVentasPor_Dni_NumVen(String dni, String numVenta)
        {
            
            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(numVenta);
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentasDniNroVenta(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_DniNroVenta, "Ventas");
            return dt;
        }


        private void parametrosVentasDniFecha (ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = ven.fecha;

        }

        public DataTable ObtenerVentasPor_Dni_Fecha(String dni, DateTime fecha)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.fecha = fecha;
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentasDniFecha(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_DniFecha, "Ventas");
            return dt;
        }
        private void parametrosVentas_NroVenta_Fecha (ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta;

            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = ven.fecha;

        }

        public DataTable ObtenerVentasPor_NroVenta_Fecha (String nroVenta, DateTime fecha)
        {
            
            Ventas ven = new Ventas();
            ven.id_venta = Convert.ToInt32(nroVenta);
            ven.fecha = fecha;
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentas_NroVenta_Fecha(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_NroVentaFecha, "Ventas");
            return dt;
        }

        private void parametrosVentasDni_NroVenta_Fecha(ref SqlCommand Comando, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char,8);
            parametros.Value = ven.dni_cliente;

            parametros = Comando.Parameters.Add("@id", SqlDbType.Int);
            parametros.Value = ven.id_venta; 

            parametros = Comando.Parameters.Add("@fecha", SqlDbType.Date);
            parametros.Value = ven.fecha;

        }

        public DataTable ObtenerVentasPorDni_NroVenta_Fecha(String dni,String nroVenta, DateTime fecha)
        {

            Ventas ven = new Ventas();
            ven.dni_cliente = dni;
            ven.id_venta = Convert.ToInt32(nroVenta);
            ven.fecha = fecha;
            SqlCommand Comando = new SqlCommand();
            AccesoDatos ad = new AccesoDatos();
            DataTable dt = new DataTable();
            parametrosVentasDni_NroVenta_Fecha(ref Comando, ven);
            dt = ad.EjecutarSpConParametros(Comando, sp_ventas_DniNroVentaFecha, "Ventas");
            return dt;
        }




        
        /*Detalles de ventas por nro de venta */
        public DataTable ObtenerDetallaVenta_numVen(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);

            return ds.ObtenerTabla("DetalleVentas", "SELECT p.Título_Pelicula, s.Nombre_Sucursal , dv.ID_Sala_DV, dv.ID_Asiento_DV,dv.Precio " +
                "FROM DetalleVentas dv INNER JOIN Peliculas p on p.ID_Pelicula = dv.ID_Pelicula_DV " +
                "INNER JOIN Sucursales s on s.ID_Sucursal = dv.ID_Sucursal_DV WHERE dv.ID_Venta_DV = " + n_venta + "");
        }
        public DataTable ObtenerDetalleVentaArticulos_numVen(String nroVenta)
        {
            int n_venta = Convert.ToInt32(nroVenta);
            return ds.ObtenerTabla("DetalleVentaArticulos", "SELECT dva.ID_DVA, a.Nombre_Articulo, dva.Cantidad, dva.Precio" +
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
        private void parametrosSumarDetalleVentasArts(ref SqlCommand Comando, Cliente cli, Ventas ven)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@dni", SqlDbType.Char, 8);
            parametros.Value = cli.dni;

            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = ven.id_venta;

        }

        public DataTable SumaDetalleVentasArts_Dni_NumVen(String dni, String numVenta)
        {
            Cliente cli = new Cliente();
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
            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = id_venta;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalDv_nv, "DetalleVentas");
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
            parametros = Comando.Parameters.Add("@nro_venta", SqlDbType.Int);
            parametros.Value = id_venta;
            dt = ad.EjecutarSpConParametros(Comando, sp_totalventa_nv, "Ventas");
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

    }
}
