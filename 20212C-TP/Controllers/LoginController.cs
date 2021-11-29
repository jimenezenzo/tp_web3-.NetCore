using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20212C_TP.Models;
using Servicios.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;

namespace _20212C_TP.Controllers
{
    public class LoginController : Controller
    {
        IUsuarioServicio _usuarioServicio;

        public LoginController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        public IActionResult Index()
        {
            return View("Views/Auth/Ingresar.cshtml");
        }

        [HttpPost]
        public IActionResult Ingresar(LoginViewModel loginViewModel)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View("Views/Auth/Ingresar.cshtml");

                var usuario = _usuarioServicio.login(loginViewModel.Email, loginViewModel.Password);

                HttpContext.Session.Set<int>("idUsuario", usuario.IdUsuario);
                HttpContext.Session.Set<int>("perfil", usuario.Perfil);
                HttpContext.Session.Set<string>("nombre", usuario.Nombre);

                if (usuario.Perfil == 1)
                    return Redirect("/comensales/reservas");
                else
                    return Redirect("/cocineros/perfil");
            }
            catch(Exception e)
            {
                ViewBag.error = e.Message;
                return View("Views/Auth/Ingresar.cshtml");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("/");
        }
    }
}
