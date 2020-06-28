using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Negocios
{
    public class NegociosDetalleDeVenta
    {
        DaoDetalleDeVenta dao = new DaoDetalleDeVenta();

        /*Negocios Det venta*/
        public DataTable getTablaDetalleDeVenta ()
        {
            return dao.ObtenerTodosLosDetallesDeVenta();
        }
        public DataTable getTablaDetalleDeVentaArticulos()
        {
            return dao.ObtenerTodosLosDetallesDeVentaArts();
        }
        public DataTable getDetalleArt_porNroVenta(DetalleVentasArticulo detalle_art)
        {
            return dao.ObtenerDVAPorNroVenta(detalle_art);
        }
        public DataTable getDetalleVenta_porNroVenta(DetalleVentas detalle_venta)
        {
            return dao.ObtenerDVPorNroVenta(detalle_venta);
        }

        public DataTable getTablaDetalleVenta_NroVenta(String nroVenta)
        {
            return dao.ObtenerDetallaVenta_numVen(nroVenta);
        }

        public DataTable getTablaDetalleVentaArts_NroVenta(String nroVenta)
        {
            return dao.ObtenerDetalleVentaArticulos_numVen(nroVenta);
        }

        public DataTable getTablaTotalDetalleVenta_NroVenta(String nroVenta)
        {
            return dao.SumaDetalleVenta_numVen(nroVenta);
        }
        public DataTable getTablaTotalDetalleVentaArt_NroVenta(String nroVenta)
        {
            return dao.SumaDetalleVentasArts_NumVen(nroVenta);
        }
        public DataTable getTablaTotalVenta_NroVenta(String nroVenta)
        {
            return dao.SumaTotalVenta_NumVen(nroVenta);
        }

        /*Baja logica de detalles de venta*/
        public bool BorrarDetalleVenta(DetalleVentas dev)
        {


            if (dao.BajaDetalleVentas(dev))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool BorrarDetalleVentaArticulos(DetalleVentasArticulo devArt)
        {


            if (dao.BajaDetalleVentaArticulos(devArt))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
