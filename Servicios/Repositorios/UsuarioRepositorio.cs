using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Repositorios.Interfaces;

namespace Servicios.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private _20212C_TPContext _db;

        public UsuarioRepositorio(_20212C_TPContext db)
        {
            _db = db;
        }
        public void AgregarUsuario(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            return _db.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public bool ValidarEmail(string email)
        {
            var usuario = this.ObtenerUsuarioPorEmail(email);

            return usuario == null;
        }
        public Usuario ObtenerUsuarioPorId(int IdUsuario)
        {
            return _db.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
        }
    }
}
