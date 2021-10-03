using _20212C_TP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios;

namespace _20212C_TP.Controllers
{
    public class HomeController : Controller
    {
        private RecetaServicio _recetaServicio;

        public HomeController()
        {
            _recetaServicio = new RecetaServicio();
        }

        public IActionResult Index()
        {
            return View(_recetaServicio.obtenerRecetas());
        }

        public IActionResult Privacy()
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
