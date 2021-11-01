using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios.Interfaces
{
    public interface IRecetaServicio
    {
        public void Crear(Usuario usuario, string nombre, int tiempoCoccion, string descripcion, string ingredientes, int idTipoReceta);

        public List<Entidades.Receta> ObtenerRecetas();

        public List<Entidades.Receta> ObtenerRecetasPorCocinero(int idCocinero);

        public List<Entidades.TipoReceta> ObtenerTiposDeRecetas();
    }
}
