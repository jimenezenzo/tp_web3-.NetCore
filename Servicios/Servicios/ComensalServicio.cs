using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using Servicios.Repositorios.Interfaces;

namespace Servicios.Servicios
{
    public class ComensalServicio : IComensalServicio
    {
        IComensalRepositorio _comensalRepositorio;
        IEventoRepositorio _eventoRepositorio;

        public ComensalServicio(IComensalRepositorio comensalRepositorio, IEventoRepositorio eventoRepositorio)
        {
            _comensalRepositorio = comensalRepositorio;
            _eventoRepositorio = eventoRepositorio;
        }

        public List<Evento> ObtenerEventosParaReservar()
        {
            return _comensalRepositorio.ObtenerEventosParaReservar();
        }

        public List<Receta> ObtenerRecetasPorEvento(int idEvento)
        {
            return _comensalRepositorio.ObtenerRecetasPorEvento(idEvento);
        }

        public void ReservarEvento(int idEvento, int idComensal, int idReceta, int cantidadComensales)
        {
            var cantidadComensalesEventoDb = _eventoRepositorio.ObtenerEventoPorId(idEvento).CantidadComensales;
            var cantidadDeComensalesActualReservados = _comensalRepositorio.ObtenerCantidadDeComensalesReservados(idEvento);

            if ((cantidadDeComensalesActualReservados + cantidadComensales) > cantidadComensalesEventoDb)
                throw new Exception("La cantidad de comensales ingresado supera el limite");

            Reserva reserva = new Reserva();
            reserva.CantidadComensales = cantidadComensales;
            reserva.IdComensal = idComensal;
            reserva.IdEvento = idEvento;
            reserva.IdReceta = idReceta;
            reserva.FechaCreacion = DateTime.Now;

            _comensalRepositorio.ReservarEvento(reserva);
        }
    }
}
