using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IEventoRepositorio
    {
        public void CrearEvento(Evento evento);

        public List<Evento> ObtenerEventosPorCocinero(int idCocinero);
    }
}
