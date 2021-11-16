using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios.Interfaces
{
    public interface IEventoCocineroRepositorio
    {
        public EventoCocineroViewModel ObtenerDetalleDeEventoConCocinero(int idEvento);
    }
}
