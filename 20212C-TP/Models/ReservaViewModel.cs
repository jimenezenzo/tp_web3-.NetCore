using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _20212C_TP.Models
{
    public class ReservaViewModel
    {
        [Required(ErrorMessage = "Tenes que seleccionar una receta")]
        public int IdReceta { get; set; }
        [Required]
        public int IdEvento { get; set; }
        [Required(ErrorMessage = "Tenes que ingresar la cantidad de comensales")]
        public int CantidadComensales { get; set; }
    }
}
