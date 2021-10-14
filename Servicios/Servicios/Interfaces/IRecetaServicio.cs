using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios.Interfaces
{
    public interface IRecetaServicio
    {
        public List<Entidades.Receta> ObtenerRecetas();
    }
}
