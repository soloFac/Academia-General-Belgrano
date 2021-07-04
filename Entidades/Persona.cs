using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Persona
    {
        private int iD;
        private string nombre;
        private string apellido;



        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }


        public Persona()
        {
        }

        public Persona(int ID, string Nombre, string Apellido)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }


    }
}
