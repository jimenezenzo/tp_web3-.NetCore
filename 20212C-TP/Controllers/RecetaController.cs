using _20212C_TP.Models;
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
        IUsuarioServicio _usuarioServicio;

        public RecetaController(IRecetaServicio recetaServicio, IUsuarioServicio usuarioServicio)
        {
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public IActionResult Crear()
        {
            int idUsuario = HttpContext.Session.Get<int>("idUsuario");
            ViewData["idCocinero"] = _usuarioServicio.ObtenerUsuarioPorId(idUsuario).IdUsuario;

            return View();
        }

        [HttpPost]
        public IActionResult Crear(RecetaViewModel receta)
        {
            int idUsuario = HttpContext.Session.Get<int>("idUsuario");

            Usuario usuario = _usuarioServicio.ObtenerUsuarioPorId(idUsuario);

            _recetaServicio.Crear(usuario, receta.Nombre, receta.TiempoCoccion, receta.Descripcion, receta.Ingredientes, receta.IdTipoReceta);

            return View();
        }
    }
}
