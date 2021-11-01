using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicios.Dominio;
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

        public Evento ObtenerEvento(int id)
        {
            var query = from eventos in _db.Eventos
                        where eventos.IdEvento == id
                        select eventos;

            return query.Single();
        }


        public List<Evento> ObtenerEventosPorCocinero(Usuario usuario)
        {
            var query = from e in _db.Eventos
                        where e.IdCocinero == usuario.IdUsuario
                        select e;

            return query.ToList();
        }
        public void CrearEventosRecetas(Evento evento, Receta receta)
        {
            EventosReceta er = new EventosReceta();
            er.IdEvento = evento.IdEvento;
            er.IdReceta = receta.IdReceta;

            _db.EventosRecetas.Add(er);
            _db.SaveChanges();

        }

        public Evento ObtenerEventoProximoPorCocinero(Usuario usuario)
        {
            return _db.Eventos
                .OrderBy(d => d.Fecha)
                .FirstOrDefault(e => 
                    e.IdCocinero == usuario.IdUsuario && 
                    e.Estado == ((int)EstadoEvento.PENDIENTE)
                 );
        }

        public Evento ObtenerEventoProximoPorComensal(Usuario usuario)
        {
            List<Evento> eventos = new List<Evento>();

            eventos = ObtenerEventosPorComensal(usuario);

            return eventos.OrderBy(d => d.Fecha).FirstOrDefault(e => e.Estado == ((int)EstadoEvento.PENDIENTE));

        }

        public List<Reserva> ObtenerReservasDeEventosPorCocinero(Usuario usuario)
        {
            var query = from e in _db.Eventos
                        join r in _db.Reservas
                        on e.IdEvento equals r.IdEvento
                        where e.IdCocinero == usuario.IdUsuario
                        select r;

            return query.ToList();
        }

        public Evento ObtenerEventoPorId(int idEvento)
        {
            return _db.Eventos.FirstOrDefault(e => e.IdEvento.Equals(idEvento));
        }
        public List<Evento> ObtenerEventosPorComensal(Usuario usuario)
        {
            var query = from reservas in _db.Reservas
                        join eventos in _db.Eventos on reservas.IdEvento equals eventos.IdEvento
                        where reservas.IdComensal == usuario.IdUsuario
                        select eventos;

            return query.ToList();
        }

        public List<Reserva> ObtenerReservasPorComensal(Usuario usuario)
        {
            var query = from r in _db.Reservas
                        where r.IdComensal == usuario.IdUsuario
                        select r;

            return query.ToList();
        }

        public List<Evento> ObtenerEventosFinalizadosParaComensal(Usuario usuario)
        {
            var query = from reservas in _db.Reservas
                        join eventos in _db.Eventos on reservas.IdEvento equals eventos.IdEvento
                        where reservas.IdComensal == usuario.IdUsuario
                        where eventos.Estado == ((int)EstadoEvento.FINALIZADO)
                        select eventos;

            return query.ToList();
        }

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero)
        {
            throw new NotImplementedException();
        }
    }
}
