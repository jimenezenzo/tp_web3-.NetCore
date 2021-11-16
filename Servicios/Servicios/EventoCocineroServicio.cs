using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class EventoCocineroServicio : IEventoCocineroServicio
    {
        public IEventoCocineroRepositorio _eventoCocineroRepositorio { get; set; }

        public EventoCocineroServicio(IEventoCocineroRepositorio eventoCocineroRepositorio)
        {
            _eventoCocineroRepositorio = eventoCocineroRepositorio;
        }

        public EventoCocineroViewModel ObtenerDetalleDeEventoConCocinero(int idEvento)
        {
            return _eventoCocineroRepositorio.ObtenerDetalleDeEventoConCocinero(idEvento);
        }
    }
}
