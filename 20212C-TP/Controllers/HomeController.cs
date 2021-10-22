using _20212C_TP.Models;
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

        public HomeController(IRecetaServicio recetaServicio)
        {
            _recetaServicio = recetaServicio;
        }

        public IActionResult Index()
        {
            var recetas = _recetaServicio.ObtenerRecetas();

            return View();
        }

        public IActionResult Ingresar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
