using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;

namespace Servicios.Repositorios
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private _20212C_TPContext _db;

        public EventoRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }
        public int CrearEvento(Evento evento)
        {
            _db.Eventos.Add(evento);
            _db.SaveChanges();

            return evento.IdEvento;
        }


        public List<Evento> ObtenerEventosPorCocinero(int idCocinero)
        {
            var query = from e in _db.Eventos
                        where e.IdCocinero == idCocinero
                        select e;

            return query.ToList();
        }
        public void CrearEventosRecetas(int IdEvento, int IdReceta)
        {
            EventosReceta er = new EventosReceta();
            er.IdEvento = IdEvento;
            er.IdReceta = IdReceta;

            _db.EventosRecetas.Add(er);
            _db.SaveChanges();

        }

        public Evento ObtenerEventoProximoPorCocinero(int idCocinero)
        {
            return _db.Eventos.OrderBy(d => d.Fecha).FirstOrDefault(e => e.IdCocinero == idCocinero && e.Estado == 1);
        }

        public Evento ObtenerEventoProximoPorComensal(int idComensal)
        {
            List<Evento> eventos = new List<Evento>();

            eventos = obtenerEventosPorComensal(idComensal);

            return eventos.OrderBy(d => d.Fecha).FirstOrDefault(e => e.Estado == 1);

        }

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero)
        {
            var query = from e in _db.Eventos
                        join r in _db.Reservas
                        on e.IdEvento equals r.IdEvento
                        where e.IdCocinero == idCocinero
                        select r;

            return query.ToList();
        }
        public List<Evento> obtenerEventosPorComensal(int idComensal)
        {
            List<Reserva> reservas = new List<Reserva>();
            List<Evento> eventos = new List<Evento>();

            var query = from r in _db.Reservas
                        where r.IdComensal == idComensal
                        select r;

            reservas = query.ToList();

            foreach (var re in reservas)
            {
                eventos.Add(_db.Eventos.FirstOrDefault(e => e.IdEvento == re.IdEvento));
            }
            return eventos;
        }

        /*(1)*/
        public List<Reserva> obtenerReservasPorComensal(int idComensal)
        {
            var query = from r in _db.Reservas
                        where r.IdComensal == idComensal
                        select r;

            return query.ToList();
        }

       
    }
}
