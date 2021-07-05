using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class CursoViewModel
    {

        public int ID { get; set ; }
        public string Nombre { get ; set ; }
        public int IDGrupo { get ; set ; }

        public CursoViewModel()
        {

        }

        public CursoViewModel(int ID, string Nombre, int IDGrupo)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.IDGrupo = IDGrupo;
        }
    }
}
