using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IRecetaRepositorio
    {
        public List<Receta> ObtenerRecetas();

        public Receta ObtenerReceta(int idReceta);

        public List<Receta> ObtenerRecetasPorCocinero(Usuario usuario);

        public List<TipoReceta> ObtenerTiposDeRecetas();
    }
}
