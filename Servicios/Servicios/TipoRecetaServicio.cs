using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class TipoRecetaServicio : ITipoRecetaServicio
    {
        private ITipoRecetaRepositorio _tipoRecetaRepositorio;

        public TipoRecetaServicio(ITipoRecetaRepositorio tipoRecetaRepositorio)
        {
            this._tipoRecetaRepositorio = tipoRecetaRepositorio;
        }

        public void Crear(string nombre)
        {
            TipoReceta tipoReceta = new TipoReceta();
            tipoReceta.Nombre = nombre;

            this._tipoRecetaRepositorio.Crear(tipoReceta);
        }

        public List<TipoReceta> ObtenerTodas()
        {
            return _tipoRecetaRepositorio.ObtenerTodas();
        }
    }
}
