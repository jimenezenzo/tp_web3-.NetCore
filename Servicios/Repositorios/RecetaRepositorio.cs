using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios
{
    public class RecetaRepositorio : IRecetaRepositorio
    {
        private _20212C_TPContext _db;

        public RecetaRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }
        public List<Receta> ObtenerRecetas()
        {
            return _db.Recetas.ToList();
        }
        public List<Receta> ObtenerRecetasPorCocinero(int idCocinero)
        {
            var query = from r in _db.Recetas
                        where r.IdCocinero == idCocinero
                        select r;

            return query.ToList();
        }
        public List<TipoReceta> ObtenerTiposDeRecetas()
        {
            return _db.TipoRecetas.ToList();
        }
    }
}
