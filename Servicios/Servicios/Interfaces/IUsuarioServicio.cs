using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        public void registrarUsuario(string nombre, string email, string password, string passwordConfirmar, int perfil);
    }
}
