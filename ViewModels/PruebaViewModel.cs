using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class PruebaViewModel
    {
        public int ID;
        public string Nombre;
        public string Apellido;
        public string Telefono;

        public string DNI;

        public PruebaViewModel()
        {

        }

        public PruebaViewModel(int ID, string Nombre, string Apellido, string Telefono, string DNI)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;

            this.DNI = DNI;
        }
    }
}
