using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public partial class Evento
    {
        public int CantidadDeComensalesReservados
        {
            get
            {
                return Reservas.Sum(r => r.CantidadComensales);
            }
        }

        public int CantidadComensalesDisponibles
        {
            get
            {
                return (CantidadComensales - CantidadDeComensalesReservados);
            }
        }
    }
}