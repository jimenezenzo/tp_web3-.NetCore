using _20212C_TP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Servicios.Interfaces;

namespace _20212C_TP.Controllers
{
    public class RegistracionController : Controller
    {
        IUsuarioServicio _usuarioServicio;

        public RegistracionController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public IActionResult Index()
        {
            return View("Views/Auth/Registrarse.cshtml");
        }

        [HttpPost]
        public IActionResult store(UsuarioViewModel usuarioModel)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View("Views/Auth/Registrarse.cshtml");

                _usuarioServicio.registrarUsuario(usuarioModel.Nombre, usuarioModel.Email, usuarioModel.Password, usuarioModel.PassworConfirmar, usuarioModel.Perfil);

                TempData["success"] = "Registro exito";
                return Redirect("/login");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View("Views/Auth/Registrarse.cshtml");
            }
        }
    }
}
