using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;

namespace Negocios
{
    public class NegocioDetalleDeCompra
    {
        public bool seleccionarAsiento(String funcion, String pelicula, String sucursal, String sala, String asiento, String estado, DateTime fecha)
        {
            int cantFilas = 0;

            FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
            fsa.ID_Funcion_FSA1 = funcion;
            fsa.ID_Pelicula_FSA1 = pelicula;
            fsa.ID_Sucursal_FSA1 = sucursal;
            fsa.ID_Sala_FSA1 = sala;
            fsa.ID_Asiento_FSA1 = asiento;
            fsa.Estado_FSA1 = estado;
            fsa.Fecha_FuncionxSalaAsiento1 = fecha;

            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();
            cantFilas = dao.SeleccionarAsiento(fsa);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool quitarAsientoSeleccionado (String asiento, String estado)
        {
            FuncionesxSalasxAsiento fsa = new FuncionesxSalasxAsiento();
            fsa.ID_Asiento_FSA1 = asiento;
            fsa.Estado_FSA1 = estado;

            DaoDetalleDeCompra dao = new DaoDetalleDeCompra();

            int op = dao.QuitarAsientoSeleccionado(fsa);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool seleccionarArticulo(int id_venta, int id_dva, String id_articulo, String estado, int cantidad, decimal precio)
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

        public bool quitarArticuloSeleccionado (int id_venta, int id_dva, String id_articulo)
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
    }
}
