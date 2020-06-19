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
    public class DaoArticulos
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable ObtenerTodasLosArticulos()
        {
            return ds.ObtenerTabla("Articulos", "SELECT ID_Articulo[ID Articulo], Estado_Articulo[Estado],Nombre_Articulo[Nombre],Descripción_Articulo[Descripción],Precio[Precio],URL_Articulo[Url artículo] From Articulos");
        }
    }
}
