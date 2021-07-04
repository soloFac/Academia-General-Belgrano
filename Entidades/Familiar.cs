using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Familiar : Persona
    {
        private int iDAlumno;
        private string ocupacion;
        private string empresa;
        private string gremio;
        private string telefono;
        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public string Gremio { get => gremio; set => gremio = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Familiar()
        {
        }

        public Familiar(int ID, string Nombre, string Apellido, int IDAlumno, string Telefono, string Ocupacion, string Empresa, string Gremio) : base(ID, Nombre, Apellido)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;

            this.Telefono = Telefono;
            this.IDAlumno = IDAlumno;
            this.Ocupacion = Ocupacion;
            this.Empresa = Empresa;
            this.Gremio = Gremio;
        }


    }
}
