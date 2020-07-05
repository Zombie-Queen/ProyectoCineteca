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

        public DataTable getTabla_idArticulo(Articulos ar)
        {
            return dao.ObtenerArticulo_id(ar);
        }



        public bool agregarArticulo(Articulos art)
        {
            int filas = 0;
            filas = dao.agregarArticulo(art);

            if (filas == 1) return true;
            else return false;

        }

        public bool existeArticulo(Articulos art)
        {
            if (dao.existe_articulo(art)) return true;
            else return false;

        }

        public bool eliminarArticulo(Articulos art)
        {
            if (dao.eliminar_articulo(art)) return true;
            else return false;
        }
        public bool modificarArticulo(Articulos art)
        {
            if (dao.actualizarArticulo(art)) return true;
            else return false;
        }
    }
}
