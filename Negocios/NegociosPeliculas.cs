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
    
    public class NegociosPeliculas
    {
        DaoPeliculas dao = new DaoPeliculas();
        public DataTable getTabla()
        {
            return dao.ObtenerTodasLasPeliculas();
        }
    }
}
