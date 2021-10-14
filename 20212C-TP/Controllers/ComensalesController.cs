using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class ComensalesController : Controller
    {
        public ActionResult Reserva()
        {
            return View();
        }
        public ActionResult Reservas()
        {
            return View();
        }
        public ActionResult Comentarios()
        {
            return View();
        }
    }
}
