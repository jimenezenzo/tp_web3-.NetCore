using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;

namespace Servicios.Repositorios
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private _20212C_TPContext _db;

        public EventoRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }
        public int CrearEvento(Evento evento)
        {
            _db.Eventos.Add(evento);
            _db.SaveChanges();

            return evento.IdEvento;
        }


        public List<Evento> ObtenerEventosPorCocinero(int idCocinero)
        {
            List<Evento> es = new List<Evento>();

            foreach (Evento e in _db.Eventos)
            {
                if(e.IdCocinero == idCocinero)
                {
                    es.Add(e);
                }
            }
            return es;
        }
        public void CrearEventosRecetas(int IdEvento, int IdReceta)
        {
            EventosReceta er = new EventosReceta();
            er.IdEvento = IdEvento;
            er.IdReceta = IdReceta;

            _db.EventosRecetas.Add(er);
            _db.SaveChanges();

        }
    }
}
