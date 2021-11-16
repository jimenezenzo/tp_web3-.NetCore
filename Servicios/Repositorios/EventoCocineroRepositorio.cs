using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Repositorios
{
    public class EventoCocineroRepositorio : IEventoCocineroRepositorio
    {
        private _20212C_TPContext _db;
        public EventoCocineroRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }
        public EventoCocineroViewModel ObtenerDetalleDeEventoConCocinero(int idEvento)
        {
            var query = from evento in _db.Eventos
                        join calificacion in _db.Calificaciones on evento.IdEvento equals calificacion.IdEvento
                        join cocinero in _db.Usuarios on evento.IdCocinero equals cocinero.IdUsuario
                        where evento.IdEvento == idEvento
                        select new EventoCocineroViewModel
                        {
                            IdEvento = evento.IdEvento,
                            IdCocinero = cocinero.IdUsuario,
                            NombreEvento = evento.Nombre,
                            FotoEvento = evento.Foto,
                            PrecioEvento = evento.Precio,
                            UbicacionEvento = evento.Ubicacion,
                            CantidadComensalesEvento = evento.CantidadComensales,
                            FechaEvento = evento.Fecha,
                            NombreCocinero = cocinero.Nombre
                        };

            return query.FirstOrDefault();
        }
    }
}
