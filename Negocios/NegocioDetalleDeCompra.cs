using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;

namespace Negocios
{
    public class NegocioDetalleDeCompra
    {
        public bool seleccionarAsiento(FuncionesxSala fs, string asiento)
        {
            int cantFilas = 0;

            FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
            fsa.ID_Pelicula_FSA1 = fs.ID_Pelicula1;
            fsa.ID_Sucursal_FSA1 = fs.ID_Sucursal1;
            fsa.ID_Asiento_FSA1 = asiento;
            fsa.Fecha_FuncionxSalaAsiento1 = fs.Fecha1;

            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            cantFilas = dao.SeleccionarAsiento(fs, fsa);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool quitarAsientoSeleccionado(string asiento)
        {
            FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
            fsa.ID_Asiento_FSA1 = asiento;

            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();

            int op = dao.QuitarAsientoSeleccionado(fsa);
            if (op == 1)
                return true;
            else
                return false;
        }

        public DataTable obtenerAsientosDisponibles(FuncionesxSala fs)
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            return dao.ObtenerAsientosDisponibles(fs);
        }

        public DataTable obtenerAsientosReservados()
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            return dao.ObtenerAsientosReservados();
        }

        public DataTable obtenerDatosDetalleVentas()
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            return dao.ObtenerDatosDetalleVentas();
        }

        public bool chequearCodigoPromocional(string Promocion, string Codigo)
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            return dao.ChequearCodigoPromocional(Promocion, Codigo);
        }

        public DataTable cargarddlStock(String Stock)
        {
            if (Stock=="") { Stock = "0"; }
            DataTable dt = new DataTable();
            dt.Columns.Add("Stock_ddl");
            int max = Convert.ToInt32(Stock);

            for (int i = 0; i <= max; i++)
            {
                if (i <= 10)
                {
                    var dr = dt.NewRow();

                    dr["Stock_ddl"] = i;

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public bool seleccionarArticulo(int id_venta, int id_dva, string id_articulo, string estado, int cantidad, decimal precio)
        {
            int cantFilas = 0;

            DetalleVentasArticulo dva = new DetalleVentasArticulo();
            dva.id_venta_dva = id_venta;
            dva.id_dv_articulo = id_dva;
            dva.id_articulo_dva = id_articulo;
            dva.estado = estado;
            dva.cantidad = cantidad;
            dva.precio = precio;

            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            cantFilas = dao.SeleccionarArticulo(dva);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool quitarArticuloSeleccionado(int id_venta, int id_dva, string id_articulo)
        {
            DetalleVentasArticulo dva = new DetalleVentasArticulo();
            dva.id_venta_dva = id_venta;
            dva.id_dv_articulo = id_dva;
            dva.id_articulo_dva = id_articulo;

            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();

            int op = dao.QuitarArticuloSeleccionado(dva);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool procesarVenta(string correo, string promocion)
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            int op = dao.ProcesarVenta(correo, promocion);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool procesarDetalleVentas(FuncionesxSalasxAsiento fsa, decimal precio)
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            int op = dao.ProcesarDetalleVentas(fsa, precio);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool procesarDetalleVentaArticulos(DetalleVentasArticulo dva)
        {
            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            int op = dao.ProcesarDetalleVentaArticulos(dva);
            if (op == 1)
                return true;
            else
                return false;
        }
    }
}
