using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class MisReservasController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/MisReservas/Index.cshtml");
        }

        public IActionResult Hola()
        {
            return View();
        }
    }
}
