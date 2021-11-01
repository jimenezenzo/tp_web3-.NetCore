using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using Servicios.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Dominio;

namespace Servicios.Servicios
{
    public class EventoServicio : IEventoServicio
    {
        IEventoRepositorio _eventoRepositorio;
        IUsuarioRepositorio _usuarioRepositorio;
        IRecetaRepositorio _recetaRepositorio;
        IUsuarioServicio _usuarioServicio;

        public EventoServicio(
            IEventoRepositorio eventoRepositorio, 
            IUsuarioRepositorio usuarioRepositorio,
            IRecetaRepositorio recetaRepositorio,
            IUsuarioServicio usuarioServicio
            )
        {
            _eventoRepositorio = eventoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _recetaRepositorio = recetaRepositorio;
            _usuarioServicio = usuarioServicio;
        }


        public int CrearEvento(int idCocinero, string nombre, DateTime fecha, int cantidadComensales, string ubicacion, string foto, decimal precio)
        {
            Usuario cocinero = this.ObtenerCocinero(idCocinero);

            Evento e = new Evento();
            e.IdCocinero = cocinero.IdUsuario;
            e.Nombre = nombre;
            e.Fecha = fecha;
            e.CantidadComensales = cantidadComensales;
            e.Ubicacion = ubicacion;
            e.Foto = foto;
            e.Precio = precio;
            e.Estado = ((int)EstadoEvento.PENDIENTE);

            return _eventoRepositorio.CrearEvento(e);
        }

        public List<Evento> ObtenerEventosPorCocinero(int idCocinero)
        {
            return _eventoRepositorio
                .ObtenerEventosPorCocinero(this.ObtenerCocinero(idCocinero));
        }
        public void CrearEventosRecetas(int IdEvento, String[] IdReceta)
        {
            Evento evento = _eventoRepositorio.ObtenerEvento(IdEvento);
            for (int i = 0; i < IdReceta.Length-1; i++)
            {
                int id = int.Parse(IdReceta[i]);
                Receta receta = _recetaRepositorio.ObtenerReceta(id);
                _eventoRepositorio.CrearEventosRecetas(evento, receta);
            }
        }

        public Evento ObtenerEventoProximoPorCocinero(int idCocinero)
        {

            return _eventoRepositorio
                .ObtenerEventoProximoPorCocinero(this.ObtenerCocinero(idCocinero));
            
        }
        public Evento ObtenerEventoProximoPorComensal(int idComensal)
        {
            return _eventoRepositorio.ObtenerEventoProximoPorComensal(this.ObtenerComensal(idComensal));
        }

        public List<Reserva> ObtenerRecervasDeEventosPorCocinero(int idCocinero)
        {
            return _eventoRepositorio
                .ObtenerReservasDeEventosPorCocinero(this.ObtenerCocinero(idCocinero));
        }
        public List<Evento> ObtenerEventosPorComensal(int idComensal)
        {
            return _eventoRepositorio
                .ObtenerEventosPorComensal(this.ObtenerComensal(idComensal));
        }

        /*(1)*/
        public List<Reserva> ObtenerReservasPorComensal(int idComensal)
        {
            return _eventoRepositorio
                .ObtenerReservasPorComensal(this.ObtenerComensal(idComensal));
        }

        private Usuario ObtenerCocinero(int idCocinero)
        {
            Usuario cocinero = _usuarioRepositorio.ObtenerUsuarioPorId(idCocinero);

            if (!_usuarioServicio.EsCocinero(cocinero))
            {
                throw new Exception("El usuario no es cocinero");
            }

            return cocinero;
        }

        private Usuario ObtenerComensal(int idComensal)
        {
            Usuario comensal = _usuarioRepositorio.ObtenerUsuarioPorId(idComensal);

            if (_usuarioServicio.EsCocinero(comensal))
            {
                throw new Exception("El usuario no es cocinero");
            }

            return comensal;
        }

    }
}
