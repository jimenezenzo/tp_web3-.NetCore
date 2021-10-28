﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Servicios.Interfaces
{
    public interface IEventoServicio
    {
        public int crearUnEvento(int idCocinero, string nombre, DateTime fecha, int cantidadComensales, string ubicacion, string foto, decimal precio, int estado);

        public List<Evento> ObtenerEventosPorCocinero(int idCocinero);

        public void CrearEventosRecetas(int IdEvento, String[] IdReceta);

        public Evento ObtenerEventoProximoPorCocinero(int idCocinero);

        public Evento ObtenerEventoProximoPorComensal(int idCocinero);

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero);

        public List<Evento> obtenerEventosPorComensal(int idComensal);


        /*(1)*/
        public List<Reserva> obtenerReservasPorComensal(int idComensal);
    }
}
