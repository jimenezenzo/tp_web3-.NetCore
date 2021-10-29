using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;
using _20212C_TP.Models;

namespace _20212C_TP.Controllers
{
    public class ComensalesController : Controller
    {
        IComensalServicio _comensalServicio;
        IEventoServicio _eventoServicio;

        public ComensalesController(IComensalServicio comensalServicio, IEventoServicio eventoServicio)
        {
            _comensalServicio = comensalServicio;
            _eventoServicio = eventoServicio;
        }

        public ActionResult Reserva()
        {
            return View(_comensalServicio.ObtenerEventosParaReservar());
        }
        public ActionResult Reservas()
        {
            return View();
        }
        public ActionResult Comentarios()
        {
            return View();
        }

        [Route("[controller]/{idEvento}/reservar")]
        public ActionResult ReservarEvento(int idEvento)
        {
            if(TempData["errorValidacion"] != null)
            {
                ViewBag.error = TempData["errorValidacion"];
            }

            ViewBag.evento = _eventoServicio.ObtenerEventoPorId(idEvento);

            ViewBag.recetas = _comensalServicio.ObtenerRecetasPorEvento(idEvento);

            return View();
        }

        [HttpPost]
        [Route("[controller]/{idEvento}/reservar")]
        public ActionResult ReservarEvento(ReservaViewModel reservaViewModel, int idEvento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorValidacion"] = ModelState.Values;
                    return Redirect("/comensales/" + idEvento + "/reservar");
                }

                var idComensal = HttpContext.Session.Get<int>("idUsuario");

                _comensalServicio.ReservarEvento(idEvento, idComensal, reservaViewModel.IdReceta, reservaViewModel.CantidadComensales);

                return Redirect("/comensales/reservas");
            }
            catch(Exception e)
            {
                ViewBag.error = e.Message;

                return View("Views/Comensales/ReservarEvento.cshtml");
            }
        }
    }
}
