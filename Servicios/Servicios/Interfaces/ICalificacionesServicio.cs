using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios.Interfaces
{
    public interface ICalificacionesServicio
    {
        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int idEvento);
    }
}
