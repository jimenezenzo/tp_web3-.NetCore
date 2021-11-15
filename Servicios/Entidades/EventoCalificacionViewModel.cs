using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EventoCalificacionViewModel
    {
        public decimal Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
