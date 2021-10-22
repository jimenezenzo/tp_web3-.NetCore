using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public void AgregarUsuario(Usuario usuario);

        public Usuario ObtenerUsuarioPorEmail(string email);

        public bool ValidarEmail(string email);
    }
}
