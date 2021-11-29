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

        public double ObtenerPromedioDeCalificacionesPorEvento(int idEvento);

        public void CalificarEvento(int idevento,int idComensal,string comentario,int puntuacion);

        public Calificacione ObtenerCalificacionEventoComensal(int idComensal, int idEvento);
    }
}
