using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class EstablecimientoAcademicoViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public EstablecimientoAcademicoViewModel()
        {

        }

        public EstablecimientoAcademicoViewModel(int ID, string Nombre)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}
