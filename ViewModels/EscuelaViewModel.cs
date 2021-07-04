using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class EscuelaViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Domicilio { get; set; }
        public string Provincia { get; set; }

        public EscuelaViewModel()
        {
        }

        public EscuelaViewModel(int ID, string Nombre, string Departamento, string Localidad, string Telefono, string Mail, string Domicilio, string Provincia)
        {
            this.ID = ID;
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
