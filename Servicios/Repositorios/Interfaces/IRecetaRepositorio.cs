using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios.Interfaces
{
    public interface IRecetaRepositorio
    {
        public List<Entidades.Receta> ObtenerRecetas();

        public List<Entidades.Receta> ObtenerRecetasPorCocinero(int idCocinero);

        public List<Entidades.TipoReceta> ObtenerTiposDeRecetas();
    }
}
