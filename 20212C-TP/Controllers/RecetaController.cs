using _20212C_TP.Filtros;
using _20212C_TP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicios.Dominio;
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
        ITipoRecetaServicio _tipoRecetaServicio;

        public RecetaController(
            IRecetaServicio recetaServicio, 
            IUsuarioServicio usuarioServicio,
            ITipoRecetaServicio tipoRecetaServicio
            )
        {
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
            _tipoRecetaServicio = tipoRecetaServicio;
        }

        [HttpGet]
        [AuthorizationFilter((int)PerfilUsuario.COCINERO)]
        public IActionResult Crear()
        {
            int idUsuario = HttpContext.Session.Get<int>("idUsuario");
            ViewData["idCocinero"] = _usuarioServicio.ObtenerUsuarioPorId(idUsuario).IdUsuario;

            ViewBag.TiposReceta =  new SelectList(_tipoRecetaServicio.ObtenerTodas(), "IdTipoReceta", "Nombre");

            /*
            List<SelectListItem> items = _tipoRecetaServicio.ObtenerTodas().ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.IdTipoReceta.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;*/

            return View();
        }

        [HttpPost]
        [AuthorizationFilter((int)PerfilUsuario.COCINERO)]
        public IActionResult Crear(RecetaViewModel receta)
        {

            if (ModelState.IsValid)
            {
                int idUsuario = HttpContext.Session.Get<int>("idUsuario");

                Usuario usuario = _usuarioServicio.ObtenerUsuarioPorId(idUsuario);

                if (receta.IdTipoReceta == 0)
                {
                    string nuevoTipoReceta = Request.Form["nuevoTipoReceta"];

                    _tipoRecetaServicio.Crear(nuevoTipoReceta);

                    int idTipoRecetaNueva = _tipoRecetaServicio.ObtenerTodas().Count();

                    _recetaServicio.Crear(usuario, receta.Nombre, receta.TiempoCoccion, receta.Descripcion, receta.Ingredientes, idTipoRecetaNueva);

                }
                else
                {
                    _recetaServicio.Crear(usuario, receta.Nombre, receta.TiempoCoccion, receta.Descripcion, receta.Ingredientes, receta.IdTipoReceta);
                }

                TempData["MensajeAlert"] = "Receta creada";
                TempData["ClaseAlert"] = "alert alert-success alert-dismissible fade show";

                return Redirect("/cocineros/perfil");
            }
            else
            {
                return View(receta);
            }
            
        }
    }
}
