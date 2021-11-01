using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IComensalRepositorio
    {
        public List<Evento> ObtenerEventosParaReservar();

        public List<Receta> ObtenerRecetasPorEvento(int idEvento);

        public void ReservarEvento(Reserva reserva);

        public int ObtenerCantidadDeComensalesReservados(int idEvento);
    }
}
