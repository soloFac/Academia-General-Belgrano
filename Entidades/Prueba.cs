using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Prueba
    {
        private string apellido;


        public string Apellido { get => apellido; set => apellido = value; }

        public Prueba()
        {

        }

        public Prueba(string Apellido)
        {
            this.Apellido = Apellido;
        }
    }
}
