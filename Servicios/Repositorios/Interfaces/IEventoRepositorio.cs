﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IEventoRepositorio
    {
        public int CrearEvento(Evento evento);

        public List<Evento> ObtenerEventosPorCocinero(int idCocinero);

        public void CrearEventosRecetas(int IdEvento, int IdReceta);

        public Evento ObtenerEventoProximo(int idCocinero);

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero);

        public Evento ObtenerEventoPorId(int idEvento);
    }
}
