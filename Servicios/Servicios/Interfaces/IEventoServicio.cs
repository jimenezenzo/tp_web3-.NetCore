using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Servicios.Interfaces
{
    public interface IEventoServicio
    {
        public int CrearEvento(int idCocinero, string nombre, DateTime fecha, int cantidadComensales, string ubicacion, string foto, decimal precio);

        public List<Evento> ObtenerEventosPorCocinero(int idCocinero);

        public void CrearEventosRecetas(int IdEvento, String[] IdReceta);

        public Evento ObtenerEventoProximoPorCocinero(int idCocinero);

        public Evento ObtenerEventoProximoPorComensal(int idCocinero);

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero);

        public Evento ObtenerEventoPorId(int idEvento);
        public List<Evento> ObtenerEventosPorComensal(int idComensal);

        public List<Reserva> ObtenerReservasPorComensal(int idComensal);
    }
}
