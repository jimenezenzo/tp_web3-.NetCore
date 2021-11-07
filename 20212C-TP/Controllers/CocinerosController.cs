﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;
using _20212C_TP.Models;
using System.IO;

namespace _20212C_TP.Controllers
{
    public class CocinerosController : Controller
    {
        IEventoServicio _eventoServicio;
        IRecetaServicio _recetaServicio;
        IUsuarioServicio _usuarioServicio;

        public CocinerosController(IEventoServicio eventoServicio, IRecetaServicio recetaServicio, IUsuarioServicio usuarioServicio)
        {
            _eventoServicio = eventoServicio;
            _recetaServicio = recetaServicio;
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public ActionResult Eventos()
        {
            int perfil = HttpContext.Session.Get<int>("perfil");

            if (perfil != 2)
            {
                return Redirect("/Home/Index");
            }

            int idComensal = HttpContext.Session.Get<int>("idUsuario");

            ViewBag.Recetas = _recetaServicio.ObtenerRecetasPorCocinero(idComensal);
            
            return View();
        }
        [HttpPost]
        public ActionResult Eventos(EventoViewModel eventoModel,string IdRecetas)
        {
            try
            {
                int perfil = HttpContext.Session.Get<int>("perfil");

                if (perfil != 2)
                {
                    return Redirect("/Home/Index");
                }

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
                    guidImagen = Guid.NewGuid().ToString() + eventoModel.Foto.FileName;
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
            int perfil = HttpContext.Session.Get<int>("perfil");

            if (perfil != 2)
            {
                return Redirect("/Home/Index");
            }

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
            return View();
        }
    }
}
