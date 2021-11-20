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

        public void CalificarEvento(Calificacione calificacion)
        {
            _db.Calificaciones.Add(calificacion);
            _db.SaveChanges();
        }

        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int idEvento)
        {
            var query = from calificacion in _db.Calificaciones
                        where calificacion.IdEvento == idEvento
                        select calificacion;

            return query.ToList();
        }
    }
}
