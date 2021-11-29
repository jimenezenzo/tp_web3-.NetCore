using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Exceptions
{
    public class CancelarEventoException : Exception
    {
        public CancelarEventoException(string message) : base(message) { }
    }
}
