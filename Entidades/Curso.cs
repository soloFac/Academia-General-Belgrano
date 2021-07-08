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
        private decimal precio;
        private int precio_Inscripcion;
        private bool tiene_Escuela;

        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IDGrupo { get => iDGrupo; set => iDGrupo = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Precio_Inscripcion { get => precio_Inscripcion; set => precio_Inscripcion = value; }
        public bool Tiene_Escuela { get => tiene_Escuela; set => tiene_Escuela = value; }

        public Curso()
        {

        }

        //public Curso(int ID, string Nombre, int IDGrupo)
        //{
        //    this.ID = ID;
        //    this.Nombre = Nombre;
        //    this.IDGrupo = IDGrupo;
        //}
    }
}
