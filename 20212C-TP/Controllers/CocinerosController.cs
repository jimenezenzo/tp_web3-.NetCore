using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Controllers
{
    public class CocinerosController : Controller
    {
        public ActionResult Recetas()
        {
            return View();
        }
        public ActionResult Eventos()
        {
            return View();
        }
        public ActionResult Perfil()
        {
            return View();
        }
        public ActionResult Cancelacion()
        {
            return View();
        }
    }
}
