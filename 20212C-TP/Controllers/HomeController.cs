﻿using _20212C_TP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class HomeController : Controller
    {
        private IRecetaServicio _recetaServicio;
        private IEventoServicio _eventoServicio;

        public HomeController(IRecetaServicio recetaServicio, IEventoServicio eventoServicio)
        {
            _recetaServicio = recetaServicio;
            _eventoServicio = eventoServicio;
        }

        public IActionResult Index()
        {
            _eventoServicio.CambiarEstadoSegunLaFechaDeHoy();
            var recetas = _recetaServicio.ObtenerRecetas();

            ViewBag.EventosFinalizados = _eventoServicio.ObtenerEventosFinalizadosConPuntuacion();

            return View();
        }

        public IActionResult Ingresar()
        {
            return View();
        }

 
        public IActionResult Error()
        {
            return View();
        }
    }
}
