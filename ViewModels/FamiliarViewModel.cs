using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class FamiliarViewModel : PersonaViewModel
    {
        public string Ocupacion { get; set; }
        public string Empresa { get; set; }
        public string Gremio { get; set; }
        public string Telefono { get; set; }

        public FamiliarViewModel() : base()
        {
        }

        public FamiliarViewModel(int ID, string Nombre, string Apellido, string Telefono, string Ocupacion, string Empresa, string Gremio) : 
            base(ID, Nombre, Apellido)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;

            this.Ocupacion = Ocupacion;
            this.Empresa = Empresa;
            this.Gremio = Gremio;
            this.Telefono = Telefono;
        }
    }
}
