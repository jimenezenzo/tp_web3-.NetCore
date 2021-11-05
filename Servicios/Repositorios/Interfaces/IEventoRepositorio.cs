using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IEventoRepositorio
    {
        public int CrearEvento(Evento evento);

        public Evento ObtenerEvento(int id);

        public List<Evento> ObtenerEventosPorCocinero(Usuario usuario);

        public void CrearEventosRecetas(Evento evento, Receta receta);

        public Evento ObtenerEventoProximoPorCocinero(Usuario usuario);

        public Evento ObtenerEventoProximoPorComensal(Usuario usuario);

        public List<Reserva> ObtenerReservasDeEventosPorCocinero(Usuario usuario);

        public List<Evento> ObtenerEventosPorComensal(Usuario usuario);

        /*mover al repositorio reserva (1)*/
        public List<Reserva> ObtenerReservasPorComensal(Usuario usuario);

        public List<Evento> ObtenerEventosFinalizadosParaComensal(Usuario usuario);

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero);

        public Evento ObtenerEventoPorId(int idEvento);

        public Evento ModificarEvento(Evento evento);
    }
}
