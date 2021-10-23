using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _20212C_TP.Models
{
    public class EventoViewModel
    {
        [Required(ErrorMessage = "Ingrese el Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese la Cantidad Comensales")]
        public int CantidadComensales { get; set; }

        [Required(ErrorMessage = "Ingrese la Ubicacion")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "Ingrese la Foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Ingrese una Precio")]
        public decimal Precio { get; set; }
    }
}
