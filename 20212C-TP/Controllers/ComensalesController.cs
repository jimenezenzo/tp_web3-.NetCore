using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;

namespace _20212C_TP.Controllers
{
    public class ComensalesController : Controller
    {
        IComensalServicio _comensalServicio;

        public ComensalesController(IComensalServicio comensalServicio)
        {
            _comensalServicio = comensalServicio;
        }

        public ActionResult Reserva()
        {
            var eventos = _comensalServicio.ObtenerEventosParaReservar();

            return View(eventos);
        }
        public ActionResult Reservas()
        {
            var IdUsuario = HttpContext.Session.Get<int>("idUsuario");

            return View();
        }
        public ActionResult Comentarios()
        {
            return View();
        }
    }
}
