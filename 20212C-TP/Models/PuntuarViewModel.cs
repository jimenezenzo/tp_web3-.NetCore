using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Models
{
    public class PuntuarViewModel
    {
       
        public int IdEvento { get; set; }

        [Required(ErrorMessage = "Ingrese la Calificacion")]
        [Range(1, 5, ErrorMessage = "calificacion del 1-5")]
        public int Calificacion { get; set; }

        [Required(ErrorMessage = "Ingrese un Comentarios")]
        public string Comentarios { get; set; }
    }
}
