using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using Servicios.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Servicios.Servicios
{
    public class EventoServicio : IEventoServicio
    {
        IEventoRepositorio _eventoRepositorio;

        public EventoServicio(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }


        public int crearUnEvento(int idCocinero, string nombre, DateTime fecha, int cantidadComensales, string ubicacion, string foto, decimal precio, int estado)
        {
            Evento e = new Evento();
            e.IdCocinero = idCocinero;
            e.Nombre = nombre;
            e.Fecha = fecha;
            e.CantidadComensales = cantidadComensales;
            e.Ubicacion = ubicacion;
            e.Foto = foto;
            e.Precio = precio;
            e.Estado = estado;

            return _eventoRepositorio.CrearEvento(e);
        }

        public List<Evento> ObtenerEventosPorCocinero(int idCocinero)
        {
            return _eventoRepositorio.ObtenerEventosPorCocinero(idCocinero);
        }
        public void CrearEventosRecetas(int IdEvento, String[] IdReceta)
        {
            for (int i = 0; i < IdReceta.Length-1; i++)
            {
                int id = int.Parse(IdReceta[i]);
            _eventoRepositorio.CrearEventosRecetas(IdEvento, id);
            }
        }

        public Evento ObtenerEventoProximoPorCocinero(int idCocinero)
        {
            return _eventoRepositorio.ObtenerEventoProximoPorCocinero(idCocinero);
        }
        public Evento ObtenerEventoProximoPorComensal(int idCocinero)
        {
            return _eventoRepositorio.ObtenerEventoProximoPorComensal(idCocinero);
        }

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero)
        {
            return _eventoRepositorio.ObtenerRecervasDeEventosPorCocinero(idCocinero);
        }
        public List<Evento> obtenerEventosPorComensal(int idComensal)
        {
            return _eventoRepositorio.obtenerEventosPorComensal(idComensal);
        }

        /*(1)*/
        public List<Reserva> obtenerReservasPorComensal(int idComensal)
        {
            return _eventoRepositorio.obtenerReservasPorComensal(idComensal);
        }

    }
}
