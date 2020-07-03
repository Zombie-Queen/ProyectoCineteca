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
    }
}
