﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicios.Dominio;
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
            List<Evento> returnEventos = new List<Evento>();

            var query = from e in _db.Eventos.Include("Reservas")
                        where e.Fecha > DateTime.Now &&
                        e.Estado != (int)EstadoEvento.CANCELADO &&
                        e.Estado != (int)EstadoEvento.FINALIZADO
                        select e;

            foreach (Evento e in query)
            {
                if (e.CantidadComensalesDisponibles > 0)
                    returnEventos.Add(e);
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

        public int ObtenerCantidadDeComensalesReservados(int idEvento)
        {
            var query = from r in _db.Reservas
                        where r.IdEvento.Equals(idEvento)
                        select r;

            return query.Sum(r => r.CantidadComensales);
        }
    }
}
