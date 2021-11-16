using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class CalificacionesServicio : ICalificacionesServicio
    {
        public ICalificacionesRepositorio _calificacionesRepositorio { get; set; }

        public CalificacionesServicio(ICalificacionesRepositorio calificacionesRepositorio)
        {
            _calificacionesRepositorio = calificacionesRepositorio;
        }
        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int idEvento)
        {
            return _calificacionesRepositorio.ObtenerCalificacionesPorIdEvento(idEvento);
        }

        public double ObtenerPromedioDeCalificacionesPorEvento(int idEvento)
        {
            List<Calificacione> calificaciones = _calificacionesRepositorio.ObtenerCalificacionesPorIdEvento(idEvento);

            return calificaciones.Average(calificacion => calificacion.Calificacion);
        }
    }
}
