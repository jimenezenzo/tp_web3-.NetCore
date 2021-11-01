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
        private IUsuarioRepositorio _usuarioRepositorio;
        public RecetaServicio(IRecetaRepositorio recetaRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _recetaRepositorio = recetaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public List<Entidades.Receta> ObtenerRecetas()
        {
            return _recetaRepositorio.ObtenerRecetas();
        }

        public List<Receta> ObtenerRecetasPosCocinero(int idCocinero)
        {
            Usuario cocinero = _usuarioRepositorio.ObtenerUsuarioPorId(idCocinero);
            //TODO: verificar que sea cocinero
            return _recetaRepositorio.ObtenerRecetasPorCocinero(cocinero);
        }
        public List<Entidades.TipoReceta> ObtenerTiposDeRecetas()
        {
            return _recetaRepositorio.ObtenerTiposDeRecetas();
        }

    }
}
