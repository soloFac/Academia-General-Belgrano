using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public class Helper
    {
        public int CantidadMesesDiferencia(DateTime FechaInscripcion, DateTime FechaFinalCurso)
        {
            int cont = 0;
            int band = 0;

            while (FechaInscripcion.Month != FechaFinalCurso.Month)
            {
                FechaInscripcion.AddMonths(1);
                cont += 1;
            }

            return cont;
        }
    }
}
