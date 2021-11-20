using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios.Interfaces
{
    public interface ICalificacionesRepositorio
    {
        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int idEvento);
        public void CalificarEvento(Calificacione calificacion);
    }
}
