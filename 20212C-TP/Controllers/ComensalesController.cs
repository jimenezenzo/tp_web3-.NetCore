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
        IEventoServicio _eventoServicio;
        IRecetaServicio _recetaServicio;
        IUsuarioServicio _usuarioServicio;

        public ComensalesController(IEventoServicio eventoServicio, IRecetaServicio recetaServicio, IUsuarioServicio usuarioServicio)
        {
            _eventoServicio = eventoServicio;
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
        }
        public ActionResult Reserva()
        {
            return View();
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
    }
}
