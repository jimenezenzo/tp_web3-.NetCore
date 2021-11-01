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
        private IUsuarioServicio _usuarioServicio;
        public RecetaServicio(IRecetaRepositorio recetaRepositorio, IUsuarioRepositorio usuarioRepositorio, IUsuarioServicio usuarioServicio)
        {
            _recetaRepositorio = recetaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioServicio = usuarioServicio;
        }

        public void Crear(Usuario usuario, string nombre, int tiempoCoccion, string descripcion, string ingredientes, int idTipoReceta)
        {
            if (!_usuarioServicio.EsCocinero(usuario))
            {
                throw new Exception("El usuario no es cocinero");
            }

            Receta receta = new Receta();
            receta.Nombre = nombre;
            receta.TiempoCoccion = tiempoCoccion;
            receta.Descripcion = descripcion;
            receta.Ingredientes = ingredientes;
            receta.IdTipoReceta = idTipoReceta;
            receta.IdCocinero = usuario.IdUsuario;

            _recetaRepositorio.Crear(receta);

        }

        public List<Entidades.Receta> ObtenerRecetas()
        {
            return _recetaRepositorio.ObtenerRecetas();
        }

        public List<Receta> ObtenerRecetasPorCocinero(int idCocinero)
        {
            Usuario cocinero = _usuarioRepositorio.ObtenerUsuarioPorId(idCocinero);

            if (!_usuarioServicio.EsCocinero(cocinero))
            {
                throw new Exception("El usuario no es cocinero");
            }

            return _recetaRepositorio.ObtenerRecetasPorCocinero(cocinero);
        }
        public List<Entidades.TipoReceta> ObtenerTiposDeRecetas()
        {
            return _recetaRepositorio.ObtenerTiposDeRecetas();
        }

    }
}
