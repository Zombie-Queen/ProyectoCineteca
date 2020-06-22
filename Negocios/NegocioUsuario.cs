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
    public class NegocioUsuario
    {
        private DaoUsuario dao = new DaoUsuario();        
        private Usuario cli1;        
        

        public bool AgregarCliente(Usuario cli)
        {
            int cantFilas = 0;
            cli1 = new Usuario();
            cli1.nombre = cli.nombre;
            cli1.apellido = cli.apellido;
            cli1.dni = cli.dni;
            cli1.contraseña = cli.contraseña;
            cli1.mail = cli.mail;
            cli1.fecha = cli.fecha;            
            if (dao.existeUsuario(cli1.dni) == false)
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

        public DataTable getRegistroUsuario(String correo, String contraseña)
        {
            return dao.getUsuario(correo, contraseña);
        }
    }
}
