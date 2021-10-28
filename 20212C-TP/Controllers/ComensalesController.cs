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

            int idComensal = HttpContext.Session.Get<int>("idUsuario");


            ViewBag.Usuario = _usuarioServicio.ObtenerUsuarioPorId(1);
            ViewBag.Reservas = _eventoServicio.obtenerReservasPorComensal(1);
            ViewBag.Eventos = _eventoServicio.obtenerEventosPorComensal(1);
            ViewBag.Recetas = _recetaServicio.ObtenerRecetas();
            
            ViewBag.EventoProximo = _eventoServicio.ObtenerEventoProximoPorComensal(1);



            return View();
        }
        public ActionResult Comentarios()
        {
            return View();
        }
    }
}
