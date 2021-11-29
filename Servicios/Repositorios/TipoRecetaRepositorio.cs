using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios
{
    public class TipoRecetaRepositorio : ITipoRecetaRepositorio
    {

        private _20212C_TPContext _db;

        public TipoRecetaRepositorio(_20212C_TPContext db)
        {
            this._db = db;
        }

        public void Crear(TipoReceta tipoReceta)
        {
            _db.Add(tipoReceta);
            _db.SaveChanges();
        }

        public List<TipoReceta> ObtenerTodas()
        {
            return _db.TipoRecetas.ToList();
        }


    }
}
