﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;
using _20212C_TP.Models;

namespace _20212C_TP.Controllers
{
    public class CocinerosController : Controller
    {
        IEventoServicio _eventoServicio;
        IRecetaServicio _recetaServicio;

        public CocinerosController(IEventoServicio eventoServicio, IRecetaServicio recetaServicio)
        {
            _eventoServicio = eventoServicio;
            _recetaServicio = recetaServicio;
        }
        public ActionResult Recetas()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Eventos()
        {
            
            ViewBag.Recetas = _recetaServicio.ObtenerRecetasPosCocinero(2);
            
            return View();
        }
        [HttpPost]
        public ActionResult Eventos(EventoViewModel eventoModel,string IdRecetas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Recetas = _recetaServicio.ObtenerRecetasPosCocinero(2);
                    return View("Views/Cocineros/Eventos.cshtml");
                }


                int idCocinero = HttpContext.Session.Get<int>("idUsuario");

                int idEvento=  _eventoServicio.crearUnEvento(2, eventoModel.Nombre, eventoModel.Fecha, eventoModel.CantidadComensales, eventoModel.Ubicacion, eventoModel.Foto, eventoModel.Precio, 1);

                String[] ArrayId = IdRecetas.Split(',');

                _eventoServicio.CrearEventosRecetas(idEvento, ArrayId);

                TempData["success"] = "Evento creado con exito";
                return Redirect("/Cocineros/Perfil");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                ViewBag.Recetas = _recetaServicio.ObtenerRecetasPosCocinero(2);
                return View("Views/Cocineros/Eventos.cshtml");
            }
        }
        public ActionResult Perfil()
        {
            int idCocinero = HttpContext.Session.Get<int>("idUsuario");

            ViewBag.Recetas = _recetaServicio.ObtenerRecetasPosCocinero(2);
            ViewBag.Eventos = _eventoServicio.ObtenerEventosPorCocinero(2);
            ViewBag.TipodeReceta = _recetaServicio.ObtenerTiposDeRecetas();
            ViewBag.EventoProximo = _eventoServicio.ObtenerEventoProximo(2);
            ViewBag.Reservas = _eventoServicio.ObtenerRecervasDeEventosPorCocinero(2);
            ViewBag.Cont = 0;


            return View();
        }
        public ActionResult Cancelacion()
        {
            return View();
        }
    }
}
