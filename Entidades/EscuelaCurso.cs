using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class EscuelaCurso
    {
        private int iD;
        private string nombre;
        private int iDCurso;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IDCurso { get => iDCurso; set => iDCurso = value; }

        public EscuelaCurso()
        {

        }

        public EscuelaCurso(int ID, string Nombre, int IDCurso)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.IDCurso = IDCurso;
        }
    }
}
