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
    public class NegocioFinalizarCompra
    {
        public bool realizarVenta()
        {
            DaoFinalizarCompra dao = new DaoFinalizarCompra();
            return dao.RealizarVenta();
        }

        public bool cancelarVenta()
        {
            DaoFinalizarCompra dao = new DaoFinalizarCompra();
            return dao.CancelarVenta();
        }

        public DataTable obtenerDatosArticulosVendidos()
        {
            DaoFinalizarCompra dao = new DaoFinalizarCompra();
            return dao.ObtenerDatosArticulosVendidos();
        }

        public bool disminuirStock(DetalleVentasArticulo dva)
        {
            DaoFinalizarCompra dao = new DaoFinalizarCompra();
            return dao.DisminuirStock(dva);
        }

        public bool actualizarEstadoAsientos()
        {
            DaoFinalizarCompra dao = new DaoFinalizarCompra();
            return dao.ActualizarEstadoAsientos();
        }
        
        public bool vaciarAsientosReservados()
        {
            DaoFinalizarCompra dao = new DaoFinalizarCompra();
            return dao.VaciarAsientosReservados();
        }
    }
}
