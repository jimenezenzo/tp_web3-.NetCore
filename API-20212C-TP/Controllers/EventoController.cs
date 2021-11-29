using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API_20212C_TP.Models;
using Servicios.Exceptions;
using Microsoft.AspNetCore.Http;

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

        [Route("Cancelar")]
        [HttpPost]
        public async Task<ActionResult> PostCancelarEvento(CancelarEventoViewModel cancelarEventoViewModel)
        {
            try
            {
                return Ok(_eventoServicio.CancelarEvento(cancelarEventoViewModel.IdEvento, cancelarEventoViewModel.IdCocinero));
            }
            catch (CancelarEventoException e)
            {
                return new JsonResult(new { error = e.Message })
                {
                    StatusCode = StatusCodes.Status422UnprocessableEntity,
                };
            }
        }
    }
}
