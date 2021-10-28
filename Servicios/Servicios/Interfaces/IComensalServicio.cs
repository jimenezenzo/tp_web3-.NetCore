using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Servicios.Interfaces
{
    public interface IComensalServicio
    {
        public List<Evento> ObtenerEventosParaReservar();
    }
}
