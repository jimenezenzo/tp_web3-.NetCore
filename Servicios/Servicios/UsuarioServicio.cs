using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Servicios.Interfaces;
using Servicios.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Servicios.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario login(string email, string password)
        {
            if (_usuarioRepositorio.ValidarEmail(email))
                throw new Exception("El email o contraseña es incorrecto");

            Usuario userDb = _usuarioRepositorio.ObtenerUsuarioPorEmail(email);

            if(userDb.Password != password)
                throw new Exception("El email o contraseña es incorrecto");

            return userDb;
        }

        public void registrarUsuario(string nombre, string email, string password, string passwordConfirmar, int perfil)
        {
            if (password != passwordConfirmar)
                throw new Exception("El campo password no coincide con passwordConfirmar");

            if(!_usuarioRepositorio.ValidarEmail(email))
                throw new Exception("El email ya existe");

            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Email = email;
            usuario.Password = password;
            usuario.Perfil = perfil;
            usuario.FechaRegistracion = DateTime.Now;

            _usuarioRepositorio.AgregarUsuario(usuario);
        }
        public Usuario ObtenerUsuarioPorId(int IdUsuario)
        {
            return _usuarioRepositorio.ObtenerUsuarioPorId(IdUsuario);
        }
    }
}
