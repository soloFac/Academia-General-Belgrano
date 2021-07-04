using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Escuela
    {
        private int iD;
        private string nombre;
        private string domicilio;
        private string telefono;
        private string mail;
        private string localidad;
        private string departamento;
        private string provincia;
        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Provincia { get => provincia; set => provincia = value; }

        public Escuela()
        {
        }

        public Escuela(string Nombre, string Departamento, string Localidad, string Telefono, string Mail, string Domicilio, string Provincia)
        {
            this.Nombre = Nombre;
            this.Departamento = Departamento;
            this.Localidad = Localidad;
            this.Telefono = Telefono;
            this.Mail = Mail;
            this.Domicilio = Domicilio;
            this.Provincia = Provincia;
        }


    }
}
