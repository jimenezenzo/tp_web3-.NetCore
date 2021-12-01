using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;
using _20212C_TP.Models;
using System.IO;
using _20212C_TP.Filtros;
using Servicios.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicios.Entidades;

namespace _20212C_TP.Controllers
{
    [AuthorizationFilter((int)PerfilUsuario.COCINERO)]
    public class CocinerosController : Controller
    {
        IEventoServicio _eventoServicio;
        IRecetaServicio _recetaServicio;
        IUsuarioServicio _usuarioServicio;
        ITipoRecetaServicio _tipoRecetaServicio;

        public CocinerosController(IEventoServicio eventoServicio, IRecetaServicio recetaServicio, IUsuarioServicio usuarioServicio, ITipoRecetaServicio tipoRecetaServicio)
        {
            _eventoServicio = eventoServicio;
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
            _tipoRecetaServicio = tipoRecetaServicio;
        }

        [HttpGet]
        public ActionResult Eventos()
        {
            int idComensal = HttpContext.Session.Get<int>("idUsuario");

            ViewBag.Recetas = _recetaServicio.ObtenerRecetasPorCocinero(idComensal);
            
            return View();
        }
        [HttpPost]
        public ActionResult Eventos(EventoViewModel eventoModel,string IdRecetas)
        {
            try
            {
                int idCocinero = HttpContext.Session.Get<int>("idUsuario");

                if (!ModelState.IsValid)
                {
                    ViewBag.Recetas = _recetaServicio.ObtenerRecetasPorCocinero(idCocinero);
                    return View("Views/Cocineros/Eventos.cshtml");
                }

                if (IdRecetas == null || IdRecetas == "")
                {
                    ViewBag.Recetas = _recetaServicio.ObtenerRecetasPorCocinero(idCocinero);
                    ViewBag.errorReceta = "debe cargar al menos una receta";
                    return View("Views/Cocineros/Eventos.cshtml");
                }

                /*cargar imagen*/
                string guidImagen = null;

                if(eventoModel.Foto != null)
                {
                    string ficherosImagenes = Path.Combine("wwwroot/assets/img/evento");
                    guidImagen = Guid.NewGuid().ToString("N").Substring(0, 5) + eventoModel.Foto.FileName;
                    string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImagen);
                    eventoModel.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                }


                /*cargar evento*/

                int idEvento=  _eventoServicio.CrearEvento(idCocinero, eventoModel.Nombre, eventoModel.Fecha, eventoModel.CantidadComensales, eventoModel.Ubicacion, guidImagen, eventoModel.Precio);


                /*cargar recetas en el evento*/

                String[] ArrayId = IdRecetas.Split(',');

                _eventoServicio.CrearEventosRecetas(idEvento, ArrayId);



                TempData["success"] = "Evento creado con exito";
                return Redirect("/Cocineros/Perfil");
            }
            catch (Exception e)
            {
                int idCocinero = HttpContext.Session.Get<int>("idUsuario");
                ViewBag.error = e.Message;
                ViewBag.Recetas = _recetaServicio.ObtenerRecetasPorCocinero(idCocinero);
                return View("Views/Cocineros/Eventos.cshtml");
            }
        }
        public ActionResult Perfil()
        {
            _eventoServicio.CambiarEstadoSegunLaFechaDeHoy();

            int idCocinero = HttpContext.Session.Get<int>("idUsuario");

            ViewBag.Recetas = _recetaServicio.ObtenerRecetasPorCocinero(idCocinero);
            ViewBag.Eventos = _eventoServicio.ObtenerEventosPorCocinero(idCocinero);
            ViewBag.EventoProximo = _eventoServicio.ObtenerEventoProximoPorCocinero(idCocinero);
            ViewBag.Reservas = _eventoServicio.ObtenerRecervasDeEventosPorCocinero(idCocinero);
            ViewBag.Usuario = _usuarioServicio.ObtenerUsuarioPorId(idCocinero);
            ViewBag.TipodeReceta = _recetaServicio.ObtenerTiposDeRecetas();
            ViewBag.IdCocinero = idCocinero;
            ViewBag.Cont = 0;


            return View();
        }
        public ActionResult Cancelacion()
        {
            int idCocinero = HttpContext.Session.Get<int>("idUsuario");

            ViewBag.Eventos = _eventoServicio.ObtenerEventosPorCocinero(idCocinero);
            ViewBag.IdCocinero = idCocinero;

            return View();
        }

        public ActionResult Recetas()
        {
            int idUsuario = HttpContext.Session.Get<int>("idUsuario");
            ViewData["idCocinero"] = _usuarioServicio.ObtenerUsuarioPorId(idUsuario).IdUsuario;

            ViewBag.TiposReceta = new SelectList(_tipoRecetaServicio.ObtenerTodas(), "IdTipoReceta", "Nombre");

            return View();
        }

        [HttpPost]
        public IActionResult Recetas(RecetaViewModel receta)
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
