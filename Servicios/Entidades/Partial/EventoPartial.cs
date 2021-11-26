using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public partial class Evento
    {
        public int CantidadComensalesDisponibles
        {
            get
            {
                var reservado = Reservas.Sum(r => r.CantidadComensales);
                return (CantidadComensales - reservado);
            }
        }

    }
}