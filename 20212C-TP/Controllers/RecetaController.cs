using Microsoft.AspNetCore.Mvc;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class RecetaController : Controller
    {
        IRecetaServicio _recetaServicio;

        public RecetaController(IRecetaServicio recetaServicio)
        {
            _recetaServicio = recetaServicio;   
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Receta receta)
        {
            return View();
        }
    }
}
