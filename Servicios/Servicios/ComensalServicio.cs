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

        public ComensalServicio(IComensalRepositorio comensalRepositorio)
        {
            _comensalRepositorio = comensalRepositorio;
        }

        public List<Evento> ObtenerEventosParaReservar()
        {
            return _comensalRepositorio.ObtenerEventosParaReservar();
        }
    }
}
