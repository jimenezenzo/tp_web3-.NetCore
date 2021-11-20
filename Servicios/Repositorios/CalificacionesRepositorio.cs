using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios
{
    public class CalificacionesRepositorio : ICalificacionesRepositorio
    {
        private _20212C_TPContext _db;

        public CalificacionesRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }

        public void CalificarEvento(Calificacione cal)
        {
            var query = from calificacion in _db.Calificaciones
                        where calificacion.IdEvento == cal.IdEvento &&
                        calificacion.IdComensal == cal.IdComensal
                        select calificacion;

            if(query.FirstOrDefault() != null)
            {
                query.FirstOrDefault().Comentarios = cal.Comentarios;
                query.FirstOrDefault().Calificacion = cal.Calificacion;
                _db.SaveChanges();
            }
            else
            {
                _db.Calificaciones.Add(cal);
                _db.SaveChanges();
            }

        }

        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int idEvento)
        {
            var query = from calificacion in _db.Calificaciones
                        where calificacion.IdEvento == idEvento
                        select calificacion;

            return query.ToList();
        }

        public Calificacione ObtenerCalificacionEventoComensal(int idComensal, int idEvento)
        {
            var query = from calificacion in _db.Calificaciones
                        where calificacion.IdEvento == idEvento &&
                        calificacion.IdComensal == idComensal
                        select calificacion;

            return query.FirstOrDefault();
        }
    }
}
