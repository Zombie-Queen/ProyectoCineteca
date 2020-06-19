using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;

namespace Negocios
{
    public class NegociosArticulos
    {
        DaoArticulos dao = new DaoArticulos();
        public DataTable getTabla()
        {
            return dao.ObtenerTodasLosArticulos();
        }
    }
}
