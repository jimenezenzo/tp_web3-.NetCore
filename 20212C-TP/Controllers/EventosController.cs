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

        public EventosController(IEventoServicio eventoServicio, ICalificacionesServicio calificacionesServicio)
        {
            _eventoServicio = eventoServicio;
            _calificacionesServicio = calificacionesServicio;
        }

        public IActionResult Detalle(int id)
        {
            List<Calificacione> calificaciones = _calificacionesServicio.ObtenerCalificacionesPorIdEvento(id);

            ViewBag.Calificaciones = calificaciones;

            return View();
        }
    }
}
