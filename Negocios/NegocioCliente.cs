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
    public class NegocioCliente
    {
        private DaoCliente dao = new DaoCliente();
        private AccesoDatos acc = new AccesoDatos();
        private Cliente cli1;
        
        

        public bool AgregarCliente(Cliente cli)
        {
            int cantFilas = 0;
            cli1 = new Cliente();
            cli1.nombre = cli.nombre;
            cli1.apellido = cli.apellido;
            cli1.dni = cli.dni;
            cli1.contraseña = cli.contraseña;
            cli1.mail = cli.mail;
            cli1.fecha = cli.fecha;            
            if (dao.existeCliente(cli1.dni) == false)
            {
                dao.AgregarCliente(cli1);
            }
            if (cantFilas == 1)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable getRegistroCliente(String correo, String contraseña)
        {
            return dao.getCliente(correo, contraseña);
        }
    }
}
