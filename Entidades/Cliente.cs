using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private String Dni;
        private String Estado_Cliente;
        private String Nombre;
        private String Apellido;
        private String Contraseña;
        private DateTime FechaNac;
        private String Mail;

        public Cliente() { }

        public Cliente(String _Nombre, String _Apellido, String _Dni, String _Contraseña, DateTime _fecha, String _Mail)
        {
            FechaNac.ToShortDateString();
            this.Dni = _Dni;
            this.Estado_Cliente = "Activo";
            this.Nombre = _Nombre;
            this.Apellido = _Apellido;
            this.Contraseña = _Contraseña;
            this.FechaNac = _fecha;
            this.Mail = _Mail;

        }

        public String dni
        {
            get { return Dni; }
            set { Dni = value; }
        }

        public String estado_cliente
        {
            get { return Estado_Cliente; }
            set { Estado_Cliente = value; }
        }
        public String nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public String apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }

        public String contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }
        public DateTime fecha
        {

            get { return FechaNac; }
            set { FechaNac = value; }
        }

        public String mail
        {
            get { return Mail; }
            set { Mail = value; }
        }
    }
}
