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
    public class DaoPeliculas
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable ObtenerTodasLasPeliculas()
        {
            return ds.ObtenerTabla("Peliculas", "Select ID_Pelicula[Pelicula],ID_Estado_Pelicula[Estado],Título_Pelicula[Título],Duración_Pelicula[Duración],Clasificación_Pelicula[Clasificación],URL_Portada[Url imagen] From Peliculas");
        }
    }
}
