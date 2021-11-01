using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        public bool EsCocinero(Usuario usuario);

        public void registrarUsuario(string nombre, string email, string password, string passwordConfirmar, int perfil);

        public Usuario login(string email, string password);

        public Usuario ObtenerUsuarioPorId(int IdUsuario);
    }
}
