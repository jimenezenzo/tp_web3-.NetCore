using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public partial class Evento
    {
        public int CantidadComensalesDisponibles = 0;

        public int GetCantidadComensalesDisponibles()
        {
            return CantidadComensalesDisponibles;
        }

        public void SetCantidadComensalesDisponibles(int cant)
        {
            CantidadComensalesDisponibles = cant;
        }
    }
}