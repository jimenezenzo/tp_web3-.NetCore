using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EventoCocinero
    {
        public int IdEvento { get; set; }
        public int IdCocinero { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public int CantidadComensalesEvento { get; set; }
        public string UbicacionEvento { get; set; }
        public string FotoEvento { get; set; }
        public decimal PrecioEvento { get; set; }
        public int EstadoEvento { get; set; }
        public string NombreCocinero { get; set; }
    }
}
