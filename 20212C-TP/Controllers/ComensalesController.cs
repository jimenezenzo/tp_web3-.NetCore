using _20212C_TP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Entidades;
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
        ICalificacionesServicio _calificacionesServicio;

        public ComensalesController(IEventoServicio eventoServicio, IRecetaServicio recetaServicio, IUsuarioServicio usuarioServicio, IComensalServicio comensalServicio, ICalificacionesServicio calificacionesServicio)
        {
            _eventoServicio = eventoServicio;
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
            _comensalServicio = comensalServicio;
            _calificacionesServicio = calificacionesServicio;
        }
        public ActionResult Reserva()
        {
            _eventoServicio.CambiarEstadoSegunLaFechaDeHoy();
            return View(_comensalServicio.ObtenerEventosParaReservar());
        }
        public ActionResult Reservas()
        {
            int perfil = HttpContext.Session.Get<int>("perfil");

            //if (perfil != 1)
            //{
            //    return Redirect("/Home/Index");
            //}

            int idComensal = HttpContext.Session.Get<int>("idUsuario");

            ViewBag.Usuario = _usuarioServicio.ObtenerUsuarioPorId(idComensal);
            ViewBag.Reservas = _eventoServicio.ObtenerReservasPorComensal(idComensal);
            ViewBag.Eventos = _eventoServicio.ObtenerEventosPorComensal(idComensal);
            ViewBag.EventoProximo = _eventoServicio.ObtenerEventoProximoPorComensal(idComensal);
            ViewBag.Recetas = _recetaServicio.ObtenerRecetas();

            return View();
        }
        [Route("[controller]/Comentarios/{idEvento}")]
        public ActionResult Comentarios(int idEvento)
        {
            ViewBag.IdEvento = idEvento;
            var idComensal = HttpContext.Session.Get<int>("idUsuario");
            if (_calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, idEvento) != null)
            {
                ViewBag.Calificacion = _calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, idEvento);
            }
            else
            {
                Calificacione c = new Calificacione();
                c.Calificacion = 1;
                c.Comentarios = "";
                ViewBag.Calificacion = c;
            }

            return View();
        }
        [HttpPost]
        [Route("[controller]/Comentarios-calificacion")]
        public ActionResult Comentarios(PuntuarViewModel puntuarViewModel)
        {
            try
            {
                var idComensal = HttpContext.Session.Get<int>("idUsuario");

                if (!ModelState.IsValid)
                {
                    ViewBag.IdEvento = puntuarViewModel.IdEvento;
                    if (_calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, puntuarViewModel.IdEvento) != null)
                    {
                        ViewBag.Calificacion = _calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, puntuarViewModel.IdEvento);
                    }
                    else
                    {
                        Calificacione c = new Calificacione();
                        c.Calificacion = 1;
                        c.Comentarios = "";
                        ViewBag.Calificacion = c;
                    }
                    return View(puntuarViewModel);
                }
                if (puntuarViewModel.Calificacion>5 || puntuarViewModel.Calificacion < 1)
                {
                    ViewBag.IdEvento = puntuarViewModel.IdEvento;
                    TempData["error"] = "puntaje entre 1-5";
                    if (_calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, puntuarViewModel.IdEvento) != null)
                    {
                        ViewBag.Calificacion = _calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, puntuarViewModel.IdEvento);
                    }
                    else
                    {
                        Calificacione c = new Calificacione();
                        c.Calificacion = 1;
                        c.Comentarios = "";
                        ViewBag.Calificacion = c;
                    }
                    return View(puntuarViewModel);
                }
                if (puntuarViewModel.Comentarios=="")
                {
                    ViewBag.IdEvento = puntuarViewModel.IdEvento;
                    TempData["error"] = "Escribir un comentario";
                    if (_calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, puntuarViewModel.IdEvento) != null)
                    {
                        ViewBag.Calificacion = _calificacionesServicio.ObtenerCalificacionEventoComensal(idComensal, puntuarViewModel.IdEvento);
                    }
                    else
                    {
                        Calificacione c = new Calificacione();
                        c.Calificacion = 1;
                        c.Comentarios = "";
                        ViewBag.Calificacion = c;
                    }
                    return View(puntuarViewModel);
                }


                _calificacionesServicio.CalificarEvento(puntuarViewModel.IdEvento, idComensal, puntuarViewModel.Comentarios, puntuarViewModel.Calificacion);

                return Redirect("/comensales/reservas");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;

                return Redirect("/comensales/reservas");
            }
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
