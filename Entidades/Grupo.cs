using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Grupo
    {
        private int iD;
        private string nombre;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Grupo()
        {

        }

        public Grupo(int ID, string Nombre)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}

