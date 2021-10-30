using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Dominio
{
    public enum EstadoEvento: int
    {
        PENDIENTE = 0,
        CANCELADO = 1,
        FINALIZADO = 2
    }
}
