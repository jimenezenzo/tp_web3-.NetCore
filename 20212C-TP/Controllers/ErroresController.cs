using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class ErroresController : Controller
    {
        public IActionResult Status401()
        {
            return View();
        }
    }
}
