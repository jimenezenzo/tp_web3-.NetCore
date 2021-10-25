using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Repositorios;
using Servicios.Repositorios.Interfaces;
using Servicios.Servicios.Interfaces;

namespace Servicios.Servicios
{
    public class RecetaServicio : IRecetaServicio
    {
        private IRecetaRepositorio _recetaRepositorio;
        public RecetaServicio(IRecetaRepositorio recetaRepositorio)
        {
            _recetaRepositorio = recetaRepositorio;
        }

        public List<Entidades.Receta> ObtenerRecetas()
        {
            return _recetaRepositorio.ObtenerRecetas();
        }


        public List<Receta> ObtenerRecetasPosCocinero(int idCocinero)
        {
            return _recetaRepositorio.ObtenerRecetasPorCocinero(idCocinero);
        }
    }
}
