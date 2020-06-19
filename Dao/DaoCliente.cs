using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoCliente
    {
        private AccesoDatos acc = new AccesoDatos();
        private Cliente cli = new Cliente();
        private String consulta;
        SqlCommand comando;


        private void armarParametrosAgregarCliente(ref SqlCommand Comando, Cliente cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
            parametros.Value = cli.nombre;
            parametros = Comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 30);
            parametros.Value = cli.apellido;
            parametros = Comando.Parameters.Add("@Dni", SqlDbType.Char, 8);
            parametros.Value = cli.dni;
            parametros = Comando.Parameters.Add("@Contraseña", SqlDbType.Char, 30);
            parametros.Value = cli.contraseña;
            parametros = Comando.Parameters.Add("@Correo", SqlDbType.VarChar, 30);
            parametros.Value = cli.mail;
            parametros = Comando.Parameters.Add("@Fecha", SqlDbType.Date);
            parametros.Value = cli.fecha;
        }

        public int AgregarCliente(Cliente cli)
        {
            comando = new SqlCommand();
            armarParametrosAgregarCliente(ref comando, cli);
            return acc.sp_Ejecutar(comando, "spAgregarCliente");
        }

        public bool existeCliente(String dni)
        {
            consulta = "SELECT * FROM Clientes WHERE DNI_Cliente = '" + dni + "'";
            return acc.existe(consulta);
        }

        public DataTable getCliente(String correo, String contraseña)
        {
            consulta = "SELECT * FROM Clientes WHERE Correo = '" + correo + "' AND " +
            "Contraseña = '" + contraseña + "'";
            return (acc.ObtenerTabla("Registro", consulta));
        }
    }
}
