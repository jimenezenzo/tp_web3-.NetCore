using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;
using _20212C_TP.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
            if(TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }

            ViewBag.evento = _eventoServicio.ObtenerEventoPorId(idEvento);

            ViewBag.recetas = _comensalServicio.ObtenerRecetasPorEvento(idEvento);

            return View();
        }

        [HttpPost]
        [Route("[controller]/reservar-evento")]
        public ActionResult ReservarEvento(ReservaViewModel reservaViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.evento = _eventoServicio.ObtenerEventoPorId(reservaViewModel.IdEvento);

                    ViewBag.recetas = _comensalServicio.ObtenerRecetasPorEvento(reservaViewModel.IdEvento);

                    return View(reservaViewModel);
                }

                var idComensal = HttpContext.Session.Get<int>("idUsuario");

                _comensalServicio.ReservarEvento(reservaViewModel.IdEvento, idComensal, reservaViewModel.IdReceta, reservaViewModel.CantidadComensales);

                return Redirect("/comensales/reservas");
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;

                return Redirect("/comensales/" + reservaViewModel.IdEvento + "/reservar");
            }
        }
    }
}
