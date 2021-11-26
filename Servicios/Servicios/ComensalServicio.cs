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
        IRecetaRepositorio _recetaRepositorio;

        public ComensalServicio(IComensalRepositorio comensalRepositorio, IEventoRepositorio eventoRepositorio, IRecetaRepositorio recetaRepositorio)
        {
            _comensalRepositorio = comensalRepositorio;
            _eventoRepositorio = eventoRepositorio;
            _recetaRepositorio = recetaRepositorio;
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
            if(_recetaRepositorio.ObtenerReceta(idReceta) == null)
                throw new Exception("La receta ingresada no existe");

            if(_eventoRepositorio.ObtenerEventoPorId(idEvento) == null)
                throw new Exception("El evento no existe");

            var cantidadMaximaComensales = _eventoRepositorio.ObtenerEventoPorId(idEvento).CantidadComensales;
            var cantidadDeComensalesActualReservados = _comensalRepositorio.ObtenerCantidadDeComensalesReservados(idEvento);

            if ((cantidadDeComensalesActualReservados + cantidadComensales) > cantidadMaximaComensales)
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
