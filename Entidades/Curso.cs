using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Curso
    {
        private int iD;
        private string nombre;
        private int iDGrupo;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IDGrupo { get => iDGrupo; set => iDGrupo = value; }

        public Curso()
        {

        }

        public Curso(int ID, string Nombre, int IDGrupo)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.IDGrupo = IDGrupo;
        }
    }
}
