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

        public Receta ObtenerReceta(int id)
        {
            var query = from recetas in _db.Recetas
                        where recetas.IdReceta == id
                        select recetas;

            return query.Single();
        }
        public List<Receta> ObtenerRecetasPorCocinero(Usuario cocinero)
        {
            var query = from recetas in _db.Recetas
                        where recetas.IdCocinero == cocinero.IdUsuario
                        select recetas;

            return query.ToList();
        }
        public List<TipoReceta> ObtenerTiposDeRecetas()
        {
            return _db.TipoRecetas.ToList();
        }

        public void Crear(Receta receta)
        {
            _db.Add(receta);
            _db.SaveChanges();
            // TODO : Crear controlador para poder cargar tipos de receta. Tambien en FE.
        }
    }
}
