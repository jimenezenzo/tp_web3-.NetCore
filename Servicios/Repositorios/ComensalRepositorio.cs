using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;

namespace Servicios.Repositorios
{
    public class ComensalRepositorio : IComensalRepositorio
    {
        private _20212C_TPContext _db;

        public ComensalRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }

        public List<Evento> ObtenerEventosParaReservar()
        {
            var query = from e in _db.Eventos.Include("Reservas")
                        where e.Fecha > DateTime.Now
                        select e;

            List<Evento> returnEventos = new List<Evento>();

            foreach(Evento e in query)
            {
                var cantComensales = e.Reservas.Sum(r => r.CantidadComensales);

                if (cantComensales < e.CantidadComensales)
                {
                    e.CantidadComensalesDisponibles = e.CantidadComensales - cantComensales;
                    returnEventos.Add(e);
                }
            }

            return returnEventos;
        }

        public List<Receta> ObtenerRecetasPorEvento(int idEvento)
        {
            var query = from r in _db.EventosRecetas.Include("IdRecetaNavigation")
                        where r.IdEvento.Equals(idEvento)
                        select r.IdRecetaNavigation;


            return query.ToList();
        }

        public void ReservarEvento(Reserva reserva)
        {
            _db.Reservas.Add(reserva);
            _db.SaveChanges();
        }
    }
}
