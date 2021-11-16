using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20212C_TP.Models;
using Servicios.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Entidades;

namespace _20212C_TP.Controllers
{
    public class EventosController : Controller
    {
        IEventoServicio _eventoServicio;
        ICalificacionesServicio _calificacionesServicio;
        IEventoCocineroServicio _eventoCocineroServicio;

        public EventosController(
            IEventoServicio eventoServicio,
            ICalificacionesServicio calificacionesServicio,
            IEventoCocineroServicio eventoCocineroServicio
            )
        {
            _eventoServicio = eventoServicio;
            _calificacionesServicio = calificacionesServicio;
            _eventoCocineroServicio = eventoCocineroServicio;
        }

        public IActionResult Detalle(int id)
        {
            List<Calificacione> calificaciones = _calificacionesServicio.ObtenerCalificacionesPorIdEvento(id);
            EventoCocineroViewModel eventoCocinero = _eventoCocineroServicio.ObtenerDetalleDeEventoConCocinero(id);

            ViewBag.Calificaciones = calificaciones;
            ViewBag.PromedioCalificaciones = _calificacionesServicio.ObtenerPromedioDeCalificacionesPorEvento(id);

            return View(eventoCocinero);
        }
    }
}
