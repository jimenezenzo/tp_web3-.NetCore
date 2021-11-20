﻿using Servicios.Entidades;
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

        /*
         * TODO: Crear metodo para obtener promedio de calificaciones por evento.
         * 
         */
        public void CalificarEvento(int idevento,int idComensal,string comentario,int puntuacion);
    }
}
