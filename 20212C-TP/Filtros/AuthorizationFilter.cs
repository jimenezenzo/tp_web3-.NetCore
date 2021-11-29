using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Filtros
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private int _perfil { get; set; }
        public AuthorizationFilter(int perfil)
        {
            _perfil = perfil;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.Get<int>("perfil") != this._perfil)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
