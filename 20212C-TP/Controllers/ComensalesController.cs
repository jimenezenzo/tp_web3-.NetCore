using _20212C_TP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class ComensalesController : Controller
    {
        IEventoServicio _eventoServicio;
        IRecetaServicio _recetaServicio;
        IUsuarioServicio _usuarioServicio;
        IComensalServicio _comensalServicio;

        public ComensalesController(IEventoServicio eventoServicio, IRecetaServicio recetaServicio, IUsuarioServicio usuarioServicio, IComensalServicio comensalServicio)
        {
            _eventoServicio = eventoServicio;
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
            _comensalServicio = comensalServicio;
        }
        public ActionResult Reserva()
        {
            return View(_comensalServicio.ObtenerEventosParaReservar());
        }
        public ActionResult Reservas()
        {
            int perfil = HttpContext.Session.Get<int>("perfil");

            if (perfil != 1)
            {
                return Redirect("/Home/Index");
            }

            int idComensal = HttpContext.Session.Get<int>("idUsuario");



            ViewBag.Usuario = _usuarioServicio.ObtenerUsuarioPorId(idComensal);
            ViewBag.Reservas = _eventoServicio.ObtenerReservasPorComensal(idComensal);
            ViewBag.Eventos = _eventoServicio.ObtenerEventosPorComensal(idComensal);
            ViewBag.EventoProximo = _eventoServicio.ObtenerEventoProximoPorComensal(idComensal);
            ViewBag.Recetas = _recetaServicio.ObtenerRecetas();



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
