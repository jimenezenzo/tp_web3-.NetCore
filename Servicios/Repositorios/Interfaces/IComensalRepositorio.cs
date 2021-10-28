using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IComensalRepositorio
    {
        public List<Evento> ObtenerEventosParaReservar();
    }
}
