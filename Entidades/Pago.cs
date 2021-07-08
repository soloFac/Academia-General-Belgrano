using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Pago
    {
        private int iD;
        private DateTime mes;
        private int saldo;
        private int iDAlumno;

        public int ID { get => iD; set => iD = value; }
        public DateTime Mes { get => mes; set => mes = value; }
        public int Saldo { get => saldo; set => saldo = value; }
        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }

        public Pago()
        {

        }
    }
}
