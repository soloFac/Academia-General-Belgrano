using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class EscuelaCursoViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IDCurso { get; set; }
        public decimal Precio { get; set; }
        public int Precio_Inscripcion { get; set; }
        public bool Oficial { get; set; }

        public EscuelaCursoViewModel()
        {

        }

        public EscuelaCursoViewModel(int ID, string Nombre, int IDCurso)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.IDCurso = IDCurso;
        }
    }
}
