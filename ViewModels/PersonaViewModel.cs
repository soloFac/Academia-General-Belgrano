using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class PersonaViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public PersonaViewModel()
        {

        }

        public PersonaViewModel(int ID, string Nombre, string Apellido)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }
    }
}
