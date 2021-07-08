using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class DetallePago
    {
        private int iD;
        private DateTime fechaPago;
        private decimal monto;
        private int iDPago;

        public DetallePago()
        {

        }

        public int ID { get => iD; set => iD = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public int IDPago { get => iDPago; set => iDPago = value; }
    }
}
