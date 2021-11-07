﻿using _20212C_TP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_20212C_TP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        IEventoServicio _eventoServicio;

        public EventoController(IEventoServicio eventoServicio)
        {
            _eventoServicio = eventoServicio;
        }

        [Route("cancelar")]
        [HttpPost]
        public async Task<ActionResult<Evento>> CancelarEvento(CancelarEventoViewModel cancelarEventoViewModel)
        {
            try
            {
                return Ok(_eventoServicio.CancelarEvento(cancelarEventoViewModel.IdEvento, cancelarEventoViewModel.IdCocinero));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}